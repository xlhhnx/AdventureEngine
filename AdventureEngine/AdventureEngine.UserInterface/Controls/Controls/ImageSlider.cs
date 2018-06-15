using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using AdventureEngine.UserInterface.Screens;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Extensions;

namespace AdventureEngine.UserInterface.Controls
{
    public class ImageSlider : BaseSlider
    {
        protected Image _silderBackground;
        protected Image _focusedIndicator;
        protected Image _unfocusedIndicator;
        protected Image _clickedIndicator;


        public ImageSlider(Image sliderBackground, Image focusedIndicator, Image unfocusedIndicator, Image clickedIndicator, IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, float min, float max, float step, float value, bool visible = true, bool enabled = true)
            : base(bounds, screen, position, dimensions, tabIndex, min, max, step, value, visible, enabled)
        {
            _silderBackground = sliderBackground;
            _focusedIndicator = focusedIndicator;
            _unfocusedIndicator = unfocusedIndicator;
            _clickedIndicator = clickedIndicator;
        }

        public override void Update(GameTime gameTime)
        {
            List<Sprite> sprites = new List<Sprite>();
            if (_silderBackground is Sprite) sprites.Add(_silderBackground as Sprite);
            if (_focusedIndicator is Sprite) sprites.Add(_focusedIndicator as Sprite);
            if (_unfocusedIndicator is Sprite) sprites.Add(_unfocusedIndicator as Sprite);
            if (_clickedIndicator is Sprite) sprites.Add(_clickedIndicator as Sprite);

            foreach (var s in sprites)
            {
                if (s.ElapsedTime.TotalMilliseconds > s.FrameTime) s.ChangeFrame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_silderBackground, _position);

            if (_clicked) spriteBatch.Draw(_clickedIndicator, _position);
            else if (_focused) spriteBatch.Draw(_focusedIndicator, _position);
            else spriteBatch.Draw(_focusedIndicator, _position);
        }
    }
}