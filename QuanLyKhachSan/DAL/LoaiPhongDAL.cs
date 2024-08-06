using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiPhongDAL
    {
        QLKSDataContext qlks;
        public LoaiPhongDAL() { qlks = new QLKSDataContext(); }
        public List<LOAIPHONG> layDSLoaiPhongDAL() { return qlks.LOAIPHONGs.Select(Phong => Phong).ToList<LOAIPHONG>(); }
        public void themLoaiPhongDAL(LOAIPHONG lPhong)
        {
            qlks.LOAIPHONGs.InsertOnSubmit(lPhong);
            qlks.SubmitChanges();
        }
        public void suaLoaiPhongDAL(LOAIPHONG lPhong)
        {
            LOAIPHONG PhongCu = qlks.LOAIPHONGs.Single(s => s.MALOAIPHONG == lPhong.MALOAIPHONG);
            PhongCu.TENLOAIPHONG = lPhong.TENLOAIPHONG;
            PhongCu.DONGIA = lPhong.DONGIA;
            qlks.SubmitChanges();
        }
        public bool xoaLoaiPhongDAL(LOAIPHONG lPhong)
        {
            try
            {
                LOAIPHONG PhongCu = qlks.LOAIPHONGs.Single(s => s.MALOAIPHONG == lPhong.MALOAIPHONG);
                qlks.LOAIPHONGs.DeleteOnSubmit(PhongCu);
                qlks.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public LOAIPHONG layLoaiPhong(String MALOAIPHONG)
        {
            return qlks.LOAIPHONGs.FirstOrDefault(Phong => Phong.MALOAIPHONG == MALOAIPHONG);

        }
    }
}
