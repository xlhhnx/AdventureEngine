public interface IGraphics2DManager : ISubscriber
{
    Image DefaultImage { get; }
    Sprite DefaultSprite { get; }
    Text DefaultText { get; }
    IGraphic2DLoader Loader { get; set; }

    void LoadGraphic(string filePath, string id, GraphicType graphicType);
    void LoadGraphic(string filePath, string id);
    void LoadGraphics(string filePath, GraphicType graphicType);
    void LoadGraphics(string filePath);
    void AddGraphic(IGraphic2D graphic, bool overwrite = false);
    void AddGraphic(Image image, bool overwrite = false);
    void AddGraphic(Sprite sprite, bool overwrite = false);
    void AddGraphic(Text text, bool overwrite = false);
    void AddGraphic(Effect effect, bool overwrite = false);
    void Recycle(GraphicType graphicType);
    void Recycle();
    Image GetImage(string id);
    Sprite GetSprite(string id);
    Text GetText(string id);
    Effect GetEffect(string id);
}