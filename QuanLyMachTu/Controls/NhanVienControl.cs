using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMachTu.Controls
{
    public partial class NhanVienControl : UserControl
    {
        private string NV_SelectCommand = "SELECT MaNV, HoTenNV, GioiTinh, NgaySinh, Email, SDT, Luong, KinhNghiem, DanhGia, MaKhoa " +
                                          "FROM NHANVIEN " +
                                          "WHERE IsDeleted = 0 ";
        private string KHOA_SelectCommand = "SELECT MaKhoa, TenKhoa, SoLuong, MaNV_QuanLy " +
                                            "FROM KHOA " +
                                            "WHERE IsDeleted = 0 ";
        private string selectLatestID = "SELECT TOP 1 MaNV FROM NHANVIEN ORDER BY MaNV DESC ";

        List<string> highlightList = new List<string>();

        const int NV_TAB = 0;
        const int KHOA_TAB = 10;

        const int INS_FUNC = 1;
        const int FIL_FUNC = 0;

        private string next_NV_PrimaryKey;
        private string controlCommand;
        int controlPage;
        int NV_controlFunc;
        int Khoa_controlFunc;
        bool NV_ControlDetails;

        #region Initializing
        public NhanVienControl()
        {
            InitializeComponent();
        }
        private void NhanVienControl_Load(object sender, EventArgs e)
        {
            InitializeState();
        }
        private void InitializeState()
        {
            InitializeState_NV();
            InitializeState_Khoa();

            controlPage = NV_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    ColoringButton.EnabledColor(pageButton_Tab_NhanVien);
                    OpenFunctionPanel(NV_controlFunc);
                    pageButton_Details_NV.Enabled = true;
                    break;
                case KHOA_TAB:
                    ColoringButton.EnabledColor(pageButton_Tab_Khoa);
                    OpenFunctionPanel(Khoa_controlFunc);
                    break;
            }
        }
        private void LoadPage(int controlPage)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    controlCommand = NV_SelectCommand;
                    break;
                case KHOA_TAB:
                    controlCommand = KHOA_SelectCommand;
                    break;
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    ColoringButton.DisabledColor(pageButton_Tab_NhanVien);
                    pageButton_Details_NV.Enabled = false;
                    break;
                case KHOA_TAB:
                    ColoringButton.DisabledColor(pageButton_Tab_Khoa);
                    break;
            }
        }
        private void OpenFiltersPanel(int controlPage)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    NV_controlFunc = FIL_FUNC;
                    panel_NV_Filter.BringToFront();
                    break;
                case KHOA_TAB:
                    Khoa_controlFunc = FIL_FUNC;
                    panel_Khoa_Filter.BringToFront();
                    break;
            }
        }
        private void OpenUploadPanel(int controlPage)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    NV_controlFunc = INS_FUNC;
                    panel_NV_Upload.BringToFront();
                    break;
                case KHOA_TAB:
                    Khoa_controlFunc = INS_FUNC;
                    panel_Khoa_Upload.BringToFront();
                    break;
            }
        }
        private void OpenFunctionPanel(int controlFunc)
        {
            switch (controlFunc)
            {
                case INS_FUNC:
                    OpenUploadPanel(controlPage);
                    break;
                case FIL_FUNC:
                    OpenFiltersPanel(controlPage);
                    break;
            }
        }
        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;
            highlightList = GetDataWhenDatabaseChanged();

            if (controlPage == NV_TAB)
            {
                label_Sum_NhanVien.Text = dgv.Rows.Count.ToString();
                long sumLuong = GeneralMethods.Sum(dgv, "Luong");
                float avgKinhNghiem = GeneralMethods.Average(dgv, "KinhNghiem");
                float avgDanhGia = GeneralMethods.Average(dgv, "DanhGia");
                label_TongLuong_Number.Text = sumLuong.ToString("N0");
                label_KinhNghiem_Number.Text = avgKinhNghiem.ToString();
                label_DanhGia_Number.Text = avgDanhGia.ToString();
            }
        }
        #endregion
        #region Editing Buttons
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            OpenUploadPanel(controlPage);
        }
        private void pageButton_Filter_Click(object sender, EventArgs e)
        {
            OpenFiltersPanel(controlPage);
        }
        private void pageButton_Remove_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case NV_TAB:
                    NV_Remove();
                    break;
                case KHOA_TAB:
                    Khoa_Remove();
                    break;
            }
        }
        #endregion

        #region NhanVien Tab
        private void pageButton_Tab_NhanVien_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = NV_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        private void InitializeState_NV()
        {
            //Prefetch
            next_NV_PrimaryKey = (string)DatabaseConnection.ExecuteScalar(selectLatestID, null);
            next_NV_PrimaryKey = StringMath.Increment(next_NV_PrimaryKey);
            //Control
            NV_controlFunc = FIL_FUNC;
            //Details
            NV_ControlDetails = false;
            panel_Details.SendToBack();
            //Upload
            comboBox_NV_Upload_Thang.SelectedItem = comboBox_NV_Upload_Thang.Items[0];
            FillMaNV(textBox_NV_Upload_MaNV);
            GeneralMethods.FillDate(textBox_NV_Upload_Ngay, comboBox_NV_Upload_Thang, textBox_NV_Upload_Nam);
            //Filters
            comboBox_NV_Filter_Thang.SelectedItem = comboBox_NV_Filter_Thang.Items[0];
            comboBox_NV_Filter_Operation.SelectedItem = comboBox_NV_Filter_Operation.Items[0];
            comboBox_NVFilters_KinhNghiem_Comparer.SelectedIndex = 0;
            comboBox_NVFilters_Luong_Comparer.SelectedIndex = 0;
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

            string checkQuery = "IF EXISTS (SELECT 1 FROM NHANVIEN WHERE MaNV = @MaNV) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaNV", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO NHANVIEN " +
                                        "(MaNV, HoTenNV, GioiTinh, NgaySinh, Email, SDT, Luong, KinhNghiem, MaKhoa) " +
                                        "VALUES(@MaNV, @HoTenNV, @GioiTinh, @NgaySinh, @Email, @SDT, @Luong, @KinhNghiem, @MaKhoa)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaNV", primaryKey},
                    {"@HoTenNV", textBox_NV_Upload_TenNV.Text },
                    {"@GioiTinh", GeneralMethods.GetGioiTinh(checkBox_NV_Upload_Nam, checkBox_NV_Upload_Nu) },
                    {"@NgaySinh", GeneralMethods.GetNgayThangNam(textBox_NV_Upload_Ngay, comboBox_NV_Upload_Thang, textBox_NV_Upload_Nam) },
                    {"@Email", textBox_NV_Upload_Email.Text },
                    {"@SDT", textBox_NV_Upload_SDT.Text },
                    {"@Luong", textBox_NV_Upload_Luong.Text },
                    {"@KinhNghiem", textBox_NV_Upload_NamKN.Text },
                    {"@MaKhoa", textBox_NV_Upload_MaKhoa.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);
            }
            else
            {
                string updateQuery = "UPDATE NHANVIEN " +
                                        "SET HoTenNV = @HoTenNV, " +
                                            "GioiTinh = @GioiTinh, " +
                                            "NgaySinh = @NgaySinh, " +
                                            "Email = @Email, " +
                                            "SDT = @SDT, " +
                                            "Luong = @Luong, " +
                                            "KinhNghiem = @KinhNghiem, " +
                                            "MaKhoa = @MaKhoa " +
                                        "WHERE MaNV = @MaNV";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaNV", primaryKey},
                    {"@HoTenNV", textBox_NV_Upload_TenNV.Text },
                    {"@GioiTinh", GeneralMethods.GetGioiTinh(checkBox_NV_Upload_Nam, checkBox_NV_Upload_Nu) },
                    {"@NgaySinh", GeneralMethods.GetNgayThangNam(textBox_NV_Upload_Ngay, comboBox_NV_Upload_Thang, textBox_NV_Upload_Nam) },
                    {"@Email", textBox_NV_Upload_Email.Text },
                    {"@SDT", textBox_NV_Upload_SDT.Text },
                    {"@Luong", textBox_NV_Upload_Luong.Text },
                    {"@KinhNghiem", textBox_NV_Upload_NamKN.Text },
                    {"@MaKhoa", textBox_NV_Upload_MaKhoa.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void button_NV_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = NV_SelectCommand;

            if (string.IsNullOrEmpty(textBox_NV_MaNV_Filter.Text) == false)
                selectCommand += $"AND MaNV = '{textBox_NV_MaNV_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_NV_HoTen_Filter.Text) == false)
                selectCommand += $"AND HoTenNV = N'{textBox_NV_HoTen_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_NV_MaKhoa_Filter.Text) == false)
                selectCommand += $"AND MaKhoa = '{textBox_NV_MaKhoa_Filter.Text}' ";


            string operation = GeneralMethods.GetOperation(comboBox_NV_Filter_Operation);
            string ngaySinh = GeneralMethods.GetNgayThangNam(textBox_NV_Filter_Ngay, comboBox_NV_Filter_Thang, textBox_NV_Filter_Nam);
            if (string.IsNullOrEmpty(ngaySinh) == false)
                selectCommand += $"AND NgaySinh {operation} '{ngaySinh}' ";

            if (string.IsNullOrEmpty(textBox_NV_Luong_Filter.Text) == false)
                selectCommand += $"AND Luong >= '{textBox_NV_Luong_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_NV_Luong_Filter.Text) == false)
                selectCommand += $"AND KinhNghiem >= '{textBox_NV_NamKN_Filter.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void NV_Remove()
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
                parameter = $"@MaNV{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaNV"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "UPDATE NHANVIEN " +
                                   "SET IsDeleted = 1 " +
                                   "WHERE MaNV IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }

        #endregion


        #region Khoa Tab
        private void pageButton_Tab_Khoa_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = KHOA_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        private void InitializeState_Khoa()
        {
            //control
            Khoa_controlFunc = FIL_FUNC;
            //Upload
            comboBox_Khoa_Operation.SelectedItem = comboBox_Khoa_Operation.Items[0];
        }

        #region Error bits
        const int MAKHOA_KHOA_ERR = 1;
        const int TENKHOA_ERR = 2;
        const int MANV_KHOA_ERR = 4;
        #endregion

        private int CheckUploadTextBox_Khoa()
        {
            int error = 0;

            if (string.IsNullOrEmpty(textBox_Khoa_MaKhoa.Text))
                error |= MAKHOA_KHOA_ERR;
            if (string.IsNullOrEmpty(textBox_Khoa_TenKhoa.Text))
                error |= TENKHOA_ERR;
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

            string checkQuery = "IF EXISTS (SELECT 1 FROM KHOA WHERE MaKhoa = @MaKhoa) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaKhoa", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO KHOA " +
                                        "(MaKhoa, TenKhoa, MaNV_QuanLy) " +
                                        "VALUES(@MaKhoa, @TenKhoa, @MaNV_QuanLy)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaKhoa", primaryKey},
                    {"@TenKhoa", textBox_Khoa_TenKhoa.Text },
                    {"@MaNV_QuanLy", textBox_Khoa_MaNVQuanLy.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

                next_NV_PrimaryKey = StringMath.Increment(next_NV_PrimaryKey);
            }
            else
            {
                string updateQuery = "UPDATE KHOA " +
                                        "SET TenKhoa = @TenKhoa, " +
                                            "MaNV_QuanLy = @MaNV_QuanLy " +
                                        "WHERE MaKhoa = @MaKhoa";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaKhoa", primaryKey},
                    {"@TenKhoa", textBox_Khoa_TenKhoa.Text },
                    {"@MaNV_QuanLy", textBox_Khoa_MaNVQuanLy.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void button_Khoa_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = KHOA_SelectCommand;

            if (string.IsNullOrEmpty(textBox_Khoa_MaKhoa_Filter.Text) == false)
                selectCommand += $"AND MaKhoa = '{textBox_Khoa_MaKhoa_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_Khoa_TenKhoa_Filter.Text) == false)
                selectCommand += $"AND TenKhoa = N'{textBox_Khoa_TenKhoa_Filter.Text}' ";

            string operation = GeneralMethods.GetOperation(comboBox_Khoa_Operation);
            if (string.IsNullOrEmpty(textBox_Khoa_SoLuong_Filter.Text) == false)
                selectCommand += $"AND SoLuong {operation} '{textBox_Khoa_SoLuong_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_Khoa_MaNVQuanLy_Filter.Text) == false)
                selectCommand += $"AND MaNV_QuanLy = '{textBox_Khoa_MaNVQuanLy_Filter.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void Khoa_Remove()
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
                parameter = $"@MaKhoa{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaKhoa"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "UPDATE KHOA " +
                                   "SET IsDeleted = 1 " +
                                   "WHERE MaKhoa IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }

        #endregion

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int offset = 5;

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }
        }

        private void pageButton_Details_NV_Click(object sender, EventArgs e)
        {
            if (NV_ControlDetails == false)
            {
                Enable_PanelDetails();

                if (customDataGridView.SelectedCells.Count > 0)
                {
                    DataGridViewRow row = customDataGridView.SelectedCells[0].OwningRow;
                    string primaryKey = row.Cells["MaNV"].Value.ToString();
                    //display BENHNHAN information
                    textBox_NVDetails_MaNV.Text = primaryKey;
                    textBox_NVDetails_HoTen.Text = row.Cells["HoTenNV"].Value.ToString();
                    textBox_NVDetails_Email.Text = row.Cells["Email"].Value.ToString();
                    textBox_NVDetails_SDT.Text = row.Cells["SDT"].Value.ToString();
                    textBox_NVDetails_NgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
                    textBox_NVDetails_GioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                    textBox_NVDetails_Luong.Text = row.Cells["Luong"].Value.ToString();
                    textBox_NVDetails_KinhNghiem.Text = row.Cells["KinhNghiem"].Value.ToString();

                    //display LichSuKham
                    string selectCommand = "SELECT MaPK, MaLK, LK.MaBN, MaHSBA, ThoiDiem, KetQuaTongQuat, TinhTrang " +
                                           "FROM HOSOBENHAN HS " +
                                           "INNER JOIN LICHKHAM LK ON LK.MaBN = HS.MaBN AND CAST(LK.ThoiDiem AS DATE) = HS.NgayLap " +
                                           "WHERE " +
                                          $"MaNV = '{primaryKey}'";
                    UpdateDataGridView(customDataGridView_LichSuKham, DatabaseConnection.LoadDataIntoDataTable(selectCommand));

                    //display LichSuThanhToan
                    selectCommand = "SELECT MaHD, MaBN, NgayThanhToan, TongTien " +
                                    "FROM HOADON " +
                                    "WHERE " +
                                   $"MaNV = '{primaryKey}'";
                    UpdateDataGridView(customDataGridView_LichSuThanhToan, DatabaseConnection.LoadDataIntoDataTable(selectCommand));

                    //display LichLamViec
                    selectCommand = "SELECT MaPK, ThoiGianBD, ThoiGianKT " +
                                    "FROM LamViec " +
                                   $"WHERE MaNV = '{primaryKey}'";
                    UpdateDataGridView(customDataGridView_LichLamViec, DatabaseConnection.LoadDataIntoDataTable(selectCommand));
                }
            }
            else
            {
                Disable_PanelDetails();
            }
        }

        void Enable_PanelDetails()
        {
            panel_Details.BringToFront();
            ColoringButton.EnabledColor(pageButton_Details_NV);
            NV_ControlDetails = true;
        }
        void Disable_PanelDetails()
        {
            panel_Details.SendToBack();
            ColoringButton.DisabledColor(pageButton_Details_NV);
            NV_ControlDetails = false;
        }
        private void panel_Details_Leave(object sender, EventArgs e)
        {
            Disable_PanelDetails();
        }

        private void panel_Details_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 1104, offset = 5;

            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_NVDetails_LichSuKham.Location.Y + label_NVDetails_LichSuKham.Height / 2 + offset),
                                         new Point(label_NVDetails_LichSuKham.Location.X, label_NVDetails_LichSuKham.Location.Y + label_NVDetails_LichSuKham.Height / 2 + offset)); //label_BNDetails_LichSuKham line
            graphic.DrawLine(sectionPen, new Point(label_NVDetails_LichSuKham.Location.X + label_NVDetails_LichSuKham.Width, label_NVDetails_LichSuKham.Location.Y + label_NVDetails_LichSuKham.Height / 2 + offset),
                                         new Point(endX + offset, label_NVDetails_LichSuKham.Location.Y + label_NVDetails_LichSuKham.Height / 2 + offset)); //label_BNDetails_LichSuKham line

            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_NVDetails_LichSuThanhToan.Location.Y + label_NVDetails_LichSuThanhToan.Height / 2 + offset),
                                         new Point(label_NVDetails_LichSuThanhToan.Location.X, label_NVDetails_LichSuThanhToan.Location.Y + label_NVDetails_LichSuThanhToan.Height / 2 + offset)); //label_BNDetails_LichSuThanhToan line
            graphic.DrawLine(sectionPen, new Point(label_NVDetails_LichSuThanhToan.Location.X + label_NVDetails_LichSuThanhToan.Width, label_NVDetails_LichSuThanhToan.Location.Y + label_NVDetails_LichSuThanhToan.Height / 2 + offset),
                                         new Point(endX + offset, label_NVDetails_LichSuThanhToan.Location.Y + label_NVDetails_LichSuThanhToan.Height / 2 + offset)); //label_BNDetails_LichSuThanhToan line

            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_NVDetails_LichLamViec.Location.Y + label_NVDetails_LichLamViec.Height / 2 + offset),
                                         new Point(label_NVDetails_LichLamViec.Location.X, label_NVDetails_LichLamViec.Location.Y + label_NVDetails_LichLamViec.Height / 2 + offset)); //label_BNDetails_LichSuKham line
            graphic.DrawLine(sectionPen, new Point(label_NVDetails_LichLamViec.Location.X + label_NVDetails_LichLamViec.Width, label_NVDetails_LichLamViec.Location.Y + label_NVDetails_LichLamViec.Height / 2 + offset),
                                         new Point(endX + offset, label_NVDetails_LichLamViec.Location.Y + label_NVDetails_LichLamViec.Height / 2 + offset)); //label_BNDetails_LichSuKham line
        }

        private List<string> GetDataWhenDatabaseChanged()
        {
            string NV_chuaPhanCongCommand = "SELECT NV.MaNV " +
                                             "FROM NHANVIEN NV " +
                                             "LEFT JOIN LamViec LV ON LV.MaNV = NV.MaNV " +
                                             "WHERE LV.MaNV IS NULL ";
            //SqlDataReader reader = DatabaseConnection.ExecuteReaderNotification(NV_chuaPhanCongCommand, OnTableChange);
            SqlDataReader reader = DatabaseConnection.ExecuteReader(NV_chuaPhanCongCommand);
            List<string> NV_chuaPhanCongList = new List<string>();
            while (reader.Read())
            {
                NV_chuaPhanCongList.Add(reader["MaNV"].ToString());
            }
            reader.Close();

            return NV_chuaPhanCongList;
        }

        //private void OnTableChange(object sender, SqlNotificationEventArgs e)
        //{
        //    if (e.Type == SqlNotificationType.Change &&
        //       (e.Info == SqlNotificationInfo.Insert || e.Info == SqlNotificationInfo.Delete || e.Info == SqlNotificationInfo.Update))
        //    {
        //        HighlightChuaPhanCong();
        //    }
        //}
        private void checkBox_ChuaPhanCong_Conditions_CheckedChanged(object sender, EventArgs e)
        {
            customDataGridView.Refresh();
        }

        private void customDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            switch (controlPage)
            {
                case NV_TAB:
                    if (checkBox_ChuaPhanCong_Conditions.Checked && highlightList.Contains(row.Cells["MaNV"].Value.ToString()))
                        row.DefaultCellStyle.BackColor = ColorUsed.highlightTop;
                    else
                        row.DefaultCellStyle.BackColor = dgv.BackgroundColor;
                    break;
            }
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);
            GeneralMethods.CleanColorPanel(panel);
            GeneralMethods.SetUpPanel(panel, 0);

            LoadPage(controlPage);
        }

        private void button_NVUpload_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);
            GeneralMethods.CleanColorPanel(panel);
            GeneralMethods.SetUpPanel(panel, 0);
            FillMaNV(textBox_NV_Upload_MaNV);
            GeneralMethods.FillDate(textBox_NV_Upload_Ngay, comboBox_NV_Upload_Thang, textBox_NV_Upload_Nam);

            LoadPage(controlPage);
        }
        private void FillMaNV(TextBox textBox)
        {
            textBox.Text = next_NV_PrimaryKey;
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
                FillMaNV(textBox);
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

            switch (controlPage)
            {
                case NV_TAB:
                    fillPanel_NV(row);
                    break;
                case KHOA_TAB:
                    fillPanel_Khoa(row);
                    break;
            }
        }

        private void fillPanel_NV(DataRow row)
        {
            DateTime date = row.Field<DateTime>("NgaySinh");

            switch (NV_controlFunc)
            {
                case INS_FUNC:
                    textBox_NV_Upload_MaNV.Text = row["MaNV"].ToString();
                    textBox_NV_Upload_MaKhoa.Text = row["MaKhoa"].ToString();
                    textBox_NV_Upload_TenNV.Text = row["HoTenNV"].ToString();
                    textBox_NV_Upload_Ngay.Text = date.Day.ToString();
                    comboBox_NV_Upload_Thang.SelectedIndex = date.Month - 1;
                    textBox_NV_Upload_Nam.Text = date.Year.ToString();
                    textBox_NV_Upload_SDT.Text = row["SDT"].ToString();
                    textBox_NV_Upload_Email.Text = row["Email"].ToString();
                    textBox_NV_Upload_Luong.Text = row["Luong"].ToString();
                    textBox_NV_Upload_NamKN.Text = row["KinhNghiem"].ToString();
                    GeneralMethods.TickCheckBox(checkBox_NV_Upload_Nam, checkBox_NV_Upload_Nu, row["GioiTinh"].ToString());
                    GeneralMethods.CleanColorPanel(panel_NV_Upload);
                    break;
                case FIL_FUNC:
                    GeneralMethods.SetUpPanel(panel_NV_Filter, 2);
                    textBox_NV_MaNV_Filter.Text = row["MaNV"].ToString();
                    textBox_NV_MaKhoa_Filter.Text = row["MaKhoa"].ToString();
                    textBox_NV_HoTen_Filter.Text = row["HoTenNV"].ToString();
                    textBox_NV_Filter_Ngay.Text = date.Day.ToString();
                    comboBox_NV_Filter_Thang.SelectedIndex = date.Month - 1;
                    textBox_NV_Filter_Nam.Text = date.Year.ToString();
                    textBox_NV_Luong_Filter.Text = row["Luong"].ToString();
                    textBox_NV_NamKN_Filter.Text = row["KinhNghiem"].ToString();
                    break;
            }
        }

        private void fillPanel_Khoa(DataRow row)
        {
            switch (Khoa_controlFunc)
            {
                case INS_FUNC:
                    textBox_Khoa_MaKhoa.Text = row["MaKhoa"].ToString();
                    textBox_Khoa_TenKhoa.Text = row["TenKhoa"].ToString();
                    textBox_Khoa_MaNVQuanLy.Text = row["MaNV_QuanLy"].ToString();
                    GeneralMethods.CleanColorPanel(panel_Khoa_Upload);
                    break;
                case FIL_FUNC:
                    textBox_Khoa_MaKhoa_Filter.Text = row["MaKhoa"].ToString();
                    textBox_Khoa_TenKhoa_Filter.Text = row["TenKhoa"].ToString();
                    textBox_Khoa_SoLuong_Filter.Text = row["SoLuong"].ToString();
                    textBox_Khoa_MaNVQuanLy_Filter.Text = row["MaNV_QuanLy"].ToString();
                    comboBox_Khoa_Operation.SelectedIndex = 2;
                    break;
            }
        }

        private void textBox_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_Normal(sender, e);
        }
        private void textBox_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_PositiveNumber(sender, e);
        }
    }
}
