using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMachTu.Controls
{
    public partial class NhanVienControl : UserControl
    {
        #region SQL stuffs
        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatable_NV;
        private DataTable datatable_Khoa;
        //Database connection
        // private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        private string connectionStr = @"Server=HOANGPHUC2023;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        #endregion

        const int NV_TAB = 0;
        const int KHOA_TAB = 10;

        int controlPage;
        DataTable controlDataTable;
        CustomDataGridView controlDataGridView;

        #region Initializing
        public NhanVienControl()
        {
            InitializeComponent();
        }
        private void NhanVienControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }
        private void InitializeState()
        {
            controlDataGridView = customDataGridView;
            controlPage = NV_TAB;
            EnablePage(controlPage);
        }
        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    controlDataTable = datatable_NV;
                    ColoringButton.EnabledColor(pageButton_Tab_NhanVien);
                    panel_NV_Upload.BringToFront();
                    break;
                case KHOA_TAB:
                    controlDataTable = datatable_Khoa;
                    ColoringButton.EnabledColor(pageButton_Tab_Khoa);
                    panel_Khoa_Upload.BringToFront();
                    break;
            }

            UpdateDataGridView(customDataGridView, controlDataTable);
        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    ColoringButton.DisabledColor(pageButton_Tab_NhanVien);
                    break;
                case KHOA_TAB:
                    ColoringButton.DisabledColor(pageButton_Tab_Khoa);
                    break;
            }
        }
        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            LoadTabNhanVien();
            LoadTabKhoa();

            connection.Close();
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
            label_Sum_NhanVien.Text = dgv.Rows.Count.ToString();
        }
        #endregion
        #region Editing Buttons
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    panel_NV_Upload.BringToFront();
                    break;
                case KHOA_TAB:
                    panel_Khoa_Upload.BringToFront();
                    break;
            }
        }
        private void pageButton_Filter_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    panel_NV_Filter.BringToFront();
                    break;
                case KHOA_TAB:
                    panel_Khoa_Filter.BringToFront();
                    break;
            }
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
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
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

            UpdateDataGridView(customDataGridView, controlDataTable);
        }

        #endregion

        #region Getters
        private string GetGioiTinh(CheckBox checkBox_Nam, CheckBox checkBox_Nu)
        {
            if (checkBox_Nam.Checked)
                return "Nam";
            else
                return "Nữ";
        }
        private string GetNgayThangNam(TextBox textBox_Ngay, ComboBox comboBox_Thang, TextBox textBox_Nam)
        {
            if (string.IsNullOrEmpty(textBox_Ngay.Text))
                return null;
            else if (string.IsNullOrEmpty(textBox_Nam.Text))
                return null;

            return $"{comboBox_Thang.SelectedIndex + 1}/{textBox_Ngay.Text}/{textBox_Nam.Text}";
        }
        private string GetOperation(ComboBox operations)
        {
            string selected = operations.SelectedItem as string;
            switch (selected)
            {
                case "≥":
                    return ">=";
                case "≤":
                    return "<=";
                default:
                    return selected;
            }
        }

        #endregion

        #region NhanVien Tab
        private void pageButton_Tab_NhanVien_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = NV_TAB;
            EnablePage(controlPage);
        }
        private void LoadTabNhanVien()
        {
            LoadDataToDataSet("SELECT * FROM NHANVIEN", "NHANVIEN");
            datatable_NV = dataset.Tables["NHANVIEN"];
            datatable_NV.PrimaryKey = new DataColumn[] { datatable_NV.Columns["MaNV"] };

            comboBox_NV_Upload_Thang.SelectedItem = comboBox_NV_Upload_Thang.Items[0];
            comboBox_NV_Filter_Thang.SelectedItem = comboBox_NV_Filter_Thang.Items[0];
            comboBox_NV_Filter_Operation.SelectedItem = comboBox_NV_Filter_Operation.Items[0];
        }

        #region Error bits
        const int MANV_ERR = 1;
        const int MAKHOA_ERR = 2;
        const int TENNV_ERR = 4;
        const int NGAY_ERR = 8;
        const int NAM_ERR = 16;
        const int SDT_ERR = 32;
        const int EMAIL_ERR = 64;
        const int LUONG_ERR = 128;
        const int NAMKN_ERR = 256;
        #endregion
        private int CheckUploadTextBox()
        {
            int error = 0;

            if (string.IsNullOrEmpty(textBox_NV_Upload_MaNV.Text))
                error |= MANV_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_MaKhoa.Text))
                error |= MAKHOA_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_TenNV.Text))
                error |= TENNV_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_Ngay.Text))
                error |= NGAY_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_Nam.Text))
                error |= NAM_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_SDT.Text))
                error |= SDT_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_Email.Text))
                error |= EMAIL_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_Luong.Text))
                error |= LUONG_ERR;
            if (string.IsNullOrEmpty(textBox_NV_Upload_NamKN.Text))
                error |= NAMKN_ERR;

            return error;
        }
        private void WarningUploadTextBoxError(int error)
        {
            if ((error & MANV_ERR) == MANV_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_MaNV);
            if ((error & MAKHOA_ERR) == MAKHOA_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_MaKhoa);
            if ((error & TENNV_ERR) == TENNV_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_TenNV);
            if ((error & NGAY_ERR) == NGAY_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_Ngay);
            if ((error & NAM_ERR) == NAM_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_Nam);
            if ((error & SDT_ERR) == SDT_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_SDT);
            if ((error & EMAIL_ERR) == EMAIL_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_Email);
            if ((error & LUONG_ERR) == LUONG_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_Luong);
            if ((error & NAMKN_ERR) == NAMKN_ERR)
                ColoringTextBox.WarningColor(textBox_NV_Upload_NamKN);
        }

        private void button_NV_OK_Click(object sender, EventArgs e)
        {
            int error = CheckUploadTextBox();
            if (error != 0)
            {
                WarningUploadTextBoxError(error);
                return;
            }

            string primaryKey = textBox_NV_Upload_MaNV.Text;
            DataRow targetRow = datatable_NV.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatable_NV.NewRow();

                targetRow["MaNV"] = primaryKey;
                targetRow["TenNV"] = textBox_NV_Upload_TenNV.Text;
                targetRow["MaKhoa"] = textBox_NV_Upload_MaKhoa.Text;
                targetRow["GioiTinh"] = GetGioiTinh(checkBox_NV_Upload_Nam, checkBox_NV_Upload_Nu);
                targetRow["NgaySinh"] = GetNgayThangNam(textBox_NV_Upload_Ngay, comboBox_NV_Upload_Thang, textBox_NV_Upload_Nam);
                targetRow["SDT"] = textBox_NV_Upload_SDT.Text;
                targetRow["Email"] = textBox_NV_Upload_Email.Text;
                targetRow["Luong"] = textBox_NV_Upload_Luong.Text;
                targetRow["KinhNghiem"] = textBox_NV_Upload_NamKN.Text;
                targetRow["DanhGia"] = textBox_NV_Upload_DanhGia.Text;

                datatable_NV.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaNV"] = primaryKey;
                targetRow["TenNV"] = textBox_NV_Upload_TenNV.Text;
                targetRow["MaKhoa"] = textBox_NV_Upload_MaKhoa.Text;
                targetRow["GioiTinh"] = GetGioiTinh(checkBox_NV_Upload_Nam, checkBox_NV_Upload_Nu);
                targetRow["NgaySinh"] = GetNgayThangNam(textBox_NV_Upload_Ngay, comboBox_NV_Upload_Thang, textBox_NV_Upload_Nam);
                targetRow["SDT"] = textBox_NV_Upload_SDT.Text;
                targetRow["Email"] = textBox_NV_Upload_Email.Text;
                targetRow["Luong"] = textBox_NV_Upload_Luong.Text;
                targetRow["KinhNghiem"] = textBox_NV_Upload_NamKN.Text;
                targetRow["DanhGia"] = textBox_NV_Upload_DanhGia.Text;
            }

            UpdateDataGridView(customDataGridView, datatable_NV);
        }
        private void button_NV_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = "1 = 1 ";

            if (string.IsNullOrEmpty(textBox_NV_MaNV_Filter.Text) == false)
                selectCommand += $"AND MaNV = '{textBox_NV_MaNV_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_NV_HoTen_Filter.Text) == false)
                selectCommand += $"AND TenNV = '{textBox_NV_HoTen_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_NV_MaKhoa_Filter.Text) == false)
                selectCommand += $"AND MaKhoa = '{textBox_NV_MaKhoa_Filter.Text}' ";


            string operation = GetOperation(comboBox_NV_Filter_Operation);
            string ngaySinh = GetNgayThangNam(textBox_NV_Filter_Ngay, comboBox_NV_Filter_Thang, textBox_NV_Filter_Nam);
            if (string.IsNullOrEmpty(ngaySinh) == false)
                selectCommand += $"AND NgaySinh {operation} '{ngaySinh}' ";

            if (string.IsNullOrEmpty(textBox_NV_Luong_Filter.Text) == false)
                selectCommand += $"AND Luong >= '{textBox_NV_Luong_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_NV_Luong_Filter.Text) == false)
                selectCommand += $"AND KinhNghiem >= '{textBox_NV_NamKN_Filter.Text}' ";

            if (checkBox_NV_Filter_Nam.Checked == true)
                selectCommand += $"AND GioiTinh = 'Nam' ";
            if (checkBox_NV_Filter_Nu.Checked == true)
                selectCommand += $"AND GioiTinh = 'Nữ' ";

            DataRow[] resultRow = datatable_NV.Select(selectCommand);
            DataTable resultDatatable = datatable_NV.Clone();

            foreach (DataRow row in resultRow)
            {
                if (resultDatatable.Rows.Contains(row["MaNV"]))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
        }

        #endregion


        #region Khoa Tab
        private void pageButton_Tab_Khoa_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = KHOA_TAB;
            EnablePage(controlPage);
        }
        private void LoadTabKhoa()
        {
            LoadDataToDataSet("SELECT * FROM KHOA", "KHOA");
            datatable_NV = dataset.Tables["KHOA"];
            datatable_NV.PrimaryKey = new DataColumn[] { datatable_NV.Columns["MaKhoa"] };

            comboBox_Khoa_Operation.SelectedItem = comboBox_Khoa_Operation.Items[0];
        }

        #region Error bits
        const int MAKHOA_KHOA_ERR = 1;
        const int TENKHOA_ERR = 2;
        const int SOLUONG_ERR = 4;
        const int MANV_KHOA_ERR = 8;
        #endregion

        private int CheckUploadTextBox_Khoa()
        {
            int error = 0;

            if (string.IsNullOrEmpty(textBox_Khoa_MaKhoa.Text))
                error |= MAKHOA_KHOA_ERR;
            if (string.IsNullOrEmpty(textBox_Khoa_TenKhoa.Text))
                error |= TENKHOA_ERR;
            if (string.IsNullOrEmpty(textBox_Khoa_SoLuong.Text))
                error |= SOLUONG_ERR;
            if (string.IsNullOrEmpty(textBox_Khoa_MaNVQuanLy.Text))
                error |= MANV_KHOA_ERR;

            return error;
        }
        private void WarningUploadTextBoxError_Khoa(int error)
        {
            if ((error & MAKHOA_KHOA_ERR) == MAKHOA_KHOA_ERR)
                ColoringTextBox.WarningColor(textBox_Khoa_MaKhoa);
            if ((error & TENKHOA_ERR) == TENKHOA_ERR)
                ColoringTextBox.WarningColor(textBox_Khoa_TenKhoa);
            if ((error & SOLUONG_ERR) == SOLUONG_ERR)
                ColoringTextBox.WarningColor(textBox_Khoa_SoLuong);
            if ((error & MANV_KHOA_ERR) == MANV_KHOA_ERR)
                ColoringTextBox.WarningColor(textBox_Khoa_MaNVQuanLy);
        }

        private void button_Khoa_OK_Click(object sender, EventArgs e)
        {
            int error = CheckUploadTextBox_Khoa();
            if (error != 0)
            {
                WarningUploadTextBoxError_Khoa(error);
                return;
            }

            string primaryKey = textBox_Khoa_MaKhoa.Text;
            DataRow targetRow = datatable_Khoa.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatable_Khoa.NewRow();

                targetRow["MaKhoa"] = primaryKey;
                targetRow["TenKhoa"] = textBox_Khoa_TenKhoa.Text;
                targetRow["SoLuong"] = textBox_Khoa_SoLuong.Text;
                targetRow["MaNV_QuanLy"] = textBox_Khoa_MaNVQuanLy.Text;

                datatable_Khoa.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaKhoa"] = primaryKey;
                targetRow["TenKhoa"] = textBox_Khoa_TenKhoa.Text;
                targetRow["SoLuong"] = textBox_Khoa_SoLuong.Text;
                targetRow["MaNV_QuanLy"] = textBox_Khoa_MaNVQuanLy.Text;
            }

            UpdateDataGridView(customDataGridView, datatable_Khoa);
        }
        private void button_Khoa_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = "1 = 1 ";

            if (string.IsNullOrEmpty(textBox_Khoa_MaKhoa_Filter.Text) == false)
                selectCommand += $"AND MaKhoa = '{textBox_Khoa_MaKhoa_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_Khoa_TenKhoa_Filter.Text) == false)
                selectCommand += $"AND TenKhoa = '{textBox_Khoa_TenKhoa_Filter.Text}' ";
            
            string operation = GetOperation(comboBox_Khoa_Operation);
            if (string.IsNullOrEmpty(textBox_Khoa_SoLuong_Filter.Text) == false)
                selectCommand += $"AND SoLuong {operation} '{textBox_Khoa_SoLuong_Filter.Text}' ";
            
            if (string.IsNullOrEmpty(textBox_Khoa_MaNVQuanLy_Filter.Text) == false)
                selectCommand += $"AND MaNV_QuanLy = '{textBox_Khoa_MaNVQuanLy_Filter.Text}' ";

            DataRow[] resultRow = datatable_Khoa.Select(selectCommand);
            DataTable resultDatatable = datatable_Khoa.Clone();

            foreach (DataRow row in resultRow)
            {
                if (resultDatatable.Rows.Contains(row["MaKhoa"]))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
        }

        #endregion
    }
}
