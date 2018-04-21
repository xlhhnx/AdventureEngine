public class MouseScrollWheelChangedMessage : Message
{
    // Properties
    public int ScrollWheelChange
    {
        get { return _scrollWheelChange; }
    }

    // Variables
    protected int _scrollWheelChange;

    // Methods
    public MouseScrollWheelChangedMessage(int scrollWheelChange, object sender) : base("SCROLL_WHEEL_CHANGE", sender)
    {
        _scrollWheelChange = scrollWheelChange;
    }
}