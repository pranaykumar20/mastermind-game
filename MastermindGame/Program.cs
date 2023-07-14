using System;

namespace MastermindGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!");

            // Generate a random answer
            Random random = new Random();
            int[] answer = new int[4];
            for (int i = 0; i < 4; i++)
            {
                answer[i] = random.Next(1, 7);
            }

            int attempts = 10;
            bool hasWon = false;

            while (attempts > 0 && !hasWon)
            {
                Console.WriteLine($"You have {attempts} attempts remaining.");

                // Get player's guess
                Console.Write("Enter your guess (4 digits between 1 and 6): ");
                string input = Console.ReadLine();

                // Validate the input
                if (input.Length != 4)
                {
                    Console.WriteLine("Invalid input. Please enter 4 digits.");
                    continue;
                }

                int[] guess = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    if (!int.TryParse(input[i].ToString(), out guess[i]) || guess[i] < 1 || guess[i] > 6)
                    {
                        Console.WriteLine("Invalid input. Please enter digits between 1 and 6.");
                        continue;
                    }
                }

                // Compare the guess with the answer
                int plusCount = 0;
                int minusCount = 0;
                bool[] usedAnswerDigits = new bool[4];
                bool[] usedGuessDigits = new bool[4];

                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] == answer[i])
                    {
                        plusCount++;
                        usedAnswerDigits[i] = true;
                        usedGuessDigits[i] = true;
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (usedGuessDigits[i])
                    {
                        continue;
                    }

                    for (int j = 0; j < 4; j++)
                    {
                        if (guess[i] == answer[j] && !usedAnswerDigits[j])
                        {
                            minusCount++;
                            usedAnswerDigits[j] = true;
                            break;
                        }
                    }
                }

                // Print the feedback
                for (int i = 0; i < plusCount; i++)
                {
                    Console.Write("+");
                }

                for (int i = 0; i < minusCount; i++)
                {
                    Console.Write("-");
                }

                Console.WriteLine();

                if (plusCount == 4)
                {
                    hasWon = true;
                }

                attempts--;
            }

            if (hasWon)
            {
                Console.WriteLine("Congratulations! You've won!");
            }
            else
            {
                Console.WriteLine("You've run out of attempts. Game over!");
                Console.WriteLine("The answer was: " + string.Join("", answer));
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}