﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public abstract class GraphicsObject
{
    /* Properties */
    public bool Visible
    {
        get { return _visible; }
        set { _visible = value; }
    }

    public bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; }
    }

    public abstract Vector2 DrawPosition { get; set; }
    public abstract Vector2 DrawDimensions { get; set; }

    /* Variables */
    protected bool _visible;
    protected bool _enabled;
    protected SpriteBatch _spriteBatch;

    /* Methods*/
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime);
    public abstract void Draw(GameTime gameTime, Vector2? drawPosition, SpriteBatch spriteBatch);
}