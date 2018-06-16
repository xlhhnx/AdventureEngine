using System;

namespace AdventureEngine.Messaging
{
    public class Message
    {
        /// <summary>
        /// Gets the message type.
        /// </summary>
        public string Type { get { return _type; } }

        /// <summary>
        /// Gets the sender.
        /// </summary>
        public object Sender { get { return _sender; } }

        protected string _type;
        protected object _sender;

        /// <summary>
        /// Constructs a Message.
        /// </summary>
        /// <param name="type">The type of message.</param>
        /// <param name="sender">The message's sender.</param>
        public Message(string type, object sender)
        {
            _type = type;
            _sender = sender;
        }
    }
}