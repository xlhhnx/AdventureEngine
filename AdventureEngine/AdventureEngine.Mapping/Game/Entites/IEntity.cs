using Microsoft.Xna.Framework;

public interface IEntity
{
    string Id { get; }
    IWorld World { get; }

    void Update(GameTime gameTime);
    void Draw();
}