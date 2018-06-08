using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

public class Texture2DAsset : BaseAsset
{
    public virtual Texture2D Texture { get { return _texture; } }
    public override bool Loaded { get { return _loaded; } }


    protected bool _loaded;
    protected Texture2D _texture;


    public Texture2DAsset(string assetId, Texture2D texture) 
        : base(assetId)
    {
        _texture = texture;
        _loaded = texture != null;
    }

    public override void Unload()
    {
        _loaded = false;
    }
}