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

namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau
{
    public partial class Dangki : PhoneApplicationPage
    {
        private Sounds sounds = new Sounds();
        private Service1Client server = new Service1Client();

        public Dangki()
        {
            InitializeComponent();
        }

        private void checkTK(object sender, GetDataCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }


        private void btnBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/DangNhap.xaml", UriKind.Relative));
        }

        private void btnRegister(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            if (txtUsername.Text == "" || txtPassword.Password == "" || txtRepassword.Password == "")
            {
                MessageBox.Show("Thông tin đăng nhập, mật khẩu, xác nhận mật khẩu không được để trống", "Thông báo", MessageBoxButton.OK);
            }
            else
            {
                if (String.Compare(txtPassword.Password.ToString(), txtRepassword.Password.ToString()).Equals(0))
                {
                    MessageBox.Show("Mật khẩu và xác nhận mật khẩu không chính xác", "Thông báo", MessageBoxButton.OK);
                }
                else
                {
                    server.CheckUserCompleted += new EventHandler<CheckUserCompletedEventArgs>(checkUser);
                    server.CheckUserAsync(txtUsername.Text, txtPassword.Password);
                }
            }
            
        }

        private void checkUser(object sender, CheckUserCompletedEventArgs e)
        {
            try
            {
                if (e.Result == false)
                {
                    server.CreateUserCompleted += new EventHandler<CreateUserCompletedEventArgs>(serverCreateUser);
                    server.CreateUserAsync(txtUsername.Text.ToString(), txtPassword.Password.ToString());
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại!", "Cảnh báo", MessageBoxButton.OK);
                    return;
                }
            }
            catch (Exception)
            {
              
            }
        }

        private void serverCreateUser(object sender, CreateUserCompletedEventArgs e)
        {
            if (e.Result == false)
            {
                NavigationService.Navigate(new Uri("/Source/Thachdau/DangNhap.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Thất bại! Vui lòng tạo lại tài khoản", "Error", MessageBoxButton.OK);
                return;
            }

        }

        private void btnReset(object sender, System.Windows.Input.GestureEventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Password = "";
            txtRepassword.Password = "";
        }
    }
}