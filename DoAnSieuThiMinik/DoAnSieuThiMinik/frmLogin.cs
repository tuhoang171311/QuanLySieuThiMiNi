﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace DoAnSieuThiMinik
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        QL_NguoiDung CauHinh = new QL_NguoiDung();

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
            MessageBox.Show("Không được bỏ trống " + lblUsername.Text.ToLower());
            this.txtUsername.Focus();
            return;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
            MessageBox.Show("Không được bỏ trống " + lblPassword.Text.ToLower());
            this.txtPassword.Focus();
            return;
            }
            int kq=CauHinh.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
            ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
            MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
            //ProcessConfig();
            }
            if (kq == 2)
            {
            MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
            //ProcessConfig();
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        public void ProcessLogin()
        {
        DoAnSieuThiMinik.enumLogin.LoginResult result;
        result = CauHinh.Check_User(txtUsername.Text, txtPassword.Text); //
        if (result == DoAnSieuThiMinik.enumLogin.LoginResult.Invalid)
        {
            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            return;
        }
        // Account had been disabled
        else if (result == DoAnSieuThiMinik.enumLogin.LoginResult.Disabled)
        {
            MessageBox.Show("Tài khoản bị khóa");
            return;
        }
        if (Program.mainForm == null || Program.mainForm.IsDisposed)
        {
            Program.mainForm = new Form1(txtUsername.Text);
        }
        this.Visible = false;
        Program.mainForm.Show();
        }



    }
}