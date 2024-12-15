public class Program
{
    public static void Main()
    {
        Stopwatch stopwatch = new Stopwatch();

        // Subscribe to events
        stopwatch.OnStarted += message => Console.WriteLine($"\n{message}");
        stopwatch.OnStopped += message => Console.WriteLine($"\n{message}");
        stopwatch.OnReset += message => Console.WriteLine($"\n{message}");

        Console.WriteLine("Press S to Start, T to Stop, R to Reset:");

        while (true)
        {
            string input = Console.ReadLine()?.ToUpper();

            switch (input)
            {
                case "S":
                    stopwatch.Start();
                    break;
                case "T":
                    stopwatch.Stop();
                    break;
                case "R":
                    stopwatch.Reset();
                    break;
                default:
                    Console.WriteLine("Invalid input. Use S, T, or R.");
                    break;
            }
        }
    }
}
