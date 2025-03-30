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
    }
}
