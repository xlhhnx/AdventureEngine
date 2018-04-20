using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class MessageQueue
{

    protected List<Subscriber> _subscribers;
    protected Queue<Message> _messageQueue;

    public MessageQueue()
    {
        _subscribers = new List<Subscriber>();
        _messageQueue = new Queue<Message>();
    }

    public void Subscribe(Subscriber subscriber)
    {
        if (!_subscribers.Contains(subscriber))
            _subscribers.Add(subscriber);
    }

    public void Unsubscribe(Subscriber subscriber)
    {
        if (_subscribers.Contains(subscriber))
            _subscribers.Remove(subscriber);
    }

    public void EnqueueMessage(Message message)
    {
        _messageQueue.Enqueue(message);
    }

    public void Update(GameTime gameTime, [Optional]TimeSpan startTime)
    {
        Queue<Message> _executingMessages = new Queue<Message>(_messageQueue);
        _messageQueue = new Queue<Message>();

        foreach (Message msg in _executingMessages)
        {
            if (startTime != null)
                msg.ExecutionTime = gameTime.ElapsedGameTime - startTime;
            else
                msg.ExecutionTime = gameTime.ElapsedGameTime;

            foreach (Subscriber sub in _subscribers)
                sub.ReceiveMessage(msg);
        }
    }
}