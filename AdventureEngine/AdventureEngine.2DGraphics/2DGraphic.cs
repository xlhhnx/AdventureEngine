using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class Graphic2D : IComponent
{
    public virtual string EntityId { get { return _entityId; } }
    public virtual string Name { get { return _name; } }

    /// <summary>
    /// Gets this graphic's id.
    /// </summary>
    public virtual string Id { get { return _id; } }

    /// <summary>
    /// Gets and Sets the flag that determines if the graphic is being drawn.
    /// </summary>
    public virtual bool Visible
    {
        get { return _visible; }
        set { _visible = value; }
    }

    /// <summary>
    /// Gets an Sets the flag determining if the graphic is enabled.
    /// </summary>
    public virtual bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; }
    }

    public virtual Vector2 PositionOffset
    {
        get { return _positionOffset; }
        set { _positionOffset = value; }
    }

    public virtual Vector2 Dimensions
    {
        get { return _dimensions; }
        set { _dimensions = value; }
    }

    protected string _entityId;
    protected string _name;
    protected string _id;
    protected bool _visible;
    protected bool _enabled;
    protected Vector2 _positionOffset;
    protected Vector2 _dimensions;

    /// <summary>
    /// Copies the graphic.
    /// </summary>
    /// <returns>A new graphic exactly matching this graphic.</returns>
    public abstract Graphic2D Copy();
}