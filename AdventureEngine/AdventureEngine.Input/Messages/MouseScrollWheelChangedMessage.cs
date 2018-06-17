using AdventureEngine.Messaging;

namespace AdventureEngine.Input.Messages
{
    public class MouseScrollWheelChangedMessage : Message
    {
        /// <summary>
        /// Gets the amount by shich the scroll wheel changed.
        /// </summary>
        public int ScrollWheelChange { get { return _scrollWheelChange; } }

        protected int _scrollWheelChange;

        /// <summary>
        /// Builds a MOUSE_SCROLL_WHEEL_CHANGE message.
        /// </summary>
        /// <param name="scrollWheelChange">The amount by which the scroll wheel changed</param>
        /// <param name="sender">The object that created the message.</param>
        public MouseScrollWheelChangedMessage(int scrollWheelChange, object sender) : base("MOUSE_SCROLL_WHEEL_CHANGE", sender)
        {
            _scrollWheelChange = scrollWheelChange;
        }

        public override int GetHashCode()
        {
            return _scrollWheelChange.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var equals = obj is MouseScrollWheelChangedMessage;
            var mObj = obj as MouseScrollWheelChangedMessage;

            if (equals && mObj.ScrollWheelChange != _scrollWheelChange)
            {
                equals = false;
            }

            return equals;
        }

        public override string ToString()
        {
            return $"{_type} : (change,{_scrollWheelChange})";
        }
    }
}