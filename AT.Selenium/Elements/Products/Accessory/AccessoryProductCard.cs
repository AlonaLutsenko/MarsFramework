namespace AT.Selenium.Elements.Products.Accessory
{
    public class AccessoryProductCard : IProductCard
    {
        public void ClickProductLink()
        {
            Console.WriteLine("Clicking on the 'Accessory' product card.");
        }

        public string GetCardName()
        {
            Console.WriteLine("Getting the name of the 'Accessory' product from the card.");
            return "Fashionable scarf";
        }

        public double GetCardPrice()
        {
            Console.WriteLine("Getting the price of the 'Accessory' product from the card.");
            return 15.00;
        }
    }
}
