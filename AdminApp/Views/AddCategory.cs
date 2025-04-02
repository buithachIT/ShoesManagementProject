using AdminApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Models;

namespace AdminApp.Views
{
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
            LoadData();
        }

        CategoryController categoryController = new CategoryController();

        private void LoadData()
        {
            tablecategory.DataSource = categoryController.GetAllCategory();
        }

        private void them_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = NameCategory.Text; // Đúng cách

            bool result = categoryController.AddCategory(category);
            if (result)
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
            LoadData();
        }


        private void repair_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            {
                category.Id = Convert.ToInt32(idCategory.Text);
                category.Name = NameCategory.Text;
            }
            ;
            bool result = categoryController.UpdateCategory(category);
            if (result)
            {
                MessageBox.Show("Sửa thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            LoadData();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idCategory.Text);
            bool result = categoryController.DeleteCategory(id);
            if (result)
            {
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            LoadData();
        }

        private void tablecategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = tablecategory.Rows[e.RowIndex];
                idCategory.Text = row.Cells["Id"].Value.ToString();
                NameCategory.Text = row.Cells["Name"].Value.ToString();
            }
        }
    }
}
