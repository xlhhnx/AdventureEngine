using System.Collections.Generic;

public class Grid2D : Graph
{
    /// <summary>
    /// Gets and Sets the flag that determines if diagonal edges are generated when edges are regenerated.
    /// </summary>
    public virtual bool DiagonalTraversal
    {
        get { return _diagonalTraversal; }
        set { _diagonalTraversal = value; }
    }

    /// <summary>
    /// Gets and Sets the grid width. Resizes the grid if the width is changed.
    /// </summary>
    public virtual int Width
    {
        get { return _width; }
        set
        {
            if (value != _width)
            {
                _width = value;
                ResizeGrid();
            }
        }
    }

    /// <summary>
    /// Gets and Sets the grid height. Resizes the grid if the height is changed.
    /// </summary>
    public virtual int Height
    {
        get { return _height; }
        set
        {
            if (value != _height)
            {
                _width = value;
                ResizeGrid();
            }
        }
    }

    /// <summary>
    /// Accesses the tiles in the grid.
    /// </summary>
    /// <param name="xPos">The horizontal position of the tile.</param>
    /// <param name="yPos">The vertical position of the tile.</param>
    /// <returns>A tile or null.</returns>
    public virtual Tile2D this[int xPos, int yPos]
    {
        get
        {
            var nodeIndex = (yPos * _width) + xPos;
            if (_nodes.Count > nodeIndex)
            {
                return (Tile2D)_nodes[nodeIndex];
            }
            else
            {
                return null;
            }
        }

        set
        {
            var nodeIndex = (yPos * _width) + xPos;
            if (_nodes.Capacity > nodeIndex && value is Tile2D)
            {
                _nodes[nodeIndex] = value;
            }
        }
    }

    protected bool _diagonalTraversal;
    protected int _width;
    protected int _height;

    /// <summary>
    /// Creates a 2D grid.
    /// </summary>
    /// <param name="width">The width of the grid.</param>
    /// <param name="height">The height of the grid.</param>
    public Grid2D(int width, int height) : base()
    {
        _width = width;
        _height = height;
        ResizeGrid(false);
    }

    /// <summary>
    /// Resizes the grid based on the existing height and width.
    /// </summary>
    /// <param name="keepExistingTiles">Determines if the existing tiles should be copied to the new grid.</param>
    protected virtual void ResizeGrid(bool keepExistingTiles = true)
    {
        var newNodes = new List<INode>(_width * _height);

        if (keepExistingTiles)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var nodeIndex = (y * _width) + x;
                    newNodes.Add(_nodes[nodeIndex]);
                }
            }
        }
        _nodes = newNodes;
    }

    public override void AddEdge(IEdge edge)
    {
        if (edge is TileEdge)
        {
            base.AddEdge(edge);
        }
    }

    public override void RemoveEdge(IEdge edge)
    {
        if (edge is TileEdge)
        {
            RemoveEdge(edge as TileEdge);
        }
    }

    /// <summary>
    /// Removes an edge.
    /// </summary>
    /// <param name="edge">The edge to be removed.</param>
    public virtual void RemoveEdge(TileEdge edge)
    {
        edge.Node1.Edges.Remove(edge);
        edge.Node2.Edges.Remove(edge);
        _edges.Remove(edge);
    }

    public override void AddNode(INode node)
    {
        if (node is Tile2D)
        {
            AddTile(node as Tile2D);
        }
    }

    /// <summary>
    /// Adds a tile to the grid.
    /// </summary>
    /// <param name="tile">The tile to add.</param>
    public virtual void AddTile(Tile2D tile)
    {
        this[tile.X, tile.Y] = tile;
    }

    public override void RemoveNode(INode node)
    {
        if (node is Tile2D)
        {
            ResetTile(node as Tile2D);
        }
    }

    /// <summary>
    /// Removed a tile from the grid.
    /// </summary>
    /// <param name="tile">The tile to remove.</param>
    public virtual void ResetTile(Tile2D tile)
    {
        this[tile.X, tile.Y] = new Tile2D(tile.X, tile.Y, this);
    }

    /// <summary>
    /// Regenerates the edges of the grid.
    /// </summary>
    /// <param name="keepExistingEdges">Determins if the existing edges should be kept or removed.</param>
    public virtual void RegenerateEdges(bool keepExistingEdges = true)
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                if (!keepExistingEdges)
                {
                    foreach (TileEdge edge in this[x, y].Edges)
                    {
                        this[x, y].RemoveEdge(edge);
                    }
                }

                var yPlusValid = y < _height - 1;
                var xPlusValid = x < _width - 1;

                if (yPlusValid)
                {
                    var edge = new TileEdge(this[x, y], this[x, y + 1], this);
                    this[x, y].AddEdge(edge);
                    this[x, y + 1].AddEdge(edge);

                    if (xPlusValid)
                    {
                        edge = new TileEdge(this[x, y], this[x + 1, y + 1], this);
                        this[x, y].AddEdge(edge);
                        this[x + 1, y + 1].AddEdge(edge);
                    }
                }

                if (xPlusValid)
                {
                    var edge = new TileEdge(this[x, y], this[x + 1, y], this);
                    this[x, y].AddEdge(edge);
                    this[x + 1, y].AddEdge(edge);
                }
            }
        }
    }
}