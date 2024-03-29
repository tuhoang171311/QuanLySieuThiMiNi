﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;


namespace DoAnSieuThiMinik
{
    public partial class frmDanhSachSanPham : Form
    {
        HANGHOA_DAL hanghoa = new HANGHOA_DAL();
        string ma, ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        ADO ado = new ADO();
        public frmDanhSachSanPham()
        {
            InitializeComponent();
        }

        private void frmDanhSachSanPham_Load(object sender, EventArgs e)
        {
            dataGridViewDanhSachHangHoa.DataSource = hanghoa.getAllDataHangHoa();
            cbMaLoai.DataSource = hanghoa.getCBLoaiHang();
            cbMaLoai.DisplayMember = "TenLoai";
            cbMaLoai.ValueMember = "MaLoai";
            cbMaNSX.DataSource = hanghoa.getCBNhaSX();
            cbMaNSX.DisplayMember = "TenNSX";
            cbMaNSX.ValueMember = "MaNSX";
            //dataGridViewDanhSachHangHoa.DataSource = ado.getChiTietHoaDonData();
            ThemDuLieuDVT();
          
        }
        public void ThemDuLieuDVT() {
            cbDVT.Items.Add("Lon");
            cbDVT.Items.Add("Bịch");
            cbDVT.Items.Add("Chai");
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaHang.Text) || String.IsNullOrEmpty(txtTenHang.Text))
            {
                MessageBox.Show("Vui  lòng điền đủ thông tin!!");
                if (hanghoa.KiemTraKhoaChinhMaHg(txtMaHang.Text) == 0) {
                    MessageBox.Show("Trùng khóa chính, Vui lòng nhập lại!!");
                    return;
                }
            }
            else {
                if (hanghoa.ThemHangHoa(txtMaHang.Text, cbDVT.Text, txtTenHang.Text, cbMaLoai.SelectedValue.ToString(), cbMaNSX.SelectedValue.ToString()) == 1) {
                    MessageBox.Show("Thêm thành công!!");
                    dataGridViewDanhSachHangHoa.DataSource = hanghoa.getAllDataHangHoa();
                }
                else{
                    MessageBox.Show("Thêm thất bại,vui lòng kiểm tra lại thông tin!!");
                }
            }
        }

        private void dataGridViewDanhSachHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //frm.Show();
        }

        private void dataGridViewDanhSachHangHoa_DoubleClick(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.sender(dataGridViewDanhSachHangHoa.CurrentRow.Cells[0].Value.ToString());
        }

        private void dataGridViewDanhSachHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewDanhSachHangHoa.CurrentRow != null)
            {
                this.Ma = dataGridViewDanhSachHangHoa.CurrentRow.Cells[0].Value.ToString();
                this.Ten = dataGridViewDanhSachHangHoa.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
        }
    }
}
