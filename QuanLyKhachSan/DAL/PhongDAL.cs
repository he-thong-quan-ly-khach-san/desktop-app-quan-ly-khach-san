using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class PhongDAL
    {
        QLKSDataContext qlks = new QLKSDataContext();
        public PhongDAL() { }
        public List<PHONG> GetPHONGs() { return qlks.PHONGs.Select(ph => ph).ToList<PHONG>(); }
    }
}
