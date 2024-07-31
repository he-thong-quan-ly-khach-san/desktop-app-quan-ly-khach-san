using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DALNguoiDung
    {
        QLKSDataContext qLKS = new QLKSDataContext();
        public DALNguoiDung() { }
        public List<QL_NGUOIDUNG> layDSNguoiDung()
        { return qLKS.QL_NGUOIDUNGs.select(nd => nd).ToList; }
    }
}
