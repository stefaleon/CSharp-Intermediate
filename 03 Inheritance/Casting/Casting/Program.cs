using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 2147483647;
            double d = 3.141592;
            int k = 7;

            Console.WriteLine($"i={i}, d={d}, k={k}");

            //d = i;
            k = (int)d; // decimal digits values are lost with the cast
            d = i; // implicitly casting double to int

            Console.WriteLine($"i={i}, d={d}, k={k}");
                       

        }
    }
}
