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

        // Returns nearest empty position for given object moving to given position
        public Vector2 NearestEmptyPosition(GameObject movingObject, Vector2 newPosition)
        {
            // Get new bounds
            Rectangle newBounds = new Rectangle(newPosition.ToPoint(), movingObject.Size.ToPoint());

            // For each object
            foreach (GameObject gameObject in gameObjects)
            {
                // Skip self
                if (gameObject == movingObject) continue;

                // If object intersects with new bounds
                Rectangle objBounds = gameObject.Bounds;
                if (objBounds.Intersects(newBounds))
                {
                    // Get object centers
                    Point objCenter = gameObject.Bounds.Center;
                    Point newCenter = newBounds.Center;

                    // Get horizontal and vertical displacements
                    float displacementX = Math.Abs(objCenter.X - newCenter.X);
                    float displacementY = Math.Abs(objCenter.Y - newCenter.Y);

                    // If greater horizontal displacement
                    if (displacementX > displacementY)
                    {
                        // If right of object
                        if (newCenter.X > objCenter.X) newPosition.X = newBounds.X = objBounds.Right;
                        // If left of object
                        else newPosition.X = newBounds.X = objBounds.Left - newBounds.Width;
                    }
                    // If greater vertical displacement
                    else
                    {
                        // If below object
                        if (newCenter.Y > objCenter.Y) newPosition.Y = newBounds.Y = objBounds.Bottom;
                        // If above object
                        else newPosition.Y = newBounds.Y = objBounds.Top - newBounds.Height;

                    }
                }
            }

            // Return corrected new position
            return newPosition;
        }
    }
}
