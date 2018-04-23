using System.Collections.Generic;
using Xunit;

namespace Solid02.OCP.Tests
{
    public class DiscountTests
    {
        [Fact]
        public void NoDiscount_GivesFullPrice()
        {
            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem { Quantity = 4, Price = 10 },
                new OrderItem { Quantity = 3, Price = 2 },
            };

            double expectedPrice = 46;

            double actualPrice = PriceCalculator.CalculateTotal(items);

            Assert.Equal(expectedPrice, actualPrice);
        }

        [Fact]
        public void Discount3For2_GivesAppropriateDiscount()
        {
            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem { Quantity = 4, Price = 10, DiscountType = DiscountTypes.Discount3For2 } // should be 2*10 + 1*10
            };

            double expectedPrice = 30;

            double actualPrice = PriceCalculator.CalculateTotal(items);

            Assert.Equal(expectedPrice, actualPrice);
        }
        
        [Fact]
        public void Discount4For3_GivesAppropriateDiscount()
        {
            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem { Quantity = 4, Price = 10, DiscountType = DiscountTypes.Discount4For3 } // should be 3*10
            };

            double expectedPrice = 30;

            double actualPrice = PriceCalculator.CalculateTotal(items);

            Assert.Equal(expectedPrice, actualPrice);
        }
        
        [Fact]
        public void Discount10PercentFor5Plus_GivesAppropriateDiscount()
        {
            List<OrderItem> items = new List<OrderItem>
            {
                new OrderItem { Quantity = 5, Price = 10, DiscountType = DiscountTypes.Discount10PercentOn5Plus } // should be 45
            };

            double expectedPrice = 45;

            double actualPrice = PriceCalculator.CalculateTotal(items);

            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}
