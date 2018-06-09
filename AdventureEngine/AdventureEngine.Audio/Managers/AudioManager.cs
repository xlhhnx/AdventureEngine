using System.Collections.Generic;

public class AudioManager
{
    public IAudioPlayer Player
    {
        get { return _player; }
        set { _player = value; }
    }

    public IAudioLoader Loader
    {
        get { return _loader; }
        set { _loader = value; }
    }


    protected IAudioLoader _loader;
    protected IAudioPlayer _player;
    protected Dictionary<string, Sound> _soundDictionary;
    protected Dictionary<string, Song> _songDictionray;


    public AudioManager(AssetManager assetManager)
    {
        _loader = new AudioLoader(assetManager);
        _player = new AudioPlayer();
        _soundDictionary = new Dictionary<string, Sound>();
        _songDictionray = new Dictionary<string, Song>();
    }

    public void LoadAudio(AudioAsset audioAsset, string id, AudioType audioType)
    {
        switch (audioType)
        {
            case (AudioType.Song):
                {
                    var song = _loader.LoadSong(audioAsset, id);
                    AddAudio(song, true);
                }
                break;
            case (AudioType.Sound):
                {
                    var sound = _loader.LoadSound(audioAsset, id);
                    AddAudio(sound, true);
                }
                break;
        }
    }

    public void LoadAudios(Dictionary<string, AudioAsset> idAudioAssetDictionary, AudioType audioType)
    {
        var audios = _loader.LoadAudios(idAudioAssetDictionary, audioType);
        foreach (var a in audios) AddAudio(a, true);
    }

    public void AddAudio(IAudio audio, bool overwrite = false)
    {
        if (audio is Song) AddAudio(audio as Song, overwrite);
        else if (audio is Sound) AddAudio(audio as Sound, overwrite);
    }

    public void AddAudio(Song song, bool overwrite = false)
    {
        if (!_songDictionray.ContainsKey(song.Id)) _songDictionray.Add(song.Id, song);
        else if (overwrite) _songDictionray[song.Id] = song;
    }

    public void AddAudio(Sound sound, bool overwrite = false)
    {
        if (!_soundDictionary.ContainsKey(sound.Id)) _soundDictionary.Add(sound.Id, sound);
        else if (overwrite) _soundDictionary[sound.Id] = sound;
    }

    public Song GetSong(string id)
    {
        if (_songDictionray.ContainsKey(id)) return _songDictionray[id];
        else return null;
    }

    public Sound GetSound(string id)
    {
        if (_soundDictionary.ContainsKey(id)) return _soundDictionary[id];
        else return null;
    }

    public void ReceiveMessage(Message message)
    {
        // TODO: Handle messages
    }
}