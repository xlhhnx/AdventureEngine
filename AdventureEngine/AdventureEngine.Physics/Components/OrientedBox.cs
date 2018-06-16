using Microsoft.Xna.Framework;

namespace AdventureEngine.Physics2D.Components
{
    public class OrientedBox : Shape
    {
        public override float Area { get { return _extent.X * _extent.Y * 4; } }

        /// <summary>
        /// Gets and Sets the axis of the oriented box.
        /// </summary>
        public Vector2 Axis
        {
            get { return _axis; }
            set { _axis = value; }
        }

        /// <summary>
        /// Gets and Sets the extent of the oriented box.
        /// </summary>
        public Vector2 Extent
        {
            get { return _extent; }
            set { _extent = value; }
        }

        protected Vector2 _axis;
        protected Vector2 _extent;

        /// <summary>
        /// Creates an oriented box.
        /// </summary>
        /// <param name="extent">The extent of the </param>
        public OrientedBox(string entityId, string name, Vector2 positionOffset, Vector2 axis, Vector2 extent) : base(entityId, name, positionOffset)
        {
            _axis = axis;
            _extent = extent;
        }
    }
}