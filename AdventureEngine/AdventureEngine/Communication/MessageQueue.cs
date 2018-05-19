﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public static class MessageQueue
{
    // Variables
    private static int _nextId = 0;
    private static List<Subscriber> _subscribers = new List<Subscriber>();
    private static Queue<Message> _messageQueue = new Queue<Message>();

    private static readonly string _logName = "msgLog";

    // Methods
    public static void Initialize(int nextId = 0)
    {
        _nextId = nextId;
        LogManager.AddLogger(_logName, new Logger($"MessageLog.log", 3, FileMode.Create));
    }

    public static void Subscribe(Subscriber subscriber)
    {
        if (!_subscribers.Contains(subscriber))
        {
            _subscribers.Add(subscriber);
        }
    }

    public static void Unsubscribe(Subscriber subscriber)
    {
        if (_subscribers.Contains(subscriber))
        {
            _subscribers.Remove(subscriber);
        }
    }

    public static void EnqueueMessage(Message message)
    {
        _messageQueue.Enqueue(message);
    }

    public static void Update(GameTime gameTime, [Optional]TimeSpan timeModifier)
    {
        Queue<Message> _executingMessages = new Queue<Message>(_messageQueue);
        _messageQueue = new Queue<Message>();

        foreach (Message msg in _executingMessages)
        {
            if (timeModifier != null)
            {
                msg.ExecutionTime = gameTime.ElapsedGameTime - timeModifier;
            }
            else
            {
                msg.ExecutionTime = gameTime.ElapsedGameTime;
            }

            LogManager.Write(msg.LogLevel, _logName, msg.ToString());
            foreach (Subscriber sub in _subscribers)
                sub.ReceiveMessage(msg);
        }
    }
}