using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading.Tasks;

namespace MonoGameLesson1
{
    class DiscoGame : Game
    {

        GraphicsDeviceManager graphics;
        Color background;

        public DiscoGame()
        {
            graphics = new GraphicsDeviceManager(this);
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            int redComponent = gameTime.TotalGameTime.Milliseconds / 4;
            background = new Color(redComponent, 0, 0);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(background);
        }


    }
}
