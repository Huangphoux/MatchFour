using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using NUnit.Framework.Constraints;
using QuanLyMachTu.Helper;
using static System.Windows.Forms.AxHost;

namespace QuanLyMachTu
{
    public partial class BenhNhanControl : UserControl
    {
        //Bit errors
        //Upload textBox
        const int MABN_ERR = 1;
        const int TENBN_ERR = 2;
        const int MANV_ERR = 4;
        const int TENTK_ERR = 8;
        const int MK_ERR = 16;
        //Constant property
        const int MAX_HEIGHT = 300;

        //Select command
        string BN_SelectCommand = "SELECT MaBN, HoTenBN, GioiTinh, NgaySinh, DoanhSo, Email, SDT " +
                                  "FROM BENHNHAN " +
                                  "WHERE IsDeleted = 0";
        string HSBA_SelectCommand = "SELECT MaHSBA, NgayLap, KetQuaTongQuat, MaBN, MaNV " +
                                    "FROM HOSOBENHAN " +
                                    "WHERE IsDeleted = 0";
        string TK_SelectCommand = "SELECT * FROM TAIKHOAN";
        string selectLastID_BN = "SELECT TOP 1 MaBN FROM BENHNHAN ORDER BY MaBN DESC";
        string selectLastID_TK = "SELECT TOP 1 MaTK FROM TAIKHOAN ORDER BY MaTK DESC";
        //Control variables
        //tab index
        const int BN_TAB = 0;
        const int HSBA_TAB = 10;
        const int TK_TAB = 20;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //control primary key
        string next_BN_PrimaryKey, next_TK_PrimaryKey;
        //controllers
        string controlCommand;
        int controlPage;
        bool BN_ControlDetails;
        bool HSBA_ControlDetails;
        int BN_ControlFunc;
        int HSBA_ControlFunc;
        int TK_ControlFunc;

        //System methods
        public BenhNhanControl()
        {
            InitializeComponent();
        }
        private void BenhNhanControl_Load(object sender, EventArgs e)
        {
            Prefetch();
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            controlPage = BN_TAB;

            BN_ControlFunc = FIL_FUNC;
            HSBA_ControlFunc = FIL_FUNC;
            TK_ControlFunc = FIL_FUNC;

            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        //Activate / Deactivate tab
        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    ColoringButton.EnabledColor(pageButton_BNTab);
                    enableFunc_BN();
                    break;
                case HSBA_TAB:
                    ColoringButton.EnabledColor(pageButton_HSBATab);
                    enableFunc_HSBA();
                    break;
                case TK_TAB:
                    ColoringButton.EnabledColor(pageButton_TKTab);
                    enableFunc_TK();
                    break;
            }
        }
        private void LoadPage(int controlPage)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    controlCommand = BN_SelectCommand;
                    break;
                case HSBA_TAB:
                    controlCommand = HSBA_SelectCommand;
                    break;
                case TK_TAB:
                    controlCommand = TK_SelectCommand;
                    break;
            }
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    ColoringButton.DisabledColor(pageButton_BNTab);                    
                    break;
                case HSBA_TAB:
                    ColoringButton.DisabledColor(pageButton_HSBATab);
                    break;
                case TK_TAB:
                    ColoringButton.DisabledColor(pageButton_TKTab);
                    break;
            }
        }
        //Load methods
        private void Prefetch()
        {
            next_BN_PrimaryKey = (string)DatabaseConnection.ExecuteScalar(selectLastID_BN, null);
            next_BN_PrimaryKey = StringMath.Increment(next_BN_PrimaryKey);

            next_TK_PrimaryKey = (string)DatabaseConnection.ExecuteScalar(selectLastID_TK, null);
            next_TK_PrimaryKey = StringMath.Increment(next_TK_PrimaryKey);

            LoadTabBenhNhan();
            LoadTabHoSoBenhAn();
            LoadTabTaiKhoan();
        }
        //Reload data
        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;

            //Display statitic number
            //label_HienThiDTTong.Text = CalculateSumOfDoanhSo(dgv).ToString();
        }
        //Upload button
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    panel_BNUpload.BringToFront();
                    BN_ControlFunc = INS_FUNC;
                    break;
                case HSBA_TAB:
                    panel_HSBAUpload.BringToFront();
                    HSBA_ControlFunc = INS_FUNC;
                    break;
                case TK_TAB:
                    panel_TKUpload.BringToFront();
                    TK_ControlFunc = INS_FUNC;
                    break;
            }
        }
        //Filter button
        private void pageButton_Filters_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    panel_BNFilter.BringToFront();
                    BN_ControlFunc = FIL_FUNC;
                    break;
                case HSBA_TAB:
                    panel_HSBAFilter.BringToFront();
                    HSBA_ControlFunc = FIL_FUNC;
                    break;
                case TK_TAB:
                    panel_TKFilter.BringToFront();
                    TK_ControlFunc = FIL_FUNC;
                    break;
            }
        }
        //Remove button
        private void pageButton_Remove_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    pageButton_BNRemove_Click(sender, e);
                    break;
                case HSBA_TAB:
                    pageButton_HSBARemove_Click(sender, e);
                    break;
                case TK_TAB:
                    pageButton_TKRemove_Click(sender, e);
                    break;
            }
        }
        //Decorations
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
        //Additions
        private void Button_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_PositiveNumber(sender, e);
        }
        private void button_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_Normal(sender, e);
        }
        private void textBox_MaBN_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
                FillMaBN(textBox);
        }
        //Bottom view
        private long CalculateSumOfDoanhSo(DataGridView dgv)
        {
            long sum = 0L;
            long doanhSo;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (long.TryParse(row.Cells["DoanhSo"].Value.ToString(), out doanhSo))
                    sum += doanhSo;
            }

            return sum;
        }

        //---------------------------------------------------------------Benh Nhan tab---------------------------------------------------------------        
        //Activate tab
        private void pageButton_BNTab_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = BN_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        private void enableFunc_BN()
        {
            pageButton_Details_BN.Enabled = true;

            switch (BN_ControlFunc)
            {
                case INS_FUNC:
                    panel_BNUpload.BringToFront();
                    break;
                case FIL_FUNC:
                    panel_BNFilter.BringToFront();
                    break;
            }
        }
        //Load data
        private void LoadTabBenhNhan()
        {
            //Upload
            comboBox_BNUpload_Thang.SelectedItem = comboBox_BNUpload_Thang.Items[0];
            FillMaBN(textBox_BNUpload_MaBN);
            GeneralMethods.FillDate(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);

            //Filters
            comboBox_BNFilters_Comparer.SelectedIndex = 2;

            //Details
            BN_ControlDetails = false;
            panel_BNDetails.SendToBack();
        }
        //Check and prevent errors
        private void checkBox_BNUpload_Nam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BNUpload_Nam.Checked)
                checkBox_BNUpload_Nu.Checked = false;
        }

        private void checkBox_BNUpload_Nu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_BNUpload_Nu.Checked)
                checkBox_BNUpload_Nam.Checked = false;
        }
        private int CheckUploadTextBox()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_BNUpload_MaBN.Text))
                error |= 1;
            if (string.IsNullOrEmpty(textBox_BNUpload_TenBN.Text))
                error |= 2;

            return error;
        }
        private void WarningUploadTextBoxError(int error)
        {
            if ((error & MABN_ERR) == MABN_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_MaBN);
            if ((error & TENBN_ERR) == TENBN_ERR)
                ColoringTextBox.WarningColor(textBox_BNUpload_TenBN);
        }
        //Autofill
        private void FillMaBN(TextBox maBN)
        {
            maBN.Text = next_BN_PrimaryKey;
        }

        //Upload method
        private void button_BNUpload_OK_Click(object sender, EventArgs e)
        {
            int error = CheckUploadTextBox();
            if (error != 0)
            {
                WarningUploadTextBoxError(error);
                return;
            }

            string primaryKey = textBox_BNUpload_MaBN.Text;

            string checkQuery = "IF EXISTS (SELECT 1 FROM BENHNHAN WHERE MaBN = @MaBN) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaBN", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO BENHNHAN " +
                                        "(MaBN, HoTenBN, GioiTinh, NgaySinh, Email, SDT) " +
                                        "VALUES(@MaBN, @HoTenBN, @GioiTinh, @NgaySinh, @Email, @SDT)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaBN", primaryKey},
                    {"@HoTenBN", textBox_BNUpload_TenBN.Text },
                    {"@GioiTinh", GeneralMethods.GetGioiTinh(checkBox_BNUpload_Nam, checkBox_BNUpload_Nu) },
                    {"@NgaySinh", GeneralMethods.GetNgayThangNam(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam) },
                    {"@Email", textBox_BNUpload_Email.Text },
                    {"@SDT", textBox_BNUpload_SDT.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

                next_BN_PrimaryKey = StringMath.Increment(next_BN_PrimaryKey);
            }
            else
            {
                string updateQuery = "UPDATE BENHNHAN " +
                                        "SET HoTenBN = @HoTenBN, " +
                                            "GioiTinh = @GioiTinh, " +
                                            "NgaySinh = @NgaySinh, " +
                                            "Email = @Email, " +
                                            "SDT = @SDT " +
                                        "WHERE MaBN = @MaBN";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaBN", primaryKey},
                    {"@HoTenBN", textBox_BNUpload_TenBN.Text },
                    {"@GioiTinh", GeneralMethods.GetGioiTinh(checkBox_BNUpload_Nam, checkBox_BNUpload_Nu) },
                    {"@NgaySinh", GeneralMethods.GetNgayThangNam(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam) },
                    {"@Email", textBox_BNUpload_Email.Text },
                    {"@SDT", textBox_BNUpload_SDT.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Filter method
        private void button_BNFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "SELECT DISTINCT BN.MaBN, HoTenBN, GioiTinh, NgaySinh, DoanhSo, BN.Email, BN.SDT " +
                                   "FROM BENHNHAN BN " +
                                   "INNER JOIN HOSOBENHAN HS ON HS.MaBN = BN.MaBN " +
                                   "INNER JOIN TAIKHOAN TK ON TK.MaBN = BN.MaBN " +
                                   "WHERE BN.IsDeleted = 0 AND HS.IsDeleted = 0 ";
            //Find exact row
            if (string.IsNullOrEmpty(textBox_Filters_MaBN.Text) == false)
                selectCommand += $"AND BN.MaBN = '{textBox_Filters_MaBN.Text}' ";
            else if (string.IsNullOrEmpty(textBox_Filters_MaHSBA.Text) == false)
                selectCommand += $"AND MaHSBA = '{textBox_Filters_MaHSBA.Text}' ";
            else if (string.IsNullOrEmpty(textBox_Filters_MaTK.Text) == false)
                selectCommand += $"AND MaTK = '{textBox_Filters_MaTK.Text}' ";

            //Another informations
            if (string.IsNullOrEmpty(textBox_Filters_TenBN.Text) == false)
                selectCommand += $"AND HoTenBN = N'{textBox_Filters_TenBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_Email.Text) == false)
                selectCommand += $"AND BN.Email = '{textBox_Filters_Email.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_SDT.Text) == false)
                selectCommand += $"AND BN.SDT = '{textBox_Filters_SDT.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_DoanhSo.Text) == false)
                selectCommand += $"AND DoanhSo {GeneralMethods.GetOperation(comboBox_BNFilters_Comparer)} {textBox_Filters_DoanhSo.Text} ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Remove
        private void pageButton_BNRemove_Click(object sender, EventArgs e)
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
                parameter = $"@MaBN{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaBN"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "UPDATE BENHNHAN " +
                                   "SET IsDeleted = 1 " +
                                   "WHERE MaBN IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Additional
        private void textBox_BNDate_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
                GeneralMethods.FillDate(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
        }

        //-------------------------------------------------------------Ho So Benh An tab-------------------------------------------------------------        
        //Activate tab
        private void pageButton_HSBATab_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = HSBA_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        private void enableFunc_HSBA()
        {
            switch (HSBA_ControlFunc)
            {
                case INS_FUNC:
                    panel_HSBAUpload.BringToFront();
                    break;
                case FIL_FUNC:
                    panel_HSBAFilter.BringToFront();
                    break;
            }
        }
        //Load data
        private void LoadTabHoSoBenhAn()
        {
            //Details
            HSBA_ControlDetails = false;
            panel_HSBADetails.SendToBack();
            //Upload
            GeneralMethods.FillDate(textBox_HSBAUpload_Ngay, comboBox_HSBAUpload_Thang, textBox_HSBAUpload_Nam);

            //Filters
            comboBox_HSBAFilter_Thang.SelectedItem = comboBox_BNUpload_Thang.Items[0];
            comboBox_HSBAFilter_Operation.SelectedItem = comboBox_HSBAFilter_Operation.Items[0];
        }
        //Check and prevent errors
        private int CheckUploadError_HSBA()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_HSBAUpload_MaBN.Text))
                error |= MABN_ERR;
            if (string.IsNullOrEmpty(textBox_HSBAUpload_MaNV.Text))
                error |= MANV_ERR;
            return error;
        }
        private void WarningUploadTextBoxError_HSBA(int error)
        {
            if ((error & MABN_ERR) == MABN_ERR)
                ColoringTextBox.WarningColor(textBox_HSBAUpload_MaBN);
            if ((error & MANV_ERR) == MANV_ERR)
                ColoringTextBox.WarningColor(textBox_HSBAUpload_MaNV);
        }
        //Upload method
        private void button_HSBAUpload_OK_Click(object sender, EventArgs e)
        {
            //check errors
            int error = CheckUploadError_HSBA();
            if (error != 0)
            {
                WarningUploadTextBoxError_HSBA(error);
                return;
            }

            //handle event
            string[] primaryKey = { textBox_HSBAUpload_MaHSBA.Text, GeneralMethods.GetNgayThangNam(textBox_HSBAUpload_Ngay, comboBox_HSBAUpload_Thang, textBox_HSBAUpload_Nam) };

            string checkQuery = "IF EXISTS (SELECT 1 FROM HOSOBENHAN WHERE MaHSBA = @MaHSBA AND NgayLap = @NgayLap) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaHSBA", primaryKey[0] }, { "@NgayLap", primaryKey[1] } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO HOSOBENHAN " +
                                        "(MaHSBA, NgayLap, KetQuaTongQuat, MaBN, MaNV) " +
                                        "VALUES(@MaHSBA, @NgayLap, @KetQuaTongQuat, @MaBN, @MaNV)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaHSBA", primaryKey[0]},
                    {"@NgayLap", primaryKey[1]},
                    {"@KetQuaTongQuat", textBox_HSBAUpload_KetQuaTQ.Text },
                    {"@MaBN", textBox_HSBAUpload_MaBN.Text },
                    {"@MaNV", textBox_HSBAUpload_MaNV.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);
            }
            else
            {
                string updateQuery = "UPDATE HOSOBENHAN " +
                                        "SET KetQuaTongQuat = @KetQuaTongQuat, " +
                                            "MaBN = @MaBN, " +
                                            "MaNV = @MaNV " +
                                        "WHERE MaHSBA = @MaHSBA AND NgayLap = @NgayLap";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaHSBA", primaryKey[0]},
                    {"@NgayLap", primaryKey[1]},
                    {"@KetQuaTongQuat", textBox_HSBAUpload_KetQuaTQ.Text },
                    {"@MaBN", textBox_HSBAUpload_MaBN.Text },
                    {"@MaNV", textBox_HSBAUpload_MaNV.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Filter method
        private void button_HSBAFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "SELECT MaHSBA, NgayLap, KetQuaTongQuat, HS.MaBN, MaNV " +
                                   "FROM HOSOBENHAN HS " +
                                   "INNER JOIN BENHNHAN BN ON BN.MaBN = HS.MaBN " +
                                   "WHERE BN.IsDeleted = 0 AND HS.IsDeleted = 0 ";

            //make a select command
            if (string.IsNullOrEmpty(textBox_HSBAFilter_MaBN.Text) == false)
                selectCommand += $"AND HS.MaBN = '{textBox_HSBAFilter_MaBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_HSBAFilter_MaHSBA.Text) == false)
                selectCommand += $"AND MaHSBA = '{textBox_HSBAFilter_MaHSBA.Text}' ";
            string ngayLap = GeneralMethods.GetNgayThangNam(textBox_HSBAFilter_Ngay, comboBox_HSBAFilter_Thang, textBox_HSBAFilter_Nam);
            string operation = GeneralMethods.GetOperation(comboBox_HSBAFilter_Operation);
            if (string.IsNullOrEmpty(ngayLap) == false)
                selectCommand += $"AND NgayLap {operation} '{ngayLap}' ";

            if (string.IsNullOrEmpty(textBox_HSBAFilter_Email.Text) == false)
                selectCommand += $"AND Email = '{textBox_HSBAFilter_Email.Text}' ";
            if (string.IsNullOrEmpty(textBox_HSBAFilter_SDT.Text) == false)
                selectCommand += $"AND SDT = '{textBox_HSBAFilter_SDT.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Remove
        private void pageButton_HSBARemove_Click(object sender, EventArgs e)
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter1, parameter2;
            int parameterIndex = 0;

            string maHSBA, ngayLap;

            string inDeletedList = "1 != 1 ";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter1 = $"@MaHSBA{parameterIndex}";
                parameter2 = $"@NgayLap{parameterIndex}";
                maHSBA = row.Cells["MaHSBA"].Value.ToString();
                ngayLap = row.Cells["NgayLap"].Value.ToString();
                parameters.Add(parameter1, maHSBA);
                parameters.Add(parameter2, ngayLap);
                inDeletedList += $"OR (MaHSBA = {parameter1} AND NgayLap = {parameter2}) ";
                parameterIndex++;
            }

            //remove
            string deleteCommand = "UPDATE HOSOBENHAN " +
                                   "SET IsDeleted = 1" +
                                   "WHERE " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Additional
        private void textBox_HSBADate_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
                GeneralMethods.FillDate(textBox_HSBAUpload_Ngay, comboBox_HSBAUpload_Thang, textBox_HSBAUpload_Nam);
        }
        //Decorate panel
        private void panel_HSBAUpload_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int offset = 5;

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox && control != textBox_HSBAUpload_KetQuaTQ)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }

            int x = label_HSBAUpload_NgayLap.Location.X - 9;
            int startY = label_HSBAUpload_NgayLap.Location.Y, endY = startY + label_HSBAUpload_NgayLap.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }
        private void panel_HSBAFilter_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int offset = 5;

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox && control != textBox_HSBAUpload_KetQuaTQ)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }

            int x = label_HSBAFilters_NgayLap.Location.X - 9;
            int startY = label_HSBAFilters_NgayLap.Location.Y, endY = startY + label_HSBAFilters_NgayLap.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }

        //---------------------------------------------------------------Tai Khoan tab-----------------------------------------------------------------
        //Activate tab
        private void pageButton_TKTab_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = TK_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }
        private void enableFunc_TK()
        {
            switch (TK_ControlFunc)
            {
                case INS_FUNC:
                    panel_TKUpload.BringToFront();
                    break;
                case FIL_FUNC:
                    panel_TKFilter.BringToFront();
                    break;
            }
        }
        //Load data
        private void LoadTabTaiKhoan()
        {
            //Upload
            Autofill_MaTK(textBox_TKUpload_MaTK);

            //Filters
            comboBox_TKFilter_Thang.SelectedIndex = 0;
            comboBox_TKFilter_Operation.SelectedIndex = 2;
        }
        //Check and prevent errors
        private int CheckUploadError_TK()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_TKUpload_TenTK.Text))
                error |= TENTK_ERR;
            if (string.IsNullOrEmpty(textBox_TKUpload_MatKhau.Text))
                error |= MK_ERR;
            return error;
        }
        private void WarningUploadTextBoxError_TK(int error)
        {
            if ((error & TENTK_ERR) == TENTK_ERR)
                ColoringTextBox.WarningColor(textBox_TKUpload_TenTK);
            if ((error & MK_ERR) == MK_ERR)
                ColoringTextBox.WarningColor(textBox_TKUpload_MatKhau);
        }
        //Autofill
        private void Autofill_MaTK(TextBox textBox)
        {
            textBox.Text = next_TK_PrimaryKey;
        }
        //Upload method
        private void button_TKUpload_OK_Click(object sender, EventArgs e)
        {
            //check errors
            int error = CheckUploadError_TK();
            if (error != 0)
            {
                WarningUploadTextBoxError_TK(error);
                return;
            }

            //handle event
            string primaryKey = textBox_TKUpload_MaTK.Text;

            string checkQuery = "IF EXISTS (SELECT 1 FROM TAIKHOAN WHERE MaTK = @MaTK) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaTK", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO TAIKHOAN " +
                                        "VALUES(@MaTK, @TenTK, @MatKhau, @SDT, @Email, @MaBN)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaTK", primaryKey},
                    {"@TenTK", textBox_TKUpload_TenTK.Text },
                    {"@MatKhau", textBox_TKUpload_MatKhau.Text },
                    {"@SDT", textBox_TKUpload_SDT.Text },
                    {"@Email", textBox_TKUpload_Email.Text },
                    {"@MaBN", textBox_TKUpload_MaBN.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

                next_BN_PrimaryKey = StringMath.Increment(next_BN_PrimaryKey);
            }
            else
            {
                string updateQuery = "UPDATE TAIKHOAN " +
                                        "SET TenTK = @TenTK, " +
                                            "MatKhau = @MatKhau, " +
                                            "SDT = @SDT, " +
                                            "Email = @Email, " +
                                            "MaBN = @MaBN " +
                                        "WHERE MaTK = @MaTK";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaTK", primaryKey},
                    {"@TenTK", textBox_TKUpload_TenTK.Text },
                    {"@MatKhau", textBox_TKUpload_MatKhau.Text },
                    {"@SDT", textBox_TKUpload_SDT.Text },
                    {"@Email", textBox_TKUpload_Email.Text },
                    {"@MaBN", textBox_TKUpload_MaBN.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Filter method
        private void button_TKFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "SELECT * " +
                                   "FROM TAIKHOAN " +
                                   "WHERE 1 = 1 ";

            //make a select command
            if (string.IsNullOrEmpty(textBox_TKFilter_MaBN.Text) == false)
                selectCommand += $"AND MaBN = '{textBox_TKFilter_MaBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_TKFilter_MaTK.Text) == false)
                selectCommand += $"AND MaTK = '{textBox_TKFilter_MaTK.Text}' ";
            if (string.IsNullOrEmpty(textBox_TKFilter_TenTK.Text) == false)
                selectCommand += $"AND TenTK = '{textBox_TKFilter_TenTK.Text}' ";
            if (string.IsNullOrEmpty(textBox_TKFilter_Email.Text) == false)
                selectCommand += $"AND Email = '{textBox_TKFilter_Email.Text}' ";
            if (string.IsNullOrEmpty(textBox_TKFilter_SDT.Text) == false)
                selectCommand += $"AND SDT = '{textBox_TKFilter_SDT.Text}' ";
            string ngayLap = GeneralMethods.GetNgayThangNam(textBox_TKFilter_Ngay, comboBox_TKFilter_Thang, textBox_TKFilter_Nam);
            string operation = GeneralMethods.GetOperation(comboBox_TKFilter_Operation);
            if (string.IsNullOrEmpty(ngayLap) == false)
                selectCommand += $"AND NgayLap {operation} '{ngayLap}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Remove
        private void pageButton_TKRemove_Click(object sender, EventArgs e)
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
                parameter = $"@MaTK{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaTK"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "DELETE FROM TAIKHOAN " +
                                   "WHERE MaTK IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Additional
        private void textBox_MaTK_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
                Autofill_MaTK(textBox);
        }
        //Decorate panel
        private void panel_TKFilter_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int offset = 5;

            foreach (Control control in panel.Controls)
            {
                if (control is TextBox && control != textBox_HSBAUpload_KetQuaTQ)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }

            int x = label_TKFilters_NgayTao.Location.X - 9;
            int startY = label_TKFilters_NgayTao.Location.Y, endY = startY + label_TKFilters_NgayTao.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }

        private void fillPanel_BN(DataRow row)
        {
            switch (BN_ControlFunc)
            {
                case INS_FUNC:
                    textBox_BNUpload_MaBN.Text = row["MaBN"].ToString();
                    textBox_BNUpload_TenBN.Text = row["HoTenBN"].ToString();
                    textBox_BNUpload_Ngay.Text = row.Field<DateTime>("NgaySinh").Day.ToString();
                    textBox_BNUpload_Nam.Text = row.Field<DateTime>("NgaySinh").Year.ToString();
                    textBox_BNUpload_SDT.Text = row["SDT"].ToString();
                    textBox_BNUpload_Email.Text = row["Email"].ToString();
                    comboBox_BNUpload_Thang.SelectedIndex = row.Field<DateTime>("NgaySinh").Month - 1;

                    if (row["GioiTinh"].ToString() == "Nam")
                    {
                        checkBox_BNUpload_Nam.Checked = true;
                        checkBox_BNUpload_Nu.Checked = false;
                    }
                    else
                    {
                        checkBox_BNUpload_Nam.Checked = false;
                        checkBox_BNUpload_Nu.Checked = true;
                    }
                    break;
                case FIL_FUNC:
                    textBox_Filters_MaBN.Text = row["MaBN"].ToString();
                    textBox_Filters_TenBN.Text = row["HoTenBN"].ToString();
                    textBox_Filters_SDT.Text = row["SDT"].ToString();
                    textBox_Filters_Email.Text = row["Email"].ToString();
                    textBox_Filters_DoanhSo.Text = row["DoanhSo"].ToString();
                    break;
            }
        }
        private void fillPanel_HSBA(DataRow row)
        {
            switch (HSBA_ControlFunc)
            {
                case INS_FUNC:
                    textBox_HSBAUpload_MaBN.Text = row["MaBN"].ToString();
                    textBox_HSBAUpload_MaHSBA.Text = row["MaHSBA"].ToString();
                    textBox_HSBAUpload_MaNV.Text = row["MaNV"].ToString();
                    textBox_HSBAUpload_Ngay.Text = row.Field<DateTime>("NgayLap").Day.ToString();
                    textBox_HSBAUpload_Nam.Text = row.Field<DateTime>("NgayLap").Year.ToString();
                    comboBox_HSBAUpload_Thang.SelectedIndex = row.Field<DateTime>("NgayLap").Month - 1;

                    if (string.IsNullOrEmpty(row["KetQuaTongQuat"].ToString()) == false)
                        textBox_HSBAUpload_KetQuaTQ.Text = row["KetQuaTongQuat"].ToString();

                    break;
                case FIL_FUNC:
                    textBox_HSBAFilter_MaBN.Text = row["MaBN"].ToString();
                    textBox_HSBAFilter_MaHSBA.Text = row["MaHSBA"].ToString();
                    //textBox_HSBAFilter_Email.Text = row["Email"].ToString();
                    //textBox_HSBAFilter_SDT.Text = row["SDT"].ToString();
                    textBox_HSBAFilter_Ngay.Text = row.Field<DateTime>("NgayLap").Day.ToString();
                    textBox_HSBAFilter_Nam.Text = row.Field<DateTime>("NgayLap").Year.ToString();
                    comboBox_HSBAFilter_Thang.SelectedIndex = row.Field<DateTime>("NgayLap").Month - 1;
                    break;
            }
        }
        private void fillPanel_TK(DataRow row)
        {
            switch (TK_ControlFunc)
            {
                case INS_FUNC:
                    textBox_TKUpload_MaBN.Text = row["MaBN"].ToString();
                    textBox_TKUpload_MaTK.Text = row["MaTK"].ToString();
                    textBox_TKUpload_TenTK.Text = row["TenTK"].ToString();
                    textBox_TKUpload_MatKhau.Text = row["MatKhau"].ToString();
                    textBox_TKUpload_SDT.Text = row["SDT"].ToString();
                    textBox_TKUpload_Email.Text = row["Email"].ToString();
                    break;
                case FIL_FUNC:
                    textBox_TKFilter_MaBN.Text = row["MaBN"].ToString();
                    textBox_TKFilter_MaTK.Text = row["MaTK"].ToString();
                    textBox_TKFilter_TenTK.Text = row["TenTK"].ToString();
                    textBox_TKFilter_SDT.Text = row["SDT"].ToString();
                    textBox_TKFilter_Email.Text = row["Email"].ToString();
                    textBox_TKFilter_Ngay.Text = row.Field<DateTime>("NgayLap").Day.ToString();
                    textBox_TKFilter_Nam.Text = row.Field<DateTime>("NgayLap").Year.ToString();
                    comboBox_TKFilter_Thang.SelectedIndex = row.Field<DateTime>("NgayLap").Month - 1;
                    break;
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

            switch (controlPage)
            {
                case BN_TAB:
                    fillPanel_BN(row);
                    break;
                case HSBA_TAB:
                    fillPanel_HSBA(row);
                    break;
                case TK_TAB:
                    fillPanel_TK(row);
                    break;
            }
        }

        private void customDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                pageButton_Remove_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)
            {
                pageButton_Filters_Click(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.T)
            {
                pageButton_Upload_Click(sender, e);
                e.Handled = true;
            }
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Panel containingPanel = clickedButton.Parent as Panel;

            foreach (Control control in containingPanel.Controls)
            {
                if (control is TextBox textBox)
                    textBox.Text = "";
                else if (control is ComboBox comboBox)
                    comboBox.SelectedIndex = 0;
            }
            LoadPage(controlPage);
        }

        private void button_TKUpload_Reset_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Panel containingPanel = clickedButton.Parent as Panel;

            foreach (Control control in containingPanel.Controls)
                if (control is TextBox textBox)
                    textBox.Text = "";

            Autofill_MaTK(textBox_TKUpload_MaTK);
            LoadPage(controlPage);
        }

        private void button_HSBAUpload_Reset_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Panel containingPanel = clickedButton.Parent as Panel;

            foreach (Control control in containingPanel.Controls)
                if (control is TextBox textBox)
                    textBox.Text = "";

            GeneralMethods.FillDate(textBox_HSBAUpload_Ngay, comboBox_HSBAUpload_Thang, textBox_HSBAUpload_Nam);
            LoadPage(controlPage);
        }

        private void button_BNUpload_Reset_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            Panel containingPanel = clickedButton.Parent as Panel;

            foreach (Control control in containingPanel.Controls)
                if (control is TextBox textBox)
                    textBox.Text = "";

            FillMaBN(textBox_BNUpload_MaBN);
            GeneralMethods.FillDate(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
            LoadPage(controlPage);
        }

        private void pageButton_Details_BN_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    toggle_BNDetails_panel();
                    break;
                case HSBA_TAB:
                    toggle_HSBADetails_panel();
                    break;
            }
        }
        private void ShowDetails_BN()
        {
            if (customDataGridView.SelectedCells.Count > 0)
            {
                DataGridViewRow row = customDataGridView.SelectedCells[0].OwningRow;
                string primaryKey = row.Cells["MaBN"].Value.ToString();
                //display BENHNHAN information
                textBox_BNDetails_MaBN.Text = primaryKey;
                textBox_BNDetails_HoTen.Text = row.Cells["HoTenBN"].Value.ToString();
                textBox_BNDetails_Email.Text = row.Cells["Email"].Value.ToString();
                textBox_BNDetails_SDT.Text = row.Cells["SDT"].Value.ToString();
                textBox_BNDetails_NgaySinh.Text = row.Cells["NgaySinh"].Value.ToString();
                textBox_BNDetails_GioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
                textBox_BNDetails_DoanhSo.Text = row.Cells["DoanhSo"].Value.ToString();

                //display LichSuKham
                string selectCommand = "SELECT MaHSBA, MaLK, ThoiDiem, TinhTrang, KetQuaTongQuat, MaPK, MaNV " +
                                       "FROM HOSOBENHAN HS " +
                                       "INNER JOIN LICHKHAM LK ON LK.MaBN = HS.MaBN AND CAST(LK.ThoiDiem AS DATE) = HS.NgayLap " +
                                       "WHERE HS.IsDeleted = 0 AND " +
                                      $"HS.MaBN = '{primaryKey}'";
                UpdateDataGridView(customDataGridView_LichSuKham, DatabaseConnection.LoadDataIntoDataTable(selectCommand));

                //display LichSuKetQuaKham
                selectCommand = "SELECT HSBA.MaHSBA, HSBA.NgayLap, MaDV, KetQuaChuanDoan, NoiDung " +
                                "FROM KetQua KQ " +
                                "INNER JOIN HOSOBENHAN HSBA ON HSBA.MaHSBA = KQ.MaHSBA AND HSBA.NgayLap = KQ.NgayLap " +
                                "WHERE IsDeleted = 0 AND " +
                               $"MaBN = '{primaryKey}'";
                UpdateDataGridView(customDataGridView_LichSuKetQuaKham, DatabaseConnection.LoadDataIntoDataTable(selectCommand));

                //display LichSuThanhToan
                selectCommand = "SELECT MaHD, NgayThanhToan, TongTien, MaNV " +
                                "FROM HOADON " +
                                "WHERE IsDeleted = 0 AND " +
                               $"MaBN = '{primaryKey}'";
                UpdateDataGridView(customDataGridView_LichSuThanhToan, DatabaseConnection.LoadDataIntoDataTable(selectCommand));
            }
        }
        private void ShowDetails_HSBA()
        {
            if (customDataGridView.SelectedCells.Count > 0)
            {
                DataGridViewRow row = customDataGridView.SelectedCells[0].OwningRow;
                string[] primaryKey = { row.Cells["MaHSBA"].Value.ToString(), row.Cells["NgayLap"].Value.ToString() };
                //display BENHNHAN information
                string selectBNInfo = "SELECT BN.MaBN, HoTenBN, Email, SDT, NgaySinh, GioiTinh, DoanhSo, KetQuaTongQuat " +
                                      "FROM BENHNHAN BN " +
                                      "INNER JOIN HOSOBENHAN HSBA ON HSBA.MaBN = BN.MaBN " +
                                     $"WHERE BN.IsDeleted = 0 AND MaHSBA = '{primaryKey[0]}'";
                DataTable BN_info = DatabaseConnection.LoadDataIntoDataTable(selectBNInfo);
                if (BN_info.Rows.Count == 0)
                    return;

                DataRow BN_row = BN_info.Rows[0];
                textBox_HSBADetails_MaBN.Text = BN_row["MaBN"].ToString();
                textBox_HSBADetails_HoTen.Text = BN_row["HoTenBN"].ToString();
                textBox_HSBADetails_Email.Text = BN_row["Email"].ToString();
                textBox_HSBADetails_SDT.Text = BN_row["SDT"].ToString();
                textBox_HSBADetails_NgaySinh.Text = BN_row["NgaySinh"].ToString();
                textBox_HSBADetails_GioiTinh.Text = BN_row["GioiTinh"].ToString();
                textBox_HSBADetails_DoanhSo.Text = BN_row["DoanhSo"].ToString();

                //display KetQuaKham
                string selectCommand = "SELECT * " +
                                       "FROM KetQua " +
                                      $"WHERE MaHSBA = '{primaryKey[0]}' AND NgayLap = '{primaryKey[1]}'";
                UpdateDataGridView(customDataGridView_KetQuaKham, DatabaseConnection.LoadDataIntoDataTable(selectCommand));
            }
        }
        private void toggle_BNDetails_panel()
        {
            if (BN_ControlDetails)
            {
                panel_BNDetails.SendToBack();
                ColoringButton.DisabledColor(pageButton_Details_BN);
                BN_ControlDetails = false;
            }
            else
            {
                panel_BNDetails.BringToFront();
                ColoringButton.EnabledColor(pageButton_Details_BN);
                BN_ControlDetails = true;
                ShowDetails_BN();
            }
        }
        private void toggle_HSBADetails_panel()
        {
            if (HSBA_ControlDetails)
            {
                panel_HSBADetails.SendToBack();
                ColoringButton.DisabledColor(pageButton_Details_BN);
                HSBA_ControlDetails = false;
            }
            else
            {
                panel_HSBADetails.BringToFront();
                ColoringButton.EnabledColor(pageButton_Details_BN);
                HSBA_ControlDetails = true;
                ShowDetails_HSBA();
            }
        }
        private void panel_Details_Leave(object sender, EventArgs e)
        {
            toggle_BNDetails_panel();
        }

        private void panel_Details_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen sectionPen = new Pen(lineColor, 2);
            int startX = 20, endX = 1104, offset = 5;

            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_BNDetails_LichSuKham.Location.Y + label_BNDetails_LichSuKham.Height / 2 + offset),
                                         new Point(label_BNDetails_LichSuKham.Location.X, label_BNDetails_LichSuKham.Location.Y + label_BNDetails_LichSuKham.Height / 2 + offset)); //label_BNDetails_LichSuKham line
            graphic.DrawLine(sectionPen, new Point(label_BNDetails_LichSuKham.Location.X + label_BNDetails_LichSuKham.Width, label_BNDetails_LichSuKham.Location.Y + label_BNDetails_LichSuKham.Height / 2 + offset),
                                         new Point(endX + offset, label_BNDetails_LichSuKham.Location.Y + label_BNDetails_LichSuKham.Height / 2 + offset)); //label_BNDetails_LichSuKham line

            graphic.DrawLine(sectionPen, new Point(startX - 3 * offset, label_BNDetails_LichSuThanhToan.Location.Y + label_BNDetails_LichSuThanhToan.Height / 2 + offset),
                                         new Point(label_BNDetails_LichSuThanhToan.Location.X, label_BNDetails_LichSuThanhToan.Location.Y + label_BNDetails_LichSuThanhToan.Height / 2 + offset)); //label_BNDetails_LichSuThanhToan line
            graphic.DrawLine(sectionPen, new Point(label_BNDetails_LichSuThanhToan.Location.X + label_BNDetails_LichSuThanhToan.Width, label_BNDetails_LichSuThanhToan.Location.Y + label_BNDetails_LichSuThanhToan.Height / 2 + offset),
                                         new Point(endX + offset, label_BNDetails_LichSuThanhToan.Location.Y + label_BNDetails_LichSuThanhToan.Height / 2 + offset)); //label_BNDetails_LichSuThanhToan line
        }

        private void panel_HSBADetails_Leave(object sender, EventArgs e)
        {
            toggle_HSBADetails_panel();
        }
    }
}
