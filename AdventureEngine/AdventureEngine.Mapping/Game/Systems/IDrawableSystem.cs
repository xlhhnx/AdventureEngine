namespace AdventureEngine.Game.Systems
{
    public interface IDrawableSystem : ISystem
    {
        /// <summary>
        /// Draws the entity provided.
        /// </summary>
        /// <param name="entityId">The id of then entity to draw.</param>
        void Draw(string entityId);
    }
}