using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    abstract class Card //Klassen är inte menad att kallas
    {
        protected string _name; //Protected ger acess till subklasser
        protected string _description; //Kort har för närvarande inga beskrivningar 

        public string Name
        {
          get { return _name;  }
        }

        public abstract void Play(Player player); //Metoden är inte menad att kallas (därav abstract)

    }
}
