using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solid05.DIP.Models;

namespace Solid05.DIP.Services
{
    public class OrderProcessor
    {
        public async Task<bool> ProcessOrder(OrderModel order, DbConnection dbConnection)
        {
            // calculate total price
            double totalPrice = 0;
            int totalNumberOfItems = 0;
            foreach (var orderItem in order.OrderItems)
            {
                totalNumberOfItems += orderItem.Quantity;
                totalPrice += orderItem.Price * orderItem.Quantity;
            }

            // if total number of items is greater than 30 and total price > 100.00 give 5% discount
            if (totalPrice > 100.0 && totalNumberOfItems > 30)
            {
                totalPrice *= 0.95;
            }

            // charge credit card
            object creditCardChargeRequest = new
            {
                order.Orderer.CreditCardNumber,
                billingAddress = new
                {
                    order.Orderer.AddressLine1,
                    order.Orderer.AddressLine2,
                    order.Orderer.City,
                    order.Orderer.Country,
                    order.Orderer.PostCode
                },
                charge = totalPrice
            };

            string creditCardChargeRequestJson = JsonConvert.SerializeObject(creditCardChargeRequest);
            var creditCardClient = new HttpClient();
            var response = await creditCardClient.PostAsync("creditCardApiUrl/charge",
                new StringContent(creditCardChargeRequestJson, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
            {
                return false;
            }
            string responseJson = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeAnonymousType(responseJson, new {success = true, reason = "", responseId = 0});
            if (!responseObject.success)
            {
                return false;
            }

            // try to save to DB
            try
            {
                var cmd = dbConnection.CreateCommand();
                cmd.CommandText = @"exec processOrder";
                int generatedOrderId = cmd.Parameters.Add(JsonConvert.SerializeObject(order));
                order.OrderId = generatedOrderId;
            }
            catch
            {
                // cancel credit card charge if saving failed
                string cancelChargeJson = JsonConvert.SerializeObject(
                    new
                    {
                        responseObject.responseId
                    });
                await creditCardClient.PostAsync("creditCardApiUrl/cancel",
                    new StringContent(cancelChargeJson, Encoding.UTF8, "application/json"));

                throw;
            }
            
            // send email confirming the order
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

            return true;
        }
    }
}
