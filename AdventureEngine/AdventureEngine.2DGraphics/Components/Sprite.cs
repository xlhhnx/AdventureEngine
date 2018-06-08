using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Sprite : Image, IComponent
{
    public override bool Loaded { get { return _texture2DAsset.Loaded; } }
    
    public bool Looping
    {
        get { return _looping; }
        set { _looping = value; }
    }
    
    public override GraphicType GraphicType { get { return GraphicType.Sprite; } }

    public TimeSpan ElapsedTime
    {
        get { return _elapsedTime; }
        set { _elapsedTime = value; }
    }

    
    protected int _rows;
    protected int _currentRow;
    protected int _columns;
    protected int _currentColumn;
    protected bool _looping;
    protected Vector2 _sourcePosition;
    protected Vector2 _sourceDimensions;
    protected TimeSpan _elapsedTime;


    public Sprite(string entityId, string name, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Color color, Vector2 positionOffset, Vector2 dimensions, int rows, int columns, bool looping = true, bool enabled = true, bool visible = true) 
        : base(entityId, name, texture2DAsset, sourcePosition, sourceDimensions, color, positionOffset, dimensions, enabled, visible)
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

    public void ChangeFrame()
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

    public override IGraphic2D Copy()
    {
        return new Sprite(_entityId, _name, _texture2DAsset, _sourceRectangle.GetPosition(), _sourceRectangle.GetDimensions(), _color, _positionOffset, _dimensions, _rows, _columns, _looping, _enabled, _visible);
    }
}