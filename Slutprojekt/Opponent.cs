using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Opponent : Player
    {
        public override Card SelectCard(Type cardType)
        {
            int cardNumber = Game.Generator.Next(0, _hand.Count);

            if (cardType == typeof(Card) || CheckHandForCards(cardType) == true)
            {
                bool sucess = false;
                while (sucess == false)
                {
                    cardNumber = Game.Generator.Next(0, _hand.Count);

                    if (cardType != _hand[cardNumber].GetType() && cardType !=_hand[cardNumber].GetType().BaseType)
                    {
                        //Om det har specificerats att kortet kan vara av vilken typ som helst bryts loopen om de tidigare checkarna har passerats
                        if (cardType == typeof(Card))
                        {
                            sucess = true;
                        }

                        else
                        {
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
          
    }
}
