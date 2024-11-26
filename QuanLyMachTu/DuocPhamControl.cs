using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;

using System.Data;
using System.Data.SqlClient;

namespace QuanLyMachTu
{
    public partial class DuocPhamControl : UserControl
    {
        //Bit errors
        //Upload textBox
        const int MAPK_ERR = 1;
        const int MANV_ERR = 2;
        const int SOGHE_ERR = 4;
        const int TRANGTHAI_ERR = 8;

        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatable;
        //Database connection
        // private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        private string connectionStr = @"Server=HOANGPHUC2023;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        //Control variables

        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;

        //controllers

        #region "Controls"
        int controlPage;
        DataTable controlDataTable;
        private Panel panel_TopPanel;
        private Panel panel_Toolbar;
        private PageButton pageButton_Filter;
        private PageButton pageButton_Remove;
        private PageButton pageButton_Upload;
        private Panel panel_Upload;
        private TextBox textBox_MaTK_Year;
        private TextBox textBox_MaTK_TK;
        private TextBox textBox11;
        private TextBox textBox_TKUpload_SDT;
        private Label textBox_TKUpload_Email;
        private Label label11;
        private TextBox textBox_TKUpload_MatKhau;
        private Label label1;
        private TextBox textBox_TKUpload_MaTK;
        private Label label18;
        private Button button_Upload_OK;
        private Label label_Upload;
        private Label label_TenDP;
        private Label label_MaDP;
        private TextBox textBox_TenDP;
        private TextBox textBox_MaDP;
        private Label label_SoLuong;
        private TextBox textBox_SoLuong;
        private TextBox textBox_MoTa;
        private Label label_MoTa;
        private Label label_GiaBan;
        private TextBox textBox_GiaBan;
        private Label label_GiaNhap;
        private TextBox textBox_GiaNhap;
        private Label label_XuatXu;
        private TextBox textBox_XuatXu;
        private Label label_DonVi;
        private TextBox textBox_DonVi;
        private Label label_SoLuongDP;
        private TextBox textBox_HSD;
        private Label label_HSD;
        private TextBox textBox_Nam;
        private Label label_Nam;
        private ComboBox comboBox_Thang;
        private Label label_Thang;
        private TextBox textBox_Ngay;
        private Label label_Ngay;
        private CustomDataGridView customDataGridView;
        private Panel panel_Filter;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Label label3;
        private ComboBox comboBox1;
        private Label label4;
        private TextBox textBox4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox5;
        private Label label8;
        private TextBox textBox6;
        private Label label9;
        private TextBox textBox7;
        private Label label10;
        private TextBox textBox8;
        private TextBox textBox9;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox textBox10;
        private TextBox textBox12;
        private Button button1;
        private Label label15;
        CustomDataGridView controlDataGridView;
        #endregion
        public DuocPhamControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DuocPhamControl));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel_TopPanel = new Panel();
            panel_Toolbar = new Panel();
            pageButton_Filter = new PageButton();
            pageButton_Remove = new PageButton();
            pageButton_Upload = new PageButton();
            panel_Upload = new Panel();
            textBox_SoLuong = new TextBox();
            textBox_HSD = new TextBox();
            label_HSD = new Label();
            textBox_Nam = new TextBox();
            label_Nam = new Label();
            comboBox_Thang = new ComboBox();
            label_Thang = new Label();
            textBox_Ngay = new TextBox();
            label_Ngay = new Label();
            label_SoLuong = new Label();
            label_DonVi = new Label();
            textBox_DonVi = new TextBox();
            label_XuatXu = new Label();
            textBox_XuatXu = new TextBox();
            label_GiaBan = new Label();
            textBox_GiaBan = new TextBox();
            label_GiaNhap = new Label();
            textBox_GiaNhap = new TextBox();
            textBox_MoTa = new TextBox();
            label_MoTa = new Label();
            label_TenDP = new Label();
            label_MaDP = new Label();
            textBox_TenDP = new TextBox();
            textBox_MaDP = new TextBox();
            button_Upload_OK = new Button();
            label_Upload = new Label();
            customDataGridView = new CustomDataGridView();
            panel_Filter = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox6 = new TextBox();
            label9 = new Label();
            textBox7 = new TextBox();
            label10 = new Label();
            textBox8 = new TextBox();
            textBox9 = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            textBox10 = new TextBox();
            textBox12 = new TextBox();
            button1 = new Button();
            label15 = new Label();
            panel_Toolbar.SuspendLayout();
            panel_Upload.SuspendLayout();
            ((ISupportInitialize)customDataGridView).BeginInit();
            panel_Filter.SuspendLayout();
            SuspendLayout();
            // 
            // panel_TopPanel
            // 
            panel_TopPanel.BackColor = Color.FromArgb(57, 54, 70);
            panel_TopPanel.Dock = DockStyle.Top;
            panel_TopPanel.Location = new Point(0, 0);
            panel_TopPanel.Margin = new Padding(2);
            panel_TopPanel.Name = "panel_TopPanel";
            panel_TopPanel.Size = new Size(1272, 67);
            panel_TopPanel.TabIndex = 20;
            // 
            // panel_Toolbar
            // 
            panel_Toolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Toolbar.BackColor = Color.FromArgb(57, 54, 70);
            panel_Toolbar.Controls.Add(pageButton_Filter);
            panel_Toolbar.Controls.Add(pageButton_Remove);
            panel_Toolbar.Controls.Add(pageButton_Upload);
            panel_Toolbar.Location = new Point(0, 67);
            panel_Toolbar.Margin = new Padding(2);
            panel_Toolbar.Name = "panel_Toolbar";
            panel_Toolbar.Size = new Size(939, 64);
            panel_Toolbar.TabIndex = 1;
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
            pageButton_Filter.Location = new Point(883, 8);
            pageButton_Filter.Margin = new Padding(2);
            pageButton_Filter.Name = "pageButton_Filter";
            pageButton_Filter.Size = new Size(44, 44);
            pageButton_Filter.TabIndex = 3;
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
            pageButton_Remove.Location = new Point(72, 10);
            pageButton_Remove.Margin = new Padding(2);
            pageButton_Remove.Name = "pageButton_Remove";
            pageButton_Remove.Size = new Size(44, 44);
            pageButton_Remove.TabIndex = 2;
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
            pageButton_Upload.Location = new Point(20, 10);
            pageButton_Upload.Margin = new Padding(2);
            pageButton_Upload.Name = "pageButton_Upload";
            pageButton_Upload.Size = new Size(44, 44);
            pageButton_Upload.TabIndex = 1;
            pageButton_Upload.TextLocation = new Point(0, 0);
            pageButton_Upload.UseVisualStyleBackColor = false;
            pageButton_Upload.Click += pageButton_Upload_Click;
            // 
            // panel_Upload
            // 
            panel_Upload.Anchor = AnchorStyles.Right;
            panel_Upload.AutoScroll = true;
            panel_Upload.AutoSize = true;
            panel_Upload.BackColor = Color.FromArgb(57, 54, 70);
            panel_Upload.Controls.Add(textBox_SoLuong);
            panel_Upload.Controls.Add(textBox_HSD);
            panel_Upload.Controls.Add(label_HSD);
            panel_Upload.Controls.Add(textBox_Nam);
            panel_Upload.Controls.Add(label_Nam);
            panel_Upload.Controls.Add(comboBox_Thang);
            panel_Upload.Controls.Add(label_Thang);
            panel_Upload.Controls.Add(textBox_Ngay);
            panel_Upload.Controls.Add(label_Ngay);
            panel_Upload.Controls.Add(label_SoLuong);
            panel_Upload.Controls.Add(label_DonVi);
            panel_Upload.Controls.Add(textBox_DonVi);
            panel_Upload.Controls.Add(label_XuatXu);
            panel_Upload.Controls.Add(textBox_XuatXu);
            panel_Upload.Controls.Add(label_GiaBan);
            panel_Upload.Controls.Add(textBox_GiaBan);
            panel_Upload.Controls.Add(label_GiaNhap);
            panel_Upload.Controls.Add(textBox_GiaNhap);
            panel_Upload.Controls.Add(textBox_MoTa);
            panel_Upload.Controls.Add(label_MoTa);
            panel_Upload.Controls.Add(label_TenDP);
            panel_Upload.Controls.Add(label_MaDP);
            panel_Upload.Controls.Add(textBox_TenDP);
            panel_Upload.Controls.Add(textBox_MaDP);
            panel_Upload.Controls.Add(button_Upload_OK);
            panel_Upload.Controls.Add(label_Upload);
            panel_Upload.Location = new Point(939, 67);
            panel_Upload.Margin = new Padding(2);
            panel_Upload.Name = "panel_Upload";
            panel_Upload.Size = new Size(333, 624);
            panel_Upload.TabIndex = 21;
            panel_Upload.Paint += panel_Upload_Paint;
            // 
            // textBox_SoLuong
            // 
            textBox_SoLuong.BackColor = Color.FromArgb(57, 54, 70);
            textBox_SoLuong.BorderStyle = BorderStyle.None;
            textBox_SoLuong.Font = new Font("Segoe UI Semilight", 12F);
            textBox_SoLuong.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_SoLuong.Location = new Point(164, 362);
            textBox_SoLuong.Margin = new Padding(2);
            textBox_SoLuong.Name = "textBox_SoLuong";
            textBox_SoLuong.Size = new Size(102, 27);
            textBox_SoLuong.TabIndex = 48;
            // 
            // textBox_HSD
            // 
            textBox_HSD.BackColor = Color.FromArgb(57, 54, 70);
            textBox_HSD.BorderStyle = BorderStyle.None;
            textBox_HSD.Font = new Font("Segoe UI Semilight", 12F);
            textBox_HSD.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_HSD.Location = new Point(251, 446);
            textBox_HSD.Margin = new Padding(2);
            textBox_HSD.Name = "textBox_HSD";
            textBox_HSD.Size = new Size(48, 27);
            textBox_HSD.TabIndex = 47;
            // 
            // label_HSD
            // 
            label_HSD.AutoSize = true;
            label_HSD.BackColor = Color.Transparent;
            label_HSD.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_HSD.ForeColor = Color.FromArgb(193, 193, 193);
            label_HSD.ImageAlign = ContentAlignment.BottomCenter;
            label_HSD.Location = new Point(244, 405);
            label_HSD.Margin = new Padding(2, 0, 2, 0);
            label_HSD.Name = "label_HSD";
            label_HSD.Size = new Size(43, 23);
            label_HSD.TabIndex = 46;
            label_HSD.Text = "HSD";
            label_HSD.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_Nam
            // 
            textBox_Nam.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Nam.BorderStyle = BorderStyle.None;
            textBox_Nam.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Nam.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Nam.Location = new Point(184, 439);
            textBox_Nam.Margin = new Padding(2);
            textBox_Nam.Name = "textBox_Nam";
            textBox_Nam.Size = new Size(48, 27);
            textBox_Nam.TabIndex = 45;
            // 
            // label_Nam
            // 
            label_Nam.AutoSize = true;
            label_Nam.BackColor = Color.Transparent;
            label_Nam.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Nam.ForeColor = Color.FromArgb(193, 193, 193);
            label_Nam.ImageAlign = ContentAlignment.BottomCenter;
            label_Nam.Location = new Point(188, 405);
            label_Nam.Margin = new Padding(2, 0, 2, 0);
            label_Nam.Name = "label_Nam";
            label_Nam.Size = new Size(47, 23);
            label_Nam.TabIndex = 44;
            label_Nam.Text = "Năm";
            label_Nam.TextAlign = ContentAlignment.BottomLeft;
            // 
            // comboBox_Thang
            // 
            comboBox_Thang.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_Thang.FlatStyle = FlatStyle.Flat;
            comboBox_Thang.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_Thang.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_Thang.FormattingEnabled = true;
            comboBox_Thang.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            comboBox_Thang.Location = new Point(96, 432);
            comboBox_Thang.Margin = new Padding(2);
            comboBox_Thang.Name = "comboBox_Thang";
            comboBox_Thang.Size = new Size(69, 36);
            comboBox_Thang.TabIndex = 43;
            // 
            // label_Thang
            // 
            label_Thang.AutoSize = true;
            label_Thang.BackColor = Color.Transparent;
            label_Thang.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Thang.ForeColor = Color.FromArgb(193, 193, 193);
            label_Thang.ImageAlign = ContentAlignment.BottomCenter;
            label_Thang.Location = new Point(104, 405);
            label_Thang.Margin = new Padding(2, 0, 2, 0);
            label_Thang.Name = "label_Thang";
            label_Thang.Size = new Size(58, 23);
            label_Thang.TabIndex = 42;
            label_Thang.Text = "Tháng";
            label_Thang.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_Ngay
            // 
            textBox_Ngay.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Ngay.BorderStyle = BorderStyle.None;
            textBox_Ngay.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Ngay.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Ngay.Location = new Point(24, 439);
            textBox_Ngay.Margin = new Padding(2);
            textBox_Ngay.Name = "textBox_Ngay";
            textBox_Ngay.Size = new Size(44, 27);
            textBox_Ngay.TabIndex = 41;
            // 
            // label_Ngay
            // 
            label_Ngay.AutoSize = true;
            label_Ngay.BackColor = Color.Transparent;
            label_Ngay.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Ngay.ForeColor = Color.FromArgb(193, 193, 193);
            label_Ngay.ImageAlign = ContentAlignment.BottomCenter;
            label_Ngay.Location = new Point(24, 404);
            label_Ngay.Margin = new Padding(2, 0, 2, 0);
            label_Ngay.Name = "label_Ngay";
            label_Ngay.Size = new Size(50, 23);
            label_Ngay.TabIndex = 40;
            label_Ngay.Text = "Ngày";
            label_Ngay.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_SoLuong
            // 
            label_SoLuong.AutoSize = true;
            label_SoLuong.BackColor = Color.Transparent;
            label_SoLuong.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SoLuong.ForeColor = Color.FromArgb(193, 193, 193);
            label_SoLuong.ImageAlign = ContentAlignment.BottomCenter;
            label_SoLuong.Location = new Point(164, 337);
            label_SoLuong.Margin = new Padding(2, 0, 2, 0);
            label_SoLuong.Name = "label_SoLuong";
            label_SoLuong.Size = new Size(78, 23);
            label_SoLuong.TabIndex = 39;
            label_SoLuong.Text = "Số lượng";
            label_SoLuong.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_DonVi
            // 
            label_DonVi.AutoSize = true;
            label_DonVi.BackColor = Color.Transparent;
            label_DonVi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DonVi.ForeColor = Color.FromArgb(193, 193, 193);
            label_DonVi.ImageAlign = ContentAlignment.BottomCenter;
            label_DonVi.Location = new Point(15, 337);
            label_DonVi.Margin = new Padding(2, 0, 2, 0);
            label_DonVi.Name = "label_DonVi";
            label_DonVi.Size = new Size(59, 23);
            label_DonVi.TabIndex = 37;
            label_DonVi.Text = "Đơn vị";
            label_DonVi.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_DonVi
            // 
            textBox_DonVi.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DonVi.BorderStyle = BorderStyle.None;
            textBox_DonVi.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DonVi.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DonVi.Location = new Point(15, 362);
            textBox_DonVi.Margin = new Padding(2);
            textBox_DonVi.Name = "textBox_DonVi";
            textBox_DonVi.Size = new Size(102, 27);
            textBox_DonVi.TabIndex = 36;
            // 
            // label_XuatXu
            // 
            label_XuatXu.AutoSize = true;
            label_XuatXu.BackColor = Color.Transparent;
            label_XuatXu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_XuatXu.ForeColor = Color.FromArgb(193, 193, 193);
            label_XuatXu.ImageAlign = ContentAlignment.BottomCenter;
            label_XuatXu.Location = new Point(12, 274);
            label_XuatXu.Margin = new Padding(2, 0, 2, 0);
            label_XuatXu.Name = "label_XuatXu";
            label_XuatXu.Size = new Size(68, 23);
            label_XuatXu.TabIndex = 35;
            label_XuatXu.Text = "Xuất xứ";
            label_XuatXu.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_XuatXu
            // 
            textBox_XuatXu.BackColor = Color.FromArgb(57, 54, 70);
            textBox_XuatXu.BorderStyle = BorderStyle.None;
            textBox_XuatXu.Font = new Font("Segoe UI Semilight", 12F);
            textBox_XuatXu.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_XuatXu.Location = new Point(12, 308);
            textBox_XuatXu.Margin = new Padding(2);
            textBox_XuatXu.Name = "textBox_XuatXu";
            textBox_XuatXu.Size = new Size(285, 27);
            textBox_XuatXu.TabIndex = 34;
            // 
            // label_GiaBan
            // 
            label_GiaBan.AutoSize = true;
            label_GiaBan.BackColor = Color.Transparent;
            label_GiaBan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaBan.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaBan.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaBan.Location = new Point(164, 205);
            label_GiaBan.Margin = new Padding(2, 0, 2, 0);
            label_GiaBan.Name = "label_GiaBan";
            label_GiaBan.Size = new Size(69, 23);
            label_GiaBan.TabIndex = 33;
            label_GiaBan.Text = "Giá bán";
            label_GiaBan.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_GiaBan
            // 
            textBox_GiaBan.BackColor = Color.FromArgb(57, 54, 70);
            textBox_GiaBan.BorderStyle = BorderStyle.None;
            textBox_GiaBan.Font = new Font("Segoe UI Semilight", 12F);
            textBox_GiaBan.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_GiaBan.Location = new Point(164, 240);
            textBox_GiaBan.Margin = new Padding(2);
            textBox_GiaBan.Name = "textBox_GiaBan";
            textBox_GiaBan.Size = new Size(102, 27);
            textBox_GiaBan.TabIndex = 32;
            // 
            // label_GiaNhap
            // 
            label_GiaNhap.AutoSize = true;
            label_GiaNhap.BackColor = Color.Transparent;
            label_GiaNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaNhap.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaNhap.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaNhap.Location = new Point(12, 205);
            label_GiaNhap.Margin = new Padding(2, 0, 2, 0);
            label_GiaNhap.Name = "label_GiaNhap";
            label_GiaNhap.Size = new Size(79, 23);
            label_GiaNhap.TabIndex = 31;
            label_GiaNhap.Text = "Giá nhập";
            label_GiaNhap.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_GiaNhap
            // 
            textBox_GiaNhap.BackColor = Color.FromArgb(57, 54, 70);
            textBox_GiaNhap.BorderStyle = BorderStyle.None;
            textBox_GiaNhap.Font = new Font("Segoe UI Semilight", 12F);
            textBox_GiaNhap.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_GiaNhap.Location = new Point(12, 245);
            textBox_GiaNhap.Margin = new Padding(2);
            textBox_GiaNhap.Name = "textBox_GiaNhap";
            textBox_GiaNhap.Size = new Size(102, 27);
            textBox_GiaNhap.TabIndex = 30;
            // 
            // textBox_MoTa
            // 
            textBox_MoTa.BackColor = Color.FromArgb(57, 54, 70);
            textBox_MoTa.Font = new Font("Segoe UI Semilight", 12F);
            textBox_MoTa.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_MoTa.Location = new Point(21, 508);
            textBox_MoTa.Margin = new Padding(2);
            textBox_MoTa.Multiline = true;
            textBox_MoTa.Name = "textBox_MoTa";
            textBox_MoTa.Size = new Size(294, 41);
            textBox_MoTa.TabIndex = 29;
            // 
            // label_MoTa
            // 
            label_MoTa.AutoSize = true;
            label_MoTa.BackColor = Color.Transparent;
            label_MoTa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_MoTa.ForeColor = Color.FromArgb(193, 193, 193);
            label_MoTa.ImageAlign = ContentAlignment.BottomCenter;
            label_MoTa.Location = new Point(23, 470);
            label_MoTa.Margin = new Padding(2, 0, 2, 0);
            label_MoTa.Name = "label_MoTa";
            label_MoTa.Size = new Size(55, 23);
            label_MoTa.TabIndex = 28;
            label_MoTa.Text = "Mô tả";
            label_MoTa.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_TenDP
            // 
            label_TenDP.AutoSize = true;
            label_TenDP.BackColor = Color.Transparent;
            label_TenDP.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TenDP.ForeColor = Color.FromArgb(193, 193, 193);
            label_TenDP.ImageAlign = ContentAlignment.BottomCenter;
            label_TenDP.Location = new Point(12, 134);
            label_TenDP.Margin = new Padding(2, 0, 2, 0);
            label_TenDP.Name = "label_TenDP";
            label_TenDP.Size = new Size(128, 23);
            label_TenDP.TabIndex = 14;
            label_TenDP.Text = "Tên dược phẩm";
            label_TenDP.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_MaDP
            // 
            label_MaDP.AutoSize = true;
            label_MaDP.BackColor = Color.Transparent;
            label_MaDP.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_MaDP.ForeColor = Color.FromArgb(193, 193, 193);
            label_MaDP.ImageAlign = ContentAlignment.BottomCenter;
            label_MaDP.Location = new Point(12, 55);
            label_MaDP.Margin = new Padding(2, 0, 2, 0);
            label_MaDP.Name = "label_MaDP";
            label_MaDP.Size = new Size(126, 23);
            label_MaDP.TabIndex = 13;
            label_MaDP.Text = "Mã dược phẩm";
            label_MaDP.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_TenDP
            // 
            textBox_TenDP.BackColor = Color.FromArgb(57, 54, 70);
            textBox_TenDP.BorderStyle = BorderStyle.None;
            textBox_TenDP.Font = new Font("Segoe UI Semilight", 12F);
            textBox_TenDP.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_TenDP.Location = new Point(12, 159);
            textBox_TenDP.Margin = new Padding(2);
            textBox_TenDP.Name = "textBox_TenDP";
            textBox_TenDP.Size = new Size(293, 27);
            textBox_TenDP.TabIndex = 12;
            // 
            // textBox_MaDP
            // 
            textBox_MaDP.BackColor = Color.FromArgb(57, 54, 70);
            textBox_MaDP.BorderStyle = BorderStyle.None;
            textBox_MaDP.Font = new Font("Segoe UI Semilight", 12F);
            textBox_MaDP.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_MaDP.Location = new Point(12, 90);
            textBox_MaDP.Margin = new Padding(2);
            textBox_MaDP.Name = "textBox_MaDP";
            textBox_MaDP.Size = new Size(293, 27);
            textBox_MaDP.TabIndex = 11;
            // 
            // button_Upload_OK
            // 
            button_Upload_OK.FlatStyle = FlatStyle.Flat;
            button_Upload_OK.Font = new Font("Segoe UI", 10F);
            button_Upload_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_Upload_OK.Location = new Point(20, 568);
            button_Upload_OK.Margin = new Padding(2);
            button_Upload_OK.Name = "button_Upload_OK";
            button_Upload_OK.Size = new Size(75, 34);
            button_Upload_OK.TabIndex = 4;
            button_Upload_OK.Text = "OK";
            button_Upload_OK.UseVisualStyleBackColor = true;
            button_Upload_OK.Click += button_Upload_OK_Click;
            // 
            // label_Upload
            // 
            label_Upload.AutoSize = true;
            label_Upload.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Upload.ForeColor = Color.White;
            label_Upload.Location = new Point(12, 6);
            label_Upload.Margin = new Padding(2, 0, 2, 0);
            label_Upload.Name = "label_Upload";
            label_Upload.Size = new Size(92, 32);
            label_Upload.TabIndex = 2;
            label_Upload.Text = "Upload";
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(79, 69, 87);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.Padding = new Padding(0, 0, 0, 5);
            dataGridViewCellStyle1.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            customDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            customDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customDataGridView.CornerRadius = 60;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semilight", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.Padding = new Padding(15, 0, 5, 5);
            dataGridViewCellStyle2.SelectionBackColor = Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            customDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
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
            customDataGridView.TabIndex = 22;
            // 
            // panel_Filter
            // 
            panel_Filter.Anchor = AnchorStyles.Right;
            panel_Filter.AutoScroll = true;
            panel_Filter.AutoSize = true;
            panel_Filter.BackColor = Color.FromArgb(57, 54, 70);
            panel_Filter.Controls.Add(textBox1);
            panel_Filter.Controls.Add(textBox2);
            panel_Filter.Controls.Add(label2);
            panel_Filter.Controls.Add(textBox3);
            panel_Filter.Controls.Add(label3);
            panel_Filter.Controls.Add(comboBox1);
            panel_Filter.Controls.Add(label4);
            panel_Filter.Controls.Add(textBox4);
            panel_Filter.Controls.Add(label5);
            panel_Filter.Controls.Add(label6);
            panel_Filter.Controls.Add(label7);
            panel_Filter.Controls.Add(textBox5);
            panel_Filter.Controls.Add(label8);
            panel_Filter.Controls.Add(textBox6);
            panel_Filter.Controls.Add(label9);
            panel_Filter.Controls.Add(textBox7);
            panel_Filter.Controls.Add(label10);
            panel_Filter.Controls.Add(textBox8);
            panel_Filter.Controls.Add(textBox9);
            panel_Filter.Controls.Add(label12);
            panel_Filter.Controls.Add(label13);
            panel_Filter.Controls.Add(label14);
            panel_Filter.Controls.Add(textBox10);
            panel_Filter.Controls.Add(textBox12);
            panel_Filter.Controls.Add(button1);
            panel_Filter.Controls.Add(label15);
            panel_Filter.Location = new Point(939, 67);
            panel_Filter.Margin = new Padding(2);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(333, 624);
            panel_Filter.TabIndex = 49;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(57, 54, 70);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI Semilight", 12F);
            textBox1.ForeColor = Color.FromArgb(244, 238, 224);
            textBox1.Location = new Point(164, 362);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(102, 27);
            textBox1.TabIndex = 48;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(57, 54, 70);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI Semilight", 12F);
            textBox2.ForeColor = Color.FromArgb(244, 238, 224);
            textBox2.Location = new Point(251, 446);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(48, 27);
            textBox2.TabIndex = 47;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(193, 193, 193);
            label2.ImageAlign = ContentAlignment.BottomCenter;
            label2.Location = new Point(244, 405);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 23);
            label2.TabIndex = 46;
            label2.Text = "HSD";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(57, 54, 70);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Segoe UI Semilight", 12F);
            textBox3.ForeColor = Color.FromArgb(244, 238, 224);
            textBox3.Location = new Point(184, 439);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(48, 27);
            textBox3.TabIndex = 45;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(193, 193, 193);
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(188, 405);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(47, 23);
            label3.TabIndex = 44;
            label3.Text = "Năm";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(57, 54, 70);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI Semilight", 12F);
            comboBox1.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            comboBox1.Location = new Point(96, 432);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(69, 36);
            comboBox1.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(193, 193, 193);
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(104, 405);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 23);
            label4.TabIndex = 42;
            label4.Text = "Tháng";
            label4.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(57, 54, 70);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Segoe UI Semilight", 12F);
            textBox4.ForeColor = Color.FromArgb(244, 238, 224);
            textBox4.Location = new Point(24, 439);
            textBox4.Margin = new Padding(2);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(44, 27);
            textBox4.TabIndex = 41;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(193, 193, 193);
            label5.ImageAlign = ContentAlignment.BottomCenter;
            label5.Location = new Point(24, 404);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(50, 23);
            label5.TabIndex = 40;
            label5.Text = "Ngày";
            label5.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(193, 193, 193);
            label6.ImageAlign = ContentAlignment.BottomCenter;
            label6.Location = new Point(164, 337);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(78, 23);
            label6.TabIndex = 39;
            label6.Text = "Số lượng";
            label6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(193, 193, 193);
            label7.ImageAlign = ContentAlignment.BottomCenter;
            label7.Location = new Point(15, 337);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(59, 23);
            label7.TabIndex = 37;
            label7.Text = "Đơn vị";
            label7.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(57, 54, 70);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Segoe UI Semilight", 12F);
            textBox5.ForeColor = Color.FromArgb(244, 238, 224);
            textBox5.Location = new Point(15, 362);
            textBox5.Margin = new Padding(2);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(102, 27);
            textBox5.TabIndex = 36;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(193, 193, 193);
            label8.ImageAlign = ContentAlignment.BottomCenter;
            label8.Location = new Point(12, 274);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(68, 23);
            label8.TabIndex = 35;
            label8.Text = "Xuất xứ";
            label8.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(57, 54, 70);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Segoe UI Semilight", 12F);
            textBox6.ForeColor = Color.FromArgb(244, 238, 224);
            textBox6.Location = new Point(12, 308);
            textBox6.Margin = new Padding(2);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(285, 27);
            textBox6.TabIndex = 34;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(193, 193, 193);
            label9.ImageAlign = ContentAlignment.BottomCenter;
            label9.Location = new Point(164, 205);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(69, 23);
            label9.TabIndex = 33;
            label9.Text = "Giá bán";
            label9.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.FromArgb(57, 54, 70);
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Font = new Font("Segoe UI Semilight", 12F);
            textBox7.ForeColor = Color.FromArgb(244, 238, 224);
            textBox7.Location = new Point(164, 240);
            textBox7.Margin = new Padding(2);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(102, 27);
            textBox7.TabIndex = 32;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(193, 193, 193);
            label10.ImageAlign = ContentAlignment.BottomCenter;
            label10.Location = new Point(12, 205);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(79, 23);
            label10.TabIndex = 31;
            label10.Text = "Giá nhập";
            label10.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox8
            // 
            textBox8.BackColor = Color.FromArgb(57, 54, 70);
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Font = new Font("Segoe UI Semilight", 12F);
            textBox8.ForeColor = Color.FromArgb(244, 238, 224);
            textBox8.Location = new Point(12, 245);
            textBox8.Margin = new Padding(2);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(102, 27);
            textBox8.TabIndex = 30;
            // 
            // textBox9
            // 
            textBox9.BackColor = Color.FromArgb(57, 54, 70);
            textBox9.Font = new Font("Segoe UI Semilight", 12F);
            textBox9.ForeColor = Color.FromArgb(244, 238, 224);
            textBox9.Location = new Point(21, 508);
            textBox9.Margin = new Padding(2);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(294, 41);
            textBox9.TabIndex = 29;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(193, 193, 193);
            label12.ImageAlign = ContentAlignment.BottomCenter;
            label12.Location = new Point(23, 470);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(55, 23);
            label12.TabIndex = 28;
            label12.Text = "Mô tả";
            label12.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(193, 193, 193);
            label13.ImageAlign = ContentAlignment.BottomCenter;
            label13.Location = new Point(12, 134);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(128, 23);
            label13.TabIndex = 14;
            label13.Text = "Tên dược phẩm";
            label13.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(193, 193, 193);
            label14.ImageAlign = ContentAlignment.BottomCenter;
            label14.Location = new Point(12, 55);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(126, 23);
            label14.TabIndex = 13;
            label14.Text = "Mã dược phẩm";
            label14.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox10
            // 
            textBox10.BackColor = Color.FromArgb(57, 54, 70);
            textBox10.BorderStyle = BorderStyle.None;
            textBox10.Font = new Font("Segoe UI Semilight", 12F);
            textBox10.ForeColor = Color.FromArgb(244, 238, 224);
            textBox10.Location = new Point(12, 159);
            textBox10.Margin = new Padding(2);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(293, 27);
            textBox10.TabIndex = 12;
            // 
            // textBox12
            // 
            textBox12.BackColor = Color.FromArgb(57, 54, 70);
            textBox12.BorderStyle = BorderStyle.None;
            textBox12.Font = new Font("Segoe UI Semilight", 12F);
            textBox12.ForeColor = Color.FromArgb(244, 238, 224);
            textBox12.Location = new Point(12, 90);
            textBox12.Margin = new Padding(2);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(293, 27);
            textBox12.TabIndex = 11;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = Color.FromArgb(148, 255, 216);
            button1.Location = new Point(20, 568);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(75, 34);
            button1.TabIndex = 4;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(12, 6);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(69, 32);
            label15.TabIndex = 2;
            label15.Text = "Filter";
            // 
            // DuocPhamControl
            // 
            BackColor = Color.FromArgb(57, 54, 70);
            Controls.Add(panel_Filter);
            Controls.Add(customDataGridView);
            Controls.Add(panel_Upload);
            Controls.Add(panel_Toolbar);
            Controls.Add(panel_TopPanel);
            Margin = new Padding(2);
            Name = "DuocPhamControl";
            Size = new Size(1272, 691);
            Load += DuocPhamControl_Load;
            panel_Toolbar.ResumeLayout(false);
            panel_Upload.ResumeLayout(false);
            panel_Upload.PerformLayout();
            ((ISupportInitialize)customDataGridView).EndInit();
            panel_Filter.ResumeLayout(false);
            panel_Filter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void DuocPhamControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }

        private void InitializeState()
        {
            controlDataGridView = customDataGridView;
            panel_Upload.BringToFront();


            //controlDataGridView = customDataGridView_PC;
            //controlPage = PK_TAB;
            //SwitchMode(controlPage);
            //panel_Filters.BringToFront();


            //controlPage = BN_TAB;
            //controlDataTable = datatableBN;
            //EnablePage(controlPage);
        }

        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            LoadDataToDataSet("SELECT * FROM DUOCPHAM", "DUOCPHAM");
            datatable = dataset.Tables["DUOCPHAM"];
            datatable.PrimaryKey = new DataColumn[] { datatable.Columns["MaDP"] };

            comboBox_Thang.SelectedItem = comboBox_Thang.Items[0];

            connection.Close();

            UpdateDataGridView(customDataGridView, datatable);
        }

        private void LoadDataToDataSet(string commandStr, string tableName)
        {
            adapter = new SqlDataAdapter(commandStr, connection);
            adapter.Fill(dataset, tableName);
        }
        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;

            //Display statitic number
            //label_HienThiDTTong.Text = CalculateSumOfDoanhSo(dgv).ToString();
            //label_HienThiSoBN.Text = dgv.Rows.Count.ToString();
        }

        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            panel_Upload.BringToFront();
        }

        private void button_Upload_OK_Click(object sender, EventArgs e)
        {
            int error = CheckUploadTextBox();
            if (error != 0)
            {
                WarningUploadTextBoxError(error);
                return;
            }

            string primaryKey = textBox_MaDP.Text;
            DataRow targetRow = datatable.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatable.NewRow();

                targetRow["MaDP"] = primaryKey;
                targetRow["TenDP"] = textBox_TenDP.Text;
                targetRow["GiaNhap"] = textBox_GiaNhap.Text;
                targetRow["GiaBan"] = textBox_GiaBan.Text;
                targetRow["XuatXu"] = textBox_XuatXu.Text;
                targetRow["DonVi"] = textBox_DonVi.Text;
                targetRow["SoLuong"] = textBox_SoLuong.Text;
                targetRow["NgayNhap"] = GetNgayThangNam(textBox_Ngay, comboBox_Thang, textBox_Nam);
                targetRow["HSD"] = textBox_HSD.Text;
                targetRow["MoTa"] = textBox_MoTa.Text;


                datatable.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaDP"] = primaryKey;
                targetRow["TenDP"] = textBox_TenDP.Text;
                targetRow["GiaNhap"] = textBox_GiaNhap.Text;
                targetRow["GiaBan"] = textBox_GiaBan.Text;
                targetRow["XuatXu"] = textBox_XuatXu.Text;
                targetRow["DonVi"] = textBox_DonVi.Text;
                targetRow["SoLuong"] = textBox_SoLuong.Text;
                targetRow["NgayNhap"] = GetNgayThangNam(textBox_Ngay, comboBox_Thang, textBox_Nam);
                targetRow["HSD"] = textBox_HSD.Text;
                targetRow["MoTa"] = textBox_MoTa.Text;
            }

            UpdateDataGridView(customDataGridView, datatable);
        }

        private void pageButton_Filter_Click(object sender, EventArgs e)
        {
            //panel_Filters.BringToFront();
        }

        private void pageButton_Remove_Click(object sender, EventArgs e)
        {
            DataColumn[] primaryKeyColumn = controlDataTable.PrimaryKey;
            string[] primaryKeyName = new string[primaryKeyColumn.Length];
            string[] primaryKey = new string[primaryKeyColumn.Length];
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();

            //get primary key name
            for (int col = 0; col < primaryKeyName.Length; col++)
                primaryKeyName[col] = primaryKeyColumn[col].ColumnName;

            //get all rows of selected cells
            foreach (DataGridViewCell cell in controlDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //remove row with primary key
            foreach (DataGridViewRow row in selectedRows)
            {
                //get primary key value
                for (int col = 0; col < primaryKeyName.Length; col++)
                    primaryKey[col] = row.Cells[primaryKeyName[col]].Value.ToString();
                //remove row
                DataRow? deleteRow = controlDataTable.Rows.Find(primaryKey);
                controlDataTable.Rows.Remove(deleteRow);
            }

            UpdateDataGridView(controlDataGridView, controlDataTable);
        }

        private string GetNgayThangNam(TextBox textBox_Ngay, ComboBox comboBox_Thang, TextBox textBox_Nam)
        {
            if (string.IsNullOrEmpty(textBox_Ngay.Text))
                return null;
            else if (string.IsNullOrEmpty(textBox_Nam.Text))
                return null;

            return $"{comboBox_Thang.SelectedIndex + 1}/{textBox_Ngay.Text}/{textBox_Nam.Text}";
        }

        private int CheckUploadTextBox()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_MaDP.Text))
                error |= 1;
            if (string.IsNullOrEmpty(textBox_TenDP.Text))
                error |= 2;
            if (string.IsNullOrEmpty(textBox_GiaNhap.Text))
                error |= 4;
            if (string.IsNullOrEmpty(textBox_GiaBan.Text))
                error |= 8;
            if (string.IsNullOrEmpty(textBox_XuatXu.Text))
                error |= 16;
            if (string.IsNullOrEmpty(textBox_DonVi.Text))
                error |= 32;
            if (string.IsNullOrEmpty(textBox_SoLuong.Text))
                error |= 64;
            if (string.IsNullOrEmpty(textBox_Ngay.Text))
                error |= 128;
            if (string.IsNullOrEmpty(textBox_Nam.Text))
                error |= 256;
            if (string.IsNullOrEmpty(textBox_HSD.Text))
                error |= 512;
            if (string.IsNullOrEmpty(textBox_MoTa.Text))
                error |= 1024;

            return error;
        }

        #region Bit errors
        const int MADP_ERR = 1;
        const int TENDP_ERR = 2;
        const int GIANHAP_ERR = 4;
        const int GIABAN_ERR = 8;
        const int XUATXU_ERR = 16;
        const int DONVI_ERR = 32;
        const int SOLUONG_ERR = 64;
        const int NGAY_ERR = 128;
        const int NAM_ERR = 256;
        const int HSD_ERR = 512;
        const int MOTA_ERR = 1024;
        #endregion

        private void WarningUploadTextBoxError(int error)
        {
            if ((error & MADP_ERR) == MADP_ERR)
                ColoringTextBox.WarningColor(textBox_MaDP);
            if ((error & TENDP_ERR) == TENDP_ERR)
                ColoringTextBox.WarningColor(textBox_TenDP);
            if ((error & GIANHAP_ERR) == GIANHAP_ERR)
                ColoringTextBox.WarningColor(textBox_GiaNhap);
            if ((error & GIABAN_ERR) == GIABAN_ERR)
                ColoringTextBox.WarningColor(textBox_GiaBan);
            if ((error & XUATXU_ERR) == XUATXU_ERR)
                ColoringTextBox.WarningColor(textBox_XuatXu);
            if ((error & DONVI_ERR) == DONVI_ERR)
                ColoringTextBox.WarningColor(textBox_DonVi);
            if ((error & SOLUONG_ERR) == SOLUONG_ERR)
                ColoringTextBox.WarningColor(textBox_SoLuong);
            if ((error & NGAY_ERR) == NGAY_ERR)
                ColoringTextBox.WarningColor(textBox_Ngay);
            if ((error & NAM_ERR) == NAM_ERR)
                ColoringTextBox.WarningColor(textBox_Nam);
            if ((error & HSD_ERR) == HSD_ERR)
                ColoringTextBox.WarningColor(textBox_HSD);
            if ((error & MOTA_ERR) == MOTA_ERR)
                ColoringTextBox.WarningColor(textBox_MoTa);
        }

        private void panel_Upload_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 15, endX = 395;

            graphic.DrawLine(linePen, new Point(startX, 165), new Point(endX, 165)); //MaBN line
            graphic.DrawLine(linePen, new Point(startX, 264), new Point(endX, 264)); //TenBN line
            graphic.DrawLine(linePen, new Point(startX, 363), new Point(94, 363)); //Ngay line
            graphic.DrawLine(linePen, new Point(239, 363), new Point(endX, 363)); //Nam line
            graphic.DrawLine(linePen, new Point(startX, 462), new Point(199, 462)); //SDL line
            graphic.DrawLine(linePen, new Point(startX, 561), new Point(endX, 561)); //Email line
        }
    }
}
