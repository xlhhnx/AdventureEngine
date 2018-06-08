using NAudio.Wave;

public class Sound : Audio
{
    public float[] AudioData { get { return _audioData; } }
    public WaveFormat WaveFormat
    {
        get
        {
            if (_audioAsset.Loaded)
            {
                return _audioAsset.Stream.WaveFormat;
            }
            else
            {
                return null;
            }
        }
    }

    protected float[] _audioData;

    public Sound(string id, float[] audioData, AudioAsset audioAsset) : base(id, audioAsset)
    {
        _audioData = audioData;
    }

    public ISampleProvider CreateSampleProvider()
    {
        return new SoundSampleProvider(this);
    }
}