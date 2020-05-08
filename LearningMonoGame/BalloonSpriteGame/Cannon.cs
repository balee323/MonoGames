using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BalloonSpriteGame
{
    class Cannon
    {

        private Texture2D cannonBarrel;
        private Vector2 cannonBarrelOrigin;
        private Vector2 cannonBarrelPosition;
        private Vector2 colorOrigin;
        private Color currentColor = Color.Blue;
        private Texture2D colorRed;
        private Texture2D colorGreen;
        private Texture2D colorBlue;
        private float angle;

        private ContentManager content;

        //constructor
        public Cannon(ContentManager content)
        {
            this.content = content;
            cannonBarrel = this.content.Load<Texture2D>("spr_cannon_barrel");
            colorRed = this.content.Load<Texture2D>("spr_cannon_red");
            colorGreen = this.content.Load<Texture2D>("spr_cannon_green");
            colorBlue = this.content.Load<Texture2D>("spr_cannon_blue");

            cannonBarrelOrigin = new Vector2(cannonBarrel.Height, cannonBarrel.Height) / 2;
            cannonBarrelPosition = new Vector2(72, 405);
            colorOrigin = new Vector2(colorRed.Width, colorRed.Height) / 2;

        }

        public Vector2 CannonBarrelOrigin { get => cannonBarrelOrigin; set => cannonBarrelOrigin = value; }
        public Vector2 CannonBarrelPosition { get => cannonBarrelPosition; set => cannonBarrelPosition = value; }
        public Texture2D CannonBarrel { get => cannonBarrel; set => cannonBarrel = value; }
        public float Angle { get => angle; set => angle = value; }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cannonBarrel, cannonBarrelPosition, null, Color.White,
            angle, cannonBarrelOrigin, 1f, SpriteEffects.None, 0);
            // determine the sprite based on the current color
            Texture2D currentSprite;
            if (currentColor == Color.Red)
                currentSprite = colorRed;
            else if (currentColor == Color.Green)
                currentSprite = colorGreen;
            else
                currentSprite = colorBlue;
            // draw that sprite
            spriteBatch.Draw(currentSprite, cannonBarrelPosition, null, Color.White,
            0f, colorOrigin, 1.0f, SpriteEffects.None, 0);
        }


        public void Reset()
        {
            currentColor = Color.Blue;
            angle = 0.0f;
        }

    }
}
