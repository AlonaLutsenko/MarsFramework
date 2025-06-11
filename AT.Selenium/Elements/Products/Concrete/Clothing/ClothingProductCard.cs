using AT.Selenium.Elements.Products.Abstract;

namespace AT.Selenium.Elements.Products.Concrete.Clothing
{
    public class ClothingProductCard : IProductCard
    {
        public void ClickProductLink()
        {
            Console.WriteLine("Clicking on the 'Clothing' product card.");
        }

        public string GetCardName()
        {
            Console.WriteLine("Getting the name of the 'Clothing' product from the card.");
            return "Stylish sweater";
        }

        public double GetCardPrice()
        {
            Console.WriteLine("Getting the price of the 'Clothing' product from the card.");
            return 49.99;
        }

        public void AddToWishlist()
        {
            Console.WriteLine("Adding clothing to wishlist.");
        }
    }
}
