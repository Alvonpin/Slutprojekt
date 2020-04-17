using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;

namespace Slutprojekt
{
    class Program
    {

        static void Main(string[] args)
        {

            Game game = new Game();

            bool endGame = false;
            while  (endGame == false)
            {
                game.PlayRound(out endGame, game.User);
                game.PlayRound(out endGame, game.Opponent); 
            }

            Console.Clear();
            Console.WriteAscii("Nu are slut");
            Console.Read();  

        }
    }
}
