using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

public class SpriteFontAsset : Asset
{
    /// <summary>
    /// Gets the SpriteFont of this Asset.
    /// </summary>
    public SpriteFont SpriteFont { get { return _spriteFont; } }

    public override bool Loaded
    {
        get { return _loaded; }
        set { _loaded = value; }
    }

    protected bool _loaded;
    protected SpriteFont _spriteFont;

    /// <summary>
    /// Constructs a SpriteFontAsset.
    /// </summary>
    /// <param name="assetId">The unique Id of this Asset.</param>
    /// <param name="spriteFont">The SpriteFont that this Asset contains.</param>
    public SpriteFontAsset(string assetId, SpriteFont spriteFont)
        : base(assetId)
    {
        _spriteFont = spriteFont;
        _loaded = _spriteFont != null;
    }
}