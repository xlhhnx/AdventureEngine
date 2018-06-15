using System;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.UserInterface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AdventureEngine.Graphics2D.Extensions;

namespace AdventureEngine.UserInterface.Controls
{
    public class ImageTextBox : BaseTextBox
    {
        public virtual bool CursorFlash
        {
            get { return _cursorFlash; }
            set { _cursorFlash = value; }
        }

        public virtual int CursorFlashTime
        {
            get { return _cursorFlashTime; }
            set { _cursorFlashTime = value; }
        }

        public override string FullText
        {
            get { return _text.FullText; }
            set { _text.FullText = value; }
        }

        public override string DisplayText { get { return _text.DrawText; } }
        public override Vector2 TextDimensions { get { return (Vector2)_text.TextDimensions; } }
        public override Vector2 DisplayDimensions { get { return _text.Dimensions; } }


        protected bool _cursorFlash;
        protected bool _drawCursor;
        protected int _cursorFlashTime;
        protected TimeSpan _elapsedTime;
        protected Image _background;
        protected Text _text;
        protected Text _cursorText;


        public ImageTextBox(Image background, Text text, Text cursorText, int tabIndex, int keyDownPauseTime, IBounds bounds, IScreen screen, Vector2 position, string fullText = "", bool visible = true, bool enabled = true, bool focused = false)
            : base(tabIndex, keyDownPauseTime, bounds, screen, position, fullText, visible, enabled, focused)
        {
            FullText = fullText;
            _background = background;
            _text = text;
            _cursorText = cursorText;

            _elapsedTime = new TimeSpan();
        }

        public override void Update(GameTime gameTime)
        {
            if (_selected)
            {
                _elapsedTime += gameTime.ElapsedGameTime;
                _drawCursor = !_cursorFlash || (_elapsedTime.TotalMilliseconds < _cursorFlashTime);
                if (_elapsedTime.TotalMilliseconds > _cursorFlashTime * 2) _elapsedTime = new TimeSpan();
            }
            else _drawCursor = false;

            if (_background is Sprite)
            {
                var sprite = _background as Sprite;
                sprite.ElapsedTime += gameTime.ElapsedGameTime;
                if (sprite.ElapsedTime.TotalMilliseconds > sprite.FrameTime) sprite.ChangeFrame();
            }

            if (_text.Loaded) _cursorText.PositionOffset = new Vector2(_text.SpriteFontAsset.SpriteFont.MeasureString(FullText.Substring(0, Cursor)).X, _cursorText.PositionOffset.Y);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background, _position);
            spriteBatch.DrawString(_text, _position);
            if (_drawCursor) spriteBatch.DrawString(_cursorText, _position);
        }
    }
}