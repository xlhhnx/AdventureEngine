using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AssetManager
{
    // Properties
    public IServiceProvider ServiceProvider { get { return _serviceProvider; } }
    public Dictionary<string, ContentBatch> ContentBatches { get { return _contentBatches; } }
    public Dictionary<string, AssetDefinition> AssetDefinitions { get { return _assetDefinitions; } }
    public Dictionary<string, AssetObject> AssetObjects { get { return _assetObjects; } }

    // Variables
    protected Dictionary<string, ContentBatch> _contentBatches;
    protected Dictionary<string, AssetDefinition> _assetDefinitions;
    protected Dictionary<string, AssetObject> _assetObjects;
    protected IServiceProvider _serviceProvider;

    // Method
    public AssetManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _assetDefinitions = new Dictionary<string, AssetDefinition>();
        _contentBatches = new Dictionary<string, ContentBatch>();
        _assetObjects = new Dictionary<string, AssetObject>();
    }

    public void LoadAssetDefinitions(string filePath)
    {
        var assetDefinitions = File.ReadAllLines(filePath)
                                   .Where(l => l.Length > 0)
                                   .Select(l => AssetDefinition.Load(l))
                                   .Where(ad => ad != null);

        foreach (AssetDefinition assetDefinition in assetDefinitions)
        {
            _assetDefinitions.Add(assetDefinition.AssetId, assetDefinition);
        }
    }

    public bool LoadContentBatch(string batchId)
    {
        if (!_contentBatches.ContainsKey(batchId)) return false;

        ContentBatch batch = new ContentBatch(this);
        batch.Load(batchId);

        foreach (AssetObject asset in batch.Assets)
            _assetObjects.Add(asset.AssetId, asset);

        _contentBatches.Add(batchId, batch);
        return true;
    }

    public void ReloadContentBatch(string batchId)
    {
        if (!_contentBatches.ContainsKey(batchId)) return;
        ContentBatch batch = _contentBatches[batchId];

        foreach (AssetObject asset in batch.Assets)
            _assetObjects.Remove(asset.AssetId);

        batch.Unload();
        batch.Load(batchId);

        foreach (AssetObject asset in batch.Assets)
            _assetObjects.Add(asset.AssetId, asset);
    }
}