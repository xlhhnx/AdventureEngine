using System.Collections.Generic;

public interface IGraphic2DLoader
{
    /// <summary>
    /// Loads a graphic.
    /// </summary>
    /// <param name="filePath">The path to the file that containst the graphic definition.</param>
    /// <param name="id">The id of the graphic to load.</param>
    /// <returns>A graphic or null.</returns>
    Graphic LoadGraphic(string filePath, string id);

    /// <summary>
    /// Loads all graphics in a file.
    /// </summary>
    /// <param name="filePath">The path to the file that containst the graphic definitions.</param>
    /// <returns>A list of graphics.</returns>
    List<Graphic> LoadGraphics(string filePath);
}