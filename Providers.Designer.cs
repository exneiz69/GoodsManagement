namespace GoodsManagement
{
    partial class Providers
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
            this.dataGridViewProviders = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.постачальникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProviders)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewProviders
            // 
            this.dataGridViewProviders.AllowUserToAddRows = false;
            this.dataGridViewProviders.AllowUserToDeleteRows = false;
            this.dataGridViewProviders.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewProviders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridViewProviders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProviders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewProviders.Location = new System.Drawing.Point(41, 130);
            this.dataGridViewProviders.Name = "dataGridViewProviders";
            this.dataGridViewProviders.ReadOnly = true;
            this.dataGridViewProviders.RowHeadersVisible = false;
            this.dataGridViewProviders.RowTemplate.Height = 24;
            this.dataGridViewProviders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewProviders.Size = new System.Drawing.Size(634, 226);
            this.dataGridViewProviders.TabIndex = 11;
            this.dataGridViewProviders.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewProviders_CellMouseUp);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Код";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 62;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Назва";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CarsToolStripMenuItem,
            this.DriversToolStripMenuItem,
            this.RoutesToolStripMenuItem,
            this.GoodsToolStripMenuItem,
            this.постачальникиToolStripMenuItem});
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
            // GoodsToolStripMenuItem
            // 
            this.GoodsToolStripMenuItem.Name = "GoodsToolStripMenuItem";
            this.GoodsToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.GoodsToolStripMenuItem.Text = "Перевезення";
            this.GoodsToolStripMenuItem.Click += new System.EventHandler(this.GoodsToolStripMenuItem_Click);
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
            this.label2.Location = new System.Drawing.Point(161, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Назва";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(215, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 27;
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
            this.button2.TabIndex = 26;
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
            this.button1.TabIndex = 25;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(160, 61);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(259, 22);
            this.textBox2.TabIndex = 24;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(41, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(113, 22);
            this.textBox1.TabIndex = 23;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // постачальникиToolStripMenuItem
            // 
            this.постачальникиToolStripMenuItem.Name = "постачальникиToolStripMenuItem";
            this.постачальникиToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.постачальникиToolStripMenuItem.Text = "Постачальники";
            // 
            // Providers
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
            this.Controls.Add(this.dataGridViewProviders);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Providers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Providers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Providers_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Providers_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProviders)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProviders;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RoutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoodsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ToolStripMenuItem постачальникиToolStripMenuItem;
    }
}