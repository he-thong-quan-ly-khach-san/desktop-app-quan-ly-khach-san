using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Phong_DatPhongDAL
    {
        QLKSDataContext qlks = new QLKSDataContext();
        public Phong_DatPhongDAL() { }

        public void add(PHONG_DATPHONG pdp) {qlks.PHONG_DATPHONGs.InsertOnSubmit(pdp);}
        public void sua(PHONG_DATPHONG pdp) 
        {
            PHONG_DATPHONG pdpCu = qlks.PHONG_DATPHONGs.FirstOrDefault(p=>p.MAPHONG_DATPHONG == pdp.MAPHONG_DATPHONG);
            if (pdpCu != null) 
            {
                pdpCu.MADATPHONG = pdp.MADATPHONG;
                pdpCu.MAPHONG = pdp.MAPHONG;
                pdpCu.DONGIA = pdp.DONGIA;
                pdp.SONGAYO = pdp.SONGAYO;
                pdp.NGAY = pdp.NGAY;
                pdp.THANHTIEN = pdp.THANHTIEN;
                try
                {
                    qlks.SubmitChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
