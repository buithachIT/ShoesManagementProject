using AdminApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Views
{
    public partial class add_Image : Form
    {
        ProductController productController = new ProductController();
        string selectedImagePath;
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public add_Image()
        {
            InitializeComponent();
            loadProduct();
            SetupControls();
        }

        private void SetupControls()
        {
            // Thiết lập PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;

            // Thiết lập OpenFileDialog
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            openFileDialog.Title = "Select an Image";
        }

        private void upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                pictureBox1.ImageLocation = selectedImagePath;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void loadProduct()
        {
            cbbProductName.DataSource = productController.GetAllProducts();
            cbbProductName.DisplayMember = "NameProduct";
            cbbProductName.ValueMember = "IdProduct";
        }

        private void addImg_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Vui lòng chọn ảnh trước khi lưu", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbProductName.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int productId = (int)cbbProductName.SelectedValue;
                string imageName = Path.GetFileName(selectedImagePath);

                // Chỉ lưu đường dẫn ảnh (không có imageData)
                ImageController imageController = new ImageController();
                imageController.AddImage(productId, imageName);

                MessageBox.Show("Thêm ảnh thành công!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu ảnh: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
