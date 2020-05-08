using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace BalloonSpriteGame
{
    class Balloon
    {

        private Texture2D balloonSprite;
        private Vector2 balloonPosition;
        private Vector2 balloonOrigin;
        private ContentManager content;


        //constructor
        public Balloon(ContentManager content)
        {
            this.content = content;
            balloonSprite = this.content.Load<Texture2D>("spr_lives");
            balloonOrigin = new Vector2(balloonSprite.Width / 2, balloonSprite.Height); //this is most efficient as this value doesn't change

        }

        public Texture2D BalloonSprite { get => balloonSprite; set => balloonSprite = value; }
        public Vector2 BalloonPosition { get => balloonPosition; set => balloonPosition = value; }
        public Vector2 BalloonOrigin { get => balloonOrigin; set => balloonOrigin = value; }
    }
}
