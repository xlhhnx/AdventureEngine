using Microsoft.Xna.Framework;
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

    /* Variables */
    protected bool _visible;
    protected bool _enabled;
    protected SpriteBatch _spriteBatch;

    /* Methods*/
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime, [Optional]Vector2 drawPosition, [Optional]SpriteBatch spriteBatch);
}