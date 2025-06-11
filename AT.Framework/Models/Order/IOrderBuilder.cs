namespace AT.Framework.Models.Order
{
    public interface IOrderBuilder
    {
        IOrderBuilder SetOrderId(string orderId);
        IOrderBuilder SetCustomerId(string customerId);
        IOrderBuilder AddItem(string productId, string productName);
        IOrderBuilder SetPaymentMethod(string method);
        Order Build(); 
    }
}
