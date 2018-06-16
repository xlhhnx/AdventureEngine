using Microsoft.Xna.Framework;

namespace AdventureEngine.Game.Components
{
    public interface IComponent
    {
        string EntityId { get; }
        string Name { get; }

        string Serilize();
    }
}