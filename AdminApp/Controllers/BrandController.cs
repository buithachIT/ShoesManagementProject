using MySql.Data.MySqlClient;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    class BrandController
    {
        private string connectionString = "Server=localhost;Database=shose_web;User Id=root;Password=;";

        public List<Brand> GetAllBrand()
        {
            List<Brand> products = new List<Brand>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_brand, name_brand, info_brand FROM brand";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Brand
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Info = reader.GetString(2)
                    });
                }
            }
            return products;
        }
    }
}
