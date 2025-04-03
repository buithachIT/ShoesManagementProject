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

        public bool DeleteCategory(int categoryId)
        {
            // Kiểm tra xem category có tồn tại trong bảng line không
            string checkQuery = "SELECT COUNT(*) FROM line WHERE id_category = @id_category";
            MySqlParameter[] checkParams = new MySqlParameter[1];
            checkParams[0] = new MySqlParameter("@id_category", categoryId);

            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

            if (count > 0)
            {
                // Nếu có dòng liên quan, thông báo và không xóa
                MessageBox.Show("Không thể xóa danh mục vì có sản phẩm thuộc danh mục này!",
                              "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Nếu không có dòng liên quan, thực hiện xóa
            string deleteQuery = "DELETE FROM category WHERE id_category = @id_category";
            MySqlParameter[] deleteParams = new MySqlParameter[1];
            deleteParams[0] = new MySqlParameter("@id_category", categoryId);

            return db.ExecuteNonQuery(deleteQuery, deleteParams);
        }
    }
}