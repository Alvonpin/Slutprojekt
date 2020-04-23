using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class SneakAttackCard : AttackCard
    {
        public SneakAttackCard(int power, string name)
        {
            _power = power;
            _name = name;
        }

        public override void Play(Player player)
        {
            //Olika attack cards har särkillda egenskaper som ännu inte har implimenterats 
        }

    }
}
