using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class StaticBackgroundScreen : BaseScreen
{
    protected bool _mouseInBounds = false;
    protected Color _tint;
    protected Vector2 _focusedSourcePosition;
    protected Vector2 _focusedSourceDimensions;
    protected Vector2 _unfocusedSourcePosition;
    protected Vector2 _unfocusedSourceDimensions;
    protected Texture2DAsset _focusedTexture;
    protected Texture2DAsset _unfocusedTexture;
    protected Rectangle _destionationRectangle;
    protected Rectangle _sourceRectangle;


    public StaticBackgroundScreen(Viewport viewport, Vector2 focusedSourcePosition, Vector2 focusedSourceDimensions, Vector2 unfocusedSourcePosition, Vector2 unfocusedSourceDimensions, Color tint
        , bool focused = false, bool visible = true, bool enabled = true)
    {
        _drawPosition = new Vector2(viewport.X, viewport.Y);
        _drawDimensions = new Vector2(viewport.Width, viewport.Height);
        _focusedSourcePosition = focusedSourcePosition;
        _focusedSourceDimensions = focusedSourceDimensions;
        _unfocusedSourcePosition = unfocusedSourcePosition;
        _unfocusedSourceDimensions = unfocusedSourceDimensions;
        _tint = tint;
        _focused = focused;
        _enabled = enabled;
        _visible = visible;
    }

    public StaticBackgroundScreen(Vector2 drawPosition, Vector2 drawDimensions, Vector2 focusedSourcePosition, Vector2 focusedSourceDimensions, Vector2 unfocusedSourcePosition, Vector2 unfocusedSourceDimensions
        , Color tint, bool focused = false, bool visible = true, bool enabled = true)
    {
        _drawPosition = drawPosition;
        _drawDimensions = drawDimensions;
        _focusedSourcePosition = focusedSourcePosition;
        _focusedSourceDimensions = focusedSourceDimensions;
        _unfocusedSourcePosition = unfocusedSourcePosition;
        _unfocusedSourceDimensions = unfocusedSourceDimensions;
        _tint = tint;
        _focused = focused;
        _enabled = enabled;
        _visible = visible;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        if (Visible)
        {
            Texture2DAsset texture;
            Color tint;

            if (Enabled) tint = _tint;
            else tint = Color.Gray;

            if (_focused)
            {
                _sourceRectangle = new Rectangle(_focusedSourcePosition.ToPoint(), _focusedSourceDimensions.ToPoint());
                texture = _focusedTexture;
            }
            else
            {
                _sourceRectangle = new Rectangle(_unfocusedSourcePosition.ToPoint(), _unfocusedSourceDimensions.ToPoint());
                texture = _unfocusedTexture;
            }

            if (texture.Loaded) spriteBatch.Draw(texture.Texture, _destionationRectangle, _sourceRectangle, tint);

            foreach (var ctrl in _controls) ctrl.Draw(spriteBatch);
        }
    }

    public override void ReceiveMessage(Message message)
    {
        if (_mouseInBounds && message is MouseButtonStatesMessage)
        {
            var msg = message as MouseButtonStatesMessage;

            if (_mouseInBounds && (msg.ButtonState["LeftButton"] == ButtonState.Pressed || msg.ButtonState["LeftButton"] == ButtonState.Pressed))
            {
                Focus();
            }
            else if (!_mouseInBounds && (msg.ButtonState["LeftButton"] == ButtonState.Pressed || msg.ButtonState["LeftButton"] == ButtonState.Pressed))
            {
                Unfocus();
            }
        }
        else if (message is MouseMoveMessage)
        {
            var msg = message as MouseMoveMessage;
            _mouseInBounds = _destionationRectangle.Contains(msg.Position);
        }
    }
}