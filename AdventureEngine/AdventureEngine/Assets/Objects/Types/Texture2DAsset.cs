using Microsoft.Xna.Framework.Graphics;

public class Texture2DAsset : AssetObject
{
    /* Static Methods */
    public static Texture2DAsset Load(AssetDefinition definition, ContentBatch batch)
    {
        Texture2D texture = batch.ContentManager.Load<Texture2D>(definition.FilePath);
        Texture2DAsset asset = new Texture2DAsset(definition.AssetId, texture);
        asset.AddParentBatch(batch);
        return asset;
    }

    /* Properties */
    public Texture2D Texture
    {
        get { return _texture; }
    }

    /* Variables */
    protected Texture2D _texture;

    /* Methods */
    public Texture2DAsset(string assetId, Texture2D texture) : base(assetId)
    {
        _texture = texture;
    }
}