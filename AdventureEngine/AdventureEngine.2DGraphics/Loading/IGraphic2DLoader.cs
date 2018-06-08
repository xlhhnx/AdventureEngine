using System.Collections.Generic;

public interface IGraphic2DLoader
{
    Image LoadImage(string filePath, string id);
    Sprite LoadSprite(string filePath, string id);
    Text LoadText(string filePath, string id);
    Effect LoadEffect(string filePath, string id);
    IGraphic2D LoadGraphic(string filePath, string id);
    List<IGraphic2D> LoadGraphics(string filePath);
    void StageFile(string filePath, bool overwrite = false);
    void UnstageFile(string filePath);
}