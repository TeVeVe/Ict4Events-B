﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedClasses.Views
{
    public partial class ViewLookup : UserControl
    {
        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        }

        public ViewLookup()
        {
            InitializeComponent();
        }
    }
}
