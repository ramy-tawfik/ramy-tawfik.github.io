namespace Zoo_Management_System
{
    partial class ZooKeeperForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZooKeeperForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.speciesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.viewButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.animalClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.species = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.classTB = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.SpeciesTB = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.StatusTB = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.searchPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(81)))), ((int)(((byte)(73)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 105);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(5, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(596, 55);
            this.label4.TabIndex = 2;
            this.label4.Text = "Zoo Management System";
            // 
            // label5
            // 
            this.label5.AllowDrop = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(603, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(5);
            this.label5.Size = new System.Drawing.Size(277, 38);
            this.label5.TabIndex = 3;
            this.label5.Text = "Zoo Keeper Control Panel\r\n\r\n\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 666);
            this.panel2.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 62);
            this.button2.TabIndex = 5;
            this.button2.Text = "Home";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 316);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::Zoo_Managment_System.Properties.Resources.Logo1;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(126)))), ((int)(((byte)(74)))));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(215, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 96);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "View Animals";
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.ClassComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.speciesComboBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 71);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.ClassComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.IntegralHeight = false;
            this.ClassComboBox.ItemHeight = 20;
            this.ClassComboBox.Items.AddRange(new object[] {
            "All"});
            this.ClassComboBox.Location = new System.Drawing.Point(3, 40);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(195, 28);
            this.ClassComboBox.Sorted = true;
            this.ClassComboBox.TabIndex = 0;
            // 
            // statusComboBox
            // 
            this.statusComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.ItemHeight = 20;
            this.statusComboBox.Items.AddRange(new object[] {
            "All Statuses",
            "Critically Endangered",
            "Endangered",
            "Extinct in the Wild",
            "Least Concern",
            "Near Threatened",
            "Normal",
            "Vulnerable"});
            this.statusComboBox.Location = new System.Drawing.Point(204, 40);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(263, 28);
            this.statusComboBox.Sorted = true;
            this.statusComboBox.TabIndex = 1;
            // 
            // speciesComboBox
            // 
            this.speciesComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.speciesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speciesComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.speciesComboBox.FormattingEnabled = true;
            this.speciesComboBox.ItemHeight = 20;
            this.speciesComboBox.Items.AddRange(new object[] {
            "All"});
            this.speciesComboBox.Location = new System.Drawing.Point(473, 40);
            this.speciesComboBox.Name = "speciesComboBox";
            this.speciesComboBox.Size = new System.Drawing.Size(197, 28);
            this.speciesComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 35);
            this.label1.TabIndex = 3;
            this.label1.Text = "Classification";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(473, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 35);
            this.label3.TabIndex = 5;
            this.label3.Text = "Species";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(900, 129);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(175, 89);
            this.viewButton.TabIndex = 0;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(126)))), ((int)(((byte)(74)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenVertical;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.animalClass,
            this.name,
            this.species,
            this.Gender,
            this.Status});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.Location = new System.Drawing.Point(215, 241);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(126)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.DividerHeight = 1;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(865, 243);
            this.dataGridView1.TabIndex = 4;
            // 
            // animalClass
            // 
            this.animalClass.HeaderText = "Class";
            this.animalClass.MinimumWidth = 8;
            this.animalClass.Name = "animalClass";
            this.animalClass.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // species
            // 
            this.species.HeaderText = "Species";
            this.species.MinimumWidth = 8;
            this.species.Name = "species";
            this.species.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.HeaderText = "Gender";
            this.Gender.MinimumWidth = 8;
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(19)))), ((int)(((byte)(38)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(200, 625);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(892, 41);
            this.panel3.TabIndex = 5;
            // 
            // classTB
            // 
            this.classTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.classTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classTB.Location = new System.Drawing.Point(5, 5);
            this.classTB.Margin = new System.Windows.Forms.Padding(5);
            this.classTB.Name = "classTB";
            this.classTB.Size = new System.Drawing.Size(213, 26);
            this.classTB.TabIndex = 0;
            this.classTB.Text = "Class";
            this.classTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.classTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.classTB_MouseClick);
            this.classTB.TextChanged += new System.EventHandler(this.classTB_TextChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(126)))), ((int)(((byte)(74)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(126)))), ((int)(((byte)(74)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.Size = new System.Drawing.Size(892, 461);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // searchPanel
            // 
            this.searchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchPanel.Controls.Add(this.tableLayoutPanel2);
            this.searchPanel.Controls.Add(this.dataGridView2);
            this.searchPanel.Location = new System.Drawing.Point(200, 102);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(892, 517);
            this.searchPanel.TabIndex = 8;
            this.searchPanel.Visible = false;
            this.searchPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.searchPanel_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.classTB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SpeciesTB, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.nameTB, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.StatusTB, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 474);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(892, 43);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // SpeciesTB
            // 
            this.SpeciesTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SpeciesTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SpeciesTB.Location = new System.Drawing.Point(451, 5);
            this.SpeciesTB.Margin = new System.Windows.Forms.Padding(5);
            this.SpeciesTB.Name = "SpeciesTB";
            this.SpeciesTB.Size = new System.Drawing.Size(213, 26);
            this.SpeciesTB.TabIndex = 2;
            this.SpeciesTB.Text = "Species";
            this.SpeciesTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SpeciesTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SpeciesTB_MouseClick_1);
            this.SpeciesTB.TextChanged += new System.EventHandler(this.SpeciesTB_TextChanged);
            // 
            // nameTB
            // 
            this.nameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameTB.Location = new System.Drawing.Point(228, 5);
            this.nameTB.Margin = new System.Windows.Forms.Padding(5);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(213, 26);
            this.nameTB.TabIndex = 1;
            this.nameTB.Text = "Name";
            this.nameTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameTB_MouseClick);
            this.nameTB.TextChanged += new System.EventHandler(this.nameTB_TextChanged);
            // 
            // StatusTB
            // 
            this.StatusTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusTB.Location = new System.Drawing.Point(674, 5);
            this.StatusTB.Margin = new System.Windows.Forms.Padding(5);
            this.StatusTB.Name = "StatusTB";
            this.StatusTB.Size = new System.Drawing.Size(213, 26);
            this.StatusTB.TabIndex = 3;
            this.StatusTB.Text = "Status";
            this.StatusTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StatusTB.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StatusTB_MouseClick);
            this.StatusTB.TextChanged += new System.EventHandler(this.StatusTB_TextChanged);
            // 
            // ZooKeeperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(205)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1092, 666);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.searchPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ZooKeeperForm";
            this.Text = "Zoo Management - ZooKeeper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ZooKeeperForm_FormClosed);
            this.Load += new System.EventHandler(this.ZooKeeperForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.searchPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.ComboBox speciesComboBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn species;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.TextBox classTB;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox SpeciesTB;
        private System.Windows.Forms.TextBox StatusTB;
    }
}