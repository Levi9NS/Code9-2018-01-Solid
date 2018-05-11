using Solid05.DIP.Models;

namespace Solid05.DIP.Services
{
    public interface IOrderProcessorStore
    {
        void ProcessOrderInStorage(OrderModel order);
    }
}
