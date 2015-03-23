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
    public partial class Taophong : PhoneApplicationPage
    {
        Sounds sounds = new Sounds();
        int[] comboNumDisk = {3, 4, 5, 6, 7, 8, 9, 10 };
        public Taophong()
        {    
            InitializeComponent();
            this.lpkCountry.ItemsSource = comboNumDisk;
            txtChuphong.Text = Client.username.ToString();
            
        }

        private void btnBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/Danhsachphongchoi.xaml", UriKind.Relative));
        }

        private void btnAddNewRoom(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");

        }
    }
}