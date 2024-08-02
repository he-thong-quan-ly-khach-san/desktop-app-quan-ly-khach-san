using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace GUI
{
    public partial class frmSanPham : Form
    {
        SanPhamBLL spBLL;
        public frmSanPham()
        {
            InitializeComponent();
            this.Load += FrmSanPham_Load;
            gridDS.Click += GridDS_Click;
        }

        private void GridDS_Click(object sender, EventArgs e)
        {
            if (gridDS.RowCount > 0)
            {
                txtMaSP.Text = gridDS.GetFocusedRowCellValue("MASP").ToString();
                txtTenSP.Text = gridDS.GetFocusedRowCellValue("TENSP").ToString();
                txtDonGia.Text = gridDS.GetFocusedRowCellValue("DONGIA").ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void FrmSanPham_Load(object sender, EventArgs e)
        {
            spBLL = new SanPhamBLL();
            loadData();
            xuLyControl();
        }
        bool _them = false;
        void loadData()
        {
            gcDS.DataSource = spBLL.layDSSPBLL();
            txtTenSP.Enabled = false;
            txtDonGia.Enabled = false;
            gridDS.Columns["DAXOA"].Visible = false;
            gridDS.OptionsBehavior.Editable = false;
        }
        void xuLyControl()
        {
            _them = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaSP.Enabled = false;
            txtDonGia.Enabled = false;
            txtTenSP.Enabled = false;
            txtMaSP.Text = string.Empty;
            txtTenSP.Text = string.Empty;
            txtDonGia.Text = string.Empty;
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void MaSPTuDong()
        {
            int soTT = spBLL.layDSSPBLL().Count + 1;
            string maSPMoi = "SP" + soTT.ToString("D3");
            txtMaSP.Text = maSPMoi;

        }
        void enableCacControl()
        {
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTenSP.Enabled = true;
            txtDonGia.Enabled = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            txtTenSP.Text=string.Empty;
            txtDonGia.Text=string.Empty;
            MaSPTuDong();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            enableCacControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenSP.Text.Equals(string.Empty) || txtDonGia.Text.Equals(string.Empty))
            {
                MessageBox.Show("Kiểm tra lại tên sản phẩm hoặc đơn giá");
                return;
            }
            if(_them)
            {
                try
                {
                    SANPHAM sp = new SANPHAM();
                    sp.MASP = txtMaSP.Text;
                    sp.TENSP = txtTenSP.Text;
                    sp.DONGIA = decimal.Parse(txtDonGia.Text);
                    sp.DAXOA = false;
                    spBLL.themSPBLL(sp);
                    MessageBox.Show("Thêm thành công!");
                    loadData();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                
            }
            else
            {
                try
                {
                    SANPHAM sp = spBLL.laySPBLL(txtMaSP.Text);
                    sp.TENSP = txtTenSP.Text;
                    sp.DONGIA = decimal.Parse(txtDonGia.Text);
                    spBLL.suaSPBLL(sp);
                    MessageBox.Show("Sửa thành công!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
            xuLyControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            enableCacControl();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int focus = gridDS.FocusedRowHandle;
            if (focus >= 0)
            {
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa sản phẩm này không?","Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    try
                    {
                        SANPHAM sp = spBLL.laySPBLL(txtMaSP.Text);
                        spBLL.xoaSPBLL(sp);
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
