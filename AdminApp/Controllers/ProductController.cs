using MySql.Data.MySqlClient;
using Shared.Models;
using System.Collections.Generic;
using System.Data;

namespace AdminApp.Controllers
{
    public class ProductController
    {
        private DatabaseHelper db = new DatabaseHelper();

        public List<Product> GetAllProducts()
        {
            string query = "SELECT id_product, name_product, id_line, id_brand, description, material, price, imageUrl, releasedate, status FROM product";
            DataTable dt = db.ExecuteQuery(query);
            List<Product> products = new List<Product>();
            foreach (DataRow row in dt.Rows)
            {
                products.Add(new Product
                    {
                        IdProduct = Convert.ToInt32(row["id_product"]),
                        NameProduct = row["name_product"].ToString(),
                        IdLine = Convert.ToInt32(row["id_line"]),
                        IdBrand = Convert.ToInt32(row["id_brand"]),
                        Description = row["description"].ToString(),
                        Material = row["material"].ToString(),
                        Price = Convert.ToDecimal(row["price"]),
                        ImageUrl = row["imageUrl"].ToString(),
                        Releasedate = Convert.ToDateTime(row["releasedate"]),
                        Status = row["status"].ToString()
                });
             }
            return products;
        }
        public bool AddProduct(Product product)
        {
            string query = "INSERT INTO product (id_product, name_product, id_line, id_brand, description, material, price, imageUrl, releasedate, status) " +
                           "VALUES (@id_product, @name_product, @id_line, @id_brand, @description, @material, @price, @imageUrl, @releasedate, @status)";

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id", product.IdProduct),
                new MySqlParameter("@name", product.NameProduct),
                new MySqlParameter("@line", product.IdLine),
                new MySqlParameter("@brand", product.IdBrand),
                new MySqlParameter("@desc", product.Description),
                new MySqlParameter("@material", product.Material),
                new MySqlParameter("@price", product.Price),
                new MySqlParameter("@image", product.ImageUrl),
                new MySqlParameter("@date", product.Releasedate),
                new MySqlParameter("@status", product.Status)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool UpdateProduct(Product product)
        {
            string query = @"UPDATE product
                            SET name_product = @name, id_line = @line, id_brand = @brand, 
                                description = @desc, material = @material, price = @price, 
                                imageUrl = @image, releasedate = @date, status = @status 
                            WHERE id_product = @id";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id", product.IdProduct),
                new MySqlParameter("@name", product.NameProduct),
                new MySqlParameter("@line", product.IdLine),
                new MySqlParameter("@brand", product.IdBrand),
                new MySqlParameter("@desc", product.Description),
                new MySqlParameter("@material", product.Material),
                new MySqlParameter("@price", product.Price),
                new MySqlParameter("@image", product.ImageUrl),
                new MySqlParameter("@date", product.Releasedate),
                new MySqlParameter("@status", product.Status)
            };
            return db.ExecuteNonQuery(query, parameters);
        }
        public bool DeleteProduct(int idProduct)
        {
            string query = "DELETE FROM product WHERE id_product = @id";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("@id", idProduct)
            };
            return db.ExecuteNonQuery(query, parameters);
        }


    }
}
