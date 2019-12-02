using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnSieuThiMinik
{
    public partial class QL_NguoiDung
    {
        public int Check_Config()
        {
            if (Properties.Settings.Default.QL_SieuThiMiniConnectionString== string.Empty)
                return 1;
            SqlConnection _Sqlconn = new SqlConnection(Properties.Settings.Default.QL_SieuThiMiniConnectionString);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;
            }
            catch
            {
                return 2;
            }
        }

        public enumLogin.LoginResult Check_User(String pUser, String pPass)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from QL_NguoiDung where TenDangNhap='" + pUser + "' and MatKhau = '" + pPass + "'",
                                                            Properties.Settings.Default.QL_SieuThiMiniConnectionString);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return enumLogin.LoginResult.Invalid;
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
                return enumLogin.LoginResult.Disabled;
            return enumLogin.LoginResult.Success;
        }

        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        public DataTable getDBName(string pServer, string pUser, string pPass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " + pPass + "");
            da.Fill(dt);
            return dt;
        }

        public void SaveConfig(string pServer, string pUser, string pPass, string pDBname)
        {
            DoAnSieuThiMinik.Properties.Settings.Default["_1_LTWNCConnectionString"] = "Data Source=" + pServer + ";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";pwd = " + pPass + "";
            DoAnSieuThiMinik.Properties.Settings.Default.Save();
        }
    }
}
