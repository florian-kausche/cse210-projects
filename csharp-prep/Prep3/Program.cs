using System;

class Program
{
    static void Main(string[] args)
    {
        {
        Random random = new Random(); 
        string playAgain = "yes"; 

        
        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = random.Next(1, 101); 
            int guess = -1; 
            int numberOfGuesses = 0; 

            Console.WriteLine("Guess My Number Game!");

            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                numberOfGuesses++; 

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
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {numberOfGuesses} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine(); 
        }

        Console.WriteLine("Thanks for playing!"); 
    }
    }
}