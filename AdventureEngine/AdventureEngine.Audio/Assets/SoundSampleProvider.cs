using System;
using NAudio.Wave;

namespace AdventureEngine.AudioManagement.Assets
{
    public class SoundSampleProvider : ISampleProvider
    {
        public WaveFormat WaveFormat { get { return _sound.WaveFormat; } }

        protected Sound _sound;
        protected long _position;

        public SoundSampleProvider(Sound sound)
        {
            _sound = sound;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            var availableSamples = _sound.AudioData.Length - _position;
            var samplesToCopy = Math.Min(availableSamples, count);
            Array.Copy(_sound.AudioData, _position, buffer, offset, samplesToCopy);
            _position += samplesToCopy;
            return (int)samplesToCopy;
        }
    }
}