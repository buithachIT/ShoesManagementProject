using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    class DatabaseHelper
    {
        private string connectionString = "Server=localhost;Database=shoes_web;User=root;Password=;";

        public MySqlConnection GetConnection()

        {
            return new MySqlConnection(connectionString);
        }

        // Hàm thực thi câu lệnh (Insert, Update, Delete)
        public bool ExecuteNonQuery(string query, MySqlParameter[] parameters)
        {
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thực thi lệnh SQL: " + ex.Message);
                    return false;
                }
            }
        }
        // Hàm lấy dữ liệu (SELECT)
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
            }
            return dataTable;
        }

        public object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open(); // Đảm bảo mở kết nối trước khi thực thi

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        object result = cmd.ExecuteScalar();
                        return result == DBNull.Value ? null : result;
                    }
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                Console.WriteLine($"ExecuteScalar error: {ex.Message}");
                return null;
            }
        }
    }
}
