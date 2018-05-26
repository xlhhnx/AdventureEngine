using System;
using System.Collections.Generic;

public class Tile2D : INode
{
    /// <summary>
    /// Gets and Sets the x position of the tile.
    /// </summary>
    public virtual int X
    {
        get { return _x; }
        set { _x = value; }
    }

    /// <summary>
    /// Gets and Sets the y position of the tile.
    /// </summary>
    public virtual int Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public virtual Graph Graph { get { return _graph; } }

    public virtual List<IEdge> Edges
    {
        get { return _edges; }
        set { _edges = value; }
    }

    protected int _x;
    protected int _y;
    protected Graph _graph;
    protected List<IEdge> _edges;

    /// <summary>
    /// Creates a 2d tile.
    /// </summary>
    /// <param name="x">The horizontal position of the tile.</param>
    /// <param name="y">The vertical position of the tile.</param>
    /// <param name="graph">The graph this tile is a part of.</param>
    public Tile2D(int x, int y, Graph graph) : base()
    {
        _x = x;
        _y = y;
        _graph = graph;
        _edges = new List<IEdge>();
    }

    public virtual INode TraverseEdge(int edgeIndex)
    {
        if (_edges.Count > edgeIndex)
        {
            return _edges[edgeIndex].Traverse(this);
        }
        else
        {
            return null;
        }
    }

    public virtual INode TraverseEdge(IEdge edge)
    {
        if (_edges.Contains(edge))
        {
            return edge.Traverse(this);
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Adds an edge to the node.
    /// </summary>
    /// <param name="edge">The edge to add.</param>
    public virtual void AddEdge(TileEdge edge)
    {
        if (!_edges.Contains(edge) && edge.Graph == _graph 
            && (edge.Node1 == this || edge.Node2 == this))
        {
            _edges.Add(edge);
        }
    }

    /// <summary>
    /// Removes an edge from the node.
    /// </summary>
    /// <param name="edge">The edge to remove.</param>
    public virtual void RemoveEdge(IEdge edge)
    {
        if (_edges.Contains(edge))
        {
            _edges.Remove(edge);
        }
    }

    /// <summary>
    /// Removes an edge from the node at the index provided.
    /// </summary>
    /// <param name="edgeIndex">The index of the edge to remove.</param>
    public virtual void RemoveEdge(int edgeIndex)
    {
        if (_edges.Count > edgeIndex)
        {
            _edges.RemoveAt(edgeIndex);
        }
    }
}