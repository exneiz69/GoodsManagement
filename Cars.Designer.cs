namespace GoodsManagement
{
    partial class Cars
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewCars = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.DriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProvidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.автомобіліToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCars)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewCars
            // 
            this.dataGridViewCars.AllowUserToAddRows = false;
            this.dataGridViewCars.AllowUserToDeleteRows = false;
            this.dataGridViewCars.AllowUserToResizeColumns = false;
            this.dataGridViewCars.AllowUserToResizeRows = false;
            this.dataGridViewCars.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewCars.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridViewCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridViewCars.Location = new System.Drawing.Point(41, 130);
            this.dataGridViewCars.Name = "dataGridViewCars";
            this.dataGridViewCars.ReadOnly = true;
            this.dataGridViewCars.RowHeadersVisible = false;
            this.dataGridViewCars.RowTemplate.Height = 24;
            this.dataGridViewCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewCars.Size = new System.Drawing.Size(634, 226);
            this.dataGridViewCars.TabIndex = 7;
            this.dataGridViewCars.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCars_CellMouseUp);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Номер машини";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Код водія";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.автомобіліToolStripMenuItem,
            this.DriversToolStripMenuItem,
            this.RoutesToolStripMenuItem,
            this.ProvidersToolStripMenuItem,
            this.GoodsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(76, 24);
            this.toolStripMenuItem1.Text = "Таблиці";
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
            // GoodsToolStripMenuItem
            // 
            this.GoodsToolStripMenuItem.Name = "GoodsToolStripMenuItem";
            this.GoodsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.GoodsToolStripMenuItem.Text = "Перевезення";
            this.GoodsToolStripMenuItem.Click += new System.EventHandler(this.GoodsToolStripMenuItem_Click);
            // 
            // ProvidersToolStripMenuItem
            // 
            this.ProvidersToolStripMenuItem.Name = "ProvidersToolStripMenuItem";
            this.ProvidersToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.ProvidersToolStripMenuItem.Text = "Постачальники";
            this.ProvidersToolStripMenuItem.Click += new System.EventHandler(this.ProvidersToolStripMenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 22);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(160, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(259, 22);
            this.textBox2.TabIndex = 10;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Номер машини";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "ПІП водія";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(41, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(122, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Видалити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(215, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Оновити";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // автомобіліToolStripMenuItem
            // 
            this.автомобіліToolStripMenuItem.Name = "автомобіліToolStripMenuItem";
            this.автомобіліToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.автомобіліToolStripMenuItem.Text = "Автомобілі";
            // 
            // Cars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridViewCars);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Cars";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Автомобілі";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Cars_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Cars_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCars)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewCars;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem DriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RoutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProvidersToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem автомобіліToolStripMenuItem;
    }
}

