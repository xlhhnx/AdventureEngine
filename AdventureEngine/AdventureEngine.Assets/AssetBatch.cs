using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

public class AssetBatch
{
    public string Id
    {
        get { return _id; }
    }

    /// <summary>
    /// Determines if the asset batch is loaded.
    /// </summary>
    public bool Loaded
    {
        get { return _loaded; }
        set { _loaded = value; }
    }

    /// <summary>
    /// Gets the content manager.
    /// </summary>
    public ContentManager Content { get { return _contentManager; } }

    /// <summary>
    /// Gets and Sets the dictionary describing the paths to file and the ids inside that belong to this batch.
    /// </summary>
    public Dictionary<string, List<string>> FileIdDictionary
    {
        get { return _fileIdDictionary; }
        set { _fileIdDictionary = value; }
    }

    /// <summary>
    /// Gets and Sets the list of assets that are part of the batch.
    /// </summary>
    public List<Asset> Assets
    {
        get { return _assets; }
        set { _assets = value; }
    }

    protected string _id;
    protected bool _loaded;
    protected ContentManager _contentManager;
    // FilePath => List<Id>
    protected Dictionary<string, List<string>> _fileIdDictionary;
    protected List<Asset> _assets;

    /// <summary>
    /// Creates an asset batch.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to create the content manager.</param>
    public AssetBatch(string id, IServiceProvider serviceProvider)
    {
        _id = id;
        _contentManager = new ContentManager(serviceProvider);
        _fileIdDictionary = new Dictionary<string, List<string>>();
        _assets = new List<Asset>();
    }

    /// <summary>
    /// Creates an asset batch.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to create the content manager.</param>
    /// <param name="rootDirectory">THe root directory given to the content manager.</param>
    public AssetBatch(IServiceProvider serviceProvider, string rootDirectory)
    {
        _contentManager = new ContentManager(serviceProvider, rootDirectory);
        _assets = new List<Asset>();
    }

    /// <summary>
    /// Adds an asset definition to the asset batch.
    /// </summary>
    /// <param name="filePath">The path to the file that describes the asset.</param>
    /// <param name="assetId">The id of the asset.</param>
    public void AddAssetDefinition(string filePath, string assetId)
    {
        if (_fileIdDictionary.ContainsKey(filePath))
        {
            _fileIdDictionary[filePath].Add(assetId);
        }
        else
        {
            _fileIdDictionary.Add(filePath, new List<string>() { assetId });
        }
    }

    /// <summary>
    /// Removes an seet definition from the asset batch.
    /// </summary>
    /// <param name="filePath">The path to the file that describes the asset.</param>
    /// <param name="assetId">The id of the asset.</param>
    public void RemoveAssetDefinition(string filePath, string assetId)
    {
        if (_fileIdDictionary.ContainsKey(filePath))
        {
            if (_fileIdDictionary[filePath].Count == 1)
            {
                _fileIdDictionary.Remove(filePath);
            }
            else
            {
                _fileIdDictionary[filePath].Remove(assetId);
            }
        }
    }

    /// <summary>
    /// Adds an asset to the batch.
    /// </summary>
    /// <param name="asset">The asset to add.</param>
    public void AddAsset(Asset asset)
    {
        if (!_assets.Contains(asset))
        {
            _assets.Add(asset);
        }
    }

    /// <summary>
    /// Unloads all assets and unloads the content manager.
    /// </summary>
    public void Unload()
    {
        _loaded = false;
        foreach (Asset a in _assets)
        {
            a.Loaded = false;
        }
        _contentManager.Unload();
    }
}