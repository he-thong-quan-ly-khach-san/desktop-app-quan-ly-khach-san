using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class TangBLL
    {
        TangDAL tangDal = new TangDAL();
        public TangBLL() { }
        public List<TANG> layDanhSachTangBLL() { return tangDal.layDanhSachTangDAL(); }
        public void suaTangBLL(TANG tang)
        { tangDal.suaTangDAL(tang); }
        public void themTangBLL(TANG tang)
        { tangDal.themTang(tang); }
        public bool xoaTangBLL(TANG tang)
        { return tangDal.xoatangDAL(tang); }
        public TANG layTangBLL(string maTang)
        {
            return tangDal.layTang(maTang);
        }

    }
}
