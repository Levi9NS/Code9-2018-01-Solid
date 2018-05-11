namespace Solid02.OCP.DiscountCalculators
{
    public interface IDiscountCalculator
    {
        bool IsDiscountForKey(string discountKey);
        double GetDiscountedPrice(OrderItem item);
    }
}
