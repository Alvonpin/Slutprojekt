using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Player
    {
        protected string name;
        protected List<Card> _hand;
        protected List<Card> _tower;

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
            name = "Carl";
            _hand = new List<Card>();
            _tower = new List<Card>();
        }

        public void DrawCards(Stack<Card> deck)
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

        public string CheckCardType(int cardNumber)
        {
            //Om "klass-typen" ärver från AttackCard
            if (_hand[cardNumber].GetType().IsSubclassOf(typeof(AttackCard)))
            {
                return "AttackCard";
            }

            //Om "klass-typen" är ett ScrapCard
            else if (_hand[cardNumber].GetType().IsAssignableFrom(typeof(ScrapCard)))
            {
                return "ScrapCard";
            }

            else 
            {
                return "DefenceCard";
            }
        }

        public virtual Card SelectCard(string cardType)
        {
            int cardNumber = 0;

            bool sucess = false;
            while (sucess == false)
            {
                string input = Console.ReadLine();
                sucess = int.TryParse(input, out cardNumber);

                if (sucess == false)
                {
                    Console.WriteLine(TextManager.errorNotANumber);
                    sucess = false;
                }

                else if (cardNumber > _hand.Count)
                {
                    Console.WriteLine(TextManager.errorToBig);
                    sucess = false;
                }

                else if (cardNumber < 0)
                {
                    Console.WriteLine(TextManager.errorToSmall);
                    sucess = false;
                }

                else if (cardType != CheckCardType(cardNumber))
                {
                    //Om det har specificerats att kortet kan vara av vilken typ som helst bryts loopen om de tidigare checkarna har passerats
                    if (cardType == "AnyCard")
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

        public void Build (ScrapCard chosenCard)
        {
            chosenCard.Play(this);
            _towerHeight = _towerHeight + chosenCard.Height;
        }


        public void Attack (AttackCard chosenCard)
        {
            chosenCard.Play(this);
        }

        public void Deffend(DefenceCard chosenCard)
        {
            chosenCard.Play(this);
        }

        public void Trash(Card chosenCard)
        {
            _hand.Remove(chosenCard);
        }


        //METOD: DrawCards
        //METOD: Build (card)
        //METOD: Attack (card)
        //METOD: Deffend (card)
        //METOD: Trash (card)
        //METOD: Spank

    }
}
