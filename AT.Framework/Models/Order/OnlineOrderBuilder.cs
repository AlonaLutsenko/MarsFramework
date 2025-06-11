namespace AT.Framework.Models.Order
{
    public class OnlineOrderBuilder : IOrderBuilder
    {
        private Order _order = null!;

        public OnlineOrderBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            _order = new Order(Guid.NewGuid().ToString(), "unknown_customer", "unknown_payment_method");
        }

        public IOrderBuilder SetOrderId(string orderId)
        {
            _order = new Order(orderId, _order.CustomerId, _order.PaymentMethod);
            return this;
        }

        public IOrderBuilder SetCustomerId(string customerId)
        {
            _order = new Order(_order.OrderId, customerId, _order.PaymentMethod);
            return this;
        }

        public IOrderBuilder AddItem(string productId, string productName)
        {
            _order.Items.Add(new OrderItem
            {
                ProductId = productId,
                ProductName = productName,
            });
            return this;
        }

        public IOrderBuilder SetPaymentMethod(string method)
        {
            _order.SetPaymentMethod(method);
            return this;
        }

        public Order Build()
        {
            if (string.IsNullOrEmpty(_order.CustomerId) || !_order.Items.Any())
            {
                throw new InvalidOperationException("Order must have a customer ID and at least one item.");
            }

            Order finalOrder = _order;
            Reset();
            return finalOrder;
        }
    }
}
