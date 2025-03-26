using AdminApp.Controllers;
using Org.BouncyCastle.Asn1.Cmp;
using Shared.Models;
using System.Xml.Linq;

namespace AdminApp;

public partial class Form1 : Form
{
    ProductController productController = new ProductController();
    LineController lineController = new LineController();
    BrandController brandController = new BrandController();
    DatabaseHelper dbHelper = new DatabaseHelper();
    public Form1()
    {
        InitializeComponent();
        LoadDataProduct();
        Form1_Load();
    }
    private void LoadDataProduct()
    {
        tableProduct.DataSource = productController.GetAllProducts();
    }
    private void LoadDataUser()
    {
        tableUsers.DataSource = dbHelper.GetUsers();
    }
    private void LoadDataColor()
    {
        tableColor.DataSource = dbHelper.GetColor();
    }
    private void LoadDataSize()
    {
        tableSize.DataSource = dbHelper.GetSize();
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
        tableVariant.DataSource = dbHelper.GetVariant();
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
    // Load dữ liệu comboBox
    private void Form1_Load()
    {
        cbbLine.DataSource = lineController.GetAllLine();
        cbbLine.DisplayMember = "Name";
        cbbLine.ValueMember = "Id";
        cbbBrand.DataSource = brandController.GetAllBrand();
        cbbBrand.DisplayMember = "Name";
        cbbBrand.ValueMember = "Id";
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
        bool result = productController.AddProduct(product);
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
}
