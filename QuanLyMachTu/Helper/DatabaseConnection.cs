using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace QuanLyMachTu.Helper
{
    public static class DatabaseConnection
    {
        //Database fields
        public static SqlConnection connection;
        private static SqlTransaction transaction;
        public static readonly string connectionStr = @"Server=LAPTOP-6GL1AF15\STUDENT;Database=QUANLYPHONGMACHTU;User Id=project1;Password=letmein;";        

        public static void OpenConnection()
        {
            if (connection == null || connection.State == ConnectionState.Closed)
            {
                connection = new SqlConnection(connectionStr);
                SqlDependency.Start(connectionStr);
                connection.Open();                
                transaction = connection.BeginTransaction();
            }
        }
        public static SqlConnection GetConnection()
        {
            return connection;
        }
        public static void CloseConnection()
        {
            if(connection != null && connection.State == ConnectionState.Open)
            {
                transaction.Rollback();
                SqlDependency.Stop(connectionStr);
                connection.Close();            
            }
        }
        public static DataTable LoadDataIntoDataTable(string query)
        {
            OpenConnection();  // Ensure connection is open

            DataTable dataTable = new DataTable();            

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Transaction = transaction;
                try
                {
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while reading: {ex.Message}\n\nThe query:\n{query}");
                }
            }

            return dataTable;
        }
        public static void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            OpenConnection();  // Ensure connection is open

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Transaction = transaction;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {                    
                    MessageBox.Show($"An error occurred while searching for the row: {ex.Message}\n\nThe query:\n{query}");
                }
            }
        }
        public static SqlDataReader ExecuteReader(string query)
        {
            OpenConnection();  // Ensure connection is open
            
            SqlCommand command = new SqlCommand(query, connection)
            {
                Transaction = transaction
            };

            return command.ExecuteReader();
        }
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            OpenConnection();

            object result;

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Transaction = transaction;

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                result = command.ExecuteScalar();
            }

            return result;
        }

        //public static SqlDataReader ExecuteReaderNotification(string query, OnChangeEventHandler onChangeEvent)
        //{
        //    OpenConnection();  // Ensure connection is open

        //    SqlCommand command = new SqlCommand(query, connection) { Transaction = transaction };

        //    if (!query.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
        //    {
        //        throw new ArgumentException("Query must be a SELECT statement for SqlDependency.", nameof(query));
        //    }

        //    SqlDependency dependency = new SqlDependency(command);
        //    dependency.OnChange += onChangeEvent;

        //    return command.ExecuteReader();
        //}
    }
}
