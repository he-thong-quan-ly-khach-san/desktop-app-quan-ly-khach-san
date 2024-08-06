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
        public List<PHONG> GetPHONGs() { return qlks.PHONGs.Select(ph => ph).ToList<PHONG>(); }
        public List<dynamic> layPhongDataSource()
        {
            return qlks.PHONGs.Select(ph => new {ph.MAPHONG, ph.TENPHONG, ph.TANG.TENTANG, ph.LOAIPHONG.TENLOAIPHONG, ph.HOATDONG}).ToList<dynamic>();

        }
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
        public bool xoaPhong(PHONG phong)
        {
            try
            {
                PHONG phongCu = qlks.PHONGs.Single(ph=>ph.MAPHONG.Equals(phong.MAPHONG));
                qlks.PHONGs.DeleteOnSubmit(phongCu);
                qlks.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public PHONG layPhong(String maPhong)
        {
            return qlks.PHONGs.FirstOrDefault(p => p.MAPHONG== maPhong);

        }

        //lay phong theo tang
        public List<PHONG> GetPHONGsByTang(TANG tang)
        {
            return qlks.PHONGs.Where(ph => ph.MATANG == tang.MATANG).ToList<PHONG>();
        }
        public List<dynamic> layPhongTrongDAL()
        {
            return qlks.PHONGs.Where(ph => ph.HOATDONG == false).Select(ph => new { ph.MAPHONG, ph.TENPHONG, ph.TANG.MATANG, ph.TANG.TENTANG, ph.LOAIPHONG.DONGIA}).ToList<dynamic>();
        }
    }
}
