using Microsoft.Xna.Framework;
using System.Collections.Generic;

public interface World
{
    bool Visible { get; set; }
    List<Entity> Entities { get; }

    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
}