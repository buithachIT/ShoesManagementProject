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
    class ProductVariantController
    {
        private DatabaseHelper db = new DatabaseHelper();

        public List<ProductVariant> GetAllProductVariant()
        {
            string query = "SELECT id_variant, id_product, id_color, id_size, quantity, expired_date FROM product_variant";
            var dt = db.ExecuteQuery(query);
            List<ProductVariant> ProductVariant = new List<ProductVariant>();
            foreach (DataRow row in dt.Rows)
            {
                ProductVariant.Add(new ProductVariant
                {
                    IdVariant = Convert.ToInt32(row["id_variant"]),
                    IdProduct = Convert.ToInt32(row["id_product"]),
                    IdColor = Convert.ToInt32(row["id_color"]),
                    IdSize = Convert.ToInt32(row["id_size"]),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    ExpiredDate = Convert.ToDateTime(row["expired_date"])
                });
            }
            return ProductVariant;
        }

        public bool AddProductVariant(ProductVariant productVariant)
        {
            string checkQuery = "SELECT COUNT(*) FROM product_variant WHERE id_product = @id_product AND id_color = @id_color AND id_size = @id_size";
            MySqlParameter[] checkParams = new MySqlParameter[3];
            checkParams[0] = new MySqlParameter("@id_product", productVariant.IdProduct);
            checkParams[1] = new MySqlParameter("@id_color", productVariant.IdColor);
            checkParams[2] = new MySqlParameter("@id_size", productVariant.IdSize);
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));
            if (count > 0)
            {
                MessageBox.Show("Biến thể sản phẩm đã tồn tại!");
                return false;
            }

            string query = "INSERT INTO product_variant(id_product, id_color, id_size, quantity, expired_date) VALUES(@id_product, @id_color, @id_size, @quantity, @expired_date)";
            MySqlParameter[] parameters = new MySqlParameter[5];
            parameters[0] = new MySqlParameter("@id_product", productVariant.IdProduct);
            parameters[1] = new MySqlParameter("@id_color", productVariant.IdColor);
            parameters[2] = new MySqlParameter("@id_size", productVariant.IdSize);
            parameters[3] = new MySqlParameter("@quantity", productVariant.Quantity);
            parameters[4] = new MySqlParameter("@expired_date", productVariant.ExpiredDate);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateProductVariant(ProductVariant productVariant)
        {
            string query = "UPDATE product_variant SET id_product = @id_product, quantity = @quantity, expired_date = @expired_date WHERE id_variant = @id_variant";
            MySqlParameter[] parameters = new MySqlParameter[4];
            parameters[0] = new MySqlParameter("@id_product", productVariant.IdProduct);
            parameters[1] = new MySqlParameter("@quantity", productVariant.Quantity);
            parameters[2] = new MySqlParameter("@expired_date", productVariant.ExpiredDate);
            parameters[3] = new MySqlParameter("@id_variant", productVariant.IdVariant);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteProductVariant(int productVariant)
        {
            string checkQuery = @"
            SELECT COUNT(*) 
            FROM invoicedetail d
            JOIN invoice i ON d.id_invoice = i.id_invoice
            WHERE d.id_variant = @id_variant AND i.status != 'Hoàn thành'";
            MySqlParameter[] checkParams = new MySqlParameter[1];
            checkParams[0] = new MySqlParameter("@id_variant", productVariant);

            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery, checkParams));

            if (count == 0)
            {
                // Tức là tất cả các hóa đơn đều "Hoàn thành" hoặc không có liên quan thì được phép xóa
                string query = "DELETE FROM product_variant WHERE id_variant = @id_variant";
                MySqlParameter[] parameters = new MySqlParameter[1];
                parameters[0] = new MySqlParameter("@id_variant", productVariant);
                return db.ExecuteNonQuery(query, parameters);
            }

            // Có ít nhất 1 hoá đơn chưa hoàn thành → không được xoá
            return false;
        }
    }
}