﻿using System;
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
    public partial class UcVerticalLabelText : UserControl
    {
        public string TagName
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public string TagValue
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        public Color TagColor
        {
            get { return label1.BackColor; }
            set { label1.BackColor = value; }
        }


        public UcVerticalLabelText()
        {
            InitializeComponent();
        }
    }
}
