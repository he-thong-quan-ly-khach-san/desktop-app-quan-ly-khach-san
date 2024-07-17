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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            this.Load += FrmDangNhap_Load;
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
                panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
                button1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
