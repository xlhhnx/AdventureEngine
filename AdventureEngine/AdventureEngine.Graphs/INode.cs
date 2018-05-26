using System.Collections.Generic;

public interface INode
{
    /// <summary>
    /// Gets the graph the node belongs to.
    /// </summary>
    Graph Graph { get; }

    /// <summary>
    /// The list of all edges starting from the node.
    /// </summary>
    List<IEdge> Edges { get; set; }

    /// <summary>
    /// Traverses the edge provided if it is in the list of edges.
    /// </summary>
    /// <param name="edge">The edge to be trraversed.</param>
    /// <returns>The node reached from traversing the edge or null.</returns>
    INode TraverseEdge(IEdge edge);

    /// <summary>
    /// Traveses the edge corresponding to the index provided.
    /// </summary>
    /// <param name="edgeIndex">The index used to look up the edge to traverse.</param>
    /// <returns>The node reached from traversing the edge or null.</returns>
    INode TraverseEdge(int edgeIndex);
}