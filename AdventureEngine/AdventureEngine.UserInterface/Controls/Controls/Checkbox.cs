using AdventureEngine.Common.Bounding;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Extensions;
using AdventureEngine.UserInterface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureEngine.UserInterface.Controls
{
    public class Checkbox : Toggle
    {
        protected Text _text;


        public Checkbox(int tabIndex, IBounds bounds, IScreen screen, Vector2 position, Image onImage, Image offImage, Image focusedImage, Text text, bool visible = true, bool enabled = true, bool focused = false, bool clicked = false, bool _checked = false) 
            : base(tabIndex, bounds, screen, position, onImage, offImage, focusedImage, visible, enabled, focused, clicked, _checked)
        {
            _text = text;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            _text.Enabled = Enabled;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.DrawString(_text, _position);
        }
    }
}