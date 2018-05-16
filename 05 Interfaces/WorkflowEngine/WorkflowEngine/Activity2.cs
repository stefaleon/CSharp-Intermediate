using System;

namespace WorkflowEngine
{
    public class Activity2 : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Activity2: Making some noise...");
        }
    }
}
