using AdventureEngine.Game;
using AdventureEngine.Game.Components;
using AdventureEngine.Game.Systems;
using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace AdventureEngine.Graphics2D.Systems
{
    public class DrawingSystem : IDrawableSystem
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
                Position position = null;
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

                    if (position != null && comp.GetType() == typeof(Position))
                    {
                        position = comp as Position;
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
            if (sprite.ElapsedTime.TotalMilliseconds > Graphics2DConfig.DefaultFrameTime)
            {
                sprite.ChangeFrame();
            }
        }

        private void DrawSprite(Sprite sprite, Position position)
        {
            if (sprite.Visible && sprite.Texture2DAsset.Loaded)
            {
                var truePos = position._Position + sprite.PositionOffset;
                var destRect = new Rectangle(truePos.ToPoint(), sprite.Dimensions.ToPoint());
                _spriteBatch.Draw(sprite.Texture2DAsset.Texture, destRect, sprite.SourceRectangle, sprite.Color);
            }
        }

        private void DrawImage(Image image, Position position)
        {
            if (image.Visible && image.Texture2DAsset.Loaded)
            {
                var truePos = position._Position + image.PositionOffset;
                var destRect = new Rectangle(truePos.ToPoint(), image.Dimensions.ToPoint());
                _spriteBatch.Draw(image.Texture2DAsset.Texture, destRect, image.SourceRectangle, image.Color);
            }
        }

        private void DrawText(Text text, Position position)
        {
            if (text.Visible && text.SpriteFontAsset.Loaded)
            {
                var truePos = position._Position + text.PositionOffset;
                if (text.Visible && text.Enabled)
                {
                    _spriteBatch.DrawString(text.SpriteFontAsset.SpriteFont, text.DrawText, truePos, text.Color);
                }
                else
                {
                    _spriteBatch.DrawString(text.SpriteFontAsset.SpriteFont, text.DrawText, truePos, text.DisabledColor);
                }
            }
        }
    }
}