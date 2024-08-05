using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL khachHangDAL;
        public KhachHangBLL() { khachHangDAL = new KhachHangDAL(); }
        public List<KHACHHANG> layDSKHBLL() { return khachHangDAL.layDSKH(); }
    }
}
