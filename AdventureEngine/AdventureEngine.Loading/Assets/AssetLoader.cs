using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

public class AssetLoader : IAssetLoader
{
    public Asset LoadAsset(string filePath, string id, ContentManager contentManager)
    {
        var asset = File.ReadAllLines(filePath).Where(l => l.Length > 0)
                                               .Where(l => l.ToLower().StartsWith("asset"))
                                               .Where(l => l.ToLower().Contains(id))
                                               .Select(l => ParseAsset(l, contentManager))
                                               .FirstOrDefault();
        return asset;
    }

    public List<Asset> LoadAssets(string filePath, ContentManager contentManager)
    {
        var assets = File.ReadAllLines(filePath).Where(l => l.Length > 0)
                                                .Where(l => l.ToLower().StartsWith("asset"))
                                                .Select(l => ParseAsset(l, contentManager))
                                                .ToList();
        return assets;
    }

    public AssetBatch LoadBatch(string filePath, string id, IServiceProvider serviceProvider)
    {
        var batch = File.ReadAllLines(filePath).Where(l => l.Length > 0)
                                               .Where(l => l.ToLower().StartsWith("assetbatch"))
                                               .Where(l => l.ToLower().Contains(id))
                                               .Select(l => ParseAssetBatch(l, serviceProvider))
                                               .FirstOrDefault();
        return batch;
    }

    public List<AssetBatch> LoadBatches(string filePath, IServiceProvider serviceProvider)
    {
        var batch = File.ReadAllLines(filePath).Where(l => l.Length > 0)
                                                  .Where(l => l.ToLower().StartsWith("assetbatch"))
                                                  .Select(l => ParseAssetBatch(l, serviceProvider))
                                                  .ToList();
        return batch;
    }

    /// <summary>
    /// Parses a string into an asset.
    /// </summary>
    /// <param name="assetDefinition">The string definition of the asset.</param>
    /// <param name="contentManager">The content manager that will load the asset.</param>
    /// <returns>An asset or null.</returns>
    private Asset ParseAsset(string assetDefinition, ContentManager contentManager)
    {
        Asset asset = null;

        var arguments = assetDefinition.Split(';');

        // If the string provided is not an asset definition return null
        if (arguments[0].Trim().ToLower() != "asset") return null;

        var id = arguments[1];
        var parameters = arguments.Where(a => a.Contains('='));
        
        var type = "";
        var filePath = "";

        foreach (var p in parameters)
        {
            var pair = p.Split('=');

            switch (pair[0].Trim().ToLower())
            {
                case ("type"): { type = pair[1].Trim().ToLower(); } break;
                case ("filepath"): { filePath = pair[1].Trim().ToLower(); } break;
            }
        }

        switch (type.ToLower())
        {
            case ("texture2d"):
                {
                    var texture = contentManager.Load<Texture2D>(filePath);
                    asset = new Texture2DAsset(id, texture);
                }
                break;
            case ("spritefont"):
                {
                    var spriteFont = contentManager.Load<SpriteFont>(filePath);
                    asset = new SpriteFontAsset(id, spriteFont);
                }
                break;
        }

        return asset;
    }

    /// <summary>
    /// Parses a string into an asset batch.
    /// </summary>
    /// <param name="assetBatchDefinition">The string definition of the asset batch.</param>
    /// <param name="serviceProvider">THe service provided that will be passed to the batch.</param>
    /// <returns>An asset batch or null.</returns>
    private AssetBatch ParseAssetBatch(string assetBatchDefinition, IServiceProvider serviceProvider)
    {
        var arguments = assetBatchDefinition.Split(';');

        // If the string provided is not an asset batch definition return null
        if (arguments[0].Trim().ToLower() != "assetbatch") return null;

        var id = arguments[1];
        var parameters = arguments.Where(a => a.Contains('='));

        var fileIdDict = new Dictionary<string, List<string>>();

        foreach (var p in parameters)
        {
            var pair = p.Split('=');
            var ids = pair[1].Trim()
                             .Trim('{','}')
                             .Split(',')
                             .ToList();
            fileIdDict.Add(pair[0], ids);
        }

        var batch = new AssetBatch(serviceProvider, id);
        batch.FileIdDictionary = fileIdDict;

        return batch;
    }
}