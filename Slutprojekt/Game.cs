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
            _monkeyHight = 12;
            _deck = new Stack<Card>(); 
            _user = new Player();
            _opponent = new Opponent();
            litaratePerson = new TextManager();

            //Spelets alla kort skapas
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
            litaratePerson.InterpretBoard(_user, _opponent);//Spelplanen ritas ut. Det vill säga spelarnas torn.

            player.ForgetPlayedCards();
            player.DrawCards(_deck); //Kort dras från korthögen och läggs till i spelarens hand.

            litaratePerson.ReadCards(player);//Korten som spelaren har på handen skrivs ut.

            litaratePerson.ReadInstructions("build");
            player.Build((ScrapCard)player.SelectCard("ScrapCard"));
            /*Även fastän SelectCard returnerar ett Card vet jag att den i detta fall definitivt kommer att returnera ett ScrapCard. 
             *Jag vet detta då metoden SelectCard kollar typen av användarens valda kort i meoden innan det returneras.
             *Detta gör det möjligt för mig definera att metoden SelectCard i detta fall returnerar ett ScrapCard*/

            litaratePerson.ReadInstructions("attack");
            player.Attack((AttackCard)player.SelectCard("AttackCard"));
            //Detsamma gäller här.

            litaratePerson.ReadInstructions("trash");
            player.Trash(player.SelectCard("AnyCard"));
            //Då kortet som ska slängas typ inte spelar någon roll behöver den inte defineras.

            player.RemovePlayedCards();
        }

    }
}
