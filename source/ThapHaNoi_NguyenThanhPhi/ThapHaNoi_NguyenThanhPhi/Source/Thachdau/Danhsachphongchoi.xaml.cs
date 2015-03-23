using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using ThapHaNoi_NguyenThanhPhi.TowerHanoiService;

namespace ThapHaNoi_NguyenThanhPhi.Source.Thachdau
{
    public partial class Danhsachphongchoi : PhoneApplicationPage
    {
        Sounds sounds = new Sounds();
        Service1Client server = new Service1Client();
        DispatcherTimer _timer = new DispatcherTimer();
        
        public Danhsachphongchoi()
        {
            InitializeComponent();
            LoadListRoom();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += new EventHandler(TimeTick);
            
            //_timer.Start();

        }
        private void LoadListRoom()
        {
            server.DanhSachPhongChoiCompleted += new EventHandler<DanhSachPhongChoiCompletedEventArgs>(server_ListRoom);
            server.DanhSachPhongChoiAsync();
        }

        void TimeTick(object sender, EventArgs e)
        {
            server.DanhSachPhongChoiCompleted += new EventHandler<DanhSachPhongChoiCompletedEventArgs>(server_ListRoom);
            server.DanhSachPhongChoiAsync();
        }


        private void server_ListRoom(object sender, DanhSachPhongChoiCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                listDSPhong.ItemsSource = e.Result; 
                
            }
        }

        private void img_Taophong(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/Taophong.xaml", UriKind.Relative));
        }

        private void ItemInList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            /*
            WrapPanel a = (WrapPanel)sender;
            server.LayTTPhongCompleted += new EventHandler<LayTTPhongCompletedEventArgs>(proxy_LayTTPhongCompleted);
            server.LayTTPhongAsync(a.Tag.ToString().Trim());   
             * */
        }

        private void imgTapBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Thachdau/DangNhap.xaml", UriKind.Relative));
        }
    }
}