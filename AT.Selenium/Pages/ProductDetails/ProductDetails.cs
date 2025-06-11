using OpenQA.Selenium;

namespace AT.Selenium.Pages.ProductDetails
{
    public class ProductDetails : BasePage
    {
        private readonly By productNameElement = By.XPath("//div[@id='product-name']");
        private readonly By addToCartButton = By.Id("add-to-cart-button");

        public ProductDetails()
        {
        }

        public string GetProductName()
        {
            var productName = WaitForElementIsVisible(productNameElement);
            return productName.Text;
        }

        public void ClickAddToCart() =>
            WaitForElementToBeClickable(addToCartButton).Click();
    }
}