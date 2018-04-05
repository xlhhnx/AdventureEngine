using Microsoft.Xna.Framework;

public interface Component
{
    Entity ParentEntity { get; }

    void Update(GameTime gameTime);
}