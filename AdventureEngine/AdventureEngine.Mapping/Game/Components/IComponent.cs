using Microsoft.Xna.Framework;

public interface IComponent
{
    /// <summary>
    /// Gets the Id of the entity this component belongs to.
    /// </summary>
    string EntityId { get; }

    /// <summary>
    /// Gets the name of the component.
    /// </summary>
    string Name { get; }
}