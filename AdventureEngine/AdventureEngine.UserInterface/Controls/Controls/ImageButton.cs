using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using AdventureEngine.UserInterface.Screens;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Extensions;

namespace AdventureEngine.UserInterface.Controls
{
    public class ImageButton : BaseButton
    {
        protected ICommand _command;
        protected CommandManager _commandManager;
        protected Image _focusedImage;
        protected Image _unfocusedImage;
        protected Image _clickedImage;
        protected Text _focusedText;
        protected Text _unfocusedText;
        protected Text _clickedText;

        public ImageButton(Image focusedImage, Image unfocusedImage, Image clickedImage, Text focusedText, Text unfocusedText, Text clickedText, CommandManager commandManager, ICommand command, IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, bool visible = true, bool enabled = true)
            : base(bounds, screen, position, tabIndex, visible, enabled)
        {
            _focusedImage = focusedImage;
            _unfocusedImage = unfocusedImage;
            _clickedImage = clickedImage;
            _focusedText = focusedText;
            _unfocusedText = unfocusedText;
            _clickedText = clickedText;
            _commandManager = commandManager;
            _command = command;
        }

        public override void Select()
        {
            _commandManager.Enqueue(_command);
        }

        public override void Update(GameTime gameTime)
        {
            var sprites = new List<Sprite>();
            if (_focusedImage is Sprite) sprites.Add(_focusedImage as Sprite);
            if (_unfocusedImage is Sprite) sprites.Add(_unfocusedImage as Sprite);
            if (_clickedImage is Sprite) sprites.Add(_clickedImage as Sprite);

            foreach (var s in sprites)
            {
                if (s.ElapsedTime.TotalMilliseconds > s.FrameTime) s.ChangeFrame();
            }

            _focusedText.Enabled = Enabled;
            _unfocusedText.Enabled = Enabled;
            _clickedText.Enabled = Enabled;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_focused && _clicked)
            {
                spriteBatch.Draw(_clickedImage, _position);
                spriteBatch.DrawString(_clickedText, _position);
            }
            else if (_focused)
            {
                spriteBatch.Draw(_clickedImage, _position);
                spriteBatch.DrawString(_clickedText, _position);
            }
            else
            {
                spriteBatch.Draw(_clickedImage, _position);
                spriteBatch.DrawString(_clickedText, _position);
            }
        }
    }
}