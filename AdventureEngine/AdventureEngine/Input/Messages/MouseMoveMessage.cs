using Microsoft.Xna.Framework;

public class MouseMoveMessage : Message
{
    // Properties
    public Point Position
    {
        get { return _position; }
    }

    // Variables
    protected Point _position;

    // Method
    public MouseMoveMessage(Point position, object sender) : base("MOUSE_MOVE", sender)
    {
        _position = position;
    }
}