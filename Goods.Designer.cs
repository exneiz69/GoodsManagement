namespace GoodsManagement
{
    partial class Goods
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProvidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.providerTextBox = new System.Windows.Forms.TextBox();
            this.routeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.carTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.amountTextBox = new System.Windows.Forms.NumericUpDown();
            this.codTextBox = new System.Windows.Forms.NumericUpDown();
            this.filterButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.codTextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGoods
            // 
            this.dataGridViewGoods.AllowUserToAddRows = false;
            this.dataGridViewGoods.AllowUserToDeleteRows = false;
            this.dataGridViewGoods.AllowUserToResizeColumns = false;
            this.dataGridViewGoods.AllowUserToResizeRows = false;
            this.dataGridViewGoods.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewGoods.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridViewGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumn1,
            this.DataGridViewTextBoxColumn2,
            this.DataGridViewTextBoxColumn3,
            this.DataGridViewTextBoxColumn4,
            this.DataGridViewTextBoxColumn5,
            this.DataGridViewTextBoxColumn6,
            this.DataGridViewTextBoxColumn7,
            this.DataGridViewTextBoxColumn8});
            this.dataGridViewGoods.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridViewGoods.Location = new System.Drawing.Point(24, 202);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.ReadOnly = true;
            this.dataGridViewGoods.RowHeadersVisible = false;
            this.dataGridViewGoods.RowTemplate.Height = 24;
            this.dataGridViewGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGoods.Size = new System.Drawing.Size(1150, 483);
            this.dataGridViewGoods.TabIndex = 13;
            this.dataGridViewGoods.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewGoods_CellMouseUp);
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn1.HeaderText = "Код";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            this.DataGridViewTextBoxColumn1.ReadOnly = true;
            this.DataGridViewTextBoxColumn1.Width = 62;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn2.HeaderText = "Постачальник";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            this.DataGridViewTextBoxColumn2.ReadOnly = true;
            this.DataGridViewTextBoxColumn2.Width = 131;
            // 
            // DataGridViewTextBoxColumn3
            // 
            this.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn3.HeaderText = "Маршрут";
            this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            this.DataGridViewTextBoxColumn3.ReadOnly = true;
            this.DataGridViewTextBoxColumn3.Width = 97;
            // 
            // DataGridViewTextBoxColumn4
            // 
            this.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn4.HeaderText = "Авто";
            this.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4";
            this.DataGridViewTextBoxColumn4.ReadOnly = true;
            this.DataGridViewTextBoxColumn4.Width = 68;
            // 
            // DataGridViewTextBoxColumn5
            // 
            this.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn5.HeaderText = "Тип";
            this.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5";
            this.DataGridViewTextBoxColumn5.ReadOnly = true;
            this.DataGridViewTextBoxColumn5.Width = 62;
            // 
            // DataGridViewTextBoxColumn6
            // 
            this.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn6.HeaderText = "Назва";
            this.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
            this.DataGridViewTextBoxColumn6.ReadOnly = true;
            this.DataGridViewTextBoxColumn6.Width = 77;
            // 
            // DataGridViewTextBoxColumn7
            // 
            this.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn7.HeaderText = "Кількість";
            this.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
            this.DataGridViewTextBoxColumn7.ReadOnly = true;
            this.DataGridViewTextBoxColumn7.Width = 95;
            // 
            // DataGridViewTextBoxColumn8
            // 
            this.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DataGridViewTextBoxColumn8.HeaderText = "Дата";
            this.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8";
            this.DataGridViewTextBoxColumn8.ReadOnly = true;
            this.DataGridViewTextBoxColumn8.Width = 71;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1231, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CarsToolStripMenuItem,
            this.DriversToolStripMenuItem,
            this.RoutesToolStripMenuItem,
            this.ProvidersToolStripMenuItem,
            this.GoodsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(76, 24);
            this.toolStripMenuItem1.Text = "Таблиці";
            // 
            // CarsToolStripMenuItem
            // 
            this.CarsToolStripMenuItem.Name = "CarsToolStripMenuItem";
            this.CarsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.CarsToolStripMenuItem.Text = "Автомобілі";
            this.CarsToolStripMenuItem.Click += new System.EventHandler(this.CarsToolStripMenuItem_Click);
            // 
            // DriversToolStripMenuItem
            // 
            this.DriversToolStripMenuItem.Name = "DriversToolStripMenuItem";
            this.DriversToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.DriversToolStripMenuItem.Text = "Водії";
            this.DriversToolStripMenuItem.Click += new System.EventHandler(this.DriversToolStripMenuItem_Click);
            // 
            // RoutesToolStripMenuItem
            // 
            this.RoutesToolStripMenuItem.Name = "RoutesToolStripMenuItem";
            this.RoutesToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.RoutesToolStripMenuItem.Text = "Маршрути";
            this.RoutesToolStripMenuItem.Click += new System.EventHandler(this.RoutesToolStripMenuItem_Click);
            // 
            // ProvidersToolStripMenuItem
            // 
            this.ProvidersToolStripMenuItem.Name = "ProvidersToolStripMenuItem";
            this.ProvidersToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ProvidersToolStripMenuItem.Text = "Постачальники";
            this.ProvidersToolStripMenuItem.Click += new System.EventHandler(this.ProvidersToolStripMenuItem_Click);
            // 
            // GoodsToolStripMenuItem
            // 
            this.GoodsToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.GoodsToolStripMenuItem.Name = "GoodsToolStripMenuItem";
            this.GoodsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.GoodsToolStripMenuItem.Text = "Перевезення";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 29;
            this.label1.Text = "Код";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Постачальник";
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(215, 146);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(87, 23);
            this.updateButton.TabIndex = 27;
            this.updateButton.Text = "Оновити";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Enabled = false;
            this.deleteButton.Location = new System.Drawing.Point(122, 146);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(87, 23);
            this.deleteButton.TabIndex = 26;
            this.deleteButton.Text = "Видалити";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(41, 146);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 25;
            this.addButton.Text = "Додати";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // providerTextBox
            // 
            this.providerTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.providerTextBox.Location = new System.Drawing.Point(136, 61);
            this.providerTextBox.Name = "providerTextBox";
            this.providerTextBox.ReadOnly = true;
            this.providerTextBox.Size = new System.Drawing.Size(99, 22);
            this.providerTextBox.TabIndex = 24;
            this.providerTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.providerTextBox_MouseClick);
            this.providerTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // routeTextBox
            // 
            this.routeTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.routeTextBox.Location = new System.Drawing.Point(255, 61);
            this.routeTextBox.Name = "routeTextBox";
            this.routeTextBox.ReadOnly = true;
            this.routeTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.routeTextBox.Size = new System.Drawing.Size(138, 22);
            this.routeTextBox.TabIndex = 30;
            this.routeTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.routeTextBox_MouseClick);
            this.routeTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Точка відправлення";
            // 
            // carTextBox
            // 
            this.carTextBox.Location = new System.Drawing.Point(413, 61);
            this.carTextBox.Name = "carTextBox";
            this.carTextBox.ReadOnly = true;
            this.carTextBox.Size = new System.Drawing.Size(89, 22);
            this.carTextBox.TabIndex = 32;
            this.carTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.carTextBox_MouseClick);
            this.carTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Авто";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(519, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "Тип";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(522, 61);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(194, 22);
            this.typeTextBox.TabIndex = 35;
            this.typeTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(41, 106);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(409, 22);
            this.nameTextBox.TabIndex = 36;
            this.nameTextBox.TextChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "Назва";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Кількість";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(553, 106);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(163, 22);
            this.dateTimePicker1.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(550, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "Дата";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(308, 146);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(87, 23);
            this.clearButton.TabIndex = 43;
            this.clearButton.Text = "Очистити";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(470, 106);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(63, 22);
            this.amountTextBox.TabIndex = 44;
            this.amountTextBox.ValueChanged += new System.EventHandler(this.TextBoxTextChanged);
            // 
            // codTextBox
            // 
            this.codTextBox.Location = new System.Drawing.Point(41, 61);
            this.codTextBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.codTextBox.Name = "codTextBox";
            this.codTextBox.Size = new System.Drawing.Size(75, 22);
            this.codTextBox.TabIndex = 45;
            this.codTextBox.ValueChanged += new System.EventHandler(this.TextBoxTextChanged);
            this.codTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.codTextBox_KeyDown);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(629, 146);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(87, 23);
            this.filterButton.TabIndex = 46;
            this.filterButton.Text = "Фільтр";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Постачальник",
            "Маршрут",
            "Авто",
            "Тип"});
            this.checkedListBox1.Location = new System.Drawing.Point(854, 210);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(162, 89);
            this.checkedListBox1.TabIndex = 49;
            this.checkedListBox1.Visible = false;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            this.checkedListBox1.Leave += new System.EventHandler(this.checkListBox1_Leave);
            this.checkedListBox1.MouseLeave += new System.EventHandler(this.checkListBox1_Leave);
            // 
            // Goods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 697);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.codTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.carTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.routeTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.providerTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridViewGoods);
            this.Controls.Add(this.checkedListBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Goods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Goods";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Goods_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Goods_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.codTextBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGoods;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RoutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProvidersToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox providerTextBox;
        private System.Windows.Forms.TextBox routeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox carTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.NumericUpDown amountTextBox;
        private System.Windows.Forms.NumericUpDown codTextBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn8;
        private System.Windows.Forms.ToolStripMenuItem GoodsToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}