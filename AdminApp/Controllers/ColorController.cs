using MySql.Data.MySqlClient;
using Shared.Models;
using System.Collections.Generic;
using System.Data;
using Color = Shared.Models.Color;

namespace AdminApp.Controllers
{
    class ColorController
    {
        private DatabaseHelper db = new DatabaseHelper();
        public List<Color> GetAllColor()
        {
            string query = "SELECT id_color, color_name, color_code FROM color";
            DataTable dt = db.ExecuteQuery(query);
            List<Color> colors = new List<Color>();
            foreach (DataRow row in dt.Rows)
            {
                colors.Add(new Color
                {
                    IdColor = Convert.ToInt32(row["id_color"]),
                    NameColor = row["color_name"].ToString(),
                    ColorCode = row["color_code"].ToString()
                });
            }
            return colors;
        }
        public bool AddColor(Color color)
        {
            string query = "INSERT INTO color(color_name, color_code) VALUES(@color_name, @color_code)";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@color_name", color.NameColor);
            parameters[1] = new MySqlParameter("@color_code", color.ColorCode);
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool UpdateColor(Color color)
        {
            string query = "UPDATE color SET color_name = @color_name, color_code = @color_code WHERE id_color = @id_color";
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@color_name", color.NameColor);
            parameters[1] = new MySqlParameter("@color_code", color.ColorCode);
            parameters[2] = new MySqlParameter("@id_color", color.IdColor);
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool DeleteColor(int idColor)
        {
            string checkQuery = "SELECT COUNT(*) FROM product_variant WHERE id_color = @id_color";
            MySqlParameter[] checkParams = new MySqlParameter[1];
            checkParams[0] = new MySqlParameter("@id_color", idColor);
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));
            if (count > 0)
            {
                MessageBox.Show("Không thể xóa màu này vì có sản phẩm liên quan");
                return false;
            }

            string query = "DELETE FROM color WHERE id_color = @id_color";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_color", idColor);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
