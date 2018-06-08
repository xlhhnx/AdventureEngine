using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;

public class AudioLoader : IAudioLoader
{
    protected Dictionary<string, string[]> _stagedFiles;
    protected AssetManager _assetManager;

    public AudioLoader(AssetManager assetManager)
    {
        _assetManager = assetManager;
    }

    public Sound LoadSound(AudioAsset audioAsset, string id)
    {
        if (!audioAsset.Loaded || !(audioAsset.Stream is AudioFileReader) ) return null;

        var reader = audioAsset.Stream as AudioFileReader;
        var wholeFile = new List<float>((int)(reader.Length / 4));
        var readBuffer = new float[reader.WaveFormat.SampleRate * reader.WaveFormat.Channels];
        int samplesRead;
        while ((samplesRead = reader.Read(readBuffer, 0, readBuffer.Length)) > 0)
        {
            wholeFile.AddRange(readBuffer.Take(samplesRead));
        }
        var audioData = wholeFile.ToArray();

        return new Sound(id, audioData, audioAsset);
    }

    public Song LoadSong(AudioAsset audioAsset, string id)
    {
        return new Song(id, audioAsset);
    }

    public IAudio LoadAudio(AudioAsset audioAsset, string id, AudioType audioType)
    {
        switch (audioType) {
            case (AudioType.Song): return LoadSong(audioAsset, id);
            case (AudioType.Sound): return LoadSound(audioAsset, id);
            default: return null;
        }
    }

    public List<IAudio> LoadAudios(Dictionary<string, AudioAsset> idAudioAssetDictionary, AudioType audioType)
    {
        var audios = new List<IAudio>();
        foreach (var id in idAudioAssetDictionary.Keys) audios.Add(LoadAudio(idAudioAssetDictionary[id], id, audioType));

        return audios;
    }
}