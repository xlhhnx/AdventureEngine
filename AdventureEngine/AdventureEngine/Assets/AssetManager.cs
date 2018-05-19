using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
        bool collecting = false;
        string currentJSON = "";

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
                    var definition = JsonConvert.DeserializeObject<AssetDefinition>(currentJSON);
                    _assetDefinitions.Add(definition.AssetId, definition);
                    currentJSON = string.Empty;
                }
            }
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