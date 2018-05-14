using System;

namespace Stopwatch
{
    public class Stopwatch
    {        
        private DateTime _startTime = new DateTime();
        private DateTime _stopTime = new DateTime();
        private bool _isRunning = false;


        public void Start()
        {
            if (_isRunning)
            {
                Console.WriteLine((new InvalidOperationException("Stopwatch has already started!").Message.ToString()));
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();                
            }
            else
            {
                _startTime = DateTime.Now;
                _isRunning = true;
                Console.WriteLine("Started.");
            }
        }


        public void Stop()
        {
            if (!_isRunning)
            {
                Console.WriteLine((new InvalidOperationException("Stopwatch has not started!").Message.ToString()));
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                _stopTime = DateTime.Now;
                _isRunning = false;
                Console.WriteLine("Stopped.");
            }
        }

        public TimeSpan GetDuration()
        {            
            return _stopTime - _startTime;
        }

    }
}
