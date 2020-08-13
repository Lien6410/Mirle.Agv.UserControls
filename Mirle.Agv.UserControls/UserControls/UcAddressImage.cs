using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirle.Agv.UserControls
{
    public partial class UcAddressImage : UserControl
    {
        public UcAddress Address { get; set; } = new UcAddress();
        public int Radius { get; set; } = 6;

        private Image image;
        private Graphics gra;
        private double triangleCoefficient = (double)(Math.Sqrt(3.0));
        private ToolTip toolTip = new ToolTip();

        public UcAddressImage(UcAddress address)
        {
            InitializeComponent();
            Address = address;
            DrawAddressImage(StaticTools.redPen);
            SetupShowAddressInfo();
        }

        private void SetupShowAddressInfo()
        {
            string msg = $"Id = {Address.Id}\n" + $"Position = ({Address.Position.X},{Address.Position.Y})\n";

            toolTip.SetToolTip(pictureBox1, msg);
        }

        public void DrawAddressImage(Pen pen)
        {
            int recSize = 2 * Radius;
            Size = new Size(recSize + 2, recSize + 2);
            image = new Bitmap(Size.Width, Size.Height);
            gra = Graphics.FromImage(image);

            if (Address.IsWorkStation)
            {
                //Port站 : 畫圓
                //RectangleF rectangleF = new RectangleF(Delta + 1, label1.Height + 3, recSize, recSize);
                RectangleF rectangleF = new RectangleF(1, 1, recSize, recSize);
                gra.DrawEllipse(StaticTools.redPen, rectangleF);
            }

            if (Address.IsCharger)
            {
                //充電樁 : 畫圓內接三角形
                var triangleHeight = (float)((Radius * triangleCoefficient));
                PointF pointf = new PointF(1, 1);
                PointF p1 = new PointF(pointf.X + Radius, pointf.Y);
                PointF p2 = new PointF(pointf.X + 0, pointf.Y + triangleHeight);
                PointF p3 = new PointF(pointf.X + recSize, pointf.Y + triangleHeight);
                PointF[] pointFs = new PointF[] { p1, p2, p3 };
                gra.FillPolygon(StaticTools.redBrush, pointFs);
            }

            if (Address.IsSegmentPoint)
            {
                //Rectangle rectangle = new Rectangle(Delta + 1, label1.Height + 3, recSize, recSize);
                Rectangle rectangle = new Rectangle(1, 1, recSize, recSize);
                gra.DrawRectangle(StaticTools.blackPen, rectangle);
            }

            if (!Address.IsWorkStation && !Address.IsSegmentPoint && !Address.IsCharger)
            {
                //Rectangle rectangle = new Rectangle(Delta + 1, label1.Height + 3, recSize, recSize);
                Rectangle rectangle = new Rectangle(1, 1, recSize, recSize);
                gra.FillEllipse(StaticTools.blackBrush, rectangle);
            }

            pictureBox1.Image = image;
        }

        public void FixToCenter()
        {
            Location = new Point(Location.X - Radius, Location.Y - Radius);
        }
    }
}
