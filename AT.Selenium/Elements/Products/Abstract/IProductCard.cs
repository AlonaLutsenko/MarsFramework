namespace AT.Selenium.Elements.Products.Abstract
{
    public interface IProductCard
    {
        void ClickProductLink();
        string GetCardName();
        double GetCardPrice();
        void AddToWishlist();
    }
}
