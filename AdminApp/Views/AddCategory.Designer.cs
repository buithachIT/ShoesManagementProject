namespace AdminApp.Views
{
    partial class AddCategory
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
            idCategory = new TextBox();
            label1 = new Label();
            tablecategory = new DataGridView();
            NameCategory = new TextBox();
            label2 = new Label();
            them = new Button();
            repair = new Button();
            delete = new Button();
            ((System.ComponentModel.ISupportInitialize)tablecategory).BeginInit();
            SuspendLayout();
            // 
            // idCategory
            // 
            idCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idCategory.Location = new Point(152, 245);
            idCategory.Name = "idCategory";
            idCategory.ReadOnly = true;
            idCategory.Size = new Size(337, 38);
            idCategory.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 248);
            label1.Name = "label1";
            label1.Size = new Size(36, 31);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // tablecategory
            // 
            tablecategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tablecategory.Location = new Point(12, 12);
            tablecategory.Name = "tablecategory";
            tablecategory.RowHeadersWidth = 51;
            tablecategory.Size = new Size(488, 215);
            tablecategory.TabIndex = 2;
            tablecategory.CellClick += tablecategory_CellClick;
            // 
            // NameCategory
            // 
            NameCategory.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NameCategory.Location = new Point(152, 317);
            NameCategory.Name = "NameCategory";
            NameCategory.Size = new Size(337, 38);
            NameCategory.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 320);
            label2.Name = "label2";
            label2.Size = new Size(75, 31);
            label2.TabIndex = 4;
            label2.Text = "Name";
            // 
            // them
            // 
            them.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            them.Location = new Point(12, 415);
            them.Name = "them";
            them.Size = new Size(122, 52);
            them.TabIndex = 5;
            them.Text = "Thêm";
            them.UseVisualStyleBackColor = true;
            them.Click += them_Click;
            // 
            // repair
            // 
            repair.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            repair.Location = new Point(193, 415);
            repair.Name = "repair";
            repair.Size = new Size(122, 52);
            repair.TabIndex = 6;
            repair.Text = "Sửa";
            repair.UseVisualStyleBackColor = true;
            repair.Click += repair_Click;
            // 
            // delete
            // 
            delete.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            delete.Location = new Point(367, 415);
            delete.Name = "delete";
            delete.Size = new Size(122, 52);
            delete.TabIndex = 7;
            delete.Text = "Xóa";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // AddCategory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 479);
            Controls.Add(delete);
            Controls.Add(repair);
            Controls.Add(them);
            Controls.Add(label2);
            Controls.Add(NameCategory);
            Controls.Add(tablecategory);
            Controls.Add(label1);
            Controls.Add(idCategory);
            Name = "AddCategory";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)tablecategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idCategory;
        private Label label1;
        private DataGridView tablecategory;
        private TextBox NameCategory;
        private Label label2;
        private Button them;
        private Button repair;
        private Button delete;
    }
}