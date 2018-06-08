using System;
using NAudio.Wave;
using System.Runtime.InteropServices;
using NAudio.Wave.SampleProviders;

public class AudioPlayer : IAudioPlayer
{
    public TimeSpan CurrentTime
    {
        get { return _songStream.CurrentTime; }
        set { _songStream.CurrentTime = value; }
    }

    public TimeSpan EndTime { get { return _songStream.TotalTime; } }

    // TODO: Add volume management
    protected WaveStream _songStream;
    protected WaveOut _songOutput;
    protected WaveOut _soundOutput;
    protected MixingSampleProvider _mixer;


    public AudioPlayer(int sampleRate = 44100, int channels = 2)
    {
        _songOutput = new WaveOut();
        _soundOutput = new WaveOut();
        _mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channels));
        _soundOutput.Init(_mixer);
        _soundOutput.Play();
    }

    public void PlaySound(IAudio sound)
    {
        if (sound is Sound)
        {
            var s = sound as Sound;
            var input = s.CreateSampleProvider();
            var correctChannelInput = ConvertToCorrectChannelCount(input);
            _mixer.AddMixerInput(correctChannelInput);
        }
    }

    public void Play()
    {
        if (_songOutput != null && _songOutput.PlaybackState != PlaybackState.Playing)
        {
            _songOutput.Play();
        }
    }

    public void Pause()
    {
        if (_songOutput != null && _songOutput.PlaybackState == PlaybackState.Playing)
        {
            _songOutput.Pause();
        }
    }

    public void Stop()
    {
        if (_songOutput != null && _songOutput.PlaybackState != PlaybackState.Stopped)
        {
            _songOutput.Stop();
        }
    }

    public void NewSong(IAudio song)
    {
        if (song is Song)
        {
            var s = song as Song;
            Stop();
            _songStream = s.CreateWaveStream();
            _songOutput.Init(_songStream);
        }
    }

    public void Dispose()
    {
        _soundOutput.Stop();
        _soundOutput.Dispose();
        _songOutput.Dispose();
    }

    private ISampleProvider ConvertToCorrectChannelCount(ISampleProvider input)
    {
        if (input.WaveFormat.Channels == 1 && _mixer.WaveFormat.Channels == 2)
        {
            return new MonoToStereoSampleProvider(input);
        }
        return input;
    }
}