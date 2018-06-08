using System;

public interface IAudioPlayer : IDisposable
{
    TimeSpan CurrentTime { get; set; }
    TimeSpan EndTime { get; }

    void PlaySound(IAudio sound);
    void NewSong(IAudio song);
    void Play();
    void Pause();
    void Stop();
}