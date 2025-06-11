using AT.Selenium.Common.Enums;
using AT.Selenium.Elements.Products;
using AT.Selenium.Factories;
using AT.Selenium.Factories.Products;

namespace Tests.WebUI.TestClients
{
    public class StoreTestClient
    {
        private readonly IProductFactory _factory;

        public StoreTestClient(IProductFactory factory)
        {
            _factory = factory;
        }

        public void TestProductWorkflow(string productName, double productPrice, string sizeToSelect, string productId)
        {
            IProduct product = _factory.CreateProduct(productName, productPrice);
            product.DisplayInfo();
            Console.WriteLine($"Expected name: {product.GetName()}, Expected price: {product.GetPrice()}");

            IProductCard productCard = _factory.CreateProductCard();

            Console.WriteLine($"Received name from card: {productCard.GetCardName()}, Received price from card: {productCard.GetCardPrice()}");
            
            productCard.ClickProductLink();

            IProductDetailsPage detailsPage = _factory.CreateProductDetailsPage();
            detailsPage.NavigateTo(productId);
            detailsPage.VerifyElementsPresent();

            Console.WriteLine($"Received name from details page: {detailsPage.GetDisplayedProductName()}, Received price from details page: {detailsPage.GetDisplayedProductPrice()}");
            
            detailsPage.SelectSize(sizeToSelect);
            detailsPage.AddToCart();
        }

        public static void RunExample()
        {
            IProductFactory clothingFactory = ProductFactoryProducer.GetFactory(ProductCategory.Clothing);
            StoreTestClient clothingClient = new StoreTestClient(clothingFactory);
            clothingClient.TestProductWorkflow("Polo T-shirt", 35.00, "L", "product_clothing_1");

            IProductFactory accessoryFactory = ProductFactoryProducer.GetFactory(ProductCategory.Accessory);
            StoreTestClient accessoryClient = new StoreTestClient(accessoryFactory);
            accessoryClient.TestProductWorkflow("Sunglasses", 50.00, "One Size", "product_accessory_2");
        }
    }
}
