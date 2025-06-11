using AT.Selenium.Elements.Products.Abstract;

namespace AT.Selenium.Factories.Abstract
{
    public interface IProductFactory
    {
        IProduct CreateProduct(string name, double price);

        IProductDetailsPage CreateProductDetailsPage();

        IProductCard CreateProductCard();
    }
}
