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
using DTO;
using BLL;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraExport.Helpers;
using DevExpress.DataAccess.Native.Data;
using DevExpress.XtraGrid;
using System.Diagnostics;
namespace GUI
{
    public partial class frmDatPhongTheoDoan : Form
    {
        bool _them;
        SanPhamBLL sanPhamBLL;
        PhongBLL phongBLL;
        KhachHangBLL khachHangBLL;
        GridHitInfo downHitInfo = null;
        string _idPhong;
        string _tenPhong;
        List<OBJ_DPSP> lstDPSP;
        System.Data.DataTable dtPhongTrong;
        System.Data.DataTable dtPhongDat;
        public frmDatPhongTheoDoan()
        {
            InitializeComponent();
            _idPhong = string.Empty;
            _tenPhong = string.Empty;
            downHitInfo = new GridHitInfo();
            this.Load += FrmDatPhongTheoDoan_Load;
            dtPhongTrong = HamXuLy.layDuLieu("select MAPHONG, TENPHONG, DONGIA, PHONG.MATANG, TENTANG  from PHONG inner join TANG on PHONG.MATANG = TANG.MATANG inner join LOAIPHONG on PHONG.MALOAIPHONG = LOAIPHONG.MALOAIPHONG where PHONG.HOATDONG = 0");
            gcPhong.DataSource = dtPhongTrong;
            dtPhongDat = dtPhongTrong.Clone();
            gcPhongDat.DataSource = dtPhongDat;
        }

        private void FrmDatPhongTheoDoan_Load(object sender, EventArgs e)
        {
            lstDPSP = new List<OBJ_DPSP>();
            sanPhamBLL = new SanPhamBLL();
            khachHangBLL = new KhachHangBLL();
            phongBLL = new PhongBLL();
            xuLyControl();
            dtpTuNgay.Value = HamXuLy.NgayDauThang(dtpTuNgay.Value.Year, dtpTuNgay.Value.Month);
            dtpDenNgay.Value = DateTime.Now;
            loadData();
        }

        private void loadData()
        {
            loadKH();
            loadSP();
            //loadPhongTrong();
            cboTrangThai.DataSource = TrangThaiDatPhong.layDSTrangThai();
            cboTrangThai.DisplayMember = "_display";
            cboTrangThai.ValueMember = "_value";
        }

        private void loadPhongTrong()
        {
            
            gcPhong.DataSource = phongBLL.layPhongTrongBLL();
            
            
        }

        private void loadSP()
        {
            gcSanPham.DataSource = sanPhamBLL.layDSSPBLL();
            gvSanPham.OptionsBehavior.Editable = false;
        }

        private void loadKH()
        {
            cboKhachHang.DataSource = khachHangBLL.layDSKHBLL();
            cboKhachHang.DisplayMember = "HOTENKH";
            cboKhachHang.ValueMember = "MAKH";

        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            enableCacControl();
            btnIn.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            tabDanhSach.SelectedTabPage = pageChiTiet;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            enableCacControl();
            tabDanhSach.SelectedTabPage = pageChiTiet;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            xuLyControl();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xuLyControl();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {

        }
        void xuLyControl()
        {
            _them = false;
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnIn.Enabled = false;
            btnThemMoi.Enabled = false;
            cboKhachHang.Enabled = false;
            cboTrangThai.Enabled = false;
            txtGhiChu.Enabled = false;
            dtpNgayDat.Enabled = false;
            dtpNgayTra.Enabled = false;
            chkTheoDoan.Enabled = false;
            txtGhiChu.Text = string.Empty;
            spSoNguoi.Enabled = false;
            spSoNguoi.Text = string.Empty;
            tabDanhSach.SelectedTabPage = pageDanhSach;
        }
        void enableCacControl()
        {
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtGhiChu.Enabled = true;
            cboKhachHang.Enabled = true;
            cboTrangThai.Enabled = true;
            txtGhiChu.Enabled = true;
            dtpNgayDat.Enabled = true;
            dtpNgayTra.Enabled = true;
            chkTheoDoan.Enabled = true;
            spSoNguoi.Enabled = true;
        }



        private void gvPhongDat_MouseMove(object sender, MouseEventArgs e)
        {

            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    if (downHitInfo.RowHandle >= 0)
                    {
                        DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                        if (row != null)
                        {
                            view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                            downHitInfo = null;
                            DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                        }
                    }
                }
            }

        }

        private void gvPhongDat_MouseDown(object sender, MouseEventArgs e)
        {
            if (gvPhongDat.GetFocusedRowCellValue("MAPHONG") != null)
            {
                _idPhong = gvPhongDat.GetFocusedRowCellValue("MAPHONG").ToString();
                _tenPhong = gvPhongDat.GetFocusedRowCellValue("TENPHONG").ToString();
            }
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitInfor = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfor.RowHandle >= 0)
            {
                downHitInfo = hitInfor;
            }


        }

        private void gcPhong_DragDrop(object sender, DragEventArgs e)
        {
            //GridControl grid = sender as GridControl;
            //System.Data.DataTable table = grid.DataSource as System.Data.DataTable;
            //DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            //if (row != null && table != null && row.Table != table)
            //{
            //    table.ImportRow(row);
            //    row.Delete();
            //}

        }

        private void gcPhong_DragOver(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(DataRow)))
            //{
            //    e.Effect = DragDropEffects.Move;
            //}
            //else
            //{
            //    e.Effect = DragDropEffects.None;
            //}

        }

        private void gvPhong_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2, downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);
                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);
                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);
                    downHitInfo = null;
                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }

        private void gvPhong_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;
            GridHitInfo hitlnfor = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitlnfor.RowHandle >= 0)
            {
                downHitInfo = hitlnfor;
            }
                

        }

        private void gcPhongDat_MouseDown(object sender, MouseEventArgs e)
        {

        }
        private void gcPhong_DoubleClick(object sender, EventArgs e)
        {
            //if (gvPhong.GetFocusedRowCellValue("MAPHONG")!=null)
            //{
            //    PhongDataTable phong = new PhongDataTable();
            //    phong.maPhong = gvPhong.GetFocusedRowCellValue("MAPHONG").ToString();
            //    phong.tenPhong = gvPhong.GetFocusedRowCellValue("TENPHONG").ToString();
            //    phong.maTang = gvPhong.GetFocusedRowCellValue("MATANG").ToString();
            //    phong.tenTang = gvPhong.GetFocusedRowCellValue("TENTANG").ToString();
            //    phong.donGia = decimal.Parse(gvPhong.GetFocusedRowCellValue("TENTANG").ToString());
            //}
            if (gvPhong.GetFocusedRowCellValue("MAPHONG") != null)
            {
                DataRow row = gvPhong.GetFocusedDataRow();
                dtPhongDat.ImportRow(row);
                dtPhongTrong.Rows.Remove(row);
                gcPhongDat.DataSource = dtPhongDat;
            }

            
        }

        private void gcSanPham_DoubleClick(object sender, EventArgs e)
        {

            if (_idPhong.Equals(string.Empty))
            {
                MessageBox.Show("Vui lòng chọn phòng", "Thông báo");
                return;
            }
            if(gvSanPham.GetFocusedRowCellValue("MASP")!=null)
            {
                OBJ_DPSP sp = new OBJ_DPSP();
                sp.MASP = gvSanPham.GetFocusedRowCellValue("MASP").ToString();
                sp.TENSP = gvSanPham.GetFocusedRowCellValue("TENSP").ToString();
                sp.MAPHONG = _idPhong;
                sp.TENPHONG = _tenPhong;
                sp.DONGIA = decimal.Parse(gvSanPham.GetFocusedRowCellValue("DONGIA").ToString());
                sp.SOLUONG = 1;
                sp.THANHTIEN = sp.DONGIA * sp.SOLUONG;
                foreach(var item in lstDPSP)
                {
                    if (item.MASP == sp.MASP && item.MAPHONG == sp.MAPHONG)
                    {
                        item.SOLUONG++;
                        item.THANHTIEN = item.SOLUONG * item.DONGIA;
                        loadDPSP();
                        lblTongTien.Text = ((decimal.Parse(gvDVDat.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString()) + (decimal.Parse(gvPhongDat.Columns["DONGIA"].SummaryItem.SummaryValue.ToString()))).ToString()).ToString();
                        return;
                    }
                }
                lstDPSP.Add(sp);
            }
            loadDPSP();
            lblTongTien.Text = ((decimal.Parse(gvDVDat.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString())+ (decimal.Parse(gvPhongDat.Columns["DONGIA"].SummaryItem.SummaryValue.ToString()))).ToString()).ToString();
        }
        void loadDPSP()
        {
            List<OBJ_DPSP> lsdp = new List<OBJ_DPSP>();
            foreach (var item in lstDPSP)
            {
                lsdp.Add(item);
            }
            gcDVDat.DataSource = lsdp;
        }

        private void gvDVDat_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "SOLUONG")
            {
                int sl = int.Parse(e.Value.ToString());
                if (sl != 0)
                {
                    decimal gia = decimal.Parse(gvDVDat.GetRowCellValue(gvDVDat.FocusedRowHandle,"DONGIA").ToString());
                    gvDVDat.SetRowCellValue(gvDVDat.FocusedRowHandle, "THANHTIEN", sl * gia);
                }
                else
                {
                    gvDVDat.SetRowCellValue(gvDVDat.FocusedRowHandle, "THANHTIEN", 0);
                }
                gvDVDat.UpdateTotalSummary();
                lblTongTien.Text = gvDVDat.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString();
            }
        }

        private void gcPhongDat_Click(object sender, EventArgs e)
        {
            if (gvPhong.GetFocusedRowCellValue("MAPHONG") != null)
            {
                _idPhong = gvPhongDat.GetFocusedRowCellValue("MAPHONG").ToString();
                _tenPhong = gvPhongDat.GetFocusedRowCellValue("TENPHONG").ToString();
            }
        }

        private void gcPhongDat_DoubleClick(object sender, EventArgs e)
        {
            if (gvPhongDat.GetFocusedRowCellValue("MAPHONG") != null)
            {
                DataRow row = gvPhongDat.GetFocusedDataRow();
                dtPhongTrong.ImportRow(row);
                dtPhongDat.Rows.Remove(row);
                gcPhongDat.DataSource = dtPhongDat;
                gcPhong.DataSource = dtPhongTrong;
                _idPhong = string.Empty;
                _tenPhong = string.Empty;
            }
        }

        private void gvPhongDat_RowCountChanged(object sender, EventArgs e)
        {
            decimal t = 0;
            if (gvDVDat.Columns["THANHTIEN"].SummaryItem.SummaryValue == null)
            {
                t = 0;
            }
            else
            {
                t = decimal.Parse(gvDVDat.Columns["THANHTIEN"].SummaryItem.SummaryValue.ToString());
                lblTongTien.Text = (decimal.Parse(gvPhongDat.Columns["DONGIA"].SummaryItem.SummaryValue.ToString()) + t).ToString();
            }
        }
    }
}
