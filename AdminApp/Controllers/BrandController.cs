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
                    Id = Convert.ToInt32(row["id_brand"]),
                    Name = row["name_brand"].ToString(),
                    Info = row["info_brand"].ToString()
                });
            }
            return Brand;
        }
        public bool AddBrand(Brand brand)
        {
            string checkQuery = "SELECT COUNT(*) FROM brand WHERE name_brand = @name_brand";
            MySqlParameter[] checkParams = {
                new MySqlParameter("@name_brand", brand.Name)
            };
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));
            if (count > 0)
            {
                // Nếu đã tồn tại, thông báo và không thêm
                MessageBox.Show("Tên thương hiệu đã tồn tại!");
                return false;
            }

            string query = "INSERT INTO brand(name_brand, info_brand) VALUES(@name_brand, @info_brand)";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@name_brand", brand.Name);
            parameters[1] = new MySqlParameter("@info_brand", brand.Info);
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool UpdateBrand(Brand brand)
        {
            string checkQuery = "SELECT COUNT(*) FROM brand WHERE name_brand = @name_brand AND id_brand != @id_brand";
            MySqlParameter[] checkParams = {
                new MySqlParameter("@name_brand", brand.Name),
                new MySqlParameter("@id_brand", brand.Id)
            };
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));
            if (count > 0)
            {
                // Nếu đã tồn tại, thông báo và không cập nhật
                MessageBox.Show("Tên thương hiệu đã tồn tại!");
                return false;
            }

            string query = "UPDATE brand SET name_brand = @name_brand, info_brand = @info_brand WHERE id_brand = @id_brand";
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@name_brand", brand.Name);
            parameters[1] = new MySqlParameter("@info_brand", brand.Info);
            parameters[2] = new MySqlParameter("@id_brand", brand.Id);
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
