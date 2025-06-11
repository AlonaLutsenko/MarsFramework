using AT.Selenium.Elements.Products.Abstract;

namespace AT.Selenium.Elements.Products.Concrete.Accessory
{
    public class AccessoryDetailsPage : IProductDetailsPage
    {
        public void NavigateTo(string productId)
        {
            Console.WriteLine($"Navigating to accessory details page for Product ID: {productId}");
        }

        public string GetDisplayedProductName()
        {
            Console.WriteLine("Getting accessory product name from the page.");
            return "Leather belt";
        }

        public double GetDisplayedProductPrice()
        {
            Console.WriteLine("Getting accessory product price from the page.");
            return 19.50;
        }

        public void SelectSize(string size)
        {
            Console.WriteLine($"Selecting accessory size/option (e.g., length): {size}");
        }

        public void AddToCart()
        {
            Console.WriteLine("Adding accessory to cart.");
        }

        public void VerifyElementsPresent()
        {
            Console.WriteLine("Verifying presence of elements on accessory details page (material, color).");
        }
    }
}
