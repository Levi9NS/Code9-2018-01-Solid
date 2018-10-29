using Xunit;

namespace Solid03.LSP.Tests
{
    public class RectangleTests
    {
        [Fact]
        public void RectangleAreaCalculation()
        {
            Shape s1 = new Rectangle()
            {
                X = 4,
                Y = 5
            };

            Assert.Equal(20, s1.Area());

            Shape s2 = new Square()
            {
                Side = 4
            };

            Assert.Equal(16, s2.Area());
        }
    }
}
