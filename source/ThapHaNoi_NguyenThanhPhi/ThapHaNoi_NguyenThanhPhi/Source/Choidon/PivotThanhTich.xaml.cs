using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon
{
    public partial class PivotThanhTich : PhoneApplicationPage
    {
        Sounds sounds = new Sounds();
        public PivotThanhTich()
        {
            InitializeComponent();
        }

        private void AutoLoadThanhTichCaNhan(object sender, RoutedEventArgs e)
        {
            LoadThanhTichCaNhan(3);
            LoadThanhTichCaNhan(4);
            sounds.Play("bangxephang");
        }

        void LoadThanhTichCaNhan(int sococ)
        {
            int top = 0;
            int i = 1;
            IList<ThanhTichChoiDon> ttcd = this.GetThanhTich(sococ);
            ThanhTichCaNhanControl init = new ThanhTichCaNhanControl();
            if (sococ.Equals(3))
            {
                canvasRank3.Children.Add(init);
            }
            else
            {
                canvasRank4.Children.Add(init);
            }
            Canvas.SetTop(init, top);

            foreach (ThanhTichChoiDon thanhtichchoidon in ttcd)
            {
                top += 47;
                ThanhTichCaNhanControl canhan = new ThanhTichCaNhanControl(thanhtichchoidon, i);
                if (sococ.Equals(3))
                {
                    canvasRank3.Children.Add(canhan);
                }
                else
                {
                    canvasRank4.Children.Add(canhan);
                }
                Canvas.SetTop(canhan, top);
                i++;
            }
        }

        private IList<ThanhTichChoiDon> GetThanhTich(int sococ)
        {
            IList<ThanhTichChoiDon> ttcd = null;
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                IQueryable<ThanhTichChoiDon> query = from c in dataContext.ttcd where c.SOCOC == sococ orderby c.SODIA ascending select c;
                ttcd = query.ToList();
            }
            return ttcd;

        }


        private void DeleteThanhTich(int sococ)
        {
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                IQueryable<ThanhTichChoiDon> query;
                ThanhTichChoiDon thanhtichDelete;
                for (int i = 3; i <= 10; i++)
                {
                    query = from c in dataContext.ttcd where c.SOCOC == sococ where c.SODIA == i select c;
                    thanhtichDelete = query.FirstOrDefault();
                    thanhtichDelete.SOBUOC = 0;
                    thanhtichDelete.TENNGUOICHOI = "";
                    thanhtichDelete.THOIGIAN = "--:--:--";
                    thanhtichDelete.NGAYLAP = "--/--/---";
                    dataContext.SubmitChanges();
                }
            }
        }

        private void imgDeleteThanhTich3(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xóa thành tích cá nhân", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                canvasRank3.Children.Clear();
                DeleteThanhTich(3);
                LoadThanhTichCaNhan(3);
            }
        }

        private void imgDeleteThanhTich4(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sounds.Play("click");
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn xóa?", "Xóa thành tích cá nhân", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                canvasRank4.Children.Clear();
                DeleteThanhTich(4);
                LoadThanhTichCaNhan(4);
            }
        }
    }
}