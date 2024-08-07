using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatPhongDAl
    {
        public DatPhongDAl() { qlks = new QLKSDataContext(); }
        QLKSDataContext qlks;
        public DATPHONG themDP(DATPHONG dp)
        {
            qlks.DATPHONGs.InsertOnSubmit(dp);
            qlks.SubmitChanges();
            return dp;
        }
        public DATPHONG getDatPhong(string maDP) { return qlks.DATPHONGs.FirstOrDefault(p=>p.MADATPHONG ==  maDP); }
        public DATPHONG sua(DATPHONG dp)
        {
            DATPHONG dphongCu = qlks.DATPHONGs.FirstOrDefault(p=>p.MADATPHONG == dp.MADATPHONG);
            if (dphongCu != null)
            {
                dphongCu = dp;
                qlks.SubmitChanges();
                return dp;
            }
            else { return null; }
        }
        public List<DATPHONG> layDS() { return qlks.DATPHONGs.Select(dp => dp).ToList<DATPHONG>(); }
    }
}
