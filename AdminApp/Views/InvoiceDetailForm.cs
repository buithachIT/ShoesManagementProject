﻿using AdminApp.Controllers;
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
    public partial class InvoiceDetailForm : Form
    {
        InvoiceController invoiceController = new InvoiceController();
        ProductVariantController productVariantController = new ProductVariantController();
        InvoiceDetailController invoiceDetailController = new InvoiceDetailController();
        ProductController productController = new ProductController();

        public InvoiceDetailForm()
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
            UpdateSubTotal();
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

        private void UpdateSubTotal()
        {
            if (cbbVariant.SelectedItem is ProductVariant selectedVariant)
            {
                Product product = productController.GetProductById(selectedVariant.IdProduct);

                if (product != null && decimal.TryParse(txt_Quantity.Text, out decimal quantity))
                {
                    decimal subTotal = product.Price * quantity;
                    subtotal.Text = subTotal.ToString();
                }
                else
                {
                    subtotal.Text = "";
                }
            }
        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            UpdateSubTotal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InvoiceDetail invoiceDetail = new InvoiceDetail()
            {
                IdInvoice = Convert.ToInt32(cbbInvoice.SelectedValue),
                IdVariant = Convert.ToInt32(cbbVariant.SelectedValue),
                Quantity = Convert.ToInt32(txt_Quantity.Text),
                SubTotal = Convert.ToDecimal(subtotal.Text)
            };
            bool result = invoiceDetailController.AddInvoiceDetail(invoiceDetail);
            if (result)
            {
                MessageBox.Show("Thêm hóa đơn chi tiết thành công!");
                LoadInvoiceDetailDataGridView();
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn chi tiết thất bại!");
            }

        }
    }
}
