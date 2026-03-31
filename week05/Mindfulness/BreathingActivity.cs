public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing", "Relax by breathing slowly.") { }

    public override void Run()
    {
        StartMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);

            Console.WriteLine("Breathe out...");
            Countdown(3);
        }

        EndMessage();
    }
}