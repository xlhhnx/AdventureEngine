using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class AssetBatchLoader
{
    protected IServiceProvider _serviceProvider;
    protected AssetManager _assetManager;

    /// <summary>
    /// Constructs an AssetBatchLoader.
    /// </summary>
    /// <param name="serviceProvider">An IServiceProvider that will be passed to the new AssetBatch.</param>
    /// <param name="assetManager">The AssetManager that created this AssetBatchLoader.</param>
    public AssetBatchLoader(IServiceProvider serviceProvider, AssetManager assetManager)
    {
        _serviceProvider = serviceProvider;
        _assetManager = assetManager;
    }

    /// <summary>
    /// Builds an AssetBatch out of a string,
    /// </summary>
    /// <param name="definition">The string that will be parsed into an AssetBatch.</param>
    /// <returns>An AssetBatch or null.</returns>
    public AssetBatch Load(string definition)
    {
        var errorList = new List<string>();

        var batchId = "";
        var assetDefinitionsFilePath = "";
        var rootDirectory = "";

        var arguments = definition.Split(';');
        var type = arguments[0];
        var parameters = arguments.Where(l => l.Contains("="));

        if (type.ToLower() != "assetbatch")
        {
            
            return null;
        }

        foreach (var p in parameters)
        {
            var pair = p.Split('=');
            switch (pair[0].ToLower()) {
                case ("batchid"): { batchId = pair[1]; }
                    break;
                case ("assetdefinitionsfilepath"): { assetDefinitionsFilePath = pair[1]; }
                    break;
                case ("rootdirectory"): { rootDirectory = pair[1]; }
                    break;
            }
        }

        if (batchId == "") errorList.Add("Failed to parse batch Id.");
        if (assetDefinitionsFilePath == "") errorList.Add("Failed to parse AssetDefinitionsFilePath.");

        if (errorList.Count > 0)
        {
            foreach (var err in errorList)
            {
                _assetManager.Logger.Write(err, LogLevel.ERROR);
            }
            return null;
        }

        if (rootDirectory != "")
        {
            return new AssetBatch(_serviceProvider, batchId, assetDefinitionsFilePath, rootDirectory);
        }
        else
        {
            return new AssetBatch(_serviceProvider, batchId, assetDefinitionsFilePath);
        }
    }

    /// <summary>
    /// Reads thruogh a file to find a line to parse into a specific AssetBatch.
    /// </summary>
    /// <param name="assetBatchId">The Id of the AssetBatch to parse. Used to find the correct line to parse.</param>
    /// <param name="filePath">The path to the file that contains the AssetBatch definitions.</param>
    /// <returns>An AsestBtch or null.</returns>
    public AssetBatch Load(string assetBatchId, string filePath)
    {
        var assetBatchDefinition = File.ReadAllLines(filePath)
                                       .Where(l => l.Length > 0)
                                       .Where(l => l.ToLower().Contains("assetbatch;") && l.ToLower().Contains($"Id={assetBatchId.ToLower()}"))
                                       .First();
        return Load(assetBatchDefinition);
    }

    /// <summary>
    /// Reads through a file to build all of the contained AssetBatches.
    /// </summary>
    /// <param name="filePath">The path to the file that contains the AssetBatch definitions.</param>
    /// <returns>A list of all the AssetBatches contained in the file.</returns>
    public List<AssetBatch> LoadAll(string filePath)
    {
        var assetBatches = File.ReadAllLines(filePath)
                               .Where(l => l.Length > 0)
                               .Where(l => l.ToLower().Contains("assetbatch;"))
                               .Select(l => Load(l));
        return new List<AssetBatch>(assetBatches);
    }

    /// <summary>
    /// Reads through a file to find a line that definies a specific AssetBatch.
    /// </summary>
    /// <param name="assetBatchId">he Id of the AssetBatch to parse. Used to find the correct line to parse.</param>
    /// <param name="filePath">The path to the file that contains the AssetBatch definitions.</param>
    /// <returns>A string that defines an AssetBatch.</returns>
    public string LoadDefinition(string assetBatchId, string filePath)
    {
        var definition = File.ReadAllLines(filePath)
                             .Where(l => l.Length > 0)
                             .Where(l => l.ToLower().Contains("assetbatch;") && l.ToLower().Contains($"batchid={assetBatchId.ToLower()}"))
                             .First();
        return definition;
    }

    /// <summary>
    /// Reads through a file to find all lines that define an AssetBatch.
    /// </summary>
    /// <param name="filePath">The path to the file that contains the AssetBatch definitions.</param>
    /// <returns></returns>
    public Dictionary<string, string> LoadDefinition(string filePath)
    {
        var definitions = File.ReadAllLines(filePath)
                              .Where(l => l.Length > 0)
                              .Where(l => l.ToLower().Contains("assetbatch;"))
                              .ToDictionary(l => GetBatchId(l));
        return definitions;
    }

    /// <summary>
    /// Gets the batch Id from an AssetBatch definition.
    /// </summary>
    /// <param name="definition">A definition of an AssetBatch.</param>
    /// <returns>An AssetBatch Id or empty_string.</returns>
    private string GetBatchId(string definition)
    {
        var arguments = definition.Split(';');
        foreach (var arg in arguments)
        {
            var pair = arg.Split('=');
            if (pair[0].ToLower() == "batchid")
            {
                return pair[1];
            }
        }

        _assetManager.Logger.Write($"Failed to find the batch Id in definition='{definition}'", LogLevel.ERROR);
        return "";
    }
}