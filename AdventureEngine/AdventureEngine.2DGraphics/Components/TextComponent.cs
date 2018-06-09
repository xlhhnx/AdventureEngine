using Microsoft.Xna.Framework;

public class TextComponent : Text, IComponent
{
    public virtual string EntityId { get { return _entityId; } }
    public virtual string Name { get { return _name; } }


    protected string _entityId;
    protected string _name;


    public TextComponent(string entityId, string name, SpriteFontAsset spriteFontAsset, Color color, Color disabledColor, Vector2 positionOffset, Vector2 dimensions, string fullText) 
        : base(spriteFontAsset, color, disabledColor, positionOffset, dimensions, fullText)
    {
        _entityId = entityId;
        _name = name;
    }

    public override IGraphic2D Copy()
    {
        return new TextComponent(_entityId, _name, _spriteFontAsset, _color, _disabledColor, _positionOffset, _dimensions, _fullText);
    }
}