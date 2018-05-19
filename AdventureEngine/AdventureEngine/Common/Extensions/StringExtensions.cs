using Microsoft.Xna.Framework;

public static class StringExtensions
{
    public static Vector2 ToVector2(this string s)
    {
        var split = s.Trim('(',')')
                     .Split(new char[] { ',' }, 2);

        return new Vector2(float.Parse(split[0]), float.Parse(split[1]));
    }

    public static Color ToColor(this string s)
    {
        var split = s.Trim('(', ')')
                     .Split(new char[] { ',' }, 4);

        if (split.Length == 4)
        {
            // rgba
            return new Color(
                float.Parse(split[0]),
                float.Parse(split[1]),
                float.Parse(split[2]),
                float.Parse(split[3])
                );
        }
        else
        {
            // rgb
            return new Color(
                float.Parse(split[0]),
                float.Parse(split[1]),
                float.Parse(split[2])
                );
        }
    }
}