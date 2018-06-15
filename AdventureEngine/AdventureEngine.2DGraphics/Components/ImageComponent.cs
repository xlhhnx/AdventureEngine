using AdventureEngine.Graphics2D.Assets;
using Microsoft.Xna.Framework;

namespace AdventureEngine.Graphics2D.Components
{
    public class ImageComponent : Image, IComponent
    {
        public virtual string EntityId { get { return _entityId; } }
        public virtual string Name { get { return _name; } }


        protected string _entityId;
        protected string _name;


        public ImageComponent(string entityId, string name, Texture2DAsset texture2DAsset, Vector2 sourcePosition, Vector2 sourceDimensions, Color color, Vector2 positionOffset, Vector2 dimsensions, bool enabled = true, bool visible = true)
            : base(texture2DAsset, sourcePosition, sourceDimensions, color, positionOffset, dimsensions, enabled, visible)
        {
            _entityId = entityId;
            _name = name;
        }

        public override IGraphic2D Copy()
        {
            return new ImageComponent(_entityId, _name, _texture2DAsset, _sourceRectangle.GetPosition(), _sourceRectangle.GetDimensions(), _color, _positionOffset, _dimensions, _enabled, _visible);
        }
    }
}