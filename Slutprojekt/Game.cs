using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Game
    {
        //ATT GÖRA
        //-------------------------------------------------------------------------------
        //Lägg till torn i spelet istället för spelarna (User tower, Opponet tower)
        //I metoden Play, ta in tower istället för player
        //-------------------------------------------------------------------------------

        public static Random Generator = new Random();

        private int input;

        private List<Card> _cards;
        private Stack<Card> _deck;
        private int _monkeyHight;

        private Player _user;
        private Opponent _opponent;
        private TextManager litaratePerson;
        //private InputManager inputManager;

        public Player User
        {
            get { return _user; }
        }

        public Opponent Opponent
        {
            get { return _opponent; }
        }


        public Game ()
        {
            //input = 0;
            _monkeyHight = 12;
            _deck = new Stack<Card>(); 
            _user = new Player();
            _opponent = new Opponent();
            litaratePerson = new TextManager();
            //inputManager = new InputManager();

            //cards.Add Lägg in specifika kort tex SneakAttackCard(name, description, power)
            _cards = new List<Card> 
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


            _deck = ShuffleCards(_cards);
        }

        public Stack<Card> ShuffleCards (List<Card> cards)
        {
            //Metoden ger alla kort ett slumpmässigt nummer och lägger dem i ordningen efter deras tilldelade nummer
            cards = cards.OrderBy(x => Generator.Next()).ToList();

            return new Stack<Card>(cards);//Returnerar en stack med samma formation som listan
        }

        public void ScareMonkey ()
        {

        }

        public void PlayRound (Player player)
        {

            player.DrawCards(_deck);

            litaratePerson.ReadCards(player);

            litaratePerson.ReadInstructions("build");
            player.Build(player.SelectCard("ScrapCard"));

            litaratePerson.ReadInstructions("attack");
            player.Attack(player.SelectCard("AttackCard"));

            litaratePerson.ReadInstructions("trash");
            player.Trash(player.SelectCard("AnyCard"));

        }


        //CONSTRUCROR
        //CreateCards (en förutbestämd lista av ett antal olika kort)
        //ShuffleCards (blandar korten och lägger dem i en stack)
        //ScareMonkey (Sätter en starthöjd)
        //CreatePlayers (Kan välja mellan att spela mot en opponent eller en annan user)

        //METOD: PlayRound (player)



        //------------------------------------------------------------------------------------------------------
        //GAMMLA GREJER
        //-----------------------------------------------------------------------------------------------------

        //public void PlayRound (Player player)
        //{
        //player.DrawCards(_deck);

        //litaratePerson.ReadInstructions();
        //litaratePerson.ReadCards(player);

        //bool sucess = false;
        //while (sucess == false)

        //{
        //input = inputManager.GetInputNumber(out sucess, out string error, 0, player.Hand.Count);
        //if (sucess == false) { Console.WriteLine(error); }
        //}

        //player.Build(input);
        //}

    }
}
