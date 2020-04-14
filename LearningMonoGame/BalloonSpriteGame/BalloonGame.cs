using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Threading.Tasks;

namespace BalloonSpriteGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class BalloonGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D balloon, cannonBarrel, background;
        Vector2 balloonPosition, cannonBarrelPosition;
        Vector2 balloonOrigin, cannonBarrelOrigin;

        SoundEffect ding;

        float angle;

        public BalloonGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            balloon = Content.Load<Texture2D>("spr_lives");
            background = Content.Load<Texture2D>("spr_background");
            cannonBarrel = Content.Load<Texture2D>("spr_cannon_barrel");

            ding = Content.Load<SoundEffect>("snd_collect_points");

            // TODO: use this.Content to load your game content here
            balloonOrigin = new Vector2(balloon.Width / 2, balloon.Height); //this is most efficient as this value doesn't change
            cannonBarrelOrigin = new Vector2(cannonBarrel.Height, cannonBarrel.Height) / 2;
            cannonBarrelPosition = new Vector2(72, 405);

            MediaPlayer.Play(Content.Load<Song>("snd_music"), TimeSpan.FromMinutes(2.25));
            MediaPlayer.IsRepeating = true; //this will repeat

            //PlayDing();

        }


        private void PlayDing()
        {
            for(int i = 0; i < 2000; i++)
            {
                ding.Play();
                Task.Delay(200).Wait();
                ding.Play();
                Task.Delay(200).Wait();
                ding.Play();
                Task.Delay(400).Wait();
                ding.Play();
            }
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState currentMouseState = Mouse.GetState();

            ButtonState buttonStateLeft = currentMouseState.LeftButton;

            //option1 -- ballon will follow mouse, but balloon will be drawn to left of mouse pointer
            //balloonPosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            //option2
            //this new positioning centers the ballon at mouse pointer
            //balloonPosition = new Vector2(currentMouseState.X - balloon.Width / 2, currentMouseState.Y - balloon.Height / 2);


            //but there is another way to do this...
            //option3
            balloonPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
           

            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (currentMouseState.X < 200 || currentMouseState.Y < 50)
                {
                    //angle = 0;
                    angle = 200; //I like this better
                                 //cannonBarrelPosition = Vector2.Zero;
                }
                else
                {
                    double opposite = currentMouseState.Y - cannonBarrelPosition.Y;
                    double adjacent = currentMouseState.X - cannonBarrelPosition.X;
                    angle = (float)Math.Atan2(opposite, adjacent);
                }
            }
            




            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(balloon, balloonPosition - balloonOrigin, Color.White); //new way (vector math)...
            //spriteBatch.Draw(balloon, balloonPosition, Color.White); //old way
            spriteBatch.Draw(cannonBarrel, cannonBarrelPosition, null, Color.White, angle, cannonBarrelOrigin, 1.0f, SpriteEffects.None, 0);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
