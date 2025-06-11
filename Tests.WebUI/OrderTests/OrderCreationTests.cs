using AT.Framework;
using AT.Framework.Models.Order;
using AT.Framework.Services;
using NUnit.Framework;

namespace Tests.WebUI.OrderTests
{
    [TestFixture]
    public class OrderCreationTests : TestBase
    {
        private readonly NotificationService _notificationService = NotificationService.GetInstance();

        [Test]
        public void VerifySimpleOrderCreation()
        {
            IOrderBuilder builder = new OnlineOrderBuilder();
            Order simpleOrder = builder
                .SetCustomerId("CUSTOMER-A")
                .AddItem("PROD-001", "Basic T-Shirt")
                .SetPaymentMethod("Card")
                .Build();

            simpleOrder.DisplayOrderDetails();
            Assert.That(simpleOrder.CustomerId, Is.EqualTo("CUSTOMER-A"));
            Assert.That(simpleOrder.Items.Count, Is.EqualTo(1));
            Assert.That(simpleOrder.Items[0].ProductName, Is.EqualTo("Basic T-Shirt"));

            _notificationService.SendEmail(
                "customer-a@example.com",
                $"Order #{simpleOrder.OrderId} Confirmation",
                $"Dear Customer, your order for '{simpleOrder.Items[0].ProductName}' has been placed."
            );

            _notificationService.SendPushNotification(
                simpleOrder.CustomerId,
                $"Your order #{simpleOrder.OrderId} is now being processed."
            );
        }
    }
}
