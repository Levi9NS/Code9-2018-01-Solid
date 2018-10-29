using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03.LSP
{
    public class Rectangle : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override int Area()
        {
            return X * Y;
        }
    }

    public class Square : Shape
    {
        public int Side { get; set; }

        public override int Area()
        {
            return Side * Side;
        }
    }

    public abstract class Shape
    {
        public abstract int Area();
    }
}
