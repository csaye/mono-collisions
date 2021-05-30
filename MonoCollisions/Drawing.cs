using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoCollisions
{
    public static class Drawing
    {
        // Grid size
        public const int Grid = 32;

        // Grid width and height
        public const int GridWidth = 16;
        public const int GridHeight = 16;

        // Screen width and height
        public const int ScreenWidth = GridWidth * Grid;
        public const int ScreenHeight = GridHeight * Grid;

        private static Texture2D blankTexture;

        public static void InitializeGraphics(Game1 game)
        {
            // Set screen size
            game.Graphics.PreferredBackBufferWidth = ScreenWidth;
            game.Graphics.PreferredBackBufferHeight = ScreenHeight;
            game.Graphics.ApplyChanges();

            // Initialize blank texture
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
