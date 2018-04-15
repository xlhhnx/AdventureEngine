using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class SpriteFactory
{
    // Variables
    protected SpriteBatch _spriteBatch;
    protected Color _color;

    // Method
    public SpriteFactory(SpriteBatch defaultSpriteBatch)
    {
        _spriteBatch = defaultSpriteBatch;

        _color = Color.White;
    }

    public Sprite CreateSprite(Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Vector2 drawPosition, Vector2 drawDimensions
        , [Optional]SpriteBatch spriteBatch, [Optional]Color color, int rows = 1, int columns = 1, bool looping = true, bool enabled = true, bool visible = true)
    {
        SpriteBatch _spriteBatch = this._spriteBatch;
        Color _color = this._color;

        // Handle optional parameters
        if (spriteBatch != null) _spriteBatch = spriteBatch;
        if (color != null) _color = color;

        return new Sprite(_spriteBatch, texture2DAsset, sourcePosition, sourceDimensions, drawPosition, drawDimensions, _color, rows, columns, looping, enabled, visible);
    }
}