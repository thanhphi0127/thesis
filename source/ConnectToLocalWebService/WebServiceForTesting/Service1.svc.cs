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

namespace WebServiceForTesting
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        SqlConnection conn;
        SqlCommand cmd, cmd1, cmd2;
        string strConnect = @"Data Source=THANHPHI\SQLEXPRESS;Initial Catalog=TowerHanoi;Integrated Security=True";
        //string strConnect = @"Server=THANHPHI\SQLEXPRESS;Database=TowerHanoi;Trusted_Connection=True;";
        DataTable table;
        SqlDataAdapter da;

        public bool CheckUser(string tk, string mk)
        {
            int count = 0;
            conn = new SqlConnection(strConnect);
            conn.Open();
            cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].NGUOICHOI WHERE TAIKHOAN = '" + tk + "' AND MATKHAU = '" + mk + "'", conn);
            count = (Int32)cmd.ExecuteScalar();
            conn.Close();

            return (count != 0) ? true : false;

            /*
            int count = 0;
            using (TowerHanoiEntities database = new TowerHanoiEntities())
            {
                count = (from x in database.NGUOICHOIs
                         where String.Compare(tk, x.TAIKHOAN.Trim()) == 0 &&
                         String.Compare(mk, x.MATKHAU.Trim()) == 0
                         select x.TAIKHOAN).Count();
            }
            return (count == 1) ? true : false;
             * */
        }

        public bool CreateUser(string tk, string mk)
        {
            conn = new SqlConnection(strConnect);
            conn.Open();

            cmd = new SqlCommand("SELECT COUNT(*) FROM [dbo].NGUOICHOI WHERE TAIKHOAN = '" + tk + "'", conn);
            int exsit = (Int32)cmd.ExecuteScalar();
            if (exsit.Equals(0))
            {
                cmd = new SqlCommand("INSERT INTO [dbo].NGUOICHOI VALUES('" + tk + "', '" + mk + "')", conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            else return false;            
        }

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
                                SOLUONG = 2
                            };
                rooms_list = rooms.ToList();
                return rooms_list;
            }
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
