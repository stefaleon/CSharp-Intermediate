using System;

namespace VirtualAbstractOverride
{
    partial class Program
    {
        public class Square : Shape
        {
            // no implementation for Copy

            // required implementation for Move, since abstract in base class
            public override void Move()
            {
                Console.WriteLine("Moving a square.");
            }
        }
    }
}
