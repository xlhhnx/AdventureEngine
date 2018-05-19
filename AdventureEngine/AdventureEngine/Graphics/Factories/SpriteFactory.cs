using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class SpriteFactory
{
    // Variables
    protected SpriteBatch _spriteBatch;
    protected GraphicsManager _graphicsManager;
    protected Color _color;

    // Method
    public SpriteFactory(SpriteBatch defaultSpriteBatch, GraphicsManager graphicsManager)
    {
        _spriteBatch = defaultSpriteBatch;
        _graphicsManager = graphicsManager;

        _color = Color.White;
    }

    public Sprite CreateSprite([Optional]SpriteBatch spriteBatch, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Vector2 drawPosition, Vector2 drawDimensions
        , [Optional]Color color, int rows = 1, int columns = 1, bool looping = true, bool enabled = true, bool visible = true)
    {
        var _spriteBatch = this._spriteBatch;
        var _color = this._color;

        // Handle optional parameters
        if (spriteBatch != null) _spriteBatch = spriteBatch;
        if (color != null) _color = color;

        return new Sprite(_spriteBatch, texture2DAsset, sourcePosition, sourceDimensions, drawPosition, drawDimensions, _color, rows, columns, looping, enabled, visible);
    }

    public Sprite CreateSprite([Optional] SpriteBatch spriteBatch, Texture2DAsset texture2DAsset, GraphicDefinition graphicDefinition)
    {
        if (graphicDefinition.GraphicsType.ToUpper() != "SPRITE")
        {
            LogManager.Write(1, _graphicsManager.LogName, $"GRAPHIC_DEFINITION expected type is SPRITE. Actual type is {graphicDefinition.GraphicsType.ToUpper()}.");
            return null;
        }

        var _spriteBatch = this._spriteBatch;
        var _color = this._color;

        if (graphicDefinition.ContainsParameter("SourcePosition")
            && graphicDefinition.ContainsParameter("SourceDimensions")
            && graphicDefinition.ContainsParameter("DrawPosition")
            && graphicDefinition.ContainsParameter("DrawDimensions")
            && graphicDefinition.ContainsParameter("Rows")
            && graphicDefinition.ContainsParameter("Columns")
            && graphicDefinition.ContainsParameter("Looping")
            && graphicDefinition.ContainsParameter("Enabled")
            && graphicDefinition.ContainsParameter("Visible"))
        {
            var sourcePosition = graphicDefinition["SourcePosition"].ToVector2();
            var sourceDimensions = graphicDefinition["SourceDimensions"].ToVector2();
            var drawPosition = graphicDefinition["DrawPosition"].ToVector2();
            var drawDimensions = graphicDefinition["DrawDimensions"].ToVector2();
            var rows = int.Parse(graphicDefinition["Rows"]);
            var columns = int.Parse(graphicDefinition["Columns"]);
            var looping = bool.Parse(graphicDefinition["Looping"]);
            var enabled = bool.Parse(graphicDefinition["Enabled"]);
            var visible = bool.Parse(graphicDefinition["Visible"]);

            if (graphicDefinition.ContainsParameter("Color"))
            {
                _color = graphicDefinition["Color"].ToColor();
            }

            if (spriteBatch != null)
            {
                _spriteBatch = spriteBatch;
            }

            return new Sprite(_spriteBatch, texture2DAsset, sourcePosition, sourceDimensions, drawPosition, drawDimensions, _color, rows, columns, looping, enabled, visible);
        }
        else
        {
            LogManager.Write(1, _graphicsManager.LogName, $"Failed to create SPRITE id={graphicDefinition.GraphicId}. The GRAPHIC_DEFINITION is missing parameters.");
            return null;
        }
    }
}