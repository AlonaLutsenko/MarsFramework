using AT.Selenium.Elements.Products.Abstract;

namespace AT.Selenium.Elements.Products.Concrete.Accessory
{
    public class AccessoryProduct : IProduct
    {
        private readonly string _name;
        private readonly double _price;

        public AccessoryProduct(string name, double price)
        {
            _name = name;
            _price = price;
        }

        public string GetName() => _name;
        public double GetPrice() => _price;

        public void DisplayInfo()
        {
            Console.WriteLine($"Accessory: '{_name}', Price: {_price:C}");
        }
    }
}
