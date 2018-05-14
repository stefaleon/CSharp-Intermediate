using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Stop();  // no can do
            watch.Start();   // start watch          
            Thread.Sleep(1000); // wait 1 sec
            watch.Start(); // no can do
            watch.Stop();  // stop
            System.Console.WriteLine($"{watch.GetDuration().Seconds.ToString()} seconds have passed.");
            watch.Start(); // start again
            Thread.Sleep(2000); // wait 2 secs
            watch.Stop(); // stop
            System.Console.WriteLine($"{watch.GetDuration().Seconds.ToString()} seconds have passed.");
        }
    }
}
