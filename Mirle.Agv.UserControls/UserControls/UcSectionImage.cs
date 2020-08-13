using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Mirle.Agv.UserControls
{
    public partial class UcSectionImage : UserControl
    {
        public UcSection Section { get; set; } = new UcSection();
        public Tuple<double,double> VectorHeadToTail { get; set; }        

        private Image image;
        private Graphics gra;

        private double coefficient = 0.05f;

        private ToolTip toolTip = new ToolTip();

        private int x1 = 0;
        private int y1 = 0;
        private int x2 = 0;
        private int y2 = 0;

        public UcSectionImage() : this(new UcSection()) { }
        public UcSectionImage(UcSection section)
        {
            InitializeComponent();

            Section = section;
            VectorHeadToTail = Tuple.Create(Section.TailAddress.Position.X - Section.HeadAddress.Position.X, Section.TailAddress.Position.Y - Section.HeadAddress.Position.Y);
            label1.Text = Section.Id;
            DrawSectionImage(StaticTools.bluePen);
            SetupShowSectionInfo();
        }

        private void SetupShowSectionInfo()
        {
            string msg = $"Id = {Section.Id}\n" + $"FromAdr = {Section.HeadAddress.Id}\n" + $"ToAdr = {Section.TailAddress.Id}";

            toolTip.SetToolTip(pictureBox1, msg);
            toolTip.SetToolTip(label1, msg);
        }

        public void SetColor(Pen pen)
        {
            gra.Clear(Color.Transparent);
            gra.DrawLine(pen, x1, y1, x2, y2);
        }

        public void DrawSectionImage(Pen aPen)
        {
            UcAddress headAdr = Section.HeadAddress;
            UcAddress tailAdr = Section.TailAddress;

            var disX = Convert.ToInt32(Math.Abs(tailAdr.Position.X - headAdr.Position.X) * coefficient);
            var disY = Convert.ToInt32(Math.Abs(tailAdr.Position.Y - headAdr.Position.Y) * coefficient);

            switch (Section.SectionType)
            {
                case EnumUcSectionType.Horizontal:
                    {
                        Size = new Size(disX, label1.Height * 3);
                        label1.Location = new Point(disX / 2, label1.Height * 2);
                        image = new Bitmap(Size.Width, Size.Height);
                        gra = Graphics.FromImage(image);

                        x1 = 0;
                        y1 = 0;
                        x2 = disX;
                        y2 = 0;
                    }
                    break;
                case EnumUcSectionType.Vertical:
                    {
                        Size = new Size(label1.Width + 10, disY);
                        label1.Location = new Point(5, disY / 2);
                        image = new Bitmap(Size.Width, Size.Height);
                        gra = Graphics.FromImage(image);

                        x1 = label1.Width / 2 + 5;
                        y1 = 0;
                        x2 = label1.Width / 2 + 5;
                        y2 = disY;
                    }
                    break;
                case EnumUcSectionType.R30deg:
                case EnumUcSectionType.R2000:
                    {
                        Size = new Size(disX, disY);
                        label1.Location = new Point(disX / 2, disY / 2);
                        image = new Bitmap(Size.Width, Size.Height);
                        gra = Graphics.FromImage(image);
                        if (VectorHeadToTail.Item1 * VectorHeadToTail.Item2 > 0)
                        {
                            //左上右下型
                            x1 = 0;
                            y1 = 0;
                            x2 = disX;
                            y2 = disY;
                        }
                        else
                        {
                            //左下右上型
                            x1 = 0;
                            y1 = disY;
                            x2 = disX;
                            y2 = 0;
                        }
                    }
                    break;
                case EnumUcSectionType.None:
                default:
                    break;
            }

            gra.DrawLine(aPen, x1, y1, x2, y2);
            pictureBox1.Image = image;

        }
    }
}
