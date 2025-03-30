using AdminApp.Controllers;
using AdminApp.Views;
using Org.BouncyCastle.Asn1.Cmp;
using Shared.Models;
using System.Xml.Linq;

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


    DatabaseHelper dbHelper = new DatabaseHelper();
    public Form1()
    {
        InitializeComponent();
        LoadDataProduct();
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
        //tableLine.DataSource = lineController.GetAllLine();
    }
    private void LoadDataBrand()
    {
        //tableBrand.DataSource = brandController.GetAllBrand();
    }
    private void LoadDataVariant()
    {
        //tableVariant.DataSource = dbHelper.GetVariant();
    }
    private void LoadDataCategory()
    {
        //tableCategory.DataSource = dbHelper.GetCategory();
    }

    // Load dữ liệu khi chuyển tab

    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (tabControl1.SelectedTab == tabProduct) // Kiểm tra nếu đang ở tab "Product"
        {
            LoadDataProduct();
        }
        else if (tabControl1.SelectedTab == tabUser) // Kiểm tra nếu đang ở tab "User"
        {
            LoadDataUser();
        }
        else if (tabControl1.SelectedTab == tabColorSize) // Kiểm tra nếu đang ở tab "Color"
        {
            LoadDataColor();
            LoadDataSize();
        }
        else if (tabControl1.SelectedTab == tabBrandLine) // Kiểm tra nếu đang ở tab "Line"
        {
            LoadDataLine();
            LoadDataBrand();
        }
        else if (tabControl1.SelectedTab == tabVariant) // Kiểm tra nếu đang ở tab "Variant"
        {
            LoadDataVariant();
        }
    }

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

    private void Add_Prd_Click(object sender, EventArgs e)
    {
        Product product = new Product()
        {
            NameProduct = txt_namePrd.Text,
            IdLine = Convert.ToInt32(cbbLine.SelectedValue),
            IdBrand = Convert.ToInt32(cbbBrand.SelectedValue),
            Description = txt_Descrip.Text,
            Material = txt_Material.Text,
            Price = Convert.ToDecimal(price_Prd.Value),
            //ImageUrl = txtImageUrl.Text,
            ImageUrl = "chưa làm tới",
            Releasedate = Releasedate_Prd.Value,  // DateTimePicker
            Status = cbb_Status.SelectedItem.ToString()
        };
        bool result = productController.AddProduct(product);
        if (result)
        {
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
            NameProduct = txt_namePrd.Text,
            IdLine = Convert.ToInt32(cbbLine.SelectedValue),
            IdBrand = Convert.ToInt32(cbbBrand.SelectedValue),
            Description = txt_Descrip.Text,
            Material = txt_Material.Text,
            Price = Convert.ToDecimal(price_Prd.Value),
            //ImageUrl = txtImageUrl.Text,
            ImageUrl = "chưa làm tới",
            Releasedate = Releasedate_Prd.Value,  // DateTimePicker
            Status = cbb_Status.SelectedItem.ToString()
        };
        bool result = productController.UpdateProduct(product);
        if (result)
        {
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
                LoadDataProduct(); // Cập nhật lại danh sách sản phẩm
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
                LoadDataUser(); // Cập nhật lại danh sách sản phẩm
            }
            else
            {
                MessageBox.Show("Xóa người dùng thất bại!");
            }
        }
    }
}
