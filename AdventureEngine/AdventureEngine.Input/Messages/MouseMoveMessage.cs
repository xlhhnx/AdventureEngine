using AdventureEngine.Messaging;
using Microsoft.Xna.Framework;

namespace AdventureEngine.Input.Messages
{
    public class MouseMoveMessage : Message
    {
        /// <summary>
        /// Gets the new mouse position;
        /// </summary>
        public Point Position
        {
            get { return _position; }
        }

        protected Point _position;

        /// <summary>
        /// Builds a MOUSE_MOVE message.
        /// </summary>
        /// <param name="position">The new mouse position.</param>
        /// <param name="sender">The object that created the message.</param>
        public MouseMoveMessage(Point position, object sender) : base("MOUSE_MOVE", sender)
        {
            _position = position;
        }

        public override int GetHashCode()
        {
            return _position.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var equals = obj is MouseMoveMessage;
            var mObj = obj as MouseMoveMessage;

            if (equals && mObj.Position != _position)
            {
                equals = false;
            }

            return equals;
        }

        public override string ToString()
        {
            return $"{_type} : (position,{_position})";
        }
    }
}