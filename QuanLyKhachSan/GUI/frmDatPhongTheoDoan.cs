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
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using DevExpress.XtraRichEdit.Internal;
namespace GUI
{
    public partial class frmDatPhongTheoDoan : Form
    {
        bool _them;
        SanPhamBLL sanPhamBLL;
        PhongBLL phongBLL;
        KhachHangBLL khachHangBLL;
        GridHitInfo downHitInfo = null;
        DatPhongBLL dpBLL;
        Phong_DattPhongBLL phongDattPhongBLL;
        SP_DatPhongBLL sp_DatPhongBLL;
        string _idPhong;
        string _tenPhong;
        List<OBJ_DPSP> lstDPSP;
        System.Data.DataTable dtPhongTrong;
        System.Data.DataTable dtPhongDat;
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
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
            sp_DatPhongBLL = new SP_DatPhongBLL();
            phongDattPhongBLL = new Phong_DattPhongBLL();
            lstDPSP = new List<OBJ_DPSP>();
            sanPhamBLL = new SanPhamBLL();
            khachHangBLL = new KhachHangBLL();
            phongBLL = new PhongBLL();
            dpBLL = new DatPhongBLL();
            xuLyControl();
            dtpTuNgay.Value = HamXuLy.NgayDauThang(dtpTuNgay.Value.Year, dtpTuNgay.Value.Month);
            dtpDenNgay.Value = DateTime.Now;
            loadData();
        }

        private void loadData()
        {
            loadDSDat();
            loadKH();
            loadSP();
            //loadPhongTrong();
            cboTrangThai.DataSource = TrangThaiDatPhong.layDSTrangThai();
            cboTrangThai.DisplayMember = "_display";
            cboTrangThai.ValueMember = "_value";
        }

        private void loadDSDat()
        {
            _them = false;
            gcDanhSach.DataSource = dpBLL.LayDSBLL(dtpTuNgay.Value, dtpDenNgay.Value.AddDays(1));
            gridDS.OptionsBehavior.Editable = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
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

        public void loadKH()
        {
            khachHangBLL = new KhachHangBLL();
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
            if (MessageBox.Show("Bạn có muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DATPHONG dp = dpBLL.getDPBLL(maDPhong);
                dpBLL.xoaBLL(dp);
                loadDSDat();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            saveData();
            _them = false;
            xuLyControl();
            objMain.loadDSPhong();
        }
        
        string phatSinhMaDP()
        {
            List<DATPHONG> list = new List<DATPHONG>();
            list = dpBLL.LayDSBLL();
            return "DP"+list.Count.ToString("D8");
        }
        string phatSinhMaPDP()
        {
            List<PHONG_DATPHONG> lst = phongDattPhongBLL.LayDSBLL();
            return "PDP" + lst.Count.ToString("D7");
        }

        string phatSinhMaSPDP()
        {
            List<SP_DATPHONG> lst = sp_DatPhongBLL.LayDSBLL();
            return "SDP" + lst.Count.ToString("D7");
        }
        void saveData()
        {
            if (_them)
            {
                DATPHONG dp = new DATPHONG();
                PHONG_DATPHONG pdp = new PHONG_DATPHONG();
                SP_DATPHONG sdp = new SP_DATPHONG();
                dp.MADATPHONG = phatSinhMaDP();
                dp.MAKH = cboKhachHang.SelectedValue.ToString();
                dp.NGAYDAT = dtpNgayDat.Value;
                dp.NGAYTRA = dtpNgayTra.Value;
                dp.SONGUOIO = short.Parse(spSoNguoi.EditValue.ToString());
                dp.TRANGTHAI = bool.Parse(cboTrangThai.SelectedValue.ToString());
                dp.SOTIEN = decimal.Parse(lblTongTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                dp.THEODOAN = chkTheoDoan.Checked;
                dp.DISABLED = false;
                maDPhong = dp.MADATPHONG;
                dp.TENDANGNHAP = frmDangNhap.tenDangNhap;
                var datphong = dpBLL.themDPBLL(dp);
                for (int i = 0;i<gvPhongDat.RowCount;i++)
                {
                    pdp = new PHONG_DATPHONG();
                    pdp.MAPHONG_DATPHONG = phatSinhMaPDP();
                    pdp.MADATPHONG = dp.MADATPHONG;
                    pdp.MAPHONG = gvPhongDat.GetRowCellValue(i, "MAPHONG").ToString();
                    pdp.SONGAYO = (short?)(dtpNgayTra.Value.Day - dtpNgayDat.Value.Day);
                    pdp.DONGIA = decimal.Parse(gvPhongDat.GetRowCellValue(i, "DONGIA").ToString());
                    phongDattPhongBLL.addBLL(pdp);
                    phongBLL.capNhatTrangThaiBLL(pdp.MAPHONG, true);
                    if (gvDVDat.RowCount > 0)
                    {
                        for (int j = 0; j < gvDVDat.RowCount; j++)
                        {
                            if (pdp.MAPHONG == gvDVDat.GetRowCellValue(j,"MAPHONG").ToString())
                            {
                                sdp = new SP_DATPHONG();
                                sdp.MADATPHONG = dp.MADATPHONG;
                                sdp.MAPHONG = gvDVDat.GetRowCellValue(j, "MAPHONG").ToString();
                                sdp.MASP = gvDVDat.GetRowCellValue(j, "MASP").ToString();
                                sdp.MASPDP = phatSinhMaSPDP();
                                sdp.DONGIA = decimal.Parse(gvDVDat.GetRowCellValue(j, "DONGIA").ToString());
                                sdp.SOLUONG = int.Parse(gvDVDat.GetRowCellValue(j, "SOLUONG").ToString());
                                sdp.THANHTIEN = sdp.SOLUONG * sdp.DONGIA;
                                sdp.NGAY = DateTime.Now;
                                sp_DatPhongBLL.addBLL(sdp);
                            }
                            //else
                            //{
                            //    sdp = new SP_DATPHONG();
                            //    sdp.MADATPHONG = dp.MADATPHONG.ToString();
                            //    sdp.MAPHONG = pdp.MAPHONG;
                            //    sp_DatPhongBLL.addBLL(sdp);
                            //}
                        }
                        loadDSDat();
                        MessageBox.Show("Đặt phòng thành công!");
                        return;
                    }
                    else
                    {
                        sdp = new SP_DATPHONG();
                        sdp.MADATPHONG = dp.MADATPHONG.ToString();
                        sdp.MAPHONG = pdp.MAPHONG;
                        sp_DatPhongBLL.addBLL(sdp);
                    }

                }
                loadDSDat();
                MessageBox.Show("Đặt phòng thành công!");

            }
            else
            {
                DATPHONG dp = dpBLL.getDPBLL(maDPhong);
                PHONG_DATPHONG pdp;
                SP_DATPHONG dpsp;
                dp.NGAYDAT = dtpNgayDat.Value;
                dp.NGAYTRA = dtpNgayTra.Value;
                dp.SONGUOIO = short.Parse(spSoNguoi.EditValue.ToString());
                dp.TRANGTHAI = bool.Parse(cboTrangThai.SelectedValue.ToString());
                dp.SOTIEN = decimal.Parse(lblTongTien.Text);
                dp.GHICHU = txtGhiChu.Text;
                maDPhong = dp.MADATPHONG;
                //dp.TENDANGNHAP = frmDangNhap.tenDangNhap;
                var _dp = dpBLL.suaBLL(dp);
                phongDattPhongBLL.xoaAllBLL(dp.MADATPHONG);
                sp_DatPhongBLL.xoaAllBLL(dp.MADATPHONG);
                for (int i = 0; i < gvPhongDat.RowCount; i++)
                {
                    pdp = new PHONG_DATPHONG();
                    pdp.MADATPHONG = dp.MADATPHONG;
                    pdp.MAPHONG = gvPhongDat.GetRowCellValue(i, "MAPHONG").ToString();
                    pdp.SONGAYO = (short?)(dtpNgayTra.Value.Day - dtpNgayDat.Value.Day);
                    pdp.DONGIA = decimal.Parse(gvPhongDat.GetRowCellValue(i, "DONGIA").ToString());
                    phongDattPhongBLL.addBLL(pdp);
                    phongBLL.capNhatTrangThaiBLL(pdp.MAPHONG, true);
                    if (gvDVDat.RowCount > 0)
                    {
                        for (int j = 0; j < gvDVDat.RowCount; j++)
                        {
                            if (pdp.MAPHONG == gvDVDat.GetRowCellValue(j, "MAPHONG").ToString())
                            {
                                dpsp = new SP_DATPHONG();
                                dpsp.MADATPHONG = dp.MADATPHONG;
                                dpsp.MAPHONG = gvDVDat.GetRowCellValue(j, "MAPHONG").ToString();
                                dpsp.MASP = gvDVDat.GetRowCellValue(j, "MASP").ToString();
                                dpsp.DONGIA = decimal.Parse(gvDVDat.GetRowCellValue(j, "DONGIA").ToString());
                                dpsp.SOLUONG = int.Parse(gvDVDat.GetRowCellValue(j, "SOLUONG").ToString());
                                dpsp.THANHTIEN = dpsp.SOLUONG * dpsp.DONGIA;
                                sp_DatPhongBLL.addBLL(dpsp);
                            }
                            else
                            {
                                dpsp = new SP_DATPHONG();
                                dpsp.MADATPHONG = dp.MADATPHONG.ToString();
                                dpsp.MAPHONG = pdp.MAPHONG;
                                sp_DatPhongBLL.addBLL(dpsp);

                            }
                        }
                    }
                    else
                    {
                        dpsp = new SP_DATPHONG();
                        dpsp.MADATPHONG = dp.MADATPHONG.ToString();
                        dpsp.MAPHONG = pdp.MAPHONG;
                        sp_DatPhongBLL.addBLL(dpsp);
                    }

                }
                MessageBox.Show("Sửa thành công");
                loadDSDat();
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
            btnThemMoi.Enabled = true;
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

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        public void setKH(string maKH)
        {
            var kh = khachHangBLL.layKHBLL(maKH);
            cboKhachHang.SelectedValue = kh.MAKH;
            cboKhachHang.Text = kh.HOTENKH;
        }
        string maDPhong=string.Empty;
        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            enableCacControl();
            var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridDS.RowCount > 0 && !_them)
            {
                if(gridDS.GetFocusedRowCellValue("MAPHONG_DATPHONG") == null)
                { return; }
                _them = false;
                maDPhong = gridDS.GetFocusedRowCellValue("MAPHONG_DATPHONG").ToString();

                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void dtpTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Giá trị ngày không hợp lệ!");
                return;
            }
            loadDSDat();
        }

        private void dtpTuNgay_Leave(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Giá trị ngày không hợp lệ!");
                return;
            }
            loadDSDat();
        }

        private void dtpDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Giá trị ngày không hợp lệ!");
                return;
            }
            loadDSDat();
        }

        private void dtpDenNgay_Leave(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Giá trị ngày không hợp lệ!");
                return;
            }
            loadDSDat();
        }
        void loadDP()
        {
            gcPhongDat.DataSource = HamXuLy.layDuLieu("select PHONG.MAPHONG, TENPHONG, LOAIPHONG.DONGIA, PHONG.MATANG, TENTANG  from PHONG "
            + "inner join TANG on PHONG.MATANG = TANG.MATANG "
            + "inner join LOAIPHONG on PHONG.MALOAIPHONG = LOAIPHONG.MALOAIPHONG "
            + "inner join PHONG_DATPHONG on PHONG.MAPHONG = PHONG_DATPHONG.MAPHONG"
            + "WHERE PHONG_DATPHONG.MAPHONG_DATPHONG = '"+maDPhong+"'");
        }
        void loadSPDat()
        {
            gcDVDat.DataSource = sp_DatPhongBLL.layDSTheoDP(maDPhong);
        }
        void clickDS()
        {
            maDPhong = gridDS.GetFocusedRowCellValue("MADATPHONG").ToString();
            var dp = dpBLL.getDPBLL(maDPhong);
            cboKhachHang.SelectedValue = dp.MAKH;
            dtpNgayDat.Value = dp.NGAYDAT.Value;
            dtpNgayTra.Value = dp.NGAYTRA.Value;
            spSoNguoi.Text = dp.SONGUOIO.ToString();
            cboTrangThai.SelectedValue = dp.TRANGTHAI;
            txtGhiChu.Text = dp.GHICHU.ToString();
            lblTongTien.Text = dp.SOTIEN.Value.ToString("N0");
            loadSPDat();
        }
        private void gridDS_Click(object sender, EventArgs e)
        {
            clickDS();

        }

        private void gridDS_DoubleClick(object sender, EventArgs e)
        {
            clickDS();
            tabDanhSach.SelectedTabPage = pageChiTiet;
        }
    }
}
