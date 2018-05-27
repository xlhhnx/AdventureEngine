using Microsoft.Xna.Framework;

public class PhysicsComponent : IComponent
{
    public string EntityId    {        get        { return _entityId;        }    }
    public string Name    {        get        {            return _name;        }    }

    /// <summary>
    /// Gets and Sets the velocity of the entity.
    /// </summary>
    public Vector2 Velocity
    {
        get { return _velocity; }
        set { _velocity = value; }
    }

    protected string _entityId;
    protected string _name;
    protected Vector2 _velocity;

    /// <summary>
    /// Creates a physics component.
    /// </summary>
    /// <param name="entityId">The id of the entity this component is a part of you.</param>
    /// <param name="name">The name of thi component.</param>
    /// <param name="velocity">The starting velocity of the entity.</param>
    public PhysicsComponent(string entityId, string name, Vector2 velocity)
    {
        _entityId = entityId;
        _name = name;
        _velocity = velocity;
    }
}