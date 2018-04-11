using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GraphicsManager
{
    /* Properties */
    public IServiceProvider ServiceProvider
    {
        get { return _serviceProvider; }
    }

    public List<AssetDefinition> AssetDefinitions
    {
        get { return _assetDefinitions; }
    }

    public Dictionary<string, AssetObject> AssetObjects
    {
        get { return _assetObjects; }
    }

    /* Variables */
    protected List<AssetDefinition> _assetDefinitions;
    protected List<ContentBatch> _contentBatches;
    protected Dictionary<string, AssetObject> _assetObjects;
    protected IServiceProvider _serviceProvider;

    /* Method */
    public GraphicsManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _assetDefinitions = new List<AssetDefinition>();
        _contentBatches = new List<ContentBatch>();
        _assetObjects = new Dictionary<string, AssetObject>();
    }

    public void LoadAssetDefinitions(string filePath)
    {
        using (StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
        {
            while (!reader.EndOfStream)
            {
                string path = string.Empty;
                string assetId = string.Empty;
                string assetType = string.Empty;
                List<string> batchIds = new List<string>();

                string line = reader.ReadLine();
                List<string> attributes = new List<string>(
                    line.Split(new char[] { ',' })
                );

                foreach (string attribute in attributes)
                {
                    string[] pair = attribute.Split(new char[] { '=' });
                    if (pair.Length != 2) continue;

                    switch (pair[0])
                    {
                        case ("filePath"): { path = pair[1]; } break;
                        case ("assetId"): { assetId = pair[1]; } break;
                        case ("assetType"): { assetType = pair[1]; } break;
                        case ("batchId"): { batchIds.Add(pair[1]); } break;
                    }
                }

                if (path != string.Empty && assetId != string.Empty && assetType != null && batchIds.Count != 0)
                {
                    AssetDefinition def = new AssetDefinition(path, assetId, assetType, batchIds);
                    _assetDefinitions.Add(def);
                }
            }
        }
    }

    public bool LoadContentBatch(string batchId)
    {
        if (_contentBatches.Find(cb => cb.BatchId == batchId) != null) return false; // If the batch already exists, dont reload it.

        ContentBatch batch = new ContentBatch(this);
        batch.Load(batchId);

        foreach (AssetObject asset in batch.Assets)
            _assetObjects.Add(asset.AssetId, asset);

        _contentBatches.Add(batch);
        return true;
    }

    public void ReloadContentBatch(string batchId)
    {
        ContentBatch batch = _contentBatches.Find(cb => cb.BatchId == batchId);
        if (batch == null) return; // If the batch doesn't exist, dont try to reload it.

        foreach (AssetObject asset in batch.Assets)
            _assetObjects.Remove(asset.AssetId);

        batch.Unload();
        batch.Load(batchId);

        foreach (AssetObject asset in batch.Assets)
            _assetObjects.Add(asset.AssetId, asset);

        _contentBatches.Add(batch);
    }

    private Type ParseTypeString(string typeString)
    {
        Type type = null;

        switch (typeString)
        {
            // TODO: Add cases
        }

        return type;
    }
}