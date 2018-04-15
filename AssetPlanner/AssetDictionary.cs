using System.Collections.Generic;

public class AssetDictionary
{
    // Properties
    public string FileName
    {
        get { return _fileName; }
    }

    public List<AssetBatch> Batches
    {
        get { return _batches; }
    }

    // Variables
    protected string _fileName;
    protected List<AssetBatch> _batches;

    // Methods
    public AssetDictionary(string fileName)
    {
        _fileName = fileName;

        _batches = new List<AssetBatch>();
    }
}