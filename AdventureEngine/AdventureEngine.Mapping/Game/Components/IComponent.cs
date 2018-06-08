using Microsoft.Xna.Framework;

public interface IComponent
{
    string EntityId { get; }
    string Name { get; }

    string Serilize();
}