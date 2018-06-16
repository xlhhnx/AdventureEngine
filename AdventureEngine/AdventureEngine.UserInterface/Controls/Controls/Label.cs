using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AdventureEngine.UserInterface.Screens;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Extensions;
using AdventureEngine.Messaging;
using AdventureEngine.Common.Bounding;

namespace AdventureEngine.UserInterface.Controls
{
    public class Label : BaseLabel
    {
        public Label(IBounds bounds, IScreen screen, Text text, Vector2 position, int tabIndex, bool visible = true, bool enabled = true) : base(bounds, screen, text, position, tabIndex, visible, enabled)
        { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_text, _position);
        }

        public override void Update(GameTime gameTime)
        {
            _text.Enabled = Enabled;
        }

        public override void ReceiveMessage(Message message)
        { /* No op */ }
    }
}