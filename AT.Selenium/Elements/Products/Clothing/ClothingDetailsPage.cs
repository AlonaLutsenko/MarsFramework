namespace AT.Selenium.Elements.Products.Clothing
{
    public class ClothingDetailsPage : IProductDetailsPage
    {
        public void NavigateTo(string productId)
        {
            Console.WriteLine($"Go to the clothing details page for Product ID: {productId}");

        }

        public string GetDisplayedProductName()
        {
            Console.WriteLine("Get the name of the clothing product from the page.");
            return "T-shirt 'Summer'";
        }

        public double GetDisplayedProductPrice()
        {
            Console.WriteLine("Get the price of a clothing product from the page.");
            return 29.99;
        }

        public void SelectSize(string size)
        {
            Console.WriteLine($"Choosing a clothing size: {size}");

        }

        public void AddToCart()
        {
            Console.WriteLine("Add clothes to the cart.");

        }

        public void VerifyElementsPresent()
        {
            Console.WriteLine("Check the availability of items on the garment details page (size, color, image, description)");

        }
    }
}
