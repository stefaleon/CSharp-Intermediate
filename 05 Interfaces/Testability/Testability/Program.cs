using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testability
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderProcessor = new OrderProcessor(new ShippingCalculator());
            var order = new Order { DatePlaced = DateTime.Now, TotalPrice = 100f };
            orderProcessor.Process(order);

            Console.WriteLine("=========================================================================");
            Console.WriteLine("In order to unit test a class, we need to isolate it.\n");
            Console.WriteLine("So in order to test the OrderProcessor class,");
            Console.WriteLine("it has to be isolated from the concrete ShippingCalculator class.\n");
            Console.WriteLine("It can be loosely coupled with the IShippingCalculator interface instead.");
            Console.WriteLine("=========================================================================");
        }
    }
}
