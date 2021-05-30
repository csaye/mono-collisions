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
    }
}
