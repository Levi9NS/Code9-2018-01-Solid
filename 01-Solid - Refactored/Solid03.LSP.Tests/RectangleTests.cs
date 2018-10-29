using Xunit;

namespace Solid03.LSP.Tests
{
    public class RectangleTests
    {
        [Fact]
        public void RectangleAreaCalculation()
        {
            RectangleBase s1 = new Rectangle()
            {
                A = 4,
                B = 5
            };

            Assert.Equal(20, s1.Area());

            RectangleBase s2 = new Square()
            {
                Side = 4
            };

            Assert.Equal(16, s2.Area());
        }

    }
}
