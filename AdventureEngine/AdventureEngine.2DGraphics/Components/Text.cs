using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;

public class Text : BaseGraphic2D, IComponent
{
    public override bool Loaded { get { return _spriteFontAsset.Loaded; } }
    public string DrawText { get { return _drawText; } }
    public virtual string EntityId { get { return _entityId; } }
    public virtual string Name { get { return _name; } }

    public string FullText
    {
        get { return _fullText; }
        set
        {
            _fullText = value;
            _drawText = TrimText(_fullText, _drawDimensions);
        }
    }

    public override GraphicType GraphicType { get { return GraphicType.Text; } }
    public SpriteFontAsset SpriteFontAsset { get { return _spriteFontAsset; } }

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
    
    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public Color DisabledColor
    {
        get { return _disabledColor; }
        set { _disabledColor = value; }
    }


    protected string _entityId;
    protected string _name;
    protected string _fullText;
    protected string _drawText;
    protected Color _color;
    protected Color _disabledColor;
    protected Vector2 _drawPosition;
    protected Vector2 _drawDimensions;
    protected SpriteFontAsset _spriteFontAsset;


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

    public override IGraphic2D Copy()
    {
        return new Text(_entityId, _name, _spriteFontAsset, _color, _disabledColor, _positionOffset, _dimensions, _fullText);
    }

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

    public string Serilize()
    {
        throw new NotImplementedException();
    }
}