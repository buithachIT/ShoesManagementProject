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
    class LineController
    {
        private DatabaseHelper db = new DatabaseHelper();

        public List<Line> GetAllLine()
        {
            string query = "SELECT id_line, name_category, id_category FROM line";
            var dt = db.ExecuteQuery(query);
            List<Line> Line = new List<Line>();
            foreach (DataRow row in dt.Rows)
            {
                Line.Add(new Line
                {
                    Id = Convert.ToInt32(row["id_line"]),
                    Name = row["name_category"].ToString(),
                    IdCategory = Convert.ToInt32(row["id_category"])
                });
            }
            return Line;
        }

        public bool AddLine(Line line)
        {
            string checkQuery = "SELECT COUNT(*) FROM line WHERE name_category = @name_category AND id_category = @id_category";
            MySqlParameter[] checkParams = new MySqlParameter[2];
            checkParams[0] = new MySqlParameter("@name_category", line.Name);
            checkParams[1] = new MySqlParameter("@id_category", line.IdCategory);
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));
            if (count > 0)
            {
                MessageBox.Show("Tên dòng đã tồn tại!");
                return false;
            }

            string query = "INSERT INTO line(name_category, id_category) VALUES(@name_category, @id_category)";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@name_category", line.Name);
            parameters[1] = new MySqlParameter("@id_category", line.IdCategory);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateLine(Line line)
        {
            string checkQuery = "SELECT COUNT(*) FROM line WHERE name_category = @name_category AND id_category = @id_category AND id_line != @id_line";
            MySqlParameter[] checkParams = new MySqlParameter[3];
            checkParams[0] = new MySqlParameter("@name_category", line.Name);
            checkParams[1] = new MySqlParameter("@id_category", line.IdCategory);
            checkParams[2] = new MySqlParameter("@id_line", line.Id);
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));
            if (count > 0)
            {
                MessageBox.Show("Tên dòng đã tồn tại!");
                return false;
            }

            string query = "UPDATE line SET name_category = @name_category, id_category = @id_category WHERE id_line = @id_line";
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@name_category", line.Name);
            parameters[1] = new MySqlParameter("@id_category", line.IdCategory);
            parameters[2] = new MySqlParameter("@id_line", line.Id);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteLine(int line)
        {
            string checkQuery = "SELECT COUNT(*) FROM product WHERE id_line = @id_line";
            MySqlParameter[] checkParams = new MySqlParameter[1];
            checkParams[0] = new MySqlParameter("@id_line", line);

            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

            if (count > 0)
            {
                MessageBox.Show("Không thể xóa dòng vì có sản phẩm thuộc dòng này!");
                return false;
            }


            string query = "DELETE FROM line WHERE id_line = @id_line";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_line", line);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
