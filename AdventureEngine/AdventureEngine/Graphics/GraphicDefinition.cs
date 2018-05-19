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
}