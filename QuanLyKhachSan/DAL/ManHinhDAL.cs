using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class ManHinhDAL
    {
        QLKSDataContext qlks;
        public  ManHinhDAL() { qlks = new QLKSDataContext(); }
        public  List<DM_MANHINH> loadManHinhDAL()
        {
            return  qlks.DM_MANHINHs.Select(mh=>mh).ToList<DM_MANHINH>();
        }
    }
}
