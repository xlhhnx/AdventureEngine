using Microsoft.Xna.Framework;

public abstract class DrawableComponent : Component
{
    /* Properties */
    public bool Visible { get; set; }

    /* Variables */
    protected bool _visible;

    /* Methods */
    public DrawableComponent(Entity parentEntity, bool visible = false) : base(parentEntity)
    {
        _visible = visible;
    }

    public abstract void Draw(GameTime gameTime);
}