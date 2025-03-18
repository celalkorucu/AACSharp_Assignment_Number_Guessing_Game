using AACSharp_Assignment_Number_Guessing_Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AACSharp_Assignment_Number_Guessing_Game.Classes
{
    public class Guess : IGuess
    {

        private int keptNumber { get; set; }

        private int guessCounter { get; set; }

        private int guessNumber { get; set; }

        GuessRobot guessRobot { get; set; }
        private enum GameLevel
        {
            Easy,
            Mid,
            Hard
        }

        private GameLevel SelectLevel {  get; set; }

        public void StartGame(int hardLevel)
        {
            LevelInitialize(hardLevel);
            
            GuessRobotInitialize(hardLevel);

            OperationsInLoop();
            FinishGame();
        }

        private void LevelInitialize(int level)
        {
            switch (level)
            {
                case 0: NumberGuessOneToTen(); break;
                case 1: NumberGuessOneToHundred(); break;
                case 2: NumberGuessOneToThousand(); break;
            }
        }

        private void GuessRobotInitialize(int level)
        {
            guessRobot = new GuessRobot();
            guessRobot.StartRobot(level);
        }

        private void GetNumberFromUser()
        {
            ////Console.Write("Bir sayı tahmin ediniz : ");
            ////string? input = Console.ReadLine();
            //if(input == null)
            //{
            //    Console.WriteLine("Bir değer giriniz !");
            //}
            //else
            //{
            //    guessNumber = int.Parse(input!);
            //}

            guessNumber = guessRobot.GuessNumber();
        }

        private bool CheckNumbers()
        {
            if (SelectLevel == GameLevel.Easy)
            {
                WarningMessageEasyGame();
            }else if(SelectLevel == GameLevel.Mid)
            {
                WarningMessageMidGame();
            }
            else
            {
                WarningMessageHardGame();
            }


            if (guessNumber == keptNumber)
            {
                return true;
            }
            else if(guessNumber > keptNumber)
            {
                guessRobot.MergeDown();
                InfoReduceTheNumber();
                return false;
            }
            else
            {
                guessRobot.MergeUp();
                InfoIncreaseTheNumber();
                return false;
            }
        }

        private void WarningMessageEasyGame()
        {
            if(!(guessNumber >0 && guessNumber < 10))
            {
                Console.WriteLine("1-10 Arasında değerler girmelisiniz !");
            }
        }

        private void WarningMessageMidGame()
        {
            if (!(guessNumber > 0 && guessNumber < 100))
            {
                Console.WriteLine("1-100 Arasında değerler girmelisiniz !");

            }
        }

        private void WarningMessageHardGame()
        {
            if (!(guessNumber > 0 && guessNumber < 1000))
            {
                Console.WriteLine("1-1000 Arasında değerler girmelisiniz !");
            }
        }

        private void InfoIncreaseTheNumber()
        {
            Console.WriteLine("Daha büyük bir sayı söylemelisin");
        }

        private void InfoReduceTheNumber()
        {
            Console.WriteLine("Daha küçük bir sayı söylemelisin");
        }

        private void OperationsInLoop()
        {
            while(true)
            {
                IncrementGuessCounter();
                GetNumberFromUser();
                bool control = CheckNumbers();
                if(control)
                {
                    break;
                }
            }
        }

        private void FinishGame()
        {
            Console.WriteLine("Doğru sayıyı tahmin ettin !");
            Console.WriteLine("Aklımdan tuttuğum sayı :" + keptNumber + " idi.");
            Console.WriteLine(guessCounter + " denemede bu sayıyı bulmayı başardın.");
            Console.WriteLine("Derecen : "+UserCategorize());
        }

        private string UserCategorize()
        {


            switch (SelectLevel)
            {
                case GameLevel.Easy: return EasyLevelCategorize();
                case GameLevel.Mid: return MidLevelCategorize(); 
                case GameLevel.Hard: return HardLevelCategorize(); 

            }

            return null;

            
        }

        private string HardLevelCategorize()
        {
            if (guessCounter == 1)
            {
                return "MUHTEŞEM";
            }else if( guessCounter > 1 &&guessCounter < 10)
            {
                return "İYİ";
            }
            else if(guessCounter>= 10 &&guessCounter < 20)
            {
                return "FENA DEĞİL";
            }
            else
            {
                return "BERBAT";
            }
        }

        private string MidLevelCategorize()
        {
            if (guessCounter == 1)
            {
                return "MUHTEŞEM";
            }
            else if (guessCounter > 1 && guessCounter < 5)
            {
                return "İYİ";
            }
            else if (guessCounter >= 5 && guessCounter < 10)
            {
                return "FENA DEĞİL";
            }
            else
            {
                return "BERBAT";
            }
        }

        private string EasyLevelCategorize()
        {
            if (guessCounter == 1)
            {
                return "MUHTEŞEM";
            }
            else if (guessCounter > 1 && guessCounter < 3)
            {
                return "İYİ";
            }
            else if (guessCounter >= 3 && guessCounter < 5)
            {
                return "FENA DEĞİL";
            }
            else
            {
                return "BERBAT";
            }
        }

        private void IncrementGuessCounter()
        {
            guessCounter++;
        }

        public int NumberGuessOneToHundred()
        {
            Random random = new Random();
            SelectLevel = GameLevel.Mid;        
            return keptNumber = random.Next(1,100);
        }

        public int NumberGuessOneToTen()
        {
            Random random = new Random();
            SelectLevel = GameLevel.Easy;
            return keptNumber = random.Next(1, 10);
        }

        public int NumberGuessOneToThousand()
        {
            Random random = new Random();
            SelectLevel = GameLevel.Hard;
            return keptNumber = random.Next(1, 1000);
        }
    }
}
