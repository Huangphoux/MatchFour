using QuanLyMachTu.Custom;
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
        private DataTable datatable;
        //Database connection
        // private string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";
        private string connectionStr = @"Server=HOANGPHUC2023;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";

        #endregion

        const int INS_FUNC = 1;
        const int FIL_FUNC = 2;

        public DichVuControl()
        {
            InitializeComponent();
        }

        private void DichVuControl_Load(object sender, EventArgs e)
        {
            LoadData();
            InitializeState();
        }


        CustomDataGridView controlDataGridView;
        private void InitializeState()
        {
            controlDataGridView = customDataGridView;
            panel_DV_Upload.BringToFront();


            //controlDataGridView = customDataGridView_PC;
            //controlPage = PK_TAB;
            //SwitchMode(controlPage);
            //panel_Filters.BringToFront();


            //controlPage = BN_TAB;
            //controlDataTable = datatableBN;
            //EnablePage(controlPage);
        }

        private void LoadData()
        {
            connection = new SqlConnection(connectionStr);
            connection.Open();

            dataset = new DataSet();

            LoadDataToDataSet("SELECT * FROM DICHVU", "DICHVU");
            datatable = dataset.Tables["DICHVU"];
            datatable.PrimaryKey = new DataColumn[] { datatable.Columns["MaDV"] };

            connection.Close();

            UpdateDataGridView(customDataGridView, datatable);
        }
    }
}
