namespace AT.Framework.Models.Order
{
    public class Order
    {
        public string OrderId { get; private set; }
        public string CustomerId { get; private set; }
        public string PaymentMethod { get; private set; }
        public List<OrderItem> Items { get; private set; }

        public Order(string orderId, string customerId, string paymentMethod)
        {
            OrderId = orderId;
            CustomerId = customerId;
            PaymentMethod = paymentMethod;
            Items = new List<OrderItem>();
        }

        public void SetItems(List<OrderItem> items) => Items = items ?? new List<OrderItem>();
        public void SetPaymentMethod(string method) => PaymentMethod = method;

        public void DisplayOrderDetails()
        {
            Console.WriteLine($"\n--- Order Details (Order ID: {OrderId}) ---");
            Console.WriteLine($"Customer ID: {CustomerId}");
            Console.WriteLine($"Payment Method: {PaymentMethod ?? "Not specified"}");

            if (Items.Any())
            {
                Console.WriteLine("Items:");
                foreach (var item in Items)
                {
                    Console.WriteLine($"- {item.ProductName}");
                }
            }
            else
            {
                Console.WriteLine("No items in this order.");
            }
        }
    }
}
