using AdventureEngine.AssetManagement.Assets;

namespace AdventureEngine.AudioManagement.Assets
{
    public abstract class BaseAudio : IAudio
    {
        public string Id { get { return _id; } }
        public bool Loaded { get { return _audioAsset.Loaded; } }
        public AudioAsset AudioAsset { get { return _audioAsset; } }

        protected string _id;
        protected AudioAsset _audioAsset;

        public BaseAudio(string id, AudioAsset audioAsset)
        {
            _id = id;
            _audioAsset = audioAsset;
        }

        public void Unload() { /* No op */ }
    }
}