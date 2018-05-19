using Microsoft.Xna.Framework.Graphics;
using System;

public class GraphicsManager
{
    // Properties


    // Variables
    protected ImageFactory _imageFactory;
    protected SpriteFactory _spriteFactory;
    protected TextFactory _textFactory;

    // Methods
    public GraphicsManager(SpriteBatch defaultSpriteBatch)
    {
        _imageFactory = new ImageFactory();
        _spriteFactory = new SpriteFactory(defaultSpriteBatch);
        _textFactory = new TextFactory();
    }

    public Image GetImage()
    {
        throw new NotImplementedException();
    }

    public Sprite GetSprite()
    {
        throw new NotImplementedException();
    }

    public Text GetText()
    {
        throw new NotImplementedException();
    }
}