using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

// File line: [type],[id],[parameter]=[value],...

public interface IAssetLoader
{
    AudioAsset LoadAudioAsset(string filePath, string id, ContentManager contentManager);
    SpriteFontAsset LoadSpriteFontAsset(string filePath, string id, ContentManager contentManager);
    Texture2DAsset LoadTexture2DAsset(string filePath, string id, ContentManager contentManager);
    IAsset LoadAsset(string filePath, string id, ContentManager contentManager);
    List<IAsset> LoadAssets(string filePath, ContentManager contentManager);
    BaseAssetBatch LoadAssetBatch(string filePath, string id, IServiceProvider serviceProvider);
    List<BaseAssetBatch> LoadAssetBatches(string filePath, IServiceProvider serviceProvider);
    void StageFile(string filePath, bool overwrite = false);
    void UnstageFile(string filePath);
}