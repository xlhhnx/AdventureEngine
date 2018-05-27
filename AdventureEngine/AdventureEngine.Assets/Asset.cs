public abstract class Asset
{
    /// <summary>
    /// Gets the id of the asset.
    /// </summary>
    public string Id { get { return _id; } }

    /// <summary>
    /// Determines if the asset is currently Loaded.
    /// </summary>
    public abstract bool Loaded { get; set; }

    protected string _id;

    /// <summary>
    /// Creates an asset.
    /// </summary>
    /// <param name="id">THe id of the asset.</param>
    public Asset(string id)
    {
        _id = id;
    }
}