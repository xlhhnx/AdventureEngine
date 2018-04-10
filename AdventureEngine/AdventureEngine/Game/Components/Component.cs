using Microsoft.Xna.Framework;

public abstract class Component
{
    /* Properties */
    public Entity ParentEntity
    {
        get { return _parentEntity; }
        set { _parentEntity = value; }
    }

    /* Vaiables */
    protected Entity _parentEntity;

    /* Methods */
    public Component(Entity parentEntity)
    {
        _parentEntity = parentEntity;
    }

    public abstract void Update(GameTime gameTime);
}