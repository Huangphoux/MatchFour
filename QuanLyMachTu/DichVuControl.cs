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

namespace QuanLyMachTu
{
    public partial class DichVuControl : UserControl
    {
        #region SQL stuffs
        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatable_DV;
        private DataTable datatable_TT;
        //Database connection
        // private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        private string connectionStr = @"Server=HOANGPHUC2023;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        #endregion

        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;

        const int DV_TAB = 0;
        const int TT_TAB = 10;

        int controlPage;
        DataTable controlDataTable;
        CustomDataGridView controlDataGridView;

        public DichVuControl()
        {
            InitializeComponent();
        }

        private void DichVuControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }

        private void InitializeState()
        {
            controlDataGridView = customDataGridView;
            controlPage = DV_TAB;
            EnablePage(controlPage);
        }

        private void EnablePage(int controlPage)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    controlDataTable = datatable_DV;
                    ColoringButton.EnabledColor(pageButton_DV);
                    panel_DV_Filter.BringToFront();
                    break;
                case TT_TAB:
                    controlDataTable = datatable_TT;
                    ColoringButton.EnabledColor(pageButton_TinhTrang);
                    panel_TinhTrang_Filter.BringToFront();
                    break;
            }

            UpdateDataGridView(customDataGridView, controlDataTable);
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

        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            LoadTabDichVu();
            LoadTabTinhTrang();

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
            //label_HienThiSoBN.Text = dgv.Rows.Count.ToString();
        }

        private void pageButton_Upload_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    panel_DV_Upload.BringToFront();
                    break;
                case TT_TAB:
                    panel_TinhTrang_Upload.BringToFront();
                    break;
            }
        }

        private void pageButton_Filter_Click(object sender, EventArgs e)
        {
            switch (controlPage)
            {
                case DV_TAB:
                    panel_DV_Filter.BringToFront();
                    break;
                case TT_TAB:
                    panel_TinhTrang_Filter.BringToFront();
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

        #region DichVu Tab
        private void pageButton_DV_Click(object sender, EventArgs e)
        {
            DisablePage(controlPage);
            controlPage = DV_TAB;
            EnablePage(controlPage);
        }

        private void LoadTabDichVu()
        {
            LoadDataToDataSet("SELECT * FROM DICHVU", "DICHVU");
            datatable_DV = dataset.Tables["DICHVU"];
            datatable_DV.PrimaryKey = new DataColumn[] { datatable_DV.Columns["MaDV"] };
        }

        const int MADV_ERR = 1;
        const int TENDV_ERR = 2;
        const int CHIPHI_ERR = 4;

        const int MAPK_ERR = 8;
        const int TENPK_ERR = 16;
        const int TINHTRANG_ERR = 32;

        private int CheckUploadTextBox()
        {
            int error = 0;

            if (string.IsNullOrEmpty(textBox_DV_MaDV.Text))
                error |= 1;
            if (string.IsNullOrEmpty(textBox_DV_TenDV.Text))
                error |= 2;
            if (string.IsNullOrEmpty(textBox_DV_ChiPhi.Text))
                error |= 4;
            if (string.IsNullOrEmpty(textBox_TT_MaPK_Upload.Text))
                error |= 8;

            return error;
        }

        private void WarningUploadTextBoxError(int error)
        {
            if ((error & MADV_ERR) == MADV_ERR)
                ColoringTextBox.WarningColor(textBox_TT_MaDV_Upload);
            if ((error & TENDV_ERR) == TENDV_ERR)
                ColoringTextBox.WarningColor(textBox_DV_TenDV);
            if ((error & CHIPHI_ERR) == CHIPHI_ERR)
                ColoringTextBox.WarningColor(textBox_DV_ChiPhi);
            if ((error & MAPK_ERR) == MAPK_ERR)
                ColoringTextBox.WarningColor(textBox_TT_MaPK_Upload);
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
            DataRow targetRow = datatable_DV.Rows.Find(primaryKey);

            if (targetRow == null) // Insert
            {
                targetRow = datatable_DV.NewRow();

                targetRow["MaDV"] = primaryKey;
                targetRow["TenDV"] = textBox_DV_TenDV.Text;
                targetRow["ChiPhi"] = textBox_DV_ChiPhi.Text;
                targetRow["MoTa"] = textBox_DV_MoTa.Text;

                datatable_DV.Rows.Add(targetRow);
            }
            else //Update
            {
                targetRow["MaDV"] = primaryKey;
                targetRow["TenDV"] = textBox_DV_TenDV.Text;
                targetRow["ChiPhi"] = textBox_DV_ChiPhi.Text;
                targetRow["MoTa"] = textBox_DV_MoTa.Text;
            }

            UpdateDataGridView(customDataGridView, datatable_DV);
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

        private void button_DV_OK_Filter_Click(object sender, EventArgs e)
        {
            string selectCommand = "1 = 1 ";

            if (string.IsNullOrEmpty(textBox_DV_MaDV_Filter.Text) == false)
                selectCommand += $"AND MaDV = '{textBox_DV_MaDV_Filter.Text}' ";

            if (string.IsNullOrEmpty(textBox_DV_TenDV_Filter.Text) == false)
                selectCommand += $"AND TenDV = '{textBox_DV_TenDV_Filter.Text}' ";

            string operation = GetOperation(comboBox_DV_Filter_Operation);
            if (string.IsNullOrEmpty(textBox_DV_ChiPhi_Filter.Text) == false
                &&
                string.IsNullOrEmpty(operation) == false)
                selectCommand += $"AND NgayLap {operation} '{textBox_DV_ChiPhi_Filter.Text}' ";

            DataRow[] resultRow = datatable_DV.Select(selectCommand);
            DataTable resultDatatable = datatable_DV.Clone();

            foreach (DataRow row in resultRow)
            {
                if (resultDatatable.Rows.Contains(row["MaDV"]))
                    continue;

                resultDatatable.ImportRow(row);
            }

            UpdateDataGridView(customDataGridView, resultDatatable);
        }

        #endregion

        #region TinhTrang Tab

        #endregion
    }
}
