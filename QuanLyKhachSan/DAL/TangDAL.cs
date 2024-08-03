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
        public void themTang(TANG tang)
        {
            qlks.TANGs.InsertOnSubmit(tang);
            qlks.SubmitChanges();
        }
        public void suaTangDAL(TANG tang)
        {
            TANG tCu = qlks.TANGs.Single(t => t.MATANG== tang.MATANG);
            tCu.TENTANG = tang.TENTANG;
            tCu.HOATDONG = tang.HOATDONG;
            qlks.SubmitChanges();
        }

        public bool xoatangDAL(TANG tang)
        {
            try
            {
                TANG tangCu = qlks.TANGs.Single(s => s.MATANG == tang.MATANG);
                qlks.TANGs.DeleteOnSubmit(tangCu);
                qlks.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public TANG layTang(String maTang)
        {
            return qlks.TANGs.FirstOrDefault(t => t.MATANG == maTang);
        }
    }
}
