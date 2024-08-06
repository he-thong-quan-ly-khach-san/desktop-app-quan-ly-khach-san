﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class DatPhongBLL
    {
        DatPhongDAl datPhongDAl;
        public DatPhongBLL() { datPhongDAl = new DatPhongDAl(); }
        public DATPHONG themDPBLL(DATPHONG dp) { return datPhongDAl.themDP(dp); }
        public DATPHONG getDPBLL(string maDP) { return datPhongDAl.getDatPhong(maDP); }
        public DATPHONG suaBLL(DATPHONG dp) { return datPhongDAl.sua(dp); }
    }
}
