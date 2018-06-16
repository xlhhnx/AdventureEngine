using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Extensions;
using AdventureEngine.Input;
using AdventureEngine.Input.Messages;
using AdventureEngine.Messaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureEngine.UserInterface.Screens
{
    public class BackgroundScreen : BaseScreen
    {
        protected bool _mouseInBounds = false;
        protected Vector2 _focusedSourcePosition;
        protected Vector2 _focusedSourceDimensions;
        protected Vector2 _unfocusedSourcePosition;
        protected Vector2 _unfocusedSourceDimensions;
        protected Image _focusedImage;
        protected Image _unfocusedImage;
        protected Rectangle _destionationRectangle;
        protected Rectangle _sourceRectangle;


        public BackgroundScreen(Viewport viewport, Vector2 focusedSourcePosition, Vector2 focusedSourceDimensions, Vector2 unfocusedSourcePosition, Vector2 unfocusedSourceDimensions, Image focusedImage, Image unfocusedImage, bool focused = false, bool visible = true, bool enabled = true)
            : base (new Vector2(viewport.X, viewport.Y), new Vector2(viewport.Width, viewport.Height), focused, visible, enabled)
        {
            _focusedSourcePosition = focusedSourcePosition;
            _focusedSourceDimensions = focusedSourceDimensions;
            _unfocusedSourcePosition = unfocusedSourcePosition;
            _unfocusedSourceDimensions = unfocusedSourceDimensions;
            _focusedImage = focusedImage;
            _unfocusedImage = unfocusedImage;
        }

        public BackgroundScreen(Vector2 drawPosition, Vector2 drawDimensions, Vector2 focusedSourcePosition, Vector2 focusedSourceDimensions, Vector2 unfocusedSourcePosition, Vector2 unfocusedSourceDimensions, Image focusedImage, Image unfocusedImage, bool focused = false, bool visible = true, bool enabled = true)
            : base(drawPosition, drawDimensions, focused, visible, enabled)
        {
            _focusedSourcePosition = focusedSourcePosition;
            _focusedSourceDimensions = focusedSourceDimensions;
            _unfocusedSourcePosition = unfocusedSourcePosition;
            _unfocusedSourceDimensions = unfocusedSourceDimensions;
            _focusedImage = focusedImage;
            _unfocusedImage = unfocusedImage;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                if(Focused) spriteBatch.Draw(_focusedImage, Position);
                else spriteBatch.Draw(_unfocusedImage, Position);

                foreach (var ctrl in _controls) ctrl.Draw(spriteBatch);
            }
        }

        public override void ReceiveMessage(Message message)
        {
            if (_mouseInBounds && message is MouseButtonStatesMessage)
            {
                var msg = message as MouseButtonStatesMessage;

                if (_mouseInBounds && (msg.ButtonState["LeftButton"] == ButtonState.Pressed || msg.ButtonState["LeftButton"] == ButtonState.Pressed)) Focus();
                else if (!_mouseInBounds && (msg.ButtonState["LeftButton"] == ButtonState.Pressed || msg.ButtonState["LeftButton"] == ButtonState.Pressed)) Unfocus();
            }
            else if (message is MouseMoveMessage)
            {
                var msg = message as MouseMoveMessage;
                _mouseInBounds = _destionationRectangle.Contains(msg.Position);
            }
        }
    }
}