using Microsoft.Xna.Framework;
using System.Collections.Generic;

public interface IWorld
{
    List<IEntity> Entities { get; }

    void Update(GameTime gameTime);
    void Draw();
}