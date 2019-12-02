using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class SIEUTHI_DAL
    {
        CHITIETHD cthd;
        HOADON hd;
        HANGHOA hh;
        QLSTDataContext QLST = new QLSTDataContext();
        public List<String> getMaHD()
        {
            return QLST.HOADONs.Select(t => t.MaHD).ToList<String>();
        }
        public List<CHITIETHD> GETCTHData() { 
            
            var dl=from cthd in QLST.CHITIETHDs
                    join hd in QLST.HOADONs
                    on cthd.MaHD equals hd.MaHD
                    join hh in QLST.HANGHOAs
                    on hh.MaHG equals cthd.MaHg
                    select new{
                        MAHD=cthd.MaHD,
                        TenHG=hh.TenHG,
                        SoLuong=cthd.SoLuong,
                        Tt=cthd.SoLuong*cthd.GiaBan
                        
                    };
            List<CHITIETHD> kq = new List<CHITIETHD>();

            if (dl != null)
            {
                kq = dl.ToList().ConvertAll(t => new CHITIETHD()
                {
                    MaHD = t.MAHD,
                    TenSP1 = t.TenHG,
                    SoLuong = t.SoLuong,
                    Tt = t.Tt
                });
            }        
               
            return kq.ToList<CHITIETHD>();
        }
        public List<CHITIETHOADON2> getDataCTHD2() {
            List<CHITIETHOADON2> kq = new List<CHITIETHOADON2>();
            try
            {
                var dl = from cthd in QLST.CHITIETHDs
                         join hd in QLST.HOADONs
                         on cthd.MaHD equals hd.MaHD
                         join hh in QLST.HANGHOAs
                         on hh.MaHG equals cthd.MaHg
                         select new CHITIETHOADON2
                         {
                             Mahd = cthd.MaHD,
                            Tensp = hh.TenHG,
                             Soluong = Convert.ToInt32(cthd.SoLuong),
                             Dongia = Convert.ToDouble(cthd.GiaBan),
                             Thanhtien = Convert.ToDouble(cthd.SoLuong * cthd.GiaBan)

                         };
                
                var kq2 = dl.ToList().ConvertAll(t => new CHITIETHOADON2()
                 {
                     Mahd = t.Mahd,
                     Tensp = t.Tensp,
                     Soluong = Convert.ToInt32(t.Soluong),
                     Dongia = Convert.ToDouble(t.Dongia),
                     Thanhtien = Convert.ToDouble(t.Thanhtien)
                 });
                kq.AddRange(kq2);
                return kq.ToList<CHITIETHOADON2>();
            }
            catch(Exception e) {
                return kq;
            }
        }
    }
}
