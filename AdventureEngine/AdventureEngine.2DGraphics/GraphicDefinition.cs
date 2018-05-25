using System.Collections.Generic;

public class GraphicDefinition
{
    /// <summary>
    /// Gets the id of the graphic defined/
    /// </summary>
    public string GraphicId { get { return _graphicId; } }

    /// <summary>
    /// Gets the type of graphic definied.
    /// </summary>
    public string GraphicType { get { return _graphicType; } }

    /// <summary>
    /// Accesses parameter values.
    /// </summary>
    /// <param name="parm">The name of the parameter to access.</param>
    /// <returns>A parameter or null.</returns>
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

    /// <summary>
    /// Creates a graphic definition.
    /// </summary>
    /// <param name="graphicId">The id of the graphic.</param>
    /// <param name="graphicType">The type of the graphic.</param>
    public GraphicDefinition(string graphicId, string graphicType)
    {
        _graphicId = graphicId;
        _graphicType = graphicType;
        _parameters = new Dictionary<string, string>();
    }

    /// <summary>
    /// Determines if the definition contans a parameter.
    /// </summary>
    /// <param name="s">The name of the parameter.</param>
    /// <returns>A flag that determines if the definition contans a parameter.</returns>
    public bool ContainsParameter(string s)
    {
        return _parameters.ContainsKey(s);
    }
}