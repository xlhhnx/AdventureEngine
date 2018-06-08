using NAudio.Wave;

public class Song : Audio
{
    public Song(string id, AudioAsset audioAsset) : base(id, audioAsset)
    { }

    public WaveStream CreateWaveStream()
    {
        if (_audioAsset.Loaded)
        {
            return new WaveChannel32(_audioAsset.Stream);
        }
        else
        {
            return null;
        }
    }
}