using System;

public class Mass : IComponent
{
    public string EntityId { get { throw new NotImplementedException(); } }
    public string Name { get { throw new NotImplementedException(); } }

    /// <summary>
    /// Gets and Sets the mass of the entity.
    /// </summary>
    public float _Mass
    {
        get { return 1 / _inverseMass; }
        set { _inverseMass = 1 / value; }
    }

    /// <summary>
    /// Gets and Sets the inverse mass of the entity
    /// </summary>
    public float InverseMass
    {
        get { return _inverseMass; }
        set { _inverseMass = value; }
    }

    protected string _entityId;
    protected string _name;
    protected float _inverseMass;

    /// <summary>
    /// Creates a mass component.
    /// </summary>
    /// <param name="entityId">The id of the entity this component is a part of you.</param>
    /// <param name="name">The name of this component.</param>
    /// <param name="mass">The starting mass of the entity.</param>
    public Mass(string entityId, string name, float mass)
    {
        _entityId = entityId;
        _name = name;
        _Mass = mass;
    }

    public string Serilize()
    {
        throw new NotImplementedException();
    }
}