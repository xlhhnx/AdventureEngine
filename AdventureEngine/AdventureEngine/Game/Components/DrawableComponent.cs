using Microsoft.Xna.Framework;

public interface DrawableComponent : Component
{
    bool Visible { get; set; }

    void Draw(GameTime gameTime);
}