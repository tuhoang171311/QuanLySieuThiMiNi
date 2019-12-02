using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnSieuThiMinik
{
    public partial class frmCauHinh : Form
    {
        public frmCauHinh()
        {
            InitializeComponent();
        }

        QL_NguoiDung CauHinh = new QL_NguoiDung();

        private void cboServer_DropDown(object sender, EventArgs e)
        {
            cboServer.DataSource = CauHinh.GetServerName();
            cboServer.DisplayMember = "ServerName";
        }

        public DataTable GetServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }

        private void cboDataBase_DropDown(object sender, EventArgs e)
        {
            cboDataBase.DataSource = CauHinh.getDBName(cboServer.Text, txtUsername.Text, txtPassword.Text);
            cboDataBase.DisplayMember = "name";
        }

        public DataTable GetDBName(string pServer, string pUser, string pPass)
        {
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases",
        "Data Source=" + pServer + ";Initial Catalog=master;User ID=" + pUser + ";pwd = " +
        pPass + "");
        da.Fill(dt);
        return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cboServer.Text, txtUsername.Text, txtPassword.Text,
            cboDataBase.Text);
            this.Close();
        }
        public void SaveConfig(string pServer, string pUser, string pPass, string pDBname)
        {
        DoAnSieuThiMinik.Properties.Settings.Default["QL_SieuThiMiniConnectionString"] = "Data Source=" + pServer + 

        ";Initial Catalog=" + pDBname + ";User ID=" + pUser + ";pwd = " + pPass + "";
        DoAnSieuThiMinik.Properties.Settings.Default.Save();
        }



    }
}
