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
            //Error check för type behövs

            int cardNumber = Game.Generator.Next(0, _hand.Count);

            bool sucess = false;
            while (sucess == false)
            {
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

    }
}
