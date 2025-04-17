using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AdminApp.Controllers
{
    class InvoiceDetailController
    {
        private DatabaseHelper db = new DatabaseHelper();

        public List<InvoiceDetail> GetAllInvoiceDetails()
        {
            string query = "Select id_invoice, id_variant, quantity, sub_total FROM invoicedetail";
            DataTable dt = db.ExecuteQuery(query);
            List < InvoiceDetail> invoices = new List<InvoiceDetail>();
            foreach (DataRow row in dt.Rows) {
                invoices.Add(new InvoiceDetail
                {
                    IdInvoice = Convert.ToInt32(row["id_invoice"]),
                    IdVariant = Convert.ToInt32(row["id_variant"]),
                    Quantity = Convert.ToInt32(row["quantity"]),
                    SubTotal = Convert.ToDecimal(row["sub_total"])
                });
            }
            return invoices;
        }

        public bool AddInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            string query = "INSERT INTO invoicedetail(id_invoice, id_variant, quantity, sub_total) VALUES(@id_invoice, @id_variant, @quantity, @sub_total)";
            MySqlParameter[] parameters = new MySqlParameter[4];
            parameters[0] = new MySqlParameter("@id_invoice", invoiceDetail.IdInvoice);
            parameters[1] = new MySqlParameter("@id_variant", invoiceDetail.IdVariant);
            parameters[2] = new MySqlParameter("@quantity", invoiceDetail.Quantity);
            parameters[3] = new MySqlParameter("@sub_total", invoiceDetail.SubTotal);
            bool insertSuccess = db.ExecuteNonQuery(query, parameters);

            if (insertSuccess)
            {
                string updateQuery = @"
            UPDATE invoice
            SET totalamount = (
                SELECT SUM(sub_total)
                FROM invoicedetail
                WHERE id_invoice = @id_invoice
            )
            WHERE id_invoice = @id_invoice";

                MySqlParameter[] updateParams = {
            new MySqlParameter("@id_invoice", invoiceDetail.IdInvoice)
        };

                return db.ExecuteNonQuery(updateQuery, updateParams);
            }

            return false;
        }
    }
}
