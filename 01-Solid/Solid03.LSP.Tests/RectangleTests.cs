using System;
using Xunit;

namespace Solid03.LSP.Tests
{
    public class RectangleTests
    {
        [Fact]
        public void RectangleAreaCalculation()
        {
            Rectangle r1 = new Rectangle
            {
                A = 4,
                B = 5
            };

            Assert.Equal(20, r1.Area);

            Rectangle r2 = new Square
            {
                A = 4,
                B = 5
            };

            Assert.Equal(20, r2.Area); // fails, area is 25
        }
    }
}
