using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

// File line: [type],[id],[parameter]=[value],...

public interface IAssetLoader
{
    /// <summary>
    /// Loads a single asset batch.
    /// </summary>
    /// <param name="filePath">The path to the file that contains the batch to load.</param>
    /// <param name="id">The id of the batch to load.</param>
    /// <returns>An asset batch or null.</returns>
    AssetBatch LoadBatch(string filePath, string id, IServiceProvider serviceProvider);

    /// <summary>
    /// Loads all of the asset batches in a file.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    /// <returns>A list of asset batches.</returns>
    List<AssetBatch> LoadBatches(string filePath, IServiceProvider serviceProvider);

    /// <summary>
    /// Loads a single asset.
    /// </summary>
    /// <param name="filePath">The path to the file that contains the asset to load.</param>
    /// <param name="id">The id of the asset to load.</param>
    /// <param name="contentManager">The content manager to be used to load the asset.</param>
    /// <returns>An asset or null.</returns>
    Asset LoadAsset(string filePath, string id, ContentManager contentManager);

    /// <summary>
    /// Loads all of the assets in a file.
    /// </summary>
    /// <param name="filePath">The path to the file that contains the assets to load.</param>
    /// <param name="contentManager">The content manager to be used to load the asset.</param>
    /// <returns>A list of assets.</returns>
    List<Asset> LoadAssets(string filePath, ContentManager contentManager);
}