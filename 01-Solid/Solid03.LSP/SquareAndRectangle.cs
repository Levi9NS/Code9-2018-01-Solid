using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid03.LSP
{
    public class Rectangle
    {
        public virtual int A { get; set; }
        public virtual int B { get; set; }

        public int Area => A * B;
    }

    public class Square : Rectangle
    {
        private int _side;

        public override int A
        {
            get => _side;
            set => _side = value;
        }

        public override int B
        {
            get => _side;
            set => _side = value;
        }
    }
}
