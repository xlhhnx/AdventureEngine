using System;

public class Friction : IComponent
{
    public string EntityId { get { return _entityId; } }
    public string Name { get { return _name; } }

    /// <summary>
    /// Gets and Sets the coefficient of static friction of the entity.
    /// </summary>
    public float StaticFriction
    {
        get { return _staticFriction; }
        set { _staticFriction = value; }
    }

    /// <summary>
    /// Gets and Sets the coefficient of dynamic friction of the entity.
    /// </summary>
    public float DynamicFriction
    {
        get { return _dynamicFriction; }
        set { _dynamicFriction = value; }
    }

    protected string _entityId;
    protected string _name;
    protected float _staticFriction;
    protected float _dynamicFriction;

    /// <summary>
    /// Creates a restitution component.
    /// </summary>
    /// <param name="entityId">The id of the entity this component is a part of you.</param>
    /// <param name="name">The name of this component.</param>
    /// <param name="staticFriction">The starting coefficient of static friction of the entity.</param>
    /// <param name="dynamicFriction">The starting coefficient of dynamic friction of the entity.</param>
    public Friction(string entityId, string name, float staticFriction, float dynamicFriction)
    {
        _entityId = entityId;
        _name = name;
        _staticFriction = staticFriction;
        _dynamicFriction = dynamicFriction;
    }

    public string Serilize()
    {
        throw new NotImplementedException();
    }
}