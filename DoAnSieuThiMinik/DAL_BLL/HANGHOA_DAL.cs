using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HANGHOA_DAL
    {
        QLSTDataContext qlst = new QLSTDataContext();
        public List<HANGHOA> getAllDataHangHoa() {
            return qlst.HANGHOAs.Select(t => t).ToList<HANGHOA>();
        }
        public List<LOAIHANG> getCBLoaiHang() {
            return qlst.LOAIHANGs.Select(t => t).ToList<LOAIHANG>();
        }
        public List<NHASX> getCBNhaSX()
        {
            return qlst.NHASXes.Select(t => t).ToList<NHASX>();
        }
        public int ThemHangHoa(string mahg,string dvt,string tenhg,string maloai,string mansx) {
            try
            {
                HANGHOA hh = new HANGHOA();
                hh.MaHG = mahg;
                hh.TenHG = tenhg;
                hh.DVT = dvt;
                hh.MaLoai = maloai;
                hh.MaNSX = mansx;
                qlst.HANGHOAs.InsertOnSubmit(hh);
                qlst.SubmitChanges();
                return 1;
            }
            catch {
                return 0;
            }
        }
        public int KiemTraKhoaChinhMaHg(string ma) {
            HANGHOA hh = qlst.HANGHOAs.Where(t => t.MaHG == ma).FirstOrDefault();
            if (hh == null) {
                return 1;
            }
            return 0;
        }
        public HANGHOA GetOneHangHoa(string ma) {
            return qlst.HANGHOAs.Where(t => t.MaHG == ma).FirstOrDefault();
        }
        public int XoaHangHoa(string ma) {
                try
                {
                    HANGHOA hh = qlst.HANGHOAs.Where(t => t.MaHG == ma).FirstOrDefault();
                    qlst.HANGHOAs.DeleteOnSubmit(hh);
                    qlst.SubmitChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
    }
