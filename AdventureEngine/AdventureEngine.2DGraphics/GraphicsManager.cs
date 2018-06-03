using System.Collections.Generic;

public class GraphicsManager
{
    protected Dictionary<string, Graphic2D> _graphics;

    /// <summary>
    /// Creates a graphics manager.
    /// </summary>
    public GraphicsManager()
    {
        _graphics = new Dictionary<string, Graphic2D>();
    }

    /// <summary>
    /// Adds a graphic to the dictionary.
    /// </summary>
    /// <param name="graphic"></param>
    public void AddGraphic(Graphic2D graphic)
    {
        if (!_graphics.ContainsKey(graphic.Id))
        {
            _graphics.Add(graphic.Id, graphic);
        }
    }

    /// <summary>
    /// Gets a graphic.
    /// </summary>
    /// <param name="id">The id of the graphic to get.</param>
    /// <returns>A graphic or null.</returns>
    public Graphic2D GetGraphic(string id)
    {
        Graphic2D graphic = null;
        _graphics.TryGetValue(id, out graphic);
        return graphic;
    }
}