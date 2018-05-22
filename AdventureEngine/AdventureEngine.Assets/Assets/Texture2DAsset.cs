using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class Texture2DAsset : Asset
{
    /// <summary>
    /// Gets the Texture2D of this Asset.
    /// </summary>
    public Texture2D Texture { get { return _texture; } }

    protected Texture2D _texture;

    /// <summary>
    /// Construct a Texture2DAsset.
    /// </summary>
    /// <param name="assetId">The unique Id of the Asset.</param>
    /// <param name="assetManager">The AssetManager that initially loaded the Asset.</param>
    /// <param name="batchIds">The list of BatchIds corresponding to batches that this Asset belongs to.</param>
    /// <param name="texture">The Texture2D that this Asset will contain.</param>
    public Texture2DAsset(string assetId, AssetManager assetManager, List<string> batchIds, Texture2D texture) 
        : base(assetId, assetManager, batchIds)
    {
        _texture = texture;
    }
}