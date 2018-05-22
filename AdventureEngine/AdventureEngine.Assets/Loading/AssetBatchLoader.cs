using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class AssetBatchLoader
{
    /// <summary>
    /// Builds an AssetBatch out of a string,
    /// </summary>
    /// <param name="serviceProvider">An IServiceProvider that will be passed to the new AssetBatch.</param>
    /// <param name="definition">The string that will be parsed into an AssetBatch.</param>
    /// <returns>An AssetBatch or null.</returns>
    public static AssetBatch Load(IServiceProvider serviceProvider, string definition)
    {
        var batchId = "";
        var assetDefinitionsFilePath = "";
        var rootDirectory = "";

        var arguments = definition.Split(';');
        var type = arguments[0];
        var parameters = arguments.Where(l => l.Contains("="));

        if (type.ToLower() == "assetbatch")
        {
            // TODO: Throw Error
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

        if (batchId == "" || assetDefinitionsFilePath == "")
        {
            // TODO: Throw Error
            return null;
        }

        if (rootDirectory != "")
        {
            return new AssetBatch(serviceProvider, batchId, assetDefinitionsFilePath, rootDirectory);
        }
        else
        {
            return new AssetBatch(serviceProvider, batchId, assetDefinitionsFilePath);
        }
    }

    /// <summary>
    /// Reads thruogh a file to find a line to parse into a specific AssetBatch.
    /// </summary>
    /// <param name="serviceProvider">An IServiceProvider that will be passed to the new AssetBatch.</param>
    /// <param name="assetBatchId">The Id of the AssetBatch to parse. Used to find the correct line to parse.</param>
    /// <param name="filePath">The path to the file that contains the AssetBatch definitions.</param>
    /// <returns>An AsestBtch or null.</returns>
    public static AssetBatch Load(IServiceProvider serviceProvider, string assetBatchId, string filePath)
    {
        var assetBatchDefinition = File.ReadAllLines(filePath)
                                       .Where(l => l.Length > 0)
                                       .Where(l => l.ToLower().Contains("assetbatch;") && l.ToLower().Contains($"Id={assetBatchId.ToLower()}"))
                                       .First();
        return Load(serviceProvider, assetBatchDefinition);
    }

    /// <summary>
    /// Reads through a file to build all of the contained AssetBatches.
    /// </summary>
    /// <param name="serviceProvider">An IServiceProvider that will be passed to the new AssetBatch.</param>
    /// <param name="filePath">The path to the file that contains the AssetBatch definitions.</param>
    /// <returns>A list of all the AssetBatches contained in the file.</returns>
    public static List<AssetBatch> LoadAll(IServiceProvider serviceProvider, string filePath)
    {
        var assetBatches = File.ReadAllLines(filePath)
                               .Where(l => l.Length > 0)
                               .Where(l => l.ToLower().Contains("assetbatch;"))
                               .Select(l => Load(serviceProvider, l));
        return new List<AssetBatch>(assetBatches);
    }

    /// <summary>
    /// Reads through a file to find a line that definies a specific AssetBatch.
    /// </summary>
    /// <param name="assetBatchId">he Id of the AssetBatch to parse. Used to find the correct line to parse.</param>
    /// <param name="filePath">The path to the file that contains the AssetBatch definitions.</param>
    /// <returns>A string that defines an AssetBatch.</returns>
    public static string LoadDefinition(string assetBatchId, string filePath)
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
    public static Dictionary<string, string> LoadDefinition(string filePath)
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
    private static string GetBatchId(string definition)
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

        // TODO: Throw Error
        return "";
    }
}