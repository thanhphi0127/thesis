using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Threading;

namespace ThapHaNoi_NguyenThanhPhi
{
    public static class MoveCalculation
    {
        static int moveCounter = 0;

        /// <summary>
        /// MẢNG TAM GIÁC PASCAL ĐỂ XÁC ĐỊNH HỆ SỐ CHIA TỐI ƯU L
        /// </summary>
        /// <purpose>
        /// Giá trị trong mảng là giá trị trong tam giác Pascal với:
        /// a) Chỉ số mảng là giá trị x
        /// b) Giá trị của mảng là cột thứ 4 (P = 4) trong tam giác Pascal
        /// x\P| 2 | 3 | 4 |.....
        /// 0  |1  |
        /// 1  |1  |1  |
        /// 2  |1  |2  |1  |
        /// 3  |1  |3  |3  |1  |
        /// 4  |1  |4  |6  |4  |
        /// 5  |1  |5  |10 |10 |
        /// 6  |1  |6  |15 |20 |
        /// </purpose>
        static int[] arrayPascal = {0, 0, 1, 3, 6, 10, 15, 21};
        static public int miliseconds;
        public static List<Move> moves { get; set; }

        public static List<Move> SolveHanoi3(int numDisk, BackgroundWorker worker)
        {
            moveCounter = 0;
            moves = new List<Move>();
            Hanoi3(numDisk, "A", "C", "B", worker);
            return moves;
        }

        public static List<Move> SolveHanoi4(int numDisk, BackgroundWorker worker)
        {
            moveCounter = 0;
            moves = new List<Move>();
            Hanoi4(numDisk, 4, "A", "D", "B", "C", worker);
            return moves;
        }

        public static int GetNumMove()
        {
            return moveCounter;
        }

        /// <summary>
        /// HAM LOI GIAI BAI TOAN 3 COC
        /// </summary>
        /// <param>Tham so n la so luong dia</param>
        /// <purpose>
        /// </purpose>
        public static void Hanoi3(int n, string RodA, string RodC, string RodB, BackgroundWorker worker)
        {
            if (n == 1)
            {
                /*
                moves.Add(new Move(RodA, RodC));
                 * */
                worker.ReportProgress(0, string.Format("{0}/{1}", RodA, RodC));
                Thread.Sleep(miliseconds);
                return;
            }
            Hanoi3(n - 1, RodA, RodB, RodC, worker);
            /*
            moves.Add(new Move(RodA, RodC));
             * */
            worker.ReportProgress(0, string.Format("{0}/{1}", RodA, RodC));
            Thread.Sleep(miliseconds);

            Hanoi3(n - 1, RodB, RodC, RodA, worker);
        }


        /// <summary>
        /// HAM LOI GIAI BAI TOAN 4 COC
        /// </summary>
        /// <param>Tham so n la so luong dia</param>
        /// <work>
        /// Buoc 1: Xac dinh so chia toi uu trong tam giac Pascal
        /// Buoc 2: Chuyen l dia nho tre cung sang coc trunggian 1, su dung 4 coc
        /// Buoc 3: Chuyen n-l dia lon nhat tu coc 1 sang coc 4 (chi su dung 3 coc) => coc 2 dang chua tap l dia nho nhat
        /// Bước 4: Chuyen l dia nho ban dau ve coc dich.
        /// ĐIỀU KIỆN DỪNG CỦA THUẬT GIẢI
        /// 1. Với số đĩa = 1 thì chuyển từ nguồn qua đích
        /// 2. A/ Với số đĩa = 2 thì chuyển 2 dĩa qua cọc trung gian 1, hoặc trung gian 2 (PHÁT ĐĨA)
        ///    B/ Chuyển đĩa 1 qua cọc đích
        ///    C/ Chuyển đĩa 2 từ cọc trung gian trước đó qua cọc đích (THU ĐĨA)
        /// </work>>
        public static void Hanoi4(int n, int socot, string cotnguon, string cotdich, string trunggian1, string trunggian2, BackgroundWorker worker)
        {
            if (n == 1)
            {
                /*
                moves.Add(new Move(cotnguon, cotdich));
                 * */
                worker.ReportProgress(0, string.Format("{0}/{1}", cotnguon, cotdich));
                Thread.Sleep(miliseconds);
                return;
            }

            if (n == 2)
            {
                /*
                moves.Add(new Move(cotnguon, trunggian1));
                moves.Add(new Move(cotnguon, cotdich));
                moves.Add(new Move(trunggian1, cotdich));
                 * */
                worker.ReportProgress(0, string.Format("{0}/{1}", cotnguon, trunggian1));
                Thread.Sleep(miliseconds);
                worker.ReportProgress(0, string.Format("{0}/{1}", cotnguon, cotdich));
                Thread.Sleep(miliseconds);
                worker.ReportProgress(0, string.Format("{0}/{1}", trunggian1, cotdich));
                Thread.Sleep(miliseconds);
                return;
            }

            //Bước 1
            int l = sochia(n);
            //Bước 2
            Hanoi4(l, 4, cotnguon, trunggian1, trunggian2, cotdich, worker);
            //Bước 3
            Hanoi3(n - l, cotnguon, cotdich, trunggian2, worker);
            //Bước 4
            Hanoi4(l, 4, trunggian1, cotdich, trunggian2, cotnguon, worker);

        }

        /// <summary>
        /// HAM TINH SO CHIA TOI UU L
        /// </summary>
        /// <param>Tham so n la so luong dia</param>
        /// <purpose>
        /// 1. Nếu n == arrayPascal[i] => n là số tam giác thì trả về giá trị n - (i - 1)
        /// 2. Nếu n nhỏ hơn arrayPascal[i] => n không là số tam giá thì trả về giá trị n - (i - 1 - 1) 
        ///    (THeo thuật toán Frame – Stewart) trả về giá trị k trước đó nhỏ hơn 1 đơn vị)
        /// </purpose>
        public static int sochia(int n)
        {
            int l = 0;
            for (int i = 2; i <= 7; i++)
            {
                if (n == arrayPascal[i])
                {
                    return (n - i + 1);
                }

                if (n < arrayPascal[i])
                {
                    return (n - i + 2);
                }

            }
            return l;
        }

    }
}
