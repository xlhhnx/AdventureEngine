using System.Collections.Generic;
using AdventureEngine.Common.Bounding;
using AdventureEngine.UserInterface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureEngine.UserInterface.Controls
{
    public class RadioButtonCollection : BaseRadioButtonCollection
    {
        public RadioButtonCollection(int tabIndex, IBounds bounds, IScreen screen, Vector2 position, IRadioButton selected = null, List<IRadioButton> radioButtons = null, bool visible = true, bool enabled = true, bool focused = false) : base(tabIndex, bounds, screen, position, selected, radioButtons, visible, enabled, focused)
        { /* No op */ }

        public override void Update(GameTime gameTime)
        {
            foreach (var rb in _radioButtons) rb.Enabled = Enabled;
        }

        public override void Draw(SpriteBatch spriteBatch)
        { /* No op */ }
    }
}