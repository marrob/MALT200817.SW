﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALT200817.Checklist
{

    public interface IMainForm
    {
        event EventHandler Shown;
        event EventHandler Reset;
    }

    public partial class MainFrom : Form
    {
        public event EventHandler Reset
        {
            add { toolStripMenuItemReset.Click += value; }
            remove { toolStripMenuItemReset.Click -= value; }
        }



        public MainFrom()
        {
            InitializeComponent();
            toolStripStatusLabelVersion.Text = Application.ProductVersion;
        }

        public void AddCheckItem(Control control)
        {
            flowLayoutPanel1.Controls.Add(control);
        }
    }
}
