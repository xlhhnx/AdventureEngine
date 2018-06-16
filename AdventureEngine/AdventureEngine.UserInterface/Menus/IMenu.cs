using AdventureEngine.Messaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AdventureEngine.UserInterface.Menus
{
    public interface IMenu : ISubscriber
    {
        int CurrentOptionIndex { get; set; }
        IMenuOption CurrentOption { get; set; }
        Vector2 PositionOffset { get; set; }
        Vector2 Dimensions { get; set; }
        List<IMenuOption> Options { get; set; }

        void Select();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}