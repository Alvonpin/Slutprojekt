using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class InputManager
    {
        //Metoden returnerar 0 om den misslyckas och resultatet om den lyckas samt en bool som indikerar om den lyckats eller misslyckats
        static public int GetInputNumber(out bool sucess)
        {
            string input = Console.ReadLine();
            sucess = int.TryParse(input, out int result);

            if (!sucess) { return 0; }
            else { return result; }
        }

        //Metoden returnerar även en string som utgörs av ett errormeddelande
        static public int GetInputNumber(out bool sucess, out string error, int max, int min)
        {
            string input = Console.ReadLine();
            sucess = int.TryParse(input, out int result);

            //if (!sucess || result < min || result > max) { return 0;} <-- Om jag endast har ett typ av errormeddelande

            if (!sucess) { error = "Not a number"; sucess = false; return 0; }
            if (result < min) { error = "To small"; sucess = false; return 0; }
            if (result > max) { error = "To big"; sucess = false; return 0; }

            else { error = ""; sucess = true; return result; }
        }

        static public Card GetInputCard(int cardNumber)
        {
            
        }
    }
}
