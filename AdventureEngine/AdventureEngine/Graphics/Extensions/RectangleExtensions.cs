using Microsoft.Xna.Framework;

public static class RectangleExtensions
{
    public static Vector2 GetPosition(this Rectangle rectangle)
    {
        return new Vector2(rectangle.X, rectangle.Y);
    }

    public static Vector2 GetDimensions(this Rectangle rectangle)
    {
        return new Vector2(rectangle.Width, rectangle.Height);
    }

    public static Rectangle Copy(this Rectangle rectangle)
    {
        return new Rectangle(rectangle.Location, rectangle.Size);
    }
}