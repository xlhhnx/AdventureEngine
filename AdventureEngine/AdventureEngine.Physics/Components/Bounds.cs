using System;
using Microsoft.Xna.Framework;

public abstract class Bounds : IComponent
{
    public string EntityId { get { return _entityId; } }
    public string Name { get { return _name; } }

    /// <summary>
    /// Gets the area of the shape.
    /// </summary>
    public abstract float Area { get; }

    /// <summary>
    /// Get and Sets the position offset of the shape.
    /// </summary>
    public Vector2 PositionOffset
    {
        get { return _positionOffset; }
        set { _positionOffset = value; }
    }

    protected string _entityId;
    protected string _name;
    protected Vector2 _positionOffset;

    public Bounds(string entityId, string name, Vector2 positionOffset)
    {
        _entityId = entityId;
        _name = name;
        _positionOffset = positionOffset;
    }

    public string Serilize()
    {
        throw new NotImplementedException();
    }
}