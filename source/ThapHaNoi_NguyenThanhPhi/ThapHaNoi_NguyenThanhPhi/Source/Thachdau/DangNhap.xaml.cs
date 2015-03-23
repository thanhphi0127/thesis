using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ThapHaNoi_NguyenThanhPhi.TowerHanoiService;

//using ThapHaNoi_NguyenThanhPhi.TowerHanoiService;

namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau
{
    public partial class DangNhap : PhoneApplicationPage
    {       
        Sounds sounds = new Sounds();
        Service1Client proxy = new Service1Client();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void imgDangki(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/Dangki.xaml", UriKind.Relative)); 
        }
        
        private void proxy_CheckUser(object sender, CheckUserCompletedEventArgs e)
        {
           if (e.Result == true)
           {
               Client.username = txtUsername.Text.ToString();
               NavigationService.Navigate(new Uri("/Source/Thachdau/Danhsachphongchoi.xaml", UriKind.Relative));
           }
           else
           {
               MessageBox.Show("Sai thông tin đăng nhập.", "Thong bao", MessageBoxButton.OK);
               return;
           }
        }
        
        private void btn_Dangnhap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            if (txtUsername.Text.ToString() == "" || txtPassword.Password.ToString() == "")
            {
                MessageBox.Show("Không bỏ trống thông tin đăng nhập.", "Thong bao", MessageBoxButton.OK);
            }
            else
            {        
                proxy.CheckUserCompleted += new EventHandler<CheckUserCompletedEventArgs>(proxy_CheckUser);
                proxy.CheckUserAsync(txtUsername.Text.ToString(), txtPassword.Password.ToString());  
            }
        }

        private void btnBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void btnReset(object sender, System.Windows.Input.GestureEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
        }
    }
}