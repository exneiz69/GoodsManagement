﻿namespace GoodsManagement
{
    partial class Invoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.filterContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fProviderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fCarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimized = new System.Windows.Forms.Button();
            this.buttonMaximized = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxProvider = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panelButtonEdit = new System.Windows.Forms.Panel();
            this.buttonEditCancel = new System.Windows.Forms.Button();
            this.buttonEditAccept = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.panelButtonAdd = new System.Windows.Forms.Panel();
            this.buttonAddCancel = new System.Windows.Forms.Button();
            this.buttonAddAccept = new System.Windows.Forms.Button();
            this.panelButtonDelete = new System.Windows.Forms.Panel();
            this.buttonDeleteCancel = new System.Windows.Forms.Button();
            this.buttonDeleteAccept = new System.Windows.Forms.Button();
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutMainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelBehindTextBoxs = new System.Windows.Forms.Panel();
            this.panelTextBoxs = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.filterContextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panelButtonEdit.SuspendLayout();
            this.panelButtonAdd.SuspendLayout();
            this.panelButtonDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraDataGridView)).BeginInit();
            this.tableLayoutMainPanel.SuspendLayout();
            this.panelBehindTextBoxs.SuspendLayout();
            this.panelTextBoxs.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBalance});
            this.menuStrip1.Location = new System.Drawing.Point(0, 36);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(703, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemBalance
            // 
            this.toolStripMenuItemBalance.Font = new System.Drawing.Font("Cambria", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.toolStripMenuItemBalance.Name = "toolStripMenuItemBalance";
            this.toolStripMenuItemBalance.Size = new System.Drawing.Size(91, 24);
            this.toolStripMenuItemBalance.Text = "Залишки";
            this.toolStripMenuItemBalance.ToolTipText = "Переглянути залишки товарів";
            this.toolStripMenuItemBalance.Click += new System.EventHandler(this.toolStripMenuItemBalance_Click);
            // 
            // filterContextMenuStrip
            // 
            this.filterContextMenuStrip.BackColor = System.Drawing.Color.WhiteSmoke;
            this.filterContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.filterContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fProviderToolStripMenuItem,
            this.fRouteToolStripMenuItem,
            this.fCarToolStripMenuItem,
            this.fTypeToolStripMenuItem});
            this.filterContextMenuStrip.Name = "filterContextMenuStrip";
            this.filterContextMenuStrip.ShowCheckMargin = true;
            this.filterContextMenuStrip.ShowImageMargin = false;
            this.filterContextMenuStrip.Size = new System.Drawing.Size(177, 100);
            // 
            // fProviderToolStripMenuItem
            // 
            this.fProviderToolStripMenuItem.Name = "fProviderToolStripMenuItem";
            this.fProviderToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.fProviderToolStripMenuItem.Text = "Постачальник";
            this.fProviderToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // fRouteToolStripMenuItem
            // 
            this.fRouteToolStripMenuItem.Name = "fRouteToolStripMenuItem";
            this.fRouteToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.fRouteToolStripMenuItem.Text = "Маршрут";
            this.fRouteToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // fCarToolStripMenuItem
            // 
            this.fCarToolStripMenuItem.Name = "fCarToolStripMenuItem";
            this.fCarToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.fCarToolStripMenuItem.Text = "Авто";
            this.fCarToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // fTypeToolStripMenuItem
            // 
            this.fTypeToolStripMenuItem.Name = "fTypeToolStripMenuItem";
            this.fTypeToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.fTypeToolStripMenuItem.Text = "Тип";
            this.fTypeToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Image = global::GoodsManagement.Properties.Resources.Refresh_32;
            this.buttonRefresh.Location = new System.Drawing.Point(180, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(33, 39);
            this.buttonRefresh.TabIndex = 61;
            this.toolTip1.SetToolTip(this.buttonRefresh, "Оновити");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.Transparent;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Image = global::GoodsManagement.Properties.Resources.Add_32;
            this.buttonAdd.Location = new System.Drawing.Point(3, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(33, 39);
            this.buttonAdd.TabIndex = 55;
            this.toolTip1.SetToolTip(this.buttonAdd, "Додати накладну");
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Image = global::GoodsManagement.Properties.Resources.Delete_32;
            this.buttonDelete.Location = new System.Drawing.Point(49, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(33, 39);
            this.buttonDelete.TabIndex = 54;
            this.toolTip1.SetToolTip(this.buttonDelete, "Видалити накладну");
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.BackColor = System.Drawing.Color.Transparent;
            this.buttonEdit.FlatAppearance.BorderSize = 0;
            this.buttonEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEdit.Image = global::GoodsManagement.Properties.Resources.Edit_32;
            this.buttonEdit.Location = new System.Drawing.Point(95, 3);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(33, 39);
            this.buttonEdit.TabIndex = 59;
            this.toolTip1.SetToolTip(this.buttonEdit, "Змінити накладну");
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Transparent;
            this.buttonClear.Enabled = false;
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Image = global::GoodsManagement.Properties.Resources.Clear_32;
            this.buttonClear.Location = new System.Drawing.Point(141, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(33, 39);
            this.buttonClear.TabIndex = 60;
            this.toolTip1.SetToolTip(this.buttonClear, "Очистити");
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = global::GoodsManagement.Properties.Resources.Close_Window_26;
            this.buttonClose.Location = new System.Drawing.Point(668, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(31, 27);
            this.buttonClose.TabIndex = 54;
            this.toolTip1.SetToolTip(this.buttonClose, "Закрити");
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMinimized
            // 
            this.buttonMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMinimized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.buttonMinimized.FlatAppearance.BorderSize = 0;
            this.buttonMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimized.Image = global::GoodsManagement.Properties.Resources.Minimize_Window_26;
            this.buttonMinimized.Location = new System.Drawing.Point(590, 3);
            this.buttonMinimized.Name = "buttonMinimized";
            this.buttonMinimized.Size = new System.Drawing.Size(31, 27);
            this.buttonMinimized.TabIndex = 56;
            this.toolTip1.SetToolTip(this.buttonMinimized, "Згорнути");
            this.buttonMinimized.UseVisualStyleBackColor = false;
            this.buttonMinimized.Click += new System.EventHandler(this.buttonMinimized_Click);
            // 
            // buttonMaximized
            // 
            this.buttonMaximized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaximized.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.buttonMaximized.FlatAppearance.BorderSize = 0;
            this.buttonMaximized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMaximized.Image = global::GoodsManagement.Properties.Resources.Maximize_Window_26;
            this.buttonMaximized.Location = new System.Drawing.Point(630, 3);
            this.buttonMaximized.Name = "buttonMaximized";
            this.buttonMaximized.Size = new System.Drawing.Size(31, 27);
            this.buttonMaximized.TabIndex = 55;
            this.toolTip1.SetToolTip(this.buttonMaximized, "Відновити");
            this.buttonMaximized.UseVisualStyleBackColor = false;
            this.buttonMaximized.Click += new System.EventHandler(this.buttonMaximized_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxId, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxProvider, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(689, 1);
            this.tableLayoutPanel1.TabIndex = 52;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.dateTimePicker.Enabled = false;
            this.dateTimePicker.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(329, 23);
            this.dateTimePicker.MaxDate = new System.DateTime(2037, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(184, 27);
            this.dateTimePicker.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Номер";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(326, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 42;
            this.label8.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(89, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Постачальник";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxId
            // 
            this.textBoxId.Enabled = false;
            this.textBoxId.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.textBoxId.Location = new System.Drawing.Point(3, 23);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(62, 27);
            this.textBoxId.TabIndex = 36;
            this.textBoxId.Text = "0";
            this.textBoxId.TextChanged += new System.EventHandler(this.textBoxId_TextChanged);
            this.textBoxId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxId_KeyDown);
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxId_KeyPress);
            this.textBoxId.Leave += new System.EventHandler(this.textBoxId_Leave);
            // 
            // textBoxProvider
            // 
            this.textBoxProvider.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxProvider.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxProvider.Enabled = false;
            this.textBoxProvider.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.textBoxProvider.Location = new System.Drawing.Point(92, 23);
            this.textBoxProvider.Name = "textBoxProvider";
            this.textBoxProvider.Size = new System.Drawing.Size(210, 27);
            this.textBoxProvider.TabIndex = 24;
            this.textBoxProvider.Leave += new System.EventHandler(this.textBoxProvider_Leave);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 10;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.buttonRefresh, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.panelButtonEdit, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxSearch, 9, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonAdd, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonDelete, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.panelButtonAdd, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonEdit, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.panelButtonDelete, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonClear, 6, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 10);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(689, 46);
            this.tableLayoutPanel3.TabIndex = 52;
            // 
            // panelButtonEdit
            // 
            this.panelButtonEdit.BackColor = System.Drawing.SystemColors.Control;
            this.panelButtonEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtonEdit.Controls.Add(this.buttonEditCancel);
            this.panelButtonEdit.Controls.Add(this.buttonEditAccept);
            this.panelButtonEdit.Enabled = false;
            this.panelButtonEdit.Location = new System.Drawing.Point(134, 3);
            this.panelButtonEdit.MaximumSize = new System.Drawing.Size(81, 39);
            this.panelButtonEdit.MinimumSize = new System.Drawing.Size(1, 39);
            this.panelButtonEdit.Name = "panelButtonEdit";
            this.panelButtonEdit.Size = new System.Drawing.Size(1, 39);
            this.panelButtonEdit.TabIndex = 59;
            this.panelButtonEdit.Visible = false;
            // 
            // buttonEditCancel
            // 
            this.buttonEditCancel.FlatAppearance.BorderSize = 0;
            this.buttonEditCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditCancel.Image = global::GoodsManagement.Properties.Resources.cancel_26;
            this.buttonEditCancel.Location = new System.Drawing.Point(45, 4);
            this.buttonEditCancel.Name = "buttonEditCancel";
            this.buttonEditCancel.Size = new System.Drawing.Size(31, 31);
            this.buttonEditCancel.TabIndex = 56;
            this.toolTip1.SetToolTip(this.buttonEditCancel, "Відмінити зміну");
            this.buttonEditCancel.UseVisualStyleBackColor = true;
            this.buttonEditCancel.Click += new System.EventHandler(this.buttonEditCancel_Click);
            // 
            // buttonEditAccept
            // 
            this.buttonEditAccept.FlatAppearance.BorderSize = 0;
            this.buttonEditAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditAccept.Image = global::GoodsManagement.Properties.Resources.ok_26;
            this.buttonEditAccept.Location = new System.Drawing.Point(4, 4);
            this.buttonEditAccept.Name = "buttonEditAccept";
            this.buttonEditAccept.Size = new System.Drawing.Size(31, 31);
            this.buttonEditAccept.TabIndex = 55;
            this.toolTip1.SetToolTip(this.buttonEditAccept, "Підтвердити зміну");
            this.buttonEditAccept.UseVisualStyleBackColor = true;
            this.buttonEditAccept.Click += new System.EventHandler(this.buttonEditAccept_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSearch.Font = new System.Drawing.Font("Cambria", 10.2F);
            this.textBoxSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.textBoxSearch.Location = new System.Drawing.Point(290, 12);
            this.textBoxSearch.Margin = new System.Windows.Forms.Padding(3, 12, 1, 3);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(398, 27);
            this.textBoxSearch.TabIndex = 54;
            this.textBoxSearch.Text = "Пошук...";
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // panelButtonAdd
            // 
            this.panelButtonAdd.BackColor = System.Drawing.SystemColors.Control;
            this.panelButtonAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtonAdd.Controls.Add(this.buttonAddCancel);
            this.panelButtonAdd.Controls.Add(this.buttonAddAccept);
            this.panelButtonAdd.Enabled = false;
            this.panelButtonAdd.Location = new System.Drawing.Point(42, 3);
            this.panelButtonAdd.MaximumSize = new System.Drawing.Size(81, 39);
            this.panelButtonAdd.MinimumSize = new System.Drawing.Size(1, 39);
            this.panelButtonAdd.Name = "panelButtonAdd";
            this.panelButtonAdd.Size = new System.Drawing.Size(1, 39);
            this.panelButtonAdd.TabIndex = 54;
            this.panelButtonAdd.Visible = false;
            // 
            // buttonAddCancel
            // 
            this.buttonAddCancel.FlatAppearance.BorderSize = 0;
            this.buttonAddCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddCancel.Image = global::GoodsManagement.Properties.Resources.cancel_26;
            this.buttonAddCancel.Location = new System.Drawing.Point(45, 4);
            this.buttonAddCancel.Name = "buttonAddCancel";
            this.buttonAddCancel.Size = new System.Drawing.Size(31, 31);
            this.buttonAddCancel.TabIndex = 56;
            this.toolTip1.SetToolTip(this.buttonAddCancel, "Відмінити додавання");
            this.buttonAddCancel.UseVisualStyleBackColor = true;
            this.buttonAddCancel.Click += new System.EventHandler(this.buttonAddCancel_Click);
            // 
            // buttonAddAccept
            // 
            this.buttonAddAccept.FlatAppearance.BorderSize = 0;
            this.buttonAddAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddAccept.Image = global::GoodsManagement.Properties.Resources.ok_26;
            this.buttonAddAccept.Location = new System.Drawing.Point(4, 4);
            this.buttonAddAccept.Name = "buttonAddAccept";
            this.buttonAddAccept.Size = new System.Drawing.Size(31, 31);
            this.buttonAddAccept.TabIndex = 55;
            this.toolTip1.SetToolTip(this.buttonAddAccept, "Підтвердити додавання");
            this.buttonAddAccept.UseVisualStyleBackColor = true;
            this.buttonAddAccept.Click += new System.EventHandler(this.buttonAddAccept_Click);
            // 
            // panelButtonDelete
            // 
            this.panelButtonDelete.BackColor = System.Drawing.SystemColors.Control;
            this.panelButtonDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtonDelete.Controls.Add(this.buttonDeleteCancel);
            this.panelButtonDelete.Controls.Add(this.buttonDeleteAccept);
            this.panelButtonDelete.Enabled = false;
            this.panelButtonDelete.Location = new System.Drawing.Point(88, 3);
            this.panelButtonDelete.MaximumSize = new System.Drawing.Size(81, 39);
            this.panelButtonDelete.MinimumSize = new System.Drawing.Size(1, 39);
            this.panelButtonDelete.Name = "panelButtonDelete";
            this.panelButtonDelete.Size = new System.Drawing.Size(1, 39);
            this.panelButtonDelete.TabIndex = 57;
            this.panelButtonDelete.Visible = false;
            // 
            // buttonDeleteCancel
            // 
            this.buttonDeleteCancel.FlatAppearance.BorderSize = 0;
            this.buttonDeleteCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteCancel.Image = global::GoodsManagement.Properties.Resources.cancel_26;
            this.buttonDeleteCancel.Location = new System.Drawing.Point(45, 4);
            this.buttonDeleteCancel.Name = "buttonDeleteCancel";
            this.buttonDeleteCancel.Size = new System.Drawing.Size(31, 31);
            this.buttonDeleteCancel.TabIndex = 56;
            this.toolTip1.SetToolTip(this.buttonDeleteCancel, "Відмінити видалення");
            this.buttonDeleteCancel.UseVisualStyleBackColor = true;
            this.buttonDeleteCancel.Click += new System.EventHandler(this.buttonDeleteCancel_Click);
            // 
            // buttonDeleteAccept
            // 
            this.buttonDeleteAccept.FlatAppearance.BorderSize = 0;
            this.buttonDeleteAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteAccept.Image = global::GoodsManagement.Properties.Resources.ok_26;
            this.buttonDeleteAccept.Location = new System.Drawing.Point(4, 4);
            this.buttonDeleteAccept.Name = "buttonDeleteAccept";
            this.buttonDeleteAccept.Size = new System.Drawing.Size(31, 31);
            this.buttonDeleteAccept.TabIndex = 55;
            this.toolTip1.SetToolTip(this.buttonDeleteAccept, "Підтвердити видалення");
            this.buttonDeleteAccept.UseVisualStyleBackColor = true;
            this.buttonDeleteAccept.Click += new System.EventHandler(this.buttonDeleteAccept_Click);
            // 
            // dataGridViewGoods
            // 
            this.dataGridViewGoods.AllowUserToAddRows = false;
            this.dataGridViewGoods.AllowUserToDeleteRows = false;
            this.dataGridViewGoods.AllowUserToResizeRows = false;
            this.dataGridViewGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGoods.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewGoods.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewGoods.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGoods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoods.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGoods.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewGoods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGoods.EnableHeadersVisualStyles = false;
            this.dataGridViewGoods.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewGoods.Location = new System.Drawing.Point(3, 67);
            this.dataGridViewGoods.MultiSelect = false;
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.ReadOnly = true;
            this.dataGridViewGoods.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGoods.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewGoods.RowHeadersWidth = 5;
            this.dataGridViewGoods.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewGoods.RowTemplate.Height = 24;
            this.dataGridViewGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGoods.Size = new System.Drawing.Size(689, 375);
            this.dataGridViewGoods.TabIndex = 13;
            this.dataGridViewGoods.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGoods_CellClick);
            this.dataGridViewGoods.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGoods_CellDoubleClick);
            this.dataGridViewGoods.CurrentCellChanged += new System.EventHandler(this.dataGridViewGoods_CurrentCellChanged);
            // 
            // DataGridViewTextBoxColumn9
            // 
            this.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9";
            this.DataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn10
            // 
            this.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10";
            this.DataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumn11
            // 
            this.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11";
            this.DataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // extraDataGridView
            // 
            this.extraDataGridView.AllowUserToAddRows = false;
            this.extraDataGridView.AllowUserToDeleteRows = false;
            this.extraDataGridView.AllowUserToResizeColumns = false;
            this.extraDataGridView.AllowUserToResizeRows = false;
            this.extraDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.extraDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.extraDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.extraDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.extraDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.extraDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.extraDataGridView.ColumnHeadersVisible = false;
            this.extraDataGridView.EnableHeadersVisualStyles = false;
            this.extraDataGridView.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.extraDataGridView.Location = new System.Drawing.Point(50, 50);
            this.extraDataGridView.MultiSelect = false;
            this.extraDataGridView.Name = "extraDataGridView";
            this.extraDataGridView.ReadOnly = true;
            this.extraDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.extraDataGridView.RowHeadersVisible = false;
            this.extraDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.extraDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.extraDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.extraDataGridView.Size = new System.Drawing.Size(240, 150);
            this.extraDataGridView.TabIndex = 0;
            // 
            // tableLayoutMainPanel
            // 
            this.tableLayoutMainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMainPanel.ColumnCount = 1;
            this.tableLayoutMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMainPanel.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutMainPanel.Controls.Add(this.panelBehindTextBoxs, 0, 0);
            this.tableLayoutMainPanel.Controls.Add(this.dataGridViewGoods, 0, 3);
            this.tableLayoutMainPanel.Location = new System.Drawing.Point(4, 64);
            this.tableLayoutMainPanel.MinimumSize = new System.Drawing.Size(695, 445);
            this.tableLayoutMainPanel.Name = "tableLayoutMainPanel";
            this.tableLayoutMainPanel.RowCount = 4;
            this.tableLayoutMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutMainPanel.Size = new System.Drawing.Size(695, 445);
            this.tableLayoutMainPanel.TabIndex = 52;
            // 
            // panelBehindTextBoxs
            // 
            this.panelBehindTextBoxs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.panelBehindTextBoxs.Controls.Add(this.panelTextBoxs);
            this.panelBehindTextBoxs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBehindTextBoxs.Enabled = false;
            this.panelBehindTextBoxs.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panelBehindTextBoxs.Location = new System.Drawing.Point(3, 3);
            this.panelBehindTextBoxs.MaximumSize = new System.Drawing.Size(0, 53);
            this.panelBehindTextBoxs.MinimumSize = new System.Drawing.Size(0, 1);
            this.panelBehindTextBoxs.Name = "panelBehindTextBoxs";
            this.panelBehindTextBoxs.Size = new System.Drawing.Size(689, 1);
            this.panelBehindTextBoxs.TabIndex = 55;
            this.panelBehindTextBoxs.Visible = false;
            // 
            // panelTextBoxs
            // 
            this.panelTextBoxs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.panelTextBoxs.Controls.Add(this.tableLayoutPanel1);
            this.panelTextBoxs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTextBoxs.Location = new System.Drawing.Point(0, 0);
            this.panelTextBoxs.MaximumSize = new System.Drawing.Size(1100, 53);
            this.panelTextBoxs.MinimumSize = new System.Drawing.Size(689, 1);
            this.panelTextBoxs.Name = "panelTextBoxs";
            this.panelTextBoxs.Size = new System.Drawing.Size(689, 1);
            this.panelTextBoxs.TabIndex = 53;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(126)))), ((int)(((byte)(152)))));
            this.panelHeader.Controls.Add(this.buttonClose);
            this.panelHeader.Controls.Add(this.label9);
            this.panelHeader.Controls.Add(this.buttonMinimized);
            this.panelHeader.Controls.Add(this.buttonMaximized);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(703, 36);
            this.panelHeader.TabIndex = 53;
            this.panelHeader.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDoubleClick);
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.panelHeader.MouseLeave += new System.EventHandler(this.panelHeader_MouseLeave);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            this.panelHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 22);
            this.label9.TabIndex = 55;
            this.label9.Text = "ПрАТ «ДУБНОМОЛОКО»";
            this.label9.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDoubleClick);
            this.label9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.label9.MouseLeave += new System.EventHandler(this.panelHeader_MouseLeave);
            this.label9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            this.label9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseUp);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.menuStrip1);
            this.MainPanel.Controls.Add(this.panelHeader);
            this.MainPanel.Controls.Add(this.tableLayoutMainPanel);
            this.MainPanel.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.MainPanel.Location = new System.Drawing.Point(5, 5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(705, 515);
            this.MainPanel.TabIndex = 54;
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Invoice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(715, 525);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cambria", 18.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(715, 525);
            this.Name = "Invoice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ПрАТ «ДУБНОМОЛОКО»";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.Goods_Load);
            this.SizeChanged += new System.EventHandler(this.Goods_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.filterContextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panelButtonEdit.ResumeLayout(false);
            this.panelButtonAdd.ResumeLayout(false);
            this.panelButtonDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.extraDataGridView)).EndInit();
            this.tableLayoutMainPanel.ResumeLayout(false);
            this.panelBehindTextBoxs.ResumeLayout(false);
            this.panelTextBoxs.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ContextMenuStrip filterContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fProviderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fCarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fTypeToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView extraDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMainPanel;
        private System.Windows.Forms.Panel panelTextBoxs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMaximized;
        private System.Windows.Forms.Button buttonMinimized;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewGoods;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonAddCancel;
        private System.Windows.Forms.Button buttonAddAccept;
        private System.Windows.Forms.Panel panelButtonAdd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelButtonDelete;
        private System.Windows.Forms.Button buttonDeleteCancel;
        private System.Windows.Forms.Button buttonDeleteAccept;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Panel panelButtonEdit;
        private System.Windows.Forms.Button buttonEditCancel;
        private System.Windows.Forms.Button buttonEditAccept;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Panel panelBehindTextBoxs;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBalance;
    }
}