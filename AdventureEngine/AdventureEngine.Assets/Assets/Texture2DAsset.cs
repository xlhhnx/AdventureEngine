using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

public class Texture2DAsset : Asset
{
    /// <summary>
    /// Gets the Texture2D of this Asset.
    /// </summary>
    public Texture2D Texture { get { return _texture; } }

    public override bool Loaded
    {
        get { return _loaded; }
        set { _loaded = value; }
    }

    protected bool _loaded;
    protected Texture2D _texture;

    /// <summary>
    /// Construct a Texture2DAsset.
    /// </summary>
    /// <param name="assetId">The unique Id of the Asset.</param>
    /// <param name="texture">The Texture2D that this Asset will contain.</param>
    public Texture2DAsset(string assetId, Texture2D texture) 
        : base(assetId)
    {
        _texture = texture;
        _loaded = texture != null;
    }
}