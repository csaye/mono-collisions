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
        public GridObjectManager GridObjectManager { get; private set; }

        public KeyboardState KeyboardState { get; private set; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Initialize objects
            GridObjectManager = new GridObjectManager(Drawing.GridWidth, Drawing.GridHeight);
            Player = new Player(0, 0, Drawing.Grid, Drawing.Grid);
            GridObjectManager.AddDynamicObject(Player);
            GridObjectManager.AddStaticObject(new Block(Drawing.Grid * 4, Drawing.Grid * 4, Drawing.Grid, Drawing.Grid));
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
            GridObjectManager.Update(this, delta);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(); // Begin sprite batch
            GridObjectManager.Draw(this); // Draw objects
            SpriteBatch.End(); // End sprite batch

            base.Draw(gameTime);
        }
    }
}
