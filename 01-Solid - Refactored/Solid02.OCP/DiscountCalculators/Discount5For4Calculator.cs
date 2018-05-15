using System;
using System.Collections.Generic;
using System.Text;

namespace Solid02.OCP.DiscountCalculators
{
    public class Discount5For4Calculator : IDiscountCalculator
    {
        public double GetDiscountedPrice(OrderItem item)
        {
            double itemPrice = item.Price * item.Quantity;

            int setsOf5s = item.Quantity / 5;
            itemPrice -= setsOf5s * item.Price;

            return itemPrice;
        }

        public bool IsDiscountForKey(string discountKey)
        {
            return discountKey == "5 for 4";
        }
    }
}
