using Microsoft.Xna.Framework;

public static class Vector2Extensions
{
    public static Vector2 Copy(this Vector2 vector)
    {
        return new Vector2(vector.X, vector.Y);
    } 
}