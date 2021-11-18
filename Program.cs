using System;
using System.Collections.Generic;

namespace Rock_Paper_Scissors
{
    enum GameResult
    {
        Draw,
        UserWins,
        ComputerWins
    };

    class Program
    {
        static void Main(string[] args)
        {
            int Answer = 0;

            // Set up initial game options menu using a do-while loop

            do {

                Console.WriteLine(@"-----------------------
Welcome to Rock Paper Scissors Game!!!

Please select a number:

1) New Game
2) Settings 
3) Exit

-----------------------
");

                try
                {
                    Answer = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number between 1, 2 or 3");
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong, please retry");
                    Console.WriteLine("(" + ex.Message + ")");
                    continue;
                }

                if (Answer == 1)
                {
                    PlayGame();
                }

                else if (Answer == 2)
                {
                    GameSettings();
                }

                if (Answer == 3)
                {
                    break;
                }
            } while (Answer != 3);

            Console.WriteLine("Bye bye then...");
        }

        private static void GameSettings()
        {
            Console.WriteLine(@"---Game Settings:---
    - Sound
    - Display
    - Load
    - Save
    - Exit");
        }

        private static void PlayGame()
        {
            int CurrentRound = 1;

            // Create an object using random for computer's choice

            Random RandomGenerator = new Random();

            /*
                 * 
                 * State Table
                 * 
                 * User + Computer -> Result
                 * r + r -> draw
                 * r + p -> computer
                 * r + s -> user
                 * p + r -> user
                 * p + p -> draw
                 * p + s -> computer
                 * s + r -> computer
                 * s + p -> user
                 * s + s -> draw
            */

            var GameStateDictionary = new Dictionary<string, GameResult>
            {
                // %user choice%%computer choice% -> result
                {  "rr", GameResult.Draw },
                {  "rp", GameResult.ComputerWins },
                {  "rs", GameResult.UserWins },
                {  "pr", GameResult.UserWins },
                {  "pp", GameResult.Draw },
                {  "ps", GameResult.ComputerWins },
                {  "sr", GameResult.ComputerWins },
                {  "sp", GameResult.UserWins },
                {  "ss", GameResult.Draw }
            };

            // Set up the game loop using "for"

            for (; ;)
            {
                Console.WriteLine("This is round: " + CurrentRound);

                Console.WriteLine("Please enter your choice: [r]ock [p]aper or [s]cissors?");

                var userChoice = Console.ReadLine();

                System.Threading.Thread.Sleep(600);

                if (userChoice == "r")
                {
                    Console.WriteLine("You chose Rock" + @"  
   _______
----  ' ____)
      (_____)
      (_____)
      (____)
----._(___)");
                }

                else if (userChoice == "p")
                {
                    Console.WriteLine("You chose Paper" + @"
       _______
-- - '    ____)___
           ______)
          _______)
         _______)
---.__________)");
                }

                else if (userChoice == "s")
                {
                    Console.WriteLine("You chose Scissors" + @"
    _______
-- -     ___)___
          ______)
       __________)
      (____)
--.__(___)");
                }

                else if (userChoice != "r" && userChoice != "p" && userChoice != "s")
                {
                    Console.WriteLine("Error! Please learn to read, and try once more...");
                    continue;
                }

                System.Threading.Thread.Sleep(1000);

                var ComputerChoice = (new string[] { "r", "p", "s" })[RandomGenerator.Next(0, 2)];

                // rp or rr or sr depending on user and computer choices
                var ChoiceSelector = userChoice + ComputerChoice;

                var Result = GameStateDictionary[ChoiceSelector];

                if (ComputerChoice == "r")
                    {
                    Console.WriteLine("Computer chose Rock" + @"  
    _______
----  ' ____)
      (_____)
      (_____)
      (____)
----._(___)");
                    }
                else if (ComputerChoice == "p")
                    {
                    Console.WriteLine("Computer chose Paper" + @"       
      _______
-- - '    ____)___
           _______)
          _______)
         _______)
---.__________)");
                    }
                else if (ComputerChoice == "s")
                {
                    Console.WriteLine("Computer chose Scissors" + @" 
    ____ __
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)");
                }

                System.Threading.Thread.Sleep(1000);

                // Draw

                if (Result == GameResult.Draw)
                {
                    Console.WriteLine("This is a DRAW! Try again...");
                }

                // Computer wins

                else if (Result == GameResult.ComputerWins)
                {
                    Console.WriteLine("Computer WINS !!! Machines will take over the world...");
                    break;
                }

                // User wins

                else
                {
                    Console.WriteLine("You WIN !!! Machines will take over another day...");
                    break;
                }
                
                // Go to Next Round
                CurrentRound++;
            }
        }
    }

}
