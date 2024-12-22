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
using System.Web;
using System.Windows.Forms;

namespace QuanLyMachTu
{
    public partial class DichVuControl : UserControl
    {
        private string DV_SelectCommand = "SELECT MaDV, TenDV, ChiPhi, MoTa " +
                                          "FROM DICHVU " +
                                          "WHERE IsDeleted = 0 ";
        private string PKDV_SelectCommand = "SELECT * " +
                                            "FROM PhongKham_DichVu ";
        private string selectLastID = "SELECT TOP 1 MaDV FROM DICHVU ORDER BY MaDV DESC";

        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;

        const int DV_TAB = 0;
        const int TT_TAB = 10;

        string next_DV_PrimaryKey;
        int DV_controlFunc;
        int TT_controlFunc;
        int controlPage;
        string controlCommand;

        public DichVuControl()
        {
            InitializeComponent();
        }

        private void DichVuControl_Load(object sender, EventArgs e)
        {
            InitializeState();
        }

        private void InitializeState()
        {
            InitializeState_DV();
            InitializeState_TT();

            controlPage = DV_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }

        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    ColoringButton.EnabledColor(pageButton_DV);
                    OpenFunctionPanel(DV_controlFunc);
                    break;
                case TT_TAB:
                    ColoringButton.EnabledColor(pageButton_TinhTrang);
                    OpenFunctionPanel(TT_controlFunc);
                    break;
            }
        }
        private void LoadPage(int controlPage)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    controlCommand = DV_SelectCommand;
                    break;
                case TT_TAB:
                    controlCommand = PKDV_SelectCommand;
                    break;
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    ColoringButton.DisabledColor(pageButton_DV);
                    break;
                case TT_TAB:
                    ColoringButton.DisabledColor(pageButton_TinhTrang);
                    break;
            }
        }
        private void OpenFiltersPanel(int controlPage)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    DV_controlFunc = FIL_FUNC;
                    panel_DV_Filter.BringToFront();
                    break;
                case TT_TAB:
                    TT_controlFunc = FIL_FUNC;
                    panel_TinhTrang_Filter.BringToFront();
                    break;
            }
        }
        private void OpenUploadPanel(int controlPage)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    DV_controlFunc = INS_FUNC;
                    panel_DV_Upload.BringToFront();
                    break;
                case TT_TAB:
                    TT_controlFunc = INS_FUNC;
                    panel_TinhTrang_Upload.BringToFront();
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

            //Display statitic number
            //label_HienThiDTTong.Text = CalculateSumOfDoanhSo(dgv).ToString();
            //label_HienThiSoBN.Text = dgv.Rows.Count.ToString();
        }

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
                case DV_TAB:
                    DV_Remove();
                    break;
                case TT_TAB:
                    TT_Remove();
                    break;
            }
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
                if (control is TextBox && control != textBox_DV_MoTa)
                    graphic.DrawLine(linePen, new Point(control.Location.X - offset, control.Location.Y + control.Height + offset),
                                              new Point(control.Location.X + control.Width + offset, control.Location.Y + control.Height + offset));
            }
        }

        #region DichVu Tab
        private void pageButton_DV_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = DV_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }

        private void InitializeState_DV()
        {
            //prefetch
            next_DV_PrimaryKey = (string)DatabaseConnection.ExecuteScalar(selectLastID, null);
            next_DV_PrimaryKey = StringMath.Increment(next_DV_PrimaryKey);
            //Control
            DV_controlFunc = FIL_FUNC;
            //Filters
            comboBox_DV_Filter_Operation.SelectedItem = comboBox_DV_Filter_Operation.Items[0];
            //Upload
            FillMaDV(textBox_DV_MaDV);
        }

        #region Error bits
        const int MADV_ERR = 1;
        const int TENDV_ERR = 2;
        const int CHIPHI_ERR = 4;

        const int MAPK_ERR = 8;
        const int TENPK_ERR = 16;
        const int TINHTRANG_ERR = 32;
        #endregion

        private int CheckUploadTextBox()
        {
            int error = 0;

            if (string.IsNullOrEmpty(textBox_DV_MaDV.Text))
                error |= 1;
            if (string.IsNullOrEmpty(textBox_DV_TenDV.Text))
                error |= 2;
            if (string.IsNullOrEmpty(textBox_DV_ChiPhi.Text))
                error |= 4;

            return error;
        }

        private void WarningUploadTextBoxError(int error)
        {
            if ((error & MADV_ERR) == MADV_ERR)
                ColoringTextBox.WarningColor(textBox_DV_MaDV);
            if ((error & TENDV_ERR) == TENDV_ERR)
                ColoringTextBox.WarningColor(textBox_DV_TenDV);
            if ((error & CHIPHI_ERR) == CHIPHI_ERR)
                ColoringTextBox.WarningColor(textBox_DV_ChiPhi);
        }

        private void button_DV_OK_Click(object sender, EventArgs e)
        {
            int error = CheckUploadTextBox();
            if (error != 0)
            {
                WarningUploadTextBoxError(error);
                return;
            }

            string primaryKey = textBox_DV_MaDV.Text;

            string checkQuery = "IF EXISTS (SELECT 1 FROM DICHVU WHERE MaDV = @MaDV) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaDV", primaryKey } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO DICHVU " +
                                        "(MaDV, TenDV, ChiPhi, MoTa) " +
                                        "VALUES(@MaDV, @TenDV, @ChiPhi, @MoTa)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaDV", primaryKey},
                    {"@TenDV", textBox_DV_TenDV.Text },
                    {"@ChiPhi", textBox_DV_ChiPhi.Text },
                    {"@MoTa", textBox_DV_MoTa.Text }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);

                next_DV_PrimaryKey = StringMath.Increment(next_DV_PrimaryKey);
            }
            else
            {
                string updateQuery = "UPDATE DICHVU " +
                                        "SET TenDV = @TenDV, " +
                                            "ChiPhi = @ChiPhi, " +
                                            "MoTa = @MoTa " +
                                        "WHERE MaDV = @MaDV";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaDV", primaryKey},
                    {"@TenDV", textBox_DV_TenDV.Text },
                    {"@ChiPhi", textBox_DV_ChiPhi.Text },
                    {"@MoTa", textBox_DV_MoTa.Text }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        private void button_DV_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = DV_SelectCommand;

            if (string.IsNullOrEmpty(textBox_DV_MaDV_Filter.Text) == false)
                selectCommand += $"AND MaDV = '{textBox_DV_MaDV_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_DV_TenDV_Filter.Text) == false)
                selectCommand += $"AND TenDV = N'{textBox_DV_TenDV_Filter.Text}' ";

            string operation = GeneralMethods.GetOperation(comboBox_DV_Filter_Operation);
            if (string.IsNullOrEmpty(textBox_DV_ChiPhi_Filter.Text) == false)
                selectCommand += $"AND ChiPhi {operation} '{textBox_DV_ChiPhi_Filter.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Remove
        private void DV_Remove()
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
                parameter = $"@MaDV{parameterIndex}";
                parameters.Add(parameter, row.Cells["MaDV"].Value.ToString());
                inDeletedList += $", {parameter}";
                parameterIndex++;
            }
            inDeletedList += ")";

            //remove
            string deleteCommand = "UPDATE DICHVU " +
                                   "SET IsDeleted = 1 " +
                                   "WHERE MaDV IN " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        #endregion

        #region TinhTrang Tab

        private void pageButton_TinhTrang_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = TT_TAB;
            EnablePage(controlPage);
            LoadPage(controlPage);
        }

        private void InitializeState_TT()
        {
            //Control
            TT_controlFunc = FIL_FUNC;
            //Upload
            comboBox_TinhTrang_Upload.SelectedItem = comboBox_TinhTrang_Upload.Items[0];
            //Filters
            comboBox_TinhTrang_Filter.SelectedItem = comboBox_TinhTrang_Filter.Items[0];
        }

        private int CheckUploadError_TT()
        {
            int error = 0;
            if (string.IsNullOrEmpty(textBox_TT_MaDV_Upload.Text))
                error |= MADV_ERR;
            if (string.IsNullOrEmpty(textBox_TT_MaPK_Upload.Text))
                error |= MAPK_ERR;
            return error;
        }

        private void WarningUploadTextBoxError_TT(int error)
        {
            if ((error & MADV_ERR) == MADV_ERR)
                ColoringTextBox.WarningColor(textBox_TT_MaDV_Upload);
            if ((error & MAPK_ERR) == MAPK_ERR)
                ColoringTextBox.WarningColor(textBox_TT_MaPK_Upload);
        }

        private void button_OK_Upload_Click(object sender, EventArgs e)
        {
            //check errors
            int error = CheckUploadError_TT();
            if (error != 0)
            {
                WarningUploadTextBoxError_TT(error);
                return;
            }

            string[] primaryKey = new string[2]
            {
                textBox_TT_MaDV_Upload.Text,
                textBox_TT_MaPK_Upload.Text
            };

            string checkQuery = "IF EXISTS (SELECT 1 FROM PhongKham_DichVu WHERE MaDV = @MaDV AND MaPK = @MaPK) SELECT 1 ELSE SELECT 0";
            Dictionary<string, object> checkParameters = new Dictionary<string, object> { { "@MaDV", primaryKey[0] }, { "@MaPK", primaryKey[1] } };

            int recordExists = (int)DatabaseConnection.ExecuteScalar(checkQuery, checkParameters);

            if (recordExists == 0)
            {
                string insertQuery = "INSERT INTO PhongKham_DichVu " +
                                     "VALUES(@MaDV, @MaPK, @TinhTrang)";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaDV", primaryKey[0] },
                    {"@MaPK",  primaryKey[1] },
                    {"@TinhTrang", comboBox_TinhTrang_Upload.SelectedItem }
                };

                DatabaseConnection.ExecuteNonQuery(insertQuery, parameters);
            }
            else
            {
                string updateQuery = "UPDATE PhongKham_DichVu " +
                                        "SET TinhTrang = @TinhTrang " +
                                        "WHERE MaDV = @MaDV AND MaPK = @MaPK";

                Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    {"@MaDV", primaryKey[0]},
                    {"@MaPK",  primaryKey[1] },
                    {"@TinhTrang", comboBox_TinhTrang_Upload.SelectedItem }
                };

                DatabaseConnection.ExecuteNonQuery(updateQuery, parameters);
            }

            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }

        private void button_TT_OK_Click(object sender, EventArgs e)
        {
            string selectCommand = "SELECT DV.MaDV, MaPK, TinhTrang " +
                                   "FROM PhongKham_DichVu PKDV " +
                                   "INNER JOIN DICHVU DV ON DV.MaDV = PKDV.MaDV " +
                                   "WHERE DV.IsDeleted = 0 ";

            if (string.IsNullOrEmpty(textBox_TT_MaDV_Filter.Text) == false)
                selectCommand += $"AND PKDV.MaDV = '{textBox_TT_MaDV_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_TT_MaPK_Filter.Text) == false)
                selectCommand += $"AND MaPK = '{textBox_TT_MaPK_Filter.Text}' ";
            if (string.IsNullOrEmpty(comboBox_TinhTrang_Filter.Text) == false)
                selectCommand += $"AND TinhTrang = '{comboBox_TinhTrang_Filter.Text}' ";
            if (string.IsNullOrEmpty(textBox_TT_TenDV_Filter.Text) == false)
                selectCommand += $"AND TenDV = N'{textBox_TT_TenDV_Filter.Text}' ";

            controlCommand = selectCommand;
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }
        //Remove
        private void TT_Remove()
        {
            //get all rows of selected cells
            HashSet<DataGridViewRow> selectedRows = new HashSet<DataGridViewRow>();
            foreach (DataGridViewCell cell in customDataGridView.SelectedCells)
                selectedRows.Add(cell.OwningRow);

            //get deleted parameters
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            string parameter1, parameter2;
            int parameterIndex = 0;

            string maPK, maDV;

            string inDeletedList = "1 != 1 ";
            foreach (DataGridViewRow row in selectedRows)
            {
                parameter1 = $"@MaPK{parameterIndex}";
                parameter2 = $"@MaDV{parameterIndex}";
                maPK = row.Cells["MaPK"].Value.ToString();
                maDV = row.Cells["MaDV"].Value.ToString();
                parameters.Add(parameter1, maPK);
                parameters.Add(parameter2, maDV);
                inDeletedList += $"OR (MaPK = {parameter1} AND MaDV = {parameter2}) ";
                parameterIndex++;
            }

            //remove
            string deleteCommand = "DELETE FROM PhongKham_DichVu " +
                                   "WHERE " + inDeletedList;
            DatabaseConnection.ExecuteNonQuery(deleteCommand, parameters);

            //renew            
            UpdateDataGridView(customDataGridView, DatabaseConnection.LoadDataIntoDataTable(controlCommand));
        }

        #endregion

        private void button_Filters_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);

            LoadPage(controlPage);
        }

        private void button_TTUpload_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);
            GeneralMethods.CleanColorPanel(panel);
            GeneralMethods.SetUpPanel(panel, 0);

            LoadPage(controlPage);
        }
        private void button_DVUpload_Reset_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Panel panel = button.Parent as Panel;

            GeneralMethods.ClearPanel(panel);
            GeneralMethods.CleanColorPanel(panel);

            FillMaDV(textBox_DV_MaDV);

            LoadPage(controlPage);
        }
        private void FillMaDV(TextBox textBox)
        {
            textBox.Text = next_DV_PrimaryKey;
        }

        private void textBox_DV_MaDV_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrEmpty(textBox.Text))
                FillMaDV(textBox);
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
                case DV_TAB:
                    fillPanel_DV(row);
                    break;
                case TT_TAB:
                    fillPanel_TT(row);
                    break;
            }
        }

        private void fillPanel_TT(DataRow row)
        {
            switch (TT_controlFunc)
            {
                case INS_FUNC:
                    textBox_TT_MaDV_Upload.Text = row["MaDV"].ToString();
                    textBox_TT_MaPK_Upload.Text = row["MaPK"].ToString();
                    comboBox_TinhTrang_Upload.Text = row["TinhTrang"].ToString();
                    GeneralMethods.CleanColorPanel(panel_TinhTrang_Upload);
                    break;
                case FIL_FUNC:
                    textBox_TT_MaDV_Filter.Text = row["MaDV"].ToString();
                    textBox_TT_MaPK_Filter.Text = row["MaPK"].ToString();
                    comboBox_TinhTrang_Filter.Text = row["TinhTrang"].ToString();
                    break;
            }
        }

        private void fillPanel_DV(DataRow row)
        {
            switch (DV_controlFunc)
            {
                case INS_FUNC:
                    textBox_DV_MaDV.Text = row["MaDV"].ToString();
                    textBox_DV_ChiPhi.Text = row["ChiPhi"].ToString();
                    textBox_DV_TenDV.Text = row["TenDV"].ToString();
                    textBox_DV_MoTa.Text = row["MoTa"].ToString();
                    GeneralMethods.CleanColorPanel(panel_DV_Upload);
                    break;
                case FIL_FUNC:
                    textBox_DV_MaDV_Filter.Text = row["MaDV"].ToString();
                    textBox_DV_TenDV_Filter.Text = row["TenDV"].ToString();
                    textBox_DV_ChiPhi_Filter.Text = row["ChiPhi"].ToString();
                    comboBox_DV_Filter_Operation.SelectedIndex = 2;
                    break;
            }
        }
    }
}
