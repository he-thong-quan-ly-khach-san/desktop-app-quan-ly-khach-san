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
                panel1.BackColor = Color.FromArgb(100, 38, 147, 109);
                button1.BackColor = Color.FromArgb(100, 138, 211, 154);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult ret = MessageBox.Show("Thoát khỏi phần mềm?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.No)
            { 
                e.Cancel = true;
            }
        }
    }
}
