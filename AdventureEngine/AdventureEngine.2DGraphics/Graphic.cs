using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class Graphic
{   
    /// <summary>
    /// Gets this graphic's id.
    /// </summary>
    public string Id { get { return _id; } }

    /// <summary>
    /// Gets and Sets the flag that determines if the graphic is being drawn.
    /// </summary>
    public bool Visible
    {
        get { return _visible; }
        set { _visible = value; }
    }

    /// <summary>
    /// Gets an Sets the flag determining if the graphic is enabled.
    /// </summary>
    public bool Enabled
    {
        get { return _enabled; }
        set { _enabled = value; }
    }

    /// <summary>
    /// Gets and Sets the position where the graphic will be drawn.
    /// </summary>
    public abstract Vector2 DrawPosition { get; set; }

    /// <summary>
    /// Gets and Sets the dimensions of the graphic when it is drawn.
    /// </summary>
    public abstract Vector2 DrawDimensions { get; set; }

    protected string _id;
    protected bool _visible;
    protected bool _enabled;
    protected SpriteBatch _spriteBatch;

    /// <summary>
    /// Updates the graphic.
    /// </summary>
    /// <param name="gameTime">The current game time.</param>
    public abstract void Update(GameTime gameTime);

    /// <summary>
    /// Draws the graphic.
    /// </summary>
    /// <param name="gameTime">The current game time.</param>
    public abstract void Draw(GameTime gameTime);

    /// <summary>
    /// Draws the graphic at the specified position and using the specified spritebatch.
    /// </summary>
    /// <param name="gameTime">The current game time.</param>
    /// <param name="drawPosition">The position where the graphic should be drawn.</param>
    /// <param name="spriteBatch">The sprite batch that should be used to draw the graphic.</param>
    public abstract void Draw(GameTime gameTime, Vector2? drawPosition, SpriteBatch spriteBatch);

    /// <summary>
    /// Copies the graphic.
    /// </summary>
    /// <returns>A new graphic exactly matching this graphic.</returns>
    public abstract Graphic Copy();
}