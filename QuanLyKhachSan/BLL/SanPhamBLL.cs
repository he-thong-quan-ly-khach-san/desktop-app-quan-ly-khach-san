using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL spDAL;
        public SanPhamBLL() { spDAL = new SanPhamDAL(); }
        public List<SANPHAM> layDSSPBLL() { return spDAL.layDSSPDAL(); }
        public void themSPBLL(SANPHAM sp)
        {
            spDAL.themSPDAL(sp);
        }
        public void suaSPBLL(SANPHAM sp)
        {
            spDAL.suaSPDAL(sp);
        }
        public void xoaSPBLL(SANPHAM sp)
        {
            spDAL.xoaSPDAL(sp);
        }
        public SANPHAM laySPBLL(string maSP)
        {
            return  spDAL.laySP(maSP);
        }
    }
}
