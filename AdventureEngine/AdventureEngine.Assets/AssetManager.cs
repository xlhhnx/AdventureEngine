using System.Collections.Generic;

public class AssetManager
{
    public Texture2DAsset DefaultTexture2DAsset { get { return _defaultTexture2DAsset; } }
    public SpriteFontAsset DefaultSpriteFontAsset { get { return _defaultSpriteFontAsset; } }

    protected Texture2DAsset _defaultTexture2DAsset;
    protected SpriteFontAsset _defaultSpriteFontAsset;
    protected Dictionary<string, Asset> _assets;
    protected Dictionary<string, AssetBatch> _assetBatches;

    /// <summary>
    /// Creates an asset manager.
    /// </summary>
    public AssetManager(Texture2DAsset defaultTexture2DAsset, SpriteFontAsset defaultSpriteFontAsset)
    {
        _defaultTexture2DAsset = defaultTexture2DAsset;
        _defaultSpriteFontAsset = defaultSpriteFontAsset;
        _assets = new Dictionary<string, Asset>();
        _assetBatches = new Dictionary<string, AssetBatch>();
    }

    /// <summary>
    /// Adds an asset to the dictionary.
    /// </summary>
    /// <param name="asset">The asset to add.</param>
    public void AddAsset(Asset asset)
    {
        if (!_assets.ContainsKey(asset.Id))
        {
            _assets.Add(asset.Id, asset);
        }
    }

    /// <summary>
    /// Adds an asset batch to the dictionary.
    /// </summary>
    /// <param name="assetBatch">The asset batch to add.</param>
    public void AddAssetBatch(AssetBatch assetBatch)
    {
        if (!_assetBatches.ContainsKey(assetBatch.Id))
        {
            _assetBatches.Add(assetBatch.Id, assetBatch);
        }
    }

    /// <summary>
    /// Gets an asset based on an id.
    /// </summary>
    /// <param name="id">The id of the asset to get.</param>
    /// <returns>An asset or null.</returns>
    public Asset GetAsset(string id)
    {
        Asset asset = null;
        _assets.TryGetValue(id, out asset);
        return asset;
    }

    /// <summary>
    /// Gets an asset batch based on an id.
    /// </summary>
    /// <param name="id">The id of the asset batch to get.</param>
    /// <returns>An asset batch or null.</returns>
    public AssetBatch GetAssetBatch(string id)
    {
        AssetBatch assetBatch = null;
        _assetBatches.TryGetValue(id, out assetBatch);
        return assetBatch;
    }
}