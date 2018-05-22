using System.Collections.Generic;

public class Asset
{
    /// <summary>
    /// Gets a flag that defines whether the Asset is currently loaded.
    /// </summary>
    public bool Loaded
    {
        get
        {
            foreach (var id in _batchIds)
            {
                if (_assetManager.ContainsBatch(id) && _assetManager.GetBatch(id).Loaded == true)
                {
                    return true;
                }
            }
            return false;
        }
    }

    /// <summary>
    /// Get the Id of the Asset.
    /// </summary>
    public string Id { get { return _assetId; } }

    protected string _assetId;
    protected AssetManager _assetManager;
    protected List<string> _batchIds;

    /// <summary>
    /// Constructs an Asset.
    /// </summary>
    /// <param name="assetId">The unique Id of the Asset.</param>
    /// <param name="assetManager">The AssetManager that initially loaded the Asset.</param>
    /// <param name="batchIds">The list of BatchIds corresponding to batches that this Asset belongs to.</param>
    public Asset(string assetId, AssetManager assetManager, List<string> batchIds)
    {
        _assetId = assetId;
        _assetManager = assetManager;
        _batchIds = batchIds;
    }
}