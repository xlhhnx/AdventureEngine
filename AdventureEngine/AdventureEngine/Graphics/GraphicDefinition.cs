using System;
using System.Collections.Generic;

public class GraphicDefinition
{
    public string GraphicId { get { return _graphicId; } }
    public string GraphicsType { get { return _graphicType; } }

    public string this[string parm]
    {
        get
        {
            if (_parameters.ContainsKey(parm))
            {
                return _parameters[parm];
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (_parameters != null)
            {
                _parameters.Add(parm, value);
            }
        }
    }

    protected string _graphicId;
    protected string _graphicType;
    protected Dictionary<string, string> _parameters;

    public GraphicDefinition(string graphicId, string graphicType)
    {
        _graphicId = graphicId;
        _graphicType = graphicType;
        _parameters = new Dictionary<string, string>();
    }

    public bool ContainsParameter(string s)
    {
        return _parameters.ContainsKey(s);
    }

    /// <summary>
    /// Builds a GraphicDefinition using a string input.
    /// </summary>
    /// <param name="line">A string in the format 'GraphicId=[string];GraphicType=[string];Parameters=[string]:[string],...,[string]:[string]'.</param>
    /// <returns>GraphicDefinition if the format is correct, otherwise null.</returns>
    public static GraphicDefinition Load(string line)
    {
        var graphicId = "";
        var graphicType = "";
        var parameters = new Dictionary<string, string>();

        var split = line.Split(';');
        foreach (string s in split)
        {
            var pair = s.Trim().Split('=');
            switch(pair[0]){
                case ("GraphicId"): { graphicId = pair[1]; }
                    break;
                case ("GraphicType"): { graphicType = pair[1]; }
                    break;
                case ("Parameters"):
                    {
                        var paramPairs = pair[1].Split(',');
                        foreach (string param in paramPairs)
                        {
                            var paramSplit = param.Split(':');
                            parameters.Add(paramSplit[0], paramSplit[1]);
                        }
                    }
                    break;
            }
        }

        if (graphicId != "" && graphicType != "" && parameters.Count > 0)
        {
            return new GraphicDefinition(graphicId, graphicType)
            {
                _parameters = parameters
            };
        }
        else
        {
            LogManager.Write(1, $"Could not create GRAPHIC_DEFINITION because the definition line is missing one or more fields. line='{line}'");
            return null;
        }
    }
}