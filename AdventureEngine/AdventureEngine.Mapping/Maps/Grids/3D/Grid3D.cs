public class Grid3D : Graph
{
    /// <summary>
    /// Gets and Sets the flag that determines if diagonal edges are generated when edges are regenerated.
    /// </summary>
    public bool DiagonalTraversal
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
    /// Gets and Sets the grid depth. Resizes the grid if the depth is changed.
    /// </summary>
    public virtual int Depth
    {
        get { return _depth; }
        set
        {
            if (value != _depth)
            {
                _depth = value;
                ResizeGrid();
            }
        }
    }

    /// <summary>
    /// Accesses the tiles in the grid.
    /// </summary>
    /// <param name="xPos">The horizontal position of the tile.</param>
    /// <param name="yPos">The vertical position of the tile.</param>
    /// <param name="zPos">The depth position of the tile.</param>
    /// <returns>A tile or null.</returns>
    public virtual Tile3D this[int xPos, int yPos, int zPos]
    {
        get
        {
            if (xPos < _width && yPos < _height && zPos < _depth)
            {
                return _tiles[xPos, yPos, zPos];
            }
            else
            {
                return null;
            }
        }

        set
        {
            if (xPos < _width && yPos < _height && zPos < _depth)
            {
                _nodes.Remove(_tiles[xPos, yPos, zPos]);
                _tiles[xPos, yPos, zPos] = value;
                _nodes.Add(value);
            }
        }
    }

    protected bool _diagonalTraversal;
    protected int _width;
    protected int _height;
    protected int _depth;
    protected Tile3D[,,] _tiles;

    // Creates a 3d grid.
    public Grid3D(int width, int height, int depth) : base()
    {
        _width = width;
        _height = height;
        _depth = depth;
    }

    /// <summary>
    /// Resizes the grid based on the existing height, width, and depth.
    /// </summary>
    /// <param name="keepExistingTiles">Determines if the existing tiles should be copied to the new grid.</param>
    public void ResizeGrid(bool keepExistingTiles = true)
    {
        var newGrid = new Tile3D[_width, _height, _depth];

        if (keepExistingTiles)
        {

        }
        _tiles = newGrid;
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
    public void RemoveEdge(TileEdge edge)
    {
        edge.Node1.Edges.Remove(edge);
        edge.Node2.Edges.Remove(edge);
        _edges.Remove(edge);
    }

    public override void AddNode(INode node)
    {
        if (node is Tile3D)
        {
            AddTile(node as Tile3D);
        }
    }

    /// <summary>
    /// Adds a tile to the grid.
    /// </summary>
    /// <param name="tile">The tile to add.</param>
    public void AddTile(Tile3D tile)
    {
        this[tile.X, tile.Y, tile.Z] = tile;
    }

    public override void RemoveNode(INode node)
    {
        if (node is Tile3D)
        {
            ResetTile(node as Tile3D);
        }
    }

    /// <summary>
    /// Removed a tile from the grid.
    /// </summary>
    /// <param name="tile">The tile to remove.</param>
    public void ResetTile(Tile3D tile)
    {
        this[tile.X, tile.Y, tile.Z] = new Tile3D(tile.X, tile.Y, tile.Z, this);
    }

    /// <summary>
    /// Regenerates the edges of the grid.
    /// </summary>
    /// <param name="keepExistingEdges">Determins if the existing edges should be kept or removed.</param>
    public void RegenerateEdges(bool keepExistingEdges = true)
    {
        for (int z = 0; z < _depth; z++)
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (!keepExistingEdges)
                    {
                        foreach (TileEdge edge in this[x, y, z].Edges)
                        {
                            this[x, y, z].RemoveEdge(edge);
                        }
                    }

                    var yPlusValid = y < _height - 1;
                    var xPlusValid = x < _width - 1;
                    var zPlusValid = z < _depth - 1;

                    if (zPlusValid)
                    {
                        var edge = new TileEdge(this[x, y, z], this[x, y, z + 1], this);
                        this[x, y, z].AddEdge(edge);
                        this[x, y, z + 1].AddEdge(edge);

                        if (yPlusValid)
                        {
                            edge = new TileEdge(this[x, y, z], this[x, y + 1, z + 1], this);
                            this[x, y, z].AddEdge(edge);
                            this[x, y + 1, z + 1].AddEdge(edge);

                            if (xPlusValid)
                            {
                                edge = new TileEdge(this[x, y, z], this[x + 1, y + 1, z + 1], this);
                                this[x, y, z].AddEdge(edge);
                                this[x + 1, y + 1, z + 1].AddEdge(edge);
                            }
                        }

                        if (xPlusValid)
                        {
                            edge = new TileEdge(this[x, y, z], this[x + 1, y, z + 1], this);
                            this[x, y, z].AddEdge(edge);
                            this[x + 1, y, z + 1].AddEdge(edge);
                        }
                    }

                    if (yPlusValid)
                    {
                        var edge = new TileEdge(this[x, y, z], this[x, y + 1, z], this);
                        this[x, y, z].AddEdge(edge);
                        this[x, y + 1, z].AddEdge(edge);

                        if (xPlusValid)
                        {
                            edge = new TileEdge(this[x, y, z], this[x + 1, y + 1, z], this);
                            this[x, y, z].AddEdge(edge);
                            this[x + 1, y + 1, z].AddEdge(edge);
                        }
                    }

                    if (xPlusValid)
                    {
                        var edge = new TileEdge(this[x, y, z], this[x + 1, y, z], this);
                        this[x, y, z].AddEdge(edge);
                        this[x + 1, y, z].AddEdge(edge);
                    }
                }
            }
        }
    }
}