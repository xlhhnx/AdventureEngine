using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class ImageButton : BaseButton
{
    protected ICommand _command;
    protected CommandManager _commandManager;
    protected Image _focusedImage;
    protected Image _unfocusedImage;
    protected Image _clickedImage;
    protected Text _focusedText;
    protected Text _unfocusedText;
    protected Text _clickedText;

    public ImageButton(Image focusedImage, Image unfocusedImage, Image clickedImage, Text focusedText, Text unfocusedText, Text clickedText, CommandManager commandManager, ICommand command, IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, bool visible = true, bool enabled = true) 
        : base(bounds, screen, position, dimensions, tabIndex, visible, enabled)
    {
        _focusedImage = focusedImage;
        _unfocusedImage = unfocusedImage;
        _clickedImage = clickedImage;
        _focusedText = focusedText;
        _unfocusedText = unfocusedText;
        _clickedText = clickedText;
        _commandManager = commandManager;
        _command = command;
    }

    public override void Select()
    {
        _commandManager.Enqueue(_command);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        string text = "";
        Color imageTint = Color.White;
        Color textColor = Color.White;
        Vector2 textPosition = Vector2.Zero;
        Rectangle sourceRectangle = Rectangle.Empty;
        Rectangle destinationRectangle = Rectangle.Empty;
        Texture2D texture = null;
        SpriteFont spriteFont = null;

        if (_focused && _clicked)
        {
            if (_clickedImage.Texture2DAsset.Loaded)
            {
                destinationRectangle = new Rectangle(_position.ToPoint() + _clickedImage.PositionOffset.ToPoint(), _clickedImage.Dimensions.ToPoint());
                sourceRectangle = _clickedImage.SourceRectangle;
                texture = _clickedImage.Texture2DAsset.Texture;
                imageTint = _clickedImage.Color;
            }

            if (_clickedText.SpriteFontAsset.Loaded)
            {
                textPosition = _position + _clickedText.PositionOffset;
                spriteFont = _clickedText.SpriteFontAsset.SpriteFont;
                text = _clickedText.DrawText;

                if (_enabled) textColor = _clickedText.Color;
                else textColor = _clickedText.DisabledColor;
            }
        }
        else if (_focused)
        {
            if (_focusedImage.Texture2DAsset.Loaded)
            {
                destinationRectangle = new Rectangle(_position.ToPoint() + _focusedImage.PositionOffset.ToPoint(), _focusedImage.Dimensions.ToPoint());
                sourceRectangle = _focusedImage.SourceRectangle;
                texture = _focusedImage.Texture2DAsset.Texture;
                imageTint = _focusedImage.Color;
            }

            if (_focusedText.SpriteFontAsset.Loaded)
            {
                textPosition = _position + _focusedText.PositionOffset;
                spriteFont = _focusedText.SpriteFontAsset.SpriteFont;
                text = _focusedText.DrawText;

                if (_enabled) textColor = _focusedText.Color;
                else textColor = _focusedText.DisabledColor;
            }
        }
        else
        {
            if (_unfocusedImage.Texture2DAsset.Loaded)
            {
                destinationRectangle = new Rectangle(_position.ToPoint() + _unfocusedImage.PositionOffset.ToPoint(), _unfocusedImage.Dimensions.ToPoint());
                sourceRectangle = _unfocusedImage.SourceRectangle;
                texture = _unfocusedImage.Texture2DAsset.Texture;
                imageTint = _unfocusedImage.Color;
            }

            if (_unfocusedText.SpriteFontAsset.Loaded)
            {
                textPosition = _position + _unfocusedText.PositionOffset;
                spriteFont = _unfocusedText.SpriteFontAsset.SpriteFont;
                text = _unfocusedText.DrawText;

                if (_enabled) textColor = _unfocusedText.Color;
                else textColor = _unfocusedText.DisabledColor;
            }
        }

        if (texture != null && spriteFont != null)
        {
            spriteBatch.Draw(texture, sourceRectangle, destinationRectangle, imageTint);
            spriteBatch.DrawString(spriteFont, text, textPosition, textColor);
        }
    }
}