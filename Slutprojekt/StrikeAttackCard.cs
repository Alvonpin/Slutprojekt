using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class StrikeAttackCard : AttackCard
    {
        public StrikeAttackCard(int power, string name)
        {
            _power = power;
            _name = name;
        }

        public override void Play(Player player)
        {

        }

        //CONSTRUCTOR (power, name, description)

        //METOD (overide) Attack
    }
}
