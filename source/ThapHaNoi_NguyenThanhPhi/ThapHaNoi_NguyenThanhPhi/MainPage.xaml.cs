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
using ThapHaNoi_NguyenThanhPhi.Resources;
//using ThapHaNoi_NguyenThanhPhi.ServiceReference;
using System.Diagnostics;
using System.ServiceModel;


namespace ThapHaNoi_NguyenThanhPhi
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        Sounds sounds = new Sounds();
        Function func = new Function();
        bool stateSound = false;
        public MainPage()
        {
            InitializeComponent();
            func.CreateLocalDatabase();
            sounds.Play("main");

        }

        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO CHOI DON
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        /// <work></work>
        private void btn_Start_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            sounds.Stop("main");
            NavigationService.Navigate(new Uri("/Source/Choidon/ChooseGame.xaml", UriKind.Relative));
        }

        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO CHOI THACH DAU TRUC TUYEN
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        /// <work></work>
        private void Tap_Online(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            sounds.Stop("main");
            NavigationService.Navigate(new Uri("/Source/Thachdau/DangNhap.xaml", UriKind.Relative));
        }

        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO 3 COC TREN GIAO DIEN
        /// </summary>
        /// <param name="numDiskContinue">/param>
        /// <purpose></purpose>
        /// <work></work>
        private void btn_MoreGame_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            sounds.Stop("main");
            NavigationService.Navigate(new Uri("/MoreGame.xaml", UriKind.Relative));
        }

        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO BIEU TUONG AM THANH
        /// </summary>
        /// <param name="numDiskContinue">/param>
        /// <purpose></purpose>
        /// <work></work>
        private void btnSound_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            if (stateSound)
            {
                sounds.Play("main");
                stateSound = false;
            }
            else
            {
                sounds.Stop("main");
                stateSound = true;
            }
        }

        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO NUT GIOI THIEU
        /// </summary>
        /// <param name="numDiskContinue">/param>
        /// <purpose></purpose>
        /// <work></work>
        private void imgGioithieu(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            sounds.Stop("main");
            NavigationService.Navigate(new Uri("/Source/Huongdan.xaml", UriKind.Relative));
        }

        /// <summary>
        /// HAM SU LY SU KIEN CHAM VAO NUT THANH TICH
        /// </summary>
        /// <param name="numDiskContinue">/param>
        /// <purpose></purpose>
        /// <work></work>
        private void btnThanhtich(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            sounds.Stop("main");
            NavigationService.Navigate(new Uri("/Source/Choidon/PivotThanhTich.xaml", UriKind.Relative));
        }

        private void BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sounds.Play("click");
            e.Cancel = true;
            MessageBoxResult flag = MessageBox.Show("Bạn có muốn thoát không", "Thoát khỏi trò chơi", MessageBoxButton.OKCancel);
            if (flag == MessageBoxResult.OK)
                Application.Current.Terminate();
        }

        private void LoadEvent(object sender, RoutedEventArgs e)
        {
            Affect_Move.Begin();
        }


        //private Service1Client client;

        private void imgSeting(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            /*
            //TestClient client = new TestClient();
            if (client == null)
            {
                client = new Service1Client(new BasicHttpBinding(), new EndpointAddress("http://localhost:32546/Service1.svc"));
                client.GetDataCompleted += new EventHandler<GetDataCompletedEventArgs>(client_AddCompleted);
            }
            client.GetDataAsync(1);
             * */


        }
        /*
        void client_AddCompleted(object sender, GetDataCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MessageBox.Show("The answer is " + e.Result);
            }
        }
         * */

    }
}