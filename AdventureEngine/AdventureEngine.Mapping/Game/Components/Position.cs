using System;
using Microsoft.Xna.Framework;

namespace AdventureEngine.Game.Components
{
    public class Position : IComponent
    {
        public string EntityId { get { return _entityId; } }
        public string Name { get { return _name; } }

        /// <summary>
        /// Gets and Sets the entity position.
        /// </summary>
        public Vector2 _Position
        {
            get { return _position; }
            set { _position = value; }
        }

        protected string _entityId;
        protected string _name;
        protected Vector2 _position;

        /// <summary>
        /// Creates a health component.
        /// </summary>
        /// <param name="entityId">The id of the entity this component is a part of you.</param>
        /// <param name="name">The name of thi component.</param>
        /// <param name="position">The starting health of the entity.</param>
        public Position(string entityId, string name, Vector2 position)
        {
            _entityId = entityId;
            _name = name;
            _position = position;
        }

        public string Serilize()
        {
            throw new NotImplementedException();
        }
    }
}