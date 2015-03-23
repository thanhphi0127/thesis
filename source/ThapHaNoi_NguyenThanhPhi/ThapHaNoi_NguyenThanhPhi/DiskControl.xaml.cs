using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ThapHaNoi_NguyenThanhPhi
{
    public partial class DiskControl : UserControl
    {
        public DiskControl()
        {
            InitializeComponent();
        }
        public DiskControl(int number)
        {
            InitializeComponent();
            txtNumber.Text = number.ToString();
        }
    }
}
