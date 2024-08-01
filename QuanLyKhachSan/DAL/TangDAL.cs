using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class TangDAL
    {
        QLKSDataContext qlks;
        public TangDAL() { qlks = new QLKSDataContext(); }
        public List<TANG> layDanhSachTangDAL() { return qlks.TANGs.Where(t => t.HOATDONG == false || t.HOATDONG == null).ToList<TANG>(); }

    }
}
