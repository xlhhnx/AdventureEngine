using Microsoft.Xna.Framework;
using System.IO;
using System.Linq;

public static class GlobalConfiguration
{
    public static string DefaultLogName { get; set; }
    public static Vector2 DefaultDrawPosition { get; set; }
    public static Vector2 DefaultDrawDimensions { get; set; }

    public static void LoadDefaults(string globalConfigInitFile)
    {
        var lines = File.ReadLines(globalConfigInitFile)
                        .Where(l => l.Contains("="));

        foreach (string line in lines)
        {
            var split = line.Split('=');
            var id = split[0];
            var value = split[1];

            switch (id)
            {
                case ("DefaultLogName"): { DefaultLogName = value; }
                    break;
                case ("DefaultDrawPosition"): { DefaultDrawPosition = value.ToVector2(); }
                    break;
                case ("DefaultDrawDimensions"): { DefaultDrawDimensions = value.ToVector2(); }
                    break;
            }
        }
    }
}