using System;
using System.Collections.Generic;
using System.Linq;

public class AssetManager : IAssetManager
{
    public IAssetLoader Loader
    {
        get { return _loader; }
        set { _loader = value; }
    }

    public IServiceProvider DefaultServiceProvider { get { return _defaultServiceProvider; } }
    public AudioAsset DefaultAudioAsset { get { return _defaultAudio; } }
    public Texture2DAsset DefaultTexture2DAsset { get { return _defaultTexture2DAsset; } }
    public SpriteFontAsset DefaultSpriteFontAsset { get { return _defaultSpriteFontAsset; } }


    protected IServiceProvider _defaultServiceProvider;
    protected IAssetLoader _loader;
    protected AudioAsset _defaultAudio;
    protected Texture2DAsset _defaultTexture2DAsset;
    protected SpriteFontAsset _defaultSpriteFontAsset;
    protected Dictionary<string, AudioAsset> _audioAssets;
    protected Dictionary<string, SpriteFontAsset> _spriteFontAssets;
    protected Dictionary<string, Texture2DAsset> _texture2DAssets;
    protected Dictionary<string, IAssetBatch> _assetBatches;


    public AssetManager(IServiceProvider defaultServiceProvider, IAssetLoader loader, AudioAsset defaultAudio, Texture2DAsset defaultTexture2DAsset, SpriteFontAsset defaultSpriteFontAsset)
    {
        _loader = loader;
        _defaultAudio = defaultAudio;
        _defaultTexture2DAsset = defaultTexture2DAsset;
        _defaultSpriteFontAsset = defaultSpriteFontAsset;
        _audioAssets = new Dictionary<string, AudioAsset>();
        _spriteFontAssets = new Dictionary<string, SpriteFontAsset>();
        _texture2DAssets = new Dictionary<string, Texture2DAsset>();
        _assetBatches = new Dictionary<string, IAssetBatch>();
    }

    public void LoadAsset(string filePath, string id, string batchId, AssetType assetType)
    {
        var batch = GetAssetBatch(batchId);
        if (batch == null) return;

        LoadAsset(filePath, id, batch, assetType);
    }

    public void LoadAsset(string filePath, string id, IAssetBatch batch, AssetType assetType)
    {
        switch (assetType)
        {
            case (AssetType.AudioAsset):
                {
                        var audio = _loader.LoadAudioAsset(filePath, id, batch.Content);
                        AddAsset(audio, true);
                }
                break;
            case (AssetType.SpriteFontAsset):
                {
                        var spriteFontAsset = _loader.LoadSpriteFontAsset(filePath, id, batch.Content);
                        AddAsset(spriteFontAsset, true);
                }
                break;
            case (AssetType.Texture2DAsset):
                {
                        var texture2DAsset = _loader.LoadTexture2DAsset(filePath, id, batch.Content);
                        AddAsset(texture2DAsset, true);
                }
                break;
        }
    }

    public void LoadAsset(string filePath, string id, string batchId)
    {
        var batch = GetAssetBatch(batchId);
        if (batch == null) return;

        LoadAsset(filePath, id, batch);
    }

    public void LoadAsset(string filePath, string id, IAssetBatch batch)
    {
        var asset = _loader.LoadAsset(filePath, id, batch.Content);

        if (asset is AudioAsset) AddAsset(asset as AudioAsset, true);
        else if (asset is SpriteFontAsset) AddAsset(asset as SpriteFontAsset, true);
        else if (asset is Texture2DAsset) AddAsset(asset as Texture2DAsset, true);
    }

    public void LoadAssets(string filePath, string batchId, AssetType assetType)
    {
        var batch = GetAssetBatch(batchId);
        if (batch == null) return;

        LoadAssets(filePath, batch, assetType);
    }

    public void LoadAssets(string filePath, IAssetBatch batch, AssetType assetType)
    {
        var assets = _loader.LoadAssets(filePath, batch.Content);

        switch (assetType) {
            case (AssetType.AudioAsset):
                {
                    var audios = assets.Where(a => a is AudioAsset);
                    foreach (var a in audios) AddAsset(a, true);
                }
                break;
            case (AssetType.SpriteFontAsset):
                {
                    var spriteFonts = assets.Where(a => a is SpriteFontAsset);
                    foreach (var s in spriteFonts) AddAsset(s, true);
                }
                break;
            case (AssetType.Texture2DAsset):
                {
                    var textures = assets.Where(a => a is Texture2DAsset);
                    foreach (var t in textures) AddAsset(t, true);
                }
                break;
        }
    }

    public void LoadAssets(string filePath, string batchId)
    {
        var batch = GetAssetBatch(batchId);
        if (batch == null) return;

        LoadAssets(filePath, batch);
    }

    public void LoadAssets(string filePath, IAssetBatch batch)
    {
        var assets = _loader.LoadAssets(filePath, batch.Content);

        foreach (var a in assets) AddAsset(a, true);
    }

    public void LoadAssetBatch(string filePath, string id, IServiceProvider serviceProvider = null)
    {
        if (serviceProvider == null) serviceProvider = _defaultServiceProvider;

        var assetBatch = _loader.LoadAssetBatch(filePath, id, serviceProvider);
        AddAssetBatch(assetBatch);
    }

    public void LoadAssetBatches(string filePath, IServiceProvider serviceProvider = null)
    {
        if (serviceProvider == null) serviceProvider = _defaultServiceProvider;

        var assetBatches = _loader.LoadAssetBatches(filePath, serviceProvider);
        foreach (var ab in assetBatches) AddAssetBatch(ab);
    }

    public void LoadBatchAssets(string id)
    {
        var batch = GetAssetBatch(id);
        if (batch == null) return;

        foreach (var file in batch.FileIdDictionary.Keys)
        {
            foreach (var assetId in batch.FileIdDictionary[file]) LoadAsset(file, assetId, batch);
        }
    }

    public void LoadAllBatchAssets()
    {
        foreach (var id in _assetBatches.Keys) LoadBatchAssets(id);
    }

    public void AddAsset(IAsset asset, bool overwrite = false)
    {
        if (asset is AudioAsset) AddAsset(asset as AudioAsset, overwrite);
        else if (asset is SpriteFontAsset) AddAsset(asset as SpriteFontAsset, overwrite);
        else if (asset is Texture2DAsset) AddAsset(asset as Texture2DAsset, overwrite);
    }

    public void AddAsset(AudioAsset audioAsset, bool overwrite = false)
    {
        if (!_audioAssets.ContainsKey(audioAsset.Id)) _audioAssets.Add(audioAsset.Id, audioAsset);
        else if (overwrite) _audioAssets[audioAsset.Id] = audioAsset;
    }

    public void AddAsset(SpriteFontAsset spriteFontAsset, bool overwrite = false)
    {
        if (!_spriteFontAssets.ContainsKey(spriteFontAsset.Id)) _spriteFontAssets.Add(spriteFontAsset.Id, spriteFontAsset);
        else if (overwrite) _spriteFontAssets[spriteFontAsset.Id] = spriteFontAsset;
    }

    public void AddAsset(Texture2DAsset texture2DAsset, bool overwrite = false)
    {
        if (!_texture2DAssets.ContainsKey(texture2DAsset.Id)) _texture2DAssets.Add(texture2DAsset.Id, texture2DAsset);
        else if (overwrite) _texture2DAssets[texture2DAsset.Id] = texture2DAsset;
    }

    public void AddAssetBatch(IAssetBatch assetBatch)
    {
        if (!_assetBatches.ContainsKey(assetBatch.Id)) _assetBatches.Add(assetBatch.Id, assetBatch);
    }

    public void Recycle(AssetType assetType)
    {
        switch (assetType) {
            case (AssetType.AudioAsset): _audioAssets = new Dictionary<string, AudioAsset>(); break;
            case (AssetType.SpriteFontAsset): _texture2DAssets = new Dictionary<string, Texture2DAsset>(); break;
            case (AssetType.Texture2DAsset): _texture2DAssets = new Dictionary<string, Texture2DAsset>(); break;
        }
    }

    public void Recycle()
    {
        _audioAssets = new Dictionary<string, AudioAsset>();
        _spriteFontAssets = new Dictionary<string, SpriteFontAsset>();
        _texture2DAssets = new Dictionary<string, Texture2DAsset>();
    }

    public void UnloadAssetBatch(string id)
    {
        if (_assetBatches.ContainsKey(id))
        {
            _assetBatches[id].Unload();
            _assetBatches.Remove(id);
        }        
    }

    public void UnloadAllAssetBatches()
    {
        foreach (var id in _assetBatches.Keys) _assetBatches[id].Unload();
        _assetBatches = new Dictionary<string, IAssetBatch>();
    }

    public AudioAsset GetAudioAsset(string id)
    {
        AudioAsset audio = null;
        _audioAssets.TryGetValue(id, out audio);
        return audio;
    }

    public SpriteFontAsset GetSpriteFontAsset(string id)
    {
        SpriteFontAsset spriteFontAsset = null;
        _spriteFontAssets.TryGetValue(id, out spriteFontAsset);
        return spriteFontAsset;
    }

    public Texture2DAsset GetTexture2DAsset(string id)
    {
        Texture2DAsset texture2DAsset = null;
        _texture2DAssets.TryGetValue(id, out texture2DAsset);
        return texture2DAsset;
    }

    public IAssetBatch GetAssetBatch(string id)
    {
        IAssetBatch assetBatch = null;
        _assetBatches.TryGetValue(id, out assetBatch);
        return assetBatch;
    }

    public void ReceiveMessage(Message message)
    {
        // TODO: Handle messages
    }
}