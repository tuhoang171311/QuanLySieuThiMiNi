using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class CHITIETHOADON2
    {
        string mahd;

        public string Mahd
        {
            get { return mahd; }
            set { mahd = value; }
        }
        string tensp;

        public string Tensp
        {
            get { return tensp; }
            set { tensp = value; }
        }
        double dongia;

        public double Dongia
        {
            get { return dongia; }
            set { dongia = value; }
        }
        int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        double thanhtien;

        public double Thanhtien
        {
            get { return thanhtien; }
            set { thanhtien =Dongia*Soluong; }
        }
    }
}
