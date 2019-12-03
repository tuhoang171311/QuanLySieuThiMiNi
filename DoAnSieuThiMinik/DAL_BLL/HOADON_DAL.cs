using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HOADON_DAL
    {
        QLSTDataContext qlst = new QLSTDataContext();
        public List<HOADON> getAllDataHoaDon() {
            return qlst.HOADONs.Select(t => t).ToList();
        }
        public List<CHITIETHD> getAllDataCTHD() {
            return qlst.CHITIETHDs.Select(t => t).ToList();
        }
        public List<CHITIETHD> getDataCTHDTheoMa(string ma) {
            return qlst.CHITIETHDs.Where(t => t.MaHD == ma).ToList();
        }
    }
}
