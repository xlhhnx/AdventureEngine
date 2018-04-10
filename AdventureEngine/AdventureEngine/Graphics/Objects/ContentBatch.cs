using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

public class ContentBatch
{
    /* Properties */
    public bool Loaded
    {
        get { return _loaded; }
    }

    public string BatchId
    {
        get { return _batchId; }
    }

    public List<AssetObject> Assets
    {
        get { return _assets; }
    }

    /* Variables */
    protected string _batchId;
    protected bool _loaded;
    protected ContentManager _contentManager;
    protected GraphicsManager _graphicsManager;
    protected List<AssetObject> _assets;

    /* Methods */
    public ContentBatch(GraphicsManager graphicsManager)
    {
        _graphicsManager = graphicsManager;

        _contentManager = new ContentManager(_graphicsManager.ServiceProvider);
        _assets = new List<AssetObject>();
        _batchId = string.Empty; // Not yet loaded
    }

    public void Load(string batchId)
    {
        if(_batchId != string.Empty)
            _batchId = batchId;

        // Retrieve asset definitions
        List<AssetDefinition> assetDefinitions = _graphicsManager.AssetDefinitions.FindAll(e => e.BatchIds.Contains(batchId));
        
        for (int i = 0; i < assetDefinitions.Count;)
        {
            if (_graphicsManager.AssetObjects.ContainsKey(assetDefinitions[i].AssetId))
            {
                assetDefinitions.RemoveAt(i);
                _graphicsManager.AssetObjects[assetDefinitions[i].AssetId].AddParentBatch(this);
            }
            else
            {
                i++;
            }
        }

        // TODO: Load assets

        _loaded = true;
    }

    public void Unload()
    {
        _loaded = false;
        _assets = new List<AssetObject>();

        _contentManager.Unload();
    }
}