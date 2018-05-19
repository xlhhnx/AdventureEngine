using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

public class GraphicsManager
{
    // Properties
    public string LogName { get { return _logName; } }

    // Variables
    protected Dictionary<string, Image> _images;
    protected Dictionary<string, Sprite> _sprites;
    protected Dictionary<string, Text> _texts;
    protected Dictionary<string, GraphicDefinition> _graphicDefinitions;
    protected AssetManager _assetManager;
    protected ImageFactory _imageFactory;
    protected SpriteFactory _spriteFactory;
    protected TextFactory _textFactory;
    protected string _logName;

    // Methods
    public GraphicsManager(SpriteBatch defaultSpriteBatch, AssetManager assetManager, [Optional]string logName)
    {
        _assetManager = assetManager;

        _imageFactory = new ImageFactory(defaultSpriteBatch, this);
        _spriteFactory = new SpriteFactory(defaultSpriteBatch, this);
        _textFactory = new TextFactory(defaultSpriteBatch, this);

        _images = new Dictionary<string, Image>();
        _sprites = new Dictionary<string, Sprite>();
        _texts = new Dictionary<string, Text>();
        _graphicDefinitions = new Dictionary<string, GraphicDefinition>();

        if (logName != null) _logName = logName;
        else _logName = GlobalConfiguration.DefaultLogName;
    }

    public void LoadGraphicDefinitions(string filePath)
    {
        bool collecting = false;
        string currentJSON = "";

        using (var reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // IF line is an object start THEN set collecting flag
                if (line.Contains("{"))
                    collecting = true;

                // IF in an object THEN add the line to the string
                if (collecting)
                    currentJSON += '\n' + line;

                // IF line is an object end THEN deserialize the whole object
                if (line.Contains("}"))
                {
                    collecting = false;
                    var definition = JsonConvert.DeserializeObject<GraphicDefinition>(currentJSON);
                    _graphicDefinitions.Add(definition.GraphicId, definition);
                    currentJSON = string.Empty;
                }
            }
        }
    }

    public Image GetImage(string id, [Optional] SpriteBatch spriteBatch)
    {
        if (_images.ContainsKey(id))
        {
            return _images[id].Copy();
        }
        else if (_graphicDefinitions.ContainsKey(id))
        {
            if (!_assetManager.AssetObjects.ContainsKey(id))
            {
                LogManager.Write(1, _logName, $"ASSET_OBJECT with id={id} is not loaded.");
                return null;
            }
            else if (!(_assetManager.AssetObjects[id] is Texture2DAsset))
            {
                LogManager.Write(1, _logName, $"ASSET_OBJECT with id={id} is not of expected type TEXTURE_2D_ASSET.");
                return null;
            }

            var texture2DAsset = _assetManager.AssetObjects[id] as Texture2DAsset;
            var image = _imageFactory.CreateImage(spriteBatch, texture2DAsset, _graphicDefinitions[id]);
            _images.Add(id, image);
            return image;
        }
        else
        {
            LogManager.Write(1, _logName, $"Could not find IMAGE with id={id}");
        }

        return null;
    }

    public Sprite GetSprite(string id, [Optional] SpriteBatch spriteBatch)
    {
        if (_sprites.ContainsKey(id))
        {
            return _sprites[id].Copy();
        }
        else if (_graphicDefinitions.ContainsKey(id))
        {
            if (!_assetManager.AssetObjects.ContainsKey(id))
            {
                LogManager.Write(1, _logName, $"ASSET_OBJECT with id={id} is not loaded.");
                return null;
            }
            else if (!(_assetManager.AssetObjects[id] is Texture2DAsset))
            {
                LogManager.Write(1, _logName, $"ASSET_OBJECT with id={id} is not of expected type TEXTURE_2D_ASSET.");
                return null;
            }

            var texture2DAsset = _assetManager.AssetObjects[id] as Texture2DAsset;
            var sprite = _spriteFactory.CreateSprite(spriteBatch, texture2DAsset, _graphicDefinitions[id]);
            _sprites.Add(id, sprite);
            return sprite;
        }
        else
        {
            LogManager.Write(1, _logName, $"Could no find the SPRITE with id={id}");
            return null;
        }
    }

    public Text GetText(string id, [Optional] SpriteBatch spriteBatch, string fullText = "")
    {
        if (_texts.ContainsKey(id))
        {
            return _texts[id].Copy();
        }
        else if (_graphicDefinitions.ContainsKey(id))
        {
            if (!_assetManager.AssetObjects.ContainsKey(id))
            {
                LogManager.Write(1, _logName, $"ASSET_OBJECT with id={id} is not loaded.");
                return null;
            }
            else if (!(_assetManager.AssetObjects[id] is SpriteFontAsset))
            {
                LogManager.Write(1, _logName, $"ASSET_OBJECT with id={id} is not of expected type SPRITE_FONT_ASSET.");
                return null;
            }

            var spriteFontAsset = _assetManager.AssetObjects[id] as SpriteFontAsset;
            var text = _textFactory.CreateText(spriteBatch, spriteFontAsset, _graphicDefinitions[id]);
            _texts.Add(id, text);
            return text;
        }
        else
        {
            LogManager.Write(1, _logName, $"Could no find the TEXT with id={id}");
            return null;
        }
    }
}