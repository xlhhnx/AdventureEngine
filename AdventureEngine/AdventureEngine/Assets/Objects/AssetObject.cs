using System.Collections.Generic;

public abstract class AssetObject
{
    /* Properties */
    public bool Loaded
    {
        get { return _parentContentBatches.Find(p => p.Loaded) != null; }
    }

    public string AssetId
    {
        get { return _assetId; }
    }

    /* Variables */
    protected string _assetId;
    protected List<ContentBatch> _parentContentBatches;

    /* Methods */
    public AssetObject(string assetId)
    {
        _assetId = assetId;

        _parentContentBatches = new List<ContentBatch>();
    }

    public void AddParentBatch(ContentBatch batch)
    {
        if (!_parentContentBatches.Contains(batch))
            _parentContentBatches.Add(batch);
    }
}