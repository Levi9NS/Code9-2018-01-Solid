using Solid05.DIP.Models;

namespace Solid05.DIP.Services
{
    public interface IPriceCalculator
    {
        double CalculateTotalPrice(OrderModel order);
    }
}
