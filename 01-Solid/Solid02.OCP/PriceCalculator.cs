using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid02.OCP
{
    public static class PriceCalculator
    {
        public static double CalculateTotal(IEnumerable<OrderItem> orderItems)
        {
            double totalPrice = 0.0;

            foreach (var item in orderItems)
            {
                double itemPrice;

                switch (item.DiscountType)
                {
                    case DiscountTypes.Discount10PercentOn5Plus:
                        itemPrice = item.Price * item.Quantity;
                        if (item.Quantity >= 5)
                        {
                            itemPrice *= 0.9;
                        }
                        break;

                    case DiscountTypes.Discount3For2:
                        itemPrice = item.Price * item.Quantity;

                        int setsOf3s = item.Quantity / 3;
                        itemPrice -= setsOf3s * item.Price;

                        break;

                    case DiscountTypes.Discount4For3:
                        itemPrice = item.Price * item.Quantity;

                        int setsOf4s = item.Quantity / 4;
                        itemPrice -= setsOf4s * item.Price;

                        break;

                    default: // no discount
                        itemPrice = item.Price * item.Quantity;
                        break;
                }

                totalPrice += itemPrice;
            }

            return totalPrice;
        }
    }
}
