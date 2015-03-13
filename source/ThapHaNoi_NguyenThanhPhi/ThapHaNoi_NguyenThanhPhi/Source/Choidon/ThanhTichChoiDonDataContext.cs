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
using System.Data.Linq;

namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon
{
    public class ThanhTichChoiDonDataContext : DataContext
    {
       
        public ThanhTichChoiDonDataContext(string connection) : base(connection) { }
        public Table<ThanhTichChoiDon> ttcd
        {
            get
            {
                return this.GetTable<ThanhTichChoiDon>();
            }
        }
    }
}
