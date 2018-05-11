using Solid05.DIP.Models;
using System.Threading.Tasks;

namespace Solid05.DIP.Services
{
    public interface ICreditCardProcessorClient
    {
        /// <summary>
        /// Charges the credit card and returns request id
        /// </summary>
        /// <param name="orderer">The orderer.</param>
        /// <param name="amount">USD amount to charge.</param>
        /// <returns></returns>
        Task<int> ChargeCreditCard(OrdererInfoModel orderer, double amount);

        /// <summary>
        /// Cancels the credit card charge.
        /// </summary>
        /// <param name="responseId">responseId returned by CC service</param>
        /// <returns></returns>
        Task CancelCreditCardCharge(int responseId);
    }
}
