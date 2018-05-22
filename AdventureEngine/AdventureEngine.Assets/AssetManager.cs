using System;
using System.Collections.Generic;

public class AssetManager
{    
    protected IServiceProvider _serviceProvider;
    protected Dictionary<string, string> _assetBatchDefinitions;
    protected Dictionary<string, AssetBatch> _assetBatches;
    protected Dictionary<string, AssetDefinition> _assetDefinitions;
    protected Dictionary<string, Asset> _assets;

    /// <summary>
    /// Constructs an AssetManager
    /// </summary>
    /// <param name="serviceProvider">The service provider that will be used for all ContentManagers.</param>
    public AssetManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Loads all AssetBatches defined in a file.
    /// </summary>
    /// <param name="filePath">A file containing AssetBatch definitions.</param>
    /// <param name="mode">The loading mode to determine how much of the batches to load.</param>
    public void LoadAssetBatchFile(string filePath, LoadingMode mode)
    {
        var definitions = AssetBatchLoader.LoadDefinition(filePath);
        foreach (var batchId in definitions.Keys)
        {
            if (!_assetBatchDefinitions.ContainsKey(batchId))
            {
                _assetBatchDefinitions.Add(batchId, definitions[batchId]);
            }
            else
            {
                // TODO: Throw Warning
            }
        }

        if (mode == LoadingMode.Lazy)
        {
            return;
        }
        
        var assetBatches = AssetBatchLoader.LoadAll(_serviceProvider, filePath);
        foreach (var ab in assetBatches)
        {
            if (_assetBatchDefinitions.ContainsKey(ab.Id))
            {
                _assetBatches.Add(ab.Id, ab);
            }
            else
            {
                // TODO: Throw Warning
            }
        }

        if (mode == LoadingMode.Aggressive)
        {
            foreach (var ab in assetBatches)
            {
                LoadAssetDefinitions(ab.Id);
                LoadAssets(ab.Id);
            }
        }
    }

    /// <summary>
    /// Loads a single batch definied in a file.
    /// </summary>
    /// <param name="batchId">The batch Id to be loaded.</param>
    /// <param name="filePath">A file containing AssetBatch definitions.</param>
    /// <param name="mode">The loading mode to determine how much of the batch to load.</param>
    public void LoadAssetBatch(string batchId, string filePath, LoadingMode mode)
    {
        if (mode == LoadingMode.Lazy)
        {
            var definition = AssetBatchLoader.LoadDefinition(batchId, filePath);
            if (!_assetBatchDefinitions.ContainsKey(batchId))
            {
                _assetBatchDefinitions.Add(batchId, definition);
            }
            else
            {
                // TODO: Throw Warning
            }
            return;
        }

        var assetBatch = AssetBatchLoader.Load(_serviceProvider, batchId, filePath);
        if (!_assetBatches.ContainsKey(batchId))
        {
            _assetBatches.Add(batchId, assetBatch);
        }
        else
        {
            // TODO: Throw Warning
        }

        if (mode == LoadingMode.Aggressive)
        {
            LoadAssetDefinitions(batchId);
            LoadAssets(batchId);
        }
    }

    /// <summary>
    /// Loads a single AssetBatch that already has a definition loaded.
    /// </summary>
    /// <param name="batchDefinitionId">The Id of the AssetBatchDefinition that is loaded.</param>
    /// <param name="mode">The loading mode to determine how much of the batch to load.</param>
    public void LoadAssetBatch(string batchDefinitionId, LoadingMode mode)
    {
        if (ContainsBatchDefinition(batchDefinitionId))
        {
            var assetBatch = AssetBatchLoader.Load(_serviceProvider, _assetBatchDefinitions[batchDefinitionId]);
            _assetBatches.Add(assetBatch.Id, assetBatch);

        }

        if (mode == LoadingMode.Aggressive)
        {
            LoadAssetDefinitions(batchDefinitionId);
            LoadAssets(batchDefinitionId);
        }
    }

    /// <summary>
    /// Loads all AssetDefinitions for a given AssetBatch.
    /// </summary>
    /// <param name="batchId">The Id of the AssetBatch to load AssetDefinitions for.</param>
    /// <param name="loadAssetBatch">A flag that determines whether LoadAssetDefinitions will load the assetBatch if it does not exist.</param>
    public void LoadAssetDefinitions(string batchId, bool loadAssetBatch = true)
    {
        if (loadAssetBatch && _assetBatchDefinitions.ContainsKey(batchId) && !_assetBatches.ContainsKey(batchId))
        {
            var tmpAssetBatch = AssetBatchLoader.Load(_serviceProvider, _assetBatchDefinitions[batchId]);
            _assetBatches.Add(batchId, tmpAssetBatch);
        }
        else if (!loadAssetBatch && !_assetBatches.ContainsKey(batchId))
        {
            // TODO: Throw Error
            return;
        }

        var assetBatch = _assetBatches[batchId];
        var definitions = AssetLoader.LoadDefinition(assetBatch);
        foreach (var def in definitions)
        {
            if (def != null)
            {
                _assetDefinitions.Add(def.Id, def);
            }
        }
    }

    /// <summary>
    /// Loads all Assets for a give AssetBatch.
    /// </summary>
    /// <param name="batchId">The Id of the AssetBatch to load Assets for.</param>
    /// <param name="loadDefinitions">A flag that determines whether LoadAssets will load the AssetDefinitions if they do not exist.</param>
    public void LoadAssets(string batchId, bool loadDefinitions = true)
    {
        if (loadDefinitions && (!_assetBatches.ContainsKey(batchId) || !_assetBatches[batchId].Defined))
        {
            LoadAssetDefinitions(batchId);
        }
        else if (!_assetBatches.ContainsKey(batchId) || !_assetBatches[batchId].Defined)
        {
            // TODO: Throw Error
            return;
        }

        var assetBatch = _assetBatches[batchId];
        var assets = AssetLoader.LoadAsset(assetBatch, this);
        foreach (var a in assets)
        {
            if (a != null)
            {
                _assets.Add(a.Id, a);
            }
        }

    }

    /// <summary>
    /// Loads an AssetBatch that contains an Asset with the supplied Id.
    /// </summary>
    /// <param name="assetId">The Id of the Asset to be loaded.</param>
    public void LoadAsset(string assetId)
    {
        if (ContainsDefinition(assetId) || ContainsAsset(assetId))
        {
            var batchDefinitionId = "";

            var definition = _assetDefinitions[assetId];
            foreach (var id in definition.BatchIds)
            {
                if (_assetBatches.ContainsKey(id))
                {
                    if (!_assetBatches[id].Loaded)
                    {
                        LoadAssets(id);
                    }
                    break;
                }

                if (batchDefinitionId != "" && _assetBatchDefinitions.ContainsKey(id))
                {
                    batchDefinitionId = id;
                }
            }

            if (batchDefinitionId != "")
            {
                LoadAssetBatch(batchDefinitionId, LoadingMode.Aggressive);
            }
            else
            {
                // TODO: Throw Error
            }
        }
        else
        {
            // TODO: Throw Error
        }
    }

    /// <summary>
    /// Checks to see if the supplied Id exists in the AssetBatchDefinitionDictionary.
    /// </summary>
    /// <param name="batchId">The Id to check for in the dictionary.</param>
    /// <returns>A boolean representing whether the Id was found.</returns>
    public bool ContainsBatchDefinition(string batchDefinitionId)
    {
        return _assetBatchDefinitions.ContainsKey(batchDefinitionId);
    }

    /// <summary>
    /// Checks to see if the supplied Id exists in the AssetBatchDictionary.
    /// </summary>
    /// <param name="batchId">The Id to check for in the dictionary.</param>
    /// <returns>A boolean representing whether the Id was found.</returns>
    public bool ContainsBatch(string batchId)
    {
        return _assetBatches.ContainsKey(batchId);
    }

    /// <summary>
    /// Checks to see if the supplied Id exists in the AssetDefinitionDictionary.
    /// </summary>
    /// <param name="assetId">The Id to check for in the dictionary.</param>
    /// <returns>A boolean representing whether the Id was found.</returns>
    public bool ContainsDefinition(string assetId)
    {
        return _assetDefinitions.ContainsKey(assetId);
    }

    /// <summary>
    /// Checks to see if the supplied Id exists in the AssetDictionary.
    /// </summary>
    /// <param name="assetId">The Id to check for in the dictionary.</param>
    /// <returns>A boolean representing whether the Id was found.</returns>
    public bool ContainsAsset(string assetId)
    {
        return _assets.ContainsKey(assetId);
    }

    /// <summary>
    /// Gets an AssetBatch from the AssetBatchDictionary if it exists.
    /// </summary>
    /// <param name="batchId">The Id of the AssetBatch to get.</param>
    /// <returns>An AssetBatch or null.</returns>
    public AssetBatch GetBatch(string batchId)
    {
        if (ContainsBatch(batchId))
        {
            return _assetBatches[batchId];
        }
        else
        {
            // TODO: Throw Error
            return null;
        }
    }

    /// <summary>
    /// Gets an AssetDefinition from the AssetDefinitionDictionary if it exists.
    /// </summary>
    /// <param name="assetId">The Id of the AssetDefinition to get.</param>
    /// <returns>An AssetDefinition or null.</returns>
    public AssetDefinition GetDefinition(string assetId)
    {
        if (ContainsDefinition(assetId))
        {
            return _assetDefinitions[assetId];
        }
        else
        {
            // TODO: Throw Error
            return null;
        }
    }

    /// <summary>
    /// Gets an Asset from the AssetDictionary if it exists.
    /// </summary>
    /// <param name="assetId">The Id of the Asset to get.</param>
    /// <returns>An Asset or null.</returns>
    public Asset GetAsset(string assetId)
    {
        if (ContainsAsset(assetId))
        {
            return _assets[assetId];
        }
        else
        {
            // TODO: Throw Error
            return null;
        }
    }
}