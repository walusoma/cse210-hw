using System;

class Program
{
    static int totalActivities = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness Menu:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Quit");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1": activity = new BreathingActivity(); break;
                case "2": activity = new ReflectionActivity(); break;
                case "3": activity = new ListingActivity(); break;
                case "4": return;
                default:
                    Console.WriteLine("Invalid choice");
                    continue;
            }

            activity.Run();
            totalActivities++;

            Console.WriteLine($"Total activities completed: {totalActivities}");
        }
    }
}