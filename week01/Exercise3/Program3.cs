using System;

class Program
{
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Step 1: Ask the user for the magic number
            Console.Write("Enter the magic number to guess (1-100): ");
            int magicNumber = int.Parse(Console.ReadLine());

            int guess = 0;
            int guessCount = 0;

            Console.WriteLine("Try to guess the magic number!");

            // Step 2: Loop until the guess matches the magic number
            while (guess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {guessCount} guesses.");
                }
            }

            // Step 3: Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();
            playAgain = (response == "yes");
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}