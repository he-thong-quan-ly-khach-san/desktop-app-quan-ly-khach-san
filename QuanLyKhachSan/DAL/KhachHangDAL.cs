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
        private readonly QLKSDataContext qlks;
        public KhachHangDAL() 
        {
            qlks = new QLKSDataContext();
        }
        public void ThemKhachHang(KHACHHANG kh)
        {
            qlks.KHACHHANGs.InsertOnSubmit(kh);
            qlks.SubmitChanges();
        }

        public List<KHACHHANG> LayTatCaKhachHang()
        {
            var list = qlks.KHACHHANGs.ToList();
            
            return list;
        }

        public KHACHHANG LayKhachHangTheoID(string id)
        {
            return qlks.KHACHHANGs.FirstOrDefault(kh => kh.MAKH == id);
        }

        public void CapNhatKhachHang(KHACHHANG kh)
        {
            var khachHang = qlks.KHACHHANGs.FirstOrDefault(k => k.MAKH == kh.MAKH);
            if (khachHang != null)
            {
                khachHang.HOTENKH = kh.HOTENKH;
                khachHang.DIACHI = kh.DIACHI;
                khachHang.DIENTHOAI = kh.DIENTHOAI;
                khachHang.CCCD = kh.CCCD;
                khachHang.EMAIL = kh.EMAIL;
                qlks.SubmitChanges();
            }
        }

        // Xóa khách hàng
        public void XoaKhachHang(string id)
        {
            var khachHang = qlks.KHACHHANGs.FirstOrDefault(kh => kh.MAKH == id);
            if (khachHang != null)
            {
                qlks.KHACHHANGs.DeleteOnSubmit(khachHang);
                qlks.SubmitChanges();
            }
        }
    }
}
