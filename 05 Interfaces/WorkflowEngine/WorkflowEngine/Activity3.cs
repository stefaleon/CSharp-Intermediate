using System;

namespace WorkflowEngine
{
    internal class Activity3 : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Activity3: Boiling an egg...");
        }
    }
}