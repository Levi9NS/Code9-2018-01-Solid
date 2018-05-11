namespace Solid02.OCP.DiscountCalculators
{
    public class NoDiscountCalculator : IDiscountCalculator
    {
        public double GetDiscountedPrice(OrderItem item)
        {
            // no discount here
            return item.Price * item.Quantity;
        }

        public bool IsDiscountForKey(string discountKey)
        {
            return string.IsNullOrEmpty(discountKey);
        }
    }
}
