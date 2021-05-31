# MonoCollisions

A top-down collision system for MonoGame.

## Scripts

[GameObject.cs](Objects/GameObjects.cs)

- Abstract class defining a collidable object
- Defines object position and size as `Vector2`s
- Construct with `GameObject(float x, float y, float width, float height)`

[ObjectManager.cs](Objects/ObjectManager.cs)

- Treats all `GameObject`s as dynamic
- Register `GameObject`s with `AddObject(GameObject gameObject)`
- Resolve collisions with `NearestEmptyPosition(GameObject movingObject, Vector2 newPosition)`

[GridObjectManager.cs](Objects/GridObjectManager.cs)

- Distinguishes between dynamic and static `GameObject`s
- Register dynamic objects with `AddDynamicObject(GameObject gameObject)`
- Register static objects with `AddStaticObject(GameObject gameObject)`
- Resolve collisions with `NearestEmptyPosition(GameObject movingObject, Vector2 newPosition)`

[Player.cs](Objects/Player.cs)

- Inherits from `GameObject`
- Moves with WASD
- Resolves collisions with central object manager

[Drawing.cs](Drawing.cs)

- Static helper class for drawing blank rects to sprite batch
- Defines grid size and screen size
- Draw rects with `DrawRect(Game1 game, Rectangle rect, Color color)`
