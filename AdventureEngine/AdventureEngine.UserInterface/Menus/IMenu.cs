using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AdventureEngine.UserInterface.Menus
{
    public interface IMenu : ISubscriber
    {
        int SelectedIndex { get; set; }
        IMenuOption Selected { get; set; }
        Vector2 PositionOffset { get; set; }
        Vector2 Dimensions { get; set; }
        List<IMenuOption> Options { get; set; }

        IMenuOption Select();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}