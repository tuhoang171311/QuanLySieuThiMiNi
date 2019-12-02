using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace DoAnSieuThiMinik
{
    static class Program
    {
        
        public static Form1 mainForm = null;
        public static frmLogin loginForm = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            loginForm = new frmLogin();
            Application.Run(loginForm);
        }
    }
}
