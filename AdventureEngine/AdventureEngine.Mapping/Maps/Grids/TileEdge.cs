using System;

public class TileEdge : IEdge
{
    public virtual Graph Graph { get { return _graph; } }

    public virtual INode Node1
    {
        get { return _node1; }
        set { _node1 = value; }
    }

    public virtual INode Node2
    {
        get { return _node2; }
        set { _node2 = value; }
    }

    protected INode _node1;
    protected INode _node2;
    protected Graph _graph;

    public TileEdge(INode node1, INode node2, Graph graph) : base()
    {
        _node1 = node1;
        _node2 = node2;
        _graph = graph;

        _node1.Edges.Add(this);
        _node2.Edges.Add(this);
    }

    public virtual INode Traverse(INode startNode)
    {
        if (_node1 == startNode)
        {
            return _node2;
        }
        else if (_node2 == startNode)
        {
            return _node1;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Removes a node from the edge.
    /// </summary>
    /// <param name="node">The node to be removed.</param>
    public virtual void RemoveNode(INode node)
    {
        if (_node1 == node)
        {
            _node1 = null;
        }

        if (_node2 == node)
        {
            _node2 = null;
        }
    }
}