using AdventureEngine.Common.Bounding;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Extensions;
using AdventureEngine.UserInterface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AdventureEngine.UserInterface.Controls
{
    public class Toggle : BaseToggle
    {
        Image _onImage;
        Image _offImage;
        Image _focusedImage;

        public Toggle(int tabIndex, IBounds bounds, IScreen screen, Vector2 position, Image onImage, Image offImage, Image focusedImage, bool visible = true, bool enabled = true, bool focused = false, bool clicked = false, bool _checked = false) 
            : base(tabIndex, bounds, screen, position, visible, enabled, focused, clicked, _checked)
        {
            _onImage = onImage;
            _offImage = offImage;
            _focusedImage = focusedImage;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(Checked) spriteBatch.Draw(_onImage, Position);
            else spriteBatch.Draw(_offImage, Position);

            if(Focused) spriteBatch.Draw(_focusedImage, Position);
        }

        public override void Update(GameTime gameTime)
        {
            var sprites = new List<Sprite>();

            if(_onImage is Sprite) sprites.Add(_onImage as Sprite);
            if(_offImage is Sprite) sprites.Add(_offImage as Sprite);
            if(_focusedImage is Sprite) sprites.Add(_focusedImage as Sprite);

            foreach (var s in sprites)
            {
                s.ElapsedTime += gameTime.ElapsedGameTime;
                if(s.ElapsedTime.TotalMilliseconds > s.FrameTime) s.ChangeFrame();
            }

            _onImage.Enabled = Enabled;
            _offImage.Enabled = Enabled;
            _focusedImage.Enabled = Enabled;
        }
    }
}