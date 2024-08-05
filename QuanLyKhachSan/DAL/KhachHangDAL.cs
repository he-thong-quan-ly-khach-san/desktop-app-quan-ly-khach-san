using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhachHangDAL
    {
        QLKSDataContext qlks;
        public KhachHangDAL() { qlks = new QLKSDataContext(); }
        public List<KHACHHANG> layDSKH() { return qlks.KHACHHANGs.Select(kh=>kh).ToList<KHACHHANG>(); }

    }
}
