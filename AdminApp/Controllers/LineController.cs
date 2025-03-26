using MySql.Data.MySqlClient;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    class LineController
    {
        private string connectionString = "Server=localhost;Database=shose_web;User Id=root;Password=;";

        public List<Line> GetAllLine()
        {
            List<Line> products = new List<Line>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_line, name_category, id_category FROM line";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Line
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        IdCategory = reader.GetInt32(2)
                    });
                }
            }
            return products;
        }
    }
}
