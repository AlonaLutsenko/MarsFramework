using AT.Selenium.Elements.Products;
using AT.Selenium.Elements.Products.Clothing;

namespace AT.Selenium.Factories.Products
{
    public class ClothingProductFactory : IProductFactory
    {
        public IProduct CreateProduct(string name, double price)
        {
            Console.WriteLine($"Creating 'Clothing' object: {name}.");
            return new ClothingProduct(name, price);
        }

        public IProductDetailsPage CreateProductDetailsPage()
        {
            Console.WriteLine("Creating details page for clothing.");
            return new ClothingDetailsPage();
        }

        public IProductCard CreateProductCard()
        {
            Console.WriteLine("Creating product card for clothing.");
            return new ClothingProductCard();
        }
    }
}
