using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using DevExpress.CodeParser;
namespace GUI
{
    public partial class frmTang : Form
    {
        TangBLL tangBLL;
        bool _them;
        public frmTang()
        {
            InitializeComponent();
            this.Load += FrmTang_Load;
            gridDS.Click += GridDS_Click;
        }

        private void GridDS_Click(object sender, EventArgs e)
        {
            if (gridDS.RowCount > 0 && !_them)
            {
                _them = false;
                txtMaTang.Text = gridDS.GetFocusedRowCellValue("MATANG").ToString();
                txtTenTang.Text = gridDS.GetFocusedRowCellValue("TENTANG").ToString();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void FrmTang_Load(object sender, EventArgs e)
        {
            tangBLL = new TangBLL();
            loadData();
            xuLyControl();
            _them = false;
        }
        void enableCacControl()
        {
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTenTang.Enabled = true;
        }
        void loadData()
        {
            gcDS.DataSource = tangBLL.layDanhSachTangBLL();
            txtTenTang.Enabled = false;
            gridDS.OptionsBehavior.Editable = false;
        }
        void xuLyControl()
        {
            _them = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            txtMaTang.Enabled = false;
            txtTenTang.Enabled = false;
            txtMaTang.Text = string.Empty;
            txtTenTang.Text = string.Empty;
        }
        string MaTangTuDong()
        {
            int soTT = tangBLL.layDanhSachTangBLL().Count + 1;
            string maTang = "T" + soTT.ToString("D2");
            return maTang;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            gridDS.ActiveFilterEnabled = false;
            txtTenTang.Text = string.Empty;
            txtMaTang.Text = MaTangTuDong();
            MaTangTuDong();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            enableCacControl();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenTang.Text.Equals(string.Empty) )
            {
                MessageBox.Show("Kiểm tra lại tên tên tầng");
                return;
            }
            if (_them)
            {
                try
                {
                    TANG t = new TANG();
                    t.MATANG = txtMaTang.Text;
                    t.TENTANG = txtTenTang.Text;
                    tangBLL.themTangBLL(t);
                    MessageBox.Show("Thêm thành công!");
                    loadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi đã xảy ra!");
                    throw;
                }
            }
            else 
            {
                TANG t = tangBLL.layTangBLL(txtMaTang.Text);
                t.TENTANG = txtTenTang.Text;
                tangBLL.suaTangBLL(t);
                MessageBox.Show("Sửa thành công!");
            }
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
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa tầng này không?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    try
                    {
                        TANG t = tangBLL.layTangBLL(txtMaTang.Text);
                        if (!tangBLL.xoaTangBLL(t))
                        {
                            MessageBox.Show("Không thể xóa tầng!");
                        }
                        loadData();
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
    }
}
