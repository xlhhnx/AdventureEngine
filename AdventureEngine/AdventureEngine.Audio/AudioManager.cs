using System.Collections.Generic;

public class AudioManager
{
    public AudioPlayer Player
    {
        get { return _audioPlayer; }
        set { _audioPlayer = value; }
    }

    protected AudioPlayer _audioPlayer;
    protected Dictionary<string, Sound> _soundDictionary;
    protected Dictionary<string, Song> _songDictionray;

    public AudioManager()
    {
        _audioPlayer = new AudioPlayer();
        _soundDictionary = new Dictionary<string, Sound>();
        _songDictionray = new Dictionary<string, Song>();
    }

    public void AddSong(Song song, bool overwrite = false)
    {
        if (!_songDictionray.ContainsKey(song.Id))
        {
            _songDictionray.Add(song.Id, song);
        }
        else if (overwrite)
        {
            _songDictionray[song.Id] = song;
        }

    }

    public void AddSound(Sound sound, bool overwrite = false)
    {
        if (!_soundDictionary.ContainsKey(sound.Id))
        {
            _soundDictionary.Add(sound.Id, sound);
        }
        else if (overwrite)
        {
            _soundDictionary[sound.Id] = sound;
        }
    }

    public Song GetSong(string id)
    {
        if (_songDictionray.ContainsKey(id))
        {
            return _songDictionray[id];
        }
        else
        {
            return null;
        }
    }

    public Sound GetSound(string id)
    {
        if (_soundDictionary.ContainsKey(id))
        {
            return _soundDictionary[id];
        }
        else
        {
            return null;
        }
    }
}