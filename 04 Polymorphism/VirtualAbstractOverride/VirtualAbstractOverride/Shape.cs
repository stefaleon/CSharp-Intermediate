using System;

namespace VirtualAbstractOverride
{
    partial class Program
    {
        public abstract class Shape
        {
            public int Width { get; set; }
            public int Height { get; set; }

            public virtual void Copy()
            {
                Console.WriteLine("Copying a shape.");
            }

            public abstract void Move(); // declared only, no body, must be implemented in each child
        }
    }
}
