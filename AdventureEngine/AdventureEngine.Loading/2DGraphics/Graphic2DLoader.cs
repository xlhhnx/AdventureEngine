using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Graphic2DLoader : IGraphic2DLoader
{
    protected AssetManager _assetManager;

    public Graphic2DLoader(AssetManager assetManager)
    {
        _assetManager = assetManager;
    }

    public Graphic2D LoadGraphic(string filePath, string id)
    {
        var graphic = File.ReadAllLines(filePath).Where(l => l.Trim().Length > 0)
                                                 .Where(l => l.Trim().StartsWith("graphic"))
                                                 .Where(l => l.Contains(id))
                                                 .Select(l => ParseGraphic(l))
                                                 .FirstOrDefault();
        return graphic;
    }

    public List<Graphic2D> LoadGraphics(string filePath)
    {
        var graphics = File.ReadAllLines(filePath).Where(l => l.Trim().Length > 0)
                                                 .Where(l => l.Trim().StartsWith("graphic"))
                                                 .Select(l => ParseGraphic(l))
                                                 .ToList();
        return graphics;
    }

    private Graphic2D ParseGraphic(string graphicDefinition)
    {
        Graphic2D graphic = null;
        var arguments = graphicDefinition.Split(';');

        // If the string provided is not a graphic definition return null
        if (arguments[0].Trim().ToLower() != "graphic") return null;

        var id = arguments[1];
        var parameters = arguments.Where(a => a.Contains("="))
                                  .ToList();

        var type = "";

        foreach (var p in parameters)
        {
            var pair = p.Split('=');
            if (pair[0].Trim().ToLower() == "type")
            {
                type = pair[1].Trim().ToLower();
                break;
            }
        }

        switch (type.Trim().ToLower())
        {
            case ("text"): { graphic = ParseText(id, parameters); } break;
            case ("image"): { graphic = ParseImage(id, parameters); } break;
            case ("sprite"): { graphic = ParseSprite(id, parameters); } break;
        }

        return graphic;
    }

    private Text ParseText(string id, List<string> parameters)
    {
        var name = "";
        var spriteFontAssetId = "";
        Color color = new Color();
        Color disabledColor = new Color();
        Vector2 positionOffset = new Vector2();
        Vector2 dimensions = new Vector2();
        var fullText = "";

        foreach (var p in parameters)
        {
            var pair = p.Split('=');
            switch (pair[0].Trim().ToLower())
            {
                case ("name"):
                    {
                        name = pair[1].ToLower();
                    }
                    break;
                case ("spritefontassetid"):
                    {
                        spriteFontAssetId = pair[1].Trim().ToLower();
                    }
                    break;
                case ("color"):
                    {
                        color = pair[1].Trim().ToLower().ToColor();
                    }
                    break;
                case ("disabledcolor"):
                    {
                        disabledColor = pair[1].Trim().ToLower().ToColor();
                    }
                    break;
                case ("positionoffset"):
                    {
                        positionOffset = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("dimensions"):
                    {
                        dimensions = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("fulltext"):
                    {
                        fullText = pair[1].ToLower();
                    }
                    break;
            }
        }

        var spriteFontAsset = _assetManager.GetAsset(spriteFontAssetId);
        if (spriteFontAsset == null)
        {
            spriteFontAsset = _assetManager.DefaultSpriteFontAsset;
        }

        return new Text(id, name, (SpriteFontAsset)spriteFontAsset, color, disabledColor, positionOffset, dimensions, fullText);
    }

    private Image ParseImage(string id, List<string> parameters)
    {
        var name = "";
        var texture2DAssetId = "";
        Color color = new Color();
        Vector2 sourcePosition = new Vector2();
        Vector2 sourceDimensions = new Vector2();
        Vector2 positionOffset = new Vector2();
        Vector2 dimensions = new Vector2();
        var enabled = true;
        var visible = true;

        foreach (var p in parameters)
        {
            var pair = p.Split('=');
            switch (pair[0].Trim().ToLower())
            {
                case ("name"):
                    {
                        name = pair[1].ToLower();
                    }
                    break;
                case ("texture2dassetid"):
                    {
                        texture2DAssetId = pair[1].Trim().ToLower();
                    }
                    break;
                case ("color"):
                    {
                        color = pair[1].Trim().ToLower().ToColor();
                    }
                    break;
                case ("sourceposition"):
                    {
                        sourcePosition = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("sourcedimensions"):
                    {
                        sourceDimensions = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("positionoffset"):
                    {
                        positionOffset = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("dimensions"):
                    {
                        dimensions = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("enabled"):
                    {
                        enabled = pair[1].Trim().ToLower().ToBool();
                    }
                    break;
                case ("visible"):
                    {
                        visible = pair[1].Trim().ToLower().ToBool();
                    }
                    break;
            }
        }

        var texture2DAsset = _assetManager.GetAsset(texture2DAssetId);
        if (texture2DAsset == null)
        {
            texture2DAsset = _assetManager.DefaultTexture2DAsset;
        }

        return new Image(id, name, (Texture2DAsset)texture2DAsset, sourcePosition, sourceDimensions, color, positionOffset, dimensions, enabled, visible);
    }

    private Sprite ParseSprite(string id, List<string> parameters)
    {
        var name = "";
        var texture2DAssetId = "";
        Color color = new Color();
        Vector2 sourcePosition = new Vector2();
        Vector2 sourceDimensions = new Vector2();
        Vector2 positionOffset = new Vector2();
        Vector2 dimensions = new Vector2();
        var rows = 1;
        var columns = 1;
        var looping = true;
        var enabled = true;
        var visible = true;

        foreach (var p in parameters)
        {
            var pair = p.Split('=');
            switch (pair[0].Trim().ToLower())
            {
                case ("name"):
                    {
                        name = pair[1].ToLower();
                    }
                    break;
                case ("texture2dassetid"):
                    {
                        texture2DAssetId = pair[1].Trim().ToLower();
                    }
                    break;
                case ("color"):
                    {
                        color = pair[1].Trim().ToLower().ToColor();
                    }
                    break;
                case ("sourceposition"):
                    {
                        sourcePosition = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("sourcedimensions"):
                    {
                        sourceDimensions = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("positionoffset"):
                    {
                        positionOffset = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("dimensions"):
                    {
                        dimensions = pair[1].Trim().ToLower().ToVector2();
                    }
                    break;
                case ("rows"):
                    {
                        rows = pair[1].Trim().ToLower().ToInt32();
                    }
                    break;
                case ("columns"):
                    {
                        columns = pair[1].Trim().ToLower().ToInt32();
                    }
                    break;
                case ("looping"):
                    {
                        looping = pair[1].Trim().ToLower().ToBool();
                    }
                    break;
                case ("enabled"):
                    {
                        enabled = pair[1].Trim().ToLower().ToBool();
                    }
                    break;
                case ("visible"):
                    {
                        visible = pair[1].Trim().ToLower().ToBool();
                    }
                    break;
            }
        }

        var texture2DAsset = _assetManager.GetAsset(texture2DAssetId);
        if (texture2DAsset == null)
        {
            texture2DAsset = _assetManager.DefaultTexture2DAsset;
        }

        return new Sprite(id, name, (Texture2DAsset)texture2DAsset, sourcePosition, sourceDimensions, color, positionOffset, dimensions, rows,  columns, looping, enabled, visible);
    }
}