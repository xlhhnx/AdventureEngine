using Microsoft.Xna.Framework;

namespace AdventureEngine.Game.Systems
{
    public interface ISystem
    {
        /// <summary>
        /// Updates the entity provided.
        /// </summary>
        /// <param name="entityId">The entity to update.</param>
        /// <param name="gameTime">The current gameTime.</param>
        void Update(string entityId, GameTime gameTime);
    }
}