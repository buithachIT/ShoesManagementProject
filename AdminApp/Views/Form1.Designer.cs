namespace AdminApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabControl1 = new TabControl();
        tabProduct = new TabPage();
        price_Prd = new NumericUpDown();
        Releasedate_Prd = new DateTimePicker();
        cbb_Status = new ComboBox();
        label10 = new Label();
        label9 = new Label();
        label7 = new Label();
        txt_Material = new TextBox();
        label6 = new Label();
        buttonAddImage = new Button();
        txt_Descrip = new TextBox();
        label5 = new Label();
        cbbBrand = new ComboBox();
        cbbLine = new ComboBox();
        label4 = new Label();
        label3 = new Label();
        txt_namePrd = new TextBox();
        label2 = new Label();
        txt_IDprd = new TextBox();
        label1 = new Label();
        Repair_Prd = new Button();
        Deleted_Prd = new Button();
        Add_Prd = new Button();
        tableProduct = new DataGridView();
        tabUser = new TabPage();
        txt_Sdt = new NumericUpDown();
        cbb_Active = new ComboBox();
        cbb_Role = new ComboBox();
        label15 = new Label();
        label16 = new Label();
        label17 = new Label();
        txt_FullName = new TextBox();
        txt_PassWord = new TextBox();
        txt_Email = new TextBox();
        label8 = new Label();
        label11 = new Label();
        label12 = new Label();
        txt_nameUser = new TextBox();
        label13 = new Label();
        txt_idUser = new TextBox();
        label14 = new Label();
        Repair_User = new Button();
        Delete_User = new Button();
        add_User = new Button();
        tableUsers = new DataGridView();
        tabColorSize = new TabPage();
        textBox14 = new TextBox();
        textBox15 = new TextBox();
        textBox16 = new TextBox();
        label23 = new Label();
        label24 = new Label();
        label25 = new Label();
        textBox13 = new TextBox();
        textBox12 = new TextBox();
        textBox11 = new TextBox();
        label22 = new Label();
        label21 = new Label();
        label20 = new Label();
        button11 = new Button();
        button12 = new Button();
        button13 = new Button();
        button10 = new Button();
        button9 = new Button();
        button8 = new Button();
        label19 = new Label();
        tableSize = new DataGridView();
        label18 = new Label();
        tableColor = new DataGridView();
        tabBrandLine = new TabPage();
        buttonAddCategory = new Button();
        comboBox6 = new ComboBox();
        textBox20 = new TextBox();
        label32 = new Label();
        label31 = new Label();
        button17 = new Button();
        button18 = new Button();
        button19 = new Button();
        button16 = new Button();
        button15 = new Button();
        button14 = new Button();
        textBox19 = new TextBox();
        label30 = new Label();
        textBox18 = new TextBox();
        label29 = new Label();
        textBox17 = new TextBox();
        label28 = new Label();
        label27 = new Label();
        label26 = new Label();
        tableLine = new DataGridView();
        tableBrand = new DataGridView();
        tabVariant = new TabPage();
        dateTimePicker2 = new DateTimePicker();
        textBox22 = new TextBox();
        comboBox9 = new ComboBox();
        comboBox8 = new ComboBox();
        comboBox7 = new ComboBox();
        textBox21 = new TextBox();
        label38 = new Label();
        label37 = new Label();
        label36 = new Label();
        label35 = new Label();
        label34 = new Label();
        label33 = new Label();
        button23 = new Button();
        button22 = new Button();
        button21 = new Button();
        tableVariant = new DataGridView();
        tabPage10 = new TabPage();
        dataGridView8 = new DataGridView();
        tabPage11 = new TabPage();
        dataGridView9 = new DataGridView();
        tabControl1.SuspendLayout();
        tabProduct.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)price_Prd).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tableProduct).BeginInit();
        tabUser.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)txt_Sdt).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tableUsers).BeginInit();
        tabColorSize.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tableSize).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tableColor).BeginInit();
        tabBrandLine.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tableLine).BeginInit();
        ((System.ComponentModel.ISupportInitialize)tableBrand).BeginInit();
        tabVariant.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)tableVariant).BeginInit();
        tabPage10.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView8).BeginInit();
        tabPage11.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView9).BeginInit();
        SuspendLayout();
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabProduct);
        tabControl1.Controls.Add(tabUser);
        tabControl1.Controls.Add(tabColorSize);
        tabControl1.Controls.Add(tabBrandLine);
        tabControl1.Controls.Add(tabVariant);
        tabControl1.Controls.Add(tabPage10);
        tabControl1.Controls.Add(tabPage11);
        tabControl1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        tabControl1.Location = new Point(12, 12);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1141, 693);
        tabControl1.TabIndex = 0;
        tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
        // 
        // tabProduct
        // 
        tabProduct.Controls.Add(price_Prd);
        tabProduct.Controls.Add(Releasedate_Prd);
        tabProduct.Controls.Add(cbb_Status);
        tabProduct.Controls.Add(label10);
        tabProduct.Controls.Add(label9);
        tabProduct.Controls.Add(label7);
        tabProduct.Controls.Add(txt_Material);
        tabProduct.Controls.Add(label6);
        tabProduct.Controls.Add(buttonAddImage);
        tabProduct.Controls.Add(txt_Descrip);
        tabProduct.Controls.Add(label5);
        tabProduct.Controls.Add(cbbBrand);
        tabProduct.Controls.Add(cbbLine);
        tabProduct.Controls.Add(label4);
        tabProduct.Controls.Add(label3);
        tabProduct.Controls.Add(txt_namePrd);
        tabProduct.Controls.Add(label2);
        tabProduct.Controls.Add(txt_IDprd);
        tabProduct.Controls.Add(label1);
        tabProduct.Controls.Add(Repair_Prd);
        tabProduct.Controls.Add(Deleted_Prd);
        tabProduct.Controls.Add(Add_Prd);
        tabProduct.Controls.Add(tableProduct);
        tabProduct.Location = new Point(4, 37);
        tabProduct.Name = "tabProduct";
        tabProduct.Padding = new Padding(3);
        tabProduct.Size = new Size(1133, 652);
        tabProduct.TabIndex = 0;
        tabProduct.Text = "Product";
        tabProduct.UseVisualStyleBackColor = true;
        // 
        // price_Prd
        // 
        price_Prd.Location = new Point(580, 409);
        price_Prd.Name = "price_Prd";
        price_Prd.Size = new Size(207, 34);
        price_Prd.TabIndex = 26;
        // 
        // Releasedate_Prd
        // 
        Releasedate_Prd.Location = new Point(468, 587);
        Releasedate_Prd.Name = "Releasedate_Prd";
        Releasedate_Prd.Size = new Size(319, 34);
        Releasedate_Prd.TabIndex = 25;
        // 
        // cbb_Status
        // 
        cbb_Status.FormattingEnabled = true;
        cbb_Status.Items.AddRange(new object[] { "Còn Hàng", "Hết Hàng" });
        cbb_Status.Location = new Point(580, 473);
        cbb_Status.Name = "cbb_Status";
        cbb_Status.Size = new Size(207, 36);
        cbb_Status.TabIndex = 24;
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(468, 476);
        label10.Name = "label10";
        label10.Size = new Size(65, 28);
        label10.TabIndex = 23;
        label10.Text = "Status";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(468, 538);
        label9.Name = "label9";
        label9.Size = new Size(115, 28);
        label9.TabIndex = 21;
        label9.Text = "Releasedate";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(465, 411);
        label7.Name = "label7";
        label7.Size = new Size(54, 28);
        label7.TabIndex = 17;
        label7.Text = "Price";
        // 
        // txt_Material
        // 
        txt_Material.Location = new Point(580, 342);
        txt_Material.Name = "txt_Material";
        txt_Material.Size = new Size(207, 34);
        txt_Material.TabIndex = 16;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(465, 345);
        label6.Name = "label6";
        label6.Size = new Size(84, 28);
        label6.TabIndex = 15;
        label6.Text = "Material";
        // 
        // buttonAddImage
        // 
        buttonAddImage.Location = new Point(1011, 570);
        buttonAddImage.Name = "buttonAddImage";
        buttonAddImage.Size = new Size(107, 41);
        buttonAddImage.TabIndex = 14;
        buttonAddImage.Text = "Thêm ảnh";
        buttonAddImage.UseVisualStyleBackColor = true;
        buttonAddImage.Click += buttonAddImage_Click;
        // 
        // txt_Descrip
        // 
        txt_Descrip.Location = new Point(131, 593);
        txt_Descrip.Name = "txt_Descrip";
        txt_Descrip.Size = new Size(207, 34);
        txt_Descrip.TabIndex = 13;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(16, 593);
        label5.Name = "label5";
        label5.Size = new Size(112, 28);
        label5.TabIndex = 12;
        label5.Text = "Description";
        // 
        // cbbBrand
        // 
        cbbBrand.FormattingEnabled = true;
        cbbBrand.Location = new Point(131, 535);
        cbbBrand.Name = "cbbBrand";
        cbbBrand.Size = new Size(207, 36);
        cbbBrand.TabIndex = 11;
        // 
        // cbbLine
        // 
        cbbLine.FormattingEnabled = true;
        cbbLine.Location = new Point(131, 473);
        cbbLine.Name = "cbbLine";
        cbbLine.Size = new Size(207, 36);
        cbbLine.TabIndex = 10;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(16, 535);
        label4.Name = "label4";
        label4.Size = new Size(63, 28);
        label4.TabIndex = 9;
        label4.Text = "Brand";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(16, 473);
        label3.Name = "label3";
        label3.Size = new Size(47, 28);
        label3.TabIndex = 8;
        label3.Text = "Line";
        // 
        // txt_namePrd
        // 
        txt_namePrd.Location = new Point(131, 408);
        txt_namePrd.Name = "txt_namePrd";
        txt_namePrd.Size = new Size(207, 34);
        txt_namePrd.TabIndex = 7;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(16, 408);
        label2.Name = "label2";
        label2.Size = new Size(41, 28);
        label2.TabIndex = 6;
        label2.Text = "Tên";
        // 
        // txt_IDprd
        // 
        txt_IDprd.Enabled = false;
        txt_IDprd.Location = new Point(131, 342);
        txt_IDprd.Name = "txt_IDprd";
        txt_IDprd.ReadOnly = true;
        txt_IDprd.Size = new Size(207, 34);
        txt_IDprd.TabIndex = 5;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(16, 342);
        label1.Name = "label1";
        label1.Size = new Size(31, 28);
        label1.TabIndex = 4;
        label1.Text = "ID";
        // 
        // Repair_Prd
        // 
        Repair_Prd.Location = new Point(1011, 444);
        Repair_Prd.Name = "Repair_Prd";
        Repair_Prd.Size = new Size(107, 41);
        Repair_Prd.TabIndex = 3;
        Repair_Prd.Text = "Sửa";
        Repair_Prd.UseVisualStyleBackColor = true;
        Repair_Prd.Click += Repair_Prd_Click;
        // 
        // Deleted_Prd
        // 
        Deleted_Prd.Location = new Point(1011, 509);
        Deleted_Prd.Name = "Deleted_Prd";
        Deleted_Prd.Size = new Size(107, 41);
        Deleted_Prd.TabIndex = 2;
        Deleted_Prd.Text = "Xóa";
        Deleted_Prd.UseVisualStyleBackColor = true;
        Deleted_Prd.Click += Deleted_Prd_Click;
        // 
        // Add_Prd
        // 
        Add_Prd.Location = new Point(1011, 380);
        Add_Prd.Name = "Add_Prd";
        Add_Prd.Size = new Size(107, 41);
        Add_Prd.TabIndex = 1;
        Add_Prd.Text = "Thêm";
        Add_Prd.UseVisualStyleBackColor = true;
        Add_Prd.Click += Add_Prd_Click;
        // 
        // tableProduct
        // 
        tableProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tableProduct.Location = new Point(16, 15);
        tableProduct.Name = "tableProduct";
        tableProduct.RowHeadersWidth = 51;
        tableProduct.Size = new Size(1102, 294);
        tableProduct.TabIndex = 0;
        tableProduct.CellClick += tableProduct_CellClick;
        // 
        // tabUser
        // 
        tabUser.Controls.Add(txt_Sdt);
        tabUser.Controls.Add(cbb_Active);
        tabUser.Controls.Add(cbb_Role);
        tabUser.Controls.Add(label15);
        tabUser.Controls.Add(label16);
        tabUser.Controls.Add(label17);
        tabUser.Controls.Add(txt_FullName);
        tabUser.Controls.Add(txt_PassWord);
        tabUser.Controls.Add(txt_Email);
        tabUser.Controls.Add(label8);
        tabUser.Controls.Add(label11);
        tabUser.Controls.Add(label12);
        tabUser.Controls.Add(txt_nameUser);
        tabUser.Controls.Add(label13);
        tabUser.Controls.Add(txt_idUser);
        tabUser.Controls.Add(label14);
        tabUser.Controls.Add(Repair_User);
        tabUser.Controls.Add(Delete_User);
        tabUser.Controls.Add(add_User);
        tabUser.Controls.Add(tableUsers);
        tabUser.Location = new Point(4, 37);
        tabUser.Name = "tabUser";
        tabUser.Padding = new Padding(3);
        tabUser.Size = new Size(1133, 652);
        tabUser.TabIndex = 1;
        tabUser.Text = "User";
        tabUser.UseVisualStyleBackColor = true;
        // 
        // txt_Sdt
        // 
        txt_Sdt.Location = new Point(663, 352);
        txt_Sdt.Name = "txt_Sdt";
        txt_Sdt.Size = new Size(207, 34);
        txt_Sdt.TabIndex = 32;
        // 
        // cbb_Active
        // 
        cbb_Active.FormattingEnabled = true;
        cbb_Active.Items.AddRange(new object[] { "0", "1" });
        cbb_Active.Location = new Point(663, 479);
        cbb_Active.Name = "cbb_Active";
        cbb_Active.Size = new Size(207, 36);
        cbb_Active.TabIndex = 31;
        // 
        // cbb_Role
        // 
        cbb_Role.FormattingEnabled = true;
        cbb_Role.Location = new Point(663, 417);
        cbb_Role.Name = "cbb_Role";
        cbb_Role.Size = new Size(207, 36);
        cbb_Role.TabIndex = 30;
        // 
        // label15
        // 
        label15.AutoSize = true;
        label15.Location = new Point(564, 482);
        label15.Name = "label15";
        label15.Size = new Size(66, 28);
        label15.TabIndex = 28;
        label15.Text = "Active";
        // 
        // label16
        // 
        label16.AutoSize = true;
        label16.Location = new Point(564, 417);
        label16.Name = "label16";
        label16.Size = new Size(50, 28);
        label16.TabIndex = 27;
        label16.Text = "Role";
        // 
        // label17
        // 
        label17.AutoSize = true;
        label17.Location = new Point(564, 351);
        label17.Name = "label17";
        label17.Size = new Size(42, 28);
        label17.TabIndex = 26;
        label17.Text = "Sđt";
        // 
        // txt_FullName
        // 
        txt_FullName.Location = new Point(125, 538);
        txt_FullName.Name = "txt_FullName";
        txt_FullName.Size = new Size(207, 34);
        txt_FullName.TabIndex = 25;
        // 
        // txt_PassWord
        // 
        txt_PassWord.Location = new Point(125, 479);
        txt_PassWord.Name = "txt_PassWord";
        txt_PassWord.Size = new Size(207, 34);
        txt_PassWord.TabIndex = 24;
        // 
        // txt_Email
        // 
        txt_Email.Location = new Point(125, 602);
        txt_Email.Name = "txt_Email";
        txt_Email.Size = new Size(207, 34);
        txt_Email.TabIndex = 23;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(10, 602);
        label8.Name = "label8";
        label8.Size = new Size(59, 28);
        label8.TabIndex = 22;
        label8.Text = "Email";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(10, 544);
        label11.Name = "label11";
        label11.Size = new Size(95, 28);
        label11.TabIndex = 19;
        label11.Text = "FullName";
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Location = new Point(10, 482);
        label12.Name = "label12";
        label12.Size = new Size(97, 28);
        label12.TabIndex = 18;
        label12.Text = "PassWord";
        // 
        // txt_nameUser
        // 
        txt_nameUser.Location = new Point(125, 417);
        txt_nameUser.Name = "txt_nameUser";
        txt_nameUser.Size = new Size(207, 34);
        txt_nameUser.TabIndex = 17;
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new Point(10, 417);
        label13.Name = "label13";
        label13.Size = new Size(103, 28);
        label13.TabIndex = 16;
        label13.Text = "UserName";
        // 
        // txt_idUser
        // 
        txt_idUser.Enabled = false;
        txt_idUser.Location = new Point(125, 351);
        txt_idUser.Name = "txt_idUser";
        txt_idUser.ReadOnly = true;
        txt_idUser.Size = new Size(207, 34);
        txt_idUser.TabIndex = 15;
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(10, 351);
        label14.Name = "label14";
        label14.Size = new Size(31, 28);
        label14.TabIndex = 14;
        label14.Text = "ID";
        // 
        // Repair_User
        // 
        Repair_User.Location = new Point(1020, 474);
        Repair_User.Name = "Repair_User";
        Repair_User.Size = new Size(107, 41);
        Repair_User.TabIndex = 6;
        Repair_User.Text = "Sửa";
        Repair_User.UseVisualStyleBackColor = true;
        Repair_User.Click += Repair_User_Click;
        // 
        // Delete_User
        // 
        Delete_User.Location = new Point(1020, 539);
        Delete_User.Name = "Delete_User";
        Delete_User.Size = new Size(107, 41);
        Delete_User.TabIndex = 5;
        Delete_User.Text = "Xóa";
        Delete_User.UseVisualStyleBackColor = true;
        Delete_User.Click += Delete_User_Click;
        // 
        // add_User
        // 
        add_User.Location = new Point(1020, 410);
        add_User.Name = "add_User";
        add_User.Size = new Size(107, 41);
        add_User.TabIndex = 4;
        add_User.Text = "Thêm";
        add_User.UseVisualStyleBackColor = true;
        add_User.Click += add_User_Click;
        // 
        // tableUsers
        // 
        tableUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tableUsers.Location = new Point(6, 6);
        tableUsers.Name = "tableUsers";
        tableUsers.RowHeadersWidth = 51;
        tableUsers.Size = new Size(1121, 328);
        tableUsers.TabIndex = 0;
        tableUsers.CellClick += tableUsers_CellClick;
        // 
        // tabColorSize
        // 
        tabColorSize.Controls.Add(textBox14);
        tabColorSize.Controls.Add(textBox15);
        tabColorSize.Controls.Add(textBox16);
        tabColorSize.Controls.Add(label23);
        tabColorSize.Controls.Add(label24);
        tabColorSize.Controls.Add(label25);
        tabColorSize.Controls.Add(textBox13);
        tabColorSize.Controls.Add(textBox12);
        tabColorSize.Controls.Add(textBox11);
        tabColorSize.Controls.Add(label22);
        tabColorSize.Controls.Add(label21);
        tabColorSize.Controls.Add(label20);
        tabColorSize.Controls.Add(button11);
        tabColorSize.Controls.Add(button12);
        tabColorSize.Controls.Add(button13);
        tabColorSize.Controls.Add(button10);
        tabColorSize.Controls.Add(button9);
        tabColorSize.Controls.Add(button8);
        tabColorSize.Controls.Add(label19);
        tabColorSize.Controls.Add(tableSize);
        tabColorSize.Controls.Add(label18);
        tabColorSize.Controls.Add(tableColor);
        tabColorSize.Location = new Point(4, 37);
        tabColorSize.Name = "tabColorSize";
        tabColorSize.Padding = new Padding(3);
        tabColorSize.Size = new Size(1133, 652);
        tabColorSize.TabIndex = 2;
        tabColorSize.Text = "Color & Size";
        tabColorSize.UseVisualStyleBackColor = true;
        // 
        // textBox14
        // 
        textBox14.BackColor = SystemColors.Window;
        textBox14.Location = new Point(773, 515);
        textBox14.Name = "textBox14";
        textBox14.Size = new Size(339, 34);
        textBox14.TabIndex = 21;
        // 
        // textBox15
        // 
        textBox15.Location = new Point(773, 450);
        textBox15.Name = "textBox15";
        textBox15.Size = new Size(339, 34);
        textBox15.TabIndex = 20;
        // 
        // textBox16
        // 
        textBox16.Location = new Point(773, 380);
        textBox16.Name = "textBox16";
        textBox16.Size = new Size(339, 34);
        textBox16.TabIndex = 19;
        // 
        // label23
        // 
        label23.AutoSize = true;
        label23.Location = new Point(623, 515);
        label23.Name = "label23";
        label23.Size = new Size(53, 28);
        label23.TabIndex = 18;
        label23.Text = "Type";
        // 
        // label24
        // 
        label24.AutoSize = true;
        label24.Location = new Point(623, 450);
        label24.Name = "label24";
        label24.Size = new Size(99, 28);
        label24.TabIndex = 17;
        label24.Text = "Size Value";
        // 
        // label25
        // 
        label25.AutoSize = true;
        label25.Location = new Point(623, 383);
        label25.Name = "label25";
        label25.Size = new Size(31, 28);
        label25.TabIndex = 16;
        label25.Text = "ID";
        // 
        // textBox13
        // 
        textBox13.BackColor = SystemColors.Window;
        textBox13.Location = new Point(165, 515);
        textBox13.Name = "textBox13";
        textBox13.Size = new Size(339, 34);
        textBox13.TabIndex = 15;
        // 
        // textBox12
        // 
        textBox12.Location = new Point(165, 450);
        textBox12.Name = "textBox12";
        textBox12.Size = new Size(339, 34);
        textBox12.TabIndex = 14;
        // 
        // textBox11
        // 
        textBox11.Location = new Point(165, 380);
        textBox11.Name = "textBox11";
        textBox11.Size = new Size(339, 34);
        textBox11.TabIndex = 13;
        // 
        // label22
        // 
        label22.AutoSize = true;
        label22.Location = new Point(15, 515);
        label22.Name = "label22";
        label22.Size = new Size(111, 28);
        label22.TabIndex = 12;
        label22.Text = "Color Code";
        // 
        // label21
        // 
        label21.AutoSize = true;
        label21.Location = new Point(15, 450);
        label21.Name = "label21";
        label21.Size = new Size(117, 28);
        label21.TabIndex = 11;
        label21.Text = "Color Name";
        // 
        // label20
        // 
        label20.AutoSize = true;
        label20.Location = new Point(15, 383);
        label20.Name = "label20";
        label20.Size = new Size(31, 28);
        label20.TabIndex = 10;
        label20.Text = "ID";
        // 
        // button11
        // 
        button11.Location = new Point(1002, 585);
        button11.Name = "button11";
        button11.Size = new Size(110, 46);
        button11.TabIndex = 9;
        button11.Text = "Xóa";
        button11.UseVisualStyleBackColor = true;
        // 
        // button12
        // 
        button12.Location = new Point(805, 585);
        button12.Name = "button12";
        button12.Size = new Size(110, 46);
        button12.TabIndex = 8;
        button12.Text = "Sửa";
        button12.UseVisualStyleBackColor = true;
        // 
        // button13
        // 
        button13.Location = new Point(623, 585);
        button13.Name = "button13";
        button13.Size = new Size(110, 46);
        button13.TabIndex = 7;
        button13.Text = "Thêm";
        button13.UseVisualStyleBackColor = true;
        // 
        // button10
        // 
        button10.Location = new Point(394, 585);
        button10.Name = "button10";
        button10.Size = new Size(110, 46);
        button10.TabIndex = 6;
        button10.Text = "Xóa";
        button10.UseVisualStyleBackColor = true;
        // 
        // button9
        // 
        button9.Location = new Point(197, 585);
        button9.Name = "button9";
        button9.Size = new Size(110, 46);
        button9.TabIndex = 5;
        button9.Text = "Sửa";
        button9.UseVisualStyleBackColor = true;
        // 
        // button8
        // 
        button8.Location = new Point(15, 585);
        button8.Name = "button8";
        button8.Size = new Size(110, 46);
        button8.TabIndex = 4;
        button8.Text = "Thêm";
        button8.UseVisualStyleBackColor = true;
        // 
        // label19
        // 
        label19.AutoSize = true;
        label19.Location = new Point(627, 13);
        label19.Name = "label19";
        label19.Size = new Size(97, 28);
        label19.TabIndex = 3;
        label19.Text = "Size Table";
        // 
        // tableSize
        // 
        tableSize.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tableSize.Location = new Point(627, 44);
        tableSize.Name = "tableSize";
        tableSize.RowHeadersWidth = 51;
        tableSize.Size = new Size(489, 292);
        tableSize.TabIndex = 2;
        // 
        // label18
        // 
        label18.AutoSize = true;
        label18.Location = new Point(15, 13);
        label18.Name = "label18";
        label18.Size = new Size(110, 28);
        label18.TabIndex = 1;
        label18.Text = "Color Table";
        // 
        // tableColor
        // 
        tableColor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tableColor.Location = new Point(15, 44);
        tableColor.Name = "tableColor";
        tableColor.RowHeadersWidth = 51;
        tableColor.Size = new Size(489, 292);
        tableColor.TabIndex = 0;
        // 
        // tabBrandLine
        // 
        tabBrandLine.Controls.Add(buttonAddCategory);
        tabBrandLine.Controls.Add(comboBox6);
        tabBrandLine.Controls.Add(textBox20);
        tabBrandLine.Controls.Add(label32);
        tabBrandLine.Controls.Add(label31);
        tabBrandLine.Controls.Add(button17);
        tabBrandLine.Controls.Add(button18);
        tabBrandLine.Controls.Add(button19);
        tabBrandLine.Controls.Add(button16);
        tabBrandLine.Controls.Add(button15);
        tabBrandLine.Controls.Add(button14);
        tabBrandLine.Controls.Add(textBox19);
        tabBrandLine.Controls.Add(label30);
        tabBrandLine.Controls.Add(textBox18);
        tabBrandLine.Controls.Add(label29);
        tabBrandLine.Controls.Add(textBox17);
        tabBrandLine.Controls.Add(label28);
        tabBrandLine.Controls.Add(label27);
        tabBrandLine.Controls.Add(label26);
        tabBrandLine.Controls.Add(tableLine);
        tabBrandLine.Controls.Add(tableBrand);
        tabBrandLine.Location = new Point(4, 37);
        tabBrandLine.Name = "tabBrandLine";
        tabBrandLine.Padding = new Padding(3);
        tabBrandLine.Size = new Size(1133, 652);
        tabBrandLine.TabIndex = 4;
        tabBrandLine.Text = "Brand, Line & Category";
        tabBrandLine.UseVisualStyleBackColor = true;
        // 
        // buttonAddCategory
        // 
        buttonAddCategory.FlatStyle = FlatStyle.System;
        buttonAddCategory.Location = new Point(798, 527);
        buttonAddCategory.Name = "buttonAddCategory";
        buttonAddCategory.Size = new Size(155, 48);
        buttonAddCategory.TabIndex = 20;
        buttonAddCategory.Text = "Add Category";
        buttonAddCategory.UseVisualStyleBackColor = true;
        // 
        // comboBox6
        // 
        comboBox6.FormattingEnabled = true;
        comboBox6.Location = new Point(798, 468);
        comboBox6.Name = "comboBox6";
        comboBox6.Size = new Size(313, 36);
        comboBox6.TabIndex = 19;
        // 
        // textBox20
        // 
        textBox20.Location = new Point(798, 402);
        textBox20.Name = "textBox20";
        textBox20.Size = new Size(313, 34);
        textBox20.TabIndex = 18;
        // 
        // label32
        // 
        label32.AutoSize = true;
        label32.Location = new Point(627, 468);
        label32.Name = "label32";
        label32.Size = new Size(149, 28);
        label32.TabIndex = 17;
        label32.Text = "Name Category";
        // 
        // label31
        // 
        label31.AutoSize = true;
        label31.Location = new Point(627, 396);
        label31.Name = "label31";
        label31.Size = new Size(31, 28);
        label31.TabIndex = 16;
        label31.Text = "ID";
        // 
        // button17
        // 
        button17.Location = new Point(991, 590);
        button17.Name = "button17";
        button17.Size = new Size(120, 47);
        button17.TabIndex = 15;
        button17.Text = "Xóa";
        button17.UseVisualStyleBackColor = true;
        // 
        // button18
        // 
        button18.Location = new Point(820, 590);
        button18.Name = "button18";
        button18.Size = new Size(120, 47);
        button18.TabIndex = 14;
        button18.Text = "Sửa";
        button18.UseVisualStyleBackColor = true;
        // 
        // button19
        // 
        button19.Location = new Point(627, 590);
        button19.Name = "button19";
        button19.Size = new Size(120, 47);
        button19.TabIndex = 13;
        button19.Text = "Thêm";
        button19.UseVisualStyleBackColor = true;
        // 
        // button16
        // 
        button16.Location = new Point(379, 590);
        button16.Name = "button16";
        button16.Size = new Size(120, 47);
        button16.TabIndex = 12;
        button16.Text = "Xóa";
        button16.UseVisualStyleBackColor = true;
        // 
        // button15
        // 
        button15.Location = new Point(202, 590);
        button15.Name = "button15";
        button15.Size = new Size(120, 47);
        button15.TabIndex = 11;
        button15.Text = "Sửa";
        button15.UseVisualStyleBackColor = true;
        // 
        // button14
        // 
        button14.Location = new Point(15, 590);
        button14.Name = "button14";
        button14.Size = new Size(120, 47);
        button14.TabIndex = 10;
        button14.Text = "Thêm";
        button14.UseVisualStyleBackColor = true;
        // 
        // textBox19
        // 
        textBox19.Location = new Point(141, 537);
        textBox19.Name = "textBox19";
        textBox19.Size = new Size(358, 34);
        textBox19.TabIndex = 9;
        // 
        // label30
        // 
        label30.AutoSize = true;
        label30.Location = new Point(15, 537);
        label30.Name = "label30";
        label30.Size = new Size(46, 28);
        label30.TabIndex = 8;
        label30.Text = "Info";
        // 
        // textBox18
        // 
        textBox18.Location = new Point(141, 465);
        textBox18.Name = "textBox18";
        textBox18.Size = new Size(358, 34);
        textBox18.TabIndex = 7;
        // 
        // label29
        // 
        label29.AutoSize = true;
        label29.Location = new Point(15, 465);
        label29.Name = "label29";
        label29.Size = new Size(120, 28);
        label29.TabIndex = 6;
        label29.Text = "Name Brand";
        // 
        // textBox17
        // 
        textBox17.Location = new Point(141, 396);
        textBox17.Name = "textBox17";
        textBox17.Size = new Size(358, 34);
        textBox17.TabIndex = 5;
        // 
        // label28
        // 
        label28.AutoSize = true;
        label28.Location = new Point(15, 396);
        label28.Name = "label28";
        label28.Size = new Size(31, 28);
        label28.TabIndex = 4;
        label28.Text = "ID";
        // 
        // label27
        // 
        label27.AutoSize = true;
        label27.Location = new Point(627, 12);
        label27.Name = "label27";
        label27.Size = new Size(47, 28);
        label27.TabIndex = 3;
        label27.Text = "Line";
        // 
        // label26
        // 
        label26.AutoSize = true;
        label26.Location = new Point(15, 12);
        label26.Name = "label26";
        label26.Size = new Size(63, 28);
        label26.TabIndex = 2;
        label26.Text = "Brand";
        // 
        // tableLine
        // 
        tableLine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tableLine.Location = new Point(627, 56);
        tableLine.Name = "tableLine";
        tableLine.RowHeadersWidth = 51;
        tableLine.Size = new Size(484, 308);
        tableLine.TabIndex = 1;
        // 
        // tableBrand
        // 
        tableBrand.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tableBrand.Location = new Point(15, 56);
        tableBrand.Name = "tableBrand";
        tableBrand.RowHeadersWidth = 51;
        tableBrand.Size = new Size(484, 308);
        tableBrand.TabIndex = 0;
        // 
        // tabVariant
        // 
        tabVariant.Controls.Add(dateTimePicker2);
        tabVariant.Controls.Add(textBox22);
        tabVariant.Controls.Add(comboBox9);
        tabVariant.Controls.Add(comboBox8);
        tabVariant.Controls.Add(comboBox7);
        tabVariant.Controls.Add(textBox21);
        tabVariant.Controls.Add(label38);
        tabVariant.Controls.Add(label37);
        tabVariant.Controls.Add(label36);
        tabVariant.Controls.Add(label35);
        tabVariant.Controls.Add(label34);
        tabVariant.Controls.Add(label33);
        tabVariant.Controls.Add(button23);
        tabVariant.Controls.Add(button22);
        tabVariant.Controls.Add(button21);
        tabVariant.Controls.Add(tableVariant);
        tabVariant.Location = new Point(4, 37);
        tabVariant.Name = "tabVariant";
        tabVariant.Padding = new Padding(3);
        tabVariant.Size = new Size(1133, 652);
        tabVariant.TabIndex = 6;
        tabVariant.Text = "Variant";
        tabVariant.UseVisualStyleBackColor = true;
        // 
        // dateTimePicker2
        // 
        dateTimePicker2.Location = new Point(569, 550);
        dateTimePicker2.Name = "dateTimePicker2";
        dateTimePicker2.Size = new Size(315, 34);
        dateTimePicker2.TabIndex = 15;
        // 
        // textBox22
        // 
        textBox22.Location = new Point(565, 459);
        textBox22.Name = "textBox22";
        textBox22.Size = new Size(277, 34);
        textBox22.TabIndex = 14;
        // 
        // comboBox9
        // 
        comboBox9.FormattingEnabled = true;
        comboBox9.Location = new Point(565, 365);
        comboBox9.Name = "comboBox9";
        comboBox9.Size = new Size(277, 36);
        comboBox9.TabIndex = 13;
        // 
        // comboBox8
        // 
        comboBox8.FormattingEnabled = true;
        comboBox8.Location = new Point(136, 548);
        comboBox8.Name = "comboBox8";
        comboBox8.Size = new Size(277, 36);
        comboBox8.TabIndex = 12;
        // 
        // comboBox7
        // 
        comboBox7.FormattingEnabled = true;
        comboBox7.Location = new Point(136, 457);
        comboBox7.Name = "comboBox7";
        comboBox7.Size = new Size(277, 36);
        comboBox7.TabIndex = 11;
        // 
        // textBox21
        // 
        textBox21.Location = new Point(136, 365);
        textBox21.Name = "textBox21";
        textBox21.Size = new Size(277, 34);
        textBox21.TabIndex = 10;
        // 
        // label38
        // 
        label38.AutoSize = true;
        label38.Location = new Point(442, 548);
        label38.Name = "label38";
        label38.Size = new Size(121, 28);
        label38.TabIndex = 9;
        label38.Text = "Expired date";
        // 
        // label37
        // 
        label37.AutoSize = true;
        label37.Location = new Point(442, 457);
        label37.Name = "label37";
        label37.Size = new Size(88, 28);
        label37.TabIndex = 8;
        label37.Text = "Quantity";
        // 
        // label36
        // 
        label36.AutoSize = true;
        label36.Location = new Point(442, 365);
        label36.Name = "label36";
        label36.Size = new Size(84, 28);
        label36.TabIndex = 7;
        label36.Text = "ID Color";
        // 
        // label35
        // 
        label35.AutoSize = true;
        label35.Location = new Point(6, 548);
        label35.Name = "label35";
        label35.Size = new Size(71, 28);
        label35.TabIndex = 6;
        label35.Text = "ID Size";
        // 
        // label34
        // 
        label34.AutoSize = true;
        label34.Location = new Point(6, 457);
        label34.Name = "label34";
        label34.Size = new Size(105, 28);
        label34.TabIndex = 5;
        label34.Text = "ID Product";
        // 
        // label33
        // 
        label33.AutoSize = true;
        label33.Location = new Point(6, 365);
        label33.Name = "label33";
        label33.Size = new Size(31, 28);
        label33.TabIndex = 4;
        label33.Text = "ID";
        // 
        // button23
        // 
        button23.Location = new Point(920, 548);
        button23.Name = "button23";
        button23.Size = new Size(175, 53);
        button23.TabIndex = 3;
        button23.Text = "Xóa";
        button23.UseVisualStyleBackColor = true;
        // 
        // button22
        // 
        button22.Location = new Point(920, 457);
        button22.Name = "button22";
        button22.Size = new Size(175, 53);
        button22.TabIndex = 2;
        button22.Text = "Sửa";
        button22.UseVisualStyleBackColor = true;
        // 
        // button21
        // 
        button21.Location = new Point(920, 365);
        button21.Name = "button21";
        button21.Size = new Size(175, 53);
        button21.TabIndex = 1;
        button21.Text = "Thêm";
        button21.UseVisualStyleBackColor = true;
        // 
        // tableVariant
        // 
        tableVariant.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        tableVariant.Location = new Point(6, 3);
        tableVariant.Name = "tableVariant";
        tableVariant.RowHeadersWidth = 51;
        tableVariant.Size = new Size(1121, 321);
        tableVariant.TabIndex = 0;
        tableVariant.CellClick += tableProduct_CellClick;
        // 
        // tabPage10
        // 
        tabPage10.Controls.Add(dataGridView8);
        tabPage10.Location = new Point(4, 37);
        tabPage10.Name = "tabPage10";
        tabPage10.Padding = new Padding(3);
        tabPage10.Size = new Size(1133, 652);
        tabPage10.TabIndex = 9;
        tabPage10.Text = "Bảo hành";
        tabPage10.UseVisualStyleBackColor = true;
        // 
        // dataGridView8
        // 
        dataGridView8.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView8.Location = new Point(9, 3);
        dataGridView8.Name = "dataGridView8";
        dataGridView8.RowHeadersWidth = 51;
        dataGridView8.Size = new Size(1118, 300);
        dataGridView8.TabIndex = 0;
        // 
        // tabPage11
        // 
        tabPage11.Controls.Add(dataGridView9);
        tabPage11.Location = new Point(4, 37);
        tabPage11.Name = "tabPage11";
        tabPage11.Padding = new Padding(3);
        tabPage11.Size = new Size(1133, 652);
        tabPage11.TabIndex = 10;
        tabPage11.Text = "Hóa đơn";
        tabPage11.UseVisualStyleBackColor = true;
        // 
        // dataGridView9
        // 
        dataGridView9.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView9.Location = new Point(6, 6);
        dataGridView9.Name = "dataGridView9";
        dataGridView9.RowHeadersWidth = 51;
        dataGridView9.Size = new Size(1121, 304);
        dataGridView9.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1165, 717);
        Controls.Add(tabControl1);
        Name = "Form1";
        Text = "Quản lý cửa hàng giày";
        tabControl1.ResumeLayout(false);
        tabProduct.ResumeLayout(false);
        tabProduct.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)price_Prd).EndInit();
        ((System.ComponentModel.ISupportInitialize)tableProduct).EndInit();
        tabUser.ResumeLayout(false);
        tabUser.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)txt_Sdt).EndInit();
        ((System.ComponentModel.ISupportInitialize)tableUsers).EndInit();
        tabColorSize.ResumeLayout(false);
        tabColorSize.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)tableSize).EndInit();
        ((System.ComponentModel.ISupportInitialize)tableColor).EndInit();
        tabBrandLine.ResumeLayout(false);
        tabBrandLine.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)tableLine).EndInit();
        ((System.ComponentModel.ISupportInitialize)tableBrand).EndInit();
        tabVariant.ResumeLayout(false);
        tabVariant.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)tableVariant).EndInit();
        tabPage10.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView8).EndInit();
        tabPage11.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView9).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl1;
    private TabPage tabProduct;
    private TabPage tabUser;
    private TabPage tabColorSize;
    private TabPage tabBrandLine;
    private TabPage tabVariant;
    private TabPage tabPage10;
    private TabPage tabPage11;
    private Button Add_Prd;
    private DataGridView tableProduct;
    private Label label1;
    private Button Repair_Prd;
    private Button Deleted_Prd;
    private Label label2;
    private TextBox txt_IDprd;
    private TextBox txt_namePrd;
    private Label label4;
    private Label label3;
    private TextBox txt_Descrip;
    private Label label5;
    private ComboBox cbbBrand;
    private ComboBox cbbLine;
    private Label label7;
    private TextBox txt_Material;
    private Label label6;
    private Button buttonAddImage;
    private Label label10;
    private Label label9;
    private DateTimePicker Releasedate_Prd;
    private ComboBox cbb_Status;
    private NumericUpDown price_Prd;
    private TextBox txt_FullName;
    private TextBox txt_PassWord;
    private TextBox txt_Email;
    private Label label8;
    private Label label11;
    private Label label12;
    private TextBox txt_nameUser;
    private Label label13;
    private TextBox txt_idUser;
    private Label label14;
    private Button Repair_User;
    private Button Delete_User;
    private Button add_User;
    private DataGridView tableUsers;
    private ComboBox cbb_Active;
    private ComboBox cbb_Role;
    private Label label15;
    private Label label16;
    private Label label17;
    private Button button10;
    private Button button9;
    private Button button8;
    private Label label19;
    private DataGridView tableSize;
    private Label label18;
    private DataGridView tableColor;
    private Button button11;
    private Button button12;
    private Button button13;
    private TextBox textBox13;
    private TextBox textBox12;
    private TextBox textBox11;
    private Label label22;
    private Label label21;
    private Label label20;
    private TextBox textBox14;
    private TextBox textBox15;
    private TextBox textBox16;
    private Label label23;
    private Label label24;
    private Label label25;
    private DataGridView tableLine;
    private DataGridView tableBrand;
    private Label label31;
    private Button button17;
    private Button button18;
    private Button button19;
    private Button button16;
    private Button button15;
    private Button button14;
    private TextBox textBox19;
    private Label label30;
    private TextBox textBox18;
    private Label label29;
    private TextBox textBox17;
    private Label label28;
    private Label label27;
    private Label label26;
    private Button buttonAddCategory;
    private ComboBox comboBox6;
    private TextBox textBox20;
    private Label label32;
    private DataGridView tableVariant;
    private DataGridView dataGridView8;
    private DataGridView dataGridView9;
    private Label label38;
    private Label label37;
    private Label label36;
    private Label label35;
    private Label label34;
    private Label label33;
    private Button button23;
    private Button button22;
    private Button button21;
    private DateTimePicker dateTimePicker2;
    private TextBox textBox22;
    private ComboBox comboBox9;
    private ComboBox comboBox8;
    private ComboBox comboBox7;
    private TextBox textBox21;
    private NumericUpDown txt_Sdt;
}
