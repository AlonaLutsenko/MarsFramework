namespace AT.Selenium.Elements.Products.Clothing
{
    public class ClothingProduct : IProduct
    {
        private readonly string _name;
        private readonly double _price;

        public ClothingProduct(string name, double price)
        {
            _name = name;
            _price = price;
        }

        public string GetName() => _name;
        public double GetPrice() => _price;

        public void DisplayInfo()
        {
            Console.WriteLine($"Clothe: '{_name}', Price: {_price:C}");
        }
    }
}
