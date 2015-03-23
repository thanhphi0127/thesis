using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Security.Cryptography;

namespace WebServiceForTesting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection conn;
        SqlCommand cmd;
        string strConnect = @"Data Source=THANHPHI\SQLEXPRESS;Initial Catalog=TowerHanoi;Integrated Security=True";
        //string strConnect = @"Server=THANHPHI\SQLEXPRESS;Database=TowerHanoi;Trusted_Connection=True;";
        DataTable table;
        SqlDataAdapter da;

        /// <summary>
        /// HAM MA HOA MAT KHAU
        /// </summary>
        /// <param name="data">Chuoi mat khau truyen vao</param>
        /// <purpose></purpose>
        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        /// <summary>
        /// HAM KIEM TRA TAI KHOAN NGUOI CHOI
        /// </summary>
        /// <param name="tk">TEN DANG NHAP</param>
        /// <param name="mk">MAT KHAU</param>
        /// <purpose></purpose>
        /// <work>1.Ma hoa mat khau theo chuan MD5
        ///       2.Kiem tra tai khoan, neu ton tai return true. Nguoc lai return false</work>
        public bool CheckUser(string tk, string mk)
        {
            int count = 0;
            string md5MK = md5(mk);

            conn = new SqlConnection(strConnect);
            conn.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].NGUOICHOI WHERE TAIKHOAN = '" + tk + "' AND MATKHAU = '" + md5MK + "'", conn);
            count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return (count != 0) ? true : false;
        }

        /// <summary>
        /// HAM TAO TAI KHOAN NGUOI CHOI
        /// </summary>
        /// <param name="tk">TEN DANG NHAP</param>
        /// <param name="mk">MAT KHAU</param>
        /// <purpose></purpose>
        /// <work>1.Ma hoa mat khau theo chuan MD5
        ///       2.Kiem tra tai khoan ton tai hay chua, neu roi thi return true. Nguoc lai sang buoc 3.
        ///       3.Them tai khoan vao CSDL</work>
        public bool CreateUser(string tk, string mk)
        {
            string md5MK = md5(mk);

            conn = new SqlConnection(strConnect);
            conn.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].NGUOICHOI WHERE TAIKHOAN = '" + tk + "'", conn);
            int exsit = (Int32)cmd.ExecuteScalar();
            if (exsit.Equals(0))
            {
                cmd = new SqlCommand("INSERT INTO [dbo].NGUOICHOI VALUES('" + tk + "', '" + md5MK + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else
            {
                conn.Close();
                return false;
            }
        }

        /// <summary>
        /// HAM LAY DANH SACH PHONG CHOI
        /// </summary>
        /// <purpose></purpose>  
        public List<PhongChoi> DanhSachPhongChoi()
        {
            List<PhongChoi> rooms_list = new List<PhongChoi>();

            using (TowerHanoiEntities database = new TowerHanoiEntities())
            {
                var rooms = from x in database.PHONGCHOIs
                            select new PhongChoi
                            {
                                TENPHONG = x.TENPHONG,
                                MATKHAUPHONG = x.MATKHAU,
                                CHUPHONG = x.CHUPHONG,
                                SOLUONG = x.SOLUONG
                            };
                rooms_list = rooms.ToList();
                return rooms_list;
            }
        }

        /// <summary>
        /// HAM TAO PHONG CHOI MOI
        /// </summary>
        /// <purpose></purpose>
        public string CreateNewRoom(string tk, string mk, int soluong, int sodia, string tenphong)
        {
            ////try
            //{
            string md5MK;
            if (mk == "")
            {
                md5MK = md5(mk);
            }
            else md5MK = "";

                int tinhtrang = 0;
                conn = new SqlConnection(strConnect);
                conn.Open();

                int max = MaxID("MAPHONG", "PHONGCHOI");

                cmd = new SqlCommand("INSERT INTO [dbo].PHONGCHOI VALUES(" + max + "," + sodia + ",'" + tenphong + "'," + soluong + "," + tinhtrang + ",'" + md5MK + "','','" + tk + "')", conn);
                //cmd.ExecuteNonQuery();
              // "INSERT INTO [dbo].PHONGCHOI VALUES(3,0,\'\',0,0,\'\',\'\',\'\')"
                //"INSERT INTO [dbo].PHONGCHOI VALUES(3,0,\'a\',0,0,\'\',\'\',\'a\')"
                conn.Close();
                return "INSERT INTO [dbo].PHONGCHOI VALUES(" + max + "," + sodia + ",'" + tenphong + "'," + soluong + "," + tinhtrang + ",'" + md5MK + "','','" + tk + "')";
           /* }
            catch (Exception)
            {
                return false;
            }
            */
        }

        public int MaxID(string ColumnName, string TableName)
        {
            try
            {
                conn = new SqlConnection(strConnect);
                conn.Open();
                cmd = new SqlCommand("SELECT MAX(" + ColumnName + ") FROM " + TableName, conn);
                int max = (Int32)cmd.ExecuteScalar();
                conn.Close();
                return (max + 1);
            } catch 
            {
                return 0;
            }
    
        }
    }
}
