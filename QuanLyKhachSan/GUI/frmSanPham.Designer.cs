namespace GUI
{
    partial class frmSanPham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPham));
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcDS = new DevExpress.XtraGrid.GridControl();
            this.gridDS = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MASP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DAXOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 32);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.toolStripSeparator1,
            this.btnLuu,
            this.btnThoat,
            this.btnHuy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1439, 35);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(84, 32);
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(69, 32);
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(70, 32);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(68, 32);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(71, 32);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(145, 108);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(241, 23);
            this.txtDonGia.TabIndex = 3;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(145, 72);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(241, 23);
            this.txtTenSP.TabIndex = 3;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(145, 37);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(241, 23);
            this.txtMaSP.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Đơn giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên sản phẩm";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcDS);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 213);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1439, 601);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Danh sách sản phẩm";
            // 
            // gcDS
            // 
            this.gcDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDS.Location = new System.Drawing.Point(2, 28);
            this.gcDS.MainView = this.gridDS;
            this.gcDS.Name = "gcDS";
            this.gcDS.Size = new System.Drawing.Size(1435, 571);
            this.gcDS.TabIndex = 0;
            this.gcDS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDS});
            // 
            // gridDS
            // 
            this.gridDS.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MASP,
            this.TENSP,
            this.DONGIA,
            this.DAXOA});
            this.gridDS.GridControl = this.gcDS;
            this.gridDS.Name = "gridDS";
            // 
            // MASP
            // 
            this.MASP.Caption = "Mã sản phẩm";
            this.MASP.FieldName = "MASP";
            this.MASP.MinWidth = 25;
            this.MASP.Name = "MASP";
            this.MASP.Visible = true;
            this.MASP.VisibleIndex = 0;
            this.MASP.Width = 94;
            // 
            // TENSP
            // 
            this.TENSP.Caption = "Tên sản phẩm";
            this.TENSP.FieldName = "TENSP";
            this.TENSP.MinWidth = 25;
            this.TENSP.Name = "TENSP";
            this.TENSP.Visible = true;
            this.TENSP.VisibleIndex = 1;
            this.TENSP.Width = 94;
            // 
            // DONGIA
            // 
            this.DONGIA.Caption = "Đơn giá";
            this.DONGIA.FieldName = "DONGIA";
            this.DONGIA.MinWidth = 25;
            this.DONGIA.Name = "DONGIA";
            this.DONGIA.Visible = true;
            this.DONGIA.VisibleIndex = 2;
            this.DONGIA.Width = 94;
            // 
            // DAXOA
            // 
            this.DAXOA.Caption = "DAXOA";
            this.DAXOA.FieldName = "DAXOA";
            this.DAXOA.MinWidth = 25;
            this.DAXOA.Name = "DAXOA";
            this.DAXOA.Visible = true;
            this.DAXOA.VisibleIndex = 3;
            this.DAXOA.Width = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã sản phẩm";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtDonGia);
            this.groupControl2.Controls.Add(this.txtTenSP);
            this.groupControl2.Controls.Add(this.txtMaSP);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl2.Location = new System.Drawing.Point(0, 35);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1439, 156);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Thông tin";
            // 
            // frmSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 814);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmSanPham";
            this.Text = "frmSanPham";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcDS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDS;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private DevExpress.XtraGrid.Columns.GridColumn MASP;
        private DevExpress.XtraGrid.Columns.GridColumn TENSP;
        private DevExpress.XtraGrid.Columns.GridColumn DONGIA;
        private DevExpress.XtraGrid.Columns.GridColumn DAXOA;
    }
}