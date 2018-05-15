using Solid01.SRP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid01.SRP.Services
{
    class PriceCalculator
    {
        public static double CalculateTotalPrice(OrderModel order)
        {
            // calculate total price
            double totalPrice = 0;
            int totalNumberOfItems = 0;
            foreach (var orderItem in order.OrderItems)
            {
                totalNumberOfItems += orderItem.Quantity;
                totalPrice += orderItem.Price * orderItem.Quantity;
            }

            // if total number of items is greater than 30 and total price > 100.00 give 5% discount
            if (totalPrice > 100.0 && totalNumberOfItems > 30)
            {
                totalPrice *= 0.95;
            }

            return totalPrice;
        }
    }
}
