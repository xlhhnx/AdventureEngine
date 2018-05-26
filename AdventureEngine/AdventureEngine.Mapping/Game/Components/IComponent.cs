using Microsoft.Xna.Framework;

public interface IComponent
{
    string Id { get; }
    string Name { get; }
    IEntity Entity { get; }

    void Update(GameTime gameTime);
}