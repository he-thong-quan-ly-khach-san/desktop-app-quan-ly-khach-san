using DevExpress.XtraBars.Ribbon;
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
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            btnThoat.ItemClick += BtnThoat_ItemClick;
            testLoadPhong();
            loadForm();
        }

        void loadForm()
        {
            this.WindowState = FormWindowState.Maximized;
            btnNguoiDung.ItemClick += BtnNguoiDung_ItemClick;
            btnNhomNguoiDung.ItemClick += BtnNhomNguoiDung_ItemClick;
        }

        private void BtnNhomNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNhomNguoiDung frm = new frmNhomNguoiDung();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void BtnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNguoiDung frm = new frmNguoiDung();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void BtnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonStatusBar1_Click(object sender, EventArgs e)
        {

        }

        string phong;
        string tang;
        void testLoadPhong()
        {
            var lstTang = new List<dynamic>
            {
                new
                {
                    TenTang = "Tầng 1",
                    Phongs = new List<dynamic>
                    {
                        new { TenPhong = "Phòng 101" },
                        new { TenPhong = "Phòng 102" },
                        new { TenPhong = "Phòng 103" }
                    }
                },
                new
                {
                    TenTang = "Tầng 2",
                    Phongs = new List<dynamic>
                    {
                        new { TenPhong = "Phòng 201" },
                        new { TenPhong = "Phòng 202" },
                        new { TenPhong = "Phòng 203" }
                    }
                },
                new
                {
                    TenTang = "Tầng 3",
                    Phongs = new List<dynamic>
                    {
                        new { TenPhong = "Phòng 301" },
                        new { TenPhong = "Phòng 302" },
                        new { TenPhong = "Phòng 303" }
                    }
                }
            };

            gControl.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(64, 64);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;

            // Truy cập thông tin trong danh sách
            foreach (var tang in lstTang)
            {
                var galleryItemGroup = new GalleryItemGroup
                {
                    Caption = tang.TenTang.ToString(),
                    CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch
                };

                foreach (var phong in tang.Phongs)
                {
                    var gc_item = new GalleryItem();
                    gc_item.Caption = phong.TenPhong.ToString();
                    gc_item.ImageOptions.Image = imgListGiuong.Images[0];
                    galleryItemGroup.Items.Add(gc_item);
                }

                gControl.Gallery.Groups.Add(galleryItemGroup);
            }
        }    
        /// <summary>
        /// Hàm này mai mốt cần xử lý khi dữ liệu trường hợp chưa lưu thì hỏi muốn lưu trước khi đóng không
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            DialogResult ret = MessageBox.Show("Thoát khỏi phần mềm?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
<<<<<<< HEAD
=======
<<<<<<< Updated upstream
=======
>>>>>>> feature/QLKH

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
<<<<<<< HEAD
=======

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDanhSachKhachHang frm = new frmDanhSachKhachHang();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
>>>>>>> Stashed changes
>>>>>>> feature/QLKH
    }
}
