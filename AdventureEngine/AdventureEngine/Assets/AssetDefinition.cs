using System;
using System.Collections.Generic;

public class AssetDefinition
{
    /* Properties */
    public string FilePath { get { return _filePath; } }
    public string AssetId { get { return _assetId; } }
    public string AssetType { get { return _assetType; } }
    public List<string> BatchIds { get { return _batchIds; } }

    /* Variables */
    protected string _filePath;
    protected string _assetId;
    protected string _assetType;
    protected List<string> _batchIds;

    /* Methods */
    public AssetDefinition(string filePath, string assetId, string assetType, List<string> batchIds)
    {
        _filePath = filePath;
        _assetId = assetId;
        _assetType = assetType;
        _batchIds = batchIds;
    }

    /// <summary>
    /// Builds an AssetDefinition using a string input.
    /// </summary>
    /// <param name="line">A string in the format 'FilePath=[string];AssetId=[string];AssetType=[string];BatchIds=[string],...,[string]'</param>
    /// <returns>AssetDefinition if the format is correct, otherwise null.</returns>
    public static AssetDefinition Load(string line)
    {
        var filePath = "";
        var assetId = "";
        var assetType = "";
        var batchIds = new List<string>();

        var split = line.Split(';');
        foreach (string s in split)
        {
            var pair = s.Trim().Split('=');
            switch (pair[0].ToUpper()) {
                case ("FILEPATH"): { filePath = pair[1]; }
                    break;
                case ("ASSETID"): { assetId = pair[1]; }
                    break;
                case ("ASSETTYPE"): { assetType = pair[1]; }
                    break;
                case ("BATCHIDS"):
                    {
                        var batches = pair[1].Split(',');
                        batchIds.AddRange(batches);
                    }
                    break;
            }
        }

        if (filePath != "" && assetId != "" && assetType != "" && batchIds.Count > 0)
        {
            return new AssetDefinition(filePath, assetId, assetType, batchIds);
        }
        else
        {
            LogManager.Write(1, $"Could not create ASSET_DEFINITION because the definition line is missing one or more fields. line='{line}'");
            return null;
        }
    }
}