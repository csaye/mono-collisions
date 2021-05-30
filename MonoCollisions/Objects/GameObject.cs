using Microsoft.Xna.Framework;

namespace MonoCollisions.Objects
{
    public abstract class GameObject
    {
        protected Vector2 position;
        protected Vector2 size;

        public Vector2 Position => position;
        public Vector2 Size => size;

        public Rectangle Bounds => new Rectangle(position.ToPoint(), size.ToPoint());

        public GameObject(float x, float y, float width, float height)
        {
            position = new Vector2(x, y);
            size = new Vector2(width, height);
        }

        public abstract void Update(Game1 game, float delta);
        public abstract void Draw(Game1 game);
    }
}
