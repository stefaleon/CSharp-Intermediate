using System;

namespace VirtualAbstractOverride
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //var s = new Shape(); // Cannot create an instance of the abstract class
            var sq = new Square();
            sq.Width = 42; // inherited property from Shape
            Console.WriteLine($"Square width: {sq.Width}");
            sq.Copy(); // not implemented in Square, calling the virtual method from Shape
            sq.Move(); // necessarily implemented because it is declared abstract in Shape
            var c = new Circle();
            c.Width = 13;  // inherited property from Shape
            Console.WriteLine($"Circle width: {c.Width}");
            c.Copy(); // implemented in Circle, overrides the virtual method in Shape  
            c.Move(); // necessarily implemented because it is declared abstract in Shape

        }
    }
}
