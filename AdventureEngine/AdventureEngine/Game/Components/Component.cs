using Microsoft.Xna.Framework;

public interface Component
{
    Entity ParentEntity { get; set; }

    void Update(GameTime gameTime);
}