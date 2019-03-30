namespace GoodsManagement
{
    partial class Drivers
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
            this.dataGridViewDrivers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProvidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.водіїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDrivers
            // 
            this.dataGridViewDrivers.AllowUserToAddRows = false;
            this.dataGridViewDrivers.AllowUserToDeleteRows = false;
            this.dataGridViewDrivers.AllowUserToResizeColumns = false;
            this.dataGridViewDrivers.AllowUserToResizeRows = false;
            this.dataGridViewDrivers.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewDrivers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridViewDrivers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrivers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewDrivers.Location = new System.Drawing.Point(41, 130);
            this.dataGridViewDrivers.Name = "dataGridViewDrivers";
            this.dataGridViewDrivers.ReadOnly = true;
            this.dataGridViewDrivers.RowHeadersVisible = false;
            this.dataGridViewDrivers.RowTemplate.Height = 24;
            this.dataGridViewDrivers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewDrivers.Size = new System.Drawing.Size(634, 226);
            this.dataGridViewDrivers.TabIndex = 10;
            this.dataGridViewDrivers.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewDrivers_CellMouseUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Код";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 62;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "ПІП водія";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CarsToolStripMenuItem,
            this.водіїToolStripMenuItem,
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
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(215, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Оновити";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(122, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "Видалити";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(41, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(160, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(259, 22);
            this.textBox2.TabIndex = 17;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 22);
            this.textBox1.TabIndex = 16;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "ПІП водія";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Код";
            // 
            // водіїToolStripMenuItem
            // 
            this.водіїToolStripMenuItem.Name = "водіїToolStripMenuItem";
            this.водіїToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.водіїToolStripMenuItem.Text = "Водії";
            // 
            // Drivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewDrivers);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Drivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Drivers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Drivers_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Drivers_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrivers)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDrivers;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RoutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProvidersToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ToolStripMenuItem водіїToolStripMenuItem;
    }
}