using Microsoft.Xna.Framework;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public static class StringExtensions
{
    /// <summary>
    /// Parses a string into a Vector2.
    /// </summary>
    /// <param name="s">The string to be parsed.</param>
    /// <returns>A Vector.</returns>
    public static Vector2 ToVector2(this string s)
    {
        var split = s.Trim('(', ')')
                     .Split(new char[] { ',' }, 2);

        return new Vector2(float.Parse(split[0]), float.Parse(split[1]));
    }

    /// <summary>
    /// Parses a string into a color.
    /// </summary>
    /// <param name="s">The string to be parsed.</param>
    /// <returns>A Color or null.</returns>
    public static Color? ToColor(this string s)
    {
        
        if (Regex.IsMatch(s, @"\([0-9]*,[0-9]*,[0-9]*,[0-9]*\)"))
        {
            var rgba = Regex.Match(s, @"\([0-9]*,[0-9]*,[0-9]*,[0-9]*\)").Value;

            var split = rgba.Trim('(', ')')
                            .Split(',');

            var r = byte.Parse(split[0]);
            var g = byte.Parse(split[1]);
            var b = byte.Parse(split[2]);
            var a = byte.Parse(split[3]);

            return new Color(r,g,b,a);
        }
        else if (Regex.IsMatch(s, @"\([0-9]*,[0-9]*,[0-9]*\)"))
        {
            var rgb = Regex.Match(s, @"\([0-9]*,[0-9]*,[0-9]*\)").Value;

            var split = rgb.Trim('(', ')')
                           .Split(',');

            var r = byte.Parse(split[0]);
            var g = byte.Parse(split[1]);
            var b = byte.Parse(split[2]);
            var a = (byte)255;

            return new Color(r,g,b,a);
        }
        else if (s.StartsWith("#"))
        {
            var hex = Regex.Match(s.ToUpper(), @"#[0-9A-F]{6}").Value;

            var r = byte.Parse(s.Substring(1, 2), NumberStyles.HexNumber);
            var g = byte.Parse(s.Substring(3, 2), NumberStyles.HexNumber);
            var b = byte.Parse(s.Substring(5, 2), NumberStyles.HexNumber);
            var a = (byte)255;

            return new Color(r,g,b,a);
        }
        else if (s.StartsWith("0x"))
        {
            var hex = Regex.Match(s.ToUpper(), @"#[0-9A-F]{6}").Value;

            var r = byte.Parse(s.Substring(2, 2), NumberStyles.HexNumber);
            var g = byte.Parse(s.Substring(4, 2), NumberStyles.HexNumber);
            var b = byte.Parse(s.Substring(6, 2), NumberStyles.HexNumber);
            var a = (byte)255;

            return new Color(r, g, b, a);
        }
        else
        {
            return null;
        }
    }
}