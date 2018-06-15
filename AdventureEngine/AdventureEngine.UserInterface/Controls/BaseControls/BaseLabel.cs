using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AdventureEngine.UserInterface.Screens;
using AdventureEngine.Graphics2D.Assets;

namespace AdventureEngine.UserInterface.Controls
{
    public abstract class BaseLabel : ILabel
    {
        public IBounds Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public Vector2 Dimensions
        {
            get { return _text.Dimensions; }
            set { _text.Dimensions = value; }
        }

        public Color DisbaledColor
        {
            get { return _text.DisabledColor; }
            set { _text.DisabledColor = value; }
        }

        public string DisplayText { get { return _text.DrawText; } }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public bool Focused { get { return _focused; } }

        public string FullText
        {
            get { return _text.FullText; }
            set { _text.FullText = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public IScreen Screen
        {
            get { return _screen; }
            set { _screen = value; }
        }

        public int TabIndex
        {
            get { return _tabIndex; }
            set { _tabIndex = value; }
        }

        public Color TextColor
        {
            get { return _text.Color; }
            set { _text.Color = value; }
        }

        public bool Visible
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }


        protected int _tabIndex;
        protected bool _visible;
        protected bool _enabled;
        protected bool _focused;
        protected IBounds _bounds;
        protected IScreen _screen;
        protected Text _text;
        protected Vector2 _position;


        public BaseLabel(IBounds bounds, IScreen screen, Text text, Vector2 position, int tabIndex, bool visible = true, bool enabled = true)
        {
            _bounds = bounds;
            _screen = screen;
            _text = text;
            _position = position;
            _tabIndex = tabIndex;
            _visible = visible;
            _enabled = enabled;
        }

        public void Focus()
        {
            _focused = true;
        }

        public void Unfocus()
        {
            _focused = false;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void ReceiveMessage(Message message);
    }
}