using AdventureEngine.Graphics2D.Assets;
using Microsoft.Xna.Framework;

namespace AdventureEngine.Graphics2D.Components
{
    public class SpriteComponent : Sprite, IComponent
    {
        public virtual string EntityId { get { return _entityId; } }
        public virtual string Name { get { return _name; } }


        protected string _entityId;
        protected string _name;


        public SpriteComponent(string entityId, string name, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Color color, Vector2 positionOffset, Vector2 dimensions, int rows, int columns, int frameTime, bool looping = true, bool enabled = true, bool visible = true)
            : base(texture2DAsset, sourcePosition, sourceDimensions, color, positionOffset, dimensions, rows, columns, frameTime, looping, enabled, visible)
        {
            _entityId = entityId;
            _name = name;
        }

        public override IGraphic2D Copy()
        {
            return new SpriteComponent(_entityId, _name, _texture2DAsset, _sourceRectangle.GetPosition(), _sourceRectangle.GetDimensions(), _color, _positionOffset, _dimensions, _rows, _columns, _frameTime, _looping, _enabled, _visible);
        }
    }
}