using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;


namespace ThapHaNoi_NguyenThanhPhi
{
    public class Pole
    {
        List<Color> _arrayColor = new List<Color>();

        public Stack<DiskControl> stack;
        Function func = new Function();

        public int Number { get; set; }

        public Pole()
        {
            stack = new Stack<DiskControl>();
        }

        public Pole(Canvas CavasRod)
        {
            CavasRod.Tag = stack = new Stack<DiskControl>();
        }

        /// <summary>
        /// HAM KHOI TAO
        /// </summary>
        /// <param name="numDiskContinue">KHOI TAO SO LUONG DIA MAC DINH KHI NGUOI CHOI CHON</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao so luong dia theo tham so dau vao tu class DiskControl
        ///       2.Them vao CanvasA cac dia vua duoc tao (do rong cua dia lon nhat la 154, dia tiep theo co do rong giam di 10 don vi, 
        ///       dich chuyen qua ben trai 5 don vi) va tuong tu voi cac dia con lai cho den het. Do cao giam di 1 luong Contants.SpaceDisk = 31 don vi
        ///       3.Them vao stackA => chua tap cac dia Coc A</work>
        public void Init(int numDisk, Canvas CavasRod)
        {
            if (numDisk < 3) numDisk = 3;
            if (numDisk > Contants.MAXNUMDISC)
            {
                numDisk = Contants.MAXNUMDISC;
            }
            int topDisk = Contants.TopDisk;

            //Khoi tao so luong n dia
            for (int i = 1; i <= numDisk; i++)
            {
                DiskControl disc = new DiskControl(numDisk - i + 1);
                //disc.Text = (numDisk - i + 1).ToString();
                disc.Width = 145 - 10 * i;
                disc.Height = Contants.HEIGHTDISC - 1;
                //disc.Number = numDisk - i + 1;
                //disc.RectangleColor = _arrayColor[i - 1];
                disc.Background = new SolidColorBrush(Colors.Blue);
                

                //Them vao giao dien dia  o vi tri thu i
                CavasRod.Children.Add(disc);
                disc.Tag = i.ToString();
                Canvas.SetTop(disc, topDisk);
                Canvas.SetLeft(disc, Contants.LeftCanvas + 5 * i);
                topDisk -= Contants.HEIGHTDISC;

                //Them vao stack dia o vi tri thu i
                stack.Push(disc);
            }
        }

        /// <summary>
        /// HAM KHOI TAO
        /// </summary>
        /// <param name="numDiskContinue">KHOI TAO SO LUONG DIA MAC DINH KHI NGUOI CHOI CHON</param>
        /// <purpose></purpose>
        /// <work>1.Khoi tao so luong dia theo tham so dau vao tu class DiskControl
        ///       2.Them vao CanvasA cac dia vua duoc tao (do rong cua dia lon nhat la 154, dia tiep theo co do rong giam di 10 don vi, 
        ///       dich chuyen qua ben trai 5 don vi) va tuong tu voi cac dia con lai cho den het. Do cao giam di 1 luong Contants.SpaceDisk = 31 don vi
        ///       3.Them vao stackA => chua tap cac dia Coc A</work>
        public void Init4(int numDisk, Canvas CavasRod)
        {
            if (numDisk < 3) numDisk = 3;
            if (numDisk > Contants.MAXNUMDISC4)
            {
                numDisk = Contants.MAXNUMDISC4;
            }

            int topDisk = Contants.TOPDICS4;

            //Khoi tao so luong n dia
            for (int i = 1; i <= numDisk; i++)
            {
                DiskControl disc = new DiskControl(numDisk - i + 1);
                disc.Width = 180 - 10 * i;
                disc.Height = Contants.HEIGHTDISC4 - 1;
                //disc.RectangleColor = _arrayColor[i - 1];
                disc.Background = new SolidColorBrush(Colors.Blue);


                //Them vao giao dien dia  o vi tri thu i
                CavasRod.Children.Add(disc);
                disc.Tag = i.ToString();
                Canvas.SetTop(disc, topDisk);
                Canvas.SetLeft(disc, Contants.LEFTCANVAS4 + 5 * i);
                topDisk -= Contants.HEIGHTDISC4;

                //Them vao stack dia o vi tri thu i
                stack.Push(disc);
            }
        }

        /// <summary>
        /// HAM THEM DIA VAO POLE
        /// </summary>
        /// <param name="numDiskContinue">Them dia "temp" vao "Canvas" voi gia tri SetTop la "getTop"</param>
        /// <purpose></purpose>
        /// <work>1.Kiem tra stack = null thi them vao voi gia tri Top = defaul
        ///       2. Push dia vao stack va Canvas
        ///       3. Lay phan tu tren cung cua stack lay Top va gan cho gia tri tiep theo la Top - Constans.SpaceDisk
        /// </work>
        public void AddDiskIntoPole(Canvas CavasRod, DiskControl temp)
        {
            DiskControl getTop;
            //Truong hop stack = null
            if (IsEmpty())
            {
                stack.Push(temp);
                CavasRod.Children.Add(temp);
                Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                Canvas.SetTop(temp, Contants.TopDisk);
                return;
            }

            getTop = stack.Peek();
            stack.Push(temp);
            CavasRod.Children.Add(temp);
            Canvas.SetLeft(temp, Canvas.GetLeft(temp));
            Canvas.SetTop(temp, Canvas.GetTop(getTop) - Contants.HEIGHTDISC);
        }

        /// <summary>
        /// HAM THEM DIA VAO POLE
        /// </summary>
        /// <param name="numDiskContinue">Them dia "temp" vao "Canvas" voi gia tri SetTop la "getTop"</param>
        /// <purpose></purpose>
        /// <work>1.Kiem tra stack = null thi them vao voi gia tri Top = defaul
        ///       2. Push dia vao stack va Canvas
        ///       3. Lay phan tu tren cung cua stack lay Top va gan cho gia tri tiep theo la Top - Constans.SpaceDisk
        /// </work>
        public void AddDiskIntoPole4(Canvas CavasRod, DiskControl temp)
        {
            DiskControl getTop;
            //Truong hop stack = null
            if (IsEmpty())
            {
                stack.Push(temp);
                CavasRod.Children.Add(temp);
                Canvas.SetLeft(temp, Canvas.GetLeft(temp));
                Canvas.SetTop(temp, Contants.TOPDICS4);
                return;
            }

            getTop = stack.Peek();
            stack.Push(temp);
            CavasRod.Children.Add(temp);
            Canvas.SetLeft(temp, Canvas.GetLeft(temp));
            Canvas.SetTop(temp, Canvas.GetTop(getTop) - Contants.HEIGHTDISC4);
        }

        /// <summary>
        /// HAM XOA DIA TU POLE
        /// </summary>
        /// <param name="numDiskContinue">Them dia "temp" vao "Canvas" voi gia tri SetTop la "getTop"</param>
        /// <purpose></purpose>
        /// <work>1.Kiem tra stack = null thi them vao voi gia tri Top = defaul
        ///       2. Push dia vao stack va Canvas
        ///       3. Lay phan tu tren cung cua stack lay Top va gan cho gia tri tiep theo la Top - Constans.SpaceDisk
        /// </work>
        public DiskControl RemoveDiskFromPole(Canvas CavasRod)
        {
            if (IsEmpty()) return null;
            DiskControl temp = stack.Pop();
            func.Remove(CavasRod, temp.Tag.ToString());
            return temp;
        }

        /// <summary>
        /// HAM THIET DAT GIA TRI TOP KHI CLICK LAN 1
        /// </summary>
        /// <param name="numDiskContinue">T</param>
        /// <purpose></purpose>
        /// <work>
        /// </work>
        public DiskControl SetTopDiskFromPole()
        {
            if (IsEmpty()) return null;
            DiskControl diskTab = stack.Peek();
            Canvas.SetTop(diskTab, 0);
            return diskTab;
        }

        /// <summary>
        /// HAM KIEM TRA STACK RONG
        /// </summary>
        ///
        public bool IsEmpty()
        {
            return (0 == stack.Count);
        }


    }
}
