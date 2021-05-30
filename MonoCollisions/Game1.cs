using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoCollisions.Objects;

namespace MonoCollisions
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }

        public Player Player { get; private set; }
        public ObjectManager ObjectManager { get; private set; }

        public KeyboardState KeyboardState { get; private set; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Initialize objects
            ObjectManager = new ObjectManager();
            Player = new Player(0, 0, Drawing.TileSize, Drawing.TileSize);
            ObjectManager.AddObject(Player);
            ObjectManager.AddObject(new Block(Drawing.TileSize * 4, Drawing.TileSize * 4, Drawing.TileSize, Drawing.TileSize));
        }

        protected override void Initialize()
        {
            Drawing.InitializeGraphics(this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            // Get delta
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Get keyboard state
            KeyboardState = Keyboard.GetState();
            if (KeyboardState.IsKeyDown(Keys.Escape)) Exit();

            // Update objects
            ObjectManager.Update(this, delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(); // Begin sprite batch
            ObjectManager.Draw(this); // Draw objects
            SpriteBatch.End(); // End sprite batch

            base.Draw(gameTime);
        }
    }
}
