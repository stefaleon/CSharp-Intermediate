using System;

namespace VirtualAbstractOverride
{
    partial class Program
    {
        public class Circle : Shape
        {
            //override the virtual Copy from base class
            public override void Copy()
            {
                Console.WriteLine("Copying a circle.");                
            }

            // required implementation for Move, since abstract in base class
            public override void Move()
            {
                Console.WriteLine("Moving a circle.");
            }
        }
    }
}
