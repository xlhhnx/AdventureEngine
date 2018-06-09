using Microsoft.Xna.Framework;

public class Collision2D
{
    /// <summary>
    /// Gets and Sets the first entity involved in the collision.
    /// </summary>
    public string Entity1
    {
        get { return _entity1; }
        set { _entity1 = value; }
    }

    /// <summary>
    /// Gets and Sets the second entity involved in the collision.
    /// </summary>
    public string Entity2
    {
        get { return _entity2; }
        set { _entity2 = value; }
    }

    /// <summary>
    /// Gets and Sets the collision bounds of the first entity.
    /// </summary>
    public Shape Entity1Bounds
    {
        get { return _entity1Bounds; }
        set { _entity1Bounds = value; }
    }

    /// <summary>
    /// Gets and Sets the collision bounds of the second entity.
    /// </summary>
    public Shape Entity2Bounds
    {
        get { return _entity2Bounds; }
        set { _entity2Bounds = value; }
    }

    /// <summary>
    /// Gets and Sets the depth of penetration.
    /// </summary>
    public float Penetration { get { return _penetration; } }

    /// <summary>
    /// Gets and Sets the collision normal vector.
    /// </summary>
    public Vector2 Normal { get { return _normal; } }

    protected string _entity1;
    protected string _entity2;
    protected float _penetration;
    protected Shape _entity1Bounds;
    protected Shape _entity2Bounds;
    protected Vector2 _normal;
    
    public Collision2D(string entity1, string entity2, float penetration, Shape entity1Bounds, Shape entity2Bounds, Vector2 normal)
    {
        _entity1 = entity1;
        _entity2 = entity2;
        _penetration = penetration;
        _entity1Bounds = entity1Bounds;
        _entity2Bounds = entity2Bounds;
        _normal = normal;
    }
}