﻿using System;
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
    public partial class frmNguoiDung : Form
    {
        NguoiDungBLL bllnd;
        public frmNguoiDung()
        {

            InitializeComponent();
            bllnd = new NguoiDungBLL();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
