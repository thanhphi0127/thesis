using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon
{
    public partial class ThanhTichCaNhanControl : UserControl
    {
        public ThanhTichCaNhanControl()
        {
            InitializeComponent();
            txtSodia.Text = "Số đĩa";
            txtSobuoc.Text = "Số bước";
            txtTennguoichoi.Text = "Biệt danh";
            txtThoigian.Text = "Thời gian";
            txtNgaylap.Text = "Ngày lập";
            //#FF05194B
            brdBackGround.Background = new SolidColorBrush(Color.FromArgb(150, 247, 6, 6));
        }

        
        public ThanhTichCaNhanControl(ThanhTichChoiDon ttcd, int n)
        {
            InitializeComponent();
            txtSodia.Text = ttcd.SODIA.ToString();
            txtSobuoc.Text = ttcd.SOBUOC.ToString();
            txtTennguoichoi.Text = ttcd.TENNGUOICHOI.ToString();
            txtThoigian.Text = ttcd.THOIGIAN.ToString();
            txtNgaylap.Text = ttcd.NGAYLAP.ToString();

            if (n % 2 != 0)
            {
                brdBackGround.Background = new SolidColorBrush(Color.FromArgb(50, 50, 100, 100));
            }
            
        }
    }
}
