using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class Text : GraphicsObject
{
    // Properties
    public string FullText
    {
        get { return _fullText; }
        set
        {
            _fullText = value;
            _drawText = TrimText(_fullText, _drawDimensions);
        }
    }

    public string DrawText
    {
        get { return _drawText; }
    }

    public Vector2? TextDimensions
    {
        get
        {
            if (_spriteFontAsset.Loaded)
                return _spriteFontAsset.SpriteFont.MeasureString(_drawText);
            else
                return null;
        }
    }

    public override Vector2 DrawDimensions
    {
        get { return _drawDimensions; }
        set { _drawDimensions = value; }
    }

    public override Vector2 DrawPosition
    {
        get { return _drawPosition; }
        set { _drawPosition = value; }
    }

    // Variables
    protected string _fullText;
    protected string _drawText;
    protected Color _color;
    protected Color _disabledColor;
    protected Vector2 _drawPosition;
    protected Vector2 _drawDimensions;
    protected SpriteFontAsset _spriteFontAsset;

    // Methods
    public Text(SpriteBatch spriteBatch, SpriteFontAsset spriteFontAsset, Vector2 drawPosition, Vector2 drawDimensions, Color color, Color disabledColor, string fullText)
    {
        _spriteBatch = spriteBatch;
        _spriteFontAsset = spriteFontAsset;
        _drawPosition = drawPosition;
        _drawDimensions = drawDimensions;
        _color = color;
        _disabledColor = disabledColor;
        _fullText = fullText;
        _drawText = TrimText(fullText, _drawDimensions);
    }

    public override void Update(GameTime gameTime)
    {
        // No op
    }

    public virtual void DrawLine(GameTime gameTime, string fullText, [Optional]Vector2 drawPosition, [Optional]Vector2 drawDimensions, [Optional]SpriteBatch spriteBatch)
    {
        Vector2 _drawPosition = this._drawPosition;
        Vector2 _drawDimensions = this._drawDimensions;
        SpriteBatch _spriteBatch = this._spriteBatch;

        // Handle optional parameters
        if (drawPosition != null) _drawPosition = drawPosition;
        if (drawDimensions != null) _drawDimensions = drawDimensions;
        if (spriteBatch != null) _spriteBatch = spriteBatch;

        string _drawText = TrimText(fullText, _drawDimensions);

        if (Visible && _spriteFontAsset.Loaded)
        {
            if (Enabled)
                _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _color);
            else
                _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _disabledColor);
        }
    }

    public override void Draw(GameTime gameTime)
    {
        // Use other draw to avoid duplicating code.
        Draw(gameTime, null, null);
    }

    public override void Draw(GameTime gameTime, Vector2? drawPosition, SpriteBatch spriteBatch)
    {
        Vector2 _drawPosition = DrawPosition;
        SpriteBatch _spriteBatch = this._spriteBatch;

        // Handle optional parameters
        if (drawPosition.HasValue) _drawPosition = drawPosition.Value;
        if (spriteBatch != null) _spriteBatch = spriteBatch;

        if (Visible && _spriteFontAsset.Loaded)
        {
            if (Enabled)
                _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _color);
            else
                _spriteBatch.DrawString(_spriteFontAsset.SpriteFont, _drawText, _drawPosition, _disabledColor);
        }
    }

    private string TrimText(string text, Vector2 dimensions)
    {
        if (_spriteFontAsset.Loaded) {
            string ellipsis = "...";
            string workingString = string.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                Vector2 stringSize = _spriteFontAsset.SpriteFont.MeasureString(workingString + text[i] + ellipsis);
                if (stringSize.X < dimensions.X || stringSize.Y < dimensions.Y)
                    workingString += text[i];
                else
                    break;
            }

            return workingString + ellipsis;
        }

        return null;
    }
}