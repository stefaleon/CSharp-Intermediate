using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testability.UnitTests
{
    [TestClass]
    public class OrderProcessorTests
    {
        // testmethod naming convention
        // METHODNAME_CONDITION_EXPECTATION

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderAlreadyShipped_ThrowsException()
        {
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            // Create a shipped order, one with the Shipment property initialized
            var order = new Order {         
                Shipment = new Shipment()
            };

            orderProcessor.Process(order);
        }

        [TestMethod]        
        public void Process_OrderNotShipped_SetTheShipmentProperty()
        {
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            var order = new Order(); // Shipment property is not initialized            

            orderProcessor.Process(order);

            // calling Process initializes the Shipment property
            // so we should assert that the order is now shipped
            Assert.IsTrue(order.isShipped);

            // Assert.AreEqual(Expected, Actual)

            // FakeShippingCalculator returns 1
            // so the shipment cost of the order should be equal to 1            
            Assert.AreEqual(1, order.Shipment.Cost);
            // and the shipping date should be tomorrow
            Assert.AreEqual(DateTime.Now.AddDays(1).Day, order.Shipment.ShippingDate.Day);
        }
    }
    
    public class FakeShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            return 1;
        }
    }
}
