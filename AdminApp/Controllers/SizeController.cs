using MySql.Data.MySqlClient;
using System.Data;
using Size = Shared.Models.Size;

namespace AdminApp.Controllers
{
    class SizeController
    {
        private DatabaseHelper db = new DatabaseHelper();
        public List<Size> GetAllSize()
        {
            string query = "SELECT id_size, size_value, type FROM size";
            DataTable dt = db.ExecuteQuery(query);
            List<Size> sizes = new List<Size>();
            foreach (DataRow row in dt.Rows)
            {
                sizes.Add(new Size
                {
                    IdSize = Convert.ToInt32(row["id_size"]),
                    SizeValue = Convert.ToDecimal(row["size_value"]),
                    Type = row["type"].ToString()
                });
            }
            return sizes;
        }

        public bool AddSize(Size size)
        {
            string query = "INSERT INTO size(size_value, type) VALUES(@size_value, @type)";
            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@size_value", size.SizeValue);
            parameters[1] = new MySqlParameter("@type", size.Type);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateSize(Size size)
        {
            string query = "UPDATE size SET size_value = @size_value, type = @type WHERE id_size = @id_size";
            MySqlParameter[] parameters = new MySqlParameter[3];
            parameters[0] = new MySqlParameter("@size_value", size.SizeValue);
            parameters[1] = new MySqlParameter("@type", size.Type);
            parameters[2] = new MySqlParameter("@id_size", size.IdSize);
            return db.ExecuteNonQuery(query, parameters);
        }


        public bool DeleteSize(int size) {
            string query = "DELETE FROM size WHERE id_size = @id_size";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_size", size);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
