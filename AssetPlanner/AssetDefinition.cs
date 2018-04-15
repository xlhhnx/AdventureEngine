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

    public string BatchId
    {
        get { return _batchId; }
    }

    /* Variables */
    protected string _filePath;
    protected string _assetId;
    protected string _assetType;
    protected string _batchId;

    /* Methods */
    public AssetDefinition(string filePath, string assetId, string assetType, string batchId)
    {
        _filePath = filePath;
        _assetId = assetId;
        _assetType = assetType;
        _batchId = batchId;
    }
}