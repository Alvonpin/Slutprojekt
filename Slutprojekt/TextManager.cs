using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class TextManager
    {
        public void ReadInstructions()
        {
            Console.WriteLine("Select a card");
        }

        public void ReadCards(Player player)
        {
            Console.WriteLine("Select a card");

            for (int i = 0; i < player.Hand.Count; i++)
            {
                Console.WriteLine(player.Hand[i].Name);
            }
        }
    }
}
