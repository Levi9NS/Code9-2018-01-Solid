using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Solid05.DIP.Models;

namespace Solid05.DIP.Services
{
    public class ClientNotificationService : IClientNotificationService
    {
        public async Task NotifyClientAboutOrder(OrderModel order, double amount)
        {
            var message = new MailMessage
            {
                Subject = "Your order #" + order.OrderId,
                Body = "Your order will arrive soon, your credit card is charged for $" + amount.ToString("0.00")
            };
            message.To.Add(order.Orderer.Email);
            message.Sender = new MailAddress("bestretailer@example.com");
            var mailClient = new SmtpClient("smtp.example.com", 456);
            mailClient.Credentials = new NetworkCredential("smpt-user", "smtp-pass");
            await mailClient.SendMailAsync(message);
        }
    }
}
