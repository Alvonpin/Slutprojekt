using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Opponent : Player
    {
        public override Card SelectCard(string cardType)
        {
            int cardNumber = Game.Generator.Next(0, _hand.Count);

            if (cardType == "AnyCard" || CheckHandForCards(cardType) == true)
            {
                bool sucess = false;
                while (sucess == false)
                {
                    cardNumber = Game.Generator.Next(0, _hand.Count);

                    if (cardType != CheckCardType(cardNumber))
                    {
                        //Om det har specificerats att kortet kan vara av vilken typ som helst bryts loopen om de tidigare checkarna har passerats
                        if (cardType == "AnyCard")
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
