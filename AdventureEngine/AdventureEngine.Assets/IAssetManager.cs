using AdventureEngine.AssetManagement.Assets;
using AdventureEngine.AssetManagement.Loading;
using AdventureEngine.Messaging;
using System;

namespace AdventureEngine.AssetManagement
{
    public interface IAssetManager : ISubscriber
    {
        IAssetLoader Loader { get; set; }
        IServiceProvider DefaultServiceProvider { get; }
        AudioAsset DefaultAudioAsset { get; }
        Texture2DAsset DefaultTexture2DAsset { get; }
        SpriteFontAsset DefaultSpriteFontAsset { get; }

        void LoadAsset(string filePath, string id, string batchId, AssetType assetType);
        void LoadAsset(string filePath, string id, IAssetBatch batch, AssetType assetType);
        void LoadAsset(string filePath, string id, string batchId);
        void LoadAsset(string filePath, string id, IAssetBatch batch);
        void LoadAssets(string filePath, string batchId, AssetType assetType);
        void LoadAssets(string filePath, IAssetBatch batch, AssetType assetType);
        void LoadAssets(string filePath, string batchId);
        void LoadAssets(string filePath, IAssetBatch batch);
        void LoadAssetBatch(string filePath, string id, IServiceProvider serviceProvider = null);
        void LoadAssetBatches(string filePath, IServiceProvider serviceProvider = null);
        void LoadBatchAssets(string id);
        void LoadAllBatchAssets();
        void AddAsset(IAsset asset, bool overwrite = false);
        void AddAsset(AudioAsset audioAsset, bool overwrite = false);
        void AddAsset(SpriteFontAsset spriteFontAsset, bool overwrite = false);
        void AddAsset(Texture2DAsset texture2DAsset, bool overwrite = false);
        void AddAssetBatch(IAssetBatch assetBatch);
        void Recycle(AssetType assetType);
        void Recycle();
        AudioAsset GetAudioAsset(string id);
        SpriteFontAsset GetSpriteFontAsset(string id);
        Texture2DAsset GetTexture2DAsset(string id);
        IAssetBatch GetAssetBatch(string id);
    }
}