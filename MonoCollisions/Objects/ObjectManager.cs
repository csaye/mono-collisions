using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MonoCollisions.Objects
{
    public class ObjectManager
    {
        public List<GameObject> gameObjects = new List<GameObject>();

        public ObjectManager() { }

        public void AddObject(GameObject gameObject) => gameObjects.Add(gameObject);

        public void Update(Game1 game, float delta)
        {
            // For each object
            foreach (GameObject gameObject in gameObjects)
            {
                // Update object
                gameObject.Update(game, delta);
            }
        }

        public void Draw(Game1 game)
        {
            // For each object
            foreach (GameObject gameObject in gameObjects)
            {
                // Draw object
                gameObject.Draw(game);
            }
        }
    }
}
