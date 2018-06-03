using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Image : Graphic2D
{    
    /// <summary>
    /// Gets the texture asset for this image.
    /// </summary>
    public Texture2DAsset Texture2DAsset { get { return _texture2DAsset; } }

    public Rectangle SourceRectangle { get { return _sourceRectangle; } }

    /// <summary>
    /// Gets the tint color for this image.
    /// </summary>
    public Color Color { get { return _color; } }

    protected Texture2DAsset _texture2DAsset;
    protected Rectangle _sourceRectangle;
    protected Color _color;

    /// <summary>
    /// Creates an image.
    /// </summary>
    /// <param name="texture2DAsset">The texture the image is on.</param>
    /// <param name="sourcePosition">The position of the frame.</param>
    /// <param name="sourceDimensions">The dimensions of the frame.</param>
    /// <param name="color">The tint of the image.</param>
    /// <param name="enabled">Determines if the image is enabled.</param>
    /// <param name="visible">Determines if the image is visible.</param>
    public Image(string entityId, string name, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Color color, Vector2 positionOffset, Vector2 dimsensions, bool enabled = true, bool visible = true)
    {
        _entityId = entityId;
        _name = name;
        _texture2DAsset = texture2DAsset;
        _sourceRectangle = new Rectangle(sourcePosition.ToPoint(), sourceDimensions.ToPoint());
        _positionOffset = positionOffset;
        _dimensions = dimsensions;
        _enabled = enabled;
        _visible = visible;
    }
    
    public override Graphic2D Copy()
    {
        return new Image(_entityId, _name, _texture2DAsset, _sourceRectangle.GetPosition(), _sourceRectangle.GetDimensions(), _color, _positionOffset, _dimensions, _enabled, _visible);
    }

    //public override void Draw(GameTime gameTime)
    //{
    //    if (Visible && _texture2DAsset.Loaded)
    //    {
    //        if (Enabled)
    //            _spriteBatch.Draw(_texture2DAsset.Texture, _drawRectangle, _sourceRectangle, _color);
    //        else
    //            _spriteBatch.Draw(_texture2DAsset.Texture, _drawRectangle, _sourceRectangle, Color.Gray);
    //   
    //}

    //public override void Draw(GameTime gameTime, Vector2? drawPosition, SpriteBatch spriteBatch)
    //{
    //    Vector2 _drawPosition = DrawPosition;
    //    SpriteBatch _spriteBatch = this._spriteBatch;

    //    // Handle optional parameters
    //    if (drawPosition.HasValue) _drawPosition = drawPosition.Value;
    //    if (spriteBatch != null) _spriteBatch = spriteBatch;

    //    if (Visible && _texture2DAsset.Loaded)
    //    {
    //        if (Enabled)
    //            _spriteBatch.Draw(_texture2DAsset.Texture, _drawPosition, _sourceRectangle, _color);
    //        else
    //            _spriteBatch.Draw(_texture2DAsset.Texture, _drawPosition, _sourceRectangle, Color.Gray);
    //    }
    //}
}