using Microsoft.Xna.Framework.Graphics;

public class EffectAsset : AssetObject
{
    /* Static Methods */
    public static EffectAsset Load(AssetDefinition definition, ContentBatch batch)
    {
        Effect effect = batch.ContentManager.Load<Effect>(definition.FilePath);
        EffectAsset asset = new EffectAsset(definition.AssetId, effect);
        asset.AddParentBatch(batch);
        return asset;
    }

    /* Properties */
    public Effect Effect
    {
        get { return _effect; }
    }

    /* Variables */
    protected Effect _effect;

    /* Methods */
    public EffectAsset(string assetId, Effect effect) : base(assetId)
    {
        _effect = effect;
    }
}