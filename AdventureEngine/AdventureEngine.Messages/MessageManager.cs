using Microsoft.Xna.Framework;
using System.Collections.Generic;

public static class MessageManager
{
    /// <summary>
    /// Get and Sets the MessageManager's logger.
    /// </summary>
    public static Logger Logger { get; set; }

    private static Queue<Message> _messageQueue = new Queue<Message>();
    private static List<ISubscriber> _subscribers = new List<ISubscriber>();

    /// <summary>
    /// Checks is a subscriber is already subscribed.
    /// </summary>
    /// <param name="subscriber">The subscriber to check.</param>
    /// <returns>Determines whether the subscriber is already subscribed.</returns>
    public static bool ContainsSubscriber(ISubscriber subscriber)
    {
        return _subscribers.Contains(subscriber);
    }

    /// <summary>
    /// Adds a subscriber to the subscriber list.
    /// </summary>
    /// <param name="subscriber">The subscriber to add.</param>
    public static void AddSubscriber(ISubscriber subscriber)
    {
        if (!ContainsSubscriber(subscriber))
        {
            _subscribers.Add(subscriber);
        }
    }

    /// <summary>
    /// Removes a subscriber from the subscriber list.
    /// </summary>
    /// <param name="subscriber">The subscriber to remove.</param>
    public static void RemoveSubScriber(ISubscriber subscriber)
    {
        if (ContainsSubscriber(subscriber))
        {
            _subscribers.Remove(subscriber);
        }
    }

    /// <summary>
    /// Enqueues a message.
    /// </summary>
    /// <param name="message">The message to enqueue.</param>
    public static void EnqueueMessage(Message message)
    {
        _messageQueue.Enqueue(message);
    }

    /// <summary>
    /// Sends all enqueued messages to all subscribers.
    /// </summary>
    public static void Update()
    {
        var _executionQueue = new Queue<Message>(_messageQueue);
        _messageQueue = new Queue<Message>();

        foreach (var msg in _executionQueue)
        {
            if (Logger != null)
            {
                Logger.Write(msg.ToString(), LogLevel.INFO);
            }

            foreach (var sub in _subscribers)
            {
                sub.ReceiveMessage(msg);
            }
        }
    }
}