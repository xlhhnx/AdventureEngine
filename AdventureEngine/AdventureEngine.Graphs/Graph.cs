using System.Collections.Generic;

namespace AdventureEngine.Graphing
{
    public abstract class Graph
    {
        protected List<INode> _nodes;
        protected List<IEdge> _edges;

        /// <summary>
        /// Creates a graph.
        /// </summary>
        public Graph()
        {
            _nodes = new List<INode>();
            _edges = new List<IEdge>();
        }

        /// <summary>
        /// Determines if the node is in the graph.
        /// </summary>
        /// <param name="node">The node to check.</param>
        /// <returns>A flag determining if the node is in the graph.</returns>
        public virtual bool ContainsNode(INode node)
        {
            return _nodes.Contains(node);
        }

        /// <summary>
        /// Determines if the edge is in the graph.
        /// </summary>
        /// <param name="edge">The edge to check.</param>
        /// <returns>A flag determining if the edge is in the graph.</returns>
        public virtual bool ContainsEdge(IEdge edge)
        {
            return _edges.Contains(edge);
        }

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public virtual void AddNode(INode node)
        {
            if (!_nodes.Contains(node))
            {
                _nodes.Add(node);
            }
        }

        /// <summary>
        /// Adds an edge to the graph.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
        public virtual void AddEdge(IEdge edge)
        {
            if (!_edges.Contains(edge))
            {
                _edges.Add(edge);
            }
        }

        /// <summary>
        /// Removes a node from the graph.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        public virtual void RemoveNode(INode node)
        {
            if (_nodes.Contains(node))
            {
                _nodes.Remove(node);
            }
        }

        /// <summary>
        /// Removes an edge from the graph.
        /// </summary>
        /// <param name="edge">The edge to remove.</param>
        public virtual void RemoveEdge(IEdge edge)
        {
            if (_edges.Contains(edge))
            {
                _edges.Remove(edge);
            }
        }
    }
}