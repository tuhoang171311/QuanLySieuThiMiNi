using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public partial class CHITIETHD
    {
        string TenSP;
        double? tt;

        public double? Tt
        {
            get { return tt; }
            set { tt = value; }
        }

        public string TenSP1
        {
            get { return TenSP; }
            set { TenSP = value; }
        }
    }
}
