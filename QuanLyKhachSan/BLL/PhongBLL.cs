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
        public List<dynamic> layPhongDataSourceBLL()
        {
            return phongDAL.layPhongDataSource();
        }

        public void themPhongBLL(PHONG phong)
        {
            phongDAL.themPhong(phong);
        }

        public void SuaPhongBLL(PHONG phong)
        {
            phongDAL.suaPhong(phong);
        }
        public bool XoaPhongBLL(PHONG phong)
        {
            return phongDAL.xoaPhong(phong);
        }
        public List<PHONG> loadPhongTheoTang(TANG tang) 
        {
            return phongDAL.GetPHONGsByTang(tang);
        }
        public PHONG layPhong(string maPhong)
        {
            return phongDAL.layPhong(maPhong);
        }
        public List<dynamic> layPhongTrongBLL()
        {
            return phongDAL.layPhongTrongDAL();
        }
        public void capNhatTrangThaiBLL(string maPhong, bool TrangThai)
        {
            phongDAL.capNhatTrangThai(maPhong, TrangThai);
        }

    }
}
