using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiPhongBLL
    {
        LoaiPhongDAL LoaiPhongDAL = new LoaiPhongDAL();
        public LoaiPhongBLL() { }
        public List<LOAIPHONG> layDanhSachLOAIPHONGBLL() { return LoaiPhongDAL.layDSLoaiPhongDAL(); }
        public void suaLOAIPHONGBLL(LOAIPHONG LOAIPHONG)
        { LoaiPhongDAL.suaLoaiPhongDAL(LOAIPHONG); }
        public void themLOAIPHONGBLL(LOAIPHONG LOAIPHONG)
        { LoaiPhongDAL.themLoaiPhongDAL(LOAIPHONG); }
        public bool xoaLOAIPHONGBLL(LOAIPHONG LOAIPHONG)
        { return LoaiPhongDAL.xoaLoaiPhongDAL(LOAIPHONG); }
        public LOAIPHONG layLOAIPHONGBLL(string maLOAIPHONG)
        {
            return LoaiPhongDAL.layLoaiPhong(maLOAIPHONG);
        }
    }
}
