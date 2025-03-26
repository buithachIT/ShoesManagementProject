using MySql.Data.MySqlClient;
using Shared.Models;  // Dùng Model từ Shared
using System.Collections.Generic;
using System;
using System.Data;

namespace AdminApp.Controllers
{
    public class ProductController
    {
        private string connectionString = "Server=localhost;Database=shose_web;User Id=root;Password=;";

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_product, name_product, id_line, id_brand, description, material, price, imageUrl, releasedate, status FROM product";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        IdProduct = reader.GetInt32(0),
                        NameProduct = reader.GetString(1),
                        IdLine = reader.GetInt32(2),
                        IdBrand = reader.GetInt32(3),
                        Description = reader.GetString(4),
                        Material = reader.GetString(5),
                        Price = reader.GetDecimal(6),
                        ImageUrl = reader.GetString(7),
                        Releasedate = reader.GetDateTime(8),
                        Status = reader.GetString(9)
                    });
                }
            }
            return products;
        }
        public DataTable GetLines()
        {
            DataTable dataTable = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id_line, name_line FROM lines";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
            return dataTable;
        }

        public bool AddProduct(Product product)
        {
            string query = "INSERT INTO product (id_product, name_product, id_line, id_brand, description, material, price, imageUrl, releasedate, status) " +
                           "VALUES (@id_product, @name_product, @id_line, @id_brand, @description, @material, @price, @imageUrl, @releasedate, @status)";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_product", product.IdProduct);
                        cmd.Parameters.AddWithValue("@name_product", product.NameProduct);
                        cmd.Parameters.AddWithValue("@id_line", product.IdLine);
                        cmd.Parameters.AddWithValue("@id_brand", product.IdBrand);
                        cmd.Parameters.AddWithValue("@description", product.Description);
                        cmd.Parameters.AddWithValue("@material", product.Material);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@imageUrl", product.ImageUrl);
                        cmd.Parameters.AddWithValue("@releasedate", product.Releasedate);
                        cmd.Parameters.AddWithValue("@status", product.Status);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                return false;
            }
        }
        public bool UpdateProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE products 
                            SET name_product = @name, id_line = @line, id_brand = @brand, 
                                description = @desc, material = @material, price = @price, 
                                imageUrl = @image, releasedate = @date, status = @status 
                            WHERE id_product = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", product.IdProduct);
                        cmd.Parameters.AddWithValue("@name", product.NameProduct);
                        cmd.Parameters.AddWithValue("@line", product.IdLine);
                        cmd.Parameters.AddWithValue("@brand", product.IdBrand);
                        cmd.Parameters.AddWithValue("@desc", product.Description);
                        cmd.Parameters.AddWithValue("@material", product.Material);
                        cmd.Parameters.AddWithValue("@price", product.Price);
                        cmd.Parameters.AddWithValue("@image", product.ImageUrl);
                        cmd.Parameters.AddWithValue("@date", product.Releasedate);
                        cmd.Parameters.AddWithValue("@status", product.Status);

                        return cmd.ExecuteNonQuery() > 0; // Trả về true nếu cập nhật thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật sản phẩm: " + ex.Message);
                    return false;
                }
            }
        }



    }
}
