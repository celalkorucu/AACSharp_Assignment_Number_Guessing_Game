using AACSharp_Assignment_Number_Guessing_Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AACSharp_Assignment_Number_Guessing_Game.Classes
{
    public class GuessRobot
    {

        private int currentGuessValue { get; set; }

        private int maxValue { get; set; }

        private int minValue { get; set; }

        public void StartRobot(int level)
        {
            switch (level)
            {
                case 0: currentGuessValue =  5; maxValue = 10; minValue = 1; break;
                case 1: currentGuessValue = 50; maxValue = 100; minValue = 1;  break;
                case 2: currentGuessValue = 500; maxValue = 1000; minValue = 1;  break;
            }
        }
        public int GuessNumber()
        {
            Console.WriteLine("Roboton tahmin ettiği sayı : "+currentGuessValue);
            Thread.Sleep(500);
            return currentGuessValue;
        }

        public void MergeUp()
        {
            minValue = currentGuessValue;
            currentGuessValue = (maxValue + minValue)/2;
        }

        public void MergeDown()
        {
            maxValue = currentGuessValue;
            currentGuessValue = (maxValue + minValue) / 2;
        }
    }
}
