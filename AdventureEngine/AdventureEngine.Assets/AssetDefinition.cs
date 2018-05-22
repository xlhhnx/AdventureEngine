using System.Collections.Generic;

public class AssetDefinition
{
    /// <summary>
    /// Gets the file path of the actual asset.
    /// </summary>
    public string FilePath { get { return _filePath; } }

    /// <summary>
    /// Gets the unique Id of this AssetDefinition.
    /// </summary>
    public string Id { get { return _assetId; } }

    /// <summary>
    /// Gets the type of the definied asset.
    /// </summary>
    public string AssetType { get { return _assetType; } }

    /// <summary>
    /// Gets the list of batch Id's corresponding to batches that this AssetDefinition belongs to.
    /// </summary>
    public List<string> BatchIds { get { return _batchIds; } }

    protected string _filePath;
    protected string _assetId;
    protected string _assetType;
    protected List<string> _batchIds;

    /// <summary>
    /// Constructs an AssetDefinition.
    /// </summary>
    /// <param name="filePath">The file path of the actual asset.</param>
    /// <param name="assetId">The unique Id of this AssetDefinition.</param>
    /// <param name="assetType">The type of the definied asset.</param>
    public AssetDefinition(string filePath, string assetId, string assetType)
    {
        _filePath = filePath;
        _assetId = assetId;
        _assetType = assetType;

        _batchIds = new List<string>();
    }

    /// <summary>
    /// Constructs an AssetDefinition including the list of batchIds. 
    /// </summary>
    /// <param name="filePath">The file path of the actual asset.</param>
    /// <param name="assetId">The unique Id of this AssetDefinition.</param>
    /// <param name="assetType">The type of the definied asset.</param>
    /// <param name="batchIds">The list of batch Id's corresponding to batches that this AssetDefinition belongs to.</param>
    public AssetDefinition(string filePath, string assetId, string assetType, List<string> batchIds)
    {
        _filePath = filePath;
        _assetId = assetId;
        _assetType = assetType;
        _batchIds = batchIds;
    }
}