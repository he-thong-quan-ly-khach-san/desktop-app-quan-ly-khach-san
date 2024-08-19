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
    public partial class frmKhachHang : Form
    {
        KhachHangBLL khBLL;
        frmDatPhongTheoDoan objDP = (frmDatPhongTheoDoan)Application.OpenForms["frmDatPhongTheoDoan"];
        public frmKhachHang()
        {
            InitializeComponent();

            this.Load += FrmKhachHang_Load;
        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
            khBLL = new KhachHangBLL();
            loadData();
            xuLyControl();
        }

        private void loadData()
        {
            gcDS.DataSource = khBLL.layDSKHBLL();
            gridDS.OptionsBehavior.Editable = false;
        }

        bool _them = false;

        void xuLyControl()
        {
            _them = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            txtCCCD.Enabled = false;
            txtEmail.Enabled = false;
            txtTenKH.Text= string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            gridDS.ActiveFilterEnabled = false;
            txtTenKH.Text = string.Empty;
            txtMaKH.Text = MaKHTuDong();
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtEmail.Text = string.Empty;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            enableCacControl();
        }
        void enableCacControl()
        {
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTenKH.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            txtCCCD.Enabled = true;
            txtEmail.Enabled = true;
            
        }

        private string MaKHTuDong()
        {
            int soTT = khBLL.layDSKHBLL().Count + 1;
            //string ngay = DateTime.Now.Day.ToString("D2");
            //string thang = DateTime.Now.Month.ToString("D2");
            //string nam = (DateTime.Now.Year - 2000).ToString();
            //string maKH = "KH" + ngay + thang + nam + soTT.ToString("D2");
            string maKH = "KH"+soTT.ToString("D8");
            return maKH;
        }

        private void gridDS_Click(object sender, EventArgs e)
        {
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (gridDS.RowCount > 0 && !_them)
            {
                _them = false;
                txtMaKH.Text = gridDS.GetFocusedRowCellValue("MAKH").ToString();
                txtTenKH.Text = gridDS.GetFocusedRowCellValue("HOTENKH").ToString();
                txtSDT.Text = gridDS.GetFocusedRowCellValue("DIENTHOAI").ToString();
                if (gridDS.GetFocusedRowCellValue("DIACHI") == null )
                {
                    txtDiaChi.Text = string.Empty;
                    txtCCCD.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    return;
                }
                txtDiaChi.Text = gridDS.GetFocusedRowCellValue("DIACHI").ToString();
                txtCCCD.Text = gridDS.GetFocusedRowCellValue("CCCD").ToString();
                txtEmail.Text = gridDS.GetFocusedRowCellValue("EMAIL").ToString();




                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtCCCD.Text.Equals(string.Empty) || txtEmail.Text.Equals(string.Empty) || txtDiaChi.Text.Equals(string.Empty)||
                txtSDT.Text.Equals(string.Empty) || txtTenKH.Text.Equals(string.Empty))
            {
                MessageBox.Show("Kiểm tra lại các thông tin");
                return;
            }
            if (_them)
            {
                try
                {
                    KHACHHANG kh = new KHACHHANG();
                    kh.MAKH= txtMaKH.Text;
                    kh.HOTENKH = txtTenKH.Text;
                    kh.CCCD = txtCCCD.Text;
                    kh.EMAIL = txtEmail.Text;
                    kh.DIACHI = txtDiaChi.Text;
                    kh.DIENTHOAI = txtSDT.Text;
                    khBLL.themKHBLL(kh);
                    MessageBox.Show("Thêm thành công!");

                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi đã xảy ra!");
                    throw;
                }
            }
            else
            {
                KHACHHANG kh = khBLL.layKHBLL(txtMaKH.Text);
                kh.HOTENKH = txtTenKH.Text;
                kh.CCCD= txtCCCD.Text;
                kh.EMAIL = txtEmail.Text;
                kh.DIACHI= txtDiaChi.Text;
                kh.DIENTHOAI= txtSDT.Text;
                khBLL.suaKHBLL(kh);
                MessageBox.Show("Sửa thành công!");
            }
            loadData();
            xuLyControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            enableCacControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int focus = gridDS.FocusedRowHandle;
            if (focus >= 0)
            {
                KHACHHANG k = khBLL.layKHBLL(txtMaKH.Text);
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa khách hàng " + "'" + k.HOTENKH + "'" + " không?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    try
                    {

                        if (!khBLL.xoaKHBLL(k))
                        {
                            MessageBox.Show("Không thể xóa phòng!");
                        }
                        loadData();
                        xuLyControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridDS_DoubleClick(object sender, EventArgs e)
        {
            if (gridDS.GetFocusedRowCellValue("MAKH")!= null)
            {
                objDP.setKH(gridDS.GetFocusedRowCellValue("MAKH").ToString());
                objDP.loadKH();
                this.Close();
            }
        }
    }
}
