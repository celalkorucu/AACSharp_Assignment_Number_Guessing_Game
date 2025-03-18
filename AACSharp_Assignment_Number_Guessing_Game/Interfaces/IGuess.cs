using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACSharp_Assignment_Number_Guessing_Game.Interfaces
{
    public interface IGuess
    {
        public int NumberGuessOneToTen();

        public int NumberGuessOneToHundred();

        public int NumberGuessOneToThousand();
    }
}
