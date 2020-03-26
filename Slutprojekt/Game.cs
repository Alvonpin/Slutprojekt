using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Game
    {
        private int input;
      
        private Stack<Card> _deck;
        private int _monkeyHight;

        private Player user;
        private Player opponent;
        private TextManager litaratePerson;
        private InputManager inputManager;


        //public Stack<Card> Cards
        //{
           // get { return _cards;  }
        //}

        public Game ()
        {
            input = 0;

            user = new Player();
            opponent = new Player();
            litaratePerson = new TextManager();
            inputManager = new InputManager();

            List<Card> cards = new List<Card> 
            {
                new ScrapCard(4, 5, 0, "Älgtorn"), //Fritid
                new ScrapCard(2, 2, 0, "Tio bowlingkäglor"), //Fritid
                new ScrapCard(1, 3, 0, "TV"), //Möbel
                new ScrapCard(2, 3, 0, "Farfarsklocka"), //Möbel
                new ScrapCard(2, 3, 0, "Tandemcyckel"), //Fordon
                new ScrapCard(1, 4, -1, "Flakmoped"), //Fordon
                new ScrapCard(5, 4, 1, "Dinosaurieskelett"), //Organiskt
                new ScrapCard(2, 4, -3, "Bananträd"), //Organiskt
                new ScrapCard(3, 7 , 0, "Missil"), //Illegal
                new ScrapCard(1, 3, 0, "Hembränningsapparat"), //Illegal
                new ThrowAttackCard (4, "Handgranat"),
                new StrikeAttackCard (0, "Rullgardin"),
                new StrikeAttackCard (1, "Lie"), //BONUS organisk
                new SneakAttackCard (-1, "Bollkanon"),
                new DefenceCard (1, "Paraply"),
                new DefenceCard (3, "Frityrolja")

            }; 
            //cards.Add Lägg in specifika kort tex SneakAttackCard(name, description, power)


        }

        public Stack<Card> ShuffleCards (List<Card> cards)
        {

        }

        public void ScareMonkey ()
        {

        }

        //CONSTRUCROR
        //CreateCards (en förutbestämd lista av ett antal olika kort)
        //ShuffleCards (blandar korten och lägger dem i en stack)
        //ScareMonkey (Sätter en starthöjd)
        //CreatePlayers (Kan välja mellan att spela mot en opponent eller en annan user)

        //METOD: PlayRound (player)

        public void PlayRound (Player player)
        {
            player.DrawCards(_deck);

            litaratePerson.ReadInstructions();
            litaratePerson.ReadCards(player);

            bool sucess = false;
            while (sucess == false)

            {
                input = inputManager.GetInputNumber(out sucess, out string error, 0, player.Hand.Count);
                if (sucess == false) { Console.WriteLine(error); }
            }

            player.Build(input);
        }

    }
}
