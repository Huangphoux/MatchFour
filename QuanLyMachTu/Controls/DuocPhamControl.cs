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
        private string DP_SelectCommand = "SELECT MaDP, TenDP, SoLuong, MoTa, GiaNhap, GiaBan, XuatXu, DonVi, NgayNhap, HSD, TinhTrang, SoLuongMoiDonVi " +
                                          "FROM DUOCPHAM " +
                                          "WHERE IsDeleted = 0 ";
        private string selectLastID = "SELECT TOP 1 MaDP FROM DUOCPHAM ORDER BY MaDP DESC ";
        private string controlCommand;
        //Control variables
        string next_DP_PrimaryKey;
        List<string> SoLuongThieu_highlightList = new List<string>();
        int controlFunc;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;

        //controllers

        #region "Controls"
        int controlPage;
        DataTable controlDataTable;
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
        private Label label_SoLuongTot;
        private TextBox textBox_TKUpload_MatKhau;
        private TextBox textBox_TKUpload_MaTK;
        private Label label18;
        private Label label_Upload;
        private Label label_TenDP;
        private Label label_MaDP;
        private TextBox textBox_TenDP;
        private TextBox textBox_MaDP;
        private Label label_SoLuong;
        private TextBox textBox_SoLuong;
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
        private Label label7;
        private Label label6;
        private CustomPanel customPanel_DetailsControl;
        private TextBox textBox_MoTa;
        private Label label_MoTa;
        private Panel panel_TopPanel;
        private Button button_Upload_OK;
        private Label label9;
        private TextBox textBox_SoLuongMoiDonVi;
        private TextBox textBox1;
        private Label label12;
        private Label label13;
        private TextBox textBox_SoLuongMoiDonVi_Filter;
        private ComboBox comboBox_TinhTrang_Filter;
        private Label label10;
        private CheckBox checkBox_SoLuongThieu_Conditions;
        private CheckBox checkBox_SapHetHan_Conditions;
        private Button button_Filter_Reset;
        private Button button_Upload_Reset;
        private Label label_NgayNhap;
        private Label label16;
        private Label label_SoLuongDuocPham;
        private Label label14;
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
            panel_Toolbar = new Panel();
            checkBox_SoLuongThieu_Conditions = new CheckBox();
            checkBox_SapHetHan_Conditions = new CheckBox();
            pageButton_Filter = new PageButton();
            pageButton_Remove = new PageButton();
            pageButton_Upload = new PageButton();
            panel_Upload = new Panel();
            label_NgayNhap = new Label();
            button_Upload_Reset = new Button();
            label9 = new Label();
            textBox_SoLuongMoiDonVi = new TextBox();
            button_Upload_OK = new Button();
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
            label_Upload = new Label();
            customDataGridView = new CustomDataGridView();
            panel_Filter = new Panel();
            button_Filter_Reset = new Button();
            comboBox_TinhTrang_Filter = new ComboBox();
            label10 = new Label();
            label12 = new Label();
            label13 = new Label();
            textBox_SoLuongMoiDonVi_Filter = new TextBox();
            label8 = new Label();
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
            customPanel_DetailsControl = new CustomPanel();
            label_SoLuongTot = new Label();
            label16 = new Label();
            label_SoLuongDuocPham = new Label();
            label14 = new Label();
            panel_TopPanel = new Panel();
            panel_Toolbar.SuspendLayout();
            panel_Upload.SuspendLayout();
            ((ISupportInitialize)customDataGridView).BeginInit();
            panel_Filter.SuspendLayout();
            customPanel_DetailsControl.SuspendLayout();
            SuspendLayout();
            // 
            // panel_Toolbar
            // 
            panel_Toolbar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel_Toolbar.BackColor = Color.FromArgb(57, 54, 70);
            panel_Toolbar.Controls.Add(checkBox_SoLuongThieu_Conditions);
            panel_Toolbar.Controls.Add(checkBox_SapHetHan_Conditions);
            panel_Toolbar.Controls.Add(pageButton_Filter);
            panel_Toolbar.Controls.Add(pageButton_Remove);
            panel_Toolbar.Controls.Add(pageButton_Upload);
            panel_Toolbar.Location = new Point(0, 84);
            panel_Toolbar.Margin = new Padding(2);
            panel_Toolbar.Name = "panel_Toolbar";
            panel_Toolbar.Size = new Size(1174, 80);
            panel_Toolbar.TabIndex = 1;
            // 
            // checkBox_SoLuongThieu_Conditions
            // 
            checkBox_SoLuongThieu_Conditions.Anchor = AnchorStyles.Right;
            checkBox_SoLuongThieu_Conditions.AutoSize = true;
            checkBox_SoLuongThieu_Conditions.Checked = true;
            checkBox_SoLuongThieu_Conditions.CheckState = CheckState.Checked;
            checkBox_SoLuongThieu_Conditions.FlatStyle = FlatStyle.Flat;
            checkBox_SoLuongThieu_Conditions.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            checkBox_SoLuongThieu_Conditions.ForeColor = Color.White;
            checkBox_SoLuongThieu_Conditions.Location = new Point(712, 22);
            checkBox_SoLuongThieu_Conditions.Margin = new Padding(2);
            checkBox_SoLuongThieu_Conditions.Name = "checkBox_SoLuongThieu_Conditions";
            checkBox_SoLuongThieu_Conditions.Size = new Size(182, 34);
            checkBox_SoLuongThieu_Conditions.TabIndex = 102;
            checkBox_SoLuongThieu_Conditions.Text = "Số lượng thiếu";
            checkBox_SoLuongThieu_Conditions.UseVisualStyleBackColor = true;
            checkBox_SoLuongThieu_Conditions.CheckedChanged += checkBox_CheckedChanged;
            // 
            // checkBox_SapHetHan_Conditions
            // 
            checkBox_SapHetHan_Conditions.Anchor = AnchorStyles.Right;
            checkBox_SapHetHan_Conditions.AutoSize = true;
            checkBox_SapHetHan_Conditions.Checked = true;
            checkBox_SapHetHan_Conditions.CheckState = CheckState.Checked;
            checkBox_SapHetHan_Conditions.FlatStyle = FlatStyle.Flat;
            checkBox_SapHetHan_Conditions.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            checkBox_SapHetHan_Conditions.ForeColor = Color.White;
            checkBox_SapHetHan_Conditions.Location = new Point(929, 22);
            checkBox_SapHetHan_Conditions.Margin = new Padding(2);
            checkBox_SapHetHan_Conditions.Name = "checkBox_SapHetHan_Conditions";
            checkBox_SapHetHan_Conditions.Size = new Size(152, 34);
            checkBox_SapHetHan_Conditions.TabIndex = 101;
            checkBox_SapHetHan_Conditions.Text = "Sắp hết hạn";
            checkBox_SapHetHan_Conditions.UseVisualStyleBackColor = true;
            checkBox_SapHetHan_Conditions.CheckedChanged += checkBox_CheckedChanged;
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
            pageButton_Filter.Location = new Point(1094, 13);
            pageButton_Filter.Margin = new Padding(2);
            pageButton_Filter.Name = "pageButton_Filter";
            pageButton_Filter.Size = new Size(55, 55);
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
            pageButton_Remove.Location = new Point(90, 13);
            pageButton_Remove.Margin = new Padding(2);
            pageButton_Remove.Name = "pageButton_Remove";
            pageButton_Remove.Size = new Size(55, 55);
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
            pageButton_Upload.Location = new Point(25, 13);
            pageButton_Upload.Margin = new Padding(2);
            pageButton_Upload.Name = "pageButton_Upload";
            pageButton_Upload.Size = new Size(55, 55);
            pageButton_Upload.TabIndex = 1;
            pageButton_Upload.TextLocation = new Point(0, 0);
            pageButton_Upload.UseVisualStyleBackColor = false;
            pageButton_Upload.Click += pageButton_Upload_Click;
            // 
            // panel_Upload
            // 
            panel_Upload.Anchor = AnchorStyles.Right;
            panel_Upload.AutoScroll = true;
            panel_Upload.AutoScrollMinSize = new Size(0, 1175);
            panel_Upload.BackColor = Color.FromArgb(57, 54, 70);
            panel_Upload.Controls.Add(label_NgayNhap);
            panel_Upload.Controls.Add(button_Upload_Reset);
            panel_Upload.Controls.Add(label9);
            panel_Upload.Controls.Add(textBox_SoLuongMoiDonVi);
            panel_Upload.Controls.Add(button_Upload_OK);
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
            panel_Upload.Controls.Add(label_Upload);
            panel_Upload.Location = new Point(1174, 84);
            panel_Upload.Margin = new Padding(2);
            panel_Upload.Name = "panel_Upload";
            panel_Upload.Size = new Size(416, 780);
            panel_Upload.TabIndex = 21;
            panel_Upload.Paint += panel_Paint;
            // 
            // label_NgayNhap
            // 
            label_NgayNhap.AccessibleRole = AccessibleRole.None;
            label_NgayNhap.AutoSize = true;
            label_NgayNhap.BackColor = Color.Transparent;
            label_NgayNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_NgayNhap.ForeColor = Color.FromArgb(193, 193, 193);
            label_NgayNhap.ImageAlign = ContentAlignment.BottomCenter;
            label_NgayNhap.Location = new Point(300, 282);
            label_NgayNhap.Name = "label_NgayNhap";
            label_NgayNhap.Size = new Size(108, 28);
            label_NgayNhap.TabIndex = 55;
            label_NgayNhap.Text = "Ngày nhập";
            label_NgayNhap.TextAlign = ContentAlignment.BottomLeft;
            // 
            // button_Upload_Reset
            // 
            button_Upload_Reset.FlatStyle = FlatStyle.Flat;
            button_Upload_Reset.Font = new Font("Segoe UI", 10F);
            button_Upload_Reset.ForeColor = Color.FromArgb(38, 187, 255);
            button_Upload_Reset.Location = new Point(297, 1106);
            button_Upload_Reset.Name = "button_Upload_Reset";
            button_Upload_Reset.Size = new Size(94, 43);
            button_Upload_Reset.TabIndex = 54;
            button_Upload_Reset.Text = "RESET";
            button_Upload_Reset.UseVisualStyleBackColor = true;
            button_Upload_Reset.Click += button_Upload_Reset_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(193, 193, 193);
            label9.ImageAlign = ContentAlignment.BottomCenter;
            label9.Location = new Point(25, 678);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(152, 28);
            label9.TabIndex = 50;
            label9.Text = "Số lượng đơn vị";
            label9.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_SoLuongMoiDonVi
            // 
            textBox_SoLuongMoiDonVi.BackColor = Color.FromArgb(57, 54, 70);
            textBox_SoLuongMoiDonVi.BorderStyle = BorderStyle.None;
            textBox_SoLuongMoiDonVi.Font = new Font("Segoe UI Semilight", 12F);
            textBox_SoLuongMoiDonVi.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_SoLuongMoiDonVi.Location = new Point(25, 722);
            textBox_SoLuongMoiDonVi.Margin = new Padding(2);
            textBox_SoLuongMoiDonVi.Name = "textBox_SoLuongMoiDonVi";
            textBox_SoLuongMoiDonVi.Size = new Size(160, 32);
            textBox_SoLuongMoiDonVi.TabIndex = 49;
            textBox_SoLuongMoiDonVi.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // button_Upload_OK
            // 
            button_Upload_OK.FlatStyle = FlatStyle.Flat;
            button_Upload_OK.Font = new Font("Segoe UI", 10F);
            button_Upload_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_Upload_OK.Location = new Point(20, 1106);
            button_Upload_OK.Margin = new Padding(2);
            button_Upload_OK.Name = "button_Upload_OK";
            button_Upload_OK.Size = new Size(94, 43);
            button_Upload_OK.TabIndex = 4;
            button_Upload_OK.Text = "OK";
            button_Upload_OK.UseVisualStyleBackColor = true;
            button_Upload_OK.Click += button_Upload_OK_Click;
            // 
            // textBox_SoLuong
            // 
            textBox_SoLuong.BackColor = Color.FromArgb(57, 54, 70);
            textBox_SoLuong.BorderStyle = BorderStyle.None;
            textBox_SoLuong.Font = new Font("Segoe UI Semilight", 12F);
            textBox_SoLuong.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_SoLuong.Location = new Point(25, 524);
            textBox_SoLuong.Margin = new Padding(2);
            textBox_SoLuong.Name = "textBox_SoLuong";
            textBox_SoLuong.Size = new Size(160, 32);
            textBox_SoLuong.TabIndex = 48;
            textBox_SoLuong.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // textBox_HSD
            // 
            textBox_HSD.BackColor = Color.FromArgb(57, 54, 70);
            textBox_HSD.BorderStyle = BorderStyle.None;
            textBox_HSD.Font = new Font("Segoe UI Semilight", 12F);
            textBox_HSD.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_HSD.Location = new Point(230, 623);
            textBox_HSD.Margin = new Padding(2);
            textBox_HSD.Name = "textBox_HSD";
            textBox_HSD.Size = new Size(160, 32);
            textBox_HSD.TabIndex = 47;
            textBox_HSD.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // label_HSD
            // 
            label_HSD.AutoSize = true;
            label_HSD.BackColor = Color.Transparent;
            label_HSD.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_HSD.ForeColor = Color.FromArgb(193, 193, 193);
            label_HSD.ImageAlign = ContentAlignment.BottomCenter;
            label_HSD.Location = new Point(230, 579);
            label_HSD.Margin = new Padding(2, 0, 2, 0);
            label_HSD.Name = "label_HSD";
            label_HSD.Size = new Size(123, 28);
            label_HSD.TabIndex = 46;
            label_HSD.Text = "Hạn sử dụng";
            label_HSD.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_Nam
            // 
            textBox_Nam.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Nam.BorderStyle = BorderStyle.None;
            textBox_Nam.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Nam.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Nam.Location = new Point(230, 326);
            textBox_Nam.Margin = new Padding(2);
            textBox_Nam.Name = "textBox_Nam";
            textBox_Nam.Size = new Size(60, 32);
            textBox_Nam.TabIndex = 45;
            textBox_Nam.TextAlign = HorizontalAlignment.Center;
            textBox_Nam.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // label_Nam
            // 
            label_Nam.AutoSize = true;
            label_Nam.BackColor = Color.Transparent;
            label_Nam.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Nam.ForeColor = Color.FromArgb(193, 193, 193);
            label_Nam.ImageAlign = ContentAlignment.BottomCenter;
            label_Nam.Location = new Point(230, 282);
            label_Nam.Margin = new Padding(2, 0, 2, 0);
            label_Nam.Name = "label_Nam";
            label_Nam.Size = new Size(54, 28);
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
            comboBox_Thang.Location = new Point(125, 326);
            comboBox_Thang.Margin = new Padding(2);
            comboBox_Thang.Name = "comboBox_Thang";
            comboBox_Thang.Size = new Size(85, 40);
            comboBox_Thang.TabIndex = 43;
            // 
            // label_Thang
            // 
            label_Thang.AutoSize = true;
            label_Thang.BackColor = Color.Transparent;
            label_Thang.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Thang.ForeColor = Color.FromArgb(193, 193, 193);
            label_Thang.ImageAlign = ContentAlignment.BottomCenter;
            label_Thang.Location = new Point(125, 282);
            label_Thang.Margin = new Padding(2, 0, 2, 0);
            label_Thang.Name = "label_Thang";
            label_Thang.Size = new Size(66, 28);
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
            textBox_Ngay.Location = new Point(25, 326);
            textBox_Ngay.Margin = new Padding(2);
            textBox_Ngay.Name = "textBox_Ngay";
            textBox_Ngay.Size = new Size(55, 32);
            textBox_Ngay.TabIndex = 41;
            textBox_Ngay.TextAlign = HorizontalAlignment.Center;
            textBox_Ngay.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // label_Ngay
            // 
            label_Ngay.AutoSize = true;
            label_Ngay.BackColor = Color.Transparent;
            label_Ngay.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Ngay.ForeColor = Color.FromArgb(193, 193, 193);
            label_Ngay.ImageAlign = ContentAlignment.BottomCenter;
            label_Ngay.Location = new Point(25, 282);
            label_Ngay.Margin = new Padding(2, 0, 2, 0);
            label_Ngay.Name = "label_Ngay";
            label_Ngay.Size = new Size(59, 28);
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
            label_SoLuong.Location = new Point(25, 480);
            label_SoLuong.Margin = new Padding(2, 0, 2, 0);
            label_SoLuong.Name = "label_SoLuong";
            label_SoLuong.Size = new Size(141, 28);
            label_SoLuong.TabIndex = 39;
            label_SoLuong.Text = "Số lượng nhập";
            label_SoLuong.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_DonVi
            // 
            label_DonVi.AutoSize = true;
            label_DonVi.BackColor = Color.Transparent;
            label_DonVi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DonVi.ForeColor = Color.FromArgb(193, 193, 193);
            label_DonVi.ImageAlign = ContentAlignment.BottomCenter;
            label_DonVi.Location = new Point(230, 480);
            label_DonVi.Margin = new Padding(2, 0, 2, 0);
            label_DonVi.Name = "label_DonVi";
            label_DonVi.Size = new Size(69, 28);
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
            textBox_DonVi.Location = new Point(230, 524);
            textBox_DonVi.Margin = new Padding(2);
            textBox_DonVi.Name = "textBox_DonVi";
            textBox_DonVi.Size = new Size(160, 32);
            textBox_DonVi.TabIndex = 36;
            textBox_DonVi.KeyPress += button_KeyPress_Normal;
            // 
            // label_XuatXu
            // 
            label_XuatXu.AutoSize = true;
            label_XuatXu.BackColor = Color.Transparent;
            label_XuatXu.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_XuatXu.ForeColor = Color.FromArgb(193, 193, 193);
            label_XuatXu.ImageAlign = ContentAlignment.BottomCenter;
            label_XuatXu.Location = new Point(25, 579);
            label_XuatXu.Margin = new Padding(2, 0, 2, 0);
            label_XuatXu.Name = "label_XuatXu";
            label_XuatXu.Size = new Size(78, 28);
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
            textBox_XuatXu.Location = new Point(25, 623);
            textBox_XuatXu.Margin = new Padding(2);
            textBox_XuatXu.Name = "textBox_XuatXu";
            textBox_XuatXu.Size = new Size(160, 32);
            textBox_XuatXu.TabIndex = 34;
            textBox_XuatXu.KeyPress += button_KeyPress_Normal;
            // 
            // label_GiaBan
            // 
            label_GiaBan.AutoSize = true;
            label_GiaBan.BackColor = Color.Transparent;
            label_GiaBan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaBan.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaBan.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaBan.Location = new Point(230, 381);
            label_GiaBan.Margin = new Padding(2, 0, 2, 0);
            label_GiaBan.Name = "label_GiaBan";
            label_GiaBan.Size = new Size(79, 28);
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
            textBox_GiaBan.Location = new Point(230, 425);
            textBox_GiaBan.Margin = new Padding(2);
            textBox_GiaBan.Name = "textBox_GiaBan";
            textBox_GiaBan.Size = new Size(160, 32);
            textBox_GiaBan.TabIndex = 32;
            textBox_GiaBan.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // label_GiaNhap
            // 
            label_GiaNhap.AutoSize = true;
            label_GiaNhap.BackColor = Color.Transparent;
            label_GiaNhap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaNhap.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaNhap.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaNhap.Location = new Point(25, 381);
            label_GiaNhap.Margin = new Padding(2, 0, 2, 0);
            label_GiaNhap.Name = "label_GiaNhap";
            label_GiaNhap.Size = new Size(90, 28);
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
            textBox_GiaNhap.Location = new Point(25, 425);
            textBox_GiaNhap.Margin = new Padding(2);
            textBox_GiaNhap.Name = "textBox_GiaNhap";
            textBox_GiaNhap.Size = new Size(160, 32);
            textBox_GiaNhap.TabIndex = 30;
            textBox_GiaNhap.KeyPress += Button_KeyPress_PositiveNumber;
            // 
            // textBox_MoTa
            // 
            textBox_MoTa.BackColor = Color.FromArgb(57, 54, 70);
            textBox_MoTa.Font = new Font("Segoe UI Semilight", 12F);
            textBox_MoTa.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_MoTa.Location = new Point(20, 821);
            textBox_MoTa.Margin = new Padding(2);
            textBox_MoTa.Multiline = true;
            textBox_MoTa.Name = "textBox_MoTa";
            textBox_MoTa.Size = new Size(375, 239);
            textBox_MoTa.TabIndex = 29;
            textBox_MoTa.KeyPress += button_KeyPress_Normal;
            // 
            // label_MoTa
            // 
            label_MoTa.AutoSize = true;
            label_MoTa.BackColor = Color.Transparent;
            label_MoTa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_MoTa.ForeColor = Color.FromArgb(193, 193, 193);
            label_MoTa.ImageAlign = ContentAlignment.BottomCenter;
            label_MoTa.Location = new Point(25, 777);
            label_MoTa.Margin = new Padding(2, 0, 2, 0);
            label_MoTa.Name = "label_MoTa";
            label_MoTa.Size = new Size(64, 28);
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
            label_TenDP.Location = new Point(25, 183);
            label_TenDP.Margin = new Padding(2, 0, 2, 0);
            label_TenDP.Name = "label_TenDP";
            label_TenDP.Size = new Size(146, 28);
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
            label_MaDP.Location = new Point(25, 84);
            label_MaDP.Margin = new Padding(2, 0, 2, 0);
            label_MaDP.Name = "label_MaDP";
            label_MaDP.Size = new Size(145, 28);
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
            textBox_TenDP.Location = new Point(25, 227);
            textBox_TenDP.Margin = new Padding(2);
            textBox_TenDP.Name = "textBox_TenDP";
            textBox_TenDP.Size = new Size(365, 32);
            textBox_TenDP.TabIndex = 12;
            textBox_TenDP.KeyPress += button_KeyPress_Normal;
            // 
            // textBox_MaDP
            // 
            textBox_MaDP.BackColor = Color.FromArgb(57, 54, 70);
            textBox_MaDP.BorderStyle = BorderStyle.None;
            textBox_MaDP.Font = new Font("Segoe UI Semilight", 12F);
            textBox_MaDP.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_MaDP.Location = new Point(25, 128);
            textBox_MaDP.Margin = new Padding(2);
            textBox_MaDP.Name = "textBox_MaDP";
            textBox_MaDP.Size = new Size(365, 32);
            textBox_MaDP.TabIndex = 11;
            textBox_MaDP.KeyPress += button_KeyPress_Normal;
            textBox_MaDP.Leave += textBox_MaTK_Leave;
            // 
            // label_Upload
            // 
            label_Upload.AutoSize = true;
            label_Upload.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_Upload.ForeColor = Color.White;
            label_Upload.Location = new Point(15, 8);
            label_Upload.Margin = new Padding(2, 0, 2, 0);
            label_Upload.Name = "label_Upload";
            label_Upload.Size = new Size(110, 38);
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
            customDataGridView.Location = new Point(25, 168);
            customDataGridView.Margin = new Padding(2);
            customDataGridView.Name = "customDataGridView";
            customDataGridView.ReadOnly = true;
            customDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            customDataGridView.RowHeadersVisible = false;
            customDataGridView.RowHeadersWidth = 62;
            customDataGridView.Size = new Size(1124, 600);
            customDataGridView.TabIndex = 22;
            customDataGridView.CellMouseDoubleClick += customDataGridView_CellMouseDoubleClicked;
            customDataGridView.RowPrePaint += customDataGridView_RowPrePaint;
            // 
            // panel_Filter
            // 
            panel_Filter.Anchor = AnchorStyles.Right;
            panel_Filter.AutoScroll = true;
            panel_Filter.AutoSize = true;
            panel_Filter.BackColor = Color.FromArgb(57, 54, 70);
            panel_Filter.Controls.Add(button_Filter_Reset);
            panel_Filter.Controls.Add(comboBox_TinhTrang_Filter);
            panel_Filter.Controls.Add(label10);
            panel_Filter.Controls.Add(label12);
            panel_Filter.Controls.Add(label13);
            panel_Filter.Controls.Add(textBox_SoLuongMoiDonVi_Filter);
            panel_Filter.Controls.Add(label8);
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
            panel_Filter.Location = new Point(1174, 84);
            panel_Filter.Margin = new Padding(2);
            panel_Filter.Name = "panel_Filter";
            panel_Filter.Size = new Size(416, 780);
            panel_Filter.TabIndex = 49;
            panel_Filter.Paint += panel_Paint;
            // 
            // button_Filter_Reset
            // 
            button_Filter_Reset.FlatStyle = FlatStyle.Flat;
            button_Filter_Reset.Font = new Font("Segoe UI", 10F);
            button_Filter_Reset.ForeColor = Color.FromArgb(38, 187, 255);
            button_Filter_Reset.Location = new Point(297, 710);
            button_Filter_Reset.Name = "button_Filter_Reset";
            button_Filter_Reset.Size = new Size(94, 43);
            button_Filter_Reset.TabIndex = 61;
            button_Filter_Reset.Text = "RESET";
            button_Filter_Reset.UseVisualStyleBackColor = true;
            button_Filter_Reset.Click += button_Filter_Reset_Click;
            // 
            // comboBox_TinhTrang_Filter
            // 
            comboBox_TinhTrang_Filter.BackColor = Color.FromArgb(57, 54, 70);
            comboBox_TinhTrang_Filter.FlatStyle = FlatStyle.Flat;
            comboBox_TinhTrang_Filter.Font = new Font("Segoe UI Semilight", 12F);
            comboBox_TinhTrang_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            comboBox_TinhTrang_Filter.FormattingEnabled = true;
            comboBox_TinhTrang_Filter.Items.AddRange(new object[] { "Mới", "Quá hạn", "Hết", "Đã ngưng" });
            comboBox_TinhTrang_Filter.Location = new Point(230, 623);
            comboBox_TinhTrang_Filter.Margin = new Padding(2);
            comboBox_TinhTrang_Filter.Name = "comboBox_TinhTrang_Filter";
            comboBox_TinhTrang_Filter.Size = new Size(160, 40);
            comboBox_TinhTrang_Filter.TabIndex = 60;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(193, 193, 193);
            label10.ImageAlign = ContentAlignment.BottomCenter;
            label10.Location = new Point(159, 623);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(26, 28);
            label10.TabIndex = 59;
            label10.Text = "≥";
            label10.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(193, 193, 193);
            label12.ImageAlign = ContentAlignment.BottomCenter;
            label12.Location = new Point(231, 579);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(101, 28);
            label12.TabIndex = 57;
            label12.Text = "Tình trạng";
            label12.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(193, 193, 193);
            label13.ImageAlign = ContentAlignment.BottomCenter;
            label13.Location = new Point(26, 579);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(152, 28);
            label13.TabIndex = 56;
            label13.Text = "Số lượng đơn vị";
            label13.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_SoLuongMoiDonVi_Filter
            // 
            textBox_SoLuongMoiDonVi_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_SoLuongMoiDonVi_Filter.BorderStyle = BorderStyle.None;
            textBox_SoLuongMoiDonVi_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_SoLuongMoiDonVi_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_SoLuongMoiDonVi_Filter.Location = new Point(26, 623);
            textBox_SoLuongMoiDonVi_Filter.Margin = new Padding(2);
            textBox_SoLuongMoiDonVi_Filter.Name = "textBox_SoLuongMoiDonVi_Filter";
            textBox_SoLuongMoiDonVi_Filter.Size = new Size(124, 32);
            textBox_SoLuongMoiDonVi_Filter.TabIndex = 55;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(193, 193, 193);
            label8.ImageAlign = ContentAlignment.BottomCenter;
            label8.Location = new Point(159, 425);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(26, 28);
            label8.TabIndex = 54;
            label8.Text = "≥";
            label8.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(193, 193, 193);
            label7.ImageAlign = ContentAlignment.BottomCenter;
            label7.Location = new Point(364, 326);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(26, 28);
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
            label6.Location = new Point(159, 326);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(26, 28);
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
            label3.Location = new Point(315, 227);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(26, 28);
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
            label2.Location = new Point(364, 524);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(26, 28);
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
            textBox_SoLuong_Filter.Location = new Point(25, 425);
            textBox_SoLuong_Filter.Margin = new Padding(2);
            textBox_SoLuong_Filter.Name = "textBox_SoLuong_Filter";
            textBox_SoLuong_Filter.Size = new Size(124, 32);
            textBox_SoLuong_Filter.TabIndex = 48;
            // 
            // textBox_HSD_Filter
            // 
            textBox_HSD_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_HSD_Filter.BorderStyle = BorderStyle.None;
            textBox_HSD_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_HSD_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_HSD_Filter.Location = new Point(230, 524);
            textBox_HSD_Filter.Margin = new Padding(2);
            textBox_HSD_Filter.Name = "textBox_HSD_Filter";
            textBox_HSD_Filter.Size = new Size(124, 32);
            textBox_HSD_Filter.TabIndex = 47;
            // 
            // label_HSD_Filter
            // 
            label_HSD_Filter.AutoSize = true;
            label_HSD_Filter.BackColor = Color.Transparent;
            label_HSD_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_HSD_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_HSD_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_HSD_Filter.Location = new Point(230, 480);
            label_HSD_Filter.Margin = new Padding(2, 0, 2, 0);
            label_HSD_Filter.Name = "label_HSD_Filter";
            label_HSD_Filter.Size = new Size(123, 28);
            label_HSD_Filter.TabIndex = 46;
            label_HSD_Filter.Text = "Hạn sử dụng";
            label_HSD_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_Nam_Filter
            // 
            textBox_Nam_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_Nam_Filter.BorderStyle = BorderStyle.None;
            textBox_Nam_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_Nam_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_Nam_Filter.Location = new Point(230, 227);
            textBox_Nam_Filter.Margin = new Padding(2);
            textBox_Nam_Filter.Name = "textBox_Nam_Filter";
            textBox_Nam_Filter.Size = new Size(60, 32);
            textBox_Nam_Filter.TabIndex = 45;
            // 
            // label_Nam_Filter
            // 
            label_Nam_Filter.AutoSize = true;
            label_Nam_Filter.BackColor = Color.Transparent;
            label_Nam_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Nam_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_Nam_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_Nam_Filter.Location = new Point(230, 183);
            label_Nam_Filter.Margin = new Padding(2, 0, 2, 0);
            label_Nam_Filter.Name = "label_Nam_Filter";
            label_Nam_Filter.Size = new Size(54, 28);
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
            comboBox_Thang_Filter.Location = new Point(125, 227);
            comboBox_Thang_Filter.Margin = new Padding(2);
            comboBox_Thang_Filter.Name = "comboBox_Thang_Filter";
            comboBox_Thang_Filter.Size = new Size(85, 40);
            comboBox_Thang_Filter.TabIndex = 43;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(193, 193, 193);
            label4.ImageAlign = ContentAlignment.BottomCenter;
            label4.Location = new Point(125, 183);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 28);
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
            textBox_Ngay_Filter.Location = new Point(25, 227);
            textBox_Ngay_Filter.Margin = new Padding(2);
            textBox_Ngay_Filter.Name = "textBox_Ngay_Filter";
            textBox_Ngay_Filter.Size = new Size(55, 32);
            textBox_Ngay_Filter.TabIndex = 41;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(193, 193, 193);
            label5.ImageAlign = ContentAlignment.BottomCenter;
            label5.Location = new Point(25, 183);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(59, 28);
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
            label_SoLuong_Filter.Location = new Point(25, 381);
            label_SoLuong_Filter.Margin = new Padding(2, 0, 2, 0);
            label_SoLuong_Filter.Name = "label_SoLuong_Filter";
            label_SoLuong_Filter.Size = new Size(141, 28);
            label_SoLuong_Filter.TabIndex = 39;
            label_SoLuong_Filter.Text = "Số lượng nhập";
            label_SoLuong_Filter.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_DonVi_Filter
            // 
            label_DonVi_Filter.AutoSize = true;
            label_DonVi_Filter.BackColor = Color.Transparent;
            label_DonVi_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DonVi_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_DonVi_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_DonVi_Filter.Location = new Point(230, 381);
            label_DonVi_Filter.Margin = new Padding(2, 0, 2, 0);
            label_DonVi_Filter.Name = "label_DonVi_Filter";
            label_DonVi_Filter.Size = new Size(69, 28);
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
            textBox_DonVi_Filter.Location = new Point(230, 425);
            textBox_DonVi_Filter.Margin = new Padding(2);
            textBox_DonVi_Filter.Name = "textBox_DonVi_Filter";
            textBox_DonVi_Filter.Size = new Size(160, 32);
            textBox_DonVi_Filter.TabIndex = 36;
            // 
            // label_XuatXu_Filter
            // 
            label_XuatXu_Filter.AutoSize = true;
            label_XuatXu_Filter.BackColor = Color.Transparent;
            label_XuatXu_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_XuatXu_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_XuatXu_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_XuatXu_Filter.Location = new Point(25, 480);
            label_XuatXu_Filter.Margin = new Padding(2, 0, 2, 0);
            label_XuatXu_Filter.Name = "label_XuatXu_Filter";
            label_XuatXu_Filter.Size = new Size(78, 28);
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
            textBox_XuatXu_Filter.Location = new Point(25, 524);
            textBox_XuatXu_Filter.Margin = new Padding(2);
            textBox_XuatXu_Filter.Name = "textBox_XuatXu_Filter";
            textBox_XuatXu_Filter.Size = new Size(160, 32);
            textBox_XuatXu_Filter.TabIndex = 34;
            // 
            // label_GiaBan_Filter
            // 
            label_GiaBan_Filter.AutoSize = true;
            label_GiaBan_Filter.BackColor = Color.Transparent;
            label_GiaBan_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaBan_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaBan_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaBan_Filter.Location = new Point(230, 282);
            label_GiaBan_Filter.Margin = new Padding(2, 0, 2, 0);
            label_GiaBan_Filter.Name = "label_GiaBan_Filter";
            label_GiaBan_Filter.Size = new Size(79, 28);
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
            textBox_GiaBan_Filter.Location = new Point(230, 326);
            textBox_GiaBan_Filter.Margin = new Padding(2);
            textBox_GiaBan_Filter.Name = "textBox_GiaBan_Filter";
            textBox_GiaBan_Filter.Size = new Size(124, 32);
            textBox_GiaBan_Filter.TabIndex = 32;
            // 
            // label_GiaNhap_Filter
            // 
            label_GiaNhap_Filter.AutoSize = true;
            label_GiaNhap_Filter.BackColor = Color.Transparent;
            label_GiaNhap_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_GiaNhap_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_GiaNhap_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_GiaNhap_Filter.Location = new Point(25, 282);
            label_GiaNhap_Filter.Margin = new Padding(2, 0, 2, 0);
            label_GiaNhap_Filter.Name = "label_GiaNhap_Filter";
            label_GiaNhap_Filter.Size = new Size(90, 28);
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
            textBox_GiaNhap_Filter.Location = new Point(25, 326);
            textBox_GiaNhap_Filter.Margin = new Padding(2);
            textBox_GiaNhap_Filter.Name = "textBox_GiaNhap_Filter";
            textBox_GiaNhap_Filter.Size = new Size(124, 32);
            textBox_GiaNhap_Filter.TabIndex = 30;
            // 
            // label_TenDP_Filter
            // 
            label_TenDP_Filter.AutoSize = true;
            label_TenDP_Filter.BackColor = Color.Transparent;
            label_TenDP_Filter.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TenDP_Filter.ForeColor = Color.FromArgb(193, 193, 193);
            label_TenDP_Filter.ImageAlign = ContentAlignment.BottomCenter;
            label_TenDP_Filter.Location = new Point(230, 84);
            label_TenDP_Filter.Margin = new Padding(2, 0, 2, 0);
            label_TenDP_Filter.Name = "label_TenDP_Filter";
            label_TenDP_Filter.Size = new Size(146, 28);
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
            label_MaDP_Filter.Location = new Point(25, 84);
            label_MaDP_Filter.Margin = new Padding(2, 0, 2, 0);
            label_MaDP_Filter.Name = "label_MaDP_Filter";
            label_MaDP_Filter.Size = new Size(145, 28);
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
            textBox_TenDP_Filter.Location = new Point(230, 128);
            textBox_TenDP_Filter.Margin = new Padding(2);
            textBox_TenDP_Filter.Name = "textBox_TenDP_Filter";
            textBox_TenDP_Filter.Size = new Size(160, 32);
            textBox_TenDP_Filter.TabIndex = 12;
            // 
            // textBox_MaDP_Filter
            // 
            textBox_MaDP_Filter.BackColor = Color.FromArgb(57, 54, 70);
            textBox_MaDP_Filter.BorderStyle = BorderStyle.None;
            textBox_MaDP_Filter.Font = new Font("Segoe UI Semilight", 12F);
            textBox_MaDP_Filter.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_MaDP_Filter.Location = new Point(25, 128);
            textBox_MaDP_Filter.Margin = new Padding(2);
            textBox_MaDP_Filter.Name = "textBox_MaDP_Filter";
            textBox_MaDP_Filter.Size = new Size(160, 32);
            textBox_MaDP_Filter.TabIndex = 11;
            // 
            // button_OK_Filter
            // 
            button_OK_Filter.FlatStyle = FlatStyle.Flat;
            button_OK_Filter.Font = new Font("Segoe UI", 10F);
            button_OK_Filter.ForeColor = Color.FromArgb(148, 255, 216);
            button_OK_Filter.Location = new Point(25, 710);
            button_OK_Filter.Margin = new Padding(2);
            button_OK_Filter.Name = "button_OK_Filter";
            button_OK_Filter.Size = new Size(94, 43);
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
            label15.Location = new Point(15, 8);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(92, 38);
            label15.TabIndex = 2;
            label15.Text = "Filters";
            // 
            // customPanel_DetailsControl
            // 
            customPanel_DetailsControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            customPanel_DetailsControl.BackColor = Color.FromArgb(79, 69, 87);
            customPanel_DetailsControl.Controls.Add(label_SoLuongTot);
            customPanel_DetailsControl.Controls.Add(label16);
            customPanel_DetailsControl.Controls.Add(label_SoLuongDuocPham);
            customPanel_DetailsControl.Controls.Add(label14);
            customPanel_DetailsControl.CornerRadius = 40;
            customPanel_DetailsControl.Location = new Point(25, 787);
            customPanel_DetailsControl.Name = "customPanel_DetailsControl";
            customPanel_DetailsControl.Size = new Size(1124, 60);
            customPanel_DetailsControl.TabIndex = 15;
            // 
            // label_SoLuongTot
            // 
            label_SoLuongTot.AutoSize = true;
            label_SoLuongTot.BackColor = Color.Transparent;
            label_SoLuongTot.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SoLuongTot.ForeColor = Color.White;
            label_SoLuongTot.ImageAlign = ContentAlignment.BottomCenter;
            label_SoLuongTot.Location = new Point(853, 15);
            label_SoLuongTot.Margin = new Padding(2, 0, 2, 0);
            label_SoLuongTot.Name = "label_SoLuongTot";
            label_SoLuongTot.Size = new Size(84, 28);
            label_SoLuongTot.TabIndex = 43;
            label_SoLuongTot.Text = "Number";
            label_SoLuongTot.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.White;
            label16.ImageAlign = ContentAlignment.BottomCenter;
            label16.Location = new Point(562, 15);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(266, 28);
            label16.TabIndex = 42;
            label16.Text = "Số dược phẩm tình trạng tốt:";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_SoLuongDuocPham
            // 
            label_SoLuongDuocPham.AutoSize = true;
            label_SoLuongDuocPham.BackColor = Color.Transparent;
            label_SoLuongDuocPham.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SoLuongDuocPham.ForeColor = Color.White;
            label_SoLuongDuocPham.ImageAlign = ContentAlignment.BottomCenter;
            label_SoLuongDuocPham.Location = new Point(251, 15);
            label_SoLuongDuocPham.Margin = new Padding(2, 0, 2, 0);
            label_SoLuongDuocPham.Name = "label_SoLuongDuocPham";
            label_SoLuongDuocPham.Size = new Size(84, 28);
            label_SoLuongDuocPham.TabIndex = 41;
            label_SoLuongDuocPham.Text = "Number";
            label_SoLuongDuocPham.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.ImageAlign = ContentAlignment.BottomCenter;
            label14.Location = new Point(25, 15);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(201, 28);
            label14.TabIndex = 40;
            label14.Text = "Số lượng dược phẩm:";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel_TopPanel
            // 
            panel_TopPanel.BackColor = Color.FromArgb(57, 54, 70);
            panel_TopPanel.Dock = DockStyle.Top;
            panel_TopPanel.Location = new Point(0, 0);
            panel_TopPanel.Margin = new Padding(2);
            panel_TopPanel.Name = "panel_TopPanel";
            panel_TopPanel.Size = new Size(1590, 84);
            panel_TopPanel.TabIndex = 20;
            // 
            // DuocPhamControl
            // 
            BackColor = Color.FromArgb(57, 54, 70);
            Controls.Add(customPanel_DetailsControl);
            Controls.Add(customDataGridView);
            Controls.Add(panel_Toolbar);
            Controls.Add(panel_TopPanel);
            Controls.Add(panel_Upload);
            Controls.Add(panel_Filter);
            Margin = new Padding(2);
            Name = "DuocPhamControl";
            Size = new Size(1590, 864);
            Load += DuocPhamControl_Load;
            panel_Toolbar.ResumeLayout(false);
            panel_Toolbar.PerformLayout();
            panel_Upload.ResumeLayout(false);
            panel_Upload.PerformLayout();
            ((ISupportInitialize)customDataGridView).EndInit();
            panel_Filter.ResumeLayout(false);
            panel_Filter.PerformLayout();
            customPanel_DetailsControl.ResumeLayout(false);
            customPanel_DetailsControl.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void DuocPhamControl_Load(object sender, EventArgs e)
        {
            InitializeState();
        }
        private void InitializeState()
        {
            //prefetch
            next_DP_PrimaryKey = (string)DatabaseConnection.ExecuteScalar(selectLastID, null);
            next_DP_PrimaryKey = StringMath.Increment(next_DP_PrimaryKey);
            //State
            controlFunc = FIL_FUNC;
            controlCommand = DP_SelectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
            panel_Filter.BringToFront();
            //Upload
            comboBox_Thang.SelectedItem = comboBox_Thang.Items[0];
            FillMaDP(textBox_MaDP);
            GeneralMethods.FillDate(textBox_Ngay, comboBox_Thang, textBox_Nam);
        }
        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;
            SoLuongThieu_highlightList = GetDPSapHet();

            UpdateStatics(dgv);
        }
        private void UpdateStatics(DataGridView dgv)
        {
            int soluongDP = dgv.Rows.Count;
            int soluongTot = 0;
            foreach (DataGridViewRow row in dgv.Rows)
                if (row.Cells["TinhTrang"].Value.ToString() == "Mới")
                    soluongTot++;

            label_SoLuongDuocPham.Text = soluongDP.ToString();
            label_SoLuongTot.Text = soluongTot.ToString();
        }
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            controlFunc = INS_FUNC;
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

            string checkQuery = "IF EXISTS (SELECT 1 FROM DUOCPHAM WHERE MaDP = @MaDP) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaDP", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO DUOCPHAM " +
                                        "(MaDP, TenDP, SoLuong, MoTa, GiaNhap, GiaBan, XuatXu, DonVi, NgayNhap, HSD, SoLuongMoiDonVi) " +
                                        "VALUES(@MaDP, @TenDP, @SoLuong, @MoTa, @GiaNhap, @GiaBan, @XuatXu, @DonVi, @NgayNhap, @HSD, @SoLuongMoiDonVi)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaDP", primaryKey},
                    {"@TenDP", textBox_TenDP.Text },
                    {"@SoLuong", textBox_SoLuong.Text },
                    {"@MoTa", textBox_MoTa.Text },
                    {"@GiaNhap", textBox_GiaNhap.Text },
                    {"@GiaBan", textBox_GiaBan.Text },
                    {"@XuatXu", textBox_XuatXu.Text },
                    {"@DonVi", textBox_DonVi.Text },
                    {"@NgayNhap", GeneralMethods.GetNgayThangNam(textBox_Ngay, comboBox_Thang, textBox_Nam) },
                    {"@HSD", textBox_HSD.Text },
                    {"@SoLuongMoiDonVi", textBox_SoLuongMoiDonVi.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

                next_DP_PrimaryKey = StringMath.Increment(next_DP_PrimaryKey);
            }
            else
            {
                string updateQuery = "UPDATE DUOCPHAM " +
                                        "SET TenDP = @TenDP, " +
                                            "SoLuong = @SoLuong, " +
                                            "MoTa = @MoTa, " +
                                            "GiaNhap = @GiaNhap, " +
                                            "GiaBan = @GiaBan, " +
                                            "XuatXu = @XuatXu, " +
                                            "DonVi = @DonVi, " +
                                            "NgayNhap = @NgayNhap, " +
                                            "HSD = @HSD, " +                                            
                                            "SoLuongMoiDonVi = @SoLuongMoiDonVi " +
                                        "WHERE MaDP = @MaDP";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaDP", primaryKey},
                    {"@TenDP", textBox_TenDP.Text },
                    {"@SoLuong", textBox_SoLuong.Text },
                    {"@MoTa", textBox_MoTa.Text },
                    {"@GiaNhap", textBox_GiaNhap.Text },
                    {"@GiaBan", textBox_GiaBan.Text },
                    {"@XuatXu", textBox_XuatXu.Text },
                    {"@DonVi", textBox_DonVi.Text },
                    {"@NgayNhap", GeneralMethods.GetNgayThangNam(textBox_Ngay, comboBox_Thang, textBox_Nam) },
                    {"@HSD", textBox_HSD.Text },
                    {"@SoLuongMoiDonVi", textBox_SoLuongMoiDonVi.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }

        private void pageButton_Filter_Click(object sender, EventArgs e)
        {
            controlFunc = FIL_FUNC;
            panel_Filter.BringToFront();
        }

        private void pageButton_Remove_Click(object sender, EventArgs e)
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter;
            int parameterIndex = 0;

            string inDeletedList = "(NULL";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter = $"@MaDP{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaDP"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "UPDATE DUOCPHAM " +
                                   "SET IsDeleted = 1 " +
                                   "WHERE MaDP IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew            
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private int CheckUploadTextBox()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_MaDP.Text))
                error |= MADP_ERR;
            if (string.IsNullOrEmpty(textBox_TenDP.Text))
                error |= TENDP_ERR;
            if (string.IsNullOrEmpty(textBox_GiaNhap.Text))
                error |= GIANHAP_ERR;
            if (string.IsNullOrEmpty(textBox_GiaBan.Text))
                error |= GIABAN_ERR;
            if (string.IsNullOrEmpty(textBox_XuatXu.Text))
                error |= XUATXU_ERR;
            if (string.IsNullOrEmpty(textBox_DonVi.Text))
                error |= DONVI_ERR;
            if (string.IsNullOrEmpty(textBox_SoLuong.Text))
                error |= SOLUONG_ERR;
            if (string.IsNullOrEmpty(textBox_HSD.Text))
                error |= HSD_ERR;
            if (string.IsNullOrEmpty(textBox_SoLuongMoiDonVi.Text))
                error |= SLDV_ERR;

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
        const int HSD_ERR = 128;
        const int SLDV_ERR = 256;
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
            if ((error & HSD_ERR) == HSD_ERR)
                ColoringTextBox.WarningColor(textBox_HSD);
            if ((error & SLDV_ERR) == SLDV_ERR)
                ColoringTextBox.WarningColor(textBox_SoLuongMoiDonVi);
        }

        private void button_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = DP_SelectCommand;

            if (string.IsNullOrEmpty(textBox_MaDP_Filter.Text) == false)
                selectCommand += $"AND MaDP = '{textBox_MaDP_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_TenDP_Filter.Text) == false)
                selectCommand += $"AND TenDP = N'{textBox_TenDP_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_GiaNhap_Filter.Text) == false)
                selectCommand += $"AND GiaNhap >= {textBox_GiaNhap_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_GiaBan_Filter.Text) == false)
                selectCommand += $"AND GiaBan >= {textBox_GiaBan_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_XuatXu_Filter.Text) == false)
                selectCommand += $"AND XuatXu = N'{textBox_XuatXu_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_DonVi_Filter.Text) == false)
                selectCommand += $"AND DonVi = N'{textBox_DonVi_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_SoLuong_Filter.Text) == false)
                selectCommand += $"AND SoLuong >= {textBox_SoLuong_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_HSD_Filter.Text) == false)
                selectCommand += $"AND HSD >= {textBox_HSD_Filter.Text} ";
            if (string.IsNullOrEmpty(textBox_SoLuongMoiDonVi_Filter.Text) == false)
                selectCommand += $"AND SoLuongMoiDonVi >= {textBox_SoLuongMoiDonVi_Filter.Text} ";
            if (string.IsNullOrEmpty(comboBox_TinhTrang_Filter.Text) == false)
                selectCommand += $"AND TinhTrang = N'{comboBox_TinhTrang_Filter.Text}' ";

            string ngayLap = GeneralMethods.GetNgayThangNam(textBox_Ngay_Filter, comboBox_Thang_Filter, textBox_Nam_Filter);

            if (string.IsNullOrEmpty(ngayLap) == false)
                selectCommand += $"AND NgayNhap >= '{ngayLap}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void Button_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_PositiveNumber(sender, e);
        }
        private void button_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_Normal(sender, e);
        }
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int offset = 5;

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox && control != textBox_MoTa)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }

            if (panel == panel_Upload)
            {
                int x = label_NgayNhap.Location.X - 9;
                int startY = label_NgayNhap.Location.Y, endY = startY + label_NgayNhap.Height;
                graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
            }
        }
        private List<string> GetDPSapHet()
        {
            string DP_SapHetSelectCommand = "SELECT MaDP " +
                                                 "FROM DUOCPHAM DP " +
                                                 "WHERE SoLuong * SoLuongMoiDonVi - 20 <= (SELECT SUM(SoLuong) " +
                                                                                          "FROM CTHD_DuocPham CTDP " +
                                                                                          "WHERE CTDP.MaDP = DP.MaDP) ";
            //SqlDataReader reader = DatabaseConnection.ExecuteReaderNotification(NV_chuaPhanCongCommand, OnTableChange);
            SqlDataReader reader = DatabaseConnection.ExecuteReader(DP_SapHetSelectCommand);
            List<string> NV_chuaPhanCongList = new List<string>();
            while (reader.Read())
            {
                NV_chuaPhanCongList.Add(reader["MaDP"].ToString());
            }
            reader.Close();

            return NV_chuaPhanCongList;
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            customDataGridView.Refresh();
        }
        private void customDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            DateTime ngayNhap = (DateTime)row.Cells["NgayNhap"].Value;
            Int16 HSD = (Int16)row.Cells["HSD"].Value;
            int earlyMonths = 2;

            DateTime ngayHetHan = ngayNhap.AddMonths(HSD);
            DateTime thoiDiemThongBao = DateTime.Today.AddMonths(earlyMonths);

            if (checkBox_SoLuongThieu_Conditions.Checked && SoLuongThieu_highlightList.Contains(row.Cells["MaDP"].Value.ToString()))
            {
                row.DefaultCellStyle.BackColor = ColorUsed.highlightTop;
            }
            else if (checkBox_SapHetHan_Conditions.Checked && DateTime.Today < ngayHetHan && ngayHetHan <= thoiDiemThongBao)
            {
                row.DefaultCellStyle.BackColor = ColorUsed.highlightMedium;
            }
            else
            {
                row.DefaultCellStyle.BackColor = ColorUsed.originalGrid;
            }
        }

        private void customDataGridView_CellMouseDoubleClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.Button != MouseButtons.Left)
                return;

            DataGridView dgv = sender as DataGridView;
            DataRowView drv = dgv.Rows[e.RowIndex].DataBoundItem as DataRowView;
            DataRow row = drv.Row;

            fillPanel_DP(row);
        }

        private void fillPanel_DP(DataRow row)
        {
            switch (controlFunc)
            {
                case INS_FUNC:
                    textBox_MaDP.Text = row["MaDP"].ToString();
                    textBox_TenDP.Text = row["TenDP"].ToString();
                    textBox_Ngay.Text = row.Field<DateTime>("NgayNhap").Day.ToString();
                    comboBox_Thang.SelectedIndex = row.Field<DateTime>("NgayNhap").Month - 1;
                    textBox_Nam.Text = row.Field<DateTime>("NgayNhap").Year.ToString();
                    textBox_GiaNhap.Text = row["GiaNhap"].ToString();
                    textBox_GiaBan.Text = row["GiaBan"].ToString();
                    textBox_SoLuong.Text = row["SoLuong"].ToString();
                    textBox_DonVi.Text = row["DonVi"].ToString();
                    textBox_XuatXu.Text = row["XuatXu"].ToString();
                    textBox_HSD.Text = row["HSD"].ToString();
                    textBox_SoLuongMoiDonVi.Text = row["SoLuongMoiDonVi"].ToString();
                    textBox_MoTa.Text = row["MoTa"].ToString();
                    GeneralMethods.CleanColorPanel(panel_Upload);
                    break;
                case FIL_FUNC:
                    textBox_MaDP_Filter.Text = row["MaDP"].ToString();
                    textBox_TenDP_Filter.Text = row["TenDP"].ToString();
                    textBox_Ngay_Filter.Text = row.Field<DateTime>("NgayNhap").Day.ToString();
                    comboBox_Thang_Filter.SelectedIndex = row.Field<DateTime>("NgayNhap").Month - 1;
                    textBox_Nam_Filter.Text = row.Field<DateTime>("NgayNhap").Year.ToString();
                    textBox_GiaNhap_Filter.Text = row["GiaNhap"].ToString();
                    textBox_GiaBan_Filter.Text = row["GiaBan"].ToString();
                    textBox_SoLuong_Filter.Text = row["SoLuong"].ToString();
                    textBox_DonVi_Filter.Text = row["DonVi"].ToString();
                    textBox_XuatXu_Filter.Text = row["XuatXu"].ToString();
                    textBox_HSD_Filter.Text = row["HSD"].ToString();
                    textBox_SoLuongMoiDonVi_Filter.Text = row["SoLuongMoiDonVi"].ToString();
                    comboBox_TinhTrang_Filter.Text = row["TinhTrang"].ToString();
                    break;
            }
        }
        private void button_Upload_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);
            GeneralMethods.CleanColorPanel(panel);
            GeneralMethods.SetUpPanel(panel, 0);

            FillMaDP(textBox_MaDP);
            GeneralMethods.FillDate(textBox_Ngay, comboBox_Thang, textBox_Nam);

            controlCommand = DP_SelectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }

        private void button_Filter_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);

            controlCommand = DP_SelectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }

        private void FillMaDP(TextBox textBox)
        {
            textBox.Text = next_DP_PrimaryKey;
        }

        private void textBox_MaTK_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
                FillMaDP(textBox);
        }
    }
}
