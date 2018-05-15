using Solid01.SRP.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Solid01.SRP.Services
{
    class NotificationService
    {
        public static async Task SendEmailForOrder(OrderModel order, double totalPrice)
        {
            var message = new MailMessage
            {
                Subject = "Your order #" + order.OrderId,
                Body = "Your order will arrive soon, your credit card is charged for $" + totalPrice.ToString("0.00")
            };
            message.To.Add(order.Orderer.Email);
            message.Sender = new MailAddress("bestretailer@example.com");
            var mailClient = new SmtpClient("smtp.example.com", 456);
            mailClient.Credentials = new NetworkCredential("smpt-user", "smtp-pass");
            await mailClient.SendMailAsync(message);
        }
    }
}
