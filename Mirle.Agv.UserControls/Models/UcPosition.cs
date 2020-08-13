using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Agv.UserControls
{   
    public class UcPosition
    {
        public double X { get; set; }
        public double Y { get; set; }

        public UcPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public UcPosition() : this(0d, 0d)
        {

        }
    }
}
