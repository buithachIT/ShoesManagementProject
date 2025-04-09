using MySql.Data.MySqlClient;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = Shared.Models.Image;

namespace AdminApp.Controllers
{
    class ImageController
    {
        DatabaseHelper db = new DatabaseHelper();

        public List<Image> GetAllImages()
        {
            string query = "SELECT id_image, imageUrl, isPrimary, id_product, id_variant, id_color FROM image";
            var dt = db.ExecuteQuery(query);
            List<Image> images = new List<Image>();
            foreach (DataRow row in dt.Rows)
            {
                images.Add(new Image
                {
                    IdImage = Convert.ToInt32(row["id_image"]),
                    ImageUrl = row["imageUrl"].ToString(),
                    IsPrimary = Convert.ToBoolean(row["isPrimary"]),
                    IdProduct = Convert.ToInt32(row["id_product"])
                });
            }
            return images;
        }

        public bool AddImage(int productId, string imageName)
        {
            try
            {

                string query = "INSERT INTO image(imageUrl, isPrimary, id_product) VALUES(@imageUrl, 0, @id_product)";
                MySqlParameter[] parameters = new MySqlParameter[3];
                parameters[0] = new MySqlParameter("@imageUrl", imageName);
                parameters[2] = new MySqlParameter("@id_product", productId);

                bool insertSuccess = db.ExecuteNonQuery(query, parameters);
                return insertSuccess;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm ảnh: {ex.Message}");
                return false;
            }
        }
        public bool DeleteImage(int id_image)
        {
            string query = "DELETE FROM image WHERE id_image = @id_image";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_image", id_image);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
