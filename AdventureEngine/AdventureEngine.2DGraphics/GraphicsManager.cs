using System.Collections.Generic;

public class GraphicsManager
{
    /// <summary>
    /// Gets a copy of the graphic found using the id provided.
    /// </summary>
    /// <param name="s">The id of the graphic</param>
    /// <returns>A graphic or null.</returns>
    public Graphic this[string id]
    {
        get
        {
            if (_graphics.ContainsKey(id))
            {
                return _graphics[id].Copy();
            }
            else
            {
                return null;
            }
        }
    }

    protected Dictionary<string, Graphic> _graphics;

    /// <summary>
    /// Creates a graphics manager.
    /// </summary>
    public GraphicsManager()
    {
        _graphics = new Dictionary<string, Graphic>();
    }

    /// <summary>
    /// Adds a graphic to the dictionary.
    /// </summary>
    /// <param name="graphic"></param>
    public void AddGraphic(Graphic graphic)
    {
        if (!_graphics.ContainsKey(graphic.Id))
        {
            _graphics.Add(graphic.Id, graphic);
        }
    }

    /// <summary>
    /// Removes a graphic from the dictionary.
    /// </summary>
    /// <param name="id">The id used to determine which graphic to remove.</param>
    public void RemoveGraphic(string id)
    {
        if (_graphics.ContainsKey(id))
        {
            _graphics.Remove(id);
        }
    }

    /// <summary>
    /// Removes a graphic from the dictionary.
    /// </summary>
    /// <param name="graphic">The graphic to remove.</param>
    public void RemoveGraphic(Graphic graphic)
    {
        if (_graphics.ContainsKey(graphic.Id))
        {
            _graphics.Remove(graphic.Id);
        }
    }
}