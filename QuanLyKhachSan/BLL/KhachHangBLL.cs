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

        public void suaKHBLL(KHACHHANG kh)
        { khachHangDAL.suaKhachHangDAL(kh); }
        public void themKHBLL(KHACHHANG kh)
        { khachHangDAL.themKhachHang(kh); }
        public bool xoaKHBLL(KHACHHANG kh)
        { return khachHangDAL.xoaKhachHangDAL(kh); }
        public KHACHHANG layKHBLL(string maKH)
        {
            return khachHangDAL.layKhachHang(maKH);
        }
    }
}
