using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThapHaNoi_NguyenThanhPhi
{
    class Contants
    {
        /// <summary>
        /// CHIỀU CAO CỦA MỖI ĐĨA (TRƯỜNG HỢP 3 CỌC)
        /// </summary>
        public const int HEIGHTDISC = 32;

        /// <summary>
        /// CHIỀU CAO CỦA MỖI ĐĨA (TRƯỜNG HỢP 4 CỌC)
        /// </summary>
        public const int HEIGHTDISC4 = 28;

        /// <summary>
        /// KHOẢNG CÁCH PHÍA BÊN TRÁI CỦA ĐĨA KHI THÊM VÀO CANVAS (TRƯỜNG HỢP 3 CỌC)
        /// </summary>
        public const int LeftCanvas = 38;

        /// <summary>
        /// KHOẢNG CÁCH PHÍA BÊN TRÁI CỦA ĐĨA KHI THÊM VÀO CANVAS (TRƯỜNG HỢP 4 CỌC)
        /// </summary>
        public const int LEFTCANVAS4 = 20;

        /// <summary>
        /// GIÁ TRỊ TOP CỦA CANVAS KHI THEM ĐĨA ĐẦU TIÊN VÀO CỌC (TRƯỜNG HỢP 3 CỌC)
        /// </summary>
        public const int TopDisk = 350;

        /// <summary>
        /// GIÁ TRỊ TOP CỦA CANVAS KHI THEM ĐĨA ĐẦU TIÊN VÀO CỌC (TRƯỜNG HỢP 4 CỌC)
        /// </summary>
        public const int TOPDICS4 = 380;

        /// <summary>
        /// CHUỖI ĐỊNH DẠNG THỜI GIAN MẶC ĐỊNH (ĐƯỢC SỬ DỤNG TRONG SỰ KIỆN TIMETICK
        /// </summary>
        public const string TimeFormat = "{0:00}:{1:00}:{2:00}";
        public const string DefaultCountValue = "0";

        /// <summary>
        /// GIỜ MẶC ĐỊNH KHI MỚI BẮT ĐẦU CHƠI
        /// </summary>
        public const string DefaultTimeValue = "00:00:00";
        public const int TopRod = 0;
        public const int LeftRod = 0;

        /// <summary>
        /// GIÁ TRỊ NHỎ NHẤT CỦA NUMDISK (SỐ ĐĨA NHỎ NHẤT) DÙNG ĐỂ KHỞI TẠO BẢNG THÀNH TÍCH NGƯỜI CHƠI
        /// </summary>
        public const int MINNUMDISC = 3;

        /// <summary>
        /// GIÁ TRỊ LỚN NHẤT CỦA NUMDISK (SỐ ĐĨA LỚN NHẤT VỚI 3 CỌC)
        /// </summary>
        public const int MAXNUMDISC = 10;

        /// <summary>
        /// GIÁ TRỊ LỚN NHẤT CỦA NUMDISK (SỐ ĐĨA LỚN NHẤT VỚI43 CỌC)
        /// </summary>
        public const int MAXNUMDISC4 = 10;

        /// <summary>
        /// TÊN CSDL KHI LƯU BẢNG THÀNH TÍCH CÁ NHÂN
        /// </summary>
        public const string connection = @"isostore:/ThanhTichCaNhan.sdf";
    }
}
