using System.Collections.Generic;

public interface IAudioLoader
{
    Song LoadSong(AudioAsset audioAsset, string id);
    Sound LoadSound(AudioAsset audioAsset, string id);
    IAudio LoadAudio(AudioAsset audioAsset, string id, AudioType audioType);
    List<IAudio> LoadAudios(Dictionary<string, AudioAsset> idAudioAssetDictionary, AudioType audioType);
}