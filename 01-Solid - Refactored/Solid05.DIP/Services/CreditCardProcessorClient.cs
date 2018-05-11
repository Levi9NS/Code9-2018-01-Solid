using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solid05.DIP.Models;

namespace Solid05.DIP.Services
{
    public class CreditCardProcessorClient : ICreditCardProcessorClient
    {
        public async Task<int> ChargeCreditCard(OrdererInfoModel orderer, double ammount)
        {
            object creditCardChargeRequest = new
            {
                orderer.CreditCardNumber,
                billingAddress = new
                {
                    orderer.AddressLine1,
                    orderer.AddressLine2,
                    orderer.City,
                    orderer.Country,
                    orderer.PostCode
                },
                charge = ammount
            };

            string creditCardChargeRequestJson = JsonConvert.SerializeObject(creditCardChargeRequest);
            var creditCardClient = new HttpClient();
            var response = await creditCardClient.PostAsync("creditCardApiUrl/charge",
                new StringContent(creditCardChargeRequestJson, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("HTTP request failed when processing credit card.");
            }
            string responseJson = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeAnonymousType(responseJson, new { success = true, reason = "", responseId = 0 });
            if (!responseObject.success)
            {
                throw new Exception("CC service returned error when processing credit card.");
            }

            return responseObject.responseId;
        }

        public async Task CancelCreditCardCharge(int responseId)
        {
            string cancelChargeJson = JsonConvert.SerializeObject(
                    new
                    {
                        responseId
                    });
            var creditCardClient = new HttpClient();
            await creditCardClient.PostAsync("creditCardApiUrl/cancel",
                new StringContent(cancelChargeJson, Encoding.UTF8, "application/json"));
        }
    }
}
