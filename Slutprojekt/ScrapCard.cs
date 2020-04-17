using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class ScrapCard : Card
    {
        //Enum type?
        private int _height;
        private int _durability;
        private int _monkeyScare;

        public int Height
        {
            get { return _height; }
        }

        public ScrapCard (int height, int durability, int monkeyScare, string name)
        {
            _height = height;
            _durability = durability;
            _monkeyScare = monkeyScare;
            _name = name;
        }

        public override void Play(Player player)
        {
            player.Tower.Add(this);
        }

        //CONSTRUCTOR (height, durability, type, name, description)

        //METOD (overide) Play

        //METOD Collide
    }
}
