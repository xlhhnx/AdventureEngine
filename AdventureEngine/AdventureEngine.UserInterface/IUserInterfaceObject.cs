using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureEngine.UserInterface
{
    public interface IUserInterfaceObject
    {
        bool Visible { get; set; }
        bool Enabled { get; set; }
        Vector2 Position { get; set; }

        void Focus();
        void Unfocus();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}