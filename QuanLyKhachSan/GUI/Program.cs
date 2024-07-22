using DevExpress.Utils.DirectXPaint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// frmDangNhap formDN;
        public static frmCauHinhKetNoi formCN;
        public static frmMain MainForm;
        public static frmDangNhap formDN;
        [STAThread]

        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formDN = new frmDangNhap();
            formCN = new frmCauHinhKetNoi();
            Application.Run(formDN);
        }
    }
}
