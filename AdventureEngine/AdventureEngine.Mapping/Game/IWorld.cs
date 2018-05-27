using Microsoft.Xna.Framework;
using System.Collections.Generic;

public interface IWorld
{
    Dictionary<string,List<IComponent>> Entities { get; set; }
    List<ISystem> Systems { get; set; }

    void Update(GameTime gameTime);
    void Draw();
}