namespace GUI
{
    partial class frmThongBao
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcThongTin = new DevExpress.XtraGrid.GridControl();
            this.gvThongTin = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnNhapThongTin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThongTin)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcThongTin);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 90);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(805, 217);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Thông tin đặt online";
            // 
            // gcThongTin
            // 
            this.gcThongTin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcThongTin.Location = new System.Drawing.Point(2, 28);
            this.gcThongTin.MainView = this.gvThongTin;
            this.gcThongTin.Name = "gcThongTin";
            this.gcThongTin.Size = new System.Drawing.Size(801, 187);
            this.gcThongTin.TabIndex = 0;
            this.gcThongTin.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvThongTin});
            // 
            // gvThongTin
            // 
            this.gvThongTin.GridControl = this.gcThongTin;
            this.gvThongTin.Name = "gvThongTin";
            // 
            // btnNhapThongTin
            // 
            this.btnNhapThongTin.Location = new System.Drawing.Point(12, 12);
            this.btnNhapThongTin.Name = "btnNhapThongTin";
            this.btnNhapThongTin.Size = new System.Drawing.Size(180, 31);
            this.btnNhapThongTin.TabIndex = 1;
            this.btnNhapThongTin.Text = "Nhập vào hệ thống";
            this.btnNhapThongTin.UseVisualStyleBackColor = true;
            this.btnNhapThongTin.Click += new System.EventHandler(this.btnNhapThongTin_Click);
            // 
            // frmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 307);
            this.Controls.Add(this.btnNhapThongTin);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmThongBao";
            this.Text = "frmThongBao";
            this.Load += new System.EventHandler(this.frmThongBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcThongTin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvThongTin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcThongTin;
        private DevExpress.XtraGrid.Views.Grid.GridView gvThongTin;
        private System.Windows.Forms.Button btnNhapThongTin;
    }
}