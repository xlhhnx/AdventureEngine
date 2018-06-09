using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public abstract class BaseScreen : IScreen
{
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

    public virtual Vector2 Position
    {
        get { return _drawPosition; }
        set { _drawPosition = value; }
    }

    public virtual Vector2 Dimensions
    {
        get { return _drawDimensions; }
        set { _drawDimensions = value; }
    }

    public virtual List<IControl> Controls
    {
        get { return _controls; }
        set { _controls = value; }
    }


    protected bool _focused;
    protected bool _visible;
    protected bool _enabled;
    protected Vector2 _drawPosition;
    protected Vector2 _drawDimensions;
    protected List<IControl> _controls;

    public virtual void Focus()
    {
        _focused = true;
    }

    public virtual void Unfocus()
    {
        _focused = false;
    }

    public virtual void Update(GameTime gameTime)
    {
        foreach (var ctrl in _controls) ctrl.Update(gameTime);
    }

    public abstract void Draw(SpriteBatch spriteBatch);
    public abstract void ReceiveMessage(Message message);
}