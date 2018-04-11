using System;
using System.Collections.Generic;

public class AssetDefinition
{
    /* Properties */
    public string FilePath
    {
        get { return _filePath; }
    }

    public string AssetId
    {
        get { return _assetId; }
    }

    public string AssetType
    {
        get { return _assetType; }
    }

    public List<string> BatchIds
    {
        get { return _batchIds; }
    }

    /* Variables */
    protected string _filePath;
    protected string _assetId;
    protected string _assetType;
    protected List<string> _batchIds;

    /* Methods */
    public AssetDefinition(string filePath, string assetId, string assetType, List<string> batchIds)
    {
        _filePath = filePath;
        _assetId = assetId;
        _assetType = assetType;
        _batchIds = batchIds;
    }
}