using AdventureEngine.Game.Components;
using AdventureEngine.Game.Systems;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace AdventureEngine.Game
{
    public interface IWorld
    {
        Dictionary<string, List<IComponent>> Entities { get; set; }
        List<ISystem> Systems { get; set; }

        void Update(GameTime gameTime);
        void Draw();
        string Serialize();
    }
}