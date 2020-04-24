using System;
using System.Collections.Generic;

namespace MJQuadaxDemo
{
    class Program
    {
        //start time 4/24/2020 4:40 pm
        public static string playerName;
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter your name:");
            playerName = Console.ReadLine();

            // game Menu
            Console.WriteLine("Welcome "+playerName+" to Quadax Master Mind Game");
            Console.WriteLine("Created By Mohammed alJAser");
            Console.WriteLine(" ");
            Console.WriteLine("Here are the rules:");
            Console.WriteLine("The game will generate four random digits between 1-6");
            Console.WriteLine("you will need to guess the correct four digits");
            Console.WriteLine("a Minus (-) sign will appear if you guessed the correct digit, but the wrong position");
            Console.WriteLine("a Plus (+) sign will appear if you guessed the correct digit and the correct position");
            Console.WriteLine("Nothing will show if did not guess a corecct digit");
            Console.WriteLine("There are only 10 chances to guess");
            Console.WriteLine(" ");
            ReadyToPlay();

       
            Console.ReadKey();
        }

        private static void ReadyToPlay()
        {
            Console.Write("Let's play, " + playerName+", ");
            Console.WriteLine("Are you ready? y/n");
            var input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                ReadMind();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private static void ReadMind()
        {
            List<int> randomDigits = new List<int>();
            int[] PlayerDigits = new int[4];
            randomDigits = GenerateRandomDigits();
            string[] guesses = new string[4];
            int attempts = 10;
            while (attempts >= 0)
            {
                PlayerDigits = PlayerPicks();
                // To match the picks
                guesses = CheckDigits(randomDigits, PlayerDigits);
                // To diplay the result
                Result(guesses, attempts, randomDigits);
                attempts -= 1; 
            }

        }

        private static List<int> GenerateRandomDigits()
        {
            Random digitGenerator = new Random();
            List<int> randomDigits = new List<int>();
            int random;
            while (randomDigits.Count < 4)
            {
                random = digitGenerator.Next(1, 7);
                if (!randomDigits.Contains(random))
                {
                    randomDigits.Add(random);
                }
            }

            return randomDigits;
        }
        private static int[] PlayerPicks()
        {
            int[] playerDigits = new int[4];
            int Guess;
            Console.WriteLine("Pick a digit between 1-6");
            for (int i = 0; i < 4; ++i)
            {
                Console.WriteLine("type your guess:");
                try
                {
                     Guess = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException fex)
                {
                    Console.WriteLine("Error Please type the correct format");
                    Console.WriteLine("type your guess:");
                    Guess = Convert.ToInt32(Console.ReadLine());
                }

                if (Guess <1 || Guess > 6)
                {
                    while(Guess < 1 || Guess > 6)
                    {
                        Console.WriteLine("ERROR: your guess should be between 1 and 6. Please try again");
                        Console.WriteLine("type yout  guess: ");
                        try
                        {
                            Guess = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException fex)
                        {
                            Console.WriteLine("Error Please type the correct format");
                            Console.WriteLine("type your guess:");
                            Guess = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                }

                playerDigits[i] = Guess;
            }
            Console.WriteLine("Your Guess:");
            Console.WriteLine(playerDigits[0] + "," + playerDigits[1] + "," + playerDigits[2] + "," + playerDigits[3]);
            return playerDigits;
        }
        private static string[] CheckDigits(List<int> randomDigits, int[] PlayerDigits)
        {
            string[] signs = new string[4];
            for (int p = 0; p < PlayerDigits.Length; ++p)
            {
                for (int r = 0; r <= randomDigits.Count - 1; ++r)
                {
                    if (PlayerDigits[p] == randomDigits[r])
                    {
                        // If there is a match at the same position
                        if (p == r)
                        {
                            signs[p] = "+";
                            break; 
                        }
                        // If there is a match at the different position
                        else
                        {
                            signs[p] = "-";
                            break;
                        }
                    }
                    else
                    {
                        signs[p] = " ";
                    }
                }
            }
            Console.WriteLine("Matches:");
            Console.WriteLine(signs[0] + "," + signs[1] + "," + signs[2] + "," + signs[3]);
            return signs;
        }

        private static void Result(string[] checks, int attempts, List<int> randomDigit)
        {
            if (checks[0] == "+" && checks[1] == "+" && checks[2] == "+" && checks[3] == "+")
            {
                Console.WriteLine("You got it right this time with "+ attempts+ " attempt(s) remaining");
                Console.WriteLine(" ");
                PlayAgain();
            }
            else if (attempts == 1)
            {
                Console.WriteLine("Your last chance");
                Console.WriteLine(" ");
            }
            else if (attempts == 0)
            {
                Console.WriteLine("You lost");
                Console.Write("The digits were:");
                Console.WriteLine(randomDigit[0] + "," + randomDigit[1] + "," + randomDigit[2] + "," + randomDigit[3]);
                Console.WriteLine(" ");
                PlayAgain();
            }
            else
            {
                Console.WriteLine("Try again!!");
                Console.WriteLine("You have " + attempts + " attempt(s) left.");
                Console.WriteLine(" ");

            }
        }

        private static void PlayAgain()
        {
            Console.WriteLine("Do you want to play again? y/n");
            var input = Console.ReadLine();
            if (input.ToUpper() == "Y")
            {
                Console.Clear();
                ReadMind();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}

