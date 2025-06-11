using AT.Selenium.Elements.Products;

namespace AT.Selenium.Factories
{
    public interface IProductFactory
    {
        IProduct CreateProduct(string name, double price);

        IProductDetailsPage CreateProductDetailsPage();

        IProductCard CreateProductCard();
    }
}
