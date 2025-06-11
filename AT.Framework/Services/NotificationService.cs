namespace AT.Framework.Services
{
    public sealed class NotificationService
    {
        private static NotificationService? _instance = null;
        private static readonly object _lock = new();

        private NotificationService()
        {
            Console.WriteLine("NotificationService: Initializing notification service.");
            Console.WriteLine("NotificationService: Notification service is ready.");
        }

        public static NotificationService GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance ??= new NotificationService();
                }
            }
            return _instance;
        }

        public void SendEmail(string recipientEmail, string subject, string body)
        {
            Console.WriteLine($"[EMAIL] Sending email to: {recipientEmail}");
            Console.WriteLine($"[EMAIL] Subject: {subject}");
            Console.WriteLine($"[EMAIL] Body: {body}");
            Thread.Sleep(100);
            Console.WriteLine($"[EMAIL] Email sent to {recipientEmail}.");
        }

        public void SendPushNotification(string userId, string message)
        {
            Console.WriteLine($"[PUSH] Sending push notification to user: {userId}");
            Console.WriteLine($"[PUSH] Message: {message}");
            Thread.Sleep(20);
            Console.WriteLine($"[PUSH] Push notification sent to user {userId}.");
        }

        public void RunExample()
        {
            NotificationService notifier1 = GetInstance();
            Console.WriteLine("notifier1 obtained.");

            NotificationService notifier2 = GetInstance();
            Console.WriteLine("notifier2 obtained.");

            SendEmail("user@example.com", "Order Confirmation", "Your order #123 has been successfully placed.");
            SendPushNotification("user_12345", "New promotions are waiting for you!");
        }
    }
}
