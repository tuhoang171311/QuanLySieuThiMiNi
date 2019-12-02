using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL_BLL;

namespace DoAnSieuThiMinik
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        SIEUTHI_DAL sieuthi = new SIEUTHI_DAL();
        ADO ado = new ADO();
        String _TenDangNhap;
        HANGHOA_DAL hh = new HANGHOA_DAL();
        
        
        public Form1(String txtUsername)
        {
            InitializeComponent();
            _TenDangNhap = txtUsername;

            // try
            // {
            //     this.qL_PhanQuyen1TableAdapter.NguoiDung_PhanQuyen(this.dataSet1.QL_PhanQuyen1, tendangnhap);
            // }
            // catch (System.Exception ex)
            // {
            //     System.Windows.Forms.MessageBox.Show(ex.Message);
            // }
            // int n=qL_PhanQuyen1DataGridView.Rows.Count;
            //// n = 5;
            // for (int i = 0; i < n; i++)
            // {
            //     if (qL_PhanQuyen1DataGridView.Rows[i].Cells[1].Selected == false)
            //     {
            //         String mamanhinh= qL_PhanQuyen1DataGridView.Rows[i].Cells[0].Value.ToString();
            //         if (mamanhinh == "MH0001")
            //             MH001.PageVisible = false;
            //         else if (mamanhinh == "MH0002")
            //             MH002.PageVisible = false;
            //         else if (mamanhinh == "MH0003")
            //             MH003.PageVisible = false;
            //         else if (mamanhinh == "MH0004")
            //             MH004.PageVisible = false;
            //         else if (mamanhinh == "MH0005")
            //             MH005.PageVisible = false;
            //         else if (mamanhinh == "MH0006")
            //             MH006.PageVisible = false;
            //         else if (mamanhinh == "MH0007")
            //             MH007.PageVisible = false;
            //     }

            // }

        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            foreach (var item in navigationPane1.Pages)              
                    item.PageVisible = false;


            // TODO: This line of code loads data into the 'dataSet_QLSieuThiMini.QL_PhanQuyen' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'dataSet_QLSieuThiMini.QL_NhomNguoiDung' table. You can move, or remove it, as needed.
            this.qL_NhomNguoiDungTableAdapter.Fill(this.dataSet_QLSieuThiMini.QL_NhomNguoiDung);
            // TODO: This line of code loads data into the 'dataSet_QLSieuThiMini.QL_NguoiDung' table. You can move, or remove it, as needed.
            this.qL_NguoiDungTableAdapter.Fill(this.dataSet_QLSieuThiMini.QL_NguoiDung);


            String nhomND = (String)qL_NguoiDungNhomNguoiDungDKTableAdapter.GetMaNhomNguoiDung(_TenDangNhap);
            this.qL_GetPhanQuyenTableAdapter.Fill(this.dataSet_QLSieuThiMini.QL_GetPhanQuyen, nhomND);
            
            int n = qL_GetPhanQuyenDataGridView.RowCount;
            List<String> dsMaManHinh = new List<string>();
            for (int i = 0; i < n; i++)
            {
                try
                {
                    if ((bool)qL_GetPhanQuyenDataGridView.Rows[i].Cells[2].Value == true)
                        dsMaManHinh.Add(qL_GetPhanQuyenDataGridView.Rows[i].Cells[0].Value.ToString());

                }
                catch { }
            }

            for (int j=0;j<dsMaManHinh.Count;j++)
            {
                foreach (var item in navigationPane1.Pages)
                    if (item.Name == dsMaManHinh[j])
                        item.PageVisible = true;

            }
            cbMaHD2.DataSource = sieuthi.getMaHD();
          //  datagridviewCTHD.DataSource = sieuthi.GETCTHData();
          //  datagridviewCTHD.DataSource = sieuthi.getDataCTHD2();
           datagridviewCTHD.DataSource = ado.getChiTietHoaDonData();
           dataGridViewDanhSachSP.DataSource = hh.getAllDataHangHoa();
           cbMaLoai.DataSource = hh.getCBLoaiHang();
           cbMaLoai.DisplayMember = "TenLoai";
           cbMaLoai.ValueMember = "MaLoai";
           cbMaNSX.DataSource = hh.getCBNhaSX();
           cbMaNSX.DisplayMember = "TenNSX";
           cbMaNSX.ValueMember = "MaNSX";

           ThemDuLieuDVT();
            
        }

        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
            if (menu is ToolStripMenuItem &&
            ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
            {
            FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems,
            pScreenName, pEnable);
            menu.Enabled =
            CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
            menu.Visible = menu.Enabled;
            }
            else if (string.Equals(pScreenName, menu.Tag))
            {
            menu.Enabled = pEnable;
            menu.Visible = pEnable;
            }
            }
        }


        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
            if (menuItem is ToolStripMenuItem && menuItem.Enabled)
            {
            return true;
            }
            else if (menuItem is ToolStripSeparator)
            {
            continue;
            }
            }
            return false;
        }






        private void qL_NguoiDungBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.qL_NguoiDungBindingSource.EndEdit();


        }

        private void phanQuyen_ManHinhToolStripButton_Click(object sender, EventArgs e)
        {


        }

        private void qL_NhomNguoiDungGridControl_Click(object sender, EventArgs e)
        {

        }

        private void gridView3_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void maNhomNguoiDungToolStripTextBox_Click(object sender, EventArgs e)
        {

        }

        private void qL_NhomNguoiDungGridControl_FocusedViewChanged(object sender, DevExpress.XtraGrid.ViewFocusEventArgs e)
        {

        }

        private void qL_NhomNguoiDungDataGridView_SelectionChanged(object sender, EventArgs e)
        {


        }

        private void nguoiDung_PhanQuyenToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void tenDangNhapToolStripTextBox_Click(object sender, EventArgs e)
        {

        }

        private void navigationPane1_Click(object sender, EventArgs e)
        {

        }

        private void fill_DKToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        private void qL_NhomNguoiDungComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboByCondition();

        }

        public void LoadComboByCondition()
        {
        if (qL_NhomNguoiDungComboBox.SelectedValue != null)
            this.qL_NguoiDungNhomNguoiDungDKTableAdapter.Fill_DK(this.dataSet_QLSieuThiMini.QL_NguoiDungNhomNguoiDungDK, qL_NhomNguoiDungComboBox.SelectedValue.ToString());

        this.qL_GetPhanQuyenTableAdapter.Fill(this.dataSet_QLSieuThiMini.QL_GetPhanQuyen, qL_NhomNguoiDungComboBox.SelectedValue.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow item in qL_NguoiDungDataGridView.SelectedRows)
            {
            // Nhớ kiểm tra trước khi thêm trùng khóa chính
                if(this.qL_NguoiDungNhomNguoiDungDKTableAdapter.KiemTraKhoa(item.Cells[0].Value.ToString(), qL_NhomNguoiDungComboBox.SelectedValue.ToString()) > 0)
                {
                MessageBox.Show("Đã tồn tại");
                }
                else
                {
                this.qL_NguoiDungNhomNguoiDungDKTableAdapter.Insert1(item.Cells[0].Value.ToString(), qL_NhomNguoiDungComboBox.SelectedValue.ToString());
                }
            }
            LoadComboByCondition();
        }

        private void btnRaNhom_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in qL_NguoiDungNhomNguoiDungDKDataGridView.SelectedRows)
            {
            if
            (this.qL_NguoiDungNhomNguoiDungDKTableAdapter.Delete1(item.Cells[0].Value.ToString(), qL_NhomNguoiDungComboBox.SelectedValue.ToString()) == 1)
            {
            MessageBox.Show("Thành công");
            }
            else
            {
            MessageBox.Show("Thất bại");
            }
            LoadComboByCondition();
            }
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
           

        }

        private void qL_GetPhanQuyenDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string _NhomNguoiDung = qL_NhomNguoiDungComboBox.SelectedValue.ToString();
            foreach (DataGridViewRow item in qL_GetPhanQuyenDataGridView.Rows)
            {
                try
                {
                    if (this.qL_GetPhanQuyenTableAdapter.KiemTraKhoaChinhPhanQuyen(_NhomNguoiDung, item.Cells[0].Value.ToString()) == null)
                    {
                        try
                        {
                            qL_GetPhanQuyenTableAdapter.InsertQuery(_NhomNguoiDung, item.Cells[0].Value.ToString(), (bool)(item.Cells[2].Value));
                        }
                        catch
                        {

                            qL_GetPhanQuyenTableAdapter.InsertQuery(_NhomNguoiDung, item.Cells[0].Value.ToString(), false);
                        }
                    }
                    else
                    {

                        qL_GetPhanQuyenTableAdapter.UpdateQuery((item.Cells[2] == null) ? false : (bool)(item.Cells[2].Value), _NhomNguoiDung, item.Cells[0].Value.ToString());
                    }
                }
                catch { }
            }
            
        }

        private void btnHienThiDanhSachSanPham_Click(object sender, EventArgs e)
        {
            frmDanhSachSanPham dssp = new frmDanhSachSanPham();
            dssp.Show();
        }

        private void btnHienThiDanhSachSanPham_Click_1(object sender, EventArgs e)
        {
            frmDanhSachSanPham dssp = new frmDanhSachSanPham();
            dssp.Show();
        }

        private void SF002_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaHang.Text) || String.IsNullOrEmpty(txtTenHang.Text))
            {
                MessageBox.Show("Vui  lòng điền đủ thông tin!!");
            }
            else
            {
                if (hh.ThemHangHoa(txtMaHang.Text, cbDVT.Text, txtTenHang.Text, cbMaLoai.SelectedValue.ToString(), cbMaNSX.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Thêm thành công!!");
                    dataGridViewDanhSachSP.DataSource = hh.getAllDataHangHoa();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại,vui lòng kiểm tra lại thông tin!!");
                }
            }
        }

        private void dataGridViewDanhSachSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHang.Text = dataGridViewDanhSachSP.CurrentRow.Cells[0].Value.ToString();
            txtTenHang.Text = dataGridViewDanhSachSP.CurrentRow.Cells[1].Value.ToString();
        }

        public void ThemDuLieuDVT()
        {
            cbDVT.Items.Add("Lon");
            cbDVT.Items.Add("Bịch");
            cbDVT.Items.Add("Chai");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma;
            try
            {
                ma = dataGridViewDanhSachSP.CurrentRow.Cells[0].Value.ToString();
                if (hh.XoaHangHoa(ma) == 1)
                {
                    MessageBox.Show("Xóa thành công!!");
                    dataGridViewDanhSachSP.DataSource = hh.getAllDataHangHoa();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!!");
                }
            }
            catch
            {
                return;
            }
        }

        private void cbDVT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void cbMaNSX_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SF003_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
