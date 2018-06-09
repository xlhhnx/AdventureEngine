using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public interface IUserInterfaceObject
{
    bool Visible { get; set; }
    bool Enabled { get; set; }
    Vector2 Position { get; set; }
    Vector2 Dimensions { get; set; }

    void Focus();
    void Unfocus();
    void Update(GameTime gameTime);
    void Draw(SpriteBatch spriteBatch);
}