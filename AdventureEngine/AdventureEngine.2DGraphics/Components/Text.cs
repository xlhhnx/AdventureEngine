using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class Text : Graphic2D
{
    /// <summary>
    /// Gets and Sets the full text.
    /// </summary>
    public string FullText
    {
        get { return _fullText; }
        set
        {
            _fullText = value;
            _drawText = TrimText(_fullText, _drawDimensions);
        }
    }

    /// <summary>
    /// Gets the text that will be drawn.
    /// </summary>
    public string DrawText { get { return _drawText; } }

    /// <summary>
    /// Gets the dimensions of th ecurrent text based on the sprite font.
    /// </summary>
    public Vector2? TextDimensions
    {
        get
        {
            if (_spriteFontAsset.Loaded)
            {
                return _spriteFontAsset.SpriteFont.MeasureString(_drawText);
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Gets the sprite font asset.
    /// </summary>
    public SpriteFontAsset SpriteFontAsset { get { return _spriteFontAsset; } }

    /// <summary>
    /// Gets and Sets the color of the text if enabled.
    /// </summary>
    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }

    /// <summary>
    /// Gets and Sets the color of the text if disbled.
    /// </summary>
    public Color DisabledColor
    {
        get { return _disabledColor; }
        set { _disabledColor = value; }
    }

    protected string _fullText;
    protected string _drawText;
    protected Color _color;
    protected Color _disabledColor;
    protected Vector2 _drawPosition;
    protected Vector2 _drawDimensions;
    protected SpriteFontAsset _spriteFontAsset;

    /// <summary>
    /// Creates a text.
    /// </summary>
    /// <param name="spriteBatch">The spritebatch used to draw the text by default.</param>
    /// <param name="spriteFontAsset">The sprite font that should be used to draw the text.</param>
    /// <param name="drawPosition">The position where the text should be drawn.</param>
    /// <param name="drawDimensions">The dimensions with which the text should be drawn.</param>
    /// <param name="color">The color of the text.</param>
    /// <param name="disabledColor">The color of the text when disabled.</param>
    /// <param name="fullText">The full text.</param>
    public Text(string entityId, string name, SpriteFontAsset spriteFontAsset, Color color, Color disabledColor, Vector2 positionOffset, Vector2 dimensions, string fullText)
    {
        _entityId = entityId;
        _name = name;
        _spriteFontAsset = spriteFontAsset;
        _color = color;
        _disabledColor = disabledColor;
        _positionOffset = positionOffset;
        _dimensions = dimensions;
        _fullText = fullText;
        _drawText = TrimText(fullText, _drawDimensions);
    }

    ///// <summary>
    ///// Draws a string of text.
    ///// </summary>
    ///// <param name="gameTime">The current game time.</param>
    ///// <param name="fullText">The text to be drawn.</param>
    ///// <param name="drawPosition">The location where the text should be drawn.</param>
    ///// <param name="drawDimensions">The dimensions the text should be drawn within.</param>
    ///// <param name="spriteBatch">The spritebatch that should be used to draw the text.</param>
    //public virtual void DrawLine(GameTime gameTime, string fullText, [Optional]Vector2 drawPosition, [Optional]Vector2 drawDimensions, [Optional]SpriteBatch spriteBatch)
    //{
    //    Vector2 _drawPosition = this._drawPosition;
    //    Vector2 _drawDimensions = this._drawDimensions;
    //    SpriteBatch _spriteBatch = this._spriteBatch;

    //    // Handle optional parameters
    //    if (drawPosition != null) _drawPosition = drawPosition;
    //    if (drawDimensions != null) _drawDimensions = drawDimensions;
    //    if (spriteBatch != null) _spriteBatch = spriteBatch;

    //    string _drawText = TrimText(fullText, _drawDimensions);

    //    if (Visible && _spriteFontAsset.Loaded)
    //    {
    //        if (Enabled)
    //        {
    //            _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _color);
    //        }
    //        else
    //        {
    //            _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _disabledColor);
    //        }
    //    }
    //}

    //public override void Draw(GameTime gameTime) => Draw(gameTime, null, null);

    //public override void Draw(GameTime gameTime, Vector2? drawPosition, SpriteBatch spriteBatch)
    //{
    //    Vector2 _drawPosition = DrawPosition;
    //    SpriteBatch _spriteBatch = this._spriteBatch;

    //    // Handle optional parameters
    //    if (drawPosition.HasValue) _drawPosition = drawPosition.Value;
    //    if (spriteBatch != null) _spriteBatch = spriteBatch;

    //    if (Visible && _spriteFontAsset.Loaded)
    //    {
    //        if (Enabled)
    //        {
    //            _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _color);
    //        }
    //        else
    //        {
    //            _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _disabledColor);
    //        }
    //    }
    //}

    public override Graphic2D Copy()
    {
        return new Text(_entityId, _name, _spriteFontAsset, _color, _disabledColor, _positionOffset, _dimensions, _fullText);
    }

    /// <summary>
    /// Trims text to the draw dimensions.
    /// </summary>
    /// <param name="text">The full text.</param>
    /// <param name="dimensions">The allowed dimensions.</param>
    /// <returns>A string short enough to it in the dimensions or and ellipsis.</returns>
    public string TrimText(string text, Vector2 dimensions)
    {
        if (_spriteFontAsset.Loaded) {
            string ellipsis = "...";
            string workingString = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                Vector2 stringSize = _spriteFontAsset.SpriteFont.MeasureString(workingString + text[i] + ellipsis);
                if (stringSize.X < dimensions.X || stringSize.Y < dimensions.Y)
                {
                    workingString += text[i];
                }
                else
                {
                    break;
                }
            }
            return workingString + ellipsis;
        }
        return null;
    }
}