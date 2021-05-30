using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace MonoCollisions.Objects
{
    public class GridObjectManager
    {
        public List<GameObject> dynamicObjects = new List<GameObject>();
        public GameObject[,] staticObjects;

        private readonly int GridWidth;
        private readonly int GridHeight;

        public GridObjectManager(int gridWidth, int gridHeight)
        {
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            staticObjects = new GameObject[gridWidth, gridHeight];
        }

        public void AddDynamicObject(GameObject gameObject) => dynamicObjects.Add(gameObject);
        public void AddStaticObject(GameObject gameObject)
        {
            int posX = (int)(gameObject.Position.X / Drawing.Grid);
            int posY = (int)(gameObject.Position.Y / Drawing.Grid);
            staticObjects[posX, posY] = gameObject;
        }

        public void Update(Game1 game, float delta)
        {
            // Update all dynamic objects
            foreach (GameObject gameObject in dynamicObjects) gameObject.Update(game, delta);
        }

        public void Draw(Game1 game)
        {
            // Draw all static objects
            foreach (GameObject staticObject in staticObjects) staticObject.Draw(game);

            // Draw all dynamic objects
            foreach (GameObject dynamicObject in dynamicObjects) dynamicObject.Draw(game);
        }

        // Processes the intersection between two bounds, returning the corrected new bounds position
        private Vector2 ProcessIntersection(Rectangle newBounds, Rectangle objBounds, Vector2 newPosition)
        {
            // If object bounds intersect
            if (!objBounds.Intersects(newBounds))
            {
                // Get object centers
                Point objCenter = objBounds.Center;
                Point newCenter = newBounds.Center;

                // Get horizontal and vertical displacements
                float displacementX = Math.Abs(objCenter.X - newCenter.X);
                float displacementY = Math.Abs(objCenter.Y - newCenter.Y);

                // If greater horizontal displacement
                if (displacementX > displacementY)
                {
                    // If right of object
                    if (newCenter.X > objCenter.X) newPosition.X = objBounds.Right;
                    // If left of object
                    else newPosition.X = objBounds.Left - newBounds.Width;
                }
                // If greater vertical displacement
                else
                {
                    // If below object
                    if (newCenter.Y > objCenter.Y) newPosition.Y = objBounds.Bottom;
                    // If above object
                    else newPosition.Y = objBounds.Top - newBounds.Height;

                }
            }

            // Return corrected new position
            return newPosition;
        }

        // Returns nearest empty position for given object moving to given position
        public Vector2 NearestEmptyPosition(GameObject movingObject, Vector2 newPosition)
        {
            // Get new bounds
            Rectangle newBounds = new Rectangle(newPosition.ToPoint(), movingObject.Size.ToPoint());

            // Calculate new bounds on grid
            int leftBound = newBounds.Left / Drawing.Grid;
            int rightBound = newBounds.Right / Drawing.Grid;
            int topBound = newBounds.Top / Drawing.Grid;
            int bottomBound = newBounds.Bottom / Drawing.Grid;

            // For each static object in new bound
            for (int x = leftBound; x <= rightBound; x++)
            {
                for (int y = topBound; y <= bottomBound; y++)
                {
                    // Skip position if out of bounds
                    if (x < 0 || x > GridWidth - 1 || y < 0 || y > GridHeight - 1) continue;

                    // Get object at position and skip if null
                    GameObject gameObject = staticObjects[x, y];
                    if (gameObject == null) continue;

                    // Process intersection between objects
                    newPosition = ProcessIntersection(newBounds, gameObject.Bounds, newPosition);

                    // Update new bounds
                    newBounds.X = (int)newPosition.X;
                    newBounds.Y = (int)newPosition.Y;
                }
            }

            // For each dynamic object
            foreach (GameObject gameObject in dynamicObjects)
            {
                // Skip self
                if (gameObject == movingObject) continue;

                // Process intersection between objects
                newPosition = ProcessIntersection(newBounds, gameObject.Bounds, newPosition);

                // Update new bounds
                newBounds.X = (int)newPosition.X;
                newBounds.Y = (int)newPosition.Y;
            }

            // Return corrected new position
            return newPosition;
        }
    }
}
