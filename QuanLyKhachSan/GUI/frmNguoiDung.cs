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
    public partial class frmNguoiDung : Form
    {
        NguoiDungBLL bllnd;
        public frmNguoiDung()
        {

            InitializeComponent();
            this.Load += FrmNguoiDung_Load;
        }

        private void FrmNguoiDung_Load(object sender, EventArgs e)
        {
            bllnd = new NguoiDungBLL();
            gridControlNguoiDung.DataSource = bllnd.loadNguoiDungBLL();
            gridNguoiDung.RowCellClick += GridNguoiDung_RowCellClick;
        }

        private void GridNguoiDung_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        int index = -1;

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
