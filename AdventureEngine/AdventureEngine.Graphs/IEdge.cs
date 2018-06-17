namespace AdventureEngine.Graphing
{
    public interface IEdge
    {
        /// <summary>
        /// Gets the graph the edge belongs to.
        /// </summary>
        Graph Graph { get; }

        /// <summary>
        /// The first node the edge connects to.
        /// </summary>
        INode Node1 { get; set; }

        /// <summary>
        /// The second node the edge connets to.
        /// </summary>
        INode Node2 { get; set; }

        /// <summary>
        /// Traverses the edge.
        /// </summary>
        /// <param name="startingNode">The starting node.</param>
        /// <returns>The node reached from traversing the edge or null.</returns>
        INode Traverse(INode startingNode);
    }
}