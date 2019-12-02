using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_BLL
{
    public class ADO
    {
        SqlConnection conn;
        DataTable ta;
        SqlDataAdapter adap;
        public ADO() {
            conn = new SqlConnection(Properties.Settings.Default.QL_SieuThiMiniConnectionString);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch {
                return;
            }
        }

        public DataTable getChiTietHoaDonData(){
            ta = new DataTable();
            string query = "select TenHG,GiaBan,SoLuong,SoLuong*GiaBan as thanhtien from HOADON,CHITIETHD,HANGHOA where HOADON.MaHD=CHITIETHD.MaHD and HANGHOA.MaHG=CHITIETHD.MaHg";
            adap = new SqlDataAdapter(query,conn);
            adap.Fill(ta);
            return ta;
        }
    }
}
