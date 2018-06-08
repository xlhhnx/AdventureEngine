﻿using System;
using NAudio.Wave;

public class AudioAsset : BaseAsset
{
    public override bool Loaded
    {
        get { return _loaded; }
    }

    public virtual WaveStream Stream { get { return _stream; } }


    protected bool _loaded;
    protected WaveStream _stream;


    public AudioAsset(string id, WaveStream stream) : base(id)
    {
        _stream = stream;
        _loaded = true;
    }

    public override void Unload()
    {
        _loaded = false;
    }
}