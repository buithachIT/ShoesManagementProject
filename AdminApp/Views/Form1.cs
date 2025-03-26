using AdminApp.Controllers;

namespace AdminApp;

public partial class Form1 : Form
{
    DatabaseHelper dbHelper = new DatabaseHelper();
    public Form1()
    {
        InitializeComponent();
        LoadDataProduct();
    }
    private void LoadDataProduct()
    {
        tableProduct.DataSource = dbHelper.GetProduct();
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
        tableLine.DataSource = dbHelper.GetLine();
    }
    private void LoadDataBrand()
    {
        tableBrand.DataSource = dbHelper.GetBrand();
    }
    private void LoadDataVariant()
    {
        tableVariant.DataSource = dbHelper.GetVariant();
    }
    private void LoadDataCategory()
    {
        //tableCategory.DataSource = dbHelper.GetCategory();
    }

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

    private void button1_Click(object sender, EventArgs e)
    {

    }
}
