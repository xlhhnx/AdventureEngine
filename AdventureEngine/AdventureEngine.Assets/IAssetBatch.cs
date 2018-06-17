using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace AdventureEngine.AssetManagement
{
    public interface IAssetBatch : IAsset
    {
        ContentManager Content { get; }
        Dictionary<string, List<string>> FileIdDictionary { get; set; }
        List<IAsset> Assets { get; set; }

        void AddAssetDefinition(string filePath, string assetId);
        void AddAsset(IAsset asset);
    }
}