using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Player
    {
        protected string _name;
        protected List<Card> _hand;
        protected List<Card> _tower;
        protected List<Card> _playedCards;

        protected int _towerHeight;

        public int TowerHeight
        {
            get { return _towerHeight; }
        }

        public List<Card> Hand
        {
          get { return _hand;  }
        }

        public List<Card> Tower
        {
            get { return _tower; }
        }

        public Player ()
        {
            _name = "Carl";
            _hand = new List<Card>();
            _tower = new List<Card>();
            _playedCards = new List<Card>();
        }

        public void DrawCards(out bool outOfCards, Stack<Card> deck)
        {
            outOfCards = false;
            if (deck.Count > 5)
            {
                //Lägger till kort från deck tills spelaren har 5 kort i handen
                while (Hand.Count < 5)
                {
                    if (deck.Count < 1)
                    {
                        return;
                    }

                    _hand.Add(deck.Pop()); //Tar bort översta kortet i deck och lägger till det i spalarens hand
                }
            }

            //Om det inte finns kvar tillräckligt många kort för att nästa spelare ska kunna dra 5 nya ska spelet avlutas, därav out OutOfCards
            else
            {
                outOfCards = true;
            }

        }

        //Metoden söker i spelarens hand efter ett särkillt typ av kort och returnerar huruvida det finns eller inte
        //I spelet fyller metoden funktionen att låta spelaren skippa en fas om hen saknar den typ av kort som spelas under den fasen
        public bool CheckHandForCards(Type cardType)
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                //Undersöker om kortet är av typen som efterfrågas eller om klassen vilken kortet ärver från är det
                if (_hand[i].GetType() == cardType || _hand[i].GetType().BaseType == cardType)
                {
                    return true;
                }
            }

            return false;
        }

        //Metoden låter spelaren välja ett kort från sin hand och returnerar sedan det
        //Innan kortet returneras felsökes spelarens input och vid eventuella fel skrivs felmeddelanden ut och spelaren får ge ytteligare ett svar
        //I spelet används metoden varje gång en spelare, användare eller opponent, skall välja ett kort, oberoende av korttyp
        public virtual Card SelectCard(Type cardType)
        {
            int cardNumber = 0;//Index av kort i handen

            //Om korttypen som sökes antingen är vilket kort som helst eller finns på spelarens hand
            if (cardType == typeof(Card) || CheckHandForCards(cardType) == true)
            {
                bool sucess = false;//Om spelarens input är godkänd ändras denna bool och loopen bryts
                while (sucess == false)
                {
                    string input = Console.ReadLine();
                    sucess = int.TryParse(input, out cardNumber);

                    cardNumber--;//I och med att korten listas som 1, 2, 3, 4, och 5 i spelet stämmer deras nummer inte överns med deras index i _hand

                    if (sucess == false)
                    {
                        Console.WriteLine(TextManager.errorNotANumber);//TextManager har ett antal statiska felmeddelanden och kan därför nås från alla klasser
                        sucess = false;
                    }

                    else if (cardNumber >= _hand.Count)
                    {
                        Console.WriteLine(TextManager.errorToBig);
                        sucess = false;
                    }

                    else if (cardNumber < 0)
                    {
                        Console.WriteLine(TextManager.errorToSmall);
                        sucess = false;
                    }

                    //Om kortet som har valts typ varken är av den typ som efterfrågas eller om klassen vilken kortet ärver från är det.
                    else if (cardType != _hand[cardNumber].GetType() && cardType != _hand[cardNumber].GetType().BaseType)
                    {
                        //Om det har specificerats att kortet kan vara av vilken typ som helst bryts loopen om de tidigare checkarna har passerats
                        if (cardType == typeof(Card))
                        {
                            sucess = true;
                        }

                        else
                        {
                            Console.WriteLine(TextManager.errorWrongType);
                            sucess = false;
                        }
                    }

                    else
                    {
                        sucess = true;
                    }
                }

                return _hand[cardNumber];
            }

            //Om typen av kort som sökes inte finns på spelarens hand returnerar metoden null
            else
            {
                return null;
            }
          
        }

        //Metoden används när spelaren är i byggfasen och ska bygga ett skrotkort
        public void Build (ScrapCard chosenCard)
        {
            //Om metoden SelectCard har returnerat null är chosenCard null och metoden hoppas över då spelaren inte kan välja ett kort av typen som sökes
            if (chosenCard != null)
            {
                chosenCard.Play(this);
                _playedCards.Add(chosenCard);//Alla kort som spelaren spelar under en runda läggs till i en lista över spelade kort
                _towerHeight = _towerHeight + chosenCard.Height;//Tornets nya höjd beräknas (tornets höjd beror på höjden på skrotkorten i det)
            }
        }

        //Metoden används när spelaren är i attackfasen och ska attackera ett annat torn
        public void Attack (AttackCard chosenCard)
        {
            if (chosenCard != null)
            {
                chosenCard.Play(this);
                _playedCards.Add(chosenCard);
            }
        }

        //Metoden används om spelaren vill försvara sig under en attack (HAR ÄNNU INTE IMPLIMENTERATS)
        public void Defend(DefenceCard chosenCard)
        {
            chosenCard.Play(this);
            _playedCards.Add(chosenCard);
        }

        //Metoden används om spelaren vill slänga ett kort från sin hand
        public void Trash(Card chosenCard)
        {
            _hand.Remove(chosenCard);
        }

        //Metoden rensar föregående rundas spelade kort för att dessa redan har tagits bort ur spelarens hand
        public void ForgetPlayedCards()
        {
            _playedCards.Clear();
        }

        //Metoden tar bort alla kort som finns i listan över spelade kort från spelarens hand
        //I spelet fyller metoden funktionen att låta kort förbrukas när de spelats, detta så att de inte kan spelas igen nästa runda
        public void RemovePlayedCards()
        {
            for (int i = 0; i < _playedCards.Count; i++)
            {
                _hand.Remove(_playedCards[i]);
            }
        }

    }
}
