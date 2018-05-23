using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AssetLoader
{
    protected AssetManager _assetManager;

    /// <summary>
    /// Constructs an AssetLoader.
    /// </summary>
    /// <param name="assetManager">The AssetManager that created this AssetLoader.</param>
    public AssetLoader(AssetManager assetManager)
    {
        _assetManager = assetManager;
    }

    /// <summary>
    /// Loads all of the Assets for a given AssetBatch
    /// </summary>
    /// <param name="assetBatch">The AssetBatch for which the Assets will be loaded.</param>
    /// <param name="assetManager">The AssetManager that will be passed to the Assets.</param>
    /// <returns>A list of Assets.</returns>
    public List<Asset> LoadAsset(AssetBatch assetBatch, AssetManager assetManager)
    {
        var assets = new List<Asset>();

        foreach (var def in assetBatch.AssetDefinitions)
        {
            var asset = CreateAsset(def, assetBatch, assetManager);

            if (asset != null)
            {
                assets.Add(asset);
            }
        }

        return assets;
    }

    /// <summary>
    /// Creates and Asset based off of an AssetDefinition.
    /// </summary>
    /// <param name="definition">The AssetDefinition used to create the Asset.</param>
    /// <param name="assetBatch">The AssetBatch that the new Asset will belong to.</param>
    /// <param name="assetManager">That AssetManager that will be passed to the Asset.</param>
    /// <returns>An Asset or null.</returns>
    private Asset CreateAsset(AssetDefinition definition, AssetBatch assetBatch, AssetManager assetManager)
    {
        Asset asset = null;

        switch (definition.AssetType.ToLower())
        {
            case ("texture2d"):
                {
                    var texture = assetBatch.ContentManager.Load<Texture2D>(definition.FilePath);
                    asset = new Texture2DAsset(definition.Id, assetManager, definition.BatchIds, texture);
                }
                break;
            case ("spritefont"):
                {
                    var spriteFont = assetBatch.ContentManager.Load<SpriteFont>(definition.FilePath);
                    asset = new SpriteFontAsset(definition.Id, assetManager, definition.BatchIds, spriteFont);
                }
                break;
        }

        if (asset != null)
        {
            assetBatch.AddAsset(asset);
        }
        else
        {
            _assetManager.Logger.Write($"Failed to loaded Asset.Id={definition.Id} of type {definition.AssetType}.", LogLevel.ERROR);
        }

        return asset;
    }

    /// <summary>
    /// Loads an AssetBatch's AssetDefinitions.
    /// </summary>
    /// <param name="assetBatch">The AssetBatch for which the AssetDefinitions will be loaded.</param>
    /// <returns>A list of AssetDefinitions.</returns>
    public List<AssetDefinition> LoadDefinition(AssetBatch assetBatch)
    {
        var assetDefinitions = File.ReadAllLines(assetBatch.AssetDefinitionsFilePath)
                                   .Where(l => l.Length > 0)
                                   .Select(l => ParseDefinition(l, assetBatch));
        return new List<AssetDefinition>(assetDefinitions);
    }

    /// <summary>
    /// Parses a string into an AssetDefinition.
    /// </summary>
    /// <param name="line">The string that will be parsed.</param>
    /// <param name="assetBatch">The batch that the new AssetDefinition will belong to.</param>
    /// <returns>An AssetDefinition or null.</returns>
    private AssetDefinition ParseDefinition(string line, AssetBatch assetBatch)
    {
        var errorList = new List<string>();

        var filePath = "";
        var assetId = "";
        var assetType = "";
        var batchIds = new List<string>();

        var arguments = line.Split(';');
        var type = arguments[0];
        var parameters = arguments.Where(l => l.Contains("="));

        foreach (var p in parameters)
        {
            var pair = p.Split('=');
            switch (pair[0].ToLower()) {
                case ("filepath"): { filePath = pair[1]; }
                    break;
                case ("assetid"):                    { assetId = pair[1]; }
                    break;
                case ("assettype"):                    { assetType = pair[1]; }
                    break;
                case ("batchids"):
                    {
                        var batches = pair[1].Split(',');
                        batchIds.AddRange(batches);
                    }
                    break;
            }
        }

        if (filePath == "") errorList.Add("Failed to parse filePath.");
        if (assetId == "") errorList.Add("Failed to parse assetId.");
        if (assetType == "") errorList.Add("Failed to parse assetType.");
        if (errorList.Count > 0)
        {
            foreach (var err in errorList)
            {
                _assetManager.Logger.Write(err, LogLevel.ERROR);
            }
            return null;
        }

        var definition = new AssetDefinition(filePath, assetId, assetType, batchIds);
        assetBatch.AddAssetDefinition(definition);
        return definition;
    }
}