using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextButton : BaseButton
{
    protected ICommand _command;
    protected CommandManager _commandManager;
    protected Text _focusedText;
    protected Text _unfocusedText;
    protected Text _clickedText;

    public TextButton(Text focusedText, Text unfocusedText, Text clickedText, CommandManager commandManager, ICommand command, IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, bool visible = true, bool enabled = true) 
        : base(bounds, screen, position, dimensions, tabIndex, visible, enabled)
    {
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
        Color textColor = Color.White;
        Vector2 textPosition = Vector2.Zero;
        SpriteFont spriteFont = null;

        if (_focused && _clicked && _clickedText.SpriteFontAsset.Loaded)
        {
            textPosition = _position + _clickedText.PositionOffset;
            spriteFont = _clickedText.SpriteFontAsset.SpriteFont;
            text = _clickedText.DrawText;

            if (_enabled) textColor = _clickedText.Color;
            else textColor = _clickedText.DisabledColor;
        }

        else if (_focused && _focusedText.SpriteFontAsset.Loaded)
        {
            textPosition = _position + _focusedText.PositionOffset;
            spriteFont = _focusedText.SpriteFontAsset.SpriteFont;
            text = _focusedText.DrawText;

            if (_enabled) textColor = _focusedText.Color;
            else textColor = _focusedText.DisabledColor;
        }

        else if (_unfocusedText.SpriteFontAsset.Loaded)
        {
            textPosition = _position + _unfocusedText.PositionOffset;
            spriteFont = _unfocusedText.SpriteFontAsset.SpriteFont;
            text = _unfocusedText.DrawText;

            if (_enabled) textColor = _unfocusedText.Color;
            else textColor = _unfocusedText.DisabledColor;
        }

        if (spriteFont != null) spriteBatch.DrawString(spriteFont, text, textPosition, textColor);
    }
}