using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101);
        int guess = 0;

        Console.WriteLine("Guess the magic number between 1 and 100!");

        while (guess != magicNumber)
        {
            Console.Write("Enter your guess: ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
                Console.WriteLine("Higher");
            else if (guess > magicNumber)
                Console.WriteLine("Lower");
            else
                Console.WriteLine("You guessed it!");
        }
    }
}