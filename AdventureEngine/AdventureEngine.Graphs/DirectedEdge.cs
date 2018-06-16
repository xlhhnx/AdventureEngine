using System;

namespace AdventureEngine.Graphing
{
    public class DirectedEdge : IEdge
    {
        public virtual Graph Graph { get { return _graph; } }

        public virtual INode Node1
        {
            get { return _startNode; }
            set { _startNode = value; }
        }

        public virtual INode Node2
        {
            get { return _endNode; }
            set { _endNode = value; }
        }

        protected INode _startNode;
        protected INode _endNode;
        protected Graph _graph;

        public DirectedEdge(INode startNode, INode endNode, Graph graph)
        {
            _startNode = startNode;
            _endNode = endNode;
            _graph = graph;
        }

        public virtual INode Traverse(INode startNode)
        {
            if (_startNode == startNode)
            {
                return _endNode;
            }
            else
            {
                return null;
            }
        }
    }
}