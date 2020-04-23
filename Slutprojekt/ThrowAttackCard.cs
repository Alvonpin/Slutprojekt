using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class ThrowAttackCard : AttackCard
    {
        public ThrowAttackCard(int power, string name)
        {
            _power = power;
            _name = name;
        }

        public override void Play(Player user)
        {
            //Olika attack cards har särkillda egenskaper som ännu inte har implimenterats 
        }

    }
}
