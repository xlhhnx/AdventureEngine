using Microsoft.Xna.Framework;

namespace AdventureEngine.Common.Bounding
{
    public interface IBounds
    {
        Vector2 Position { get; set; }

        bool Contains(Vector2 point);
        bool Contains(Point point);
    }
}