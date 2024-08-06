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

    }
}
