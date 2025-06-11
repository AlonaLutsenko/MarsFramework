using AT.Selenium.Elements.Products;
using AT.Selenium.Elements.Products.Accessory;

namespace AT.Selenium.Factories.Products
{
    public class AccessoryProductFactory : IProductFactory
    {
        public IProduct CreateProduct(string name, double price)
        {
            Console.WriteLine($"Creating 'Accessory' object: {name}.");
            return new AccessoryProduct(name, price);
        }

        public IProductDetailsPage CreateProductDetailsPage()
        {
            Console.WriteLine("Creating details page for accessory.");
            return new AccessoryDetailsPage();
        }

        public IProductCard CreateProductCard()
        {
            Console.WriteLine("Creating product card for accessory.");
            return new AccessoryProductCard();
        }
    }
}
