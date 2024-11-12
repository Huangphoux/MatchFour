using System.Data.Common;

namespace QuanLyMachTu
{
    partial class BenhNhanControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BenhNhanControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label_Filters = new Label();
            textBox_Filters_MaBN = new TextBox();
            button_Filters_OK = new Button();
            textBox_Filters_TenBN = new TextBox();
            textBox_Filters_DoanhSo = new TextBox();
            textBox_Filters_Email = new TextBox();
            textBox_Filters_SDT = new TextBox();
            textBox_GE = new TextBox();
            textBox_Filters_MaHSBA = new TextBox();
            textBox_Filters_MaTK = new TextBox();
            label_Filters_MaBN = new Label();
            label_Filters_MaHSBA = new Label();
            label_Filters_MaTK = new Label();
            label_Filters_TenBN = new Label();
            label_Filters_Email = new Label();
            label_Filters_SDT = new Label();
            label_Filters_DoanhSo = new Label();
            panel_Filter = new Panel();
            pageButton_Upload = new PageButton();
            pageButton_Remove = new PageButton();
            pageButton_Filter = new PageButton();
            panel_Toolbar = new Panel();
            label_BNUpload = new Label();
            textBox_BNUpload_MaBN = new TextBox();
            button_Upload_OK = new Button();
            textBox_BNUpload_TenBN = new TextBox();
            textBox_BNUpload_SDT = new TextBox();
            textBox_BNUpload_Email = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox_BNUpload_Ngay = new TextBox();
            label5 = new Label();
            label6 = new Label();
            comboBox_BNUpload_Thang = new ComboBox();
            label7 = new Label();
            textBox_BNUpload_Nam = new TextBox();
            label8 = new Label();
            label9 = new Label();
            checkBox_BNUpload_Nam = new CheckBox();
            checkBox_BNUpload_Nu = new CheckBox();
            panel_Upload = new Panel();
            customDataGridView_BenhNhan = new CustomDataGridView();
            customPanel_Sum = new CustomPanel();
            label_HienThiDTTong = new Label();
            label_HienThiSoBN = new Label();
            label_DoanhThuTong = new Label();
            label_SoBenhNhan = new Label();
            panel1 = new Panel();
            pageButton6 = new PageButton();
            pageButton5 = new PageButton();
            pageButton2 = new PageButton();
            pageButton1 = new PageButton();
            panel_Filter.SuspendLayout();
            panel_Toolbar.SuspendLayout();
            panel_Upload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customDataGridView_BenhNhan).BeginInit();
            customPanel_Sum.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label_Filters
            // 
            label_Filters.AutoSize = true;
            label_Filters.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Filters.ForeColor = Color.White;
            label_Filters.Location = new Point(15, 8);
            label_Filters.Name = "label_Filters";
            label_Filters.Size = new Size(92, 38);
            label_Filters.TabIndex = 2;
            label_Filters.Text = "Filters";
            // 
            // textBox_Filters_MaBN
            // 
            textBox_Filters_MaBN.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Filters_MaBN.BorderStyle = BorderStyle.None;
            textBox_Filters_MaBN.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Filters_MaBN.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Filters_MaBN.Location = new Point(25, 128);
            textBox_Filters_MaBN.Name = "textBox_Filters_MaBN";
            textBox_Filters_MaBN.Size = new Size(105, 32);
            textBox_Filters_MaBN.TabIndex = 3;
            // 
            // button_Filters_OK
            // 
            button_Filters_OK.FlatStyle = FlatStyle.Flat;
            button_Filters_OK.Font = new Font("Segoe UI", 10F);
            button_Filters_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_Filters_OK.Location = new Point(25, 710);
            button_Filters_OK.Name = "button_Filters_OK";
            button_Filters_OK.Size = new Size(94, 43);
            button_Filters_OK.TabIndex = 4;
            button_Filters_OK.Text = "OK";
            button_Filters_OK.UseVisualStyleBackColor = true;
            button_Filters_OK.Click += button_Filters_OK_Click;
            // 
            // textBox_Filters_TenBN
            // 
            textBox_Filters_TenBN.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Filters_TenBN.BorderStyle = BorderStyle.None;
            textBox_Filters_TenBN.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Filters_TenBN.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Filters_TenBN.Location = new Point(25, 227);
            textBox_Filters_TenBN.Name = "textBox_Filters_TenBN";
            textBox_Filters_TenBN.Size = new Size(365, 32);
            textBox_Filters_TenBN.TabIndex = 5;
            // 
            // textBox_Filters_DoanhSo
            // 
            textBox_Filters_DoanhSo.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Filters_DoanhSo.BorderStyle = BorderStyle.None;
            textBox_Filters_DoanhSo.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Filters_DoanhSo.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Filters_DoanhSo.Location = new Point(25, 524);
            textBox_Filters_DoanhSo.Name = "textBox_Filters_DoanhSo";
            textBox_Filters_DoanhSo.Size = new Size(327, 32);
            textBox_Filters_DoanhSo.TabIndex = 6;
            textBox_Filters_DoanhSo.Text = "0";
            textBox_Filters_DoanhSo.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // textBox_Filters_Email
            // 
            textBox_Filters_Email.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Filters_Email.BorderStyle = BorderStyle.None;
            textBox_Filters_Email.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Filters_Email.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Filters_Email.Location = new Point(25, 326);
            textBox_Filters_Email.Name = "textBox_Filters_Email";
            textBox_Filters_Email.Size = new Size(365, 32);
            textBox_Filters_Email.TabIndex = 7;
            // 
            // textBox_Filters_SDT
            // 
            textBox_Filters_SDT.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Filters_SDT.BorderStyle = BorderStyle.None;
            textBox_Filters_SDT.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Filters_SDT.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Filters_SDT.Location = new Point(25, 425);
            textBox_Filters_SDT.Name = "textBox_Filters_SDT";
            textBox_Filters_SDT.Size = new Size(365, 32);
            textBox_Filters_SDT.TabIndex = 8;
            textBox_Filters_SDT.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // textBox_GE
            // 
            textBox_GE.BackColor = Color.FromArgb(57, 54, 70);
            textBox_GE.BorderStyle = BorderStyle.None;
            textBox_GE.Font = new Font("Segoe UI Semilight", 12F);
            textBox_GE.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_GE.Location = new Point(351, 524);
            textBox_GE.Name = "textBox_GE";
            textBox_GE.ReadOnly = true;
            textBox_GE.Size = new Size(39, 32);
            textBox_GE.TabIndex = 9;
            textBox_GE.Text = "≥";
            textBox_GE.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_Filters_MaHSBA
            // 
            textBox_Filters_MaHSBA.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Filters_MaHSBA.BorderStyle = BorderStyle.None;
            textBox_Filters_MaHSBA.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Filters_MaHSBA.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Filters_MaHSBA.Location = new Point(155, 128);
            textBox_Filters_MaHSBA.Name = "textBox_Filters_MaHSBA";
            textBox_Filters_MaHSBA.Size = new Size(105, 32);
            textBox_Filters_MaHSBA.TabIndex = 10;
            // 
            // textBox_Filters_MaTK
            // 
            textBox_Filters_MaTK.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Filters_MaTK.BorderStyle = BorderStyle.None;
            textBox_Filters_MaTK.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Filters_MaTK.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Filters_MaTK.Location = new Point(285, 128);
            textBox_Filters_MaTK.Name = "textBox_Filters_MaTK";
            textBox_Filters_MaTK.Size = new Size(105, 32);
            textBox_Filters_MaTK.TabIndex = 11;
            // 
            // label_Filters_MaBN
            // 
            label_Filters_MaBN.AutoSize = true;
            label_Filters_MaBN.BackColor = Color.Transparent;
            label_Filters_MaBN.FlatStyle = FlatStyle.Flat;
            label_Filters_MaBN.Font = new Font("Segoe UI", 10F);
            label_Filters_MaBN.ForeColor = Color.FromArgb(193, 193, 193);
            label_Filters_MaBN.Location = new Point(25, 84);
            label_Filters_MaBN.Name = "label_Filters_MaBN";
            label_Filters_MaBN.Size = new Size(71, 28);
            label_Filters_MaBN.TabIndex = 12;
            label_Filters_MaBN.Text = "Mã BN";
            label_Filters_MaBN.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_Filters_MaHSBA
            // 
            label_Filters_MaHSBA.AutoSize = true;
            label_Filters_MaHSBA.BackColor = Color.Transparent;
            label_Filters_MaHSBA.FlatStyle = FlatStyle.Flat;
            label_Filters_MaHSBA.Font = new Font("Segoe UI", 10F);
            label_Filters_MaHSBA.ForeColor = Color.FromArgb(193, 193, 193);
            label_Filters_MaHSBA.Location = new Point(155, 84);
            label_Filters_MaHSBA.Name = "label_Filters_MaHSBA";
            label_Filters_MaHSBA.Size = new Size(94, 28);
            label_Filters_MaHSBA.TabIndex = 13;
            label_Filters_MaHSBA.Text = "Mã HSBA";
            label_Filters_MaHSBA.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_Filters_MaTK
            // 
            label_Filters_MaTK.AutoSize = true;
            label_Filters_MaTK.BackColor = Color.Transparent;
            label_Filters_MaTK.FlatStyle = FlatStyle.Flat;
            label_Filters_MaTK.Font = new Font("Segoe UI", 10F);
            label_Filters_MaTK.ForeColor = Color.FromArgb(193, 193, 193);
            label_Filters_MaTK.Location = new Point(285, 84);
            label_Filters_MaTK.Name = "label_Filters_MaTK";
            label_Filters_MaTK.Size = new Size(67, 28);
            label_Filters_MaTK.TabIndex = 14;
            label_Filters_MaTK.Text = "Mã TK";
            label_Filters_MaTK.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_Filters_TenBN
            // 
            label_Filters_TenBN.AutoSize = true;
            label_Filters_TenBN.BackColor = Color.Transparent;
            label_Filters_TenBN.FlatStyle = FlatStyle.Flat;
            label_Filters_TenBN.Font = new Font("Segoe UI", 10F);
            label_Filters_TenBN.ForeColor = Color.FromArgb(193, 193, 193);
            label_Filters_TenBN.Location = new Point(25, 183);
            label_Filters_TenBN.Name = "label_Filters_TenBN";
            label_Filters_TenBN.Size = new Size(71, 28);
            label_Filters_TenBN.TabIndex = 15;
            label_Filters_TenBN.Text = "Họ tên";
            label_Filters_TenBN.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_Filters_Email
            // 
            label_Filters_Email.AutoSize = true;
            label_Filters_Email.BackColor = Color.Transparent;
            label_Filters_Email.FlatStyle = FlatStyle.Flat;
            label_Filters_Email.Font = new Font("Segoe UI", 10F);
            label_Filters_Email.ForeColor = Color.FromArgb(193, 193, 193);
            label_Filters_Email.Location = new Point(25, 282);
            label_Filters_Email.Name = "label_Filters_Email";
            label_Filters_Email.Size = new Size(59, 28);
            label_Filters_Email.TabIndex = 16;
            label_Filters_Email.Text = "Email";
            label_Filters_Email.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_Filters_SDT
            // 
            label_Filters_SDT.AutoSize = true;
            label_Filters_SDT.BackColor = Color.Transparent;
            label_Filters_SDT.FlatStyle = FlatStyle.Flat;
            label_Filters_SDT.Font = new Font("Segoe UI", 10F);
            label_Filters_SDT.ForeColor = Color.FromArgb(193, 193, 193);
            label_Filters_SDT.Location = new Point(25, 381);
            label_Filters_SDT.Name = "label_Filters_SDT";
            label_Filters_SDT.Size = new Size(128, 28);
            label_Filters_SDT.TabIndex = 17;
            label_Filters_SDT.Text = "Số điện thoại";
            label_Filters_SDT.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_Filters_DoanhSo
            // 
            label_Filters_DoanhSo.AutoSize = true;
            label_Filters_DoanhSo.BackColor = Color.Transparent;
            label_Filters_DoanhSo.FlatStyle = FlatStyle.Flat;
            label_Filters_DoanhSo.Font = new Font("Segoe UI", 10F);
            label_Filters_DoanhSo.ForeColor = Color.FromArgb(193, 193, 193);
            label_Filters_DoanhSo.Location = new Point(25, 480);
            label_Filters_DoanhSo.Name = "label_Filters_DoanhSo";
            label_Filters_DoanhSo.Size = new Size(95, 28);
            label_Filters_DoanhSo.TabIndex = 18;
            label_Filters_DoanhSo.Text = "Doanh số";
            label_Filters_DoanhSo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panel_Filter
            // 
            panel_Filter.Anchor = AnchorStyles.Right;
            panel_Filter.AutoScroll = true;
            panel_Filter.BackColor = Color.FromArgb(57, 54, 70);
            panel_Filter.Controls.Add(label_Filters_DoanhSo);
            panel_Filter.Controls.Add(label_Filters_SDT);
            panel_Filter.Controls.Add(label_Filters_Email);
            panel_Filter.Controls.Add(label_Filters_TenBN);
            panel_Filter.Controls.Add(label_Filters_MaTK);
            panel_Filter.Controls.Add(label_Filters_MaHSBA);
            panel_Filter.Controls.Add(label_Filters_MaBN);
            panel_Filter.Controls.Add(textBox_Filters_MaTK);
            panel_Filter.Controls.Add(textBox_Filters_MaHSBA);
            panel_Filter.Controls.Add(textBox_GE);
            panel_Filter.Controls.Add(textBox_Filters_SDT);
            panel_Filter.Controls.Add(textBox_Filters_Email);
            panel_Filter.Controls.Add(textBox_Filters_DoanhSo);
            panel_Filter.Controls.Add(textBox_Filters_TenBN);
            panel_Filter.Controls.Add(button_Filters_OK);
            panel_Filter.Controls.Add(textBox_Filters_MaBN);
            panel_Filter.Controls.Add(label_Filters);
            panel_Filter.Location = new Point(1174, 84);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(416, 780);
            panel_Filter.TabIndex = 1;
            panel_Filter.Paint += panel_BNFilter_Paint;
            // 
            // pageButton_Upload
            // 
            pageButton_Upload.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_Upload.BorderColor = Color.PaleVioletRed;
            pageButton_Upload.BorderRadius = 20;
            pageButton_Upload.BorderSize = 0;
            pageButton_Upload.FlatAppearance.BorderSize = 0;
            pageButton_Upload.FlatStyle = FlatStyle.Flat;
            pageButton_Upload.ForeColor = Color.White;
            pageButton_Upload.Icon = (Image)resources.GetObject("pageButton_Upload.Icon");
            pageButton_Upload.IconLocation = new Point(11, 11);
            pageButton_Upload.IconSize = new Size(34, 34);
            pageButton_Upload.Location = new Point(25, 13);
            pageButton_Upload.Name = "pageButton_Upload";
            pageButton_Upload.Size = new Size(55, 55);
            pageButton_Upload.TabIndex = 1;
            pageButton_Upload.Text1 = "";
            pageButton_Upload.TextColor = Color.Black;
            pageButton_Upload.TextFont = new Font("Segoe UI", 12F);
            pageButton_Upload.TextLocation = new Point(0, 0);
            pageButton_Upload.UseVisualStyleBackColor = false;
            pageButton_Upload.Click += pageButton_Upload_Click;
            // 
            // pageButton_Remove
            // 
            pageButton_Remove.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_Remove.BorderColor = Color.PaleVioletRed;
            pageButton_Remove.BorderRadius = 20;
            pageButton_Remove.BorderSize = 0;
            pageButton_Remove.FlatAppearance.BorderSize = 0;
            pageButton_Remove.FlatStyle = FlatStyle.Flat;
            pageButton_Remove.ForeColor = Color.White;
            pageButton_Remove.Icon = (Image)resources.GetObject("pageButton_Remove.Icon");
            pageButton_Remove.IconLocation = new Point(11, 11);
            pageButton_Remove.IconSize = new Size(34, 34);
            pageButton_Remove.Location = new Point(90, 13);
            pageButton_Remove.Name = "pageButton_Remove";
            pageButton_Remove.Size = new Size(55, 55);
            pageButton_Remove.TabIndex = 2;
            pageButton_Remove.Text1 = "";
            pageButton_Remove.TextColor = Color.Black;
            pageButton_Remove.TextFont = new Font("Segoe UI", 12F);
            pageButton_Remove.TextLocation = new Point(0, 0);
            pageButton_Remove.UseVisualStyleBackColor = false;
            pageButton_Remove.Click += pageButton_Remove_Click;
            // 
            // pageButton_Filter
            // 
            pageButton_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pageButton_Filter.BackColor = Color.FromArgb(57, 54, 70);
            pageButton_Filter.BorderColor = Color.PaleVioletRed;
            pageButton_Filter.BorderRadius = 20;
            pageButton_Filter.BorderSize = 0;
            pageButton_Filter.FlatAppearance.BorderSize = 0;
            pageButton_Filter.FlatStyle = FlatStyle.Flat;
            pageButton_Filter.ForeColor = Color.White;
            pageButton_Filter.Icon = (Image)resources.GetObject("pageButton_Filter.Icon");
            pageButton_Filter.IconLocation = new Point(11, 11);
            pageButton_Filter.IconSize = new Size(34, 34);
            pageButton_Filter.Location = new Point(1094, 13);
            pageButton_Filter.Name = "pageButton_Filter";
            pageButton_Filter.Size = new Size(55, 55);
            pageButton_Filter.TabIndex = 3;
            pageButton_Filter.Text1 = "";
            pageButton_Filter.TextColor = Color.Black;
            pageButton_Filter.TextFont = new Font("Segoe UI", 12F);
            pageButton_Filter.TextLocation = new Point(0, 0);
            pageButton_Filter.UseVisualStyleBackColor = false;
            pageButton_Filter.Click += pageButton_Filters_Click;
            // 
            // panel_Toolbar
            // 
            panel_Toolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Toolbar.BackColor = Color.FromArgb(57, 54, 70);
            panel_Toolbar.Controls.Add(pageButton_Filter);
            panel_Toolbar.Controls.Add(pageButton_Remove);
            panel_Toolbar.Controls.Add(pageButton_Upload);
            panel_Toolbar.Location = new Point(0, 84);
            panel_Toolbar.Name = "panel_Toolbar";
            panel_Toolbar.Size = new Size(1174, 80);
            panel_Toolbar.TabIndex = 0;
            // 
            // label_BNUpload
            // 
            label_BNUpload.AutoSize = true;
            label_BNUpload.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_BNUpload.ForeColor = Color.White;
            label_BNUpload.Location = new Point(15, 8);
            label_BNUpload.Name = "label_BNUpload";
            label_BNUpload.Size = new Size(110, 38);
            label_BNUpload.TabIndex = 2;
            label_BNUpload.Text = "Upload";
            // 
            // textBox_BNUpload_MaBN
            // 
            textBox_BNUpload_MaBN.BackColor = Color.FromArgb(57, 54, 70);
            textBox_BNUpload_MaBN.BorderStyle = BorderStyle.None;
            textBox_BNUpload_MaBN.Font = new Font("Segoe UI Semilight", 12F);
            textBox_BNUpload_MaBN.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_BNUpload_MaBN.Location = new Point(25, 128);
            textBox_BNUpload_MaBN.Name = "textBox_BNUpload_MaBN";
            textBox_BNUpload_MaBN.Size = new Size(366, 32);
            textBox_BNUpload_MaBN.TabIndex = 3;
            textBox_BNUpload_MaBN.KeyPress += button_KeyPress_Normal;
            // 
            // button_Upload_OK
            // 
            button_Upload_OK.FlatStyle = FlatStyle.Flat;
            button_Upload_OK.Font = new Font("Segoe UI", 10F);
            button_Upload_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_Upload_OK.Location = new Point(25, 710);
            button_Upload_OK.Name = "button_Upload_OK";
            button_Upload_OK.Size = new Size(94, 43);
            button_Upload_OK.TabIndex = 4;
            button_Upload_OK.Text = "OK";
            button_Upload_OK.UseVisualStyleBackColor = true;
            button_Upload_OK.Click += button_BNUpload_OK_Click;
            // 
            // textBox_BNUpload_TenBN
            // 
            textBox_BNUpload_TenBN.BackColor = Color.FromArgb(57, 54, 70);
            textBox_BNUpload_TenBN.BorderStyle = BorderStyle.None;
            textBox_BNUpload_TenBN.Font = new Font("Segoe UI Semilight", 12F);
            textBox_BNUpload_TenBN.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_BNUpload_TenBN.Location = new Point(25, 227);
            textBox_BNUpload_TenBN.Name = "textBox_BNUpload_TenBN";
            textBox_BNUpload_TenBN.Size = new Size(366, 32);
            textBox_BNUpload_TenBN.TabIndex = 5;
            textBox_BNUpload_TenBN.KeyPress += button_KeyPress_Normal;
            // 
            // textBox_BNUpload_SDT
            // 
            textBox_BNUpload_SDT.BackColor = Color.FromArgb(57, 54, 70);
            textBox_BNUpload_SDT.BorderStyle = BorderStyle.None;
            textBox_BNUpload_SDT.Font = new Font("Segoe UI Semilight", 12F);
            textBox_BNUpload_SDT.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_BNUpload_SDT.Location = new Point(25, 425);
            textBox_BNUpload_SDT.Name = "textBox_BNUpload_SDT";
            textBox_BNUpload_SDT.Size = new Size(164, 32);
            textBox_BNUpload_SDT.TabIndex = 6;
            textBox_BNUpload_SDT.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // textBox_BNUpload_Email
            // 
            textBox_BNUpload_Email.BackColor = Color.FromArgb(57, 54, 70);
            textBox_BNUpload_Email.BorderStyle = BorderStyle.None;
            textBox_BNUpload_Email.Font = new Font("Segoe UI Semilight", 12F);
            textBox_BNUpload_Email.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_BNUpload_Email.Location = new Point(25, 524);
            textBox_BNUpload_Email.Name = "textBox_BNUpload_Email";
            textBox_BNUpload_Email.Size = new Size(366, 32);
            textBox_BNUpload_Email.TabIndex = 7;
            textBox_BNUpload_Email.KeyPress += button_KeyPress_Normal;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(193, 193, 193);
            label2.ImageAlign = ContentAlignment.BottomCenter;
            label2.Location = new Point(25, 84);
            label2.Name = "label2";
            label2.Size = new Size(137, 28);
            label2.TabIndex = 9;
            label2.Text = "Mã bệnh nhân";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(193, 193, 193);
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(25, 183);
            label3.Name = "label3";
            label3.Size = new Size(71, 28);
            label3.TabIndex = 10;
            label3.Text = "Họ tên";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(193, 193, 193);
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(25, 282);
            label4.Name = "label4";
            label4.Size = new Size(59, 28);
            label4.TabIndex = 11;
            label4.Text = "Ngày";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_BNUpload_Ngay
            // 
            textBox_BNUpload_Ngay.BackColor = Color.FromArgb(57, 54, 70);
            textBox_BNUpload_Ngay.BorderStyle = BorderStyle.None;
            textBox_BNUpload_Ngay.Font = new Font("Segoe UI Semilight", 12F);
            textBox_BNUpload_Ngay.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_BNUpload_Ngay.Location = new Point(25, 326);
            textBox_BNUpload_Ngay.Name = "textBox_BNUpload_Ngay";
            textBox_BNUpload_Ngay.Size = new Size(59, 32);
            textBox_BNUpload_Ngay.TabIndex = 12;
            textBox_BNUpload_Ngay.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(193, 193, 193);
            label5.ImageAlign = ContentAlignment.BottomCenter;
            label5.Location = new Point(25, 381);
            label5.Name = "label5";
            label5.Size = new Size(128, 28);
            label5.TabIndex = 13;
            label5.Text = "Số điện thoại";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(193, 193, 193);
            label6.ImageAlign = ContentAlignment.BottomCenter;
            label6.Location = new Point(124, 284);
            label6.Name = "label6";
            label6.Size = new Size(66, 28);
            label6.TabIndex = 15;
            label6.Text = "Tháng";
            label6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // comboBox_BNUpload_Thang
            // 
            comboBox_BNUpload_Thang.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_BNUpload_Thang.FlatStyle = FlatStyle.Flat;
            comboBox_BNUpload_Thang.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_BNUpload_Thang.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_BNUpload_Thang.FormattingEnabled = true;
            comboBox_BNUpload_Thang.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            comboBox_BNUpload_Thang.Location = new Point(124, 318);
            comboBox_BNUpload_Thang.Name = "comboBox_BNUpload_Thang";
            comboBox_BNUpload_Thang.Size = new Size(85, 40);
            comboBox_BNUpload_Thang.TabIndex = 16;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(193, 193, 193);
            label7.ImageAlign = ContentAlignment.BottomCenter;
            label7.Location = new Point(249, 284);
            label7.Name = "label7";
            label7.Size = new Size(54, 28);
            label7.TabIndex = 17;
            label7.Text = "Năm";
            label7.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_BNUpload_Nam
            // 
            textBox_BNUpload_Nam.BackColor = Color.FromArgb(57, 54, 70);
            textBox_BNUpload_Nam.BorderStyle = BorderStyle.None;
            textBox_BNUpload_Nam.Font = new Font("Segoe UI Semilight", 12F);
            textBox_BNUpload_Nam.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_BNUpload_Nam.Location = new Point(249, 326);
            textBox_BNUpload_Nam.Name = "textBox_BNUpload_Nam";
            textBox_BNUpload_Nam.Size = new Size(85, 32);
            textBox_BNUpload_Nam.TabIndex = 18;
            textBox_BNUpload_Nam.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(193, 193, 193);
            label8.ImageAlign = ContentAlignment.BottomCenter;
            label8.Location = new Point(25, 480);
            label8.Name = "label8";
            label8.Size = new Size(59, 28);
            label8.TabIndex = 19;
            label8.Text = "Email";
            label8.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(193, 193, 193);
            label9.ImageAlign = ContentAlignment.BottomCenter;
            label9.Location = new Point(233, 381);
            label9.Name = "label9";
            label9.Size = new Size(87, 28);
            label9.TabIndex = 20;
            label9.Text = "Giới tính";
            label9.TextAlign = ContentAlignment.BottomLeft;
            // 
            // checkBox_BNUpload_Nam
            // 
            checkBox_BNUpload_Nam.AutoSize = true;
            checkBox_BNUpload_Nam.Checked = true;
            checkBox_BNUpload_Nam.CheckState = CheckState.Checked;
            checkBox_BNUpload_Nam.FlatStyle = FlatStyle.Flat;
            checkBox_BNUpload_Nam.Font = new Font("Segoe UI", 10F);
            checkBox_BNUpload_Nam.ForeColor = Color.White;
            checkBox_BNUpload_Nam.Location = new Point(233, 425);
            checkBox_BNUpload_Nam.Name = "checkBox_BNUpload_Nam";
            checkBox_BNUpload_Nam.Size = new Size(75, 32);
            checkBox_BNUpload_Nam.TabIndex = 21;
            checkBox_BNUpload_Nam.Text = "Nam";
            checkBox_BNUpload_Nam.UseVisualStyleBackColor = true;
            checkBox_BNUpload_Nam.CheckedChanged += checkBox_BNUpload_Nam_CheckedChanged;
            // 
            // checkBox_BNUpload_Nu
            // 
            checkBox_BNUpload_Nu.AutoSize = true;
            checkBox_BNUpload_Nu.FlatStyle = FlatStyle.Flat;
            checkBox_BNUpload_Nu.Font = new Font("Segoe UI", 10F);
            checkBox_BNUpload_Nu.ForeColor = Color.White;
            checkBox_BNUpload_Nu.Location = new Point(324, 425);
            checkBox_BNUpload_Nu.Name = "checkBox_BNUpload_Nu";
            checkBox_BNUpload_Nu.Size = new Size(60, 32);
            checkBox_BNUpload_Nu.TabIndex = 22;
            checkBox_BNUpload_Nu.Text = "Nữ";
            checkBox_BNUpload_Nu.UseVisualStyleBackColor = true;
            checkBox_BNUpload_Nu.CheckedChanged += checkBox_BNUpload_Nu_CheckedChanged;
            // 
            // panel_Upload
            // 
            panel_Upload.Anchor = AnchorStyles.Right;
            panel_Upload.AutoScroll = true;
            panel_Upload.AutoSize = true;
            panel_Upload.BackColor = Color.FromArgb(57, 54, 70);
            panel_Upload.Controls.Add(checkBox_BNUpload_Nu);
            panel_Upload.Controls.Add(checkBox_BNUpload_Nam);
            panel_Upload.Controls.Add(label9);
            panel_Upload.Controls.Add(label8);
            panel_Upload.Controls.Add(textBox_BNUpload_Nam);
            panel_Upload.Controls.Add(label7);
            panel_Upload.Controls.Add(comboBox_BNUpload_Thang);
            panel_Upload.Controls.Add(label6);
            panel_Upload.Controls.Add(label5);
            panel_Upload.Controls.Add(textBox_BNUpload_Ngay);
            panel_Upload.Controls.Add(label4);
            panel_Upload.Controls.Add(label3);
            panel_Upload.Controls.Add(label2);
            panel_Upload.Controls.Add(textBox_BNUpload_Email);
            panel_Upload.Controls.Add(textBox_BNUpload_SDT);
            panel_Upload.Controls.Add(textBox_BNUpload_TenBN);
            panel_Upload.Controls.Add(button_Upload_OK);
            panel_Upload.Controls.Add(textBox_BNUpload_MaBN);
            panel_Upload.Controls.Add(label_BNUpload);
            panel_Upload.Location = new Point(1174, 84);
            panel_Upload.Name = "panel_Upload";
            panel_Upload.Size = new Size(416, 780);
            panel_Upload.TabIndex = 10;
            panel_Upload.Paint += panel_BNUpload_Paint;
            // 
            // customDataGridView_BenhNhan
            // 
            customDataGridView_BenhNhan.AllowUserToAddRows = false;
            customDataGridView_BenhNhan.AllowUserToDeleteRows = false;
            customDataGridView_BenhNhan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customDataGridView_BenhNhan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            customDataGridView_BenhNhan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            customDataGridView_BenhNhan.BackgroundColor = Color.White;
            customDataGridView_BenhNhan.BorderStyle = BorderStyle.None;
            customDataGridView_BenhNhan.CellBorderStyle = DataGridViewCellBorderStyle.None;
            customDataGridView_BenhNhan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(79, 69, 87);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 0, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            customDataGridView_BenhNhan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            customDataGridView_BenhNhan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customDataGridView_BenhNhan.CornerRadius = 60;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semilight", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(15, 0, 5, 5);
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            customDataGridView_BenhNhan.DefaultCellStyle = dataGridViewCellStyle2;
            customDataGridView_BenhNhan.EnableHeadersVisualStyles = false;
            customDataGridView_BenhNhan.GridColor = Color.White;
            customDataGridView_BenhNhan.Location = new Point(25, 168);
            customDataGridView_BenhNhan.Name = "customDataGridView_BenhNhan";
            customDataGridView_BenhNhan.ReadOnly = true;
            customDataGridView_BenhNhan.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            customDataGridView_BenhNhan.RowHeadersVisible = false;
            customDataGridView_BenhNhan.RowHeadersWidth = 62;
            customDataGridView_BenhNhan.Size = new Size(1124, 600);
            customDataGridView_BenhNhan.TabIndex = 13;
            // 
            // customPanel_Sum
            // 
            customPanel_Sum.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customPanel_Sum.BackColor = Color.FromArgb(79, 69, 87);
            customPanel_Sum.Controls.Add(label_HienThiDTTong);
            customPanel_Sum.Controls.Add(label_HienThiSoBN);
            customPanel_Sum.Controls.Add(label_DoanhThuTong);
            customPanel_Sum.Controls.Add(label_SoBenhNhan);
            customPanel_Sum.CornerRadius = 40;
            customPanel_Sum.Location = new Point(25, 787);
            customPanel_Sum.Name = "customPanel_Sum";
            customPanel_Sum.Size = new Size(1124, 60);
            customPanel_Sum.TabIndex = 14;
            // 
            // label_HienThiDTTong
            // 
            label_HienThiDTTong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_HienThiDTTong.AutoSize = true;
            label_HienThiDTTong.BackColor = Color.Transparent;
            label_HienThiDTTong.Font = new Font("Segoe UI Semilight", 10F);
            label_HienThiDTTong.ForeColor = Color.White;
            label_HienThiDTTong.Location = new Point(672, 14);
            label_HienThiDTTong.Name = "label_HienThiDTTong";
            label_HienThiDTTong.Size = new Size(23, 28);
            label_HienThiDTTong.TabIndex = 3;
            label_HienThiDTTong.Text = "0";
            // 
            // label_HienThiSoBN
            // 
            label_HienThiSoBN.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label_HienThiSoBN.AutoSize = true;
            label_HienThiSoBN.BackColor = Color.Transparent;
            label_HienThiSoBN.Font = new Font("Segoe UI Semilight", 10F);
            label_HienThiSoBN.ForeColor = Color.White;
            label_HienThiSoBN.Location = new Point(191, 14);
            label_HienThiSoBN.Name = "label_HienThiSoBN";
            label_HienThiSoBN.Size = new Size(23, 28);
            label_HienThiSoBN.TabIndex = 2;
            label_HienThiSoBN.Text = "0";
            // 
            // label_DoanhThuTong
            // 
            label_DoanhThuTong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label_DoanhThuTong.AutoSize = true;
            label_DoanhThuTong.BackColor = Color.Transparent;
            label_DoanhThuTong.Font = new Font("Segoe UI Semilight", 10F);
            label_DoanhThuTong.ForeColor = Color.White;
            label_DoanhThuTong.Location = new Point(481, 14);
            label_DoanhThuTong.Name = "label_DoanhThuTong";
            label_DoanhThuTong.Size = new Size(150, 28);
            label_DoanhThuTong.TabIndex = 1;
            label_DoanhThuTong.Text = "Doanh thu tổng:";
            // 
            // label_SoBenhNhan
            // 
            label_SoBenhNhan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label_SoBenhNhan.AutoSize = true;
            label_SoBenhNhan.BackColor = Color.Transparent;
            label_SoBenhNhan.Font = new Font("Segoe UI Semilight", 10F);
            label_SoBenhNhan.ForeColor = Color.White;
            label_SoBenhNhan.Location = new Point(23, 14);
            label_SoBenhNhan.Name = "label_SoBenhNhan";
            label_SoBenhNhan.Size = new Size(133, 28);
            label_SoBenhNhan.TabIndex = 0;
            label_SoBenhNhan.Text = "Số bệnh nhân:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(57, 54, 70);
            panel1.Controls.Add(pageButton6);
            panel1.Controls.Add(pageButton5);
            panel1.Controls.Add(pageButton2);
            panel1.Controls.Add(pageButton1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1590, 84);
            panel1.TabIndex = 15;
            // 
            // pageButton6
            // 
            pageButton6.BackColor = Color.FromArgb(57, 54, 70);
            pageButton6.BorderColor = Color.PaleVioletRed;
            pageButton6.BorderRadius = 40;
            pageButton6.BorderSize = 0;
            pageButton6.FlatAppearance.BorderSize = 0;
            pageButton6.FlatStyle = FlatStyle.Flat;
            pageButton6.ForeColor = Color.White;
            pageButton6.Icon = (Image)resources.GetObject("pageButton6.Icon");
            pageButton6.IconLocation = new Point(112, 30);
            pageButton6.IconSize = new Size(50, 50);
            pageButton6.Location = new Point(323, 12);
            pageButton6.Name = "pageButton6";
            pageButton6.Size = new Size(225, 60);
            pageButton6.TabIndex = 8;
            pageButton6.Text1 = "Bệnh nhân";
            pageButton6.TextColor = Color.White;
            pageButton6.TextFont = new Font("Segoe UI", 12F);
            pageButton6.TextLocation = new Point(10, 12);
            pageButton6.UseVisualStyleBackColor = false;
            // 
            // pageButton5
            // 
            pageButton5.BackColor = Color.FromArgb(57, 54, 70);
            pageButton5.BorderColor = Color.PaleVioletRed;
            pageButton5.BorderRadius = 40;
            pageButton5.BorderSize = 0;
            pageButton5.FlatAppearance.BorderSize = 0;
            pageButton5.FlatStyle = FlatStyle.Flat;
            pageButton5.ForeColor = Color.White;
            pageButton5.Icon = (Image)resources.GetObject("pageButton5.Icon");
            pageButton5.IconLocation = new Point(112, 30);
            pageButton5.IconSize = new Size(50, 50);
            pageButton5.Location = new Point(612, 12);
            pageButton5.Name = "pageButton5";
            pageButton5.Size = new Size(225, 60);
            pageButton5.TabIndex = 7;
            pageButton5.Text1 = "Bệnh nhân";
            pageButton5.TextColor = Color.White;
            pageButton5.TextFont = new Font("Segoe UI", 12F);
            pageButton5.TextLocation = new Point(10, 12);
            pageButton5.UseVisualStyleBackColor = false;
            pageButton5.Click += pageButton5_Click;
            // 
            // pageButton2
            // 
            pageButton2.BackColor = Color.FromArgb(57, 54, 70);
            pageButton2.BorderColor = Color.PaleVioletRed;
            pageButton2.BorderRadius = 40;
            pageButton2.BorderSize = 0;
            pageButton2.FlatAppearance.BorderSize = 0;
            pageButton2.FlatStyle = FlatStyle.Flat;
            pageButton2.ForeColor = Color.White;
            pageButton2.Icon = (Image)resources.GetObject("pageButton2.Icon");
            pageButton2.IconLocation = new Point(112, 30);
            pageButton2.IconSize = new Size(50, 50);
            pageButton2.Location = new Point(25, 12);
            pageButton2.Name = "pageButton2";
            pageButton2.Size = new Size(225, 60);
            pageButton2.TabIndex = 4;
            pageButton2.Text1 = "Bệnh nhân";
            pageButton2.TextColor = Color.White;
            pageButton2.TextFont = new Font("Segoe UI", 12F);
            pageButton2.TextLocation = new Point(10, 12);
            pageButton2.UseVisualStyleBackColor = false;
            // 
            // pageButton1
            // 
            pageButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pageButton1.BackColor = Color.FromArgb(57, 54, 70);
            pageButton1.BorderColor = Color.PaleVioletRed;
            pageButton1.BorderRadius = 20;
            pageButton1.BorderSize = 0;
            pageButton1.FlatAppearance.BorderSize = 0;
            pageButton1.FlatStyle = FlatStyle.Flat;
            pageButton1.ForeColor = Color.White;
            pageButton1.Icon = (Image)resources.GetObject("pageButton1.Icon");
            pageButton1.IconLocation = new Point(11, 11);
            pageButton1.IconSize = new Size(34, 34);
            pageButton1.Location = new Point(2484, 13);
            pageButton1.Name = "pageButton1";
            pageButton1.Size = new Size(55, 55);
            pageButton1.TabIndex = 3;
            pageButton1.Text1 = "";
            pageButton1.TextColor = Color.Black;
            pageButton1.TextFont = new Font("Segoe UI", 12F);
            pageButton1.TextLocation = new Point(0, 0);
            pageButton1.UseVisualStyleBackColor = false;
            // 
            // BenhNhanControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(57, 54, 70);
            Controls.Add(panel1);
            Controls.Add(customPanel_Sum);
            Controls.Add(customDataGridView_BenhNhan);
            Controls.Add(panel_Toolbar);
            Controls.Add(panel_Filter);
            Controls.Add(panel_Upload);
            Name = "BenhNhanControl";
            Size = new Size(1590, 864);
            panel_Filter.ResumeLayout(false);
            panel_Filter.PerformLayout();
            panel_Toolbar.ResumeLayout(false);
            panel_Upload.ResumeLayout(false);
            panel_Upload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customDataGridView_BenhNhan).EndInit();
            customPanel_Sum.ResumeLayout(false);
            customPanel_Sum.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Filters;
        private TextBox textBox_Filters_MaBN;
        private Button button_Filters_OK;
        private TextBox textBox_Filters_TenBN;
        private TextBox textBox_Filters_DoanhSo;
        private TextBox textBox_Filters_Email;
        private TextBox textBox_Filters_SDT;
        private TextBox textBox_GE;
        private TextBox textBox_Filters_MaHSBA;
        private TextBox textBox_Filters_MaTK;
        private Label label_Filters_MaBN;
        private Label label_Filters_MaHSBA;
        private Label label_Filters_MaTK;
        private Label label_Filters_TenBN;
        private Label label_Filters_Email;
        private Label label_Filters_SDT;
        private Label label_Filters_DoanhSo;
        private Panel panel_Filter;
        private PageButton pageButton_Upload;
        private PageButton pageButton_Remove;
        private PageButton pageButton_Filter;
        private Panel panel_Toolbar;
        private Label label_BNUpload;
        private TextBox textBox_BNUpload_MaBN;
        private Button button_Upload_OK;
        private TextBox textBox_BNUpload_TenBN;
        private TextBox textBox_BNUpload_SDT;
        private TextBox textBox_BNUpload_Email;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox_BNUpload_Ngay;
        private Label label5;
        private Label label6;
        private ComboBox comboBox_BNUpload_Thang;
        private Label label7;
        private TextBox textBox_BNUpload_Nam;
        private Label label8;
        private Label label9;
        private CheckBox checkBox_BNUpload_Nam;
        private CheckBox checkBox_BNUpload_Nu;
        private Panel panel_Upload;
        private CustomDataGridView customDataGridView_BenhNhan;
        private CustomPanel customPanel_Sum;
        private Label label_SoBenhNhan;
        private Label label_DoanhThuTong;
        private Label label_HienThiDTTong;
        private Label label_HienThiSoBN;
        private Panel panel1;
        private PageButton pageButton2;
        private PageButton pageButton1;
        private PageButton pageButton6;
        private PageButton pageButton5;
    }
}
