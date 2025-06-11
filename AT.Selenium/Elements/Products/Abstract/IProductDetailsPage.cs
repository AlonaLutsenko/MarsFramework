namespace AT.Selenium.Elements.Products.Abstract
{
    public interface IProductDetailsPage
    {
        void NavigateTo(string productId);
        string GetDisplayedProductName();
        double GetDisplayedProductPrice();
        void SelectSize(string size);
        void AddToCart();
        void VerifyElementsPresent();
    }
}
