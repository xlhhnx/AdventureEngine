using System;

public class Density : IComponent
{
    public string EntityId { get { return _entityId; } }
    public string Name { get { return _name; } }

    /// <summary>
    /// Gets and Sets the density of the entity.
    /// </summary>
    public float _Density
    {
        get { return _density; }
        set { _density = value; }
    }

    protected string _entityId;
    protected string _name;
    protected float _density;

    /// <summary>
    /// Creates a velocity component.
    /// </summary>
    /// <param name="entityId">The id of the entity this component is a part of you.</param>
    /// <param name="name">The name of this component.</param>
    /// <param name="density">The starting density of the entity.</param>
    public Density(string entityId, string name, float density)
    {
        _entityId = entityId;
        _name = name;
        _density = density;
    }

    public string Serilize()
    {
        throw new NotImplementedException();
    }
}