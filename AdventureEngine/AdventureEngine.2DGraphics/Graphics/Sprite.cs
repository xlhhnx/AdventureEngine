using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite : Image
{
    /// <summary>
    /// Gets and Sets the flag that determines if the sprite loops.
    /// </summary>
    public bool Looping
    {
        get { return _looping; }
        set { _looping = value; }
    }

    protected Vector2 _sourcePosition;
    protected Vector2 _sourceDimensions;
    protected TimeSpan _elapsedTime;
    protected int _rows;
    protected int _currentRow;
    protected int _columns;
    protected int _currentColumn;
    protected bool _looping;

    /// <summary>
    /// Creates a sprite.
    /// </summary>
    /// <param name="spriteBatch">The spritebatch used to draw the sprite by default.</param>
    /// <param name="texture2DAsset">The texture the sprite is on.</param>
    /// <param name="sourcePosition">The position of the first frame.</param>
    /// <param name="sourceDimensions">The dimensions of the frame.</param>
    /// <param name="drawPosition">The position where the sprite should be drawn.</param>
    /// <param name="drawDimensions">The dimensions with which the sprite should be drawn.</param>
    /// <param name="color">The tint of the sprite.</param>
    /// <param name="rows">The number of rows of the sprite on the texture.</param>
    /// <param name="columns">The number of columns of the sprite on the texture.</param>
    /// <param name="looping">Determines if the sprite loops.</param>
    /// <param name="enabled">Determines if the sprite is enabled.</param>
    /// <param name="visible">Determines if the sprite is visible.</param>
    public Sprite(SpriteBatch spriteBatch, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Vector2 drawPosition, Vector2 drawDimensions, Color color
        , int rows, int columns, bool looping = true, bool enabled = true, bool visible = true) 
        : base(spriteBatch, texture2DAsset, sourcePosition, sourceDimensions, drawPosition, drawDimensions, color, enabled, visible)
    {
        _sourcePosition = sourcePosition;
        _sourceDimensions = sourceDimensions;
        _rows = rows;
        _columns = columns;
        _looping = looping;
        _currentRow = 0;
        _currentColumn = 0;
        _elapsedTime = new TimeSpan();
    }

    public override void Update(GameTime gameTime)
    {
        _elapsedTime += gameTime.ElapsedGameTime;

        if (_elapsedTime < new TimeSpan(0, 0, 0, 0, 200) /* Config.FrameTime */ )
        {
            _currentColumn++;
            if (_currentColumn >= _columns)
            {
                _currentColumn = 0;
                _currentRow++;
                if (_currentRow >= _rows && _looping)
                    _currentRow = 0;
            }

            _elapsedTime = new TimeSpan();
            _sourceRectangle = new Rectangle(
                (int)(_sourcePosition.X + (_currentColumn * _sourceDimensions.X)) // X position
                , (int)(_sourcePosition.Y + (_currentRow * _sourceDimensions.Y)) // Y Position
                , (int)(_sourceDimensions.X) // Width
                , (int)(_sourceDimensions.Y) // Height
                );
        }
    }

    public override Graphic Copy()
    {
        return new Sprite(_spriteBatch, _texture2DAsset, _sourceRectangle.GetPosition(), _sourceRectangle.GetDimensions()
            , DrawPosition.Copy(), DrawDimensions.Copy(), _color, _rows, _columns, _looping, _enabled, _visible);
    }
}