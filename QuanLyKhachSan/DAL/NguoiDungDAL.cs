using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data;
using BCrypt.Net;
using DTO;
namespace DAL
{
    public class NguoiDungDAL
    {
        QLKSDataContext qlks = new QLKSDataContext();
        public NguoiDungDAL() { }
        public List<QL_NGUOIDUNG> GetNguoiDungs() 
        {
            List<QL_NGUOIDUNG> lstND = qlks.QL_NGUOIDUNGs.Select(nd => nd).ToList<QL_NGUOIDUNG>();
            List<QL_NGUOIDUNG> lstNDMaHoa = new List<QL_NGUOIDUNG>();
            foreach (QL_NGUOIDUNG nd in lstND)
            {

                //truyen mat khau va cost vao ham ma hoa, sau do ham se tra ve 1 string ngoằng ngoèo
                string mkMaHoa = BCrypt.Net.BCrypt.HashPassword(nd.MATKHAU, 10);
                nd.MATKHAU = mkMaHoa;
                lstNDMaHoa.Add(nd);
            }
            return lstNDMaHoa;
        }
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
