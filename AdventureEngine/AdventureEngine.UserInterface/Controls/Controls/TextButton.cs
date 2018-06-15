using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AdventureEngine.UserInterface.Screens;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Extensions;

namespace AdventureEngine.UserInterface.Controls
{
    public class TextButton : BaseButton
    {
        protected ICommand _command;
        protected CommandManager _commandManager;
        protected Text _focusedText;
        protected Text _unfocusedText;
        protected Text _clickedText;

        public TextButton(Text focusedText, Text unfocusedText, Text clickedText, CommandManager commandManager, ICommand command, IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, bool visible = true, bool enabled = true)
            : base(bounds, screen, position, tabIndex, visible, enabled)
        {
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
        { /* No op */ }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_focused && _clicked) spriteBatch.DrawString(_clickedText, _position);
            else if (_focused) spriteBatch.DrawString(_focusedText, _position);
            else spriteBatch.DrawString(_unfocusedText, _position);
        }
    }
}