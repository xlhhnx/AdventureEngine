using Microsoft.Xna.Framework.Content;
using System.Linq;
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

    public ContentManager ContentManager
    {
        get { return _contentManager; }
    }

    public List<AssetObject> Assets
    {
        get { return _assets; }
    }

    /* Variables */
    protected string _batchId;
    protected bool _loaded;
    protected ContentManager _contentManager;
    protected AssetManager _assetManager;
    protected List<AssetObject> _assets;

    /* Methods */
    public ContentBatch(AssetManager assetManager)
    {
        _assetManager = assetManager;

        _contentManager = new ContentManager(_assetManager.ServiceProvider);
        _assets = new List<AssetObject>();
        _batchId = string.Empty; // Not yet loaded
    }

    public void Load(string batchId)
    {
        if(_batchId != string.Empty)
            _batchId = batchId;

        // Retrieve asset definitions
        List<AssetDefinition> assetDefinitions = new List<AssetDefinition>(
            from asset in _assetManager.AssetDefinitions
            where asset.BatchIds.Contains(BatchId)
            select asset
            );
        
        for (int i = 0; i < assetDefinitions.Count;)
        {
            if (_assetManager.AssetObjects.ContainsKey(assetDefinitions[i].AssetId))
            {
                string assetId = assetDefinitions[i].AssetId;
                _assetManager.AssetObjects[assetId].AddParentBatch(this);
                assetDefinitions.RemoveAt(i);
            }
            else
            {
                i++;
            }
        }

        // Load assets
        foreach (AssetDefinition definition in assetDefinitions)
        {
            AssetObject asset = null;

            switch (definition.AssetType)
            {
                case ("Texture2D"): { asset = Texture2DAsset.Load(definition, this); } break;
                case ("SpriteFont"): { asset = SpriteFontAsset.Load(definition, this); } break;
                case ("Effect"): { asset = EffectAsset.Load(definition, this); } break;
            }

            if (asset != null)
                _assets.Add(asset);
        }

        _loaded = true;
    }

    public void Unload()
    {
        _loaded = false;
        _assets = new List<AssetObject>();

        _contentManager.Unload();
    }
}