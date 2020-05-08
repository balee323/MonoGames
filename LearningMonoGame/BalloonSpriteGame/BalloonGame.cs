using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Threading.Tasks;

namespace BalloonSpriteGame
{

    public class BalloonGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Balloon balloon;
        Cannon cannon;
        SoundEffect ding;


        public BalloonGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;           
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("spr_background");

            balloon = new Balloon(Content);
            cannon = new Cannon(Content);

            ding = Content.Load<SoundEffect>("snd_collect_points");
            MediaPlayer.Play(Content.Load<Song>("snd_music"), TimeSpan.FromMinutes(2.25));
            MediaPlayer.IsRepeating = true; //this will repeat
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
             
            MouseState currentMouseState = Mouse.GetState();
            ButtonState buttonStateLeft = currentMouseState.LeftButton;
            balloon.BalloonPosition = new Vector2(currentMouseState.X, currentMouseState.Y);
           
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                if (currentMouseState.X < 200 || currentMouseState.Y < 50)
                {
                    cannon.Angle = 200; //I like this better                            
                }
                else
                {

                    double opposite = currentMouseState.Y - cannon.CannonBarrelPosition.Y;
                    double adjacent = currentMouseState.X - cannon.CannonBarrelPosition.X;
                    cannon.Angle = (float)Math.Atan2(opposite, adjacent);
                }
            }      
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(balloon.BalloonSprite, balloon.BalloonPosition - balloon.BalloonOrigin, Color.White); //new way (vector math)...
            cannon.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
