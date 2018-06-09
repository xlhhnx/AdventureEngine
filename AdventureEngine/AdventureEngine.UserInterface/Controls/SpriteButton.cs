using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class SpriteButton : ImageButton
{
    public SpriteButton(Sprite focusedImage, Sprite unfocusedImage, Sprite clickedImage, Text focusedText, Text unfocusedText, Text clickedText, CommandManager commandManager, ICommand command, IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, bool visible = true, bool enabled = true) 
        : base(focusedImage, unfocusedImage, clickedImage, focusedText, unfocusedText, clickedText, commandManager, command, bounds, screen, position, dimensions, tabIndex, visible, enabled)
    { }

    public override void Update(GameTime gameTime)
    {
        var sprites = new List<Sprite>() {
            _focusedImage as Sprite,
            _unfocusedImage as Sprite,
            _clickedImage as Sprite
        };

        foreach (var s in sprites)
        {
            if (s.ElapsedTime > new TimeSpan(0, 0, 0, 0, 200)) s.ChangeFrame();
        }
    }
}