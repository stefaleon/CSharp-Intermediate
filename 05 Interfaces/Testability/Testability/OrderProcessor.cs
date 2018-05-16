using System;

namespace Testability
{
    public class OrderProcessor
    {
        //private readonly ShippingCalculator _shippingCalculator;
        // The OrderProcessor class should not depend on the concrete ShippingCalculator class.
        // In order to unit test a class, we need to isolate it.
        // Refactor in order to depend on an IShippingCalculator interface.
        private readonly IShippingCalculator _shippingCalculator;

        //public OrderProcessor()
        //{
        //    _shippingCalculator = new ShippingCalculator();
        //}
        // The commented-out constructor above depends on a ShippingCalculator instance.
        // Refactor as below and initialize the _shippingCalculator field
        // by passing an IShippingCalculator parameter to the constructor.
        public OrderProcessor(IShippingCalculator shippingCalculator)
        {
            _shippingCalculator = shippingCalculator;
        }

        public void Process(Order order)
        {
            if (order.isShipped)
                throw new InvalidOperationException("This order is already processed.");

            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),
                ShippingDate = DateTime.Today.AddDays(1)
            };
        }
    }
}
