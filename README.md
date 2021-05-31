# MonoCollisions

A top-down collision system for MonoGame.

## Scripts

[GameObject.cs](MonoCollisions/Objects/GameObject.cs)

- Abstract class defining a collidable object
- Defines object position and size as `Vector2`s
- Construct with `GameObject(float x, float y, float width, float height)`

[ObjectManager.cs](MonoCollisions/Objects/ObjectManager.cs)

- Treats all `GameObject`s as dynamic
- Register `GameObject`s with `AddObject(GameObject gameObject)`
- Resolve collisions with `NearestEmptyPosition(GameObject movingObject, Vector2 newPosition)`

[GridObjectManager.cs](MonoCollisions/Objects/GridObjectManager.cs)

- Distinguishes between dynamic and static `GameObject`s
- Register dynamic objects with `AddDynamicObject(GameObject gameObject)`
- Register static objects with `AddStaticObject(GameObject gameObject)`
- Resolve collisions with `NearestEmptyPosition(GameObject movingObject, Vector2 newPosition)`

[Player.cs](MonoCollisions/Objects/Player.cs)

- Inherits from `GameObject`
- Moves with WASD
- Resolves collisions with central object manager

[Drawing.cs](MonoCollisions/Drawing.cs)

- Static helper class for drawing blank rects to sprite batch
- Defines grid size and screen size
- Draw rects with `DrawRect(Game1 game, Rectangle rect, Color color)`

## Examples

[Player.cs L36](MonoCollisions/Objects/Player.cs#L36)

Drawing the bounds of a `GameObject` to the sprite batch:

```cs
Drawing.DrawRect(game, Bounds, Color.White);
```

[Game1.cs L24](MonoCollisions/Game1.cs#L24)

Registering a `GridObjectManager` and a dynamic `GameObject`:

```cs
// Initialize objects
GridObjectManager = new GridObjectManager(Drawing.GridWidth, Drawing.GridHeight);
Player = new Player(0, 0, Drawing.Grid, Drawing.Grid);
GridObjectManager.AddDynamicObject(Player);
```

[Player.cs L16](MonoCollisions/Objects/Player.cs#L16)

WASD `GameObject` movement with collision checks:

```cs
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
```
