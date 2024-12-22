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
        private string LK_SelectCommand = "SELECT * FROM LICHKHAM ";
        private string Latest_Filters = "WHERE ThoiDiem IN (SELECT DISTINCT TOP 4 ThoiDiem " +
                                                                 "FROM LICHKHAM " +
                                                                 "ORDER BY ThoiDiem DESC) ";
        private string order = "ORDER BY ThoiDiem DESC";
        private string History_Filters = "WHERE 1 = 1 ";
        private string selectLastID = "SELECT TOP 1 MaLK FROM LICHKHAM ORDER BY MaLK DESC ";
        //Mode
        const int HIS_MODE = 1;
        const int LATEST_MODE = 2;
        //Function index
        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;
        //controllers
        //control primary key
        string next_LK_PrimaryKey;
        int controlMode;
        string controlCommand;
        int controlFunc;
        PageButton controlModeButton;

        public LichKhamControl()
        {
            InitializeComponent();
        }
        private void LichKhamControl_Load(object sender, EventArgs e)
        {
            InitializeState();
        }
        //General methods
        //Initialize methods
        private void InitializeState()
        {
            //Prefetch
            next_LK_PrimaryKey = (string)DatabaseConnection.ExecuteScalar(selectLastID, null);
            next_LK_PrimaryKey = StringMath.Increment(next_LK_PrimaryKey);

            //State
            controlMode = LATEST_MODE;
            controlCommand = LK_SelectCommand + Latest_Filters + order;
            controlFunc = FIL_FUNC;
            controlModeButton = pageButton_LatestMode;

            panel_Filters.BringToFront();
            ColoringButton.EnabledColor(controlModeButton);
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));

            //Upload
            AutoFillUploadTextBox();
            comboBox_Upload_TinhTrang.SelectedIndex = 0;

            //Filters
            comboBox_Filters_DateTimeComparer.SelectedIndex = 2;
        }
        //Load page
        private void LoadPage(int controlMode)
        {
            switch (controlMode)
            {
                case HIS_MODE:
                    controlCommand = LK_SelectCommand;
                    break;
                case LATEST_MODE:
                    controlCommand = LK_SelectCommand + Latest_Filters + order;
                    break;
            }
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Reload data
        private void UpdateDataGridView(DataGridView dgv, DataTable datatable)
        {
            //Load data to data grid view
            dgv.DataSource = datatable;

            int count = dgv.RowCount;
            int countToday = 0;

            foreach(DataGridViewRow row in dgv.Rows)
                if (row.Cells["ThoiDiem"].Value is DateTime date)
                    if (date.Date == DateTime.Today)
                        countToday++;

            label_TongSoLichKham_Number.Text = count.ToString();
            label_SoLKHomNay_Number.Text = countToday.ToString();
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
            GeneralMethods.FillDate(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam);
            GeneralMethods.FillTime(textBox_Upload_Gio, textBox_Upload_Phut, textBox_Upload_Giay);
        }
        //Auto fill
        private void FillMaLK(TextBox textBox)
        {
            textBox.Text = next_LK_PrimaryKey;
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

            string checkQuery = "IF EXISTS (SELECT 1 FROM LICHKHAM WHERE MaLK = @MaLK) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaLK", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO LICHKHAM " +
                                     "VALUES(@MaLK, @ThoiDiem, @MaBN, @MaPK, @TinhTrang)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaLK", primaryKey},
                    {"@ThoiDiem", GeneralMethods.GetDateTime(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam, textBox_Upload_Gio, textBox_Upload_Phut, textBox_Upload_Giay) },
                    {"@MaBN", textBox_Upload_MaBN.Text },
                    {"@MaPK", textBox_Upload_MaPK.Text },
                    {"@TinhTrang", comboBox_Upload_TinhTrang.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

                next_LK_PrimaryKey = StringMath.Increment(next_LK_PrimaryKey);
            }
            else
            {
                string updateQuery = "UPDATE LICHKHAM " +
                                        "SET ThoiDiem = @ThoiDiem, " +
                                            "MaBN = @MaBN, " +
                                            "MaPK = @MaPK, " +
                                            "TinhTrang = @TinhTrang " +
                                        "WHERE MaLK = @MaLK";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaLK", primaryKey},
                    {"@ThoiDiem", GeneralMethods.GetDateTime(textBox_Upload_Ngay, comboBox_Upload_Thang, textBox_Upload_Nam, textBox_Upload_Gio, textBox_Upload_Phut, textBox_Upload_Giay) },
                    {"@MaBN", textBox_Upload_MaBN.Text },
                    {"@MaPK", textBox_Upload_MaPK.Text },
                    {"@TinhTrang", comboBox_Upload_TinhTrang.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Filter button
        private void pageButton_Filters_Click(object sender, EventArgs e)
        {
            controlFunc = FIL_FUNC;
            panel_Filters.BringToFront();
        }
        private void pageButton_Filters_OK_Click(object sender, EventArgs e)
        {
            switch (controlMode)
            {
                case LATEST_MODE:
                    controlCommand = LK_SelectCommand + Latest_Filters;
                    ApplyFilter(ref controlCommand);
                    controlCommand += order;
                    break;
                case HIS_MODE:
                    controlCommand = LK_SelectCommand + History_Filters;
                    ApplyFilter(ref controlCommand);
                    break;
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void ApplyFilter(ref string selectCommand)
        {
            if (string.IsNullOrEmpty(textBox_Filters_MaLK.Text) == false)
                selectCommand += $"AND MaLK = '{textBox_Filters_MaLK.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_MaBN.Text) == false)
                selectCommand += $"AND MaBN = '{textBox_Filters_MaBN.Text}' ";
            if (string.IsNullOrEmpty(textBox_Filters_MaPK.Text) == false)
                selectCommand += $"AND MaPK = '{textBox_Filters_MaPK.Text}' ";

            string datetime = GeneralMethods.GetDateTime(textBox_Filters_Ngay, comboBox_Filters_Thang, textBox_Filters_Nam, textBox_Filters_Gio, textBox_Filters_Phut, textBox_Filters_Giay);
            string comparerDate = GeneralMethods.GetOperation(comboBox_Filters_DateTimeComparer);
            if (string.IsNullOrEmpty(datetime) == false)
                selectCommand += $"AND ThoiDiem {comparerDate} '{datetime}' ";
        }
        //Remove button
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
                parameter = $"@MaLK{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaLK"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "DELETE FROM LICHKHAM " +
                                   "WHERE MaLK IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew            
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
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
            ColoringButton.DisabledColor(controlModeButton);
            controlMode = LATEST_MODE;
            controlModeButton = pageButton_LatestMode;
            ColoringButton.EnabledColor(controlModeButton);
            LoadPage(controlMode);
        }

        //---------------------------------------------------------------History tab---------------------------------------------------------------        
        //Activate tab
        private void pageButton_HistoryTab_Click(object sender, EventArgs e)
        {
            ColoringButton.DisabledColor(controlModeButton);
            controlMode = HIS_MODE;
            controlModeButton = pageButton_HistoryMode;
            ColoringButton.EnabledColor(controlModeButton);
            LoadPage(controlMode);
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
            DateTime datetime = row.Field<DateTime>("ThoiDiem");

            switch (controlFunc)
            {
                case INS_FUNC:
                    textBox_Upload_MaLK.Text = row["MaLK"].ToString();
                    textBox_Upload_MaBN.Text = row["MaBN"].ToString();
                    textBox_Upload_MaPK.Text = row["MaPK"].ToString();
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
                    textBox_Filters_Ngay.Text = datetime.Day.ToString();
                    comboBox_Filters_Thang.SelectedIndex = datetime.Month - 1;
                    textBox_Filters_Nam.Text = datetime.Year.ToString();
                    textBox_Filters_Gio.Text = datetime.Hour.ToString("D2");
                    textBox_Filters_Phut.Text = datetime.Minute.ToString("D2");
                    textBox_Filters_Giay.Text = datetime.Second.ToString("D2");
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

            if(panel == panel_Upload)
                AutoFillUploadTextBox();

            LoadPage(controlMode);
        }

        private void textBox_Upload_MaLK_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                FillMaLK(textBox);
            }
        }

        private void textBox_KeyPress_Normal(object sender, KeyPressEventArgs e)
        {
            GeneralMethods.textBox_KeyPress_Normal(sender, e);
        }
    }
}
