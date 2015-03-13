using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ThapHaNoi_NguyenThanhPhi.Source
{
    public partial class Huongdan : PhoneApplicationPage
    {
        Sounds sounds = new Sounds();
        public Huongdan()
        {
            InitializeComponent();
        }

        private void BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void imgBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}