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
    }
}
