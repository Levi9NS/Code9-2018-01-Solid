using Newtonsoft.Json;
using Solid01.SRP.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Solid01.SRP.Services
{
    class CreditCardService
    {
        public static async Task<int> ChargeCreditCard(OrdererInfoModel orderer, double amout)
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
                charge = amout
            };

            string creditCardChargeRequestJson = JsonConvert.SerializeObject(creditCardChargeRequest);
            var creditCardClient = new HttpClient();
            var response = await creditCardClient.PostAsync("creditCardApiUrl/charge",
                new StringContent(creditCardChargeRequestJson, Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            string responseJson = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeAnonymousType(responseJson, new { success = true, reason = "", responseId = 0 });
            if (!responseObject.success)
            {
                throw new Exception();
            }

            return responseObject.responseId;

        }

        public static async Task CancelCreditCardCharge(int ccResponseId)
        {
            var creditCardClient = new HttpClient();
            string cancelChargeJson = JsonConvert.SerializeObject(
                    new
                    {
                        responseId = ccResponseId
                    });
            await creditCardClient.PostAsync("creditCardApiUrl/cancel",
                new StringContent(cancelChargeJson, Encoding.UTF8, "application/json"));
        }
    }
}
