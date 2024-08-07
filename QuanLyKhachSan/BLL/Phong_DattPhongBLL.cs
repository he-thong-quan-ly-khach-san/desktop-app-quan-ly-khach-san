using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Phong_DattPhongBLL
    {
        Phong_DatPhongDAL phong_DatPhongDAL;
        public Phong_DattPhongBLL() { phong_DatPhongDAL = new Phong_DatPhongDAL(); }
        public void addBLL(PHONG_DATPHONG pdp) { phong_DatPhongDAL.add(pdp); }

        public void xoaAllBLL(string maDatPhong) { phong_DatPhongDAL.xoaAll(maDatPhong); }
        public List<PHONG_DATPHONG> LayDSBLL() { return phong_DatPhongDAL.layDS(); }
    }
}
