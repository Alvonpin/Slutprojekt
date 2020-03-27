using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class TextManager
    {
        //Error meddelanden kan nås av alla klasser då variabeln är statisk
        public static string errorNotANumber = "Skriv en SIFFRA";
        public static string errorToBig = "Kortet du har valt finns inte på din hand. Skriv ett lägre nummer";
        public static string errorToSmall = "Kortet du har valt finns inte på din hand. Skriv ett högre nummer";
        public static string errorWrongType = "Kortet du har valt kan inte användas i denna fas. Välj ett kort av den typ som kan spelas under fasen du är i.";

        public void ReadInstructions()
        {
            Console.WriteLine("Select a card");
        }

        public void ReadCards(Player player)
        {
            Console.WriteLine("Select a card");

            for (int i = 0; i < player.Hand.Count; i++)
            {
                Console.WriteLine(player.Hand[i].Name); //(i + 1).ToString fungerar inte
            }
        }
    }
}
