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
            string query = "INSERT INTO line(name_line, name_category) VALUES(@name_line, @name_category)";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@name_line", line.Name);
            parameters[1] = new MySqlParameter("@name_category", line.IdCategory);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateLine(Line line)
        {
            string query = "UPDATE line SET name_line = @name_line, name_category = @name_category WHERE id_line = @id_line";
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@name_line", line.Name);
            parameters[1] = new MySqlParameter("@name_category", line.IdCategory);
            parameters[2] = new MySqlParameter("@id_line", line.Id);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteLine(int line)
        {
            string query = "DELETE FROM line WHERE id_line = @id_line";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_line", line);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
