using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


//using ThapHaNoi_NguyenThanhPhi.TowerHanoiService;

namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau
{
    public partial class DangNhap : PhoneApplicationPage
    {
        
        Sounds sounds = new Sounds();
        //ServiceClient proxy = new ServiceClient();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void imgDangki(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/Dangki.xaml", UriKind.Relative)); 
        }

        /*
        void proxy_KiemTraTaiKhoanCompleted(object sender, KiemTraTaiKhoanCompletedEventArgs e)
        {
            try
            {
                if (e.Result == true)
                {
                    //ChoiDon.GlobalVariables.username = txtPassword.Text;
                    NavigationService.Navigate(new Uri("/Source/Thachdau/Danhsachphongchoi.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Sai thông tin đăng nhập.", "Thong bao", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {

            }

        }
         * */

        private void btn_Dangnhap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txtUsername.Text.ToString() == "" || txtPassword.Password.ToString() == "")
            {
                MessageBox.Show("Không bỏ trống thông tin đăng nhập.", "Thong bao", MessageBoxButton.OK);
            }
            else
            {
                /*
                proxy.KiemTraTaiKhoanCompleted += new EventHandler<KiemTraTaiKhoanCompletedEventArgs>(proxy_KiemTraTaiKhoanCompleted);
                proxy.KiemTraTaiKhoanAsync(txtUsername.Text.ToString(), txtPassword.Password.ToString());
                */
                //hien thi thanh trang thai xu li
                //customIndeterminateProgressBar.Visibility = Visibility.Visible;
                 
            }   
            //NavigationService.Navigate(new Uri("/Source/Thachdau/Danhsachphongchoi.xaml", UriKind.Relative));
        }

        private void btnBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            //NavigationService.Navigate(new Uri("/Source/Thachdau/Danhsachphongchoi.xaml", UriKind.Relative));
        }
         
    }
}