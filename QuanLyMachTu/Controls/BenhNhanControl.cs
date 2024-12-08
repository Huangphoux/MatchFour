using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using QuanLyMachTu.Helper;

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

        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatableBN;
        private DataTable datatableHSBA;
        private DataTable datatableTK;
        //Database connection
        private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        //Control variables
        //tab index
        const int BN_TAB = 0;
        const int HSBA_TAB = 10;
        const int TK_TAB = 20;
        //function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        int controlPage;
        int BN_ControlFunc;
        int HSBA_ControlFunc;
        int TK_ControlFunc;
        DataTable controlDataTable;

        //System methods
        public BenhNhanControl()
        {
            InitializeComponent();
        }
        private void BenhNhanControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            controlPage = BN_TAB;
            controlDataTable = datatableBN;

            BN_ControlFunc = FIL_FUNC;
            HSBA_ControlFunc = FIL_FUNC;
            TK_ControlFunc = FIL_FUNC;

            EnablePage(controlPage);
        }
        //Activate / Deactivate tab
        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case BN_TAB:
                    controlDataTable = datatableBN;
                    ColoringButton.EnabledColor(pageButton_BNTab);
                    enableFunc_BN();
                    break;
                case HSBA_TAB:
                    controlDataTable = datatableHSBA;
                    ColoringButton.EnabledColor(pageButton_HSBATab);
                    enableFunc_HSBA();                    
                    break;
                case TK_TAB:
                    controlDataTable = datatableTK;
                    ColoringButton.EnabledColor(pageButton_TKTab);
                    enableFunc_TK();                    
                    break;
            }

            UpdateDataGridView(customDataGridView, controlDataTable);
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
        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();
            LoadTabBenhNhan();
            LoadTabHoSoBenhAn();
            LoadTabTaiKhoan();

            connection.Close();
        }
        private void LoadDataToDataSet(string commandStr, string tableName)
        {
            adapter = new SqlDataAdapter(commandStr, connection);
            adapter.Fill(dataset, tableName);
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
        //Additions
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
        private void Button_KeyPress_PositiveNumber(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                ColoringTextBox.NormalColor((TextBox)sender);
            }
            else
                e.Handled = true;
        }
        private void button_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            ColoringTextBox.NormalColor((TextBox)sender);
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
        }
        private void enableFunc_BN()
        {
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
            LoadDataToDataSet("SELECT * FROM BENHNHAN", "BENHNHAN");
            datatableBN = dataset.Tables["BENHNHAN"];
            datatableBN.PrimaryKey = new DataColumn[] { datatableBN.Columns["MaBN"] };

            //Upload
            comboBox_BNUpload_Thang.SelectedItem = comboBox_BNUpload_Thang.Items[0];
            FillMaBN(textBox_BNUpload_MaBN);
            FillDate(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
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
            string mabn = datatableBN.Rows[datatableBN.Rows.Count - 1]["MaBN"].ToString();
            mabn = StringMath.Increment(mabn);
            maBN.Text = mabn;
        }
        private void FillDate(TextBox ngay, ComboBox thang, TextBox nam)
        {
            DateTime currentDate = DateTime.Now;
            ngay.Text = currentDate.Day.ToString("D2");
            thang.SelectedIndex = currentDate.Month - 1;
            nam.Text = currentDate.Year.ToString("D2");
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
            DataRow targetRow = datatableBN.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatableBN.NewRow();
                targetRow["MaBN"] = primaryKey;
                targetRow["HoTenBN"] = textBox_BNUpload_TenBN.Text;
                targetRow["GioiTinh"] = GetGioiTinh(checkBox_BNUpload_Nam, checkBox_BNUpload_Nu);
                targetRow["NgaySinh"] = GetNgayThangNam(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
                targetRow["Email"] = textBox_BNUpload_Email.Text;
                targetRow["SDT"] = textBox_BNUpload_SDT.Text;
                datatableBN.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaBN"] = primaryKey;
                targetRow["HoTenBN"] = textBox_BNUpload_TenBN.Text;
                targetRow["GioiTinh"] = GetGioiTinh(checkBox_BNUpload_Nam, checkBox_BNUpload_Nu);
                targetRow["NgaySinh"] = GetNgayThangNam(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
                targetRow["Email"] = textBox_BNUpload_Email.Text;
                targetRow["SDT"] = textBox_BNUpload_SDT.Text;
            }

            UpdateDataGridView(customDataGridView, datatableBN);
        }
        //Filter method
        private void button_BNFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "1 = 1 ";

            //Find exact row
            if (string.IsNullOrEmpty(textBox_Filters_MaBN.Text) == false)
                selectCommand += $"AND MaBN = '{textBox_Filters_MaBN.Text}' ";
            else if (string.IsNullOrEmpty(textBox_Filters_MaHSBA.Text) == false)
            {
                DataRow[] foundRows = datatableHSBA.Select($"MaHSBA = '{textBox_Filters_MaHSBA.Text}'");

                if (foundRows.Length == 0)
                    selectCommand += $"AND MaBN = NULL ";
                else
                    selectCommand += $"AND MaBN = '{foundRows[0]["MaBN"]}' ";
            }
            else if (string.IsNullOrEmpty(textBox_Filters_MaTK.Text) == false)
            {
                DataRow? foundRow = datatableTK.Rows.Find(textBox_Filters_MaTK.Text);

                selectCommand += $"AND MaBN = '{foundRow["MaBN"]}' ";
            }

            //Another informations
            if (string.IsNullOrEmpty(textBox_Filters_TenBN.Text) == false)
                selectCommand += $"AND HoTenBN = '{textBox_Filters_TenBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_Email.Text) == false)
                selectCommand += $"AND Email = '{textBox_Filters_Email.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_SDT.Text) == false)
                selectCommand += $"AND SDT = '{textBox_Filters_SDT.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_DoanhSo.Text) == false)
                selectCommand += $"AND DoanhSo >= {textBox_Filters_DoanhSo.Text} ";

            DataRow[] resultRow = datatableBN.Select(selectCommand);
            DataTable resultDatatable = datatableBN.Clone();

            foreach (DataRow row in resultRow)
            {
                if (resultDatatable.Rows.Contains(row["MaBN"]))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
        }
        //Additional
        private void textBox_BNDate_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
                FillDate(textBox_BNUpload_Ngay, comboBox_BNUpload_Thang, textBox_BNUpload_Nam);
        }
        //Decorate panel
        private void panel_BNUpload_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(linePen, new Point(startX, textBox_BNUpload_MaBN.Location.Y + textBox_BNUpload_MaBN.Height + offset),
                                      new Point(endX, textBox_BNUpload_MaBN.Location.Y + textBox_BNUpload_MaBN.Height + offset)); //MaBN line
            graphic.DrawLine(linePen, new Point(startX, textBox_BNUpload_TenBN.Location.Y + textBox_BNUpload_TenBN.Height + offset),
                                      new Point(endX, textBox_BNUpload_TenBN.Location.Y + textBox_BNUpload_TenBN.Height + offset)); //TenBN line
            graphic.DrawLine(linePen, new Point(startX, textBox_BNUpload_Ngay.Location.Y + textBox_BNUpload_Ngay.Height + offset),
                                      new Point(textBox_BNUpload_Ngay.Location.X + textBox_BNUpload_Ngay.Width + offset, textBox_BNUpload_Ngay.Location.Y + textBox_BNUpload_Ngay.Height + offset)); //Ngay line
            graphic.DrawLine(linePen, new Point(textBox_BNUpload_Nam.Location.X - offset, textBox_BNUpload_Nam.Location.Y + textBox_BNUpload_Nam.Height + offset),
                                      new Point(textBox_BNUpload_Nam.Location.X + textBox_BNUpload_Nam.Width + offset, textBox_BNUpload_Nam.Location.Y + textBox_BNUpload_Nam.Height + offset)); //Nam line
            graphic.DrawLine(linePen, new Point(startX, textBox_BNUpload_SDT.Location.Y + textBox_BNUpload_SDT.Height + offset),
                                      new Point(textBox_BNUpload_SDT.Location.X + textBox_BNUpload_SDT.Width + offset, textBox_BNUpload_SDT.Location.Y + textBox_BNUpload_SDT.Height + offset)); //SDL line
            graphic.DrawLine(linePen, new Point(startX, textBox_BNUpload_Email.Location.Y + textBox_BNUpload_Email.Height + offset),
                                      new Point(endX, textBox_BNUpload_Email.Location.Y + textBox_BNUpload_Email.Height + offset)); //Email line
        }
        private void panel_BNFilter_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395;
            graphic.DrawLine(linePen, new Point(startX, 165), new Point(135, 165)); //MaBN line
            graphic.DrawLine(linePen, new Point(145, 165), new Point(265, 165)); //MaHSBA line
            graphic.DrawLine(linePen, new Point(275, 165), new Point(endX, 165)); //MaTK line
            graphic.DrawLine(linePen, new Point(startX, 264), new Point(endX, 264)); //TenBN line
            graphic.DrawLine(linePen, new Point(startX, 363), new Point(endX, 363)); //Email line
            graphic.DrawLine(linePen, new Point(startX, 462), new Point(endX, 462)); //SDL line
            graphic.DrawLine(linePen, new Point(startX, 561), new Point(352, 561)); //DoanhSo line
        }

        //-------------------------------------------------------------Ho So Benh An tab-------------------------------------------------------------        
        //Activate tab
        private void pageButton_HSBATab_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = HSBA_TAB;
            EnablePage(controlPage);
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
            LoadDataToDataSet("SELECT * FROM HOSOBENHAN", "HOSOBENHAN");
            datatableHSBA = dataset.Tables["HOSOBENHAN"];
            datatableHSBA.PrimaryKey = new DataColumn[] { datatableHSBA.Columns["MaHSBA"], datatableHSBA.Columns["NgayLap"] };

            //Upload
            FillDate(textBox_HSBAUpload_Ngay, comboBox_HSBAUpload_Thang, textBox_HSBAUpload_Nam);

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
            string primaryKey1 = textBox_HSBAUpload_MaHSBA.Text;
            string primaryKey2 = GetNgayThangNam(textBox_HSBAUpload_Ngay, comboBox_HSBAUpload_Thang, textBox_HSBAUpload_Nam);
            DataRow targetRow = datatableHSBA.Rows.Find(new string[] { primaryKey1, primaryKey2 });

            if (targetRow == null) // Insert
            {
                //auto fill
                if (string.IsNullOrEmpty(primaryKey1)) //auto fill MaHSBA
                {
                    string maBN = textBox_HSBAUpload_MaBN.Text;
                    DataRow row = datatableBN.Rows.Find(maBN);
                    if (row == null) //find patient HSBA
                    {
                        return;
                    }
                    DataRow[] rows = datatableHSBA.Select($"MaBN = '{maBN}'");
                    if (rows.Length > 0)
                    {
                        row = rows[0];
                        primaryKey1 = row["MaHSBA"].ToString();
                        textBox_HSBAUpload_MaHSBA.Text = primaryKey1;
                    }
                    else
                    {
                        row = datatableHSBA.Rows[datatableHSBA.Rows.Count - 1];
                        string maHSBA = row["MaHSBA"].ToString();
                        maHSBA = StringMath.Increment(maHSBA);
                        primaryKey1 = maHSBA;
                        textBox_HSBAUpload_MaHSBA.Text = primaryKey1;
                    }
                }

                if (string.IsNullOrEmpty(primaryKey2)) //auto fill NgayLap
                {
                    primaryKey2 = DateTime.Today.ToString();
                }

                targetRow = datatableHSBA.NewRow();
                targetRow["MaHSBA"] = primaryKey1;
                targetRow["NgayLap"] = primaryKey2;
                targetRow["KetQuaTongQuat"] = textBox_HSBAUpload_KetQuaTQ.Text;
                targetRow["MaBN"] = textBox_HSBAUpload_MaBN.Text;
                targetRow["MaNV"] = textBox_HSBAUpload_MaNV.Text;
                datatableHSBA.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaHSBA"] = primaryKey1;
                targetRow["NgayLap"] = primaryKey2;
                targetRow["KetQuaTongQuat"] = textBox_HSBAUpload_KetQuaTQ.Text;
                targetRow["MaBN"] = textBox_HSBAUpload_MaBN.Text;
                targetRow["MaNV"] = textBox_HSBAUpload_MaNV.Text;
            }

            UpdateDataGridView(customDataGridView, datatableHSBA);
        }
        //Filter method
        private void button_HSBAFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand_HSBA = "1 = 1 ";
            string selectCommand_BN = "1 = 1 ";

            //make a select command
            if (string.IsNullOrEmpty(textBox_HSBAFilter_MaBN.Text) == false)
                selectCommand_HSBA += $"AND MaBN = '{textBox_HSBAFilter_MaBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_HSBAFilter_MaHSBA.Text) == false)
                selectCommand_HSBA += $"AND MaHSBA = '{textBox_HSBAFilter_MaHSBA.Text}' ";
            string ngayLap = GetNgayThangNam(textBox_HSBAFilter_Ngay, comboBox_HSBAFilter_Thang, textBox_HSBAFilter_Nam);
            string operation = GetOperation(comboBox_HSBAFilter_Operation);
            if (string.IsNullOrEmpty(ngayLap) == false)
                selectCommand_HSBA += $"AND NgayLap {operation} '{ngayLap}' ";

            if (string.IsNullOrEmpty(textBox_HSBAFilter_Email.Text) == false)
                selectCommand_BN += $"AND Email = '{textBox_HSBAFilter_Email.Text}' ";
            if (string.IsNullOrEmpty(textBox_HSBAFilter_SDT.Text) == false)
                selectCommand_BN += $"AND SDT = '{textBox_HSBAFilter_SDT.Text}' ";

            DataRow[] resultRow_HSBA = datatableHSBA.Select(selectCommand_HSBA);
            DataRow[] resultRow_BN = datatableBN.Select(selectCommand_BN);
            List<DataRow> result = new List<DataRow>();

            foreach (DataRow row_HSBA in resultRow_HSBA)
            {
                foreach (DataRow row_BN in resultRow_BN)
                {
                    if (row_HSBA["MaBN"].ToString() == row_BN["MaBN"].ToString())
                    {
                        result.Add(row_HSBA);
                        break;
                    }
                }
            }

            string[] primaryKey = new string[2];
            DataTable resultDatatable = datatableHSBA.Clone();

            foreach (DataRow row in result)
            {
                primaryKey[0] = row["MaHSBA"].ToString();
                primaryKey[1] = row["NgayLap"].ToString();
                if (resultDatatable.Rows.Contains(primaryKey))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
        }
        //Additional
        private void textBox_HSBADate_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
                FillDate(textBox_HSBAUpload_Ngay, comboBox_HSBAUpload_Thang, textBox_HSBAUpload_Nam);
        }
        private void textBox_Autofind_MaHSBA_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string findingInformation = textBox.Text;
            string command = $"MaBN = '{findingInformation}'";
            DataRow[] result = datatableHSBA.Select(command);

            if (result.Length > 0)
                textBox_HSBAUpload_MaHSBA.Text = result[0]["MaHSBA"].ToString();
        }

        private void textBox_Autofind_MaBNfromMaHSBA_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string findingInformation = textBox.Text;
            string command = $"MaHSBA = '{findingInformation}'";
            DataRow[] result = datatableHSBA.Select(command);

            if (result.Length > 0)
                textBox_HSBAUpload_MaBN.Text = result[0]["MaBN"].ToString();
        }
        //Decorate panel
        private void panel_HSBAUpload_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395, offset = 5;

            graphic.DrawLine(linePen, new Point(startX, textBox_HSBAUpload_MaBN.Location.Y + textBox_HSBAUpload_MaBN.Height + offset),
                                      new Point(textBox_HSBAUpload_MaBN.Location.X + textBox_HSBAUpload_MaBN.Width + offset, textBox_HSBAUpload_MaBN.Location.Y + textBox_HSBAUpload_MaBN.Height + offset)); //MaBN line
            graphic.DrawLine(linePen, new Point(textBox_HSBAUpload_MaHSBA.Location.X - offset, textBox_HSBAUpload_MaHSBA.Location.Y + textBox_HSBAUpload_MaHSBA.Height + offset),
                                      new Point(endX, textBox_HSBAUpload_MaHSBA.Location.Y + textBox_HSBAUpload_MaHSBA.Height + offset)); //MaHSBA line
            graphic.DrawLine(linePen, new Point(startX, textBox_HSBAUpload_MaNV.Location.Y + textBox_HSBAUpload_MaNV.Height + offset),
                                      new Point(endX, textBox_HSBAUpload_MaNV.Location.Y + textBox_HSBAUpload_MaNV.Height + offset)); //MaNV line
            graphic.DrawLine(linePen, new Point(startX, textBox_HSBAUpload_Ngay.Location.Y + textBox_HSBAUpload_Ngay.Height + offset),
                                      new Point(textBox_HSBAUpload_Ngay.Location.X + textBox_HSBAUpload_Ngay.Width + offset, textBox_HSBAUpload_Ngay.Location.Y + textBox_HSBAUpload_Ngay.Height + offset)); //Ngay line
            graphic.DrawLine(linePen, new Point(textBox_HSBAUpload_Nam.Location.X - offset, textBox_HSBAUpload_Nam.Location.Y + textBox_HSBAUpload_Nam.Height + offset),
                                      new Point(textBox_HSBAUpload_Nam.Location.X + textBox_HSBAUpload_Nam.Width + offset, textBox_HSBAUpload_Nam.Location.Y + textBox_HSBAUpload_Nam.Height + offset)); //Nam line

            int x = label_HSBAUpload_NgayLap.Location.X - 9;
            int startY = label_HSBAUpload_NgayLap.Location.Y, endY = startY + label_HSBAUpload_NgayLap.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }
        private void panel_HSBAFilter_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395, offset = 5;

            graphic.DrawLine(linePen, new Point(startX, textBox_HSBAFilter_MaBN.Location.Y + textBox_HSBAFilter_MaBN.Height + offset),
                                     new Point(textBox_HSBAFilter_MaBN.Location.X + textBox_HSBAFilter_MaBN.Width + offset, textBox_HSBAFilter_MaBN.Location.Y + textBox_HSBAFilter_MaBN.Height + offset)); //MaBN line
            graphic.DrawLine(linePen, new Point(textBox_HSBAFilter_MaHSBA.Location.X - offset, textBox_HSBAFilter_MaHSBA.Location.Y + textBox_HSBAFilter_MaHSBA.Height + offset),
                                      new Point(endX, textBox_HSBAFilter_MaHSBA.Location.Y + textBox_HSBAFilter_MaHSBA.Height + offset)); //MaHSBA line
            graphic.DrawLine(linePen, new Point(startX, textBox_HSBAFilter_SDT.Location.Y + textBox_HSBAFilter_SDT.Height + offset),
                                      new Point(endX, textBox_HSBAFilter_SDT.Location.Y + textBox_HSBAFilter_SDT.Height + offset)); //SDT line
            graphic.DrawLine(linePen, new Point(startX, textBox_HSBAFilter_Email.Location.Y + textBox_HSBAFilter_Email.Height + offset),
                                      new Point(endX, textBox_HSBAFilter_Email.Location.Y + textBox_HSBAFilter_Email.Height + offset)); //Email line
            graphic.DrawLine(linePen, new Point(startX, textBox_HSBAFilter_Ngay.Location.Y + textBox_HSBAFilter_Ngay.Height + offset),
                                      new Point(textBox_HSBAFilter_Ngay.Location.X + textBox_HSBAFilter_Ngay.Width + offset, textBox_HSBAFilter_Ngay.Location.Y + textBox_HSBAFilter_Ngay.Height + offset)); //Ngay line
            graphic.DrawLine(linePen, new Point(textBox_HSBAFilter_Nam.Location.X - offset, textBox_HSBAFilter_Nam.Location.Y + textBox_HSBAFilter_Nam.Height + offset),
                                      new Point(textBox_HSBAFilter_Nam.Location.X + textBox_HSBAFilter_Nam.Width + offset, textBox_HSBAFilter_Nam.Location.Y + textBox_HSBAFilter_Nam.Height + offset)); //Nam line

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
            LoadDataToDataSet("SELECT * FROM TAIKHOAN", "TAIKHOAN");
            datatableTK = dataset.Tables["TAIKHOAN"];
            datatableTK.PrimaryKey = new DataColumn[] { datatableTK.Columns["MaTK"] };

            //Upload
            Autofill_MaTK(textBox_TKUpload_MaTK);

            //Filters
            comboBox_TKFilter_Thang.SelectedItem = comboBox_TKFilter_Thang.Items[0];
            comboBox_TKFilter_Operation.SelectedItem = comboBox_TKFilter_Operation.Items[0];
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
            string matk = datatableTK.Rows[datatableTK.Rows.Count - 1]["MaTK"].ToString();
            matk = StringMath.Increment(matk);
            textBox.Text = matk;
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
            DataRow targetRow = datatableTK.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatableTK.NewRow();
                targetRow["MaTK"] = primaryKey;
                targetRow["TenTK"] = textBox_TKUpload_TenTK.Text;
                targetRow["MatKhau"] = textBox_TKUpload_MatKhau.Text;
                targetRow["SDT"] = textBox_TKUpload_SDT.Text;
                targetRow["Email"] = textBox_TKUpload_Email.Text;
                targetRow["MaBN"] = textBox_TKUpload_MaBN.Text;
                targetRow["NgayLap"] = DateTime.Now.ToString("MM/dd/yyyy");
                datatableTK.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["TenTK"] = textBox_TKUpload_TenTK.Text;
                targetRow["MatKhau"] = textBox_TKUpload_MatKhau.Text;
                targetRow["SDT"] = textBox_TKUpload_SDT.Text;
                targetRow["Email"] = textBox_TKUpload_Email.Text;
                targetRow["MaBN"] = textBox_TKUpload_MaBN.Text;
            }

            UpdateDataGridView(customDataGridView, datatableTK);
        }
        //Filter method
        private void button_TKFilter_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "1 = 1 ";

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
            string ngayLap = GetNgayThangNam(textBox_TKFilter_Ngay, comboBox_TKFilter_Thang, textBox_TKFilter_Nam);
            string operation = GetOperation(comboBox_TKFilter_Operation);
            if (string.IsNullOrEmpty(ngayLap) == false)
                selectCommand += $"AND NgayLap {operation} '{ngayLap}' ";

            DataRow[] resultRow = datatableTK.Select(selectCommand);

            string primaryKey;
            DataTable resultDatatable = datatableTK.Clone();

            foreach (DataRow row in resultRow)
            {
                primaryKey = row["MaTK"].ToString();
                if (resultDatatable.Rows.Contains(primaryKey))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
        }
        //Additional
        private void textBox_MaTK_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
                Autofill_MaTK(textBox);
        }

        private void textBox_Autofind_MaBNfromMaTK_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string findingInformation = textBox.Text;
            string command = $"MaTK = '{findingInformation}'";
            DataRow[] result = datatableTK.Select(command);

            if (result.Length > 0)
                textBox_TKUpload_MaBN.Text = result[0]["MaBN"].ToString();
        }

        private void textBox_Autofind_MaTKfromMaBN_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string findingInformation = textBox.Text;
            string command = $"MaBN = '{findingInformation}'";
            DataRow[] result = datatableTK.Select(command);

            if (result.Length > 0)
                textBox_TKUpload_MaTK.Text = result[0]["MaTK"].ToString();
        }
        //Decorate panel
        private void panel_TKFilter_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395, offset = 5;
            graphic.DrawLine(linePen, new Point(startX, textBox_TKFilter_MaBN.Location.Y + textBox_TKFilter_MaBN.Height + offset),
                                      new Point(textBox_TKFilter_MaBN.Location.X + textBox_TKFilter_MaBN.Width + offset, textBox_TKFilter_MaBN.Location.Y + textBox_TKFilter_MaBN.Height + offset)); //MaBN line
            graphic.DrawLine(linePen, new Point(textBox_TKFilter_MaTK.Location.X - offset, textBox_TKFilter_MaTK.Location.Y + textBox_TKFilter_MaTK.Height + offset),
                                      new Point(endX, textBox_TKFilter_MaTK.Location.Y + textBox_TKFilter_MaTK.Height + offset)); //MaTK line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKFilter_TenTK.Location.Y + textBox_TKFilter_TenTK.Height + offset),
                                      new Point(endX, textBox_TKFilter_TenTK.Location.Y + textBox_TKFilter_TenTK.Height + offset)); //TenTK line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKFilter_SDT.Location.Y + textBox_TKFilter_SDT.Height + offset),
                                      new Point(endX, textBox_TKFilter_SDT.Location.Y + textBox_TKFilter_SDT.Height + offset)); //SDT line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKFilter_Email.Location.Y + textBox_TKFilter_Email.Height + offset),
                                      new Point(endX, textBox_TKFilter_Email.Location.Y + textBox_TKFilter_Email.Height + offset)); //Email line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKFilter_Ngay.Location.Y + textBox_TKFilter_Ngay.Height + offset),
                                      new Point(textBox_TKFilter_Ngay.Location.X + textBox_TKFilter_Ngay.Width + offset, textBox_TKFilter_Ngay.Location.Y + textBox_TKFilter_Ngay.Height + offset)); //Ngay line
            graphic.DrawLine(linePen, new Point(textBox_TKFilter_Nam.Location.X - offset, textBox_TKFilter_Nam.Location.Y + textBox_TKFilter_Nam.Height + offset),
                                      new Point(textBox_TKFilter_Nam.Location.X + textBox_TKFilter_Nam.Width + offset, textBox_TKFilter_Nam.Location.Y + textBox_TKFilter_Nam.Height + offset)); //Nam line

            int x = label_TKFilters_NgayTao.Location.X - 9;
            int startY = label_TKFilters_NgayTao.Location.Y, endY = startY + label_TKFilters_NgayTao.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }
        private void panel_TKUpload_Paint(object sender, PaintEventArgs e)
        {
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int startX = 20, endX = 395, offset = 5;

            graphic.DrawLine(linePen, new Point(startX, textBox_TKUpload_MaBN.Location.Y + textBox_TKUpload_MaBN.Height + offset),
                                      new Point(textBox_TKUpload_MaBN.Location.X + textBox_TKUpload_MaBN.Width + offset, textBox_TKUpload_MaBN.Location.Y + textBox_TKUpload_MaBN.Height + offset)); //MaBN line
            graphic.DrawLine(linePen, new Point(textBox_TKUpload_MaTK.Location.X - offset, textBox_TKUpload_MaTK.Location.Y + textBox_TKUpload_MaTK.Height + offset),
                                      new Point(endX, textBox_TKUpload_MaTK.Location.Y + textBox_TKUpload_MaTK.Height + offset)); //MaTK line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKUpload_TenTK.Location.Y + textBox_TKUpload_TenTK.Height + offset),
                                      new Point(endX, textBox_TKUpload_TenTK.Location.Y + textBox_TKUpload_TenTK.Height + offset)); //TenTK line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKUpload_MatKhau.Location.Y + textBox_TKUpload_MatKhau.Height + offset),
                                      new Point(endX, textBox_TKUpload_MatKhau.Location.Y + textBox_TKUpload_MatKhau.Height + offset)); //MatKhau line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKUpload_SDT.Location.Y + textBox_TKUpload_SDT.Height + offset),
                                      new Point(endX, textBox_TKUpload_SDT.Location.Y + textBox_TKUpload_SDT.Height + offset)); //SDL line
            graphic.DrawLine(linePen, new Point(startX, textBox_TKUpload_Email.Location.Y + textBox_TKUpload_Email.Height + offset),
                                      new Point(endX, textBox_TKUpload_Email.Location.Y + textBox_TKUpload_Email.Height + offset)); //Email line
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
    }
}
