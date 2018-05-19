using Microsoft.Xna.Framework.Graphics;

public class SpriteFontAsset : AssetObject
{
    /* Static Method */
    public static SpriteFontAsset Load(AssetDefinition definition, ContentBatch batch)
    {
        SpriteFont spriteFont = batch.ContentManager.Load<SpriteFont>(definition.FilePath);
        SpriteFontAsset asset = new SpriteFontAsset(definition.AssetId, spriteFont);
        asset.AddParentBatch(batch);
        return asset;
    }

    /* Properties */
    public SpriteFont SpriteFont
    {
        get { return _spriteFont; }
    }

    /* Variables */
    protected SpriteFont _spriteFont;

    /* Methods */
    public SpriteFontAsset(string assetId, SpriteFont spriteFont) : base(assetId)
    {
        _spriteFont = spriteFont;
    }
}