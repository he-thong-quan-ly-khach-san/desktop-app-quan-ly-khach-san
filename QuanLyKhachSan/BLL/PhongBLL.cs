using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class PhongBLL
    {
        PhongDAL phongDAL;
        public PhongBLL() { phongDAL = new PhongDAL(); }
        public List<PHONG> loadPhongBLL() { return phongDAL.GetPHONGs(); }
        public void SuaPhongBLL(PHONG phong)
        {
            phongDAL.suaPhong(phong);
        }
        public void XoaPhongBLL(PHONG phong)
        {
            phongDAL.xoaPhong(phong);
        }
    }
}
