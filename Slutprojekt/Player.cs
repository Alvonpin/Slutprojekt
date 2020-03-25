using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Player
    {
        private string name;
        private List<Card> _hand;
        private List<Card> _tower;

        public void DrawCards(Stack<Card> deck)
        {
            //Lägger till kort från deck tills spelaren har 5 kort i handen
            for (int i = 0; i < 5 - _hand.Count; i++)
            {
                _hand.Add(deck.Pop()); //Tar bort översta kortet i deck och lägger till det i spalarens hand
            }
        }

        public virtual void Build (int cardNumber)
        {
            _hand[cardNumber].Play();
        }


        //METOD: DrawCards
        //METOD: Build (card)
        //METOD: Attack (card)
        //METOD: Deffend (card)
        //METOD: Trash (card)
        //METOD: Spank

    }
}
