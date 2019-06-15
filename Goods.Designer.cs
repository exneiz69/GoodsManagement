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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxAmount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxKind = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.buttonRefresh);
            this.MainPanel.Controls.Add(this.buttonDelete);
            this.MainPanel.Controls.Add(this.buttonAdd);
            this.MainPanel.Controls.Add(this.textBoxAmount);
            this.MainPanel.Controls.Add(this.label7);
            this.MainPanel.Controls.Add(this.textBoxProduct);
            this.MainPanel.Controls.Add(this.label6);
            this.MainPanel.Controls.Add(this.textBoxKind);
            this.MainPanel.Controls.Add(this.label5);
            this.MainPanel.Controls.Add(this.textBoxSearch);
            this.MainPanel.Controls.Add(this.dataGridView);
            this.MainPanel.Controls.Add(this.panelHeader);
            this.MainPanel.Location = new System.Drawing.Point(5, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(705, 515);
            this.MainPanel.TabIndex = 56;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Image = global::GoodsManagement.Properties.Resources.Refresh_32;
            this.buttonRefresh.Location = new System.Drawing.Point(82, 195);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(33, 39);
            this.buttonRefresh.TabIndex = 72;
            this.toolTip1.SetToolTip(this.buttonRefresh, "Оновити");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Image = global::GoodsManagement.Properties.Resources.Delete_32;
            this.buttonDelete.Location = new System.Drawing.Point(43, 195);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(33, 39);
            this.buttonDelete.TabIndex = 70;
            this.toolTip1.SetToolTip(this.buttonDelete, "Видалити товар");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Image = global::GoodsManagement.Properties.Resources.Add_32;
            this.buttonAdd.Location = new System.Drawing.Point(4, 195);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(33, 39);
            this.buttonAdd.TabIndex = 69;
            this.toolTip1.SetToolTip(this.buttonAdd, "Додати товар");
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.DecimalPlaces = 3;
            this.textBoxAmount.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.textBoxAmount.Location = new System.Drawing.Point(6, 168);
            this.textBoxAmount.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(68, 27);
            this.textBoxAmount.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(2, 145);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 67;
            this.label7.Text = "Кількість";
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProduct.Enabled = false;
            this.textBoxProduct.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.textBoxProduct.Location = new System.Drawing.Point(6, 115);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(399, 27);
            this.textBoxProduct.TabIndex = 66;
            this.textBoxProduct.Leave += new System.EventHandler(this.textBoxProduct_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(2, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 65;
            this.label6.Text = "Назва";
            // 
            // textBoxKind
            // 
            this.textBoxKind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxKind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxKind.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.textBoxKind.Location = new System.Drawing.Point(6, 62);
            this.textBoxKind.Name = "textBoxKind";
            this.textBoxKind.Size = new System.Drawing.Size(399, 27);
            this.textBoxKind.TabIndex = 64;
            this.textBoxKind.TextChanged += new System.EventHandler(this.textBoxKind_TextChanged);
            this.textBoxKind.Leave += new System.EventHandler(this.textBoxKind_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.label5.Location = new System.Drawing.Point(2, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 63;
            this.label5.Text = "Тип";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSearch.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.textBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.textBoxSearch.Location = new System.Drawing.Point(387, 202);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 12, 1, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(310, 27);
            this.textBoxSearch.TabIndex = 56;
            this.textBoxSearch.Text = "Пошук...";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView.Location = new System.Drawing.Point(6, 235);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(691, 272);
            this.dataGridView.TabIndex = 55;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CurrentCellChanged += new System.EventHandler(this.dataGridView_CurrentCellChanged);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.panelHeader.Controls.Add(this.labelHeader);
            this.panelHeader.Controls.Add(this.buttonClose);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(703, 36);
            this.panelHeader.TabIndex = 54;
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.panelHeader.MouseLeave += new System.EventHandler(this.panelHeader_MouseLeave);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            this.panelHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseUp);
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelHeader.ForeColor = System.Drawing.Color.White;
            this.labelHeader.Location = new System.Drawing.Point(6, 4);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(0, 22);
            this.labelHeader.TabIndex = 57;
            this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.labelHeader.MouseLeave += new System.EventHandler(this.panelHeader_MouseLeave);
            this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            this.labelHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseUp);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = global::GoodsManagement.Properties.Resources.Close_Window_26;
            this.buttonClose.Location = new System.Drawing.Point(669, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(31, 27);
            this.buttonClose.TabIndex = 54;
            this.toolTip1.SetToolTip(this.buttonClose, "Закрити");
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // Goods
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(715, 525);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(715, 525);
            this.Name = "Goods";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.Goods_Load);
            this.SizeChanged += new System.EventHandler(this.Goods_SizeChanged);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxKind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown textBoxAmount;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}