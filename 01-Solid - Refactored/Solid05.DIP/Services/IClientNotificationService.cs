using Solid05.DIP.Models;
using System.Threading.Tasks;

namespace Solid05.DIP.Services
{
    public interface IClientNotificationService
    {
        Task NotifyClientAboutOrder(OrderModel order, double amount);
    }
}
