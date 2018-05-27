public static class Graphics2DConfiguration
{
    /// <summary>
    /// Gets the default frame time in milliseconds. Defaults to 200.
    /// </summary>
    public static int FrameTime
    {
        get { return _frameTime; }
        set { _frameTime = value; }
    }

    /// <summary>
    /// Gets and Sets the default sprite. Defaults to null.
    /// </summary>
    public static Sprite DefaultSprite
    {
        get { return _defaultSprite; }
        set { _defaultSprite = value; }
    }

    private static int _frameTime = 200;
    private static Sprite _defaultSprite = null;
}