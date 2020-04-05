using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading.Tasks;

namespace MonoGameLesson1
{

    public class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var discoGame = new DiscoGame();
            //discoGame.Run();

            new DiscoGame().Run();

            //new Game1().Run();

        }

     

    }

}
