using System;
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
    public partial class frmKhachHang : Form
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KHACHHANG_DAL kh = new KHACHHANG_DAL();
        
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = kh.getAllDataKhachHang();
            cbMaLoaikhach.DataSource = kh.getCbMaLoaiKhach();
            cbMaLoaikhach.DisplayMember = "TenLoaiKhach";
            cbMaLoaikhach.ValueMember = "MaLoaiKhach";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKh.Text) || String.IsNullOrEmpty(txtHoTen.Text) || String.IsNullOrEmpty(txtDiaChi.Text) || String.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!!");
                return;
            }
            else {
                if (kh.ThemKH(txtMaKh.Text, txtHoTen.Text, txtDiaChi.Text, txtSDT.Text, dateNgaysinh.Value, cbMaLoaikhach.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Thêm thành công!!");
                    dataGridView1.DataSource = kh.getAllDataKhachHang();
                }
                else {
                    MessageBox.Show("Thêm thất bại,vui lòng kiểm tra lại!!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma;
            try
            {
                ma = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (kh.XoaKH(ma) == 1)
                {
                    MessageBox.Show("Xóa thành công!!");
                    dataGridView1.DataSource = kh.getAllDataKhachHang();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại! Vui lòng kiểm tra lại!!");
                }
            }
            catch {
                MessageBox.Show("Xóa thất bại! Vui lòng kiểm tra lại!!");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKh.Text) || String.IsNullOrEmpty(txtHoTen.Text) || String.IsNullOrEmpty(txtDiaChi.Text) || String.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!!");
                return;
            }
            else{
                if (kh.SuaKh(txtMaKh.Text, txtHoTen.Text, txtDiaChi.Text, txtSDT.Text, dateNgaysinh.Value, cbMaLoaikhach.SelectedValue.ToString()) == 1)
                {
                    MessageBox.Show("Sửa thành công!!");
                    dataGridView1.DataSource = kh.getAllDataKhachHang();
                }
                else {
                    MessageBox.Show("Sửa thất bại, vui lòng kiểm tra lại!!");
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
