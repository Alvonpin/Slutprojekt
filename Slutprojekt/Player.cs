﻿using System;
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

        public List<Card> Hand
        {
          get { return _hand;  }
        }

        public void DrawCards(Stack<Card> deck)
        {
            //Lägger till kort från deck tills spelaren har 5 kort i handen
            for (int i = 0; i < 5 - _hand.Count; i++)
            {
                _hand.Add(deck.Pop()); //Tar bort översta kortet i deck och lägger till det i spalarens hand
            }
        }

        public string CheckCardType(int cardNumber)
        {
            //Om "klass-typen" är eller ärver från AttackCard
            if (_hand[cardNumber].GetType().IsAssignableFrom(typeof(AttackCard)))
            {
                return "AttackCard";
            }

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
                }

                else if (cardNumber < _hand.Count + 1)
                {
                    Console.WriteLine(TextManager.errorToBig);
                }

                else if (cardNumber < _hand.Count + 1)
                {
                    Console.WriteLine(TextManager.errorToSmall);
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
                    }
                }

                else
                {
                    sucess = true;
                }
            }

            return _hand[cardNumber];

        }

        public void Build (Card chosenCard)
        {
            //_hand[cardNumber].Play();
            chosenCard.Play();

            //Ska jag istället ha hela choose card funktionen här?
        }


        public void Attack (Card chosenCard)
        {
            chosenCard.Play();
            //Ska jag istället ha hela choose card funktionen här?
        }

        public void Deffend(Card chosenCard)
        {
            chosenCard.Play();
            //Ska jag istället ha hela choose card funktionen här?
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
