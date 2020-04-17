using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class TextManager
    {
        private Dictionary<string, string> _phases;//Funderar på att lägga till phases i Game

        //Error meddelanden kan nås av alla klasser då variabeln är statisk
        public static string errorNotANumber = "Skriv en SIFFRA";
        public static string errorToBig = "Kortet du har valt finns inte på din hand. Skriv ett lägre nummer";
        public static string errorToSmall = "Kortet du har valt finns inte på din hand. Skriv ett högre nummer";
        public static string errorWrongType = "Kortet du har valt kan inte användas i denna fas. Välj ett kort av den typ som kan spelas under fasen du är i.";

        public TextManager()
        {
            _phases = new Dictionary<string, string>();

            _phases.Add("build","Välj ett skrotkort som du vill lägga högst upp i ditt torn");
            _phases.Add("attack", "Välj ett attackkort med vilket du vill attackera din motståndare. Om du har fler attackkort kommer då få möjigheten att attackera igen");
            _phases.Add("trash", "Välj ett kort som du vill göra sig av med. Du kommer att få möjligheten att göra detta flera gånger.");
            _phases.Add("deffend", "Om du har ett försvarkort kan du nu välja att försvara dig med det");

        }

        public void InterpretBoard(Player user, Player opponent)
        {
            Console.Clear();

            Console.WriteLine(" -----------");
            Console.WriteLine("| DITT TORN |                                     Höjd: " + user.TowerHeight.ToString()); 
            Console.WriteLine(" -----------"); 
            Console.WriteLine();
            for (int i = 0; i < user.Tower.Count; i++)
            {
                Console.WriteLine(user.Tower[i].Name);
            }
            Console.WriteLine();


            Console.WriteLine();
            Console.WriteLine(" --------------------");
            Console.WriteLine("| DIN OPPONENTS TORN |                            Höjd: " + user.TowerHeight.ToString());
            Console.WriteLine(" --------------------");
            Console.WriteLine();
            for (int i = 0; i < opponent.Tower.Count; i++)
            {
                Console.WriteLine(opponent.Tower[i].Name);
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("_________________________________________________________");
            Console.WriteLine();
        }

        public void ReadInstructions(string phase)
        {
            Console.WriteLine();
            Console.WriteLine(_phases[phase]);
        }

        public void ReadCards(Player player)
        {

            for (int i = 0; i < player.Hand.Count; i++)
            {
                Console.WriteLine(i.ToString() + ") " + player.Hand[i].Name);
            }
        }
    }
}
