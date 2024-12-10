using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyMachTu
{
    public partial class LichKhamControl : UserControl
    {
        //Bit errors
        //Upload textBox
        const int MALK_ERR = 1;
        const int MABN_ERR = 2;
        const int MAPK_ERR = 4;

        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatableLK;
        //Database connection
        private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        //Function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        int controlFunc;
        PageButton controlModeButton;
        DataTable controlDataTable;
        public LichKhamControl()
        {
            InitializeComponent();
        }
        private void LichKhamControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            controlDataTable = datatableLK;
            controlFunc = FIL_FUNC;
            controlModeButton = pageButton_LatestMode;

            panel_Filters.BringToFront();
            UpdateDataGridView(customDataGridView, datatableLK);
            ActivateButton(controlModeButton);
            customDataGridView.Focus();

            //Upload
            AutoFillUploadTextBox();

            //Filters
            comboBox_Filters_DateTimeComparer.SelectedIndex = 2;
        }
        //Activate / Deactivate tab
        private void ActivateButton(PageButton button)
        {
            ColoringButton.EnabledColor(button);
            DataTable result = GetLatestNews(4);
            UpdateDataGridView(customDataGridView, result);
        }
        private void DeactivateButton(PageButton button)
        {
            ColoringButton.DisabledColor(button);
        }
        //Load methods
        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();
            LoadTabLichKham();

            connection.Close();
        }
        private void LoadTabLichKham()
        {
            LoadDataToDataSet("SELECT * FROM LICHKHAM", "LICHKHAM");
            datatableLK = dataset.Tables["LICHKHAM"];
            datatableLK.PrimaryKey = new DataColumn[] { datatableLK.Columns["MaLK"] };
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
        }
        //Check and prevent errors        
        private int CheckUploadTextBox()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_Upload_MaBN.Text))
                error |= MABN_ERR;
            if (string.IsNullOrEmpty(textBox_Upload_MaPK.Text))
                error |= MAPK_ERR;

            return error;
        }
        private void WarningUploadTextBoxError(int error)
        {
            if ((error & MABN_ERR) == MABN_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaBN);
            if ((error & MAPK_ERR) == MAPK_ERR)
                ColoringTextBox.WarningColor(textBox_Upload_MaPK);
        }
        private void AutoFillUploadTextBox()
        {
            FillMaLK(textBox_Upload_MaLK);
            FillDate(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
            FillTime(textBox_Upload_Gio, textBox_Upload_Phut, textBox_Upload_Giay);
        }
        //Auto fill
        private void FillMaLK(TextBox textBox)
        {
            string MaLK = datatableLK.Rows[datatableLK.Rows.Count - 1]["MaLK"].ToString();
            MaLK = StringMath.Increment(MaLK);
            textBox.Text = MaLK;
        }
        private void FillDate(TextBox ngay, ComboBox thang, TextBox nam)
        {
            DateTime currentDate = DateTime.Now;
            ngay.Text = currentDate.Day.ToString("D2");
            thang.SelectedIndex = currentDate.Month - 1;
            nam.Text = currentDate.Year.ToString("D2");
        }
        private void FillTime(TextBox gio, TextBox phut, TextBox giay)
        {
            DateTime currentDate = DateTime.Now;
            gio.Text = currentDate.Hour.ToString("D2");
            phut.Text = currentDate.Minute.ToString("D2");
            giay.Text = currentDate.Second.ToString("D2");
        }
        //Upload button
        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            controlFunc = INS_FUNC;
            panel_Upload.BringToFront();
        }
        private void button_Upload_OK_Click(object sender, EventArgs e)
        {
            //check errors
            int error = CheckUploadTextBox();

            if (error != 0)
            {
                WarningUploadTextBoxError(error);
                return;
            }

            string primaryKey = textBox_Upload_MaLK.Text;
            DataRow targetRow = datatableLK.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatableLK.NewRow();
                targetRow["MaLK"] = primaryKey;
                targetRow["MaBN"] = textBox_Upload_MaBN.Text;
                targetRow["MaPK"] = textBox_Upload_MaPK.Text;
                targetRow["ThoiDiem"] = GetDateTime(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam, textBox_Upload_Gio, textBox_Upload_Phut, textBox_Upload_Giay);
                datatableLK.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaBN"] = textBox_Upload_MaBN.Text;
                targetRow["MaPK"] = textBox_Upload_MaPK.Text;
                targetRow["ThoiDiem"] = GetDateTime(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam, textBox_Upload_Gio, textBox_Upload_Phut, textBox_Upload_Giay);
            }

            UpdateDataGridView(customDataGridView, datatableLK);
        }
        //Filter button
        private void pageButton_Filters_Click(object sender, EventArgs e)
        {
            controlFunc = FIL_FUNC;
            panel_Filters.BringToFront();
        }
        private void pageButton_Filters_OK_Click(object sender, EventArgs e)
        {
            string selectCommand_LK = "1 = 1 ";

            //search with primary informations
            if (string.IsNullOrEmpty(textBox_Filters_MaLK.Text) == false)
                selectCommand_LK += $"AND MaLK = '{textBox_Filters_MaLK.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_MaBN.Text) == false)
                selectCommand_LK += $"AND MaBN = '{textBox_Filters_MaBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_MaPK.Text) == false)
                selectCommand_LK += $"AND MaPK = '{textBox_Filters_MaPK.Text}' ";

            string datetime = GetDateTime(textBox_Filters_Ngay, comboBox_Filters_Thang, textBox_Filters_Nam, textBox_Filters_Gio, textBox_Filters_Phut, textBox_Filters_Giay);
            string comparerDate = GetOperation(comboBox_Filters_DateTimeComparer);
            if (string.IsNullOrEmpty(datetime) == false)
                selectCommand_LK += $"AND ThoiDiem {comparerDate} '{datetime}' ";

            DataRow[] resultRow_LK = datatableLK.Select(selectCommand_LK);
            DataTable resultDatatable = datatableLK.Clone();

            foreach (DataRow row in resultRow_LK)
            {
                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
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
        //Paint
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            Color lineColor = Color.FromArgb(193, 193, 193);
            Graphics graphic = e.Graphics;

            Pen linePen = new Pen(lineColor, 1);
            int offset = 5;

            //Draw line of TextBox
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }

            //Draw vertical separator line
            int x = label_Filters_NgayLap.Location.X - 9;
            int startY = label_Filters_NgayLap.Location.Y, endY = startY + label_Filters_NgayLap.Height;
            graphic.DrawLine(linePen, new Point(x, startY), new Point(x, endY));
        }
        private void RepaintPanel(Panel panel)
        {
            panel.Invalidate();
        }
        //Additions
        private string GetDateTime(TextBox textBox_Ngay, ComboBox comboBox_Thang, TextBox textBox_Nam, TextBox textBox_Gio, TextBox textBox_Phut, TextBox textBox_Giay)
        {
            int day, year;
            int month = comboBox_Thang.SelectedIndex + 1;

            bool isDayRead = int.TryParse(textBox_Ngay.Text, out day);
            bool isYearRead = int.TryParse(textBox_Nam.Text, out year);

            if (!isDayRead)
                return null;
            else if (!isYearRead)
                return null;

            int maxDays = GetDaysOfMonth(month, year);

            if (day < 1 || day > maxDays)
                return null;

            int hour = int.Parse(textBox_Upload_Gio.Text);
            int minute = int.Parse(textBox_Upload_Phut.Text);
            int second = int.Parse(textBox_Upload_Giay.Text);

            DateTime datetime = new DateTime(year, month, day, hour, minute, second);

            return datetime.ToString("MM/dd/yyyy h:mm tt");
        }
        private int isLeapYear(int year)
        {
            return Convert.ToInt32(year % 4 == 0 && year % 100 != 0 || year % 400 == 0);
        }
        private int GetDaysOfMonth(int month, int year)
        {
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return 28 + isLeapYear(year);
                default:
                    return 30;
            }
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

        private DataTable GetLatestNews(int time_period_count)
        {
            DataView dataView = new DataView(datatableLK);
            dataView.Sort = "ThoiDiem";

            DataRow[] searchData = dataView.ToTable().Select();
            DataTable result = datatableLK.Clone();

            DataRow latestRow = null;

            int index = searchData.Length - 1;

            while (time_period_count > 0 && index > -1)
            {
                result.ImportRow(searchData[index]);

                if (latestRow == null || searchData[index].Field<DateTime>("ThoiDiem").Date != latestRow.Field<DateTime>("ThoiDiem").Date)
                    time_period_count--;

                latestRow = searchData[index];
                index--;
            }

            return result;
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

        //---------------------------------------------------------------Latest tab---------------------------------------------------------------        
        //Activate tab
        private void pageButton_LatestTab_Click(object sender, EventArgs e)
        {
            DeactivateButton(controlModeButton);
            controlModeButton = pageButton_LatestMode;
            ActivateButton(controlModeButton);

            DataTable result = GetLatestNews(4);
            UpdateDataGridView(customDataGridView, result);
            customDataGridView.Focus();
        }

        //---------------------------------------------------------------History tab---------------------------------------------------------------        
        //Activate tab
        private void pageButton_HistoryTab_Click(object sender, EventArgs e)
        {
            DeactivateButton(controlModeButton);
            controlModeButton = pageButton_HistoryMode;
            ActivateButton(controlModeButton);

            UpdateDataGridView(customDataGridView, datatableLK);
            customDataGridView.Focus();
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

            fillPanel(row);
        }

        private void fillPanel(DataRow row)
        {
            DateTime datetime;

            switch (controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaLK.Text = row["MaLK"].ToString();
                    textBox_Upload_MaBN.Text = row["MaBN"].ToString();
                    textBox_Upload_MaPK.Text = row["MaPK"].ToString();

                    datetime = row.Field<DateTime>("ThoiDiem");
                    textBox_Upload_Ngay.Text = datetime.Day.ToString();
                    comboBox_Upload_Thang.SelectedIndex = datetime.Month - 1;
                    textBox_Upload_Nam.Text = datetime.Year.ToString();

                    textBox_Upload_Gio.Text = datetime.Hour.ToString("D2");
                    textBox_Upload_Phut.Text = datetime.Minute.ToString("D2");
                    textBox_Upload_Giay.Text = datetime.Second.ToString("D2");

                    break;
                case FIL_FUNC:
                    textBox_Filters_MaLK.Text = row["MaLK"].ToString();
                    textBox_Filters_MaBN.Text = row["MaBN"].ToString();
                    textBox_Filters_MaPK.Text = row["MaPK"].ToString();

                    datetime = row.Field<DateTime>("ThoiDiem");
                    textBox_Filters_Ngay.Text = datetime.Day.ToString();
                    comboBox_Filters_Thang.SelectedIndex = datetime.Month - 1;
                    textBox_Filters_Nam.Text = datetime.Year.ToString();

                    textBox_Filters_Gio.Text = datetime.Hour.ToString("D2");
                    textBox_Filters_Phut.Text = datetime.Minute.ToString("D2");
                    textBox_Filters_Giay.Text = datetime.Second.ToString("D2");
                    break;
            }
        }

        private void button_Filters_Reset_Paint(object sender, PaintEventArgs e)
        {
            Button clickedButton = sender as Button;
            Panel containingPanel = clickedButton.Parent as Panel;

            foreach (Control control in containingPanel.Controls)
                if (control is TextBox textBox)
                    textBox.Text = "";

            comboBox_Filters_Thang.SelectedIndex = 0;
            comboBox_Filters_DateTimeComparer.SelectedIndex = 2;
        }

        private void button_Upload_Reset_Click(object sender, EventArgs e)
        {
            textBox_Upload_MaBN.Text = "";
            textBox_Upload_MaPK.Text = "";

            AutoFillUploadTextBox();
        }
    }
}
