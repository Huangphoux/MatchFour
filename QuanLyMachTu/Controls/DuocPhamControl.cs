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

namespace QuanLyMachTu.Controls
{
    public partial class DuocPhamControl : UserControl
    {
        #region SQL stuffs
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
        private TextBox textBox_SoLuong_Filter;
        private TextBox textBox_HSD_Filter;
        private Label label_HSD_Filter;
        private TextBox textBox_Nam_Filter;
        private Label label_Nam_Filter;
        private ComboBox comboBox_Thang_Filter;
        private Label label4;
        private TextBox textBox_Ngay_Filter;
        private Label label5;
        private Label label_SoLuong_Filter;
        private Label label_DonVi_Filter;
        private TextBox textBox_DonVi_Filter;
        private Label label_XuatXu_Filter;
        private TextBox textBox_XuatXu_Filter;
        private Label label_GiaBan_Filter;
        private TextBox textBox_GiaBan_Filter;
        private Label label_GiaNhap_Filter;
        private TextBox textBox_GiaNhap_Filter;
        private Label label_TenDP_Filter;
        private Label label_MaDP_Filter;
        private TextBox textBox_TenDP_Filter;
        private TextBox textBox_MaDP_Filter;
        private Button button_OK_Filter;
        private Label label15;
        private Label label2;
        private Label label3;
        private Label label8;
        private Label label9;
        private Label label7;
        private Label label6;
        CustomDataGridView controlDataGridView;
        #endregion
        public DuocPhamControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DuocPhamControl));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
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
            label8 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox_SoLuong_Filter = new TextBox();
            textBox_HSD_Filter = new TextBox();
            label_HSD_Filter = new Label();
            textBox_Nam_Filter = new TextBox();
            label_Nam_Filter = new Label();
            comboBox_Thang_Filter = new ComboBox();
            label4 = new Label();
            textBox_Ngay_Filter = new TextBox();
            label5 = new Label();
            label_SoLuong_Filter = new Label();
            label_DonVi_Filter = new Label();
            textBox_DonVi_Filter = new TextBox();
            label_XuatXu_Filter = new Label();
            textBox_XuatXu_Filter = new TextBox();
            label_GiaBan_Filter = new Label();
            textBox_GiaBan_Filter = new TextBox();
            label_GiaNhap_Filter = new Label();
            textBox_GiaNhap_Filter = new TextBox();
            label_TenDP_Filter = new Label();
            label_MaDP_Filter = new Label();
            textBox_TenDP_Filter = new TextBox();
            textBox_MaDP_Filter = new TextBox();
            button_OK_Filter = new Button();
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
            customDataGridView.TabIndex = 22;
            // 
            // panel_Filter
            // 
            panel_Filter.Anchor = AnchorStyles.Right;
            panel_Filter.AutoScroll = true;
            panel_Filter.AutoSize = true;
            panel_Filter.BackColor = Color.FromArgb(57, 54, 70);
            panel_Filter.Controls.Add(label8);
            panel_Filter.Controls.Add(label9);
            panel_Filter.Controls.Add(label7);
            panel_Filter.Controls.Add(label6);
            panel_Filter.Controls.Add(label3);
            panel_Filter.Controls.Add(label2);
            panel_Filter.Controls.Add(textBox_SoLuong_Filter);
            panel_Filter.Controls.Add(textBox_HSD_Filter);
            panel_Filter.Controls.Add(label_HSD_Filter);
            panel_Filter.Controls.Add(textBox_Nam_Filter);
            panel_Filter.Controls.Add(label_Nam_Filter);
            panel_Filter.Controls.Add(comboBox_Thang_Filter);
            panel_Filter.Controls.Add(label4);
            panel_Filter.Controls.Add(textBox_Ngay_Filter);
            panel_Filter.Controls.Add(label5);
            panel_Filter.Controls.Add(label_SoLuong_Filter);
            panel_Filter.Controls.Add(label_DonVi_Filter);
            panel_Filter.Controls.Add(textBox_DonVi_Filter);
            panel_Filter.Controls.Add(label_XuatXu_Filter);
            panel_Filter.Controls.Add(textBox_XuatXu_Filter);
            panel_Filter.Controls.Add(label_GiaBan_Filter);
            panel_Filter.Controls.Add(textBox_GiaBan_Filter);
            panel_Filter.Controls.Add(label_GiaNhap_Filter);
            panel_Filter.Controls.Add(textBox_GiaNhap_Filter);
            panel_Filter.Controls.Add(label_TenDP_Filter);
            panel_Filter.Controls.Add(label_MaDP_Filter);
            panel_Filter.Controls.Add(textBox_TenDP_Filter);
            panel_Filter.Controls.Add(textBox_MaDP_Filter);
            panel_Filter.Controls.Add(button_OK_Filter);
            panel_Filter.Controls.Add(label15);
            panel_Filter.Location = new Point(939, 67);
            panel_Filter.Margin = new Padding(2);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(333, 624);
            panel_Filter.TabIndex = 49;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(193, 193, 193);
            label8.ImageAlign = ContentAlignment.BottomCenter;
            label8.Location = new Point(283, 362);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(22, 23);
            label8.TabIndex = 54;
            label8.Text = "≥";
            label8.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(193, 193, 193);
            label9.ImageAlign = ContentAlignment.BottomCenter;
            label9.Location = new Point(128, 362);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(22, 23);
            label9.TabIndex = 53;
            label9.Text = "≥";
            label9.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(193, 193, 193);
            label7.ImageAlign = ContentAlignment.BottomCenter;
            label7.Location = new Point(283, 244);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(22, 23);
            label7.TabIndex = 52;
            label7.Text = "≥";
            label7.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(193, 193, 193);
            label6.ImageAlign = ContentAlignment.BottomCenter;
            label6.Location = new Point(128, 244);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(22, 23);
            label6.TabIndex = 51;
            label6.Text = "≥";
            label6.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(193, 193, 193);
            label3.ImageAlign = ContentAlignment.BottomCenter;
            label3.Location = new Point(251, 440);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(22, 23);
            label3.TabIndex = 50;
            label3.Text = "≥";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(193, 193, 193);
            label2.ImageAlign = ContentAlignment.BottomCenter;
            label2.Location = new Point(95, 516);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(22, 23);
            label2.TabIndex = 49;
            label2.Text = "≥";
            label2.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_SoLuong_Filter
            // 
            textBox_SoLuong_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_SoLuong_Filter.BorderStyle = BorderStyle.None;
            textBox_SoLuong_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_SoLuong_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_SoLuong_Filter.Location = new Point(164, 362);
            textBox_SoLuong_Filter.Margin = new Padding(2);
            textBox_SoLuong_Filter.Name = "textBox_SoLuong_Filter";
            textBox_SoLuong_Filter.Size = new Size(102, 27);
            textBox_SoLuong_Filter.TabIndex = 48;
            // 
            // textBox_HSD_Filter
            // 
            textBox_HSD_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_HSD_Filter.BorderStyle = BorderStyle.None;
            textBox_HSD_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_HSD_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_HSD_Filter.Location = new Point(26, 520);
            textBox_HSD_Filter.Margin = new Padding(2);
            textBox_HSD_Filter.Name = "textBox_HSD_Filter";
            textBox_HSD_Filter.Size = new Size(48, 27);
            textBox_HSD_Filter.TabIndex = 47;
            // 
            // label_HSD_Filter
            // 
            label_HSD_Filter.AutoSize = true;
            label_HSD_Filter.BackColor = Color.Transparent;
            label_HSD_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_HSD_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_HSD_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_HSD_Filter.Location = new Point(24, 483);
            label_HSD_Filter.Margin = new Padding(2, 0, 2, 0);
            label_HSD_Filter.Name = "label_HSD_Filter";
            label_HSD_Filter.Size = new Size(43, 23);
            label_HSD_Filter.TabIndex = 46;
            label_HSD_Filter.Text = "HSD";
            label_HSD_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_Nam_Filter
            // 
            textBox_Nam_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Nam_Filter.BorderStyle = BorderStyle.None;
            textBox_Nam_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Nam_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Nam_Filter.Location = new Point(184, 439);
            textBox_Nam_Filter.Margin = new Padding(2);
            textBox_Nam_Filter.Name = "textBox_Nam_Filter";
            textBox_Nam_Filter.Size = new Size(48, 27);
            textBox_Nam_Filter.TabIndex = 45;
            // 
            // label_Nam_Filter
            // 
            label_Nam_Filter.AutoSize = true;
            label_Nam_Filter.BackColor = Color.Transparent;
            label_Nam_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Nam_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_Nam_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_Nam_Filter.Location = new Point(188, 405);
            label_Nam_Filter.Margin = new Padding(2, 0, 2, 0);
            label_Nam_Filter.Name = "label_Nam_Filter";
            label_Nam_Filter.Size = new Size(47, 23);
            label_Nam_Filter.TabIndex = 44;
            label_Nam_Filter.Text = "Năm";
            label_Nam_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // comboBox_Thang_Filter
            // 
            comboBox_Thang_Filter.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_Thang_Filter.FlatStyle = FlatStyle.Flat;
            comboBox_Thang_Filter.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_Thang_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_Thang_Filter.FormattingEnabled = true;
            comboBox_Thang_Filter.Items.AddRange(new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            comboBox_Thang_Filter.Location = new Point(96, 432);
            comboBox_Thang_Filter.Margin = new Padding(2);
            comboBox_Thang_Filter.Name = "comboBox_Thang_Filter";
            comboBox_Thang_Filter.Size = new Size(69, 36);
            comboBox_Thang_Filter.TabIndex = 43;
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
            // textBox_Ngay_Filter
            // 
            textBox_Ngay_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Ngay_Filter.BorderStyle = BorderStyle.None;
            textBox_Ngay_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Ngay_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Ngay_Filter.Location = new Point(24, 439);
            textBox_Ngay_Filter.Margin = new Padding(2);
            textBox_Ngay_Filter.Name = "textBox_Ngay_Filter";
            textBox_Ngay_Filter.Size = new Size(44, 27);
            textBox_Ngay_Filter.TabIndex = 41;
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
            // label_SoLuong_Filter
            // 
            label_SoLuong_Filter.AutoSize = true;
            label_SoLuong_Filter.BackColor = Color.Transparent;
            label_SoLuong_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SoLuong_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_SoLuong_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_SoLuong_Filter.Location = new Point(164, 337);
            label_SoLuong_Filter.Margin = new Padding(2, 0, 2, 0);
            label_SoLuong_Filter.Name = "label_SoLuong_Filter";
            label_SoLuong_Filter.Size = new Size(78, 23);
            label_SoLuong_Filter.TabIndex = 39;
            label_SoLuong_Filter.Text = "Số lượng";
            label_SoLuong_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_DonVi_Filter
            // 
            label_DonVi_Filter.AutoSize = true;
            label_DonVi_Filter.BackColor = Color.Transparent;
            label_DonVi_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DonVi_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_DonVi_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_DonVi_Filter.Location = new Point(15, 337);
            label_DonVi_Filter.Margin = new Padding(2, 0, 2, 0);
            label_DonVi_Filter.Name = "label_DonVi_Filter";
            label_DonVi_Filter.Size = new Size(59, 23);
            label_DonVi_Filter.TabIndex = 37;
            label_DonVi_Filter.Text = "Đơn vị";
            label_DonVi_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_DonVi_Filter
            // 
            textBox_DonVi_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_DonVi_Filter.BorderStyle = BorderStyle.None;
            textBox_DonVi_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_DonVi_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_DonVi_Filter.Location = new Point(15, 362);
            textBox_DonVi_Filter.Margin = new Padding(2);
            textBox_DonVi_Filter.Name = "textBox_DonVi_Filter";
            textBox_DonVi_Filter.Size = new Size(102, 27);
            textBox_DonVi_Filter.TabIndex = 36;
            // 
            // label_XuatXu_Filter
            // 
            label_XuatXu_Filter.AutoSize = true;
            label_XuatXu_Filter.BackColor = Color.Transparent;
            label_XuatXu_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_XuatXu_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_XuatXu_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_XuatXu_Filter.Location = new Point(12, 274);
            label_XuatXu_Filter.Margin = new Padding(2, 0, 2, 0);
            label_XuatXu_Filter.Name = "label_XuatXu_Filter";
            label_XuatXu_Filter.Size = new Size(68, 23);
            label_XuatXu_Filter.TabIndex = 35;
            label_XuatXu_Filter.Text = "Xuất xứ";
            label_XuatXu_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_XuatXu_Filter
            // 
            textBox_XuatXu_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_XuatXu_Filter.BorderStyle = BorderStyle.None;
            textBox_XuatXu_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_XuatXu_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_XuatXu_Filter.Location = new Point(12, 308);
            textBox_XuatXu_Filter.Margin = new Padding(2);
            textBox_XuatXu_Filter.Name = "textBox_XuatXu_Filter";
            textBox_XuatXu_Filter.Size = new Size(285, 27);
            textBox_XuatXu_Filter.TabIndex = 34;
            // 
            // label_GiaBan_Filter
            // 
            label_GiaBan_Filter.AutoSize = true;
            label_GiaBan_Filter.BackColor = Color.Transparent;
            label_GiaBan_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaBan_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaBan_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaBan_Filter.Location = new Point(164, 205);
            label_GiaBan_Filter.Margin = new Padding(2, 0, 2, 0);
            label_GiaBan_Filter.Name = "label_GiaBan_Filter";
            label_GiaBan_Filter.Size = new Size(69, 23);
            label_GiaBan_Filter.TabIndex = 33;
            label_GiaBan_Filter.Text = "Giá bán";
            label_GiaBan_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_GiaBan_Filter
            // 
            textBox_GiaBan_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_GiaBan_Filter.BorderStyle = BorderStyle.None;
            textBox_GiaBan_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_GiaBan_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_GiaBan_Filter.Location = new Point(164, 240);
            textBox_GiaBan_Filter.Margin = new Padding(2);
            textBox_GiaBan_Filter.Name = "textBox_GiaBan_Filter";
            textBox_GiaBan_Filter.Size = new Size(102, 27);
            textBox_GiaBan_Filter.TabIndex = 32;
            // 
            // label_GiaNhap_Filter
            // 
            label_GiaNhap_Filter.AutoSize = true;
            label_GiaNhap_Filter.BackColor = Color.Transparent;
            label_GiaNhap_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaNhap_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaNhap_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaNhap_Filter.Location = new Point(12, 205);
            label_GiaNhap_Filter.Margin = new Padding(2, 0, 2, 0);
            label_GiaNhap_Filter.Name = "label_GiaNhap_Filter";
            label_GiaNhap_Filter.Size = new Size(79, 23);
            label_GiaNhap_Filter.TabIndex = 31;
            label_GiaNhap_Filter.Text = "Giá nhập";
            label_GiaNhap_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_GiaNhap_Filter
            // 
            textBox_GiaNhap_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_GiaNhap_Filter.BorderStyle = BorderStyle.None;
            textBox_GiaNhap_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_GiaNhap_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_GiaNhap_Filter.Location = new Point(12, 245);
            textBox_GiaNhap_Filter.Margin = new Padding(2);
            textBox_GiaNhap_Filter.Name = "textBox_GiaNhap_Filter";
            textBox_GiaNhap_Filter.Size = new Size(102, 27);
            textBox_GiaNhap_Filter.TabIndex = 30;
            // 
            // label_TenDP_Filter
            // 
            label_TenDP_Filter.AutoSize = true;
            label_TenDP_Filter.BackColor = Color.Transparent;
            label_TenDP_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TenDP_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_TenDP_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_TenDP_Filter.Location = new Point(12, 134);
            label_TenDP_Filter.Margin = new Padding(2, 0, 2, 0);
            label_TenDP_Filter.Name = "label_TenDP_Filter";
            label_TenDP_Filter.Size = new Size(128, 23);
            label_TenDP_Filter.TabIndex = 14;
            label_TenDP_Filter.Text = "Tên dược phẩm";
            label_TenDP_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_MaDP_Filter
            // 
            label_MaDP_Filter.AutoSize = true;
            label_MaDP_Filter.BackColor = Color.Transparent;
            label_MaDP_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_MaDP_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_MaDP_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_MaDP_Filter.Location = new Point(12, 55);
            label_MaDP_Filter.Margin = new Padding(2, 0, 2, 0);
            label_MaDP_Filter.Name = "label_MaDP_Filter";
            label_MaDP_Filter.Size = new Size(126, 23);
            label_MaDP_Filter.TabIndex = 13;
            label_MaDP_Filter.Text = "Mã dược phẩm";
            label_MaDP_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_TenDP_Filter
            // 
            textBox_TenDP_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_TenDP_Filter.BorderStyle = BorderStyle.None;
            textBox_TenDP_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_TenDP_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_TenDP_Filter.Location = new Point(12, 159);
            textBox_TenDP_Filter.Margin = new Padding(2);
            textBox_TenDP_Filter.Name = "textBox_TenDP_Filter";
            textBox_TenDP_Filter.Size = new Size(293, 27);
            textBox_TenDP_Filter.TabIndex = 12;
            // 
            // textBox_MaDP_Filter
            // 
            textBox_MaDP_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_MaDP_Filter.BorderStyle = BorderStyle.None;
            textBox_MaDP_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_MaDP_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_MaDP_Filter.Location = new Point(12, 90);
            textBox_MaDP_Filter.Margin = new Padding(2);
            textBox_MaDP_Filter.Name = "textBox_MaDP_Filter";
            textBox_MaDP_Filter.Size = new Size(293, 27);
            textBox_MaDP_Filter.TabIndex = 11;
            // 
            // button_OK_Filter
            // 
            button_OK_Filter.FlatStyle = FlatStyle.Flat;
            button_OK_Filter.Font = new Font("Segoe UI", 10F);
            button_OK_Filter.ForeColor = Color.FromArgb(148, 255, 216);
            button_OK_Filter.Location = new Point(20, 568);
            button_OK_Filter.Margin = new Padding(2);
            button_OK_Filter.Name = "button_OK_Filter";
            button_OK_Filter.Size = new Size(75, 34);
            button_OK_Filter.TabIndex = 4;
            button_OK_Filter.Text = "OK";
            button_OK_Filter.UseVisualStyleBackColor = true;
            button_OK_Filter.Click += button_OK_Filter_Click;
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
        #endregion
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
            panel_Filter.BringToFront();
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

        private void button_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = "1 = 1 ";

            if (string.IsNullOrEmpty(textBox_MaDP_Filter.Text) == false)
                selectCommand += $"AND MaDP = '{textBox_MaDP_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_TenDP_Filter.Text) == false)
                selectCommand += $"AND TenDP = '{textBox_TenDP_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_GiaNhap_Filter.Text) == false)
                selectCommand += $"AND GiaNhap >= {textBox_GiaNhap_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_GiaBan_Filter.Text) == false)
                selectCommand += $"AND GiaBan >= {textBox_GiaBan_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_XuatXu_Filter.Text) == false)
                selectCommand += $"AND XuatXu = '{textBox_XuatXu_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_DonVi_Filter.Text) == false)
                selectCommand += $"AND DonVi >= {textBox_DonVi_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_SoLuong_Filter.Text) == false)
                selectCommand += $"AND SoLuong >= {textBox_SoLuong_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_HSD_Filter.Text) == false)
                selectCommand += $"AND HSD >= {textBox_HSD_Filter.Text} ";


            string ngayLap = GetNgayThangNam(textBox_Ngay_Filter, comboBox_Thang_Filter, textBox_Nam_Filter);

            if (string.IsNullOrEmpty(ngayLap) == false)
                selectCommand += $"AND NgayNhap >= '{ngayLap}' ";

            DataRow[] resultRow = datatable.Select(selectCommand);
            DataTable resultDatatable = datatable.Clone();

            foreach (DataRow row in resultRow)
            {
                if (resultDatatable.Rows.Contains(row["MaDP"]))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
        }
    }
}
