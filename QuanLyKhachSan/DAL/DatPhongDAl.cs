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
        public void xoa(DATPHONG dp)
        {
            DATPHONG dpXoa = qlks.DATPHONGs.FirstOrDefault(p=>p.MADATPHONG==dp.MADATPHONG);
            dpXoa.DISABLED = true;
            qlks.SubmitChanges();
        }
        public List<DATPHONG> layDS() { return qlks.DATPHONGs.Select(dp => dp).ToList<DATPHONG>(); }
        public List<dynamic> layDS(DateTime tuNgay, DateTime denNgay) { return qlks.DATPHONGs.Where(dp=>dp.NGAYDAT >= tuNgay && dp.NGAYDAT < denNgay && dp.DISABLED == false).Select(dp => new {dp.MADATPHONG, dp.MAKH, dp.KHACHHANG.HOTENKH, dp.SOTIEN, dp.NGAYTAO, dp.NGAYDAT, dp.NGAYTRA, dp.THEODOAN, dp.SONGUOIO, dp.CAPNHATBOI, dp.DISABLED, dp.NGAYCAPNHAT, dp.TRANGTHAI, dp.GHICHU}).ToList<dynamic>();}
    }
}
