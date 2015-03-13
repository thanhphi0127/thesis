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
using System.Windows.Input;
using System.Windows.Media.Animation;

using ThapHaNoi_NguyenThanhPhi.Resources;

using System.Data;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using System.Windows.Threading;
using System.Threading;
using System.Windows.Media.Imaging;
using System.IO;

using System.Threading.Tasks;

namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon
{
    public partial class Help : PhoneApplicationPage
    {
        /// <summary>
        /// VUNG CODE THAM SO, BIEN CUC BO
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        #region KHOI TAO CAC BIEN, THAM SO
        Sounds sounds = new Sounds();
        Function func = new Function();

        private Int32 speed = 100;
        Pole[] _pole = new Pole[4];

        //Cac bien cuc bo cho viec luu tru du lieu 
        int moveCount = 0;
        int numDisk;
        int numRod;
        bool firstLoad = true;
        private int[] comboNumDisk = { 3, 4, 5, 6, 7, 8, 9, 10 };
        
        DiskControl temp;
        private BackgroundWorker myWorker = new BackgroundWorker();
        #endregion

        public Help()
        {
            InitializeComponent();
            sounds.Stop("main");
            this.listNumDisk.ItemsSource = comboNumDisk;
            _pole[0] = new Pole(CavasRodA);
            _pole[1] = new Pole(CavasRodB);
            _pole[2] = new Pole(CavasRodC);
            _pole[3] = new Pole(CavasRodD);

            myWorker.WorkerReportsProgress = true;
            myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);
            myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);


        }


        /// <summary>
        /// HAM KHOI TAO LAI TRANG THAI GAME VOI SO LUONG DIA = SO LUONG DIA + 1
        /// </summary>
        /// <param name="numDiskContinue">Cho phep nguoi choi khoi dong lai game voi so luong dia la tham so dau vao</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao lai bo dem thoi gian
        ///       2.Xoa cac dia hien tai
        ///       3.Dat lai thoi gian</work>
        private void RestartGame(int numDiskContinue)
        {
            //Xoa cac dia dang hien thi tren Canvas va luu tru trong stack
            _pole[0].stack.Clear(); 
            _pole[1].stack.Clear(); 
            _pole[2].stack.Clear(); 
            _pole[3].stack.Clear();

            CavasRodA.Children.Clear();
            CavasRodB.Children.Clear();
            CavasRodC.Children.Clear();
            CavasRodD.Children.Clear();

            //Dat lai thoi gian va so lan di chuyen la 0
            txtSolan.Text = Contants.DefaultCountValue;
            moveCount = 0;

            //Them dia vao coc A 
            _pole[0].Init(numDiskContinue, CavasRodA);      
        }


        /// <summary>
        /// SU KIEN NHAN VAO "BACK"
        /// </summary>
        /// <param name="numDiskContinue">Dieu huong den trang chu cua ung dung</param>
        /// <purpose></purpose>
        private void imgBack(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            NavigationService.Navigate(new Uri("/Source/Choidon/ChooseGame.xaml", UriKind.Relative));
        }

        /// <summary>
        /// SU KIEN NHAN VAO NUT BAT DAU TRO GIUP
        /// </summary>
        /// <param name="numDiskContinue"></param>
        /// <purpose></purpose>
        private void Tap_Begin(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            if (string.Compare(btnBegin.Content.ToString(), (string)"Xem lại") == 0)
            {
                Load();
            }
            RestartGame(numDisk);
            btnBegin.Visibility = Visibility.Collapsed;
            listNumDisk.Visibility = Visibility.Collapsed;
            btnBegin.Content = "Xem lại";

            if (!myWorker.IsBusy)
            {
                myWorker.RunWorkerAsync();
            }

        }

        private void AutoLoad(object sender, RoutedEventArgs e)
        {
            if (firstLoad)
            {
                numRod = Convert.ToInt32(NavigationContext.QueryString["numRod"]);
                numDisk = Convert.ToInt32(NavigationContext.QueryString["numDisk"]);
                listNumDisk.SelectedItem = numDisk;
                firstLoad = false;
            }
            Load();
            
        }

        void Load()
        {
            stackList.Children.Clear();
            MoveCalculation.miliseconds = (Int32)sliderSpeed.Value;
            if (numRod.Equals(3))
            {
                CavasRodD.Visibility = Visibility.Collapsed;
            }
            RestartGame(numDisk);
        }

        /// <summary>
        /// SU KIEN THAY DOI GIA TRI TEN SLIDER
        /// </summary>
        /// <purpose></purpose>
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Dispatcher.BeginInvoke(new Action(() => speed = (Int32)sliderSpeed.Value));
            Dispatcher.BeginInvoke(new Action(() => txtSpeed.Text = "Tốc độ: " + speed.ToString() + " mili giây"));
        }
        /// <summary>
        /// SU KIEN DI CHUYEN DIA TU DONG
        /// </summary>
        /// <purpose></purpose>
        public void MakeMove(string from, string to)
        {
            switch (from)
            {
                case "A":
                    temp = _pole[0].RemoveDiskFromPole(CavasRodA);
                    break;
                case "B":
                    temp = _pole[1].RemoveDiskFromPole(CavasRodB);
                    break;
                case "C":
                    temp = _pole[2].RemoveDiskFromPole(CavasRodC);
                    break;
                case "D":
                    temp = _pole[3].RemoveDiskFromPole(CavasRodD);
                    break;
                default:
                    break;
            }

            if (temp == null) return;
            switch (to)
            {
                case "A":
                    _pole[0].AddDiskIntoPole(CavasRodA, temp);
                    break;
                case "B":
                    _pole[1].AddDiskIntoPole(CavasRodB, temp);
                    break;
                case "C":
                    _pole[2].AddDiskIntoPole(CavasRodC, temp);
                    break;
                case "D":
                    _pole[3].AddDiskIntoPole(CavasRodD, temp);
                    break;
                default:
                    break;
            }
        }



        void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnBegin.Visibility = Visibility.Visible;
            listNumDisk.Visibility = Visibility.Visible;
            TextControl text = new TextControl(moveCount + 1, "Hoàn tất");
            stackList.Children.Add(text);
        }

        /// <summary>
        /// SU KIEN GIA TRI WORKER THAY DOI
        /// </summary>
        /// <purpose></purpose>
        void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            moveCount++;
            this.txtSolan.Text = moveCount.ToString();
            string[] valueMove = e.UserState.ToString().Split('/');

            //txtStep.Text += moveCount.ToString() + ".Chuyển " + valueMove[0] + " qua " + valueMove[1] + "\n";

            TextControl text = new TextControl(moveCount, "Chuyển " + valueMove[0] + " qua " + valueMove[1]);
            stackList.Children.Add(text);

            this.MakeMove(valueMove[0], valueMove[1]);
            MoveCalculation.miliseconds = speed;
        }

        /// <summary>
        /// HOAT DONG CUA WORKER
        /// </summary>
        /// <purpose></purpose>
        void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker work = sender as BackgroundWorker;
            if (numRod.Equals(3))
            {
                MoveCalculation.SolveHanoi3(numDisk, work);
            }
            else
            {
                MoveCalculation.SolveHanoi4(numDisk, work);
            }
        }

        private void BackKeyPress(object sender, CancelEventArgs e)
        {
            if (numRod.Equals(3))
            {
                NavigationService.Navigate(new Uri("/Source/Choidon/PlayGame.xaml", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/Source/Choidon/PlayGame_Hanoi4.xaml", UriKind.Relative));
            }
            
        }

        private void listNumDisk_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => numDisk = int.Parse(listNumDisk.SelectedItem.ToString())));
            Dispatcher.BeginInvoke(new Action(() => RestartGame(numDisk)));
            
        }

    }
}