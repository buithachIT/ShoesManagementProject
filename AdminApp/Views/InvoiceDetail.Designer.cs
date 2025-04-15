namespace AdminApp.Views
{
    partial class InvoiceDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            cbbVariant = new ComboBox();
            txt_Quantity = new TextBox();
            subtotal = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            cbbInvoice = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(613, 294);
            dataGridView1.TabIndex = 0;
            // 
            // cbbVariant
            // 
            cbbVariant.Font = new Font("Segoe UI", 14F);
            cbbVariant.FormattingEnabled = true;
            cbbVariant.Location = new Point(12, 470);
            cbbVariant.Name = "cbbVariant";
            cbbVariant.Size = new Size(249, 39);
            cbbVariant.TabIndex = 1;
            cbbVariant.SelectedIndexChanged += cbbVariant_SelectedIndexChanged;
            // 
            // txt_Quantity
            // 
            txt_Quantity.Font = new Font("Segoe UI", 14F);
            txt_Quantity.Location = new Point(376, 369);
            txt_Quantity.Name = "txt_Quantity";
            txt_Quantity.Size = new Size(249, 39);
            txt_Quantity.TabIndex = 3;
            txt_Quantity.TextChanged += txt_Quantity_TextChanged;
            txt_Quantity.KeyPress += Quantity_KeyPress;
            // 
            // subtotal
            // 
            subtotal.Enabled = false;
            subtotal.Font = new Font("Segoe UI", 14F);
            subtotal.Location = new Point(376, 470);
            subtotal.Name = "subtotal";
            subtotal.ReadOnly = true;
            subtotal.Size = new Size(249, 39);
            subtotal.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(12, 334);
            label1.Name = "label1";
            label1.Size = new Size(188, 32);
            label1.TabIndex = 5;
            label1.Text = "Customer Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(12, 435);
            label2.Name = "label2";
            label2.Size = new Size(87, 32);
            label2.TabIndex = 6;
            label2.Text = "Variant";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(376, 334);
            label3.Name = "label3";
            label3.Size = new Size(106, 32);
            label3.TabIndex = 7;
            label3.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(376, 435);
            label4.Name = "label4";
            label4.Size = new Size(110, 32);
            label4.TabIndex = 8;
            label4.Text = "Sub total";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(120, 552);
            button1.Name = "button1";
            button1.Size = new Size(141, 47);
            button1.TabIndex = 9;
            button1.Text = "Thêm";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(376, 552);
            button2.Name = "button2";
            button2.Size = new Size(141, 47);
            button2.TabIndex = 10;
            button2.Text = "Xóa";
            button2.UseVisualStyleBackColor = true;
            // 
            // cbbInvoice
            // 
            cbbInvoice.Font = new Font("Segoe UI", 14F);
            cbbInvoice.FormattingEnabled = true;
            cbbInvoice.Location = new Point(12, 369);
            cbbInvoice.Name = "cbbInvoice";
            cbbInvoice.Size = new Size(249, 39);
            cbbInvoice.TabIndex = 11;
            // 
            // InvoiceDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 621);
            Controls.Add(cbbInvoice);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(subtotal);
            Controls.Add(txt_Quantity);
            Controls.Add(cbbVariant);
            Controls.Add(dataGridView1);
            Name = "InvoiceDetail";
            Text = "InvoiceDetail";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private ComboBox cbbVariant;
        private TextBox txt_Quantity;
        private TextBox subtotal;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private ComboBox cbbInvoice;
    }
}