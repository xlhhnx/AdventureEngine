using System;
using System.Collections.Generic;
using AdventureEngine.UserInterface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureEngine.UserInterface.Controls
{
    public abstract class BaseRadioButtonCollection : IRadioButtonCollection
    {
        public virtual IBounds Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

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

        public virtual IRadioButton Selected
        {
            get { return _selected; }
            set
            {
                _selected.Deselect();
                _selected = value;
            }
        }

        public virtual List<IRadioButton> RadioButtons
        {
            get { return _radioButtons; }
            set
            {
                _radioButtons = value;

                if (!_radioButtons.Contains(Selected) && _radioButtons.Count > 0) _selected = _radioButtons[0];
                else if (!_radioButtons.Contains(Selected)) _selected = null;
            }
        }


        protected bool _visible;
        protected bool _enabled;
        protected bool _focused;
        protected bool _mouseInBounds;
        protected int _tabIndex;
        protected IBounds _bounds;
        protected IScreen _screen;
        protected IRadioButton _selected;
        protected List<IRadioButton> _radioButtons;
        protected Vector2 _position;


        public BaseRadioButtonCollection(int tabIndex, IBounds bounds, IScreen screen, Vector2 position, IRadioButton selected = null, List<IRadioButton> radioButtons = null, bool visible = true, bool enabled = true, bool focused = false)
        {
            _visible = visible;
            _enabled = enabled;
            _focused = focused;
            _tabIndex = tabIndex;
            _bounds = bounds;
            _screen = screen;
            _position = position;

            if (radioButtons == null) _radioButtons = new List<IRadioButton>();
            else _radioButtons = radioButtons;

            if (selected == null && _radioButtons.Count > 0) _selected = _radioButtons[0];
            else if (selected != null) _selected = selected;
        }

        public virtual void Focus() { /* No op */ }
        public virtual void Unfocus() { /* No op */}
        public virtual void ReceiveMessage(Message message) { /* No op */ }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}