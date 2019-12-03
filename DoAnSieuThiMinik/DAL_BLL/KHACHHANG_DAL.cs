using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
   public class KHACHHANG_DAL
    {
       QLSTDataContext qlst = new QLSTDataContext();
       public List<KHACHHANG> getAllDataKhachHang() {
           return qlst.KHACHHANGs.Select(t => t).ToList();
       }
       public int ThemKH(string makh,string tenkh,string dchi,string sdt,DateTime ngaysinh,string loaikh) {
           try
           {
               KHACHHANG kh = new KHACHHANG();
               kh.MaKH = makh;
               kh.HoTen = tenkh;
               kh.DChi = dchi;
               kh.SDT = sdt;
               kh.NgaySinh = ngaysinh;
               kh.MaLoaiKhach = loaikh;
               qlst.KHACHHANGs.InsertOnSubmit(kh);
               qlst.SubmitChanges();
               return 1;
           }
           catch {
               return 0;
           }
       }
       public int XoaKH(string ma) {
           try
           {
               KHACHHANG kh = qlst.KHACHHANGs.Where(t => t.MaKH == ma).FirstOrDefault();
               qlst.KHACHHANGs.DeleteOnSubmit(kh);
               qlst.SubmitChanges();
               return 1;
           }
           catch {
               return 0;
           }
       }
       public int SuaKh(string makh,string hoten, string diachi, string sdt, DateTime ngaysinh, string maloaikhach) {
           try
           {
               KHACHHANG kh = qlst.KHACHHANGs.Where(t => t.MaKH == makh).FirstOrDefault();
               kh.HoTen = hoten;
               kh.DChi = diachi;
               kh.SDT = sdt;
               kh.NgaySinh = ngaysinh;
               kh.MaLoaiKhach = maloaikhach;
               qlst.SubmitChanges();
               return 1;
           }
           catch
           {
               return 0;
           }
       }
       public List<LOAIKHACH> getCbMaLoaiKhach() {
           return qlst.LOAIKHACHes.Select(t => t).ToList();
       }
    }
}
