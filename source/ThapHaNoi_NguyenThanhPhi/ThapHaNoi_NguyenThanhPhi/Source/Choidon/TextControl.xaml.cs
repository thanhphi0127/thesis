using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon
{
    public partial class TextControl : UserControl
    {
        public TextControl()
        {
            InitializeComponent();
        }

        public TextControl(int number, string move)
        {
            InitializeComponent();
            txtNumber.Text = number.ToString();
            txtMoveText.Text = move.ToString();
        }
              
    }
}
