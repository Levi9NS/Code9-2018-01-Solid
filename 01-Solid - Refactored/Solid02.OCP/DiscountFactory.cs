using Solid02.OCP.DiscountCalculators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid02.OCP
{
    public class DiscountFactory
    {
        private static List<IDiscountCalculator> Discounts { get; } = new List<IDiscountCalculator>();

        static DiscountFactory()
        {
            // Discounts.Add(new Discount10PercentOn5PlusCalculator());
            // Discounts.Add(new Discount3For2Calculator());
            // ...

            var discountClasses = typeof(DiscountFactory).Assembly
                .GetTypes()
                .Where(x => typeof(IDiscountCalculator).IsAssignableFrom(x) && x.IsClass)
                .ToList();

            Discounts.AddRange(discountClasses
                    .Select(x => Activator.CreateInstance(x) as IDiscountCalculator)
                );
        }

        public static IDiscountCalculator CreateDiscountCalculator(string forDiscountKey)
        {
            return Discounts
                .FirstOrDefault(x => x.IsDiscountForKey(forDiscountKey))
                ?? new NoDiscountCalculator();
        }
    }
}
