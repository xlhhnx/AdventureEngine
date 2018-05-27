using Microsoft.Xna.Framework;

public interface ISystem
{
    /// <summary>
    /// Updates the entity provided.
    /// </summary>
    /// <param name="entityId">The entity to update.</param>
    /// <param name="gameTime">The current gameTime.</param>
    void Update(string entityId, GameTime gameTime);

    /// <summary>
    /// Draws the entity provided.
    /// </summary>
    /// <param name="entityId">The id of then entity to draw.</param>
    void Draw(string entityId);
}