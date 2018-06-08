using System;

public class Health : IComponent
{
    public string EntityId { get { return _entityId; } }
    public string Name { get { return _name; } }

    /// <summary>
    /// Gets and Sets the health of the entity.
    /// </summary>
    public int _Health
    {
        get { return _health; }
        set { _health = value; }
    }

    protected string _entityId;
    protected string _name;
    protected int _health;

    /// <summary>
    /// Creates a health component.
    /// </summary>
    /// <param name="entityId">The id of the entity this component is a part of you.</param>
    /// <param name="name">The name of thi component.</param>
    /// <param name="health">The starting health of the entity.</param>
    public Health(string entityId, string name, int health)
    {
        _entityId = entityId;
        _name = name;
        _health = health;
    }

    public string Serilize()
    {
        throw new NotImplementedException();
    }
}