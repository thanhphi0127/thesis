using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Xna.Framework.Media;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework;
using System.Windows.Resources;
using System.IO;
using System.Linq;
using Microsoft.Phone.Tasks;
using Microsoft.Phone;
using System.Windows.Threading;
using ThapHaNoi_NguyenThanhPhi.Source.Choidon;

namespace ThapHaNoi_NguyenThanhPhi
{
    class Function
    {
        /// <summary>
        /// HAM XOA 1 DIA RA KHOI CANVAS
        /// </summary>
        /// <param name="ContentPanel"></param>
        /// <param name="item"></param>
        /// <param name="targetPanel"></param>
        public void Remove(Canvas _canvas, string numTag)
        {
            var child = (from c in _canvas.Children.OfType<FrameworkElement>()
                         where numTag.Equals(c.Tag)
                         select c).First();

            if (child != null)
            {
                _canvas.Children.Remove(child);
            }
        }

        /// <summary>
        /// TAO CO SO DU LIEU MOI
        /// <work>
        /// Kiểm tra CSDL tồn tại hay chưa. Nếu chưa thì khởi tạo CSDL mới và gọi hàm khởi tạo bảng thành tích cá nhân
        /// </work>
        /// </summary>
        public void CreateLocalDatabase()
        {
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                if (!dataContext.DatabaseExists())
                {
                    dataContext.CreateDatabase();
                    dataContext.SubmitChanges();

                    CreateTable();
                }
            }

        }

        /// <summary>
        /// KHOI TAO BANG THANH TICH CA NHAN
        /// <work>TRƯỜNG HỢP 3 CỌC VÀ 4 CỌC
        /// 1. Kiểm tra CSDL nếu tồn tại dữ liệu thì bỏ qua
        /// 2. Khởi tạo dữ liệu thành tích chơi đơn cho 3, 4 cọc với số lượng đĩa từ MINNUMDISC đến MAXNUMDISC
        /// 3. Lưu vào CSDL
        /// </work>
        /// </summary>
        public void CreateTable()
        {
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                IQueryable<ThanhTichChoiDon> queryChoidon3 = from c in dataContext.ttcd where c.SODIA == 1 where c.SOCOC == 3 select c;
                ThanhTichChoiDon ttcdAdd3 = queryChoidon3.FirstOrDefault();
                if (ttcdAdd3 == null)
                {
                    for (int i = Contants.MINNUMDISC; i <= Contants.MAXNUMDISC; i++)
                    {
                        ThanhTichChoiDon ttcd = new ThanhTichChoiDon();
                        ttcd.STT = i - 2;
                        ttcd.SODIA = i;
                        ttcd.SOCOC = 3;
                        ttcd.SOBUOC = 0;
                        ttcd.TENNGUOICHOI = "";
                        ttcd.THOIGIAN = "--:--:--";
                        ttcd.NGAYLAP = "--/--/----";
                        dataContext.ttcd.InsertOnSubmit(ttcd);
                        dataContext.SubmitChanges();
                    }
                }

                IQueryable<ThanhTichChoiDon> queryChoidon4 = from c in dataContext.ttcd where c.SODIA == 1 where c.SOCOC == 4 select c;
                ThanhTichChoiDon ttcdAdd4 = queryChoidon4.FirstOrDefault();
                if (ttcdAdd4 == null)
                {
                    for (int i = Contants.MINNUMDISC; i <= Contants.MAXNUMDISC4; i++)
                    {
                        ThanhTichChoiDon ttcd = new ThanhTichChoiDon();
                        ttcd.STT = 10 + i - 2;
                        ttcd.SODIA = i;
                        ttcd.SOCOC = 4;
                        ttcd.SOBUOC = 0;
                        ttcd.TENNGUOICHOI = "";
                        ttcd.THOIGIAN = "--:--:--";
                        ttcd.NGAYLAP = "--/--/----";
                        dataContext.ttcd.InsertOnSubmit(ttcd);
                        dataContext.SubmitChanges();
                    }
                }
            }
        }
        /// <summary>
        /// CAP NHAT BANG THANH TICH CA NHAN
        /// <param name="sococ">Số cọc khi người chơi chọn gồm 3 cọc và 4 cọc</param>
        /// <param name="solan">Số lần chuyển khi người chơi thắng cuộc</param>
        /// <param name="tennguoichoi">Tên người chơi nhập vào để lưu. Mặc định là "Người chơi"</param>
        /// <param name="sodia">Số đĩa người chơi chọn trước đó</param>
        /// <param name="thoigian">Thời gian hoàn tất</param>
        /// <work>1. Nếu số bước trong CSDL = 0 hoặc thời gian di chuyển thực tế nhỏ hơn thời gian trong CSDL thì tiến thành cập nhật
        ///       2. Ngược lại nếu thời gian gian di chuyển thực tế  = thời gian trong CSDL thì xét đến số lần chuyển
        ///       3. Số lần chuyển nhỏ hơn sẽ được cập nhật</work>
        /// </summary>
        public void UpdateTable(TextBox tennguoichoi, TextBlock thoigian, TextBlock solan, int sodia, int sococ)
        {
            using (ThanhTichChoiDonDataContext dataContext = new ThanhTichChoiDonDataContext(Contants.connection))
            {
                IQueryable<ThanhTichChoiDon> query = from c in dataContext.ttcd where c.SODIA == sodia where c.SOCOC == sococ select c;
                ThanhTichChoiDon updateThanhTich = query.FirstOrDefault();
                int sobuoc = Convert.ToInt32(solan.Text);

                if (updateThanhTich.SOBUOC == 0 || String.Compare(updateThanhTich.THOIGIAN, thoigian.Text) > 0)
                {
                    updateThanhTich.SOBUOC = sobuoc;
                    updateThanhTich.THOIGIAN = thoigian.Text;
                    updateThanhTich.TENNGUOICHOI = tennguoichoi.Text;
                    updateThanhTich.NGAYLAP = setDate(DateTime.Now.Day.ToString()) + "/" + setDate(DateTime.Now.Month.ToString()) +  "/" + DateTime.Now.Year.ToString();
                }
                else if (String.Compare(updateThanhTich.THOIGIAN, thoigian.Text) == 0)
                {
                    if (updateThanhTich.SOBUOC > sobuoc)
                    {
                        //if so buoc thuc te < so buoc trong CSDL
                        updateThanhTich.SOBUOC = sobuoc;
                        updateThanhTich.TENNGUOICHOI = tennguoichoi.Text;
                        updateThanhTich.NGAYLAP = setDate(DateTime.Now.Day.ToString()) + "/" + setDate(DateTime.Now.Month.ToString()) + "/" + DateTime.Now.Year.ToString();
                    }
                }

                dataContext.SubmitChanges();
            }
        }

        /// <summary>
        /// HAM DAT LAI GIA TRI NGAY THANG
        /// <work>1. Nếu tham số nhỏ hơn 10 thì thêm vào số 0. Ngược lại không thêm vào</work>
        /// </summary>
        string setDate(string stringDate)
        {
            if (Convert.ToInt32(stringDate.ToString()) < 10)
            {
                return ("0" + stringDate.ToString());
            }
            return stringDate;
        }
    }

    public static class Client
    {
        public static string username = "";
    }
}
