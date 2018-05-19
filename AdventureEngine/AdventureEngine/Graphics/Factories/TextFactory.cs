using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class TextFactory
{
    // Variables
    protected SpriteBatch _spriteBatch;
    protected Color _color;
    protected Color _disabledColor;
    protected GraphicsManager _graphicsManager;

    // Method
    public TextFactory(SpriteBatch defaultSpriteBatch, GraphicsManager graphicsManager)
    {
        _spriteBatch = defaultSpriteBatch;
        _graphicsManager = graphicsManager;

        _color = Color.White;
        _disabledColor = Color.Gray;
    }

    public Text CreateText([Optional]SpriteBatch spriteBatch, SpriteFontAsset spriteFontAsset, Vector2 drawPosition, Vector2 drawDimensions, [Optional]Color color, [Optional]Color disabledColor, string fullText = "")
    {
        var _spriteBatch = this._spriteBatch;
        var _color = this._color;
        var _disabledColor = this._disabledColor;

        if (spriteBatch != null) _spriteBatch = spriteBatch;
        if (color != null) _color = color;
        if (disabledColor != null) _disabledColor = disabledColor;

        return new Text(_spriteBatch, spriteFontAsset, drawPosition, drawDimensions, _color, _disabledColor, fullText);
    }

    public Text CreateText([Optional]SpriteBatch spriteBatch, SpriteFontAsset spriteFontAsset, GraphicDefinition graphicDefinition)
    {
        if (graphicDefinition.GraphicsType.ToUpper() != "TEXT")
        {
            LogManager.Write(1, _graphicsManager.LogName, $"GRAPHIC_DEFINITION expected type is TEXT. Actual type is {graphicDefinition.GraphicsType.ToUpper()}.");
            return null;
        }
        
        var _spriteBatch = this._spriteBatch;
        var _color = this._color;
        var _disabledColor = this._disabledColor;

        if (graphicDefinition.ContainsParameter("DrawPosition")
            && graphicDefinition.ContainsParameter("DrawDimensions")
            && graphicDefinition.ContainsParameter("FullText"))
        {
            var drawPosition = graphicDefinition["DrawPosition"].ToVector2();
            var drawDimensions = graphicDefinition["DrawDimensions"].ToVector2();
            var fullText = graphicDefinition["FullText"];

            if (graphicDefinition.ContainsParameter("Color"))
            {
                _color = graphicDefinition["Color"].ToColor();
            }

            if (graphicDefinition.ContainsParameter("DisbledColor"))
            {
                _disabledColor = graphicDefinition["DisabledColor"].ToColor();
            }

            if (spriteBatch != null)
            {
                _spriteBatch = spriteBatch;
            }

            return new Text(_spriteBatch, spriteFontAsset, drawPosition, drawDimensions, _color, _disabledColor, fullText);
        }
        else
        {
            LogManager.Write(1, _graphicsManager.LogName, $"Failed to create TEXT id={graphicDefinition.GraphicId}. The GRAPHIC_DEFINITION is missing parameters.");
            return null;
        }
    }
}