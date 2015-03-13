using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
//using ThapHaNoi_NguyenThanhPhi.ServiceReference;

namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau
{
    public partial class Dangki : PhoneApplicationPage
    {
        Sounds sounds = new Sounds();
        public Dangki()
        {
            InitializeComponent();
        }

        private void btnBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/DangNhap.xaml", UriKind.Relative));
        }
    }
}