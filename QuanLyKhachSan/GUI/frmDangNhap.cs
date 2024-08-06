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
        XuLyDangNhap CauHinh;
        public static string tenDangNhap = "null";
        public frmDangNhap()
        {
            InitializeComponent();
            this.Load += FrmDangNhap_Load;
            btnDangNhap.Click += BtnDangNhap_Click;
        }
        
        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblTenDangNhap.Text))
            {
                MessageBox.Show("Không được bỏ trống " + lblTenDangNhap.Text.ToLower());
                this.lblTenDangNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Không được bỏ trống " + lblMatKhau.Text.ToLower());
                this.txtMatKhau.Focus();
                return;
            }
            CauHinh = new XuLyDangNhap();
            int kq = CauHinh.Check_Config(); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                ProcessConfig();
            }
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
                panel1.BackColor = Color.FromArgb(100, 38, 147, 109);
                btnDangNhap.BackColor = Color.FromArgb(100, 138, 211, 154);
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

        //=========================================================================
        //=====================Các hàm xử lý=====================
        //=========================================================================

        /// <summary>
        /// Các xử lý nếu kết nối thành công
        /// </summary>
        private void ProcessLogin()
        {
            LoginResult result;
            result = CauHinh.Check_User(txtTenDangNhap.Text, txtMatKhau.Text);
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + lblTenDangNhap.Text + " Hoặc " + lblMatKhau.Text);
                return;
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }
            if (Program.MainForm == null || Program.MainForm.IsDisposed)
            {
                tenDangNhap = txtTenDangNhap.Text;
                Program.MainForm = new frmMain();
            }
            this.Visible = false;
            Program.MainForm.Show();
        }


        /// <summary>
        /// Các xử lý nếu không kết nối thành công
        /// </summary>
        private void ProcessConfig()
        {
            if (Program.formCN == null || Program.formCN.IsDisposed)
            {
                Program.formCN = new frmCauHinhKetNoi();
            }
            this.Visible = false;
            Program.formCN.Show();
        }

    }
}
