using System;

// Creativity: Added a level-up system where the player gains a new level
// every 500 points earned. This adds extra gamification beyond requirements.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}