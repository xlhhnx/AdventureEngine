using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class SpriteFontAsset : Asset
{
    /// <summary>
    /// Gets the SpriteFont of this Asset.
    /// </summary>
    public SpriteFont SpriteFont { get { return _spriteFont; } }

    protected SpriteFont _spriteFont;

    /// <summary>
    /// Constructs a SpriteFontAsset.
    /// </summary>
    /// <param name="assetId">The unique Id of this Asset.</param>
    /// <param name="assetManager">The AssetManager that initially loaded this asset.</param>
    /// <param name="batchIds">The list of AssetBatched that this asset belongs to.</param>
    /// <param name="spriteFont">The SpriteFont that this Asset contains.</param>
    public SpriteFontAsset(string assetId, AssetManager assetManager, List<string> batchIds, SpriteFont spriteFont)
        : base(assetId, assetManager, batchIds)
    {
        _spriteFont = spriteFont;
    }
}