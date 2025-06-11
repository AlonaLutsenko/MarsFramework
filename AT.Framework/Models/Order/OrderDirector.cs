namespace AT.Framework.Models.Order
{
    public class OrderDirector
    {
        private readonly IOrderBuilder _builder;

        public OrderDirector(IOrderBuilder builder)
        {
            _builder = builder;
        }

        public void BuildStandardOrder(string customerId, List<OrderItem> items, string paymentMethod)
        {
            _builder.SetCustomerId(customerId);
            foreach (var item in items)
            {
                _builder.AddItem(item.ProductId, item.ProductName);
            }
            _builder.SetPaymentMethod(paymentMethod);
        }

        public void BuildGiftOrder(string customerId, List<OrderItem> items, string paymentMethod)
        {
            _builder.SetCustomerId(customerId);
            foreach (var item in items)
            {
                _builder.AddItem(item.ProductId, item.ProductName);
            }
            _builder.SetPaymentMethod(paymentMethod);
        }
    }
}
