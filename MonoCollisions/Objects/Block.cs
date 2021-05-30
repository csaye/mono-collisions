using Microsoft.Xna.Framework;

namespace MonoCollisions.Objects
{
    public class Block : GameObject
    {
        public Block(float x, float y, float width, float height) : base(x, y, width, height) { }

        public override void Update(Game1 game, float delta) { }
        public override void Draw(Game1 game)
        {
            Drawing.DrawRect(game, Bounds, Color.Gray);
        }
    }
}
