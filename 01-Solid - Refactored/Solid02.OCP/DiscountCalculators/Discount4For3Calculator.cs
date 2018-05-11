namespace Solid02.OCP.DiscountCalculators
{
    public class Discount4For3Calculator : IDiscountCalculator
    {
        public double GetDiscountedPrice(OrderItem item)
        {
            double itemPrice = item.Price * item.Quantity;

            int setsOf4s = item.Quantity / 4;
            itemPrice -= setsOf4s * item.Price;

            return itemPrice;
        }

        public bool IsDiscountForKey(string discountKey)
        {
            return discountKey == DiscountTypes.Discount4For3;
        }
    }
}
