using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhongDAL
    {
        QLKSDataContext qlks;
        public PhongDAL() { qlks = new QLKSDataContext(); }
        public List<PHONG> GetPHONGs() { return qlks.PHONGs.Where(ph => ph.HOATDONG == true).ToList<PHONG>(); }
        public void themPhong(PHONG phong)
        {
            qlks.PHONGs.InsertOnSubmit(phong);
            qlks.SubmitChanges();
        }
        public void suaPhong(PHONG phong)
        {
            PHONG phongCu = qlks.PHONGs.Single(ph=>ph.MAPHONG == phong.MAPHONG);
            phongCu.MALOAIPHONG = phong.MALOAIPHONG;
            phongCu.MATANG = phong.MATANG; 
            phongCu.TENPHONG = phong.TENPHONG;
            qlks.SubmitChanges();
        }
        public void xoaPhong(PHONG phong)
        {
            PHONG phongCu = qlks.PHONGs.Single(ph=>ph.MAPHONG.Equals(phong.MAPHONG));
            phongCu.HOATDONG = false;
            qlks.SubmitChanges();
        }

    }
}
