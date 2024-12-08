using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanLyMachTu.Custom;
using QuanLyMachTu.Helper;

namespace QuanLyMachTu.Controls
{
    public partial class TongQuanControl : UserControl
    {
        #region SQL stuffs
        //Database fields
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataSet dataset;
        private DataTable datatable;

        // private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        private string connectionStr = @"Server=HOANGPHUC2023;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        #endregion

        const int NV_TAB = 0;
        const int KHOA_TAB = 10;

        int controlPage;
        DataTable controlDataTable;

        public TongQuanControl()
        {
            InitializeComponent();
        }

        private void TongQuanControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }

        private void InitializeState()
        {
            controlPage = NV_TAB;
            EnablePage(controlPage);
        }
        private void EnablePage(int controlPage)
        {
            //switch (controlPage)
            //{
            //    case NV_TAB:
            //        controlDataTable = datatable_NV;
            //        ColoringButton.EnabledColor(pageButton_Tab_NhanVien);
            //        panel_NV_Upload.BringToFront();
            //        break;
            //    case KHOA_TAB:
            //        controlDataTable = datatable_Khoa;
            //        ColoringButton.EnabledColor(pageButton_Tab_Khoa);
            //        panel_Khoa_Upload.BringToFront();
            //        break;
            //}

        }
        private void DisablePage(int controlPage)
        {
            switch (controlPage)
            {
                //case NV_TAB:
                //    ColoringButton.DisabledColor(pageButton_Tab_NhanVien);
                //    break;
                //case KHOA_TAB:
                //    ColoringButton.DisabledColor(pageButton_Tab_Khoa);
                //    break;
            }
        }
        private void LoadDataToDataSet(string commandStr, string tableName)
        {
            adapter = new SqlDataAdapter(commandStr, connection);
            adapter.Fill(dataset, tableName);
        }
        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            LoadDataToDataSet("SELECT * FROM DUOCPHAM", "DUOCPHAM");
            datatable = dataset.Tables["DUOCPHAM"];

            string selectCommand = "1 = 1 ";
            selectCommand += $"AND HSD > 50";

            DataRow[] resultRow = datatable.Select(selectCommand);
            DataTable resultDatatable = datatable.Clone();

            foreach (DataRow row in resultRow)
            {
                if (resultDatatable.Rows.Contains(row["MaDP"]))
                    continue;

                resultDatatable.ImportRow(row);
            }

            for (int i = 0; i < resultRow.Length; i++)
            {
                chart_DuocPham.Series[i].XValueMember = resultRow[i]["MaDP"].ToString();
                chart_DuocPham.Series[i].YValueMembers = resultRow[i]["HSD"].ToString();
            }

            chart_DuocPham.DataSource = resultDatatable;
            chart_DuocPham.DataBind();

            connection.Close();
        }

    }
}
