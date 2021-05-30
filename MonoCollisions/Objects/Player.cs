using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonoCollisions.Objects
{
    public class Player : GameObject
    {
        private Vector2 movementDirection;

        private const float Speed = 100;

        public Player(float x, float y, float width, float height) : base(x, y, width, height) { }

        public override void Update(Game1 game, float delta)
        {
            // Get keyboard state
            KeyboardState state = game.KeyboardState;

            // Reset movement direction
            movementDirection = new Vector2(0, 0);

            // Process keyboard state
            if (state.IsKeyDown(Keys.W)) movementDirection.Y -= 1; // Up
            if (state.IsKeyDown(Keys.S)) movementDirection.Y += 1; // Down
            if (state.IsKeyDown(Keys.D)) movementDirection.X += 1; // Right
            if (state.IsKeyDown(Keys.A)) movementDirection.X -= 1; // Left
            if (movementDirection.Length() > 1) movementDirection.Normalize();

            // Process movement
            Vector2 newPosition = position + movementDirection * delta * Speed;
            position = game.GridObjectManager.NearestEmptyPosition(this, newPosition);
        }

        public override void Draw(Game1 game)
        {
            Drawing.DrawRect(game, Bounds, Color.White);
        }
    }
}
