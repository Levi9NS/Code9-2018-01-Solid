using System;
using System.Threading.Tasks;
using Solid05.DIP.Models;

namespace Solid05.DIP.Services
{
    public class OrderProcessor
    {
        private readonly IPriceCalculator _priceCalculator;
        private readonly IOrderProcessorStore _orderProcessorStore;
        private readonly ICreditCardProcessorClient _ccClient;
        private readonly IClientNotificationService _notificationService;

        public OrderProcessor(
            IPriceCalculator priceCalculator, 
            IOrderProcessorStore orderProcessorStore,
            ICreditCardProcessorClient ccClient,
            IClientNotificationService notificationService
            )
        {
            _priceCalculator = priceCalculator ?? throw new ArgumentNullException(nameof(priceCalculator));
            _orderProcessorStore = orderProcessorStore ?? throw new ArgumentNullException(nameof(orderProcessorStore));
            _ccClient = ccClient ?? throw new ArgumentNullException(nameof(ccClient));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public async Task<bool> ProcessOrder(OrderModel order)
        {
            double totalPrice = _priceCalculator.CalculateTotalPrice(order);

            int ccResponseId = await _ccClient.ChargeCreditCard(order.Orderer, totalPrice);

            try
            {
                _orderProcessorStore.ProcessOrderInStorage(order);
            }
            catch
            {
                await _ccClient.CancelCreditCardCharge(ccResponseId);
                throw;
            }

            await _notificationService.NotifyClientAboutOrder(order, totalPrice);

            return true;
        }
    }
}
