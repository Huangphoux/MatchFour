﻿using System;
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
        private DataTable datatablePK;
        private DataTable datatablePC;
        //Database connection
        // private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        private string connectionStr = @"Server=HOANGPHUC2023;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        //Control variables
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        int controlPage;
        DataTable controlDataTable;
        private Panel panel_TopPanel;
        private Panel panel_Toolbar;
        private PageButton pageButton_Filter;
        private PageButton pageButton_Remove;
        private PageButton pageButton_Upload;
        private Panel panel_TKUpload;
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
        private Button button_TKUpload_OK;
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
        private TextBox textBox_SoLuongDP;
        private TextBox textBox1;
        private Label label_HSD;
        private TextBox textBox_Nam;
        private Label label_Nam;
        private ComboBox comboBox_Thang;
        private Label label_Thang;
        private TextBox textBox_Ngay;
        private Label label_Ngay;
        private PageButton pageButton1;
        CustomDataGridView controlDataGridView;

        public DuocPhamControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DuocPhamControl));
            panel_TopPanel = new Panel();
            panel_Toolbar = new Panel();
            pageButton1 = new PageButton();
            pageButton_Filter = new PageButton();
            pageButton_Remove = new PageButton();
            pageButton_Upload = new PageButton();
            panel_TKUpload = new Panel();
            textBox1 = new TextBox();
            label_HSD = new Label();
            textBox_Nam = new TextBox();
            label_Nam = new Label();
            comboBox_Thang = new ComboBox();
            label_Thang = new Label();
            textBox_Ngay = new TextBox();
            label_Ngay = new Label();
            label_SoLuongDP = new Label();
            textBox_SoLuongDP = new TextBox();
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
            label_SoLuong = new Label();
            textBox_SoLuong = new TextBox();
            label_TenDP = new Label();
            label_MaDP = new Label();
            textBox_TenDP = new TextBox();
            textBox_MaDP = new TextBox();
            button_TKUpload_OK = new Button();
            label_Upload = new Label();
            panel_Toolbar.SuspendLayout();
            panel_TKUpload.SuspendLayout();
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
            panel_Toolbar.Controls.Add(pageButton1);
            panel_Toolbar.Controls.Add(pageButton_Filter);
            panel_Toolbar.Controls.Add(pageButton_Remove);
            panel_Toolbar.Controls.Add(pageButton_Upload);
            panel_Toolbar.Location = new Point(0, 67);
            panel_Toolbar.Margin = new Padding(2);
            panel_Toolbar.Name = "panel_Toolbar";
            panel_Toolbar.Size = new Size(939, 64);
            panel_Toolbar.TabIndex = 1;
            // 
            // pageButton1
            // 
            pageButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pageButton1.BackColor = Color.FromArgb(57, 54, 70);
            pageButton1.BorderColor = Color.PaleVioletRed;
            pageButton1.BorderRadius = 20;
            pageButton1.BorderSize = 0;
            pageButton1.CustomText = null;
            pageButton1.FlatAppearance.BorderSize = 0;
            pageButton1.FlatStyle = FlatStyle.Flat;
            pageButton1.ForeColor = Color.White;
            pageButton1.Icon = (Image)resources.GetObject("pageButton1.Icon");
            pageButton1.IconLocation = new Point(11, 11);
            pageButton1.IconSize = new Size(34, 34);
            pageButton1.Location = new Point(883, 8);
            pageButton1.Margin = new Padding(2);
            pageButton1.Name = "pageButton1";
            pageButton1.Size = new Size(44, 44);
            pageButton1.TabIndex = 22;
            pageButton1.TextLocation = new Point(0, 0);
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
            pageButton_Filter.Location = new Point(1614, 10);
            pageButton_Filter.Margin = new Padding(2);
            pageButton_Filter.Name = "pageButton_Filter";
            pageButton_Filter.Size = new Size(44, 44);
            pageButton_Filter.TabIndex = 3;
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
            pageButton_Remove.TabIndex = 2;
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
            pageButton_Upload.TabIndex = 1;
            pageButton_Upload.TextLocation = new Point(0, 0);
            pageButton_Upload.UseVisualStyleBackColor = false;
            // 
            // panel_TKUpload
            // 
            panel_TKUpload.Anchor = AnchorStyles.Right;
            panel_TKUpload.AutoScroll = true;
            panel_TKUpload.AutoSize = true;
            panel_TKUpload.BackColor = Color.FromArgb(57, 54, 70);
            panel_TKUpload.Controls.Add(textBox1);
            panel_TKUpload.Controls.Add(label_HSD);
            panel_TKUpload.Controls.Add(textBox_Nam);
            panel_TKUpload.Controls.Add(label_Nam);
            panel_TKUpload.Controls.Add(comboBox_Thang);
            panel_TKUpload.Controls.Add(label_Thang);
            panel_TKUpload.Controls.Add(textBox_Ngay);
            panel_TKUpload.Controls.Add(label_Ngay);
            panel_TKUpload.Controls.Add(label_SoLuongDP);
            panel_TKUpload.Controls.Add(textBox_SoLuongDP);
            panel_TKUpload.Controls.Add(label_DonVi);
            panel_TKUpload.Controls.Add(textBox_DonVi);
            panel_TKUpload.Controls.Add(label_XuatXu);
            panel_TKUpload.Controls.Add(textBox_XuatXu);
            panel_TKUpload.Controls.Add(label_GiaBan);
            panel_TKUpload.Controls.Add(textBox_GiaBan);
            panel_TKUpload.Controls.Add(label_GiaNhap);
            panel_TKUpload.Controls.Add(textBox_GiaNhap);
            panel_TKUpload.Controls.Add(textBox_MoTa);
            panel_TKUpload.Controls.Add(label_MoTa);
            panel_TKUpload.Controls.Add(label_SoLuong);
            panel_TKUpload.Controls.Add(textBox_SoLuong);
            panel_TKUpload.Controls.Add(label_TenDP);
            panel_TKUpload.Controls.Add(label_MaDP);
            panel_TKUpload.Controls.Add(textBox_TenDP);
            panel_TKUpload.Controls.Add(textBox_MaDP);
            panel_TKUpload.Controls.Add(button_TKUpload_OK);
            panel_TKUpload.Controls.Add(label_Upload);
            panel_TKUpload.Location = new Point(939, 67);
            panel_TKUpload.Margin = new Padding(2);
            panel_TKUpload.Name = "panel_TKUpload";
            panel_TKUpload.Size = new Size(333, 624);
            panel_TKUpload.TabIndex = 21;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(57, 54, 70);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI Semilight", 12F);
            textBox1.ForeColor = Color.FromArgb(244, 238, 224);
            textBox1.Location = new Point(251, 446);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(48, 27);
            textBox1.TabIndex = 47;
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
            // label_SoLuongDP
            // 
            label_SoLuongDP.AutoSize = true;
            label_SoLuongDP.BackColor = Color.Transparent;
            label_SoLuongDP.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SoLuongDP.ForeColor = Color.FromArgb(193, 193, 193);
            label_SoLuongDP.ImageAlign = ContentAlignment.BottomCenter;
            label_SoLuongDP.Location = new Point(179, 337);
            label_SoLuongDP.Margin = new Padding(2, 0, 2, 0);
            label_SoLuongDP.Name = "label_SoLuongDP";
            label_SoLuongDP.Size = new Size(78, 23);
            label_SoLuongDP.TabIndex = 39;
            label_SoLuongDP.Text = "Số lượng";
            label_SoLuongDP.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_SoLuongDP
            // 
            textBox_SoLuongDP.BackColor = Color.FromArgb(57, 54, 70);
            textBox_SoLuongDP.BorderStyle = BorderStyle.None;
            textBox_SoLuongDP.Font = new Font("Segoe UI Semilight", 12F);
            textBox_SoLuongDP.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_SoLuongDP.Location = new Point(179, 372);
            textBox_SoLuongDP.Margin = new Padding(2);
            textBox_SoLuongDP.Name = "textBox_SoLuongDP";
            textBox_SoLuongDP.Size = new Size(102, 27);
            textBox_SoLuongDP.TabIndex = 38;
            // 
            // label_DonVi
            // 
            label_DonVi.AutoSize = true;
            label_DonVi.BackColor = Color.Transparent;
            label_DonVi.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_DonVi.ForeColor = Color.FromArgb(193, 193, 193);
            label_DonVi.ImageAlign = ContentAlignment.BottomCenter;
            label_DonVi.Location = new Point(27, 332);
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
            textBox_DonVi.Location = new Point(27, 367);
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
            label_XuatXu.Location = new Point(27, 274);
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
            textBox_XuatXu.Location = new Point(27, 309);
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
            label_GiaNhap.Location = new Point(23, 212);
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
            textBox_GiaNhap.Location = new Point(23, 247);
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
            // label_SoLuong
            // 
            label_SoLuong.AutoSize = true;
            label_SoLuong.BackColor = Color.Transparent;
            label_SoLuong.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_SoLuong.ForeColor = Color.FromArgb(193, 193, 193);
            label_SoLuong.ImageAlign = ContentAlignment.BottomCenter;
            label_SoLuong.Location = new Point(160, 55);
            label_SoLuong.Margin = new Padding(2, 0, 2, 0);
            label_SoLuong.Name = "label_SoLuong";
            label_SoLuong.Size = new Size(126, 23);
            label_SoLuong.TabIndex = 16;
            label_SoLuong.Text = "Mã dược phẩm";
            label_SoLuong.TextAlign = ContentAlignment.BottomLeft;
            // 
            // textBox_SoLuong
            // 
            textBox_SoLuong.BackColor = Color.FromArgb(57, 54, 70);
            textBox_SoLuong.BorderStyle = BorderStyle.None;
            textBox_SoLuong.Font = new Font("Segoe UI Semilight", 12F);
            textBox_SoLuong.ForeColor = Color.FromArgb(244, 238, 224);
            textBox_SoLuong.Location = new Point(160, 90);
            textBox_SoLuong.Margin = new Padding(2);
            textBox_SoLuong.Name = "textBox_SoLuong";
            textBox_SoLuong.Size = new Size(102, 27);
            textBox_SoLuong.TabIndex = 15;
            // 
            // label_TenDP
            // 
            label_TenDP.AutoSize = true;
            label_TenDP.BackColor = Color.Transparent;
            label_TenDP.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_TenDP.ForeColor = Color.FromArgb(193, 193, 193);
            label_TenDP.ImageAlign = ContentAlignment.BottomCenter;
            label_TenDP.Location = new Point(23, 132);
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
            textBox_TenDP.Location = new Point(19, 168);
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
            textBox_MaDP.Size = new Size(102, 27);
            textBox_MaDP.TabIndex = 11;
            // 
            // button_TKUpload_OK
            // 
            button_TKUpload_OK.FlatStyle = FlatStyle.Flat;
            button_TKUpload_OK.Font = new Font("Segoe UI", 10F);
            button_TKUpload_OK.ForeColor = Color.FromArgb(148, 255, 216);
            button_TKUpload_OK.Location = new Point(20, 568);
            button_TKUpload_OK.Margin = new Padding(2);
            button_TKUpload_OK.Name = "button_TKUpload_OK";
            button_TKUpload_OK.Size = new Size(75, 34);
            button_TKUpload_OK.TabIndex = 4;
            button_TKUpload_OK.Text = "OK";
            button_TKUpload_OK.UseVisualStyleBackColor = true;
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
            // DuocPhamControl
            // 
            BackColor = Color.FromArgb(57, 54, 70);
            Controls.Add(panel_TKUpload);
            Controls.Add(panel_Toolbar);
            Controls.Add(panel_TopPanel);
            Margin = new Padding(2);
            Name = "DuocPhamControl";
            Size = new Size(1272, 691);
            Load += DuocPhamControl_Load;
            panel_Toolbar.ResumeLayout(false);
            panel_TKUpload.ResumeLayout(false);
            panel_TKUpload.PerformLayout();
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
            //controlDataGridView = customDataGridView_PC;
            //controlPage = PK_TAB;
            //SwitchMode(controlPage);
            //panel_Filters.BringToFront();
        }

        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            connection.Close();

            //UpdateDataGridView(customDataGridView_PK, datatablePK);
            //UpdateDataGridView(customDataGridView_PC, datatablePC);
        }
    }
}