using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class AssetBatch
{
    /// <summary>
    /// Gets and Sets the _definitionsLoaded flag.
    /// </summary>
    public bool Defined
    {
        get { return _definitionsLoaded; }
        set { _definitionsLoaded = value; }
    }

    /// <summary>
    /// Gets and Sets the _assetsLoaded flag.
    /// </summary>
    public bool Loaded
    {
        get { return _assetsLoaded; }
        set { _assetsLoaded = value; }
    }

    /// <summary>
    /// Gets the ID of this AssetBatch.
    /// </summary>
    public string Id { get { return _assetBatchId; } }

    /// <summary>
    /// Gets the file path for this AssetBatch's AssetDefinitions.
    /// </summary>
    public string AssetDefinitionsFilePath { get { return _assetDefinitionsFilePath; } }

    /// <summary>
    /// Gets the ContentManager for this AssetBatch.
    /// </summary>
    public ContentManager ContentManager { get { return _contentManager; } }

    /// <summary>
    /// Gets the AssetDefinitions in this AssetBatch. 
    /// </summary>
    public List<AssetDefinition> AssetDefinitions { get { return _assetDefinitions; } }

    protected bool _definitionsLoaded;
    protected bool _assetsLoaded;
    protected string _assetBatchId;
    protected string _assetDefinitionsFilePath;
    protected List<AssetDefinition> _assetDefinitions;
    protected List<Asset> _assets;
    protected ContentManager _contentManager;

    /// <summary>
    /// Constructs an AssetBatch.
    /// </summary>
    /// <param name="serviceProvider">A IServiceProvider that will be passed to the ContentManager constructor.</param>
    /// <param name="assetBatchId">A unique ID for the new AssetBatch.</param>
    /// <param name="rootDirectory">A directory path that will be used as the root directory of the ContentManager.</param>
    public AssetBatch(IServiceProvider serviceProvider, string assetBatchId, string assetDefinitionsFilePath, [Optional]string rootDirectory)
    {
        _assetBatchId = assetBatchId;

        if (rootDirectory == null)
        {
            _contentManager = new ContentManager(serviceProvider);
        }
        else
        {
            _contentManager = new ContentManager(serviceProvider, rootDirectory);
        }

        _definitionsLoaded = false;
        _assetsLoaded = false;
        _assetDefinitions = new List<AssetDefinition>();
        _assets = new List<Asset>();
    }

    /// <summary>
    /// Adds a single AssetDefinition to the list.
    /// </summary>
    /// <param name="assetDefinition">An AssetDefinition to be added to the list.</param>
    public void AddAssetDefinition(AssetDefinition assetDefinition)
    {
        if (!_assetDefinitions.Contains(assetDefinition))
        {
            _assetDefinitions.Add(assetDefinition);
        }
    }

    /// <summary>
    /// Adds an ICollection of AssetDefinitions to the list.
    /// </summary>
    /// <param name="assetDefinitions">An ICollection of AssetDefinitions to be added to the list.</param>
    public void AddAssetDefinition(ICollection<AssetDefinition> assetDefinitions)
    {
        foreach (AssetDefinition ad in assetDefinitions)
        {
            AddAssetDefinition(ad);
        }
    }

    /// <summary>
    /// Adds a single Asset to the list.
    /// </summary>
    /// <param name="asset">An Asset to be added to the list.</param>
    public void AddAsset(Asset asset)
    {
        if (!_assets.Contains(asset))
        {
            _assets.Add(asset);
        }
    }

    /// <summary>
    /// Adds an ICollection of Assets to the list.
    /// </summary>
    /// <param name="assets">An ICollection of Assets to be added to the list.</param>
    public void AddAsset(ICollection<Asset> assets)
    {
        foreach (Asset a in assets)
        {
            AddAsset(a);
        }
    }

    /// <summary>
    /// Sets the _assetsLoaded flag to false, empties the Assets list, and unloads the ContentManager.
    /// </summary>
    public void UnloadAssets()
    {
        _assetsLoaded = false;
        _assets = new List<Asset>();
        _contentManager.Unload();
    }

    /// <summary>
    /// Sets the _definitionsLoaded flag to falseand empties the AssetDefinitions list.
    /// </summary>
    public void UnloadDefinitions()
    {
        _definitionsLoaded = false;
        _assetDefinitions = new List<AssetDefinition>();
    }
}