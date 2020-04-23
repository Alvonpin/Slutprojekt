using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Opponent : Player
    {
        //SelctCard hos opponent fungerar i stort sätt likadant som för spelare bortsätt från att användarinput ersätts med ett slumpmässigt tal
        //Då talet som slumpas fram varken är för stort eller för litet i och med att det slumpas fram utifrån mängden kort i spelarens hand krävs inte lika mycket felsökning
        public override Card SelectCard(Type cardType)
        {
            int cardNumber = Game.Generator.Next(0, _hand.Count);

            if (cardType == typeof(Card) || CheckHandForCards(cardType) == true)
            {
                //Den enda typ av felsökning som krävs är att säkerställa att kortet som valts är av rätt typ
                bool sucess = false;
                while (sucess == false)
                {
                    cardNumber = Game.Generator.Next(0, _hand.Count);

                    if (cardType != _hand[cardNumber].GetType() && cardType !=_hand[cardNumber].GetType().BaseType)
                    {

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
