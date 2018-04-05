using Microsoft.Xna.Framework;
using System.Collections.Generic;

public interface Entity
{
    bool Visible { get; set; }
    World ParentWorld { get; }
    List<Component> Components { get; }
    List<DrawableComponent> DrawableComponents { get; }

    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
}