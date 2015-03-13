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
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace ThapHaNoi_NguyenThanhPhi.Source.Choidon
{
    [Table]
    public class ThanhTichChoiDon
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int STT
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int SODIA
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string TENNGUOICHOI
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int SOBUOC
        {
            get;
            set;
        }
        [Column(CanBeNull = false)]
        public string THOIGIAN
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string NGAYLAP
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public int SOCOC
        {
            get;
            set;
        }
    }
}
