namespace QuanLyMachTu
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DichVuControl));
            panel_TopPanel = new Panel();
            panel_Toolbar = new Panel();
            customDataGridView = new Custom.CustomDataGridView();
            panel_DV_Upload = new Panel();
            label_DV_Upload = new Label();
            label_DV_MaDV = new Label();
            pageButton_DV = new Custom.PageButton();
            pageButton1 = new Custom.PageButton();
            pageButton_Filter = new Custom.PageButton();
            pageButton_Remove = new Custom.PageButton();
            pageButton_Upload = new Custom.PageButton();
            textBox_DV_MaDV = new TextBox();
            label_DV_ChiPhi = new Label();
            textBox_DV_ChiPhi = new TextBox();
            textBox_DV_TenDV = new TextBox();
            label_DV_TenDV = new Label();
            textBox_DV_MoTa = new TextBox();
            label_DV_MoTa = new Label();
            button_DV_OK = new Button();
            panel_DV_Filter = new Panel();
            button_DV_OK_Filter = new Button();
            textBox_DV_TenDV_Filter = new TextBox();
            label2 = new Label();
            textBox_DV_ChiPhi_Filter = new TextBox();
            label3 = new Label();
            textBox_DV_MaDV_Filter = new TextBox();
            label4 = new Label();
            label5 = new Label();
            comboBox_DV_Filter_Operation = new ComboBox();
            panel_TopPanel.SuspendLayout();
            panel_Toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customDataGridView).BeginInit();
            panel_DV_Upload.SuspendLayout();
            panel_DV_Filter.SuspendLayout();
            SuspendLayout();
            // 
            // panel_TopPanel
            // 
            panel_TopPanel.Controls.Add(pageButton1);
            panel_TopPanel.Controls.Add(pageButton_DV);
            panel_TopPanel.Dock = DockStyle.Top;
            panel_TopPanel.Location = new Point(0, 0);
            panel_TopPanel.Name = "panel_TopPanel";
            panel_TopPanel.Size = new Size(1272, 67);
            panel_TopPanel.TabIndex = 0;
            // 
            // panel_Toolbar
            // 
            panel_Toolbar.Controls.Add(pageButton_Filter);
            panel_Toolbar.Controls.Add(pageButton_Remove);
            panel_Toolbar.Controls.Add(pageButton_Upload);
            panel_Toolbar.Location = new Point(0, 67);
            panel_Toolbar.Name = "panel_Toolbar";
            panel_Toolbar.Size = new Size(939, 64);
            panel_Toolbar.TabIndex = 1;
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
            customDataGridView.Location = new Point(20, 134);
            customDataGridView.Margin = new Padding(2);
            customDataGridView.Name = "customDataGridView";
            customDataGridView.ReadOnly = true;
            customDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            customDataGridView.RowHeadersVisible = false;
            customDataGridView.RowHeadersWidth = 62;
            customDataGridView.Size = new Size(899, 480);
            customDataGridView.TabIndex = 23;
            // 
            // panel_DV_Upload
            // 
            panel_DV_Upload.Anchor = AnchorStyles.Right;
            panel_DV_Upload.AutoSize = true;
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
            panel_DV_Upload.Location = new Point(939, 67);
            panel_DV_Upload.Name = "panel_DV_Upload";
            panel_DV_Upload.Size = new Size(333, 624);
            panel_DV_Upload.TabIndex = 24;
            // 
            // label_DV_Upload
            // 
            label_DV_Upload.AutoSize = true;
            label_DV_Upload.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_DV_Upload.ForeColor = Color.White;
            label_DV_Upload.Location = new Point(18, 17);
            label_DV_Upload.Name = "label_DV_Upload";
            label_DV_Upload.Size = new Size(92, 32);
            label_DV_Upload.TabIndex = 0;
            label_DV_Upload.Text = "Upload";
            // 
            // label_DV_MaDV
            // 
            label_DV_MaDV.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_MaDV.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_MaDV.Location = new Point(18, 67);
            label_DV_MaDV.Name = "label_DV_MaDV";
            label_DV_MaDV.Size = new Size(98, 25);
            label_DV_MaDV.TabIndex = 1;
            label_DV_MaDV.Text = "Mã dịch vụ";
            // 
            // pageButton_DV
            // 
            pageButton_DV.Anchor = AnchorStyles.Top;
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
            pageButton_DV.Location = new Point(20, 10);
            pageButton_DV.Margin = new Padding(2);
            pageButton_DV.Name = "pageButton_DV";
            pageButton_DV.Size = new Size(200, 48);
            pageButton_DV.TabIndex = 10;
            pageButton_DV.TextLocation = new Point(64, 12);
            pageButton_DV.UseVisualStyleBackColor = false;
            // 
            // pageButton1
            // 
            pageButton1.Anchor = AnchorStyles.Top;
            pageButton1.BackColor = Color.FromArgb(57, 54, 70);
            pageButton1.BorderColor = Color.PaleVioletRed;
            pageButton1.BorderRadius = 40;
            pageButton1.BorderSize = 0;
            pageButton1.CustomText = "Dịch vụ";
            pageButton1.FlatAppearance.BorderSize = 0;
            pageButton1.FlatStyle = FlatStyle.Flat;
            pageButton1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            pageButton1.ForeColor = Color.FromArgb(193, 193, 193);
            pageButton1.Icon = (Image)resources.GetObject("pageButton1.Icon");
            pageButton1.IconLocation = new Point(15, 13);
            pageButton1.IconSize = new Size(30, 30);
            pageButton1.Location = new Point(224, 10);
            pageButton1.Margin = new Padding(2);
            pageButton1.Name = "pageButton1";
            pageButton1.Size = new Size(200, 48);
            pageButton1.TabIndex = 11;
            pageButton1.TextLocation = new Point(64, 12);
            pageButton1.UseVisualStyleBackColor = false;
            // 
            // pageButton_Filter
            // 
            pageButton_Filter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
            pageButton_Filter.Location = new Point(875, 10);
            pageButton_Filter.Margin = new Padding(2);
            pageButton_Filter.Name = "pageButton_Filter";
            pageButton_Filter.Size = new Size(44, 44);
            pageButton_Filter.TabIndex = 6;
            pageButton_Filter.TextLocation = new Point(0, 0);
            pageButton_Filter.UseVisualStyleBackColor = false;
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
            pageButton_Remove.Location = new Point(72, 10);
            pageButton_Remove.Margin = new Padding(2);
            pageButton_Remove.Name = "pageButton_Remove";
            pageButton_Remove.Size = new Size(44, 44);
            pageButton_Remove.TabIndex = 5;
            pageButton_Remove.TextLocation = new Point(0, 0);
            pageButton_Remove.UseVisualStyleBackColor = false;
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
            pageButton_Upload.Location = new Point(20, 10);
            pageButton_Upload.Margin = new Padding(2);
            pageButton_Upload.Name = "pageButton_Upload";
            pageButton_Upload.Size = new Size(44, 44);
            pageButton_Upload.TabIndex = 4;
            pageButton_Upload.TextLocation = new Point(0, 0);
            pageButton_Upload.UseVisualStyleBackColor = false;
            // 
            // textBox_DV_MaDV
            // 
            textBox_DV_MaDV.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_MaDV.BorderStyle = BorderStyle.None;
            textBox_DV_MaDV.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_MaDV.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_MaDV.Location = new Point(18, 108);
            textBox_DV_MaDV.Margin = new Padding(2);
            textBox_DV_MaDV.Name = "textBox_DV_MaDV";
            textBox_DV_MaDV.Size = new Size(125, 27);
            textBox_DV_MaDV.TabIndex = 4;
            // 
            // label_DV_ChiPhi
            // 
            label_DV_ChiPhi.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_ChiPhi.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_ChiPhi.Location = new Point(161, 67);
            label_DV_ChiPhi.Name = "label_DV_ChiPhi";
            label_DV_ChiPhi.Size = new Size(98, 25);
            label_DV_ChiPhi.TabIndex = 5;
            label_DV_ChiPhi.Text = "Chi phí";
            // 
            // textBox_DV_ChiPhi
            // 
            textBox_DV_ChiPhi.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_ChiPhi.BorderStyle = BorderStyle.None;
            textBox_DV_ChiPhi.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_ChiPhi.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_ChiPhi.Location = new Point(161, 108);
            textBox_DV_ChiPhi.Margin = new Padding(2);
            textBox_DV_ChiPhi.Name = "textBox_DV_ChiPhi";
            textBox_DV_ChiPhi.Size = new Size(151, 27);
            textBox_DV_ChiPhi.TabIndex = 6;
            // 
            // textBox_DV_TenDV
            // 
            textBox_DV_TenDV.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_TenDV.BorderStyle = BorderStyle.None;
            textBox_DV_TenDV.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_TenDV.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_TenDV.Location = new Point(18, 190);
            textBox_DV_TenDV.Margin = new Padding(2);
            textBox_DV_TenDV.Name = "textBox_DV_TenDV";
            textBox_DV_TenDV.Size = new Size(294, 27);
            textBox_DV_TenDV.TabIndex = 8;
            // 
            // label_DV_TenDV
            // 
            label_DV_TenDV.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_TenDV.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_TenDV.Location = new Point(18, 149);
            label_DV_TenDV.Name = "label_DV_TenDV";
            label_DV_TenDV.Size = new Size(98, 25);
            label_DV_TenDV.TabIndex = 7;
            label_DV_TenDV.Text = "Tên dịch vụ";
            // 
            // textBox_DV_MoTa
            // 
            textBox_DV_MoTa.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_MoTa.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_MoTa.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_MoTa.Location = new Point(18, 277);
            textBox_DV_MoTa.Margin = new Padding(2);
            textBox_DV_MoTa.Multiline = true;
            textBox_DV_MoTa.Name = "textBox_DV_MoTa";
            textBox_DV_MoTa.Size = new Size(294, 270);
            textBox_DV_MoTa.TabIndex = 29;
            // 
            // label_DV_MoTa
            // 
            label_DV_MoTa.AutoSize = true;
            label_DV_MoTa.BackColor = Color.Transparent;
            label_DV_MoTa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DV_MoTa.ForeColor = Color.FromArgb(193, 193, 193);
            label_DV_MoTa.ImageAlign = ContentAlignment.BottomCenter;
            label_DV_MoTa.Location = new Point(18, 242);
            label_DV_MoTa.Margin = new Padding(2, 0, 2, 0);
            label_DV_MoTa.Name = "label_DV_MoTa";
            label_DV_MoTa.Size = new Size(55, 23);
            label_DV_MoTa.TabIndex = 28;
            label_DV_MoTa.Text = "Mô tả";
            label_DV_MoTa.TextAlign = ContentAlignment.BottomLeft;
            // 
            // button_DV_OK
            // 
            button_DV_OK.FlatStyle = FlatStyle.Flat;
            button_DV_OK.Font = new Font("Segoe UI", 10F);
            button_DV_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_DV_OK.Location = new Point(18, 567);
            button_DV_OK.Margin = new Padding(2);
            button_DV_OK.Name = "button_DV_OK";
            button_DV_OK.Size = new Size(75, 34);
            button_DV_OK.TabIndex = 30;
            button_DV_OK.Text = "OK";
            button_DV_OK.UseVisualStyleBackColor = true;
            // 
            // panel_DV_Filter
            // 
            panel_DV_Filter.Anchor = AnchorStyles.Right;
            panel_DV_Filter.AutoSize = true;
            panel_DV_Filter.Controls.Add(comboBox_DV_Filter_Operation);
            panel_DV_Filter.Controls.Add(button_DV_OK_Filter);
            panel_DV_Filter.Controls.Add(textBox_DV_TenDV_Filter);
            panel_DV_Filter.Controls.Add(label2);
            panel_DV_Filter.Controls.Add(textBox_DV_ChiPhi_Filter);
            panel_DV_Filter.Controls.Add(label3);
            panel_DV_Filter.Controls.Add(textBox_DV_MaDV_Filter);
            panel_DV_Filter.Controls.Add(label4);
            panel_DV_Filter.Controls.Add(label5);
            panel_DV_Filter.Location = new Point(939, 67);
            panel_DV_Filter.Name = "panel_DV_Filter";
            panel_DV_Filter.Size = new Size(333, 624);
            panel_DV_Filter.TabIndex = 31;
            // 
            // button_DV_OK_Filter
            // 
            button_DV_OK_Filter.FlatStyle = FlatStyle.Flat;
            button_DV_OK_Filter.Font = new Font("Segoe UI", 10F);
            button_DV_OK_Filter.ForeColor = Color.FromArgb(148, 255, 216);
            button_DV_OK_Filter.Location = new Point(18, 567);
            button_DV_OK_Filter.Margin = new Padding(2);
            button_DV_OK_Filter.Name = "button_DV_OK_Filter";
            button_DV_OK_Filter.Size = new Size(75, 34);
            button_DV_OK_Filter.TabIndex = 30;
            button_DV_OK_Filter.Text = "OK";
            button_DV_OK_Filter.UseVisualStyleBackColor = true;
            // 
            // textBox_DV_TenDV_Filter
            // 
            textBox_DV_TenDV_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_TenDV_Filter.BorderStyle = BorderStyle.None;
            textBox_DV_TenDV_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_TenDV_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_TenDV_Filter.Location = new Point(18, 190);
            textBox_DV_TenDV_Filter.Margin = new Padding(2);
            textBox_DV_TenDV_Filter.Name = "textBox_DV_TenDV_Filter";
            textBox_DV_TenDV_Filter.Size = new Size(294, 27);
            textBox_DV_TenDV_Filter.TabIndex = 8;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(193, 193, 193);
            label2.Location = new Point(18, 149);
            label2.Name = "label2";
            label2.Size = new Size(98, 25);
            label2.TabIndex = 7;
            label2.Text = "Tên dịch vụ";
            // 
            // textBox_DV_ChiPhi_Filter
            // 
            textBox_DV_ChiPhi_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_ChiPhi_Filter.BorderStyle = BorderStyle.None;
            textBox_DV_ChiPhi_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_ChiPhi_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_ChiPhi_Filter.Location = new Point(18, 281);
            textBox_DV_ChiPhi_Filter.Margin = new Padding(2);
            textBox_DV_ChiPhi_Filter.Name = "textBox_DV_ChiPhi_Filter";
            textBox_DV_ChiPhi_Filter.Size = new Size(223, 27);
            textBox_DV_ChiPhi_Filter.TabIndex = 6;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(193, 193, 193);
            label3.Location = new Point(18, 240);
            label3.Name = "label3";
            label3.Size = new Size(98, 25);
            label3.TabIndex = 5;
            label3.Text = "Chi phí";
            // 
            // textBox_DV_MaDV_Filter
            // 
            textBox_DV_MaDV_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DV_MaDV_Filter.BorderStyle = BorderStyle.None;
            textBox_DV_MaDV_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DV_MaDV_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DV_MaDV_Filter.Location = new Point(18, 108);
            textBox_DV_MaDV_Filter.Margin = new Padding(2);
            textBox_DV_MaDV_Filter.Name = "textBox_DV_MaDV_Filter";
            textBox_DV_MaDV_Filter.Size = new Size(294, 27);
            textBox_DV_MaDV_Filter.TabIndex = 4;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(193, 193, 193);
            label4.Location = new Point(18, 67);
            label4.Name = "label4";
            label4.Size = new Size(98, 25);
            label4.TabIndex = 1;
            label4.Text = "Mã dịch vụ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(18, 17);
            label5.Name = "label5";
            label5.Size = new Size(92, 32);
            label5.TabIndex = 0;
            label5.Text = "Upload";
            // 
            // comboBox_DV_Filter_Operation
            // 
            comboBox_DV_Filter_Operation.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_DV_Filter_Operation.FlatStyle = FlatStyle.Flat;
            comboBox_DV_Filter_Operation.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_DV_Filter_Operation.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_DV_Filter_Operation.FormattingEnabled = true;
            comboBox_DV_Filter_Operation.Items.AddRange(new object[] { ">", "≥", "=", "≤", "<" });
            comboBox_DV_Filter_Operation.Location = new Point(264, 277);
            comboBox_DV_Filter_Operation.Margin = new Padding(2);
            comboBox_DV_Filter_Operation.Name = "comboBox_DV_Filter_Operation";
            comboBox_DV_Filter_Operation.Size = new Size(48, 36);
            comboBox_DV_Filter_Operation.TabIndex = 31;
            // 
            // DichVuControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(57, 54, 70);
            Controls.Add(panel_DV_Upload);
            Controls.Add(panel_DV_Filter);
            Controls.Add(panel_Toolbar);
            Controls.Add(panel_TopPanel);
            Controls.Add(customDataGridView);
            Margin = new Padding(2);
            Name = "DichVuControl";
            Size = new Size(1272, 691);
            panel_TopPanel.ResumeLayout(false);
            panel_Toolbar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)customDataGridView).EndInit();
            panel_DV_Upload.ResumeLayout(false);
            panel_DV_Upload.PerformLayout();
            panel_DV_Filter.ResumeLayout(false);
            panel_DV_Filter.PerformLayout();
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
        private Custom.PageButton pageButton1;
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
    }
}
