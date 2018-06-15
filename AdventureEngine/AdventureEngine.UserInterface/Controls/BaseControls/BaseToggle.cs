using System;
using AdventureEngine.UserInterface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureEngine.UserInterface.Controls
{
    public abstract class BaseToggle : IToggle
    {
        public virtual IBounds Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public virtual bool Checked { get { return _checked; } }

        public virtual bool Clicked { get { return _clicked; } }

        public virtual bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public virtual bool Focused { get { return _focused; } }

        public virtual Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public virtual IScreen Screen
        {
            get { return _screen; }
            set { _screen = value; }
        }

        public virtual int TabIndex
        {
            get { return _tabIndex; }
            set { _tabIndex = value; }
        }

        public virtual bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }


        protected bool _visible;
        protected bool _enabled;
        protected bool _focused;
        protected bool _clicked;
        protected bool _checked;
        protected bool _mouseInBounds;
        protected int _tabIndex;
        protected IBounds _bounds;
        protected IScreen _screen;
        protected Vector2 _position;


        public BaseToggle(int tabIndex, IBounds bounds, IScreen screen, Vector2 position, bool visible = true, bool enabled = true, bool focused = false, bool clicked = false, bool _checked = false)
        {
            _visible = visible;
            _enabled = enabled;
            _focused = focused;
            _clicked = clicked;
            this._checked = _checked;
            _tabIndex = tabIndex;
            _bounds = bounds;
            _screen = screen;
            _position = position;
        }
        
        public virtual void Focus()
        {
            _focused = true;
        }

        public virtual void Toggle()
        {
            _checked = !_checked;
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

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        protected virtual void HandleMouseButtonStateMessage(MouseButtonStatesMessage message)
        {
            if (!_clicked && _mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Pressed) _clicked = true;
            else if (_clicked && _mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Released)
            {
                _clicked = false;
                Toggle();
            }
        }

        protected virtual void HandleMouseMoveState(MouseMoveMessage message)
        {
            if (_bounds.Contains(message.Position))
            {
                _focused = true;
                _mouseInBounds = true;
            }
            else
            {
                _focused = false;
                _mouseInBounds = false;
            }
        }
    }
}