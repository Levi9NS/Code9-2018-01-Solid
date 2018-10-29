using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03.LSP
{
    public class Rectangle : RectangleBase
    {
        public int A { get; set; }
        public int B { get; set; }

        public override int Area()
        {
            return A * B;
        }
    }

    public class Square : RectangleBase
    {
        public int Side { get; set; }

        public override int Area()
        {
            return Side * Side;
        }
    }

    public abstract class RectangleBase
    {
        public abstract int Area();
    }

}
