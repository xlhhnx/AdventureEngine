using AdventureEngine.Graphing;

namespace AdventureEngine.Grids
{
    public class Tile3D : Tile2D
    {
        public virtual int Z
        {
            get { return _z; }
            set { _z = value; }
        }

        protected int _z;

        /// <summary>
        /// Creates a 3d tile.
        /// </summary>
        /// <param name="x">The horizontal position of the tile.</param>
        /// <param name="y">The vertical position of the tile.</param>
        /// <param name="z">The depth position of the tile.</param>
        /// <param name="graph">The graph this tile is a part of.</param>
        public Tile3D(int x, int y, int z, Graph graph) : base(x, y, graph)
        {
            _z = z;
        }
    }
}