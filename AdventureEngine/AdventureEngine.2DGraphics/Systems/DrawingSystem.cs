using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

public class DrawingSystem : ISystem
{
    protected SpriteBatch _spriteBatch;
    protected IWorld _world;

    /// <summary>
    /// Creates a drawing system.
    /// </summary>
    /// <param name="world">The world that is using this system.</param>
    public DrawingSystem(IWorld world, SpriteBatch spriteBatch)
    {
        _world = world;
        _spriteBatch = spriteBatch;
    }

    public void Update(string entityId, GameTime gameTime)
    {
        var components = new List<IComponent>();
        if (_world.Entities.TryGetValue(entityId, out components))
        {
            var sprites = new List<Sprite>();

            foreach (IComponent comp in components)
            {
                if (comp.GetType() == typeof(Sprite))
                {
                    sprites.Add(comp as Sprite);
                    continue;
                }
            }

            foreach (Sprite s in sprites)
            {
                UpdateSprite(s, gameTime);
            }
        }
    }

    public void Draw(string entityId)
    {
        var components = new List<IComponent>();
        if (_world.Entities.TryGetValue(entityId, out components))
        {
            PositionComponent position = null;
            var sprites = new List<Sprite>();
            var images = new List<Image>();
            var texts = new List<Text>();

            foreach (IComponent comp in components)
            {
                if (comp.GetType() == typeof(Sprite))
                {
                    sprites.Add(comp as Sprite);
                    continue;
                }

                if (comp.GetType() == typeof(Image))
                {
                    images.Add(comp as Image);
                    continue;
                }

                if (comp.GetType() == typeof(Text))
                {
                    texts.Add(comp as Text);
                    continue;
                }

                if (position != null && comp.GetType() == typeof(PositionComponent))
                {
                    position = comp as PositionComponent;
                    continue;
                }
            }

            if (position != null)
            {
                foreach (Sprite s in sprites)
                {
                    DrawSprite(s, position);
                }

                foreach (Image i in images)
                {
                    DrawImage(i, position);
                }

                foreach (Text t in texts)
                {
                    DrawText(t, position);
                }
            }
        }
    }

    private void UpdateSprite(Sprite sprite, GameTime gameTime)
    {
        sprite.ElapsedTime += gameTime.ElapsedGameTime;
        if (sprite.ElapsedTime.TotalMilliseconds > Configuration.Graphics.FrameTime)
        {
            sprite.ChangeFrame();
        }
    }

    private void DrawSprite(Sprite sprite, PositionComponent pComp)
    {
        if (sprite.Visible && sprite.Texture2DAsset.Loaded)
        {
            var position = pComp.Position + sprite.PositionOffset;
            var destRect = new Rectangle(position.ToPoint(), sprite.Dimensions.ToPoint());
            _spriteBatch.Draw(sprite.Texture2DAsset.Texture, destRect, sprite.SourceRectangle, sprite.Color);
        }
    }

    private void DrawImage(Image image, PositionComponent pComp)
    {
        if (image.Visible && image.Texture2DAsset.Loaded)
        {
            var position = pComp.Position + image.PositionOffset;
            var destRect = new Rectangle(position.ToPoint(), image.Dimensions.ToPoint());
            _spriteBatch.Draw(image.Texture2DAsset.Texture, destRect, image.SourceRectangle, image.Color);
        }
    }

    private void DrawText(Text text, PositionComponent pComp)
    {
        if (text.Visible && text.SpriteFontAsset.Loaded)
        {
            var position = pComp.Position + text.PositionOffset;
            if (text.Visible && text.Enabled)
            {
                _spriteBatch.DrawString(text.SpriteFontAsset.SpriteFont, text.DrawText, position, text.Color);
            }
            else
            {
                _spriteBatch.DrawString(text.SpriteFontAsset.SpriteFont, text.DrawText, position, text.DisabledColor);
            }
        }
    }
}