using MySql.Data.MySqlClient;
using Shared.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    class BrandController
    {
        private DatabaseHelper db = new DatabaseHelper();

        public List<Brand> GetAllBrand()
        {
            string query = "SELECT id_brand, name_brand, info_brand FROM brand";
            var dt = db.ExecuteQuery(query);
            List<Brand> Brand = new List<Brand>();
            foreach (DataRow row in dt.Rows)
            {
                Brand.Add(new Brand
                {
                    IdBrand = Convert.ToInt32(row["id_brand"]),
                    NameBrand = row["name_brand"].ToString(),
                    InfoBrand = row["info_brand"].ToString()
                });
            }
            return Brand;
        }
        public bool AddBrand(Brand brand)
        {
            string query = "INSERT INTO brand(name_brand, info_brand) VALUES(@name_brand, @info_brand)";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@name_brand", brand.NameBrand);
            parameters[1] = new MySqlParameter("@info_brand", brand.InfoBrand);
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool UpdateBrand(Brand brand)
        {
            string query = "UPDATE brand SET name_brand = @name_brand, info_brand = @info_brand WHERE id_brand = @id_brand";
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@name_brand", brand.NameBrand);
            parameters[1] = new MySqlParameter("@info_brand", brand.InfoBrand);
            parameters[2] = new MySqlParameter("@id_brand", brand.IdBrand);
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool DeleteBrand(int brand)
        {
            string query = "DELETE FROM brand WHERE id_brand = @id_brand";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_brand", brand);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
