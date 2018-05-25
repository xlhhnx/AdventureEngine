using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Image : Graphic
{
    /// <summary>
    /// Gets and Sets the position where the image is drawn.
    /// </summary>
    public override Vector2 DrawPosition
    {
        get { return _drawRectangle.Location.ToVector2(); }
        set { _drawRectangle = new Rectangle(value.ToPoint(), _drawRectangle.Size); }
    }

    /// <summary>
    /// Gets and Sets the dimensions in which the image is drawn.
    /// </summary>
    public override Vector2 DrawDimensions
    {
        get { return _drawRectangle.Size.ToVector2(); }
        set { _drawRectangle = new Rectangle(_drawRectangle.Location, value.ToPoint()); }
    }
    
    protected Texture2DAsset _texture2DAsset;
    protected Rectangle _drawRectangle;
    protected Rectangle _sourceRectangle;
    protected Color _color;

    /// <summary>
    /// Creates an image.
    /// </summary>
    /// <param name="spriteBatch">The spritebatch used to draw the image by default.</param>
    /// <param name="texture2DAsset">The texture the image is on.</param>
    /// <param name="sourcePosition">The position of the frame.</param>
    /// <param name="sourceDimensions">The dimensions of the frame.</param>
    /// <param name="drawPosition">The position where the image should be drawn.</param>
    /// <param name="drawDimensions">The dimensions with which the image should be drawn.</param>
    /// <param name="color">The tint of the image.</param>
    /// <param name="enabled">Determines if the image is enabled.</param>
    /// <param name="visible">Determines if the image is visible.</param>
    public Image(SpriteBatch spriteBatch, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Vector2 drawPosition, Vector2 drawDimensions, Color color
        , bool enabled = true, bool visible = true)
    {
        _spriteBatch = spriteBatch;
        _texture2DAsset = texture2DAsset;
        _sourceRectangle = new Rectangle(sourcePosition.ToPoint(), sourceDimensions.ToPoint());
        _drawRectangle = new Rectangle(drawPosition.ToPoint(), drawDimensions.ToPoint());
        _enabled = enabled;
        _visible = visible;
    }
    
    public override void Update(GameTime gameTime)
    {
        // No op
    }
    
    public override Graphic Copy()
    {
        return new Image(_spriteBatch, _texture2DAsset, _sourceRectangle.GetPosition(), _sourceRectangle.GetDimensions()
            , DrawPosition.Copy(), DrawDimensions.Copy(), _color, _enabled, _visible);
    }
    public override void Draw(GameTime gameTime)
    {
        if (Visible && _texture2DAsset.Loaded)
        {
            if (Enabled)
                _spriteBatch.Draw(_texture2DAsset.Texture, _drawRectangle, _sourceRectangle, _color);
            else
                _spriteBatch.Draw(_texture2DAsset.Texture, _drawRectangle, _sourceRectangle, Color.Gray);
        }
    }

    public override void Draw(GameTime gameTime, Vector2? drawPosition, SpriteBatch spriteBatch)
    {
        Vector2 _drawPosition = DrawPosition;
        SpriteBatch _spriteBatch = this._spriteBatch;

        // Handle optional parameters
        if (drawPosition.HasValue) _drawPosition = drawPosition.Value;
        if (spriteBatch != null) _spriteBatch = spriteBatch;

        if (Visible && _texture2DAsset.Loaded)
        {
            if (Enabled)
                _spriteBatch.Draw(_texture2DAsset.Texture, _drawPosition, _sourceRectangle, _color);
            else
                _spriteBatch.Draw(_texture2DAsset.Texture, _drawPosition, _sourceRectangle, Color.Gray);
        }
    }
}