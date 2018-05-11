using Solid02.OCP.DiscountCalculators;
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
                IDiscountCalculator discountCalculator = DiscountFactory.CreateDiscountCalculator(item.DiscountType);
                double itemPrice = discountCalculator.GetDiscountedPrice(item);
                totalPrice += itemPrice;
            }

            return totalPrice;
        }
    }
}
