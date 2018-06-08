using Microsoft.Xna.Framework;

public abstract class BaseGraphic2D : IGraphic2D
{
    public virtual string Id { get { return _id; } }
    public abstract bool Loaded { get; }

    public virtual bool Visible
    {
        get { return _visible; }
        set { _visible = value; }
    }

    public virtual bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; }
    }

    public abstract GraphicType GraphicType { get; }

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


    protected string _id;
    protected bool _visible;
    protected bool _enabled;
    protected Vector2 _positionOffset;
    protected Vector2 _dimensions;


    public void Unload() { /* No op */ }

    public abstract IGraphic2D Copy();
}