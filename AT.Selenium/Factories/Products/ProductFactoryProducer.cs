using AT.Selenium.Common.Enums;
using AT.Selenium.Factories.Abstract;

namespace AT.Selenium.Factories.Products
{
    public static class ProductFactoryProducer
    {
        public static IProductFactory GetFactory(ProductCategory category)
        {
            switch (category)
            {
                case ProductCategory.Clothing:
                    Console.WriteLine("Selected factory for clothing.");
                    return new ClothingProductFactory();
                case ProductCategory.Accessory:
                    Console.WriteLine("Selected factory for accessories.");
                    return new AccessoryProductFactory();
                default:
                    throw new ArgumentException($"Product category '{category}' is not supported.");
            }
        }
    }
}
