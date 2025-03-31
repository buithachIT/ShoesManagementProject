using MySql.Data.MySqlClient;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    class CategoryController
    {
        private DatabaseHelper db = new DatabaseHelper();

        public List<Category> GetAllCategory()
        {
            string query = "SELECT id_category, name_category FROM category";
            var dt = db.ExecuteQuery(query);
            List<Category> Category = new List<Category>();
            foreach (DataRow row in dt.Rows)
            {
                Category.Add(new Category
                {
                    Id = Convert.ToInt32(row["id_category"]),
                    Name = row["name_category"].ToString()
                });
            }
            return Category;
        }

        public bool AddCategory(Category category)
        {
            string query = "INSERT INTO category(name_category) VALUES(@name_category)";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@name_category", category.Name);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateCategory(Category category)
        {
            string query = "UPDATE category SET name_category = @name_category WHERE id_category = @id_category";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@name_category", category.Name);
            parameters[1] = new MySqlParameter("@id_category", category.Id);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteCategory(int category)
        {
            string query = "DELETE FROM category WHERE id_category = @id_category";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_category", category);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}