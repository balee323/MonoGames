﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class SpriteGameObject : GameObject
{
    protected Texture2D sprite;
    protected Vector2 origin;

    public SpriteGameObject(string spriteName)
    {
        sprite = ExtendedGame.ContentManager.Load<Texture2D>(spriteName);
        origin = Vector2.Zero;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (Visible)
        {
            // draw the sprite at its *global* position in the game world
            spriteBatch.Draw(sprite, GlobalPosition, null, Color.White,
                0, origin, 1.0f, SpriteEffects.None, 0);
        }
    }

    public int Width
    {
        get { return sprite.Width; }
    }

    public int Height
    {
        get { return sprite.Height; }
    }

    /// <summary>
    /// Updates this object's origin so that it lies in the center of the sprite.
    /// </summary>
    public void SetOriginToCenter()
    {
        origin = new Vector2(Width / 2.0f, Height / 2.0f);
    }

    /// <summary>
    /// Gets a Rectangle that describes this game object's current bounding box.
    /// This is useful for collision detection.
    /// </summary>
    public Rectangle BoundingBox
    {
        get
        {
            // get the sprite's bounds
            Rectangle spriteBounds = sprite.Bounds;
            // add the object's position to it as an offset
            spriteBounds.Offset(GlobalPosition - origin);
            return spriteBounds;
        }
    }
}