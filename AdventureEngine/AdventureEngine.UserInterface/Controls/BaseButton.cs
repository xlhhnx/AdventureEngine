using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class BaseButton : IButton
{
    public virtual bool Clicked { get { return _clicked; } }
    public virtual bool Focused { get { return _focused; } }

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

    public virtual int TabIndex
    {
        get { return _tabIndex; }
        set { _tabIndex = value; }
    }

    public virtual IBounds Bounds
    {
        get { return _bounds; }
        set { _bounds = value; }
    }

    public virtual Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public virtual Vector2 Dimensions
    {
        get { return _dimensions; }
        set { _dimensions = value; }
    }

    public virtual IScreen Screen
    {
        get { return _screen; }
        set { _screen = value; }
    }


    protected bool _clicked = false;
    protected bool _mouseInBounds = false;
    protected bool _focused = false;
    protected bool _visible;
    protected bool _enabled;
    protected int _tabIndex;
    protected IBounds _bounds;
    protected IScreen _screen;
    protected Vector2 _position;
    protected Vector2 _dimensions;


    public BaseButton(IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, bool visible = true, bool enabled = true)
    {
        _bounds = bounds;
        _screen = screen;
        _position = position;
        _dimensions = dimensions;
        _tabIndex = tabIndex;
        _visible = visible;
        _enabled = enabled;
    }

    public virtual void Focus()
    {
        _focused = true;
    }

    public virtual void Unfocus()
    {
        _focused = false;
    }

    public virtual void ReceiveMessage(Message message)
    {
        if (message is MouseButtonStatesMessage) HandleMouseButtonStateMessage(message as MouseButtonStatesMessage);
        else if (message is MouseMoveMessage) HandleMouseMoveState(message as MouseMoveMessage);
    }

    public virtual void Update(GameTime gameTime) { /* No op */ }

    public abstract void Select();
    public abstract void Draw(SpriteBatch spriteBatch);

    protected virtual void HandleMouseButtonStateMessage(MouseButtonStatesMessage message)
    {
        if (!_clicked && _mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Pressed) _clicked = true;
        else if (_clicked && _mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Released)
        {
            _clicked = false;
            Select();
        }
    }

    protected virtual void HandleMouseMoveState(MouseMoveMessage message)
    {
        if (_bounds.Contains(message.Position)) _focused = true;
        else _focused = false;
    }
}