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
            return _hand[Game.Generator.Next(0, _hand.Count)];
        }

    }
}
