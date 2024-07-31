using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using DTO;
namespace DAL
{
    public class NguoiDungDAL
    {
        QLKSDataContext qlks = new QLKSDataContext();
        public NguoiDungDAL() { }
        public List<QL_NGUOIDUNG> GetNguoiDungs() { return qlks.QL_NGUOIDUNGs.Select(nd => nd).ToList<QL_NGUOIDUNG>(); }
        public void ThemNguoiDungDAL(QL_NGUOIDUNG nguoiDung)
        {
            qlks.QL_NGUOIDUNGs.InsertOnSubmit(nguoiDung);
            qlks.SubmitChanges();
        }
        public void SuaNguoiDungDAL(QL_NGUOIDUNG nguoiDung)
        {
            QL_NGUOIDUNG nguoiDungCu = qlks.QL_NGUOIDUNGs.Single(nd => nd.TENDANGNHAP == nguoiDung.TENDANGNHAP);
            qlks.SubmitChanges();
        }
        public void XoaNguoiDungDAL(string tenDN)
        {
            QL_NGUOIDUNG nguoiDung = qlks.QL_NGUOIDUNGs.Single(nd => nd.TENDANGNHAP == tenDN);
            qlks.QL_NGUOIDUNGs.DeleteOnSubmit(nguoiDung);
            qlks.SubmitChanges();
        }

    }
}
