using AdventureEngine.AssetManagement.Assets;
using NAudio.Wave;

namespace AdventureEngine.AudioManagement.Assets
{
    public class Song : BaseAudio
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
}