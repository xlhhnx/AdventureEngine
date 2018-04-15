using System.Collections.Generic;

public class GraphicsManager
{
    // Properties


    // Variables
    protected ImageFactory _imageFactory;
    protected SpriteFactory _spriteFctory;
    protected TextFactory _textFactory;

    // Methods
    public GraphicsManager()
    {
        _imageFactory = new ImageFactory();
        _spriteFctory = new SpriteFactory();
        _textFactory = new TextFactory();
    }

    public Image GetImage()
    {

    }

    public Sprite GetSprite()
    {

    }

    public Text GetText()
    {

    }
}