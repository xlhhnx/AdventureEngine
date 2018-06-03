using Microsoft.Xna.Framework;
using System;

public class Acceleration : IComponent
{
    public string EntityId { get { return _entityId; } }
    public string Name { get { return _name; } }

    /// <summary>
    /// Gets and Sets the acceleration of the entity.
    /// </summary>
    public Vector2 _Acceleration
    {
        get { return _acceleration; }
        set { _acceleration = value; }
    }

    protected string _entityId;
    protected string _name;
    protected Vector2 _acceleration;

    /// <summary>
    /// Creates a acceleration component.
    /// </summary>
    /// <param name="entityId">The id of the entity this component is a part of you.</param>
    /// <param name="name">The name of this component.</param>
    /// <param name="acceleration">The starting acceleration of the entity.</param>
    public Acceleration(string entityId, string name, Vector2 acceleration)
    {
        _entityId = entityId;
        _name = name;
        _acceleration = acceleration;
    }
}