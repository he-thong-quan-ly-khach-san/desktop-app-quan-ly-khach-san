using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class SP_DatPhongBLL
    {
        SP_DatPhongDAL sP_DatPhongDAL;
        public SP_DatPhongBLL() { sP_DatPhongDAL = new SP_DatPhongDAL(); }
        public void addBLL(SP_DATPHONG spdp) { sP_DatPhongDAL.add(spdp); }
        public void xoaAllBLL(string maDatPhong) { sP_DatPhongDAL.xoaAll(maDatPhong); }
        public List<SP_DATPHONG> LayDSBLL() { return sP_DatPhongDAL.layDS(); }
    }
}
