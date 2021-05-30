using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoCollisions
{
    public static class Drawing
    {
        // Screen width and height
        public const int ScreenWidth = 512;
        public const int ScreenHeight = 512;

        private static Texture2D blankTexture;

        public static void InitializeGraphics(Game1 game)
        {
            game.Graphics.PreferredBackBufferWidth = ScreenWidth;
            game.Graphics.PreferredBackBufferHeight = ScreenHeight;

            blankTexture = new Texture2D(game.GraphicsDevice, 1, 1);
            blankTexture.SetData(new Color[] { Color.White });
        }

        // Draws blank rectangle of given color to sprite batch
        public static void DrawRect(Game1 game, Rectangle rect, Color color)
        {
            game.SpriteBatch.Draw(blankTexture, rect, color);
        }
    }
}
