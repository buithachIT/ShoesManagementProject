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
        ProductVariantController productVariantController = new ProductVariantController();
        ColorController colorController = new ColorController();
        ImageController imageController = new ImageController();

        public add_Image()
        {
            InitializeComponent();
            loadProduct();
            loadVariant();
            loadColor();
            SetupControls();
            loadImage();
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

        private void loadImage()
        {
            dataGridView1.DataSource = imageController.GetAllImages();
        }

        private void loadProduct()
        {
            cbbProductName.DataSource = productController.GetAllProducts();
            cbbProductName.DisplayMember = "NameProduct";
            cbbProductName.ValueMember = "IdProduct";
        }

        private void loadVariant()
        {
            cbb_Variant.DataSource = productVariantController.GetAllProductVariant();
            cbb_Variant.DisplayMember = "NameVariant";
            cbb_Variant.ValueMember = "IdVariant";
        }

        private void loadColor()
        {
            cbb_Color.DataSource = colorController.GetAllColor();
            cbb_Color.DisplayMember = "NameColor";
            cbb_Color.ValueMember = "IdColor";
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
            if (cbb_Variant.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn biến thể", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbb_Color.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn màu", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int productId = (int)cbbProductName.SelectedValue;
                string imageName = Path.GetFileName(selectedImagePath);
                int variantId = (int)cbb_Variant.SelectedValue;
                int colorId = (int)cbb_Color.SelectedValue;

                // Chỉ lưu đường dẫn ảnh (không có imageData)
                ImageController imageController = new ImageController();
                imageController.AddImage(productId, imageName, variantId, colorId);
                CopyImageToWebApp(imageName);
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

        private void delete_Click(object sender, EventArgs e)
        {
            int id_image = (int)dataGridView1.SelectedRows[0].Cells["IdImage"].Value;
            if (id_image == 0)
            {
                MessageBox.Show("Vui lòng chọn ảnh để xóa", "Cảnh báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ảnh này không?", "Xác nhận",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool success = new ImageController().DeleteImage(id_image);
                if (success)
                {
                    MessageBox.Show("Xóa ảnh thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Cập nhật lại DataGridView
                    dataGridView1.DataSource = new ImageController().GetAllImages();
                }
                else
                {
                    MessageBox.Show("Xóa ảnh thất bại!", "Lỗi",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string imagePath = row.Cells["ImageUrl"].Value.ToString();
                selectedImagePath = imagePath;
                pictureBox1.ImageLocation = imagePath;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                cbbProductName.SelectedValue = row.Cells["IdProduct"].Value;
                cbb_Variant.SelectedValue = row.Cells["IdVariant"].Value;
                cbb_Color.SelectedValue = row.Cells["IdColor"].Value;
            }

        }
        private void CopyImageToWebApp(string imageName)
        {
            // Lấy đường dẫn gốc của solution
            string solutionRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\.."));

            // Trỏ đến thư mục chứa ảnh trong WebApp
            string imageFolderPath = Path.Combine(solutionRoot, "WebApp", "wwwroot", "image", "image_product");

            // Đường dẫn đích đầy đủ đến ảnh cần copy vào WebApp
            if (string.IsNullOrEmpty(imageName))
            {
                MessageBox.Show("Tên ảnh (imageName) đang bị null hoặc trống.");
                return;
            }
            string destPath = Path.Combine(imageFolderPath, imageName);

            try
            {
                if (!File.Exists(destPath))
                {
                    File.Copy(selectedImagePath, destPath, true); // Ghi đè nếu cần
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sao chép ảnh: " + ex.Message);
            }
        }
    }
}
