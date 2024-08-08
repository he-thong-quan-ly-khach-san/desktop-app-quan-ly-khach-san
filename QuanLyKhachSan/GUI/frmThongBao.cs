using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThongBao: Form
    {
        public frmThongBao()
        {
            InitializeComponent();
        }
        KhachHangBLL khBLL = new KhachHangBLL();
        List<DATPHONG_WEB> dpweb = new List<DATPHONG_WEB>();
        QLKSDataContext qlks;
        private void frmThongBao_Load(object sender, EventArgs e)
        {
            qlks = new QLKSDataContext();
            dpweb = qlks.DATPHONG_WEBs.Select(dp=>dp).ToList<DATPHONG_WEB>();
            gcThongTin.DataSource = dpweb;
            gvThongTin.OptionsBehavior.Editable = false;
        }

        private void btnNhapThongTin_Click(object sender, EventArgs e)
        {
            if (gvThongTin.GetFocusedRowCellValue("ID") != null)
            {
                KHACHHANG kHACHHANG = new KHACHHANG();
                kHACHHANG.MAKH = MaKHTuDong();
                string ten = gvThongTin.GetFocusedRowCellValue("TEN_KHACHHANG").ToString();
                kHACHHANG.HOTENKH = ten;
                kHACHHANG.DIENTHOAI  = gvThongTin.GetFocusedRowCellValue("SODIENTHOAI").ToString();
                qlks.KHACHHANGs.InsertOnSubmit(kHACHHANG);
                qlks.SubmitChanges();
                MessageBox.Show("Đã thêm khách hàng vào hệ thống");
            }
        }
        private string MaKHTuDong()
        {
            int soTT = khBLL.layDSKHBLL().Count + 1;
            //string ngay = DateTime.Now.Day.ToString("D2");
            //string thang = DateTime.Now.Month.ToString("D2");
            //string nam = (DateTime.Now.Year - 2000).ToString();
            //string maKH = "KH" + ngay + thang + nam + soTT.ToString("D2");
            string maKH = "KH" + soTT.ToString("D8");
            return maKH;
        }
    }
}
