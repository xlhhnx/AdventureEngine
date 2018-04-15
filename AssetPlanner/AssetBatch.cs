using System.Collections.Generic;

public class AssetBatch
{
    //Properties
    public string Name
    {
        get { return _name; }
    }

    public string BatchId
    {
        get { return _name; }
    }

    public List<AssetDefinition> Assets
    {
        get { return _assets; }
    }

    // Variables
    protected string _name;
    protected string _batchId;
    protected List<AssetDefinition> _assets;

    // Methods
    public AssetBatch(string name, string batchId)
    {
        _name = name;
        _batchId = batchId;

        _assets = new List<AssetDefinition>();
    }
}