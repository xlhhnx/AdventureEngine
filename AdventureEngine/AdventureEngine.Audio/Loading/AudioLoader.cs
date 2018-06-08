using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;

public class AudioLoader
{
    public Sound LoadSound(string id, AudioAsset audioAsset)
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

    public Song LoadSong(string id, AudioAsset audioAsset)
    {
        return new Song(id, audioAsset);
    }
}