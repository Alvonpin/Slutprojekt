using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                game.PlayRound(game.User);
                game.PlayRound(game.Opponent); 
            }

        }
    }
}
