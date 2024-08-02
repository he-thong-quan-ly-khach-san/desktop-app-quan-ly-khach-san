<<<<<<< HEAD
﻿using System;
=======
﻿using DAL;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DTO;
using System;
>>>>>>> feature/QLKH
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
    public partial class frmDanhSachKhachHang : Form
    {
<<<<<<< HEAD
=======
        KhachHangDAL khachHangDAL = new KhachHangDAL();
        bool CapNhapKhachHang = false;
        bool XoaKH = false;
>>>>>>> feature/QLKH
        public frmDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void frmDanhSachKhachHang_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD

=======
            LoadDSKhachHang();
            
            AnTextBoxKhachHang();
            AnButtonKhachHang();
            HienThiButton(true);
        }

        public void LoadDSKhachHang()
        {
            List<KHACHHANG> obj = khachHangDAL.LayTatCaKhachHang();
            

            gridKhachHang.DataSource = obj;


        }

        public void AnTextBoxKhachHang()
        {
            txtHoTen.Enabled = false;
            txtCCCD.Enabled = false;
            txtDiaChi.Enabled = false;
            txtEmail.Enabled = false;
            txtSoDT.Enabled = false;
        }

        public void HienThiTextBoxKhachHang()
        {
            txtHoTen.Enabled = true;
            txtCCCD.Enabled = true;
            txtDiaChi.Enabled = true;
            txtEmail.Enabled = true;
            txtSoDT.Enabled = true;
        }

        public void AnButtonKhachHang()
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        public void HienThiButton(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnLuu.Visible = !t;
            btnQuayLai.Visible = !t;
        }

        public void HienThiButtonKhachHang()
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gvKhachHang_Click(object sender, EventArgs e)
        {
            HienThiButtonKhachHang();
            if (gvKhachHang.RowCount > 0)
            {
                txtHoTen.Text = gvKhachHang.GetFocusedRowCellValue("HOTENKH").ToString();
                txtEmail.Text = gvKhachHang.GetFocusedRowCellValue("EMAIL").ToString();
                txtDiaChi.Text = gvKhachHang.GetFocusedRowCellValue("DIACHI").ToString();
                txtCCCD.Text = gvKhachHang.GetFocusedRowCellValue("CCCD").ToString();
                txtSoDT.Text = gvKhachHang.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtMAKH.Text = gvKhachHang.GetFocusedRowCellValue("MAKH").ToString();
                bool trangThai = Convert.ToBoolean(gvKhachHang.GetFocusedRowCellValue("TRANGTHAI"));
                if (trangThai == true)
                {
                    btnDangO.Checked = true;
                    btnTraPhong.Checked = false;
                }
                else
                {
                    btnDangO.Checked = false;
                    btnTraPhong.Checked = true;
                }
                
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            HienThiTextBoxKhachHang();
            HienThiButton(false);
            CapNhapKhachHang = true;
            
        }

        public void ChinhSuaKhachHang()
        {
            try
            {
                string makh = txtMAKH.Text;
                string ten = txtHoTen.Text;
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSoDT.Text;
                bool trangThai = btnDangO.Checked == true ? true : false;
                string cccd = txtCCCD.Text;

                var khachHang = gvKhachHang.GetFocusedRow() as KHACHHANG;
                if (khachHang == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                khachHang.HOTENKH = ten;
                khachHang.DIACHI = diaChi;
                khachHang.DIENTHOAI = soDienThoai;
                khachHang.TRANGTHAI = trangThai;
                khachHang.CCCD = cccd;

                khachHangDAL.CapNhatKhachHang(khachHang);

                LoadDSKhachHang();

                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void XoaKhachHang()
        {
            try
            {
                var result = MessageBox.Show("Bạn có muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                var khachHang = gvKhachHang.GetFocusedRow() as KHACHHANG;
                khachHangDAL.XoaKhachHang(khachHang.MAKH);

                LoadDSKhachHang();

                MessageBox.Show("Xóa thành công khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(CapNhapKhachHang == true)
            {
                ChinhSuaKhachHang();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            XoaKhachHang();

            
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            HienThiButton(true);
>>>>>>> feature/QLKH
        }
    }
}
