using MySql.Data.MySqlClient;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApp.Controllers
{
    class InvoiceController
    {
        private DatabaseHelper db = new DatabaseHelper();

        public List<Invoice> GetAllInvoice()
        {
            string query = "SELECT id_invoice, id_user, customerName, customerPhone, InvoiceDate, totalAmount, status, customerAddress, InvoiceDate  FROM invoice";
            DataTable dt = db.ExecuteQuery(query);
            List<Invoice> invoices = new List<Invoice>();
            foreach (DataRow row in dt.Rows)
            {
                invoices.Add(new Invoice
                {
                    IdInvoice = Convert.ToInt32(row["id_invoice"]),
                    IdUser = Convert.ToInt32(row["id_user"]),
                    CustomerName = row["customerName"].ToString(),
                    CustomerPhone = row["customerPhone"].ToString(),
                    InvoiceDate = Convert.ToDateTime(row["InvoiceDate"]),
                    TotalAmount = Convert.ToDecimal(row["totalAmount"]),
                    Status = row["status"].ToString(),
                    CustomerAddress = row["customerAddress"].ToString()
                });
            }
            return invoices;
        }

        public List<Invoice> GetInvoiceNotAllowStatus()
        {
            string query = "SELECT id_invoice, id_user, customerName, customerPhone, InvoiceDate, totalAmount, status, customerAddress, InvoiceDate  FROM invoice WHERE status = 'Đang xử lý'";
            DataTable dt = db.ExecuteQuery(query);
            List<Invoice> invoices = new List<Invoice>();
            foreach (DataRow row in dt.Rows)
            {
                invoices.Add(new Invoice
                {
                    IdInvoice = Convert.ToInt32(row["id_invoice"]),
                    IdUser = Convert.ToInt32(row["id_user"]),
                    CustomerName = row["customerName"].ToString(),
                    CustomerPhone = row["customerPhone"].ToString(),
                    InvoiceDate = Convert.ToDateTime(row["InvoiceDate"]),
                    TotalAmount = Convert.ToDecimal(row["totalAmount"]),
                    Status = row["status"].ToString(),
                    CustomerAddress = row["customerAddress"].ToString()
                });
            }
            return invoices;
        }

        public bool AddInvoice(Invoice invoice)
        {
            string query = "INSERT INTO invoice(id_user, customerName, customerPhone, InvoiceDate, totalAmount, status, customerAddress) VALUES(@id_user, @customerName, @customerPhone, @InvoiceDate, @totalAmount, @status, @customerAddress)";
            MySqlParameter[] parameters = new MySqlParameter[7];
            parameters[0] = new MySqlParameter("@id_user", invoice.IdUser);
            parameters[1] = new MySqlParameter("@customerName", invoice.CustomerName);
            parameters[2] = new MySqlParameter("@customerPhone", invoice.CustomerPhone);
            parameters[3] = new MySqlParameter("@InvoiceDate", invoice.InvoiceDate);
            parameters[4] = new MySqlParameter("@totalAmount", invoice.TotalAmount);
            parameters[5] = new MySqlParameter("@status", invoice.Status);
            parameters[6] = new MySqlParameter("@customerAddress", invoice.CustomerAddress);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool UpdateInvoice(Invoice invoice) {
            string query = "UPDATE invoice SET id_user = @id_user, customerName = @customerName, customerPhone = @customerPhone, InvoiceDate = @InvoiceDate, totalAmount = @totalAmount, status = @status, customerAddress = @customerAddress WHERE id_invoice = @id_invoice";
            MySqlParameter[] parameters = new MySqlParameter[8];
            parameters[0] = new MySqlParameter("@id_user", invoice.IdUser);
            parameters[1] = new MySqlParameter("@customerName", invoice.CustomerName);
            parameters[2] = new MySqlParameter("@customerPhone", invoice.CustomerPhone);
            parameters[3] = new MySqlParameter("@InvoiceDate", invoice.InvoiceDate);
            parameters[4] = new MySqlParameter("@totalAmount", invoice.TotalAmount);
            parameters[5] = new MySqlParameter("@status", invoice.Status);
            parameters[6] = new MySqlParameter("@customerAddress", invoice.CustomerAddress);
            parameters[7] = new MySqlParameter("@id_invoice", invoice.IdInvoice);
            return db.ExecuteNonQuery(query, parameters);
        }

        public bool DeleteInvoice(int invoice)
        {
            string query = "DELETE FROM invoice WHERE id_invoice = @id_invoice";
            MySqlParameter[] parameters = new MySqlParameter[1];
            parameters[0] = new MySqlParameter("@id_invoice", invoice);
            return db.ExecuteNonQuery(query, parameters);
        }
    }
}
