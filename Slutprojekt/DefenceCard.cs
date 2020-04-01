using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class DefenceCard : Card
    {
        private int _durability;

        public DefenceCard(int durability, string name)
        {
            _durability = durability;
            _name = name;
        }

        public override void Play(Player player)
        {

        }

        //CONSTRUCTOR (name, description, durability)
        //METOD (overide) Play
    }
}
