using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau
{
    public partial class Danhsachphongchoi : PhoneApplicationPage
    {
        Sounds sounds = new Sounds();
        public Danhsachphongchoi()
        {
            InitializeComponent();
        }

        private void img_Taophong(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/Taophong.xaml", UriKind.Relative));
        }
    }
}