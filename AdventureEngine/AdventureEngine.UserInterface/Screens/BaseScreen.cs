using AdventureEngine.Messaging;
using AdventureEngine.UserInterface.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace AdventureEngine.UserInterface.Screens
{
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

        public virtual List<IControl> Controls { get { return _controls; } }
        public bool Focused { get { return _focused; } }


        protected bool _focused;
        protected bool _visible;
        protected bool _enabled;
        protected Vector2 _drawPosition;
        protected Vector2 _drawDimensions;
        protected List<IControl> _controls;


        public BaseScreen(Vector2 drawPosition, Vector2 drawDimensions, bool focused = false, bool visible = true, bool enabled = true)
        {
            _drawPosition = drawPosition;
            _drawDimensions = drawDimensions;
            _focused = focused;
            _enabled = enabled;
            _visible = visible;
            
            _controls = new List<IControl>();
        }

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
}