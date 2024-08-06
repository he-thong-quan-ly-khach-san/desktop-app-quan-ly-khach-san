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
        
        public void themKhachHang(KHACHHANG kh)
        {
            qlks.KHACHHANGs.InsertOnSubmit(kh);
            qlks.SubmitChanges();
        }
        public void suaKhachHangDAL(KHACHHANG kh)
        {
            KHACHHANG tCu = qlks.KHACHHANGs.Single(t => t.MAKH == kh.MAKH);
            tCu.HOTENKH = kh.HOTENKH;
            tCu.DIACHI = kh.DIACHI;
            tCu.CCCD = kh.CCCD;
            tCu.EMAIL = kh.EMAIL;
            tCu.DIENTHOAI = kh.DIENTHOAI;
            qlks.SubmitChanges();
        }

        public bool xoaKhachHangDAL(KHACHHANG kh)
        {
            try
            {
                KHACHHANG khCu = qlks.KHACHHANGs.Single(s => s.MAKH == kh.MAKH);
                qlks.KHACHHANGs.DeleteOnSubmit(khCu);
                qlks.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public KHACHHANG layKhachHang(String maKhachHang)
        {
            return qlks.KHACHHANGs.FirstOrDefault(t => t.MAKH == maKhachHang);
        }
    }
}
