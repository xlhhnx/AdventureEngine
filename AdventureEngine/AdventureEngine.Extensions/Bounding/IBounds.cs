using Microsoft.Xna.Framework;

public interface IBounds
{
    Vector2 Position { get; set; }

    bool Contains(Vector2 point);
    bool Contains(Point point);
}