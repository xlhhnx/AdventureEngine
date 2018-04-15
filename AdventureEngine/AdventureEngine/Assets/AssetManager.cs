using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class AssetManager
{
    // Properties
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

    // Variables
    protected List<AssetDefinition> _assetDefinitions;
    protected List<ContentBatch> _contentBatches;
    protected Dictionary<string, AssetObject> _assetObjects;
    protected IServiceProvider _serviceProvider;

    // Method
    public AssetManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        _assetDefinitions = new List<AssetDefinition>();
        _contentBatches = new List<ContentBatch>();
        _assetObjects = new Dictionary<string, AssetObject>();
    }

    public void LoadAssetDefinitions(string filePath)
    {
        bool collecting = false;
        string currentJSON = string.Empty;

        using (StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read)))
        {
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // IF line is an object start THEN set collecting flag
                if (line.Contains("{"))
                    collecting = true;

                // IF in an object THEN add the line to the string
                if (collecting)
                    currentJSON += '\n' + line;

                // IF line is an object end THEN deserialize the whole object
                if (line.Contains("}"))
                {
                    collecting = false;
                    _assetDefinitions.Add(
                        JsonConvert.DeserializeObject<AssetDefinition>(currentJSON)
                        );
                    currentJSON = string.Empty;
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