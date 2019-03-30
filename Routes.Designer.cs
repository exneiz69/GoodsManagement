namespace GoodsManagement
{
    partial class Routes
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.CarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GoodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProvidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewRoutes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.маршрутиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutes)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CarsToolStripMenuItem,
            this.DriversToolStripMenuItem,
            this.маршрутиToolStripMenuItem,
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
            // dataGridViewRoutes
            // 
            this.dataGridViewRoutes.AllowUserToAddRows = false;
            this.dataGridViewRoutes.AllowUserToDeleteRows = false;
            this.dataGridViewRoutes.AllowUserToResizeColumns = false;
            this.dataGridViewRoutes.AllowUserToResizeRows = false;
            this.dataGridViewRoutes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewRoutes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridViewRoutes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoutes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column3});
            this.dataGridViewRoutes.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewRoutes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridViewRoutes.Location = new System.Drawing.Point(41, 130);
            this.dataGridViewRoutes.Name = "dataGridViewRoutes";
            this.dataGridViewRoutes.ReadOnly = true;
            this.dataGridViewRoutes.RowHeadersVisible = false;
            this.dataGridViewRoutes.RowTemplate.Height = 24;
            this.dataGridViewRoutes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewRoutes.Size = new System.Drawing.Size(634, 226);
            this.dataGridViewRoutes.TabIndex = 12;
            this.dataGridViewRoutes.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewRoutes_CellMouseUp);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.HeaderText = "Код";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 62;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "Точка відправлення";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Відстань";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 94;
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
            this.label2.Location = new System.Drawing.Point(157, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 28;
            this.label2.Text = "Точка відправлення";
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
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(425, 61);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 22);
            this.textBox3.TabIndex = 30;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 31;
            this.label3.Text = "Відстань (км)";
            // 
            // маршрутиToolStripMenuItem
            // 
            this.маршрутиToolStripMenuItem.Name = "маршрутиToolStripMenuItem";
            this.маршрутиToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.маршрутиToolStripMenuItem.Text = "Маршрути";
            // 
            // Routes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 553);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewRoutes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Routes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Routes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Routes_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.Routes_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CarsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProvidersToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewRoutes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem маршрутиToolStripMenuItem;
    }
}