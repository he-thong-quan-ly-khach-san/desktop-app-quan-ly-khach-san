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
    public partial class frmCauHinhKetNoi : Form
    {
        public frmCauHinhKetNoi()
        {
            InitializeComponent();
            cboServer.DropDown += CboServer_DropDown;
            cboDataBase.DropDown += CboDataBase_DropDown;
            btnLuu.Click += BtnLuu_Click;
            CauHinh = new XuLyDangNhap();
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            CauHinh.SaveConfig(cboServer.Text, txtUsername.Text, txtPassword.Text, cboDataBase.Text);
            this.Close();
            Program.formDN.Show();
            
        }

        private void CboDataBase_DropDown(object sender, EventArgs e)
        {
            cboDataBase.DataSource = CauHinh.GetDBName(cboServer.Text, txtUsername.Text, txtPassword.Text);
            cboDataBase.DisplayMember = "name";
        }

        XuLyDangNhap CauHinh;
        private void CboServer_DropDown(object sender, EventArgs e)
        {
            DataTable dtServers = CauHinh.GetServerName();
            dtServers.Columns.Add("CombinedName", typeof(string), "ServerName + '\\' + ISNULL(InstanceName, '')");
            cboServer.DataSource = dtServers;
            cboServer.DisplayMember = "CombinedName";
        }
        
        


        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
    }
}
