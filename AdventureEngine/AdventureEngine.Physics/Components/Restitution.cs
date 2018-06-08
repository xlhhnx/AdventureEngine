using System;

public class Restitution : IComponent
{
    public string EntityId { get { return _entityId; } }
    public string Name { get { return _name; } }

    /// <summary>
    /// Gets and Sets the velocity of the entity.
    /// </summary>
    public float _Restitution
    {
        get { return _restitution; }
        set { _restitution = value; }
    }

    protected string _entityId;
    protected string _name;
    protected float _restitution;

    /// <summary>
    /// Creates a restitution component.
    /// </summary>
    /// <param name="entityId">The id of the entity this component is a part of you.</param>
    /// <param name="name">The name of this component.</param>
    /// <param name="restitution">The starting restitution of the entity.</param>
    public Restitution(string entityId, string name, float restitution)
    {
        _entityId = entityId;
        _name = name;
        _restitution = restitution;
    }

    public string Serilize()
    {
        throw new NotImplementedException();
    }
}