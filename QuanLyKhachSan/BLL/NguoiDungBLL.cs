using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguoiDungBLL
    {
        NguoiDungDAL ndDAL = new NguoiDungDAL();
        public NguoiDungBLL() { }
        public List<QL_NGUOIDUNG> loadNguoiDungBLL()
        {
            return ndDAL.GetNguoiDungs();
        }
        public void themNguoiDungBLL(QL_NGUOIDUNG nguoiDung)
        {
            ndDAL.ThemNguoiDungDAL(nguoiDung);
        }
        public void suaNguoiDungBLL(QL_NGUOIDUNG suaNguoiDung)
        {
            ndDAL.SuaNguoiDungDAL(suaNguoiDung);
        }
        public void xoaNguoiDungBLL(string tenDN)
        {
            ndDAL.XoaNguoiDungDAL(tenDN);
        }
    }
}
