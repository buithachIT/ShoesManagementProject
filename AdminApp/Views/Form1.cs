using AdminApp.Controllers;
using AdminApp.Views;
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Asn1.Cmp;
using Shared.Models;
using System.Data;
using System.Xml.Linq;
using Color = Shared.Models.Color;
using Size = Shared.Models.Size;
using User = Shared.Models.User;

namespace AdminApp;

public partial class Form1 : Form
{
    ProductController productController = new ProductController();
    UserController userController = new UserController();
    LineController lineController = new LineController();
    BrandController brandController = new BrandController();
    RoleController roleController = new RoleController();
    ColorController colorController = new ColorController();
    SizeController sizeController = new SizeController();
    CategoryController categoryController = new CategoryController();
    ProductVariantController productVariantController = new ProductVariantController();
    InvoiceController invoiceController = new InvoiceController();


    DatabaseHelper dbHelper = new DatabaseHelper();
    public Form1()
    {
        InitializeComponent();
        LoadDataProduct();
        SetupControls();
    }
    private void LoadDataProduct()
    {
        tableProduct.DataSource = productController.GetAllProducts();
        cbbLine.DataSource = lineController.GetAllLine();
        cbbLine.DisplayMember = "Name";
        cbbLine.ValueMember = "Id";
        cbbBrand.DataSource = brandController.GetAllBrand();
        cbbBrand.DisplayMember = "Name";
        cbbBrand.ValueMember = "Id";
    }
    private void LoadDataUser()
    {
        tableUsers.DataSource = userController.GetAllUsers();
        cbb_Role.DataSource = roleController.GetAllRole();
        cbb_Role.DisplayMember = "NameRole";
        cbb_Role.ValueMember = "IdRole";
    }
    private void LoadDataColor()
    {
        tableColor.DataSource = colorController.GetAllColor();
    }
    private void LoadDataSize()
    {
        tableSize.DataSource = sizeController.GetAllSize();
    }
    private void LoadDataLine()
    {
        tableLine.DataSource = lineController.GetAllLine();
        cbb_Category.DataSource = categoryController.GetAllCategory();
        cbb_Category.DisplayMember = "Name";
        cbb_Category.ValueMember = "Id";
    }
    private void LoadDataBrand()
    {
        tableBrand.DataSource = brandController.GetAllBrand();
    }
    private void LoadDataVariant()
    {
        tableVariant.DataSource = productVariantController.GetAllProductVariant();
        cbb_Product.DataSource = productController.GetAllProducts();
        cbb_Product.DisplayMember = "NameProduct";
        cbb_Product.ValueMember = "IdProduct";

        LoadSizeToCheckedListBox();
        LoadColorToCheckedListBox();
    }
    private void LoadDataInvoice()
    {
        tableInvoice.DataSource = invoiceController.GetAllInvoice();
        cbb_User.DataSource = userController.GetAllUsers();
        cbb_User.DisplayMember = "IdUser";
        cbb_User.ValueMember = "IdUser";
    }

    //////////////////////// Load dữ liệu khi chuyển tab ////////////////////////

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab == tabProduct) // Kiểm tra nếu đang ở tab "Product"
        {
            LoadDataProduct();
            ResetTextBoxes();
        }
        else if (tabControl1.SelectedTab == tabUser) // Kiểm tra nếu đang ở tab "User"
        {
            LoadDataUser();
            ResetTextBoxes();
            txt_Sdt.MaxLength = 11;
        }
        else if (tabControl1.SelectedTab == tabColorSize) // Kiểm tra nếu đang ở tab "Color"
        {
            LoadDataColor();
            LoadDataSize();
            ResetTextBoxes();
        }
        else if (tabControl1.SelectedTab == tabBrandLine) // Kiểm tra nếu đang ở tab "Line"
        {
            LoadDataLine();
            LoadDataBrand();
            ResetTextBoxes();
        }
        else if (tabControl1.SelectedTab == tabVariant) // Kiểm tra nếu đang ở tab "Variant"
        {
            LoadDataVariant();
            ResetTextBoxes();
        }
        else if (tabControl1.SelectedTab == tabInvoice) // Kiểm tra nếu đang ở tab "Category"
        {
            LoadDataInvoice();
            ResetTextBoxes();
        }
    }

    //////////////////////////////// Kiểm tra dữ liệu nhập vào ////////////////////////////////
    private void price_Prd_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        string currentText = textBox.Text;
        int selectionStart = textBox.SelectionStart;

        // Cho phép phím Backspace
        if (e.KeyChar == (char)Keys.Back)
            return;

        // Cho phép dấu chấm (chỉ 1 dấu chấm)
        if (e.KeyChar == '.')
        {
            if (currentText.Contains(".") || currentText.Length == 0)
            {
                e.Handled = true;
            }
            return;
        }

        // Chuyển dấu phẩy thành dấu chấm nếu chưa có dấu chấm
        if (e.KeyChar == ',')
        {
            if (!currentText.Contains("."))
            {
                e.KeyChar = '.';
            }
            else
            {
                e.Handled = true;
            }
            return;
        }
        // Chỉ cho phép nhập số 
        if (!char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
            return;
        }
        // Ngăn chặn số 0 đầu tiên
        if (currentText.Length == 0 && e.KeyChar == '0')
        {
            e.Handled = true;
        }
        // Kiểm tra phần thập phân
        if (currentText.Contains("."))
        {
            int dotPosition = currentText.IndexOf('.');
            if (selectionStart > dotPosition && currentText.Length - dotPosition > 2)
            {
                e.Handled = true;
            }
        }
    }

    private void txt_Sdt_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Back)
            return;
        if (!char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
        if (((TextBox)sender).Text.Length >= 11)
        {
            e.Handled = true;
        }
    }

    private void txt_Quantity_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Back)
            return;
        if (!char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
        if (((TextBox)sender).Text.Length >= 11)
        {
            e.Handled = true;
        }
    }

    ///////////////////////// Reset TextBox /////////////////////////
    private void ResetTextBoxes()
    {
        txt_ColorCode.Text = "";
        txt_Descrip.Text = "";
        txt_Email.Text = "";
        txt_FullName.Text = "";
        txt_IdBrand.Text = "";
        txt_IdColor.Text = "";
        txt_IdLine.Text = "";
        txt_IDprd.Text = "";
        txt_IdSize.Text = "";
        txt_InfoBrand.Text = "";
        txt_Material.Text = "";
        txt_IdSize.Text = "";
        txt_NameBrand.Text = "";
        txt_NameColor.Text = "";
        txt_namePrd.Text = "";
        txt_nameUser.Text = "";
        txt_PassWord.Text = "";
        txt_SizeValue.Text = "";
        txt_Sdt.Text = "";
        txt_TypeSize.Text = "";
        price_Prd.Text = "";
        Releasedate_Prd.Value = DateTime.Now;
        txt_NameLine.Text = "";

    }


    private void ResetButton_Click(object sender, EventArgs e)
    {
        ResetTextBoxes();
    }

    //////////////////////// Table Click Data //////////////////////////

    private void tableProduct_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableProduct.Rows[e.RowIndex];

            txt_IDprd.Text = row.Cells["Idproduct"].Value.ToString();
            txt_namePrd.Text = row.Cells["NameProduct"].Value.ToString();
            cbbLine.SelectedValue = row.Cells["Idline"].Value;
            cbbBrand.SelectedValue = row.Cells["IdBrand"].Value;
            txt_Descrip.Text = row.Cells["Description"].Value.ToString();
            txt_Material.Text = row.Cells["Material"].Value.ToString();
            price_Prd.Text = row.Cells["Price"].Value.ToString();
            Releasedate_Prd.Value = Convert.ToDateTime(row.Cells["Releasedate"].Value);
            cbb_Status.Text = row.Cells["Status"].Value.ToString();
            // Lấy tên ảnh từ DataGridView
            string imageName = row.Cells["ImageUrl"].Value.ToString();
            // Xây đường dẫn đầy đủ tới thư mục chứa ảnh
            string solutionRoot = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\..\.."));
            string imageFullPath = Path.Combine(solutionRoot, "WebApp", "wwwroot", "image", "image_product", imageName);

            // Kiểm tra xem ảnh có tồn tại không
            if (File.Exists(imageFullPath))
            {
                try
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(imageFullPath);
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Ảnh bị hỏng hoặc không đúng định dạng!", "Lỗi ảnh");
                    pictureBox1.Image = null; // hoặc load ảnh mặc định
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khác: " + ex.Message);
                    pictureBox1.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Ảnh không tồn tại: ");
            }
        }
    }
    private void tableUsers_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableUsers.Rows[e.RowIndex];

            txt_idUser.Text = row.Cells["IdUser"].Value.ToString();
            txt_nameUser.Text = row.Cells["Username"].Value.ToString();
            txt_PassWord.Text = row.Cells["PasswordHash"].Value.ToString();
            txt_FullName.Text = row.Cells["FullName"].Value.ToString();
            txt_Email.Text = row.Cells["Email"].Value.ToString();
            txt_Sdt.Text = row.Cells["Phone"].Value.ToString();
            cbb_Role.SelectedValue = row.Cells["IdRole"].Value;
            cbb_Active.Text = row.Cells["IsActive"].Value.ToString();
        }
    }

    private void tableColor_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableColor.Rows[e.RowIndex];
            txt_IdColor.Text = row.Cells["IdColor"].Value.ToString();
            txt_NameColor.Text = row.Cells["NameColor"].Value.ToString();
            txt_ColorCode.Text = row.Cells["ColorCode"].Value.ToString();
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml(txt_ColorCode.Text);

        }
    }

    private void tableSize_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableSize.Rows[e.RowIndex];
            txt_IdSize.Text = row.Cells["IdSize"].Value.ToString();
            txt_SizeValue.Text = row.Cells["SizeValue"].Value.ToString();
            txt_TypeSize.Text = row.Cells["type"].Value.ToString();
        }
    }

    private void tableBrand_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableBrand.Rows[e.RowIndex];
            txt_IdBrand.Text = row.Cells["Id"].Value.ToString();
            txt_NameBrand.Text = row.Cells["Name"].Value.ToString();
            txt_InfoBrand.Text = row.Cells["Info"].Value.ToString();
        }
    }

    private void tableLine_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableLine.Rows[e.RowIndex];
            txt_IdLine.Text = row.Cells["Id"].Value.ToString();
            cbb_Category.SelectedValue = row.Cells["IdCategory"].Value;
            txt_NameLine.Text = row.Cells["Name"].Value.ToString();
        }
    }

    private void tableProductVariant_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        { // Kiểm tra dòng hợp lệ
            DataGridViewRow row = tableVariant.Rows[e.RowIndex];
            idVariant.Text = row.Cells["IdVariant"].Value.ToString();
            cbb_Product.SelectedValue = row.Cells["IdProduct"].Value;
            txt_Quantity.Text = row.Cells["Quantity"].Value.ToString();
            expired_date.Value = Convert.ToDateTime(row.Cells["ExpiredDate"].Value);
        }

    }

    private void tableInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        { // Kiểm tra dòng hợp lệ
            DataGridViewRow row = tableInvoice.Rows[e.RowIndex];
            txt_IdInvoice.Text = row.Cells["IdInvoice"].Value.ToString();
            cbb_User.SelectedValue = row.Cells["IdUser"].Value;
            txt_NameInvoice.Text = row.Cells["CustomerName"].Value.ToString();
            txxt_PhoneInvoice.Text = row.Cells["CustomerPhone"].Value.ToString();
            AddressInvoice.Text = row.Cells["CustomerAddress"].Value.ToString();
            TotalAmount.Text = row.Cells["TotalAmount"].Value.ToString();
            cbb_STTIvoice.Text = row.Cells["Status"].Value.ToString();
            DateInvoice.Value = Convert.ToDateTime(row.Cells["InvoiceDate"].Value);
        }
    }

    //////////////////////// Product //////////////////////////

    private void Add_Prd_Click(object sender, EventArgs e)
    {
        Product product = new Product()
        {
            NameProduct = txt_namePrd.Text,
            IdLine = Convert.ToInt32(cbbLine.SelectedValue),
            IdBrand = Convert.ToInt32(cbbBrand.SelectedValue),
            Description = txt_Descrip.Text,
            Material = txt_Material.Text,
            Price = Convert.ToDecimal(price_Prd.Text),
            ImageUrl = Path.GetFileName(selectedImagePath),
            Releasedate = Releasedate_Prd.Value,  // DateTimePicker
            Status = cbb_Status.SelectedItem.ToString()
        };
        bool result = productController.AddProduct(product);
        if (result)
        {
            CopyImageToWebApp(product.ImageUrl);
            MessageBox.Show("Thêm sản phẩm thành công!");
            LoadDataProduct(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Thêm sản phẩm thất bại!");
        }
    }

    private void Repair_Prd_Click(object sender, EventArgs e)
    {
        Product product = new Product()
        {
            IdProduct = Convert.ToInt32(txt_IDprd.Text),
            NameProduct = txt_namePrd.Text,
            IdLine = Convert.ToInt32(cbbLine.SelectedValue),
            IdBrand = Convert.ToInt32(cbbBrand.SelectedValue),
            Description = txt_Descrip.Text,
            Material = txt_Material.Text,
            Price = Convert.ToDecimal(price_Prd.Text),
            Releasedate = Releasedate_Prd.Value,
            ImageUrl = Path.GetFileName(selectedImagePath),
            Status = cbb_Status.SelectedItem.ToString()
        };
        bool result = productController.UpdateProduct(product);
        if (result)
        {
            CopyImageToWebApp(product.ImageUrl);
            MessageBox.Show("Cập nhật sản phẩm thành công!");
            LoadDataProduct(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Cập nhật sản phẩm thất bại!");
        }
    }

    private void Deleted_Prd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_IDprd.Text))
        {
            MessageBox.Show("Vui lòng chọn sản phẩm để xóa!");
            return;
        }

        int idProduct = int.Parse(txt_IDprd.Text);

        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            bool resul = productController.DeleteProduct(idProduct);
            if (resul)
            {
                MessageBox.Show("Xóa sản phẩm thành công!");
                LoadDataProduct(); // Cập nhật lại danh sách 
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại!");
            }
        }
    }

    private void buttonAddImage_Click(object sender, EventArgs e)
    {
        add_Image addImage = new add_Image();
        addImage.ShowDialog();
    }

    //////////////////////// User //////////////////////////
    private void add_User_Click(object sender, EventArgs e)
    {
        User user = new User()
        {
            Username = txt_nameUser.Text,
            PasswordHash = txt_PassWord.Text,
            FullName = txt_FullName.Text,
            Email = txt_Email.Text,
            Phone = Convert.ToInt32(txt_Sdt.Text),
            IdRole = Convert.ToInt32(cbb_Role.SelectedValue),
            IsActive = Convert.ToBoolean(cbb_Active.SelectedItem)
        };
        bool result = userController.AddUser(user);
        if (result)
        {
            MessageBox.Show("Thêm người dùng thành công!");
            LoadDataUser(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Thêm người dùng thất bại!");
        }
    }

    private void Repair_User_Click(object sender, EventArgs e)
    {
        User user = new User()
        {
            Username = txt_nameUser.Text,
            PasswordHash = txt_PassWord.Text,
            FullName = txt_FullName.Text,
            Email = txt_Email.Text,
            Phone = Convert.ToInt32(txt_Sdt.Text),
            IdRole = Convert.ToInt32(cbb_Role.SelectedValue),
            IsActive = Convert.ToBoolean(cbb_Active.SelectedItem)
        };
        bool result = userController.UpdateUser(user);
        if (result)
        {
            MessageBox.Show("Sửa thông tin người dùng thành công!");
            LoadDataUser(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Sửa thông tin người dùng thất bại!");
        }
    }

    private void Delete_User_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_idUser.Text))
        {
            MessageBox.Show("Vui lòng chọn người dùng!");
            return;
        }

        int idUser = int.Parse(txt_idUser.Text);

        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            bool resul = userController.DeleteUser(idUser);
            if (resul)
            {
                MessageBox.Show("Xóa người dùng thành công!");
                LoadDataUser(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa người dùng thất bại!");
            }
        }
    }

    //////////////////////// Color //////////////////////////
    private void add_Color_Click(object sender, EventArgs e)
    {
        Color color = new Color()
        {
            NameColor = txt_NameColor.Text,
            ColorCode = txt_ColorCode.Text
        };
        bool result = colorController.AddColor(color);
        if (result)
        {
            MessageBox.Show("Thêm màu thành công!");
            LoadDataColor(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Thêm màu thất bại!");
        }
    }

    private void RepairColor_Click(object sender, EventArgs e)
    {
        Color color = new Color()
        {
            IdColor = Convert.ToInt32(txt_IdColor.Text),
            NameColor = txt_NameColor.Text,
            ColorCode = txt_ColorCode.Text
        };
        bool result = colorController.UpdateColor(color);
        if (result)
        {
            MessageBox.Show("Sửa thông tin màu thành công!");
            LoadDataColor(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Sửa thông tin màu thất bại!");
        }
    }
    private void DeleteColor_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_IdColor.Text))
        {
            MessageBox.Show("Vui lòng chọn màu để xóa!");
            return;
        }
        int idColor = int.Parse(txt_IdColor.Text);
        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa màu này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            bool resul = colorController.DeleteColor(idColor);
            if (resul)
            {
                MessageBox.Show("Xóa màu thành công!");
                LoadDataColor(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa màu thất bại!");
            }
        }
    }

    private void pickcolor_Click(object sender, EventArgs e)
    {
        using (ColorDialog colorDialog = new ColorDialog())
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Color selectedColor = colorDialog.Color;
                panel1.BackColor = selectedColor;
                txt_ColorCode.Text = $"#{selectedColor.R:X2}{selectedColor.G:X2}{selectedColor.B:X2}";
            }
        }
    }
    //////////////////////// Size //////////////////////////
    private void AddSize_Click(object sender, EventArgs e)
    {
        Size size = new Size()
        {
            SizeValue = Convert.ToDecimal(txt_SizeValue.Text),
            Type = txt_TypeSize.Text
        };
        bool result = sizeController.AddSize(size);
        if (result)
        {
            MessageBox.Show("Thêm size thành công!");
            LoadDataSize(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Thêm size thất bại!");
        }
    }

    private void RepairSize_Click(object sender, EventArgs e)
    {
        Size size = new Size()
        {
            IdSize = Convert.ToInt32(txt_IdSize.Text),
            SizeValue = Convert.ToDecimal(txt_SizeValue.Text),
            Type = txt_TypeSize.Text
        };
        bool result = sizeController.UpdateSize(size);
        if (result)
        {
            MessageBox.Show("Sửa thông tin size thành công!");
            LoadDataSize(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Sửa thông tin size thất bại!");
        }
    }

    private void DeleteSize_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_IdSize.Text))
        {
            MessageBox.Show("Vui lòng chọn size để xóa!");
            return;
        }
        int idSize = int.Parse(txt_IdSize.Text);
        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa size này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            bool resul = sizeController.DeleteSize(idSize);
            if (resul)
            {
                MessageBox.Show("Xóa size thành công!");
                LoadDataSize(); // Cập nhật lại danh sách Size
            }
            else
            {
                MessageBox.Show("Xóa size thất bại!");
            }
        }
    }
    /////////////////////////////// Brand//////////////////////////////////////
    private void AddBrand_Click(object sender, EventArgs e)
    {
        Brand brand = new Brand()
        {
            Name = txt_NameBrand.Text,
            Info = txt_InfoBrand.Text
        };
        bool result = brandController.AddBrand(brand);
        if (result)
        {
            MessageBox.Show("Thêm thương hiệu thành công!");
            LoadDataBrand(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Thêm thương hiệu thất bại!");
        }
    }

    private void RepairBrand_Click(object sender, EventArgs e)
    {
        Brand brand = new Brand()
        {
            Id = Convert.ToInt32(txt_IdBrand.Text),
            Name = txt_NameBrand.Text,
            Info = txt_InfoBrand.Text
        };
        bool result = brandController.UpdateBrand(brand);
        if (result)
        {
            MessageBox.Show("Sửa thông tin thương hiệu thành công!");
            LoadDataBrand(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Sửa thông tin thương hiệu thất bại!");
        }
    }

    private void DeleteBrand_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_IdBrand.Text))
        {
            MessageBox.Show("Vui lòng chọn thương hiệu để xóa!");
            return;
        }
        int idBrand = int.Parse(txt_IdBrand.Text);
        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thương hiệu này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            bool resul = brandController.DeleteBrand(idBrand);
            if (resul)
            {
                MessageBox.Show("Xóa thương hiệu thành công!");
                LoadDataBrand(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa thương hiệu thất bại!");
            }
        }
    }

    /////////////////////////////// Line//////////////////////////////////////

    private void AddLine_Click(object sender, EventArgs e)
    {
        Line line = new Line()
        {
            Name = txt_NameLine.Text,
            IdCategory = Convert.ToInt32(cbb_Category.SelectedValue)
        };
        bool result = lineController.AddLine(line);
        if (result)
        {
            MessageBox.Show("Thêm dòng sản phẩm thành công!");
            LoadDataLine(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Thêm dòng sản phẩm thất bại!");
        }
    }

    private void RepairLine_Click(object sender, EventArgs e)
    {
        Line line = new Line()
        {
            Id = Convert.ToInt32(txt_IdLine.Text),
            Name = txt_NameLine.Text,
            IdCategory = Convert.ToInt32(cbb_Category.SelectedValue)
        };
        bool result = lineController.UpdateLine(line);
        if (result)
        {
            MessageBox.Show("Sửa thông tin dòng sản phẩm thành công!");
            LoadDataLine(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Sửa thông tin dòng sản phẩm thất bại!");
        }
    }

    private void DeleteLine_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txt_IdLine.Text))
        {
            MessageBox.Show("Vui lòng chọn dòng sản phẩm để xóa!");
            return;
        }
        int idLine = int.Parse(txt_IdLine.Text);
        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng sản phẩm này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            bool resul = lineController.DeleteLine(idLine);
            if (resul)
            {
                MessageBox.Show("Xóa dòng sản phẩm thành công!");
                LoadDataLine(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa dòng sản phẩm thất bại!");
            }
        }
    }

    private void buttonAddCategory_Click(object sender, EventArgs e)
    {
        this.Hide(); // Ẩn Form1
        using (AddCategory category = new AddCategory())
        {
            category.ShowDialog();
        }
        this.Show();
    }

    ///////////////////////////////// Variant//////////////////////////////////////

    private void AddVariant_Click(object sender, EventArgs e)
    {
        int idProduct = Convert.ToInt32(cbb_Product.SelectedValue);
        int quantity = Convert.ToInt32(txt_Quantity.Text);
        DateTime expired = expired_date.Value;

        foreach (Color selectedColor in checkedListBox2.CheckedItems)
        {
            foreach (Size selectedSize in checkedListBox1.CheckedItems)
            {
                ProductVariant variant = new ProductVariant
                {
                    IdProduct = idProduct,
                    IdColor = selectedColor.IdColor,
                    IdSize = selectedSize.IdSize,
                    Quantity = quantity,
                    ExpiredDate = expired
                };

                bool result = productVariantController.AddProductVariant(variant);
                if (!result)
                {
                    MessageBox.Show($"Thêm thất bại: Màu {selectedColor.NameColor} - Size {selectedSize.SizeValue}");
                }
            }
        }
        LoadDataVariant(); // Cập nhật lại danh sách
    }


    private void Repair_Variant_Click(object sender, EventArgs e)
    {
        ProductVariant productVariant = new ProductVariant()
        {
            IdVariant = Convert.ToInt32(idVariant.Text),
            IdProduct = Convert.ToInt32(cbb_Product.SelectedValue),

            Quantity = Convert.ToInt32(txt_Quantity.Text),
            ExpiredDate = Convert.ToDateTime(expired_date.Value)
        };
        bool result = productVariantController.UpdateProductVariant(productVariant);
        if (result)
        {
            MessageBox.Show("Sửa thông tin biến thể sản phẩm thành công!");
            LoadDataVariant(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Sửa thông tin biến thể sản phẩm thất bại!");
        }
    }

    private void Delete_Variant_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(idVariant.Text))
        {
            MessageBox.Show("Vui lòng chọn biến thể sản phẩm để xóa!");
            return;
        }
        int idVariantValue = int.Parse(idVariant.Text);
        DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa biến thể sản phẩm này?",
                                              "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            bool resul = productVariantController.DeleteProductVariant(idVariantValue);
            if (resul)
            {
                MessageBox.Show("Xóa biến thể sản phẩm thành công!");
                LoadDataVariant(); // Cập nhật lại danh sách
            }
            else
            {
                MessageBox.Show("Xóa biến thể sản phẩm thất bại!");
            }
        }
    }

    ///////////////////////////////// Invoice //////////////////////////////////////


    private void AddInvoice_Click(object sender, EventArgs e)
    {
        Invoice invoice = new Invoice()
        {
            IdUser = Convert.ToInt32(cbb_User.SelectedValue),
            CustomerName = Convert.ToString(txt_NameInvoice.Text),
            CustomerPhone = Convert.ToString(txxt_PhoneInvoice.Text),
            CustomerAddress = Convert.ToString(AddressInvoice.Text),
            TotalAmount = decimal.TryParse(TotalAmount?.Text ?? "0", out decimal total) ? total : 0m,
            Status = cbb_STTIvoice.SelectedItem.ToString(),
            InvoiceDate = Convert.ToDateTime(DateInvoice.Value)
        };
        bool result = invoiceController.AddInvoice(invoice);
        if (result)
        {
            MessageBox.Show("Thêm hóa đơn thành công!");
            LoadDataInvoice(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Thêm hóa đơn thất bại!");
        }
    }

    private void RepairInvoice_Click(object sender, EventArgs e)
    {
        Invoice invoice = new Invoice()
        {
            IdInvoice = Convert.ToInt32(txt_IdInvoice.Text),
            IdUser = Convert.ToInt32(cbb_User.SelectedValue),
            CustomerName = Convert.ToString(txt_NameInvoice.Text),
            CustomerPhone = Convert.ToString(txxt_PhoneInvoice.Text),
            CustomerAddress = Convert.ToString(AddressInvoice.Text),
            TotalAmount = decimal.TryParse(TotalAmount?.Text ?? "0", out decimal total) ? total : 0m,
            Status = cbb_STTIvoice.SelectedItem.ToString(),
            InvoiceDate = Convert.ToDateTime(DateInvoice.Value)
        };
        bool result = invoiceController.UpdateInvoice(invoice);
        if (result)
        {
            MessageBox.Show("Sửa thông tin hóa đơn thành công!");
            LoadDataInvoice(); // Cập nhật lại danh sách
        }
        else
        {
            MessageBox.Show("Sửa thông tin hóa đơn thất bại!");
        }
    }


    /////////////////////////////////// Load dữ liệu user khi chọn combobox trong hóa đơn //////////////////////////////


    private void DisplayUserDetails(User user)
    {
        if (user != null)
        {
            txt_NameInvoice.Text = user.FullName;
            txxt_PhoneInvoice.Text = user.Phone?.ToString();
            AddressInvoice.Text = user.Email;
        }
        else
        {
            MessageBox.Show("User not found");
        }
    }

    private void cbb_User_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cbb_User.SelectedValue != null && int.TryParse(cbb_User.SelectedValue.ToString(), out int selectedId))
        {
            try
            {
                var user = userController.GetUserById(selectedId);
                DisplayUserDetails(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải thông tin người dùng: {ex.Message}", "Lỗi",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    /////////////////////////////// ảnh //////////////////////////////////////
    ///
    string selectedImagePath;
    OpenFileDialog openFileDialog = new OpenFileDialog();

    private void SetupControls()
    {
        // Thiết lập PictureBox
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        pictureBox1.BorderStyle = BorderStyle.FixedSingle;

        // Thiết lập OpenFileDialog
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
        openFileDialog.Title = "Select an Image";
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

    private void upload_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            selectedImagePath = openFileDialog.FileName;
            pictureBox1.ImageLocation = selectedImagePath;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }

    private void FakeComboColor_Click(object sender, EventArgs e)
    {
        checkedListBox1.Visible = !checkedListBox1.Visible;
    }

    private void checkedListBox1_MouseLeave(object sender, EventArgs e)
    {
        checkedListBox1.Visible = false;
    }

    private void textBox1_Click(object sender, EventArgs e)
    {
        checkedListBox2.Visible = !checkedListBox2.Visible;
    }

    private void checkedListBox2_MouseLeave(object sender, EventArgs e)
    {
        checkedListBox2.Visible = false;
    }

    private void LoadSizeToCheckedListBox()
    {
        SizeController sizeController = new SizeController();
        List<Size> sizes = sizeController.GetAllSize();

        checkedListBox1.Items.Clear();
        foreach (Size size in sizes)
        {
            checkedListBox1.Items.Add(size);
        }
    }

    private void LoadColorToCheckedListBox()
    {
        ColorController colorController = new ColorController();
        List<Color> colors = colorController.GetAllColor();
        checkedListBox2.Items.Clear();
        foreach (Color color in colors)
        {
            checkedListBox2.Items.Add(color);
        }
    }
}
