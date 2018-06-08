public abstract class Audio
{
    public string Id { get { return _id; } }

    protected string _id;
    protected AudioAsset _audioAsset;

    public Audio(string id, AudioAsset audioAsset)
    {
        _id = id;
        _audioAsset = audioAsset;
    }
}