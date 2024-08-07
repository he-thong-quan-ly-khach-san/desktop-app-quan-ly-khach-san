using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SP_DatPhongDAL
    {
        QLKSDataContext qlks;
        public SP_DatPhongDAL() {qlks = new QLKSDataContext();}
        public void add(SP_DATPHONG dpsp) { qlks.SP_DATPHONGs.InsertOnSubmit(dpsp); qlks.SubmitChanges(); }
        public void xoaAll(string maDatPhong)
        {
            List<SP_DATPHONG> lst = qlks.SP_DATPHONGs.Where(sdp=>sdp.MADATPHONG == maDatPhong).ToList<SP_DATPHONG>();
            try
            {
                qlks.SP_DATPHONGs.DeleteAllOnSubmit(lst);
                qlks.SubmitChanges();
            }
            catch (Exception ex)
            {
                 
                throw new Exception("Loi xl du lieu");
            }
        }
        public List<SP_DATPHONG> layDS() { return qlks.SP_DATPHONGs.Select(dp => dp).ToList<SP_DATPHONG>(); }
    }
}
