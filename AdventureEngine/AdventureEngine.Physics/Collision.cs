using Microsoft.Xna.Framework;

namespace AdventureEngine.Physics2D
{
    public class Collision
    {
        /// <summary>
        /// Gets and Sets the first entity involved in the collision.
        /// </summary>
        public string Entity1
        {
            get { return _entity1; }
            set { _entity1 = value; }
        }

        /// <summary>
        /// Gets and Sets the second entity involved in the collision.
        /// </summary>
        public string Entity2
        {
            get { return _entity2; }
            set { _entity2 = value; }
        }

        /// <summary>
        /// Gets and Sets the depth of penetration.
        /// </summary>
        public float Penetration { get { return _penetration; } }

        /// <summary>
        /// Gets and Sets the collision normal vector.
        /// </summary>
        public Vector2 Normal { get { return _normal; } }

        protected string _entity1;
        protected string _entity2;
        protected Vector2 _normal;
        protected float _penetration;

        public Collision(string entity1, string entity2, float penetration, Vector2 normal)
        {
            _entity1 = entity1;
            _entity2 = entity2;
            _penetration = penetration;
            _normal = normal;
        }
    }
}