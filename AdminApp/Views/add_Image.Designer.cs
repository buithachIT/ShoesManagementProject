﻿namespace AdminApp.Views
{
    partial class add_Image
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
            pictureBox1 = new PictureBox();
            upload = new Button();
            cbbProductName = new ComboBox();
            label1 = new Label();
            addImg = new Button();
            label2 = new Label();
            cbb_Variant = new ComboBox();
            label3 = new Label();
            cbb_Color = new ComboBox();
            delete = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightBlue;
            pictureBox1.Location = new Point(9, 359);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(209, 181);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // upload
            // 
            upload.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            upload.Location = new Point(12, 558);
            upload.Name = "upload";
            upload.Size = new Size(441, 58);
            upload.TabIndex = 1;
            upload.Text = "Upload Image";
            upload.UseVisualStyleBackColor = true;
            upload.Click += upload_Click;
            // 
            // cbbProductName
            // 
            cbbProductName.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbbProductName.FormattingEnabled = true;
            cbbProductName.Location = new Point(231, 402);
            cbbProductName.Name = "cbbProductName";
            cbbProductName.Size = new Size(222, 39);
            cbbProductName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(224, 359);
            label1.Name = "label1";
            label1.Size = new Size(96, 31);
            label1.TabIndex = 3;
            label1.Text = "Product";
            // 
            // addImg
            // 
            addImg.BackColor = Color.Aquamarine;
            addImg.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addImg.Location = new Point(520, 558);
            addImg.Name = "addImg";
            addImg.Size = new Size(222, 58);
            addImg.TabIndex = 5;
            addImg.Text = "Add Image";
            addImg.UseVisualStyleBackColor = false;
            addImg.Click += addImg_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(231, 458);
            label2.Name = "label2";
            label2.Size = new Size(87, 31);
            label2.TabIndex = 7;
            label2.Text = "Variant";
            // 
            // cbb_Variant
            // 
            cbb_Variant.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbb_Variant.FormattingEnabled = true;
            cbb_Variant.Location = new Point(231, 501);
            cbb_Variant.Name = "cbb_Variant";
            cbb_Variant.Size = new Size(222, 39);
            cbb_Variant.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(520, 359);
            label3.Name = "label3";
            label3.Size = new Size(71, 31);
            label3.TabIndex = 9;
            label3.Text = "Color";
            // 
            // cbb_Color
            // 
            cbb_Color.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbb_Color.FormattingEnabled = true;
            cbb_Color.Location = new Point(520, 402);
            cbb_Color.Name = "cbb_Color";
            cbb_Color.Size = new Size(222, 39);
            cbb_Color.TabIndex = 8;
            // 
            // delete
            // 
            delete.BackColor = Color.Red;
            delete.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            delete.Location = new Point(520, 482);
            delete.Name = "delete";
            delete.Size = new Size(222, 58);
            delete.TabIndex = 10;
            delete.Text = "Delete Image";
            delete.UseVisualStyleBackColor = false;
            delete.Click += delete_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(746, 341);
            dataGridView1.TabIndex = 11;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // add_Image
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 649);
            Controls.Add(dataGridView1);
            Controls.Add(delete);
            Controls.Add(label3);
            Controls.Add(cbb_Color);
            Controls.Add(label2);
            Controls.Add(cbb_Variant);
            Controls.Add(addImg);
            Controls.Add(label1);
            Controls.Add(cbbProductName);
            Controls.Add(upload);
            Controls.Add(pictureBox1);
            Name = "add_Image";
            Text = "add_Image";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button upload;
        private ComboBox cbbProductName;
        private Label label1;
        private Button addImg;
        private Label label2;
        private ComboBox cbb_Variant;
        private Label label3;
        private ComboBox cbb_Color;
        private Button delete;
        private DataGridView dataGridView1;
    }
}