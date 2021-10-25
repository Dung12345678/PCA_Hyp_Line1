namespace SHIV_PhongCachAm
{
    partial class frmProductCheckHistoryDetailPCA
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductCheckHistoryDetailPCA));
			this.grdData = new DevExpress.XtraGrid.GridControl();
			this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colDateLR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOrderCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colQRCode = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNguoiVanHanh = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMotaSanPham = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGiamToc = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDienApTieuChuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTanSoTieuChuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGiaTriVongQuayChuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGiaTriDongDienChuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGiaTriNhapLucChuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGiaTriDoRungChuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGiaTriTiengOnChuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDienApThucTe = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTanSoThucTe = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVongQuayThuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVongQuayNghich = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDongDienThuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDongDienNghich = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNhapLucThuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNhapLucNghich = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDoRungThuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDoRungNghich = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTiengOnThuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTiengOnNghich = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmSacThuan = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAmSacNghich = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHuongQuay = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colXuatDacBiet = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
			this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
			this.dtpTo = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnFindDate = new System.Windows.Forms.Button();
			this.txtTextFilter = new System.Windows.Forms.TextBox();
			this.dtpFrom = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
			this.SuspendLayout();
			// 
			// grdData
			// 
			this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grdData.Location = new System.Drawing.Point(4, 42);
			this.grdData.MainView = this.grvData;
			this.grdData.Name = "grdData";
			this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemMemoEdit2});
			this.grdData.Size = new System.Drawing.Size(872, 534);
			this.grdData.TabIndex = 17;
			this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
			// 
			// grvData
			// 
			this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
			this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
			this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
			this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
			this.grvData.ColumnPanelRowHeight = 40;
			this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
			this.grvData.GridControl = this.grdData;
			this.grvData.HorzScrollStep = 5;
			this.grvData.Name = "grvData";
			this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
			this.grvData.OptionsCustomization.AllowRowSizing = true;
			this.grvData.OptionsFind.AlwaysVisible = true;
			this.grvData.OptionsFind.ShowCloseButton = false;
			this.grvData.OptionsSelection.MultiSelect = true;
			this.grvData.OptionsView.ColumnAutoWidth = false;
			this.grvData.OptionsView.RowAutoHeight = true;
			this.grvData.OptionsView.ShowAutoFilterRow = true;
			this.grvData.OptionsView.ShowFooter = true;
			this.grvData.OptionsView.ShowGroupPanel = false;
			// 
			// colDateLR
			// 
			this.colDateLR.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDateLR.AppearanceCell.Options.UseFont = true;
			this.colDateLR.AppearanceCell.Options.UseTextOptions = true;
			this.colDateLR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDateLR.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDateLR.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDateLR.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDateLR.AppearanceHeader.Options.UseFont = true;
			this.colDateLR.AppearanceHeader.Options.UseTextOptions = true;
			this.colDateLR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDateLR.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDateLR.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDateLR.Caption = "Creat Date";
			this.colDateLR.DisplayFormat.FormatString = "dd/MM/yyyyy HH:MM:ss";
			this.colDateLR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colDateLR.FieldName = "DateLR";
			this.colDateLR.Name = "colDateLR";
			this.colDateLR.OptionsColumn.AllowEdit = false;
			this.colDateLR.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
			this.colDateLR.Visible = true;
			this.colDateLR.VisibleIndex = 0;
			// 
			// colSTT
			// 
			this.colSTT.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colSTT.AppearanceCell.Options.UseFont = true;
			this.colSTT.AppearanceCell.Options.UseTextOptions = true;
			this.colSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colSTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colSTT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colSTT.AppearanceHeader.Options.UseFont = true;
			this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
			this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colSTT.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colSTT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colSTT.Caption = "STT";
			this.colSTT.FieldName = "STT";
			this.colSTT.Name = "colSTT";
			this.colSTT.OptionsColumn.AllowEdit = false;
			this.colSTT.Visible = true;
			this.colSTT.VisibleIndex = 1;
			this.colSTT.Width = 59;
			// 
			// colOrderCode
			// 
			this.colOrderCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colOrderCode.AppearanceCell.Options.UseFont = true;
			this.colOrderCode.AppearanceCell.Options.UseTextOptions = true;
			this.colOrderCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colOrderCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colOrderCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colOrderCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colOrderCode.AppearanceHeader.Options.UseFont = true;
			this.colOrderCode.AppearanceHeader.Options.UseTextOptions = true;
			this.colOrderCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colOrderCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colOrderCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colOrderCode.Caption = "Order Code";
			this.colOrderCode.FieldName = "OrderCode";
			this.colOrderCode.Name = "colOrderCode";
			this.colOrderCode.OptionsColumn.AllowEdit = false;
			this.colOrderCode.Visible = true;
			this.colOrderCode.VisibleIndex = 2;
			this.colOrderCode.Width = 89;
			// 
			// colPID
			// 
			this.colPID.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colPID.AppearanceCell.Options.UseFont = true;
			this.colPID.AppearanceCell.Options.UseTextOptions = true;
			this.colPID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colPID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colPID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colPID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colPID.AppearanceHeader.Options.UseFont = true;
			this.colPID.AppearanceHeader.Options.UseTextOptions = true;
			this.colPID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colPID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colPID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colPID.Caption = "PID";
			this.colPID.FieldName = "PID";
			this.colPID.Name = "colPID";
			this.colPID.OptionsColumn.AllowEdit = false;
			this.colPID.Visible = true;
			this.colPID.VisibleIndex = 3;
			this.colPID.Width = 107;
			// 
			// colQRCode
			// 
			this.colQRCode.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colQRCode.AppearanceCell.Options.UseFont = true;
			this.colQRCode.AppearanceCell.Options.UseTextOptions = true;
			this.colQRCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colQRCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colQRCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colQRCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colQRCode.AppearanceHeader.Options.UseFont = true;
			this.colQRCode.AppearanceHeader.Options.UseTextOptions = true;
			this.colQRCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colQRCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colQRCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colQRCode.Caption = "QRCode";
			this.colQRCode.FieldName = "QRCode";
			this.colQRCode.Name = "colQRCode";
			this.colQRCode.OptionsColumn.AllowEdit = false;
			this.colQRCode.Visible = true;
			this.colQRCode.VisibleIndex = 4;
			this.colQRCode.Width = 103;
			// 
			// colNguoiVanHanh
			// 
			this.colNguoiVanHanh.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colNguoiVanHanh.AppearanceCell.Options.UseFont = true;
			this.colNguoiVanHanh.AppearanceCell.Options.UseTextOptions = true;
			this.colNguoiVanHanh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNguoiVanHanh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNguoiVanHanh.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNguoiVanHanh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colNguoiVanHanh.AppearanceHeader.Options.UseFont = true;
			this.colNguoiVanHanh.AppearanceHeader.Options.UseTextOptions = true;
			this.colNguoiVanHanh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNguoiVanHanh.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNguoiVanHanh.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNguoiVanHanh.Caption = "Người Vận Hành";
			this.colNguoiVanHanh.FieldName = "NguoiVanHanh";
			this.colNguoiVanHanh.Name = "colNguoiVanHanh";
			this.colNguoiVanHanh.OptionsColumn.AllowEdit = false;
			this.colNguoiVanHanh.Visible = true;
			this.colNguoiVanHanh.VisibleIndex = 5;
			// 
			// colMotaSanPham
			// 
			this.colMotaSanPham.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colMotaSanPham.AppearanceCell.Options.UseFont = true;
			this.colMotaSanPham.AppearanceCell.Options.UseTextOptions = true;
			this.colMotaSanPham.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colMotaSanPham.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colMotaSanPham.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colMotaSanPham.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colMotaSanPham.AppearanceHeader.Options.UseFont = true;
			this.colMotaSanPham.AppearanceHeader.Options.UseTextOptions = true;
			this.colMotaSanPham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colMotaSanPham.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colMotaSanPham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colMotaSanPham.Caption = "Mô tả sản phẩm";
			this.colMotaSanPham.FieldName = "MotaSanPham";
			this.colMotaSanPham.Name = "colMotaSanPham";
			this.colMotaSanPham.OptionsColumn.AllowEdit = false;
			this.colMotaSanPham.Visible = true;
			this.colMotaSanPham.VisibleIndex = 6;
			// 
			// colGiamToc
			// 
			this.colGiamToc.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiamToc.AppearanceCell.Options.UseFont = true;
			this.colGiamToc.AppearanceCell.Options.UseTextOptions = true;
			this.colGiamToc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiamToc.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiamToc.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiamToc.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiamToc.AppearanceHeader.Options.UseFont = true;
			this.colGiamToc.AppearanceHeader.Options.UseTextOptions = true;
			this.colGiamToc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiamToc.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiamToc.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiamToc.Caption = "Giảm tốc";
			this.colGiamToc.FieldName = "GiamToc";
			this.colGiamToc.Name = "colGiamToc";
			this.colGiamToc.OptionsColumn.AllowEdit = false;
			this.colGiamToc.Visible = true;
			this.colGiamToc.VisibleIndex = 7;
			// 
			// colDienApTieuChuan
			// 
			this.colDienApTieuChuan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDienApTieuChuan.AppearanceCell.Options.UseFont = true;
			this.colDienApTieuChuan.AppearanceCell.Options.UseTextOptions = true;
			this.colDienApTieuChuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDienApTieuChuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDienApTieuChuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDienApTieuChuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDienApTieuChuan.AppearanceHeader.Options.UseFont = true;
			this.colDienApTieuChuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colDienApTieuChuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDienApTieuChuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDienApTieuChuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDienApTieuChuan.Caption = "Điện áp tiêu chuẩn";
			this.colDienApTieuChuan.FieldName = "DienApTieuChuan";
			this.colDienApTieuChuan.Name = "colDienApTieuChuan";
			this.colDienApTieuChuan.OptionsColumn.AllowEdit = false;
			this.colDienApTieuChuan.Visible = true;
			this.colDienApTieuChuan.VisibleIndex = 8;
			// 
			// colTanSoTieuChuan
			// 
			this.colTanSoTieuChuan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colTanSoTieuChuan.AppearanceCell.Options.UseFont = true;
			this.colTanSoTieuChuan.AppearanceCell.Options.UseTextOptions = true;
			this.colTanSoTieuChuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTanSoTieuChuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTanSoTieuChuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTanSoTieuChuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colTanSoTieuChuan.AppearanceHeader.Options.UseFont = true;
			this.colTanSoTieuChuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colTanSoTieuChuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTanSoTieuChuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTanSoTieuChuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTanSoTieuChuan.Caption = "Tần số tiêu chuẩn";
			this.colTanSoTieuChuan.FieldName = "TanSoTieuChuan";
			this.colTanSoTieuChuan.Name = "colTanSoTieuChuan";
			this.colTanSoTieuChuan.OptionsColumn.AllowEdit = false;
			this.colTanSoTieuChuan.Visible = true;
			this.colTanSoTieuChuan.VisibleIndex = 9;
			// 
			// colGiaTriVongQuayChuan
			// 
			this.colGiaTriVongQuayChuan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriVongQuayChuan.AppearanceCell.Options.UseFont = true;
			this.colGiaTriVongQuayChuan.AppearanceCell.Options.UseTextOptions = true;
			this.colGiaTriVongQuayChuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriVongQuayChuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriVongQuayChuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriVongQuayChuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriVongQuayChuan.AppearanceHeader.Options.UseFont = true;
			this.colGiaTriVongQuayChuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colGiaTriVongQuayChuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriVongQuayChuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriVongQuayChuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriVongQuayChuan.Caption = "Giá trị vòng quay chuẩn";
			this.colGiaTriVongQuayChuan.FieldName = "GiaTriVongQuayChuan";
			this.colGiaTriVongQuayChuan.Name = "colGiaTriVongQuayChuan";
			this.colGiaTriVongQuayChuan.OptionsColumn.AllowEdit = false;
			this.colGiaTriVongQuayChuan.Visible = true;
			this.colGiaTriVongQuayChuan.VisibleIndex = 10;
			// 
			// colGiaTriDongDienChuan
			// 
			this.colGiaTriDongDienChuan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriDongDienChuan.AppearanceCell.Options.UseFont = true;
			this.colGiaTriDongDienChuan.AppearanceCell.Options.UseTextOptions = true;
			this.colGiaTriDongDienChuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriDongDienChuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriDongDienChuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriDongDienChuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriDongDienChuan.AppearanceHeader.Options.UseFont = true;
			this.colGiaTriDongDienChuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colGiaTriDongDienChuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriDongDienChuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriDongDienChuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriDongDienChuan.Caption = "Giá trị dòng điện chuẩn";
			this.colGiaTriDongDienChuan.FieldName = "GiaTriDongDienChuan";
			this.colGiaTriDongDienChuan.Name = "colGiaTriDongDienChuan";
			this.colGiaTriDongDienChuan.OptionsColumn.AllowEdit = false;
			this.colGiaTriDongDienChuan.Visible = true;
			this.colGiaTriDongDienChuan.VisibleIndex = 11;
			// 
			// colGiaTriNhapLucChuan
			// 
			this.colGiaTriNhapLucChuan.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriNhapLucChuan.AppearanceCell.Options.UseFont = true;
			this.colGiaTriNhapLucChuan.AppearanceCell.Options.UseTextOptions = true;
			this.colGiaTriNhapLucChuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriNhapLucChuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriNhapLucChuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriNhapLucChuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriNhapLucChuan.AppearanceHeader.Options.UseFont = true;
			this.colGiaTriNhapLucChuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colGiaTriNhapLucChuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriNhapLucChuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriNhapLucChuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriNhapLucChuan.Caption = "Giá trị nhập lực chuẩn";
			this.colGiaTriNhapLucChuan.FieldName = "GiaTriNhapLucChuan";
			this.colGiaTriNhapLucChuan.Name = "colGiaTriNhapLucChuan";
			this.colGiaTriNhapLucChuan.OptionsColumn.AllowEdit = false;
			this.colGiaTriNhapLucChuan.Visible = true;
			this.colGiaTriNhapLucChuan.VisibleIndex = 12;
			// 
			// colGiaTriDoRungChuan
			// 
			this.colGiaTriDoRungChuan.AppearanceCell.Options.UseTextOptions = true;
			this.colGiaTriDoRungChuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriDoRungChuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriDoRungChuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriDoRungChuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriDoRungChuan.AppearanceHeader.Options.UseFont = true;
			this.colGiaTriDoRungChuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colGiaTriDoRungChuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriDoRungChuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriDoRungChuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriDoRungChuan.Caption = "Giá trị độ rung chuẩn";
			this.colGiaTriDoRungChuan.FieldName = "GiaTriDoRungChuan";
			this.colGiaTriDoRungChuan.Name = "colGiaTriDoRungChuan";
			this.colGiaTriDoRungChuan.OptionsColumn.AllowEdit = false;
			this.colGiaTriDoRungChuan.Visible = true;
			this.colGiaTriDoRungChuan.VisibleIndex = 13;
			// 
			// colGiaTriTiengOnChuan
			// 
			this.colGiaTriTiengOnChuan.AppearanceCell.Options.UseTextOptions = true;
			this.colGiaTriTiengOnChuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriTiengOnChuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriTiengOnChuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriTiengOnChuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colGiaTriTiengOnChuan.AppearanceHeader.Options.UseFont = true;
			this.colGiaTriTiengOnChuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colGiaTriTiengOnChuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colGiaTriTiengOnChuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colGiaTriTiengOnChuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colGiaTriTiengOnChuan.Caption = "Giá trị tiếng ồn chuẩn";
			this.colGiaTriTiengOnChuan.FieldName = "GiaTriTiengOnChuan";
			this.colGiaTriTiengOnChuan.Name = "colGiaTriTiengOnChuan";
			this.colGiaTriTiengOnChuan.OptionsColumn.AllowEdit = false;
			this.colGiaTriTiengOnChuan.Visible = true;
			this.colGiaTriTiengOnChuan.VisibleIndex = 14;
			// 
			// colDienApThucTe
			// 
			this.colDienApThucTe.AppearanceCell.Options.UseTextOptions = true;
			this.colDienApThucTe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDienApThucTe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDienApThucTe.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDienApThucTe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDienApThucTe.AppearanceHeader.Options.UseFont = true;
			this.colDienApThucTe.AppearanceHeader.Options.UseTextOptions = true;
			this.colDienApThucTe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDienApThucTe.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDienApThucTe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDienApThucTe.Caption = "Điện áp thực tế";
			this.colDienApThucTe.FieldName = "DienApThucTe";
			this.colDienApThucTe.Name = "colDienApThucTe";
			this.colDienApThucTe.OptionsColumn.AllowEdit = false;
			this.colDienApThucTe.Visible = true;
			this.colDienApThucTe.VisibleIndex = 15;
			// 
			// colTanSoThucTe
			// 
			this.colTanSoThucTe.AppearanceCell.Options.UseTextOptions = true;
			this.colTanSoThucTe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTanSoThucTe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTanSoThucTe.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTanSoThucTe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colTanSoThucTe.AppearanceHeader.Options.UseFont = true;
			this.colTanSoThucTe.AppearanceHeader.Options.UseTextOptions = true;
			this.colTanSoThucTe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTanSoThucTe.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTanSoThucTe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTanSoThucTe.Caption = "Tần số thực tế";
			this.colTanSoThucTe.FieldName = "TanSoThucTe";
			this.colTanSoThucTe.Name = "colTanSoThucTe";
			this.colTanSoThucTe.OptionsColumn.AllowEdit = false;
			this.colTanSoThucTe.Visible = true;
			this.colTanSoThucTe.VisibleIndex = 16;
			// 
			// colVongQuayThuan
			// 
			this.colVongQuayThuan.AppearanceCell.Options.UseTextOptions = true;
			this.colVongQuayThuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colVongQuayThuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colVongQuayThuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colVongQuayThuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colVongQuayThuan.AppearanceHeader.Options.UseFont = true;
			this.colVongQuayThuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colVongQuayThuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colVongQuayThuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colVongQuayThuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colVongQuayThuan.Caption = "Vòng quay thuận";
			this.colVongQuayThuan.FieldName = "VongQuayThuan";
			this.colVongQuayThuan.Name = "colVongQuayThuan";
			this.colVongQuayThuan.OptionsColumn.AllowEdit = false;
			this.colVongQuayThuan.Visible = true;
			this.colVongQuayThuan.VisibleIndex = 17;
			// 
			// colVongQuayNghich
			// 
			this.colVongQuayNghich.AppearanceCell.Options.UseTextOptions = true;
			this.colVongQuayNghich.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colVongQuayNghich.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colVongQuayNghich.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colVongQuayNghich.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colVongQuayNghich.AppearanceHeader.Options.UseFont = true;
			this.colVongQuayNghich.AppearanceHeader.Options.UseTextOptions = true;
			this.colVongQuayNghich.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colVongQuayNghich.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colVongQuayNghich.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colVongQuayNghich.Caption = "Vòng quay nghịch";
			this.colVongQuayNghich.FieldName = "VongQuayNghich";
			this.colVongQuayNghich.Name = "colVongQuayNghich";
			this.colVongQuayNghich.OptionsColumn.AllowEdit = false;
			this.colVongQuayNghich.Visible = true;
			this.colVongQuayNghich.VisibleIndex = 18;
			// 
			// colDongDienThuan
			// 
			this.colDongDienThuan.AppearanceCell.Options.UseTextOptions = true;
			this.colDongDienThuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDongDienThuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDongDienThuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDongDienThuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDongDienThuan.AppearanceHeader.Options.UseFont = true;
			this.colDongDienThuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colDongDienThuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDongDienThuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDongDienThuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDongDienThuan.Caption = "Dòng điện thuận";
			this.colDongDienThuan.FieldName = "DongDienThuan";
			this.colDongDienThuan.Name = "colDongDienThuan";
			this.colDongDienThuan.OptionsColumn.AllowEdit = false;
			this.colDongDienThuan.Visible = true;
			this.colDongDienThuan.VisibleIndex = 19;
			// 
			// colDongDienNghich
			// 
			this.colDongDienNghich.AppearanceCell.Options.UseTextOptions = true;
			this.colDongDienNghich.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDongDienNghich.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDongDienNghich.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDongDienNghich.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDongDienNghich.AppearanceHeader.Options.UseFont = true;
			this.colDongDienNghich.AppearanceHeader.Options.UseTextOptions = true;
			this.colDongDienNghich.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDongDienNghich.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDongDienNghich.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDongDienNghich.Caption = "Dòng điện nghịch";
			this.colDongDienNghich.FieldName = "DongDienNghich";
			this.colDongDienNghich.Name = "colDongDienNghich";
			this.colDongDienNghich.OptionsColumn.AllowEdit = false;
			this.colDongDienNghich.Visible = true;
			this.colDongDienNghich.VisibleIndex = 20;
			// 
			// colNhapLucThuan
			// 
			this.colNhapLucThuan.AppearanceCell.Options.UseTextOptions = true;
			this.colNhapLucThuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNhapLucThuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNhapLucThuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNhapLucThuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colNhapLucThuan.AppearanceHeader.Options.UseFont = true;
			this.colNhapLucThuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colNhapLucThuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNhapLucThuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNhapLucThuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNhapLucThuan.Caption = "Nhập lực thuận";
			this.colNhapLucThuan.FieldName = "NhapLucThuan";
			this.colNhapLucThuan.Name = "colNhapLucThuan";
			this.colNhapLucThuan.OptionsColumn.AllowEdit = false;
			this.colNhapLucThuan.Visible = true;
			this.colNhapLucThuan.VisibleIndex = 21;
			// 
			// colNhapLucNghich
			// 
			this.colNhapLucNghich.AppearanceCell.Options.UseTextOptions = true;
			this.colNhapLucNghich.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNhapLucNghich.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNhapLucNghich.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNhapLucNghich.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colNhapLucNghich.AppearanceHeader.Options.UseFont = true;
			this.colNhapLucNghich.AppearanceHeader.Options.UseTextOptions = true;
			this.colNhapLucNghich.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colNhapLucNghich.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colNhapLucNghich.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colNhapLucNghich.Caption = "Nhập lực nghịch";
			this.colNhapLucNghich.FieldName = "NhapLucNghich";
			this.colNhapLucNghich.Name = "colNhapLucNghich";
			this.colNhapLucNghich.OptionsColumn.AllowEdit = false;
			this.colNhapLucNghich.Visible = true;
			this.colNhapLucNghich.VisibleIndex = 22;
			// 
			// colDoRungThuan
			// 
			this.colDoRungThuan.AppearanceCell.Options.UseTextOptions = true;
			this.colDoRungThuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDoRungThuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDoRungThuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDoRungThuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDoRungThuan.AppearanceHeader.Options.UseFont = true;
			this.colDoRungThuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colDoRungThuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDoRungThuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDoRungThuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDoRungThuan.Caption = "Độ rung thuận";
			this.colDoRungThuan.FieldName = "DoRungThuan";
			this.colDoRungThuan.Name = "colDoRungThuan";
			this.colDoRungThuan.OptionsColumn.AllowEdit = false;
			this.colDoRungThuan.Visible = true;
			this.colDoRungThuan.VisibleIndex = 23;
			// 
			// colDoRungNghich
			// 
			this.colDoRungNghich.AppearanceCell.Options.UseTextOptions = true;
			this.colDoRungNghich.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDoRungNghich.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDoRungNghich.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDoRungNghich.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colDoRungNghich.AppearanceHeader.Options.UseFont = true;
			this.colDoRungNghich.AppearanceHeader.Options.UseTextOptions = true;
			this.colDoRungNghich.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colDoRungNghich.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colDoRungNghich.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colDoRungNghich.Caption = "Độ rung nghịch";
			this.colDoRungNghich.FieldName = "DoRungNghich";
			this.colDoRungNghich.Name = "colDoRungNghich";
			this.colDoRungNghich.OptionsColumn.AllowEdit = false;
			this.colDoRungNghich.Visible = true;
			this.colDoRungNghich.VisibleIndex = 24;
			// 
			// colTiengOnThuan
			// 
			this.colTiengOnThuan.AppearanceCell.Options.UseTextOptions = true;
			this.colTiengOnThuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTiengOnThuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTiengOnThuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTiengOnThuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colTiengOnThuan.AppearanceHeader.Options.UseFont = true;
			this.colTiengOnThuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colTiengOnThuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTiengOnThuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTiengOnThuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTiengOnThuan.Caption = "Tiếng ồn thuận";
			this.colTiengOnThuan.FieldName = "TiengOnThuan";
			this.colTiengOnThuan.Name = "colTiengOnThuan";
			this.colTiengOnThuan.OptionsColumn.AllowEdit = false;
			this.colTiengOnThuan.Visible = true;
			this.colTiengOnThuan.VisibleIndex = 25;
			// 
			// colTiengOnNghich
			// 
			this.colTiengOnNghich.AppearanceCell.Options.UseTextOptions = true;
			this.colTiengOnNghich.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTiengOnNghich.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTiengOnNghich.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTiengOnNghich.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colTiengOnNghich.AppearanceHeader.Options.UseFont = true;
			this.colTiengOnNghich.AppearanceHeader.Options.UseTextOptions = true;
			this.colTiengOnNghich.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colTiengOnNghich.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colTiengOnNghich.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colTiengOnNghich.Caption = "Tiếng ồn nghịch";
			this.colTiengOnNghich.FieldName = "TiengOnNghich";
			this.colTiengOnNghich.Name = "colTiengOnNghich";
			this.colTiengOnNghich.OptionsColumn.AllowEdit = false;
			this.colTiengOnNghich.Visible = true;
			this.colTiengOnNghich.VisibleIndex = 26;
			// 
			// colAmSacThuan
			// 
			this.colAmSacThuan.AppearanceCell.Options.UseTextOptions = true;
			this.colAmSacThuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colAmSacThuan.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colAmSacThuan.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colAmSacThuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colAmSacThuan.AppearanceHeader.Options.UseFont = true;
			this.colAmSacThuan.AppearanceHeader.Options.UseTextOptions = true;
			this.colAmSacThuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colAmSacThuan.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colAmSacThuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colAmSacThuan.Caption = "Âm sắc thuận";
			this.colAmSacThuan.FieldName = "AmSacThuan";
			this.colAmSacThuan.Name = "colAmSacThuan";
			this.colAmSacThuan.OptionsColumn.AllowEdit = false;
			this.colAmSacThuan.Visible = true;
			this.colAmSacThuan.VisibleIndex = 27;
			// 
			// colAmSacNghich
			// 
			this.colAmSacNghich.AppearanceCell.Options.UseTextOptions = true;
			this.colAmSacNghich.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colAmSacNghich.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colAmSacNghich.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colAmSacNghich.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colAmSacNghich.AppearanceHeader.Options.UseFont = true;
			this.colAmSacNghich.AppearanceHeader.Options.UseTextOptions = true;
			this.colAmSacNghich.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colAmSacNghich.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colAmSacNghich.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colAmSacNghich.Caption = "Âm sắc nghịch";
			this.colAmSacNghich.FieldName = "AmSacNghich";
			this.colAmSacNghich.Name = "colAmSacNghich";
			this.colAmSacNghich.OptionsColumn.AllowEdit = false;
			this.colAmSacNghich.Visible = true;
			this.colAmSacNghich.VisibleIndex = 28;
			// 
			// colHuongQuay
			// 
			this.colHuongQuay.AppearanceCell.Options.UseTextOptions = true;
			this.colHuongQuay.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colHuongQuay.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colHuongQuay.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colHuongQuay.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colHuongQuay.AppearanceHeader.Options.UseFont = true;
			this.colHuongQuay.AppearanceHeader.Options.UseTextOptions = true;
			this.colHuongQuay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colHuongQuay.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colHuongQuay.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colHuongQuay.Caption = "Hướng quay";
			this.colHuongQuay.FieldName = "HuongQuay";
			this.colHuongQuay.Name = "colHuongQuay";
			this.colHuongQuay.OptionsColumn.AllowEdit = false;
			this.colHuongQuay.Visible = true;
			this.colHuongQuay.VisibleIndex = 29;
			// 
			// colXuatDacBiet
			// 
			this.colXuatDacBiet.AppearanceCell.Options.UseTextOptions = true;
			this.colXuatDacBiet.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colXuatDacBiet.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colXuatDacBiet.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colXuatDacBiet.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.colXuatDacBiet.AppearanceHeader.Options.UseFont = true;
			this.colXuatDacBiet.AppearanceHeader.Options.UseTextOptions = true;
			this.colXuatDacBiet.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.colXuatDacBiet.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.colXuatDacBiet.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.colXuatDacBiet.Caption = "Vị trí xuất đặc biệt";
			this.colXuatDacBiet.FieldName = "XuatDacBiet";
			this.colXuatDacBiet.Name = "colXuatDacBiet";
			this.colXuatDacBiet.OptionsColumn.AllowEdit = false;
			this.colXuatDacBiet.Visible = true;
			this.colXuatDacBiet.VisibleIndex = 30;
			// 
			// repositoryItemCheckEdit1
			// 
			this.repositoryItemCheckEdit1.AutoHeight = false;
			this.repositoryItemCheckEdit1.Caption = "Check";
			this.repositoryItemCheckEdit1.DisplayValueChecked = "\"1\"";
			this.repositoryItemCheckEdit1.DisplayValueUnchecked = "\"0\"";
			this.repositoryItemCheckEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
			this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
			this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemMemoEdit1
			// 
			this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
			this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
			this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
			// 
			// repositoryItemCheckEdit2
			// 
			this.repositoryItemCheckEdit2.AutoHeight = false;
			this.repositoryItemCheckEdit2.Caption = "Check";
			this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
			this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
			// 
			// repositoryItemMemoEdit2
			// 
			this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
			// 
			// dtpTo
			// 
			this.dtpTo.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpTo.Location = new System.Drawing.Point(320, 10);
			this.dtpTo.Name = "dtpTo";
			this.dtpTo.Size = new System.Drawing.Size(142, 20);
			this.dtpTo.TabIndex = 29;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(251, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 28;
			this.label1.Text = "Đến ngày: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(12, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "Từ ngày: ";
			// 
			// btnFindDate
			// 
			this.btnFindDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFindDate.Location = new System.Drawing.Point(796, 9);
			this.btnFindDate.Name = "btnFindDate";
			this.btnFindDate.Size = new System.Drawing.Size(75, 23);
			this.btnFindDate.TabIndex = 30;
			this.btnFindDate.Text = "Tìm kiếm";
			this.btnFindDate.UseVisualStyleBackColor = true;
			this.btnFindDate.Click += new System.EventHandler(this.btnFindDate_Click);
			// 
			// txtTextFilter
			// 
			this.txtTextFilter.Location = new System.Drawing.Point(623, 10);
			this.txtTextFilter.Name = "txtTextFilter";
			this.txtTextFilter.Size = new System.Drawing.Size(156, 20);
			this.txtTextFilter.TabIndex = 31;
			// 
			// dtpFrom
			// 
			this.dtpFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss";
			this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFrom.Location = new System.Drawing.Point(77, 10);
			this.dtpFrom.Name = "dtpFrom";
			this.dtpFrom.Size = new System.Drawing.Size(142, 20);
			this.dtpFrom.TabIndex = 32;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(502, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 13);
			this.label2.TabIndex = 35;
			this.label2.Text = "Order Code or PID";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmProductCheckHistoryDetailPCA
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(880, 580);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtpFrom);
			this.Controls.Add(this.txtTextFilter);
			this.Controls.Add(this.btnFindDate);
			this.Controls.Add(this.dtpTo);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.grdData);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frmProductCheckHistoryDetailPCA";
			this.Text = "SỐ LƯỢNG SẢN PHẨM ";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmProductCheckHistoryDetailPCA_Load);
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFindDate;
		private System.Windows.Forms.TextBox txtTextFilter;
		private DevExpress.XtraGrid.Columns.GridColumn colDateLR;
		private DevExpress.XtraGrid.Columns.GridColumn colSTT;
		private DevExpress.XtraGrid.Columns.GridColumn colOrderCode;
		private DevExpress.XtraGrid.Columns.GridColumn colPID;
		private DevExpress.XtraGrid.Columns.GridColumn colQRCode;
		private DevExpress.XtraGrid.Columns.GridColumn colNguoiVanHanh;
		private DevExpress.XtraGrid.Columns.GridColumn colMotaSanPham;
		private DevExpress.XtraGrid.Columns.GridColumn colGiamToc;
		private DevExpress.XtraGrid.Columns.GridColumn colDienApTieuChuan;
		private DevExpress.XtraGrid.Columns.GridColumn colTanSoTieuChuan;
		private DevExpress.XtraGrid.Columns.GridColumn colGiaTriVongQuayChuan;
		private DevExpress.XtraGrid.Columns.GridColumn colGiaTriDongDienChuan;
		private DevExpress.XtraGrid.Columns.GridColumn colGiaTriNhapLucChuan;
		private DevExpress.XtraGrid.Columns.GridColumn colGiaTriDoRungChuan;
		private DevExpress.XtraGrid.Columns.GridColumn colGiaTriTiengOnChuan;
		private DevExpress.XtraGrid.Columns.GridColumn colDienApThucTe;
		private DevExpress.XtraGrid.Columns.GridColumn colTanSoThucTe;
		private DevExpress.XtraGrid.Columns.GridColumn colVongQuayThuan;
		private DevExpress.XtraGrid.Columns.GridColumn colVongQuayNghich;
		private DevExpress.XtraGrid.Columns.GridColumn colDongDienThuan;
		private DevExpress.XtraGrid.Columns.GridColumn colDongDienNghich;
		private DevExpress.XtraGrid.Columns.GridColumn colNhapLucThuan;
		private DevExpress.XtraGrid.Columns.GridColumn colNhapLucNghich;
		private DevExpress.XtraGrid.Columns.GridColumn colDoRungThuan;
		private DevExpress.XtraGrid.Columns.GridColumn colDoRungNghich;
		private DevExpress.XtraGrid.Columns.GridColumn colTiengOnThuan;
		private DevExpress.XtraGrid.Columns.GridColumn colTiengOnNghich;
		private DevExpress.XtraGrid.Columns.GridColumn colAmSacThuan;
		private DevExpress.XtraGrid.Columns.GridColumn colAmSacNghich;
		private DevExpress.XtraGrid.Columns.GridColumn colHuongQuay;
		private DevExpress.XtraGrid.Columns.GridColumn colXuatDacBiet;
		private System.Windows.Forms.DateTimePicker dtpFrom;
		private System.Windows.Forms.Label label2;
	}
}