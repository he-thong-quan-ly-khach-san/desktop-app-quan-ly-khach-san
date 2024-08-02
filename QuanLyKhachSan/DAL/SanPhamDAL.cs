using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class SanPhamDAL
    {
        QLKSDataContext qlks;
        public SanPhamDAL() { qlks = new QLKSDataContext(); }
        public List<SANPHAM> layDSSPDAL() { return qlks.SANPHAMs.Where(sp => sp.DAXOA == false).ToList<SANPHAM>(); }
        public void themSPDAL(SANPHAM sp)
        {
            qlks.SANPHAMs.InsertOnSubmit(sp);
            qlks.SubmitChanges();
        }
        public void suaSPDAL(SANPHAM sp)
        {
            SANPHAM spCu = qlks.SANPHAMs.Single(s => s.MASP == sp.MASP);
            spCu.TENSP = sp.TENSP;
            spCu.DONGIA = sp.DONGIA;
            qlks.SubmitChanges();
        }
        public void xoaSPDAL(SANPHAM sp)
        {
            SANPHAM spCu = qlks.SANPHAMs.Single(s => s.MASP == sp.MASP);
            spCu.DAXOA = true;
            qlks.SubmitChanges();
        }
        public SANPHAM laySP(String maSp)
        {
            return qlks.SANPHAMs.FirstOrDefault(sp=>sp.MASP == maSp);
            
        }
    }
}
