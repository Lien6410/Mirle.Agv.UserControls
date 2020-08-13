using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirle.Agv.UserControls
{
    public static class StaticTools
    {
        public static readonly Pen blackPen = new Pen(Color.Black, 1);
        public static readonly Pen redPen = new Pen(Color.Red, 1);
        public static readonly SolidBrush redBrush = new SolidBrush(Color.Red);
        public static readonly SolidBrush blackBrush = new SolidBrush(Color.Black);
        public static readonly Pen bluePen = new Pen(Color.Blue, 2);
    }

    public enum EnumUcSectionType
    {
        None,
        Horizontal,
        Vertical,
        R2000,
        R30deg
    }
}
