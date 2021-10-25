
namespace SHIV_PhongCachAm
{
	partial class frmLogDetail
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogDetail));
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTextFilter = new System.Windows.Forms.TextBox();
			this.btnFindDate = new System.Windows.Forms.Button();
			this.grvData = new System.Windows.Forms.DataGridView();
			this.colsttt = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDateLR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colOrderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colQRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNguoiVanHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colMotaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGiamToc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDienApTieuChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTanSoTieuChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGiaTriVongQuayChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGiaTriDongDienChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGiaTriNhapLucChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGiaTriDoRungChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGiaTriTiengOnChuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDienApThucTe = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTanSoThucTe = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colVongQuayThuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colVongQuayNghich = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDongDienThuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDongDienNghich = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNhapLucThuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colNhapLucNghich = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDoRungThuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDoRungNghich = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTiengOnThuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colTiengOnNghich = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAmSacThuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAmSacNghich = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colHuongQuay = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colXuatDacBiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
			this.SuspendLayout();
			// 
			// dtpFrom
			// 
			this.dtpFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFrom.Location = new System.Drawing.Point(83, 9);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(142, 20);
			this.dtpFrom.TabIndex = 36;
			// 
			// dtpTo
			// 
			this.dtpTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTo.Location = new System.Drawing.Point(304, 9);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(142, 20);
			this.dtpTo.TabIndex = 35;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(235, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 34;
			this.label1.Text = "Đến ngày: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(21, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 33;
			this.label3.Text = "Từ ngày: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(456, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 39;
			this.label2.Text = "Từ khóa";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtTextFilter
			// 
			this.txtTextFilter.Location = new System.Drawing.Point(512, 9);
			this.txtTextFilter.Name = "txtTextFilter";
			this.txtTextFilter.Size = new System.Drawing.Size(156, 20);
			this.txtTextFilter.TabIndex = 38;
			// 
			// btnFindDate
			// 
			this.btnFindDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindDate.Location = new System.Drawing.Point(685, 7);
			this.btnFindDate.Name = "btnFindDate";
			this.btnFindDate.Size = new System.Drawing.Size(75, 23);
			this.btnFindDate.TabIndex = 37;
			this.btnFindDate.Text = "Tìm kiếm";
			this.btnFindDate.UseVisualStyleBackColor = true;
			this.btnFindDate.Click += new System.EventHandler(this.btnFindDate_Click);
			// 
			// grvData
			// 
			this.grvData.AllowUserToAddRows = false;
			this.grvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grvData.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colsttt,
            this.colDateLR,
            this.colSTT,
            this.colOrderCode,
            this.colPID,
            this.colQRCode,
            this.colNguoiVanHanh,
            this.colMotaSanPham,
            this.colGiamToc,
            this.colDienApTieuChuan,
            this.colTanSoTieuChuan,
            this.colGiaTriVongQuayChuan,
            this.colGiaTriDongDienChuan,
            this.colGiaTriNhapLucChuan,
            this.colGiaTriDoRungChuan,
            this.colGiaTriTiengOnChuan,
            this.colDienApThucTe,
            this.colTanSoThucTe,
            this.colVongQuayThuan,
            this.colVongQuayNghich,
            this.colDongDienThuan,
            this.colDongDienNghich,
            this.colNhapLucThuan,
            this.colNhapLucNghich,
            this.colDoRungThuan,
            this.colDoRungNghich,
            this.colTiengOnThuan,
            this.colTiengOnNghich,
            this.colAmSacThuan,
            this.colAmSacNghich,
            this.colHuongQuay,
            this.colXuatDacBiet});
			this.grvData.Location = new System.Drawing.Point(2, 41);
			this.grvData.Name = "grvData";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.grvData.Size = new System.Drawing.Size(1276, 612);
			this.grvData.TabIndex = 40;
			// 
			// colsttt
			// 
			this.colsttt.DataPropertyName = "sttt";
			this.colsttt.HeaderText = "Số thứ tự";
			this.colsttt.Name = "colsttt";
			this.colsttt.Width = 50;
			// 
			// colDateLR
			// 
			this.colDateLR.DataPropertyName = "DateLR";
			this.colDateLR.HeaderText = "Thời gian\r\n";
			this.colDateLR.Name = "colDateLR";
			this.colDateLR.Width = 150;
			// 
			// colSTT
			// 
			this.colSTT.DataPropertyName = "STT";
			this.colSTT.HeaderText = "STT Sản phẩm\r\n";
			this.colSTT.Name = "colSTT";
			// 
			// colOrderCode
			// 
			this.colOrderCode.DataPropertyName = "OrderCode";
			this.colOrderCode.HeaderText = "Order\r\n";
			this.colOrderCode.Name = "colOrderCode";
			this.colOrderCode.Width = 120;
			// 
			// colPID
			// 
			this.colPID.DataPropertyName = "PID";
			this.colPID.HeaderText = "PID";
			this.colPID.Name = "colPID";
			// 
			// colQRCode
			// 
			this.colQRCode.DataPropertyName = "QRCode";
			this.colQRCode.HeaderText = "QRCode";
			this.colQRCode.Name = "colQRCode";
			this.colQRCode.Width = 150;
			// 
			// colNguoiVanHanh
			// 
			this.colNguoiVanHanh.DataPropertyName = "NguoiVanHanh";
			this.colNguoiVanHanh.HeaderText = "Người KT Vận hành\r\n";
			this.colNguoiVanHanh.Name = "colNguoiVanHanh";
			this.colNguoiVanHanh.Width = 120;
			// 
			// colMotaSanPham
			// 
			this.colMotaSanPham.DataPropertyName = "MotaSanPham";
			this.colMotaSanPham.HeaderText = "Mô tả sản phẩm";
			this.colMotaSanPham.Name = "colMotaSanPham";
			this.colMotaSanPham.Width = 200;
			// 
			// colGiamToc
			// 
			this.colGiamToc.DataPropertyName = "GiamToc";
			this.colGiamToc.HeaderText = "Giảm tốc";
			this.colGiamToc.Name = "colGiamToc";
			// 
			// colDienApTieuChuan
			// 
			this.colDienApTieuChuan.DataPropertyName = "DienApTieuChuan";
			this.colDienApTieuChuan.HeaderText = "Điện áp tiêu chuẩn";
			this.colDienApTieuChuan.Name = "colDienApTieuChuan";
			// 
			// colTanSoTieuChuan
			// 
			this.colTanSoTieuChuan.DataPropertyName = "TanSoTieuChuan";
			this.colTanSoTieuChuan.HeaderText = "Tần số tiêu chuẩn";
			this.colTanSoTieuChuan.Name = "colTanSoTieuChuan";
			// 
			// colGiaTriVongQuayChuan
			// 
			this.colGiaTriVongQuayChuan.DataPropertyName = "GiaTriVongQuayChuan";
			this.colGiaTriVongQuayChuan.HeaderText = "Giá trị vòng quay chuẩn";
			this.colGiaTriVongQuayChuan.Name = "colGiaTriVongQuayChuan";
			// 
			// colGiaTriDongDienChuan
			// 
			this.colGiaTriDongDienChuan.DataPropertyName = "GiaTriDongDienChuan";
			this.colGiaTriDongDienChuan.HeaderText = "Giá trị dòng điện chuẩn";
			this.colGiaTriDongDienChuan.Name = "colGiaTriDongDienChuan";
			// 
			// colGiaTriNhapLucChuan
			// 
			this.colGiaTriNhapLucChuan.DataPropertyName = "GiaTriNhapLucChuan";
			this.colGiaTriNhapLucChuan.HeaderText = "Giá trị nhập lực chuẩn";
			this.colGiaTriNhapLucChuan.Name = "colGiaTriNhapLucChuan";
			// 
			// colGiaTriDoRungChuan
			// 
			this.colGiaTriDoRungChuan.DataPropertyName = "GiaTriDoRungChuan";
			this.colGiaTriDoRungChuan.HeaderText = "Giá trị độ rung chuẩn";
			this.colGiaTriDoRungChuan.Name = "colGiaTriDoRungChuan";
			// 
			// colGiaTriTiengOnChuan
			// 
			this.colGiaTriTiengOnChuan.DataPropertyName = "GiaTriTiengOnChuan";
			this.colGiaTriTiengOnChuan.HeaderText = "Giá trị tiếng ồn chuẩn";
			this.colGiaTriTiengOnChuan.Name = "colGiaTriTiengOnChuan";
			// 
			// colDienApThucTe
			// 
			this.colDienApThucTe.DataPropertyName = "DienApThucTe";
			this.colDienApThucTe.HeaderText = "Điện áp thực tế";
			this.colDienApThucTe.Name = "colDienApThucTe";
			// 
			// colTanSoThucTe
			// 
			this.colTanSoThucTe.DataPropertyName = "TanSoThucTe";
			this.colTanSoThucTe.HeaderText = "Tần số thực tế";
			this.colTanSoThucTe.Name = "colTanSoThucTe";
			// 
			// colVongQuayThuan
			// 
			this.colVongQuayThuan.DataPropertyName = "VongQuayThuan";
			this.colVongQuayThuan.HeaderText = "Vòng quay thuận";
			this.colVongQuayThuan.Name = "colVongQuayThuan";
			// 
			// colVongQuayNghich
			// 
			this.colVongQuayNghich.DataPropertyName = "VongQuayNghich";
			this.colVongQuayNghich.HeaderText = "Vòng quay nghịch";
			this.colVongQuayNghich.Name = "colVongQuayNghich";
			// 
			// colDongDienThuan
			// 
			this.colDongDienThuan.DataPropertyName = "DongDienThuan";
			this.colDongDienThuan.HeaderText = "Dòng điện thuận";
			this.colDongDienThuan.Name = "colDongDienThuan";
			// 
			// colDongDienNghich
			// 
			this.colDongDienNghich.DataPropertyName = "DongDienNghich";
			this.colDongDienNghich.HeaderText = "Dòng điện nghịch";
			this.colDongDienNghich.Name = "colDongDienNghich";
			// 
			// colNhapLucThuan
			// 
			this.colNhapLucThuan.DataPropertyName = "NhapLucThuan";
			this.colNhapLucThuan.HeaderText = "Nhập lực thuận";
			this.colNhapLucThuan.Name = "colNhapLucThuan";
			// 
			// colNhapLucNghich
			// 
			this.colNhapLucNghich.DataPropertyName = "NhapLucNghich";
			this.colNhapLucNghich.HeaderText = "Nhập lực nghịch";
			this.colNhapLucNghich.Name = "colNhapLucNghich";
			// 
			// colDoRungThuan
			// 
			this.colDoRungThuan.DataPropertyName = "DoRungThuan";
			this.colDoRungThuan.HeaderText = "Độ rung thuận";
			this.colDoRungThuan.Name = "colDoRungThuan";
			// 
			// colDoRungNghich
			// 
			this.colDoRungNghich.DataPropertyName = "DoRungNghich";
			this.colDoRungNghich.HeaderText = "Độ rung nghịch";
			this.colDoRungNghich.Name = "colDoRungNghich";
			// 
			// colTiengOnThuan
			// 
			this.colTiengOnThuan.DataPropertyName = "TiengOnThuan";
			this.colTiengOnThuan.HeaderText = "Tiếng ồn thuận";
			this.colTiengOnThuan.Name = "colTiengOnThuan";
			// 
			// colTiengOnNghich
			// 
			this.colTiengOnNghich.DataPropertyName = "TiengOnNghich";
			this.colTiengOnNghich.HeaderText = "Tiếng ồn nghịch";
			this.colTiengOnNghich.Name = "colTiengOnNghich";
			// 
			// colAmSacThuan
			// 
			this.colAmSacThuan.DataPropertyName = "AmSacThuan";
			this.colAmSacThuan.HeaderText = "Âm sắc thuận";
			this.colAmSacThuan.Name = "colAmSacThuan";
			// 
			// colAmSacNghich
			// 
			this.colAmSacNghich.DataPropertyName = "AmSacNghich";
			this.colAmSacNghich.HeaderText = "Âm sắc nghịch";
			this.colAmSacNghich.Name = "colAmSacNghich";
			// 
			// colHuongQuay
			// 
			this.colHuongQuay.DataPropertyName = "HuongQuay";
			this.colHuongQuay.HeaderText = "Hướng quay";
			this.colHuongQuay.Name = "colHuongQuay";
			// 
			// colXuatDacBiet
			// 
			this.colXuatDacBiet.DataPropertyName = "XuatDacBiet";
			this.colXuatDacBiet.HeaderText = "Vị trí xuất đặc biệt";
			this.colXuatDacBiet.Name = "colXuatDacBiet";
			this.colXuatDacBiet.Visible = false;
			// 
			// frmLogDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1279, 653);
			this.Controls.Add(this.grvData);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtTextFilter);
			this.Controls.Add(this.btnFindDate);
			this.Controls.Add(this.dtpFrom);
			this.Controls.Add(this.dtpTo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLogDetail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Log Data";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.DateTimePicker dtpTo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTextFilter;
		private System.Windows.Forms.Button btnFindDate;
		private System.Windows.Forms.DataGridView grvData;
		private System.Windows.Forms.DataGridViewTextBoxColumn colsttt;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDateLR;
		private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
		private System.Windows.Forms.DataGridViewTextBoxColumn colOrderCode;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPID;
		private System.Windows.Forms.DataGridViewTextBoxColumn colQRCode;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNguoiVanHanh;
		private System.Windows.Forms.DataGridViewTextBoxColumn colMotaSanPham;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGiamToc;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDienApTieuChuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTanSoTieuChuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTriVongQuayChuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTriDongDienChuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTriNhapLucChuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTriDoRungChuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colGiaTriTiengOnChuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDienApThucTe;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTanSoThucTe;
		private System.Windows.Forms.DataGridViewTextBoxColumn colVongQuayThuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colVongQuayNghich;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDongDienThuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDongDienNghich;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNhapLucThuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colNhapLucNghich;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDoRungThuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDoRungNghich;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTiengOnThuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colTiengOnNghich;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAmSacThuan;
		private System.Windows.Forms.DataGridViewTextBoxColumn colAmSacNghich;
		private System.Windows.Forms.DataGridViewTextBoxColumn colHuongQuay;
		private System.Windows.Forms.DataGridViewTextBoxColumn colXuatDacBiet;
	}
}