﻿using System;
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
        private KhachHangDAL khachHangDAL = new KhachHangDAL();
        bool CapNhapKhachHang = false;
        bool XoaKH = false;
        public frmDanhSachKhachHang()
        {
            InitializeComponent();
        }

        private void frmDanhSachKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}
