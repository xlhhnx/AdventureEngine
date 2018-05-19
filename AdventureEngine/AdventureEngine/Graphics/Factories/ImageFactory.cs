using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class ImageFactory
{
    // Variables
    protected SpriteBatch _spriteBatch;
    protected GraphicsManager _graphicsManager;
    protected Color _color;

    // Method
    public ImageFactory(SpriteBatch defaultSpriteBatch, GraphicsManager graphicsManger)
    {
        _spriteBatch = defaultSpriteBatch;
        _graphicsManager = graphicsManger;

        _color = Color.White;
    }

    public Image CreateImage([Optional]SpriteBatch spriteBatch, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Vector2 drawPosition, Vector2 drawDimensions, [Optional]Color color, bool enabled = true, bool visible = true)
    {
        var _spriteBatch = this._spriteBatch;
        var _color = this._color;

        // Handle optional parameters
        if (spriteBatch != null) _spriteBatch = spriteBatch;
        if (color != null) _color = color;

        return new Image(_spriteBatch, texture2DAsset, sourcePosition, sourceDimensions, drawPosition, drawDimensions, _color, enabled, visible);
    }

    public Image CreateImage([Optional] SpriteBatch spriteBatch, Texture2DAsset texture2DAsset, GraphicDefinition graphicDefinition)
    {
        if (graphicDefinition.GraphicsType.ToUpper() != "IMAGE")
        {
            LogManager.Write(1, _graphicsManager.LogName, $"GRAPHIC_DEFINITION expected type is IMAGE. Actual type is {graphicDefinition.GraphicsType.ToUpper()}.");
            return null;
        }

        var _spriteBatch = this._spriteBatch;
        var _color = this._color;

        if (graphicDefinition.ContainsParameter("SourcePosition")
            && graphicDefinition.ContainsParameter("SourceDimensions")
            && graphicDefinition.ContainsParameter("DrawPosition")
            && graphicDefinition.ContainsParameter("DrawDimensions")
            && graphicDefinition.ContainsParameter("Enabled")
            && graphicDefinition.ContainsParameter("Visible"))
        {
            var sourcePosition = graphicDefinition["SourcePosition"].ToVector2();
            var sourceDimensions = graphicDefinition["SourceDimensions"].ToVector2();
            var drawPosition = graphicDefinition["DrawPosition"].ToVector2();
            var drawDimensions = graphicDefinition["DrawDimensions"].ToVector2();
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

            return new Image(_spriteBatch, texture2DAsset, sourcePosition, sourceDimensions, drawPosition, drawDimensions, _color, enabled, visible);
        }
        else
        {
            LogManager.Write(1, _graphicsManager.LogName, $"Failed to create IMAGE id={graphicDefinition.GraphicId}. The GRAPHIC_DEFINITION is missing parameters.");
            return null;
        }
    }
}