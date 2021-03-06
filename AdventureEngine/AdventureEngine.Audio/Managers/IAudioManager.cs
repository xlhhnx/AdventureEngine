﻿using AdventureEngine.AssetManagement.Assets;
using AdventureEngine.AudioManagement.Assets;
using AdventureEngine.AudioManagement.Players;
using AdventureEngine.Messaging;
using System.Collections.Generic;

namespace AdventureEngine.AudioManagement.Loading
{
    public interface IAudioManager : ISubscriber
    {
        IAudioPlayer Player { get; set; }
        IAudioLoader Loader { get; set; }

        void LoadAudio(AudioAsset audioAsset, string id, AudioType audioType);
        void LoadAudios(Dictionary<string, AudioAsset> idAudioAssetDictionary, AudioType audioType);
        void LoadSong(AudioAsset audioAsset, string id, AudioType audioType);
        void LoadSong(AudioAsset audioAsset, string id);
        void AddAudio(IAudio audio, bool overwrite = false);
        void AddAudio(Song song, bool overwrite = false);
        void AddAudio(Sound song, bool overwrite = false);
        Song GetSong(string id);
        Sound GetSound(string id);
    }
}