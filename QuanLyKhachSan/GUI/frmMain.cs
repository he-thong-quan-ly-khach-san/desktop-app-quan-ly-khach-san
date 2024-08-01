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
using BLL;
using DTO;
namespace GUI
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            btnThoat.ItemClick += BtnThoat_ItemClick;
            tangBLL = new TangBLL();
            phongBLL = new PhongBLL();
            //testLoadPhong();
            loadForm();
            loadDSPhong();
        }
        static string tenDangNhap;
        TangBLL tangBLL;
        PhongBLL phongBLL;
        void loadForm()
        {

            this.WindowState = FormWindowState.Maximized;
            tenDangNhap = frmDangNhap.tenDangNhap;
            btnNguoiDung.ItemClick += BtnNguoiDung_ItemClick;
            btnNhomNguoiDung.ItemClick += BtnNhomNguoiDung_ItemClick;
            btnManHinh.ItemClick += BtnManHinh_ItemClick;
            if (tenDangNhap.Equals("null"))
            {
                lblXinChao.Caption = string.Empty;
            }
            else
            {
                lblXinChao.Caption = "Xin chào " + tenDangNhap; 
            }
        }
        private void LoadForm<T>() where T : Form, new()
        {
            T frm = new T();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
        private void BtnManHinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm<frmManHinh>();

        }

        private void BtnNhomNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm<frmNhomNguoiDung>();
        }

        private void BtnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm<frmNguoiDung>();
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
        
        void loadDSPhong()
        {
            List<TANG> lstTang = tangBLL.layDanhSachTangBLL();
            gControl.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(64, 64);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;
            foreach(TANG tang in lstTang)
            {
                var galleryItemGroup = new GalleryItemGroup
                {
                    Caption = tang.TENTANG.ToString(),
                    CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch
                };
                List<PHONG> phongList = phongBLL.loadPhongTheoTang(tang);
                foreach(PHONG phong in phongList)
                {
                    var gc_item = new GalleryItem();
                    gc_item.Caption = phong.TENPHONG.ToString();
                    if (phong.HOATDONG == false)
                    {
                        gc_item.ImageOptions.Image = imgListGiuong.Images[0];
                    }
                    else
                    {
                        gc_item.ImageOptions.Image = imgListGiuong.Images[1];
                    }
                    galleryItemGroup.Items.Add(gc_item);
                }
                gControl.Gallery.Groups.Add(galleryItemGroup);
            }
        }
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

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


    }
}
