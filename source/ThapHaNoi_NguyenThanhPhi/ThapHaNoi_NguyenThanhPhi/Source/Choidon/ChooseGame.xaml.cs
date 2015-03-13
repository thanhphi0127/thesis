using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.Windows.Media;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using System.Threading;

namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon
{
    public partial class ChooseGame : PhoneApplicationPage
    {
        Sounds sounds = new Sounds();
        private DispatcherTimer _effect;
        public ChooseGame()
        {
            InitializeComponent();
            _effect = new DispatcherTimer();
            _effect.Tick += new EventHandler(EffectTick);
            _effect.Interval = new TimeSpan(0, 0, 0, 0, 200);
            _effect.Start();
        }

        void EffectTick(object sender, EventArgs e)
        {
            //Hieu ung mau trong button
            Random rd = new Random();
            btnChoidon3.BorderBrush = new SolidColorBrush(Color.FromArgb(255, (byte)rd.Next(256), (byte)rd.Next(256), (byte)rd.Next(256)));

            Random rd1 = new Random();
            btnChoidon4.BorderBrush = new SolidColorBrush(Color.FromArgb(255, (byte)rd1.Next(256), (byte)rd1.Next(256), (byte)rd1.Next(256)));
        }

        private void btnChoidon3coc(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            sounds.Stop("main");
            NavigationService.Navigate(new Uri("/Source/Choidon/PlayGame.xaml", UriKind.Relative));

        }

        private void btnChoidon4coc(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            sounds.Stop("main");
            NavigationService.Navigate(new Uri("/Source/Choidon/PlayGame_Hanoi4.xaml", UriKind.Relative));
        }

        private void imgTrangchu(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void LoadEvent(object sender, RoutedEventArgs e)
        {
            //StoryboardChoose.Begin();
        }
    }
}