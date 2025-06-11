using AT.Framework;
using AT.Selenium.Common.Enums;
using AT.Selenium.Factories.Products;
using NUnit.Framework;
using Tests.WebUI.TestClients;

namespace Tests.WebUI.ProductTests
{
    [TestFixture]
    public class ProductCatalogTests : TestBase
    {
        [Test]
        public void VerifyClothingProductWorkflow()
        {
            var clothingFactory = ProductFactoryProducer.GetFactory(ProductCategory.Clothing);
            var clothingClient = new StoreTestClient(clothingFactory);

            clothingClient.TestProductWorkflow("T-shirt 'CoolPrint'", 25.50, "M", "product_clothing_test_id");
        }

        [Test]
        public void VerifyAccessoryProductWorkflow()
        {
            var accessoryFactory = ProductFactoryProducer.GetFactory(ProductCategory.Accessory);
            var accessoryClient = new StoreTestClient(accessoryFactory);

            accessoryClient.TestProductWorkflow("Wristwatch", 150.00, "Standard", "product_accessory_test_id");
        }
    }
}
