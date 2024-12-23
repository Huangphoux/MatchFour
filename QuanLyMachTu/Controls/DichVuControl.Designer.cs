﻿namespace QuanLyMachTu
{
    partial class DichVuControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DichVuControl));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panel_TopPanel = new Panel();
            pageButton_TinhTrang = new Custom.PageButton();
            pageButton_DV = new Custom.PageButton();
            panel_Toolbar = new Panel();
            pageButton_Filter = new Custom.PageButton();
            pageButton_Remove = new Custom.PageButton();
            pageButton_Upload = new Custom.PageButton();
            customDataGridView = new Custom.CustomDataGridView();
            panel_DV_Upload = new Panel();
            button_DVUpload_Reset = new Button();
            button_DV_OK = new Button();
            textBox_DV_MoTa = new TextBox();
            label_DV_MoTa = new Label();
            textBox_DV_TenDV = new TextBox();
            label_DV_TenDV = new Label();
            textBox_DV_ChiPhi = new TextBox();
            label_DV_ChiPhi = new Label();
            textBox_DV_MaDV = new TextBox();
            label_DV_MaDV = new Label();
            label_DV_Upload = new Label();
            panel_DV_Filter = new Panel();
            button_DVFilters_Reset = new Button();
            comboBox_DV_Filter_Operation = new ComboBox();
            button_DV_OK_Filter = new Button();
            textBox_DV_TenDV_Filter = new TextBox();
            label2 = new Label();
            textBox_DV_ChiPhi_Filter = new TextBox();
            label3 = new Label();
            textBox_DV_MaDV_Filter = new TextBox();
            label4 = new Label();
            label5 = new Label();
            panel_TinhTrang_Filter = new Panel();
            button_TTFilters_Reset = new Button();
            comboBox_TinhTrang_Filter = new ComboBox();
            label10 = new Label();
            textBox_TT_MaPK_Filter = new TextBox();
            label9 = new Label();
            button_TT_OK = new Button();
            textBox_TT_TenDV_Filter = new TextBox();
            label1 = new Label();
            textBox_TT_MaDV_Filter = new TextBox();
            label7 = new Label();
            label8 = new Label();
            panel_TinhTrang_Upload = new Panel();
            button_TTUpload_Reset = new Button();
            comboBox_TinhTrang_Upload = new ComboBox();
            label11 = new Label();
            textBox_TT_MaPK_Upload = new TextBox();
            label13 = new Label();
            button_OK_Upload = new Button();
            textBox_TT_MaDV_Upload = new TextBox();
            label15 = new Label();
            label_TT_Upload = new Label();
            customPanel_DetailsControl = new Custom.CustomPanel();
            panel_TopPanel.SuspendLayout();
            panel_Toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customDataGridView).BeginInit();
            panel_DV_Upload.SuspendLayout();
            panel_DV_Filter.SuspendLayout();
            panel_TinhTrang_Filter.SuspendLayout();
            panel_TinhTrang_Upload.SuspendLayout();
            SuspendLayout();
            // 
            // panel_TopPanel
            // 
            panel_TopPanel.Controls.Add(pageButton_TinhTrang);
            panel_TopPanel.Controls.Add(pageButton_DV);
            panel_TopPanel.Dock = DockStyle.Top;
            panel_TopPanel.Location = new Point(0, 0);
            panel_TopPanel.Margin = new Padding(4);
            panel_TopPanel.Name = "panel_TopPanel";
            panel_TopPanel.Size = new Size(1590, 84);
            panel_TopPanel.TabIndex = 0;
            // 
            // pageButton_TinhTrang
            // 
            pageButton_TinhTrang.Anchor = AnchorStyles.None;
            pageButton_TinhTrang.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_TinhTrang.BorderColor = Color.PaleVioletRed;
            pageButton_TinhTrang.BorderRadius = 40;
            pageButton_TinhTrang.BorderSize = 0;
            pageButton_TinhTrang.CustomText = "Tình trạng";
            pageButton_TinhTrang.FlatAppearance.BorderSize = 0;
            pageButton_TinhTrang.FlatStyle = FlatStyle.Flat;
            pageButton_TinhTrang.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton_TinhTrang.ForeColor = Color.FromArgb(193, 193, 193);
            pageButton_TinhTrang.Icon = (Image)resources.GetObject("pageButton_TinhTrang.Icon");
            pageButton_TinhTrang.IconLocation = new Point(15, 13);
            pageButton_TinhTrang.IconSize = new Size(30, 30);
            pageButton_TinhTrang.Location = new Point(280, 12);
            pageButton_TinhTrang.Margin = new Padding(2);
            pageButton_TinhTrang.Name = "pageButton_TinhTrang";
            pageButton_TinhTrang.Size = new Size(250, 60);
            pageButton_TinhTrang.TabIndex = 11;
            pageButton_TinhTrang.TextLocation = new Point(64, 12);
            pageButton_TinhTrang.UseVisualStyleBackColor = false;
            pageButton_TinhTrang.Click += pageButton_TinhTrang_Click;
            // 
            // pageButton_DV
            // 
            pageButton_DV.Anchor = AnchorStyles.None;
            pageButton_DV.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_DV.BorderColor = Color.PaleVioletRed;
            pageButton_DV.BorderRadius = 40;
            pageButton_DV.BorderSize = 0;
            pageButton_DV.CustomText = "Dịch vụ";
            pageButton_DV.FlatAppearance.BorderSize = 0;
            pageButton_DV.FlatStyle = FlatStyle.Flat;
            pageButton_DV.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton_DV.ForeColor = Color.FromArgb(193, 193, 193);
            pageButton_DV.Icon = (Image)resources.GetObject("pageButton_DV.Icon");
            pageButton_DV.IconLocation = new Point(15, 13);
            pageButton_DV.IconSize = new Size(30, 30);
            pageButton_DV.Location = new Point(25, 12);
            pageButton_DV.Margin = new Padding(2);
            pageButton_DV.Name = "pageButton_DV";
            pageButton_DV.Size = new Size(250, 60);
            pageButton_DV.TabIndex = 10;
            pageButton_DV.TextLocation = new Point(64, 12);
            pageButton_DV.UseVisualStyleBackColor = false;
            pageButton_DV.Click += pageButton_DV_Click;
            // 
            // panel_Toolbar
            // 
            panel_Toolbar.Controls.Add(pageButton_Filter);
            panel_Toolbar.Controls.Add(pageButton_Remove);
            panel_Toolbar.Controls.Add(pageButton_Upload);
            panel_Toolbar.Location = new Point(0, 84);
            panel_Toolbar.Margin = new Padding(4);
            panel_Toolbar.Name = "panel_Toolbar";
            panel_Toolbar.Size = new Size(1174, 80);
            panel_Toolbar.TabIndex = 1;
            // 
            // pageButton_Filter
            // 
            pageButton_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pageButton_Filter.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_Filter.BorderColor = Color.PaleVioletRed;
            pageButton_Filter.BorderRadius = 20;
            pageButton_Filter.BorderSize = 0;
            pageButton_Filter.CustomText = null;
            pageButton_Filter.FlatAppearance.BorderSize = 0;
            pageButton_Filter.FlatStyle = FlatStyle.Flat;
            pageButton_Filter.ForeColor = Color.White;
            pageButton_Filter.Icon = (Image)resources.GetObject("pageButton_Filter.Icon");
            pageButton_Filter.IconLocation = new Point(11, 11);
            pageButton_Filter.IconSize = new Size(34, 34);
            pageButton_Filter.Location = new Point(1094, 12);
            pageButton_Filter.Margin = new Padding(2);
            pageButton_Filter.Name = "pageButton_Filter";
            pageButton_Filter.Size = new Size(55, 55);
            pageButton_Filter.TabIndex = 6;
            pageButton_Filter.TextLocation = new Point(0, 0);
            pageButton_Filter.UseVisualStyleBackColor = false;
            pageButton_Filter.Click += pageButton_Filter_Click;
            // 
            // pageButton_Remove
            // 
            pageButton_Remove.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_Remove.BorderColor = Color.PaleVioletRed;
            pageButton_Remove.BorderRadius = 20;
            pageButton_Remove.BorderSize = 0;
            pageButton_Remove.CustomText = null;
            pageButton_Remove.FlatAppearance.BorderSize = 0;
            pageButton_Remove.FlatStyle = FlatStyle.Flat;
            pageButton_Remove.ForeColor = Color.White;
            pageButton_Remove.Icon = (Image)resources.GetObject("pageButton_Remove.Icon");
            pageButton_Remove.IconLocation = new Point(11, 11);
            pageButton_Remove.IconSize = new Size(34, 34);
            pageButton_Remove.Location = new Point(90, 12);
            pageButton_Remove.Margin = new Padding(2);
            pageButton_Remove.Name = "pageButton_Remove";
            pageButton_Remove.Size = new Size(55, 55);
            pageButton_Remove.TabIndex = 5;
            pageButton_Remove.TextLocation = new Point(0, 0);
            pageButton_Remove.UseVisualStyleBackColor = false;
            pageButton_Remove.Click += pageButton_Remove_Click;
            // 
            // pageButton_Upload
            // 
            pageButton_Upload.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_Upload.BorderColor = Color.PaleVioletRed;
            pageButton_Upload.BorderRadius = 20;
            pageButton_Upload.BorderSize = 0;
            pageButton_Upload.CustomText = null;
            pageButton_Upload.FlatAppearance.BorderSize = 0;
            pageButton_Upload.FlatStyle = FlatStyle.Flat;
            pageButton_Upload.ForeColor = Color.White;
            pageButton_Upload.Icon = (Image)resources.GetObject("pageButton_Upload.Icon");
            pageButton_Upload.IconLocation = new Point(11, 11);
            pageButton_Upload.IconSize = new Size(34, 34);
            pageButton_Upload.Location = new Point(25, 12);
            pageButton_Upload.Margin = new Padding(2);
            pageButton_Upload.Name = "pageButton_Upload";
            pageButton_Upload.Size = new Size(55, 55);
            pageButton_Upload.TabIndex = 4;
            pageButton_Upload.TextLocation = new Point(0, 0);
            pageButton_Upload.UseVisualStyleBackColor = false;
            pageButton_Upload.Click += pageButton_Upload_Click;
            // 
            // customDataGridView
            // 
            customDataGridView.AllowUserToAddRows = false;
            customDataGridView.AllowUserToDeleteRows = false;
            customDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            customDataGridView.BackgroundColor = Color.White;
            customDataGridView.BorderStyle = BorderStyle.None;
            customDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            customDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(79, 69, 87);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.Padding = new Padding(0, 0, 0, 5);
            dataGridViewCellStyle3.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            customDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            customDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customDataGridView.CornerRadius = 60;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semilight", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.Padding = new Padding(15, 0, 5, 5);
            dataGridViewCellStyle4.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            customDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            customDataGridView.EnableHeadersVisualStyles = false;
            customDataGridView.GridColor = Color.White;
            customDataGridView.Location = new Point(25, 168);
            customDataGridView.Margin = new Padding(2);
            customDataGridView.Name = "customDataGridView";
            customDataGridView.ReadOnly = true;
            customDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            customDataGridView.RowHeadersVisible = false;
            customDataGridView.RowHeadersWidth = 62;
            customDataGridView.Size = new Size(1124, 600);
            customDataGridView.TabIndex = 23;
            customDataGridView.CellMouseDoubleClick += customDataGridView_CellMouseDoubleClicked;
            // 
            // panel_DV_Upload
            // 
            panel_DV_Upload.Anchor = AnchorStyles.Right;
            panel_DV_Upload.AutoSize = true;
            panel_DV_Upload.Controls.Add(button_DVUpload_Reset);
            panel_DV_Upload.Controls.Add(button_DV_OK);
            panel_DV_Upload.Controls.Add(textBox_DV_MoTa);
            panel_DV_Upload.Controls.Add(label_DV_MoTa);
            panel_DV_Upload.Controls.Add(textBox_DV_TenDV);
            panel_DV_Upload.Controls.Add(label_DV_TenDV);
            panel_DV_Upload.Controls.Add(textBox_DV_ChiPhi);
            panel_DV_Upload.Controls.Add(label_DV_ChiPhi);
            panel_DV_Upload.Controls.Add(textBox_DV_MaDV);
            panel_DV_Upload.Controls.Add(label_DV_MaDV);
            panel_DV_Upload.Controls.Add(label_DV_Upload);
            panel_DV_Upload.Location = new Point(1174, 84);
            panel_DV_Upload.Margin = new Padding(4);
            panel_DV_Upload.Name = "panel_DV_Upload";
            panel_DV_Upload.Size = new Size(416, 780);
            panel_DV_Upload.TabIndex = 24;
            panel_DV_Upload.Paint += panel_Paint;
            // 
            // button_DVUpload_Reset
            // 
            button_DVUpload_Reset.FlatStyle = FlatStyle.Flat;
            button_DVUpload_Reset.Font = new Font("Segoe UI", 10F);
            button_DVUpload_Reset.ForeColor = Color.FromArgb(38, 187, 255);
            button_DVUpload_Reset.Location = new Point(297, 710);
            button_DVUpload_Reset.Name = "button_DVUpload_Reset";
            button_DVUpload_Reset.Size = new Size(94, 43);
            button_DVUpload_Reset.TabIndex = 43;
            button_DVUpload_Reset.Text = "RESET";
            button_DVUpload_Reset.UseVisualStyleBackColor = true;
            button_DVUpload_Reset.Click += button_DVUpload_Reset_Click;
            // 
            // button_DV_OK
            // 
            button_DV_OK.FlatStyle = FlatStyle.Flat;
            button_DV_OK.Font = new Font("Segoe UI", 10F);
            button_DV_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_DV_OK.Location = new Point(25, 710);
            button_DV_OK.Margin = new Padding(2);
            button_DV_OK.Name = "button_DV_OK";
            button_DV_OK.Size = new Size(94, 43);
            button_DV_OK.TabIndex = 30;
            button_DV_OK.Text = "OK";
            button_DV_OK.UseVisualStyleBackColor = true;
            button_DV_OK.Click += button_DV_OK_Click;
            // 
            // textBox_DV_MoTa
            // 
            textBox_DV_MoTa.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_MoTa.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_MoTa.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_MoTa.Location = new Point(20, 326);
            textBox_DV_MoTa.Margin = new Padding(2);
            textBox_DV_MoTa.Multiline = true;
            textBox_DV_MoTa.Name = "textBox_DV_MoTa";
            textBox_DV_MoTa.Size = new Size(375, 338);
            textBox_DV_MoTa.TabIndex = 29;
            // 
            // label_DV_MoTa
            // 
            label_DV_MoTa.AutoSize = true;
            label_DV_MoTa.BackColor = Color.Transparent;
            label_DV_MoTa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_MoTa.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_MoTa.ImageAlign = ContentAlignment.BottomCenter;
            label_DV_MoTa.Location = new Point(25, 282);
            label_DV_MoTa.Margin = new Padding(2, 0, 2, 0);
            label_DV_MoTa.Name = "label_DV_MoTa";
            label_DV_MoTa.Size = new Size(64, 28);
            label_DV_MoTa.TabIndex = 28;
            label_DV_MoTa.Text = "Mô tả";
            label_DV_MoTa.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_DV_TenDV
            // 
            textBox_DV_TenDV.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_TenDV.BorderStyle = BorderStyle.None;
            textBox_DV_TenDV.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_TenDV.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_TenDV.Location = new Point(25, 227);
            textBox_DV_TenDV.Margin = new Padding(2);
            textBox_DV_TenDV.Name = "textBox_DV_TenDV";
            textBox_DV_TenDV.Size = new Size(365, 32);
            textBox_DV_TenDV.TabIndex = 8;
            // 
            // label_DV_TenDV
            // 
            label_DV_TenDV.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_TenDV.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_TenDV.Location = new Point(25, 183);
            label_DV_TenDV.Margin = new Padding(4, 0, 4, 0);
            label_DV_TenDV.Name = "label_DV_TenDV";
            label_DV_TenDV.Size = new Size(122, 31);
            label_DV_TenDV.TabIndex = 7;
            label_DV_TenDV.Text = "Tên dịch vụ";
            // 
            // textBox_DV_ChiPhi
            // 
            textBox_DV_ChiPhi.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_ChiPhi.BorderStyle = BorderStyle.None;
            textBox_DV_ChiPhi.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_ChiPhi.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_ChiPhi.Location = new Point(230, 128);
            textBox_DV_ChiPhi.Margin = new Padding(2);
            textBox_DV_ChiPhi.Name = "textBox_DV_ChiPhi";
            textBox_DV_ChiPhi.Size = new Size(160, 32);
            textBox_DV_ChiPhi.TabIndex = 6;
            // 
            // label_DV_ChiPhi
            // 
            label_DV_ChiPhi.AutoSize = true;
            label_DV_ChiPhi.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_ChiPhi.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_ChiPhi.Location = new Point(230, 84);
            label_DV_ChiPhi.Margin = new Padding(4, 0, 4, 0);
            label_DV_ChiPhi.Name = "label_DV_ChiPhi";
            label_DV_ChiPhi.Size = new Size(78, 30);
            label_DV_ChiPhi.TabIndex = 5;
            label_DV_ChiPhi.Text = "Chi phí";
            // 
            // textBox_DV_MaDV
            // 
            textBox_DV_MaDV.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_MaDV.BorderStyle = BorderStyle.None;
            textBox_DV_MaDV.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_MaDV.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_MaDV.Location = new Point(25, 128);
            textBox_DV_MaDV.Margin = new Padding(2);
            textBox_DV_MaDV.Name = "textBox_DV_MaDV";
            textBox_DV_MaDV.Size = new Size(160, 32);
            textBox_DV_MaDV.TabIndex = 4;
            textBox_DV_MaDV.Leave += textBox_DV_MaDV_Leave;
            // 
            // label_DV_MaDV
            // 
            label_DV_MaDV.AutoSize = true;
            label_DV_MaDV.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_MaDV.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_MaDV.Location = new Point(25, 84);
            label_DV_MaDV.Margin = new Padding(4, 0, 4, 0);
            label_DV_MaDV.Name = "label_DV_MaDV";
            label_DV_MaDV.Size = new Size(116, 30);
            label_DV_MaDV.TabIndex = 1;
            label_DV_MaDV.Text = "Mã dịch vụ";
            // 
            // label_DV_Upload
            // 
            label_DV_Upload.AutoSize = true;
            label_DV_Upload.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_DV_Upload.ForeColor = Color.White;
            label_DV_Upload.Location = new Point(15, 8);
            label_DV_Upload.Margin = new Padding(4, 0, 4, 0);
            label_DV_Upload.Name = "label_DV_Upload";
            label_DV_Upload.Size = new Size(110, 38);
            label_DV_Upload.TabIndex = 0;
            label_DV_Upload.Text = "Upload";
            // 
            // panel_DV_Filter
            // 
            panel_DV_Filter.Anchor = AnchorStyles.Right;
            panel_DV_Filter.AutoSize = true;
            panel_DV_Filter.Controls.Add(button_DVFilters_Reset);
            panel_DV_Filter.Controls.Add(comboBox_DV_Filter_Operation);
            panel_DV_Filter.Controls.Add(button_DV_OK_Filter);
            panel_DV_Filter.Controls.Add(textBox_DV_TenDV_Filter);
            panel_DV_Filter.Controls.Add(label2);
            panel_DV_Filter.Controls.Add(textBox_DV_ChiPhi_Filter);
            panel_DV_Filter.Controls.Add(label3);
            panel_DV_Filter.Controls.Add(textBox_DV_MaDV_Filter);
            panel_DV_Filter.Controls.Add(label4);
            panel_DV_Filter.Controls.Add(label5);
            panel_DV_Filter.Location = new Point(1174, 84);
            panel_DV_Filter.Margin = new Padding(4);
            panel_DV_Filter.Name = "panel_DV_Filter";
            panel_DV_Filter.Size = new Size(416, 780);
            panel_DV_Filter.TabIndex = 31;
            panel_DV_Filter.Paint += panel_Paint;
            // 
            // button_DVFilters_Reset
            // 
            button_DVFilters_Reset.FlatStyle = FlatStyle.Flat;
            button_DVFilters_Reset.Font = new Font("Segoe UI", 10F);
            button_DVFilters_Reset.ForeColor = Color.FromArgb(38, 187, 255);
            button_DVFilters_Reset.Location = new Point(297, 710);
            button_DVFilters_Reset.Name = "button_DVFilters_Reset";
            button_DVFilters_Reset.Size = new Size(94, 43);
            button_DVFilters_Reset.TabIndex = 43;
            button_DVFilters_Reset.Text = "RESET";
            button_DVFilters_Reset.UseVisualStyleBackColor = true;
            button_DVFilters_Reset.Click += button_Filters_Reset_Click;
            // 
            // comboBox_DV_Filter_Operation
            // 
            comboBox_DV_Filter_Operation.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_DV_Filter_Operation.FlatStyle = FlatStyle.Flat;
            comboBox_DV_Filter_Operation.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_DV_Filter_Operation.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_DV_Filter_Operation.FormattingEnabled = true;
            comboBox_DV_Filter_Operation.Items.AddRange(new object[] { ">", "≥", "=", "≤", "<" });
            comboBox_DV_Filter_Operation.Location = new Point(34, 326);
            comboBox_DV_Filter_Operation.Margin = new Padding(2);
            comboBox_DV_Filter_Operation.Name = "comboBox_DV_Filter_Operation";
            comboBox_DV_Filter_Operation.Size = new Size(59, 40);
            comboBox_DV_Filter_Operation.TabIndex = 31;
            // 
            // button_DV_OK_Filter
            // 
            button_DV_OK_Filter.FlatStyle = FlatStyle.Flat;
            button_DV_OK_Filter.Font = new Font("Segoe UI", 10F);
            button_DV_OK_Filter.ForeColor = Color.FromArgb(148, 255, 216);
            button_DV_OK_Filter.Location = new Point(25, 710);
            button_DV_OK_Filter.Margin = new Padding(2);
            button_DV_OK_Filter.Name = "button_DV_OK_Filter";
            button_DV_OK_Filter.Size = new Size(94, 43);
            button_DV_OK_Filter.TabIndex = 30;
            button_DV_OK_Filter.Text = "OK";
            button_DV_OK_Filter.UseVisualStyleBackColor = true;
            button_DV_OK_Filter.Click += button_DV_OK_Filter_Click;
            // 
            // textBox_DV_TenDV_Filter
            // 
            textBox_DV_TenDV_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_TenDV_Filter.BorderStyle = BorderStyle.None;
            textBox_DV_TenDV_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_TenDV_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_TenDV_Filter.Location = new Point(25, 227);
            textBox_DV_TenDV_Filter.Margin = new Padding(2);
            textBox_DV_TenDV_Filter.Name = "textBox_DV_TenDV_Filter";
            textBox_DV_TenDV_Filter.Size = new Size(365, 32);
            textBox_DV_TenDV_Filter.TabIndex = 8;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(193, 193, 193);
            label2.Location = new Point(25, 183);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(122, 31);
            label2.TabIndex = 7;
            label2.Text = "Tên dịch vụ";
            // 
            // textBox_DV_ChiPhi_Filter
            // 
            textBox_DV_ChiPhi_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_ChiPhi_Filter.BorderStyle = BorderStyle.None;
            textBox_DV_ChiPhi_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_ChiPhi_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_ChiPhi_Filter.Location = new Point(110, 326);
            textBox_DV_ChiPhi_Filter.Margin = new Padding(2);
            textBox_DV_ChiPhi_Filter.Name = "textBox_DV_ChiPhi_Filter";
            textBox_DV_ChiPhi_Filter.Size = new Size(280, 32);
            textBox_DV_ChiPhi_Filter.TabIndex = 6;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(193, 193, 193);
            label3.Location = new Point(25, 282);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 31);
            label3.TabIndex = 5;
            label3.Text = "Chi phí";
            // 
            // textBox_DV_MaDV_Filter
            // 
            textBox_DV_MaDV_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_MaDV_Filter.BorderStyle = BorderStyle.None;
            textBox_DV_MaDV_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_MaDV_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_MaDV_Filter.Location = new Point(25, 128);
            textBox_DV_MaDV_Filter.Margin = new Padding(2);
            textBox_DV_MaDV_Filter.Name = "textBox_DV_MaDV_Filter";
            textBox_DV_MaDV_Filter.Size = new Size(365, 32);
            textBox_DV_MaDV_Filter.TabIndex = 4;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(193, 193, 193);
            label4.Location = new Point(25, 84);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(122, 31);
            label4.TabIndex = 1;
            label4.Text = "Mã dịch vụ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(15, 8);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(92, 38);
            label5.TabIndex = 0;
            label5.Text = "Filters";
            // 
            // panel_TinhTrang_Filter
            // 
            panel_TinhTrang_Filter.Anchor = AnchorStyles.Right;
            panel_TinhTrang_Filter.AutoSize = true;
            panel_TinhTrang_Filter.Controls.Add(button_TTFilters_Reset);
            panel_TinhTrang_Filter.Controls.Add(comboBox_TinhTrang_Filter);
            panel_TinhTrang_Filter.Controls.Add(label10);
            panel_TinhTrang_Filter.Controls.Add(textBox_TT_MaPK_Filter);
            panel_TinhTrang_Filter.Controls.Add(label9);
            panel_TinhTrang_Filter.Controls.Add(button_TT_OK);
            panel_TinhTrang_Filter.Controls.Add(textBox_TT_TenDV_Filter);
            panel_TinhTrang_Filter.Controls.Add(label1);
            panel_TinhTrang_Filter.Controls.Add(textBox_TT_MaDV_Filter);
            panel_TinhTrang_Filter.Controls.Add(label7);
            panel_TinhTrang_Filter.Controls.Add(label8);
            panel_TinhTrang_Filter.Location = new Point(1174, 84);
            panel_TinhTrang_Filter.Margin = new Padding(4);
            panel_TinhTrang_Filter.Name = "panel_TinhTrang_Filter";
            panel_TinhTrang_Filter.Size = new Size(416, 784);
            panel_TinhTrang_Filter.TabIndex = 32;
            panel_TinhTrang_Filter.Paint += panel_Paint;
            // 
            // button_TTFilters_Reset
            // 
            button_TTFilters_Reset.FlatStyle = FlatStyle.Flat;
            button_TTFilters_Reset.Font = new Font("Segoe UI", 10F);
            button_TTFilters_Reset.ForeColor = Color.FromArgb(38, 187, 255);
            button_TTFilters_Reset.Location = new Point(297, 703);
            button_TTFilters_Reset.Name = "button_TTFilters_Reset";
            button_TTFilters_Reset.Size = new Size(94, 43);
            button_TTFilters_Reset.TabIndex = 42;
            button_TTFilters_Reset.Text = "RESET";
            button_TTFilters_Reset.UseVisualStyleBackColor = true;
            button_TTFilters_Reset.Click += button_Filters_Reset_Click;
            // 
            // comboBox_TinhTrang_Filter
            // 
            comboBox_TinhTrang_Filter.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
            comboBox_TinhTrang_Filter.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_TinhTrang_Filter.FlatStyle = FlatStyle.Flat;
            comboBox_TinhTrang_Filter.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_TinhTrang_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_TinhTrang_Filter.FormattingEnabled = true;
            comboBox_TinhTrang_Filter.Items.AddRange(new object[] { "Open", "Close" });
            comboBox_TinhTrang_Filter.Location = new Point(25, 425);
            comboBox_TinhTrang_Filter.Margin = new Padding(2);
            comboBox_TinhTrang_Filter.Name = "comboBox_TinhTrang_Filter";
            comboBox_TinhTrang_Filter.Size = new Size(166, 40);
            comboBox_TinhTrang_Filter.TabIndex = 37;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(193, 193, 193);
            label10.Location = new Point(25, 381);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(189, 31);
            label10.TabIndex = 35;
            label10.Text = "Tình trạng";
            // 
            // textBox_TT_MaPK_Filter
            // 
            textBox_TT_MaPK_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_TT_MaPK_Filter.BorderStyle = BorderStyle.None;
            textBox_TT_MaPK_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_TT_MaPK_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_TT_MaPK_Filter.Location = new Point(25, 326);
            textBox_TT_MaPK_Filter.Margin = new Padding(2);
            textBox_TT_MaPK_Filter.Name = "textBox_TT_MaPK_Filter";
            textBox_TT_MaPK_Filter.Size = new Size(368, 32);
            textBox_TT_MaPK_Filter.TabIndex = 32;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(193, 193, 193);
            label9.Location = new Point(25, 282);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(189, 31);
            label9.TabIndex = 31;
            label9.Text = "Mã phòng khám";
            // 
            // button_TT_OK
            // 
            button_TT_OK.FlatStyle = FlatStyle.Flat;
            button_TT_OK.Font = new Font("Segoe UI", 10F);
            button_TT_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_TT_OK.Location = new Point(25, 710);
            button_TT_OK.Margin = new Padding(2);
            button_TT_OK.Name = "button_TT_OK";
            button_TT_OK.Size = new Size(94, 43);
            button_TT_OK.TabIndex = 30;
            button_TT_OK.Text = "OK";
            button_TT_OK.UseVisualStyleBackColor = true;
            button_TT_OK.Click += button_TT_OK_Click;
            // 
            // textBox_TT_TenDV_Filter
            // 
            textBox_TT_TenDV_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_TT_TenDV_Filter.BorderStyle = BorderStyle.None;
            textBox_TT_TenDV_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_TT_TenDV_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_TT_TenDV_Filter.Location = new Point(25, 227);
            textBox_TT_TenDV_Filter.Margin = new Padding(2);
            textBox_TT_TenDV_Filter.Name = "textBox_TT_TenDV_Filter";
            textBox_TT_TenDV_Filter.Size = new Size(368, 32);
            textBox_TT_TenDV_Filter.TabIndex = 8;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(193, 193, 193);
            label1.Location = new Point(25, 183);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(122, 31);
            label1.TabIndex = 7;
            label1.Text = "Tên dịch vụ";
            // 
            // textBox_TT_MaDV_Filter
            // 
            textBox_TT_MaDV_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_TT_MaDV_Filter.BorderStyle = BorderStyle.None;
            textBox_TT_MaDV_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_TT_MaDV_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_TT_MaDV_Filter.Location = new Point(25, 128);
            textBox_TT_MaDV_Filter.Margin = new Padding(2);
            textBox_TT_MaDV_Filter.Name = "textBox_TT_MaDV_Filter";
            textBox_TT_MaDV_Filter.Size = new Size(368, 32);
            textBox_TT_MaDV_Filter.TabIndex = 4;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(193, 193, 193);
            label7.Location = new Point(25, 84);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(122, 31);
            label7.TabIndex = 1;
            label7.Text = "Mã dịch vụ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(15, 8);
            label8.Name = "label8";
            label8.Size = new Size(92, 38);
            label8.TabIndex = 0;
            label8.Text = "Filters";
            // 
            // panel_TinhTrang_Upload
            // 
            panel_TinhTrang_Upload.Anchor = AnchorStyles.Right;
            panel_TinhTrang_Upload.AutoSize = true;
            panel_TinhTrang_Upload.Controls.Add(button_TTUpload_Reset);
            panel_TinhTrang_Upload.Controls.Add(comboBox_TinhTrang_Upload);
            panel_TinhTrang_Upload.Controls.Add(label11);
            panel_TinhTrang_Upload.Controls.Add(textBox_TT_MaPK_Upload);
            panel_TinhTrang_Upload.Controls.Add(label13);
            panel_TinhTrang_Upload.Controls.Add(button_OK_Upload);
            panel_TinhTrang_Upload.Controls.Add(textBox_TT_MaDV_Upload);
            panel_TinhTrang_Upload.Controls.Add(label15);
            panel_TinhTrang_Upload.Controls.Add(label_TT_Upload);
            panel_TinhTrang_Upload.Location = new Point(1174, 84);
            panel_TinhTrang_Upload.Margin = new Padding(4);
            panel_TinhTrang_Upload.Name = "panel_TinhTrang_Upload";
            panel_TinhTrang_Upload.Size = new Size(416, 780);
            panel_TinhTrang_Upload.TabIndex = 38;
            panel_TinhTrang_Upload.Paint += panel_Paint;
            // 
            // button_TTUpload_Reset
            // 
            button_TTUpload_Reset.FlatStyle = FlatStyle.Flat;
            button_TTUpload_Reset.Font = new Font("Segoe UI", 10F);
            button_TTUpload_Reset.ForeColor = Color.FromArgb(38, 187, 255);
            button_TTUpload_Reset.Location = new Point(297, 710);
            button_TTUpload_Reset.Name = "button_TTUpload_Reset";
            button_TTUpload_Reset.Size = new Size(94, 43);
            button_TTUpload_Reset.TabIndex = 43;
            button_TTUpload_Reset.Text = "RESET";
            button_TTUpload_Reset.UseVisualStyleBackColor = true;
            button_TTUpload_Reset.Click += button_TTUpload_Reset_Click;
            // 
            // comboBox_TinhTrang_Upload
            // 
            comboBox_TinhTrang_Upload.AutoCompleteSource = AutoCompleteSource.RecentlyUsedList;
            comboBox_TinhTrang_Upload.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_TinhTrang_Upload.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_TinhTrang_Upload.FlatStyle = FlatStyle.Flat;
            comboBox_TinhTrang_Upload.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_TinhTrang_Upload.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_TinhTrang_Upload.FormattingEnabled = true;
            comboBox_TinhTrang_Upload.Items.AddRange(new object[] { "Open", "Close" });
            comboBox_TinhTrang_Upload.Location = new Point(25, 326);
            comboBox_TinhTrang_Upload.Margin = new Padding(2);
            comboBox_TinhTrang_Upload.Name = "comboBox_TinhTrang_Upload";
            comboBox_TinhTrang_Upload.Size = new Size(166, 40);
            comboBox_TinhTrang_Upload.TabIndex = 37;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(193, 193, 193);
            label11.Location = new Point(25, 282);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(189, 31);
            label11.TabIndex = 35;
            label11.Text = "Tình trạng";
            // 
            // textBox_TT_MaPK_Upload
            // 
            textBox_TT_MaPK_Upload.BackColor = Color.FromArgb(57, 54, 70);
            textBox_TT_MaPK_Upload.BorderStyle = BorderStyle.None;
            textBox_TT_MaPK_Upload.Font = new Font("Segoe UI Semilight", 12F);
            textBox_TT_MaPK_Upload.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_TT_MaPK_Upload.Location = new Point(25, 227);
            textBox_TT_MaPK_Upload.Margin = new Padding(2);
            textBox_TT_MaPK_Upload.Name = "textBox_TT_MaPK_Upload";
            textBox_TT_MaPK_Upload.Size = new Size(365, 32);
            textBox_TT_MaPK_Upload.TabIndex = 32;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(193, 193, 193);
            label13.Location = new Point(25, 183);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(189, 31);
            label13.TabIndex = 31;
            label13.Text = "Mã phòng khám";
            // 
            // button_OK_Upload
            // 
            button_OK_Upload.FlatStyle = FlatStyle.Flat;
            button_OK_Upload.Font = new Font("Segoe UI", 10F);
            button_OK_Upload.ForeColor = Color.FromArgb(148, 255, 216);
            button_OK_Upload.Location = new Point(25, 710);
            button_OK_Upload.Margin = new Padding(2);
            button_OK_Upload.Name = "button_OK_Upload";
            button_OK_Upload.Size = new Size(94, 43);
            button_OK_Upload.TabIndex = 30;
            button_OK_Upload.Text = "OK";
            button_OK_Upload.UseVisualStyleBackColor = true;
            button_OK_Upload.Click += button_OK_Upload_Click;
            // 
            // textBox_TT_MaDV_Upload
            // 
            textBox_TT_MaDV_Upload.BackColor = Color.FromArgb(57, 54, 70);
            textBox_TT_MaDV_Upload.BorderStyle = BorderStyle.None;
            textBox_TT_MaDV_Upload.Font = new Font("Segoe UI Semilight", 12F);
            textBox_TT_MaDV_Upload.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_TT_MaDV_Upload.Location = new Point(25, 128);
            textBox_TT_MaDV_Upload.Margin = new Padding(2);
            textBox_TT_MaDV_Upload.Name = "textBox_TT_MaDV_Upload";
            textBox_TT_MaDV_Upload.Size = new Size(365, 32);
            textBox_TT_MaDV_Upload.TabIndex = 4;
            // 
            // label15
            // 
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.FromArgb(193, 193, 193);
            label15.Location = new Point(25, 84);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(122, 31);
            label15.TabIndex = 1;
            label15.Text = "Mã dịch vụ";
            // 
            // label_TT_Upload
            // 
            label_TT_Upload.AutoSize = true;
            label_TT_Upload.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_TT_Upload.ForeColor = Color.White;
            label_TT_Upload.Location = new Point(15, 8);
            label_TT_Upload.Margin = new Padding(4, 0, 4, 0);
            label_TT_Upload.Name = "label_TT_Upload";
            label_TT_Upload.Size = new Size(110, 38);
            label_TT_Upload.TabIndex = 0;
            label_TT_Upload.Text = "Upload";
            // 
            // customPanel_DetailsControl
            // 
            customPanel_DetailsControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customPanel_DetailsControl.BackColor = Color.FromArgb(79, 69, 87);
            customPanel_DetailsControl.CornerRadius = 40;
            customPanel_DetailsControl.Location = new Point(25, 787);
            customPanel_DetailsControl.Name = "customPanel_DetailsControl";
            customPanel_DetailsControl.Size = new Size(1124, 60);
            customPanel_DetailsControl.TabIndex = 39;
            // 
            // DichVuControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 54, 70);
            Controls.Add(customPanel_DetailsControl);
            Controls.Add(panel_Toolbar);
            Controls.Add(panel_TopPanel);
            Controls.Add(customDataGridView);
            Controls.Add(panel_DV_Upload);
            Controls.Add(panel_DV_Filter);
            Controls.Add(panel_TinhTrang_Filter);
            Controls.Add(panel_TinhTrang_Upload);
            Margin = new Padding(2);
            Name = "DichVuControl";
            Size = new Size(1590, 864);
            Load += DichVuControl_Load;
            panel_TopPanel.ResumeLayout(false);
            panel_Toolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customDataGridView).EndInit();
            panel_DV_Upload.ResumeLayout(false);
            panel_DV_Upload.PerformLayout();
            panel_DV_Filter.ResumeLayout(false);
            panel_DV_Filter.PerformLayout();
            panel_TinhTrang_Filter.ResumeLayout(false);
            panel_TinhTrang_Filter.PerformLayout();
            panel_TinhTrang_Upload.ResumeLayout(false);
            panel_TinhTrang_Upload.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel_TopPanel;
        private Panel panel_Toolbar;
        private Custom.CustomDataGridView customDataGridView;
        private Panel panel_DV_Upload;
        private Label label_DV_Upload;
        private Label label_DV_MaDV;
        private Custom.PageButton pageButton_DV;
        private Custom.PageButton pageButton_TinhTrang;
        private Custom.PageButton pageButton_Filter;
        private Custom.PageButton pageButton_Remove;
        private Custom.PageButton pageButton_Upload;
        private TextBox textBox_DV_ChiPhi;
        private Label label_DV_ChiPhi;
        private TextBox textBox_DV_MaDV;
        private TextBox textBox_DV_TenDV;
        private Label label_DV_TenDV;
        private TextBox textBox_DV_MoTa;
        private Label label_DV_MoTa;
        private Button button_DV_OK;
        private Panel panel_DV_Filter;
        private Button button_DV_OK_Filter;
        private TextBox textBox_DV_TenDV_Filter;
        private Label label2;
        private TextBox textBox_DV_ChiPhi_Filter;
        private Label label3;
        private TextBox textBox_DV_MaDV_Filter;
        private Label label4;
        private Label label5;
        private ComboBox comboBox_DV_Filter_Operation;
        private Panel panel_TinhTrang_Filter;
        private Label label10;
        private TextBox textBox_TT_MaPK_Filter;
        private Label label9;
        private Button button_TT_OK;
        private TextBox textBox_TT_TenDV_Filter;
        private Label label1;
        private TextBox textBox_TT_MaDV_Filter;
        private Label label7;
        private Label label8;
        private ComboBox comboBox_TinhTrang_Filter;
        private Panel panel_TinhTrang_Upload;
        private ComboBox comboBox_TinhTrang_Upload;
        private Label label11;
        private TextBox textBox_TT_MaPK_Upload;
        private Label label13;
        private Button button_OK_Upload;
        private TextBox textBox_TT_MaDV_Upload;
        private Label label15;
        private Label label_TT_Upload;
        private Custom.CustomPanel customPanel_DetailsControl;
        private Button button_TTFilters_Reset;
        private Button button_DVUpload_Reset;
        private Button button_TTUpload_Reset;
        private Button button_DVFilters_Reset;
    }
}
