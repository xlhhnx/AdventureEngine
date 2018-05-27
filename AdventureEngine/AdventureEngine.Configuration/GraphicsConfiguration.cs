public class GraphicsConfiguration
{
    /// <summary>
    /// Gets the default frame time in milliseconds. Defaults to 200.
    /// </summary>
    public int FrameTime
    {
        get { return _frameTime; }
        set { _frameTime = value; }
    }

    private int _frameTime = 200;
}