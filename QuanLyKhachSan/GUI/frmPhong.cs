using BLL;
using DevExpress.XtraEditors.Controls;
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
    public partial class frmPhong : Form
    {
        PhongBLL phongBLL;
        TangBLL tangBLL;
        LoaiPhongBLL loaiPhongBLL;
        bool _them;
        public frmPhong()
        {
            InitializeComponent();
            this.Load += FrmPhong_Load;
            gridDS.Click += GridDS_Click;
        }

        private void GridDS_Click(object sender, EventArgs e)
        {
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridDS.RowCount > 0 && !_them)
            {
                _them = false;
                txtMaPhong.Text = gridDS.GetFocusedRowCellValue("MAPHONG").ToString();
                txtTenPhong.Text = gridDS.GetFocusedRowCellValue("TENPHONG").ToString();
                var tenTang = gridView.GetFocusedRowCellValue("TENTANG");
                var tenLoaiPhong = gridView.GetFocusedRowCellValue("TENLOAIPHONG");
                if (tenTang != null || tenLoaiPhong != null)
                {
                    string stenTang = tenTang.ToString();
                    string stenLoaiPhong = tenLoaiPhong.ToString();
                    // Tìm và chọn mục tương ứng trong ComboBox
                    var matchingTang = cboTang.Items.Cast<DTO.TANG>().FirstOrDefault(item => item.TENTANG == stenTang);
                    var matchingLoaiPhong = cboLoaiPhong.Items.Cast<DTO.LOAIPHONG>().FirstOrDefault(item => item.TENLOAIPHONG == stenLoaiPhong);
                    cboTang.SelectedItem = matchingTang;
                    cboLoaiPhong.SelectedItem = matchingLoaiPhong;

                }

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void FrmPhong_Load(object sender, EventArgs e)
        {
            phongBLL = new PhongBLL();
            tangBLL = new TangBLL();
            loaiPhongBLL = new LoaiPhongBLL();
            loadData();
            xuLyControl();
        }

        void enableCacControl()
        {
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtTenPhong.Enabled = true;
        }
        void loadData()
        {
            cboTang.DataSource = tangBLL.layDanhSachTangBLL();
            cboTang.DisplayMember = "TENTANG";
            cboTang.ValueMember = "MATANG";
            cboLoaiPhong.DataSource = loaiPhongBLL.layDanhSachLOAIPHONGBLL();
            cboLoaiPhong.DisplayMember = "TENLOAIPHONG";
            cboLoaiPhong.ValueMember = "MALOAIPHONG";
            gcDS.DataSource = phongBLL.layPhongDataSourceBLL();
            txtTenPhong.Enabled = false;
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
            txtMaPhong.Enabled = false;
            txtTenPhong.Enabled = false;
            txtMaPhong.Text = string.Empty;
            txtTenPhong.Text = string.Empty;
            cboLoaiPhong.SelectedIndex = -1;
            cboTang.SelectedIndex = -1;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            gridDS.ActiveFilterEnabled = false;
            txtTenPhong.Text = string.Empty;
            txtMaPhong.Text = MaPhongTuDong();
            cboLoaiPhong.SelectedIndex = -1;
            cboTang.SelectedIndex = -1;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            enableCacControl();
        }

        private string MaPhongTuDong()
        {
            int soTT = phongBLL.layPhongDataSourceBLL().Count + 1;
            string maTang = "PH" + soTT.ToString("D3");
            return maTang;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenPhong.Text.Equals(string.Empty) || cboLoaiPhong.SelectedIndex ==-1 || cboTang.SelectedIndex ==-1)
            {
                MessageBox.Show("Kiểm tra lại các thông tin");
                return;
            }
            if (_them)
            {
                try
                {
                    PHONG p = new PHONG();
                    p.MAPHONG = txtMaPhong.Text;
                    p.TENPHONG = txtTenPhong.Text;
                    LOAIPHONG lpItem = (LOAIPHONG)cboLoaiPhong.SelectedItem;
                    p.MALOAIPHONG = lpItem.MALOAIPHONG;
                    TANG tangItem = (TANG)cboTang.SelectedItem;
                    p.MATANG = tangItem.MATANG;
                    phongBLL.themPhongBLL(p); 
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
                PHONG p = phongBLL.layPhong(txtMaPhong.Text);
                p.TENPHONG = txtTenPhong.Text;
                LOAIPHONG lpItem = (LOAIPHONG)cboLoaiPhong.SelectedItem;
                p.MALOAIPHONG = lpItem.MALOAIPHONG;
                TANG tangItem = (TANG)cboTang.SelectedItem;
                p.MATANG = tangItem.MATANG;
                phongBLL.SuaPhongBLL(p);
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
                PHONG p = phongBLL.layPhong(txtMaPhong.Text);
                DialogResult ret = MessageBox.Show("Bạn có muốn xóa phòng " + "'" + p.TENPHONG + "'" + " không?", "Hỏi xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    try
                    {

                        if (!phongBLL.XoaPhongBLL(p))
                        {
                            MessageBox.Show("Không thể xóa phòng!");
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
    }

}
