using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class Card
    {
        protected string _name; //protectd ger acess till subklasser
        protected string _description;

        public string Name
        {
          get { return _name;  }
        }

        //METOD Play
        public virtual void Play()
        {

        }

    }
}
