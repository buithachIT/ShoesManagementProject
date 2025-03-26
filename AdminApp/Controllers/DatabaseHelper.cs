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
        private string connectionString = "Server=localhost;Database=shose_web;User=root;Password=;";

        public MySqlConnection GetConnection()

        {
            return new MySqlConnection(connectionString);
        }

        public DataTable GetUsers()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM user";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable GetProduct()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM product";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable GetColor()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM color";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable GetSize()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM size";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable GetBrand()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM brand";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable GetLine()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM line";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message);
                }
            }
            return dt;
        }
        public DataTable GetVariant()
        {
            DataTable dt = new DataTable();
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM product_variant";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối MySQL: " + ex.Message);
                }
            }
            return dt;
        }
    }
}
