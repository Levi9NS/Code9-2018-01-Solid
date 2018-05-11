namespace Solid02.OCP.DiscountCalculators
{
    public class Discount3For2Calculator : IDiscountCalculator
    {
        public double GetDiscountedPrice(OrderItem item)
        {
            double itemPrice = item.Price * item.Quantity;

            int setsOf3s = item.Quantity / 3;
            itemPrice -= setsOf3s * item.Price;

            return itemPrice;
        }

        public bool IsDiscountForKey(string discountKey)
        {
            return discountKey == DiscountTypes.Discount3For2;
        }
    }
}
