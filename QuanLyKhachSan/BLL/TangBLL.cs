using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
