using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite : Image
{
    // Properties

    // Variables
    protected Vector2 _sourcePosition;
    protected Vector2 _sourceDimensions;
    protected TimeSpan _elapsedTime;
    protected int _rows;
    protected int _currentRow;
    protected int _columns;
    protected int _currentColumn;
    protected bool _looping;

    // Method
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

    public Sprite Copy()
    {
        return new Sprite(_spriteBatch, _texture2DAsset, _sourceRectangle.GetPosition(), _sourceRectangle.GetDimensions()
            , DrawPosition.Copy(), DrawDimensions.Copy(), _color, _rows, _columns, _looping, _enabled, _visible);
    }
}