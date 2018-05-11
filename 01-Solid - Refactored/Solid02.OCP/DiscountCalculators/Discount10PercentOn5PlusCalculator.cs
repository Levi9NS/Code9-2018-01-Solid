namespace Solid02.OCP.DiscountCalculators
{
    public class Discount10PercentOn5PlusCalculator : IDiscountCalculator
    {
        public double GetDiscountedPrice(OrderItem item)
        {
            double itemPrice = item.Price * item.Quantity;
            if (item.Quantity >= 5)
            {
                itemPrice *= 0.9;
            }
            return itemPrice;
        }

        public bool IsDiscountForKey(string discountKey)
        {
            return discountKey == DiscountTypes.Discount10PercentOn5Plus;
        }
    }
}
