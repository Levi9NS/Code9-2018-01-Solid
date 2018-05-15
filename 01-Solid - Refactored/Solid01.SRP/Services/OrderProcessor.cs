using System.Data.Common;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solid01.SRP.Models;

namespace Solid01.SRP.Services
{
    public class OrderProcessor
    {
        public async Task<bool> ProcessOrder(OrderModel order, DbConnection dbConnection)
        {
            double totalPrice = PriceCalculator.CalculateTotalPrice(order);
            int ccResponseId = await CreditCardService.ChargeCreditCard(order.Orderer, totalPrice);
            
            try
            {
                OrderStorage.ProcessOrderInDb(order, dbConnection);
            }
            catch
            {
                await CreditCardService.CancelCreditCardCharge(ccResponseId);
                throw;
            }
            await NotificationService.SendEmailForOrder(order, totalPrice);

            return true;
        }
    }
}
