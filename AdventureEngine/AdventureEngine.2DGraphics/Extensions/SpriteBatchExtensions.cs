using AdventureEngine.Graphics2D.Assets;
using AdventureEngine.Graphics2D.Config;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureEngine.Graphics2D.Extensions
{
    public static class SpriteBatchExtensions
    {
        public static void Draw(this SpriteBatch sb, Image image, Rectangle destinationRectangle)
        {
            if (destinationRectangle == null) return;

            if (image == null)
            {
                image = Graphics2DConfig.DefaultImage;
                if (image?.Loaded == false) return;
            }

            if (image?.Loaded == false)
            {
                var texture = Graphics2DConfig.DefaultImage?.Texture2DAsset.Texture;
                if (texture != null) sb.Draw(image.Texture2DAsset.Texture, image.SourceRectangle, destinationRectangle, image.Color);
                return;
            }

            sb.Draw(image.Texture2DAsset.Texture, image.SourceRectangle, destinationRectangle, image.Color);
        }

        public static void Draw(this SpriteBatch sb, Image image, Vector2 rootPosition)
        {
            var rectangle = new Rectangle(rootPosition.ToPoint() + image.PositionOffset.ToPoint(), image.Dimensions.ToPoint());
            sb.Draw(image, rectangle);
        }

        public static void DrawString(this SpriteBatch sb, Text text, Vector2 rootPosition)
        {
            if (text == null)
            {
                text = Graphics2DConfig.DefaultText;
                if (text?.Loaded == false) return;
            }

            if (text?.Loaded == false)
            {
                var color = text.Enabled ? text.Color : text.DisabledColor;
                var spriteFont = Graphics2DConfig.DefaultText?.SpriteFontAsset.SpriteFont;
                var drawPosition = rootPosition + text.PositionOffset;
                if (spriteFont != null) sb.DrawString(spriteFont, text.DrawText, drawPosition, color);
            }
        }
    }
}