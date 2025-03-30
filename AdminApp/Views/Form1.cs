﻿using AdminApp.Controllers;
using AdminApp.Views;
using Org.BouncyCastle.Asn1.Cmp;
using Shared.Models;
using System.Xml.Linq;
using Color = Shared.Models.Color;
using Size = Shared.Models.Size;

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
        cbbLine.DisplayMember = "NameLine";
        cbbLine.ValueMember = "IdLine";
        cbbBrand.DataSource = brandController.GetAllBrand();
        cbbBrand.DisplayMember = "NameBrand";
        cbbBrand.ValueMember = "IdBrand";
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
    }
    private void LoadDataBrand()
    {
        tableBrand.DataSource = brandController.GetAllBrand();
    }
    private void LoadDataVariant()
    {
        //tableVariant.DataSource = dbHelper.GetVariant();
    }
    private void LoadDataCategory()
    {
        //tableCategory.DataSource = dbHelper.GetCategory();
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
        }
    }

    private void tableSize_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableSize.Rows[e.RowIndex];
            txt_IdSize.Text = row.Cells["IdSize"].Value.ToString();
            txt_SizeValue.Text = row.Cells["size_vlaue"].Value.ToString();
            txt_TypeSize.Text = row.Cells["type"].Value.ToString();
        }
    }

    private void tableBrand_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Kiểm tra dòng hợp lệ
        {
            DataGridViewRow row = tableBrand.Rows[e.RowIndex];
            txt_IdBrand.Text = row.Cells["IdBrand"].Value.ToString();
            txt_NameBrand.Text = row.Cells["NameBrand"].Value.ToString();
            txt_InfoBrand.Text = row.Cells["InfoBrand"].Value.ToString();
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
            Price = Convert.ToDecimal(price_Prd.Text),
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
            NameBrand = txt_NameBrand.Text,
            InfoBrand = txt_InfoBrand.Text
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
            IdBrand = Convert.ToInt32(txt_IdBrand.Text),
            NameBrand = txt_NameBrand.Text,
            InfoBrand = txt_InfoBrand.Text
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

    
}
