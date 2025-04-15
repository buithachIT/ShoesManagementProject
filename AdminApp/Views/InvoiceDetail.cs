using AdminApp.Controllers;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminApp.Views
{
    public partial class InvoiceDetail : Form
    {
        InvoiceController invoiceController = new InvoiceController();
        ProductVariantController productVariantController = new ProductVariantController();
        InvoiceDetailController invoiceDetailController = new InvoiceDetailController();
        ProductController productController = new ProductController();

        public InvoiceDetail()
        {
            InitializeComponent();
            LoadVariantComboBox();
            LoadInvoiceComboBox();
            LoadInvoiceDetailDataGridView();
        }

        private void LoadInvoiceDetailDataGridView()
        {
            dataGridView1.DataSource = invoiceDetailController.GetAllInvoiceDetails();
        }

        private void LoadVariantComboBox()
        {
            List<ProductVariant> variants = productVariantController.GetAllProductVariant()
                .Select(v => new ProductVariant
                {
                    IdVariant = v.IdVariant,
                    IdProduct = v.IdProduct
                }).ToList();

            cbbVariant.DataSource = variants;
            cbbVariant.DisplayMember = "IdVariant";
            cbbVariant.ValueMember = "IdVariant"; // nếu cần lấy Id nhanh
        }

        private void LoadInvoiceComboBox()
        {
            List<Invoice> invoices = invoiceController.GetInvoiceNotAllowStatus()
                .Select(i => new Invoice
                {
                    IdInvoice = i.IdInvoice,
                    CustomerName = i.CustomerName
                }).ToList();
            cbbInvoice.DataSource = invoices;
            cbbInvoice.DisplayMember = "CustomerName";
            cbbInvoice.ValueMember = "IdInvoice"; // nếu cần lấy Id nhanh
        }

        private void cbbVariant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbVariant.SelectedItem is ProductVariant selectedVariant)
            {
                int idProduct = selectedVariant.IdProduct;

                // Lấy product theo ID
                Product product = productController.GetProductById(idProduct);
                if (product != null)
                {
                    subtotal.Text = product.Price.ToString(); // format nếu muốn
                }
            }
        }
        // check quantity 
        private void Quantity_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
