using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrangThaiDatPhong
    {
        public bool _value { get; set; }
        public string _display {get; set; }
        public TrangThaiDatPhong() { }
        public TrangThaiDatPhong(bool value, string display) { this._value = value; this._display = display; }
        public static List<TrangThaiDatPhong> layDSTrangThai()
        {
            List<TrangThaiDatPhong>  lstTrangThai = new List<TrangThaiDatPhong> ();
            TrangThaiDatPhong[] collect = new TrangThaiDatPhong[2] { new TrangThaiDatPhong(false, "Chưa hoàn tất"), new TrangThaiDatPhong(true, "Đã hoàn tất") };
            lstTrangThai.AddRange(collect);
            return lstTrangThai;
        }

    }
}
