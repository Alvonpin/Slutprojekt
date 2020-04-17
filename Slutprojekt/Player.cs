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
            name = "Carl";
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

            else
            {
                outOfCards = true;
            }

        }

        public bool CheckHandForCards(Type cardType)
        {
            for (int i = 0; i < _hand.Count; i++)
            {
                if (_hand[i].GetType() == cardType || _hand[i].GetType().BaseType == cardType)
                {
                    return true;
                }
            }

            return false;
        }

        public virtual Card SelectCard(Type cardType)
        {
            int cardNumber = 0;

            if (cardType == typeof(Card) || CheckHandForCards(cardType) == true)
            {
                bool sucess = false;
                while (sucess == false)
                {
                    string input = Console.ReadLine();
                    sucess = int.TryParse(input, out cardNumber);

                    cardNumber--;

                    if (sucess == false)
                    {
                        Console.WriteLine(TextManager.errorNotANumber);
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

            else
            {
                return null;
            }
          
        }

        public void Build (ScrapCard chosenCard)
        {
            if (chosenCard != null)
            {
                chosenCard.Play(this);
                _playedCards.Add(chosenCard);
                _towerHeight = _towerHeight + chosenCard.Height;
            }
        }


        public void Attack (AttackCard chosenCard)
        {
            if (chosenCard != null)
            {
                chosenCard.Play(this);
                _playedCards.Add(chosenCard);
            }
        }

        public void Deffend(DefenceCard chosenCard)
        {
            chosenCard.Play(this);
            _playedCards.Add(chosenCard);
        }

        public void Trash(Card chosenCard)
        {
            _hand.Remove(chosenCard);
        }

        public void ForgetPlayedCards()
        {
            _playedCards.Clear();
        }

        public void RemovePlayedCards()
        {
            for (int i = 0; i < _playedCards.Count; i++)
            {
                _hand.Remove(_playedCards[i]);
            }
        }

    }
}
