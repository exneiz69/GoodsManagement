using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace GoodsManagement
{
    public partial class Goods : Form
    {
        private string source = 
            @"Data Source=DESKTOP-M22O3UA\SQLEXPRESS;Initial Catalog=GoodsDB;Integrated Security=True;
                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

        private DataTable DataSetMain;
        private DataTable DataSetKind;
        private DataTable DataSetProduct;

        public Goods()
        {
            try
            {
                InitializeComponent();

                this.Controls.Add(this.extraDataGridView);
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
                this.DataSetMain = new DataTable();
                this.DataSetKind = new DataTable();
                this.DataSetProduct = new DataTable();
            } 
            catch
            {
                this.Close();
            }
        }

        private const Int32
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const Int32 _shift = 10;

        private new Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _shift); } }
        private new Rectangle Left { get { return new Rectangle(0, 0, _shift, this.ClientSize.Height); } }
        private new Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _shift, this.ClientSize.Width, _shift); } }
        private new Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _shift, 0, _shift, this.ClientSize.Height); } }

        private Rectangle TopLeft { get { return new Rectangle(0, 0, _shift, _shift); } }
        private Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _shift, 0, _shift, _shift); } }
        private Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _shift, _shift, _shift); } }
        private Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _shift, this.ClientSize.Height - _shift, _shift, _shift); } }

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }

        private void Goods_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void buttonAddAccept_Click(object sender, EventArgs e) // add button click
        {
            using (SqlConnection connection = new SqlConnection(source))
            {
                try
                {
                    connection.Open();
                    String query = "SELECT ID FROM Provider WHERE Name = '" + textBoxProvider.Text + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    Int32 ProviderID = (Int32)command.ExecuteScalar();

                    query = "SELECT ID FROM Product WHERE Name = '" + textBoxProduct.Text + "'";
                    command = new SqlCommand(query, connection);
                    Int32 ProductID = (Int32)command.ExecuteScalar();

                    query = "INSERT INTO Goods(ProviderID, ProductID, Amount) VALUES(" + ProviderID.ToString() + ", " +
                        ProductID.ToString() + ", " + textBoxAmount.Value.ToString() + ")";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Запис успішно доданий", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                        if (i + 1 != ex.Errors.Count) errorMessages.Append("\n\n");
                    }
                    MessageBox.Show(errorMessages.ToString(), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nПомилка при підключенні до бази данних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void buttonDeleteAccept_Click(object sender, EventArgs e) // delete button click
        {
            if (textBoxId.Text == "0")
            {
                MessageBox.Show("Невірно вказаний запис", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection connection = new SqlConnection(source))
            {
                try
                {
                    connection.Open();
                    String query = "DELETE FROM Goods WHERE ID = " + textBoxId.Text;
                    SqlCommand command = new SqlCommand(query, connection);
                    Int32 amountExecuteNonQuery = command.ExecuteNonQuery();
                    if (dataGridViewGoods.RowCount > 2)
                    {
                        foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                        {
                            if ((Int32)row.Cells[0].Value == Int32.Parse(textBoxId.Text))
                            {
                                LoadData(true, row.Index - 1);
                                break;
                            }
                        }
                    }
                    else LoadData();
                    if (amountExecuteNonQuery != 0) MessageBox.Show("Запис успішно видалений", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Запис був відсутій в базі данних", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                        if (i + 1 != ex.Errors.Count) errorMessages.Append("\n\n");
                    }
                    MessageBox.Show(errorMessages.ToString(), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nПомилка при підключенні до бази данних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void buttonEditAccept_Click(object sender, EventArgs e) // edit button click
        {
            using (SqlConnection connection = new SqlConnection(source))
            {
                try
                {
                    connection.Open();
                    String query = "SELECT ID FROM Provider WHERE Name = '" + textBoxProvider.Text + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    Int32 ProviderID = (Int32)command.ExecuteScalar();

                    query = "SELECT ID FROM Product WHERE Name = '" + textBoxProduct.Text + "'";
                    command = new SqlCommand(query, connection);
                    Int32 ProductID = (Int32)command.ExecuteScalar();

                    query = "UPDATE Goods SET ProviderID = " + ProviderID.ToString() + ", ProductID = " + ProductID.ToString() + 
                        ", Amount = " + textBoxAmount.Value.ToString() + ", Date = '" + 
                        dateTimePicker.Value.ToString("yyyy-MM-dd hh:mm:ss").ToString() + "'  WHERE ID = " + textBoxId.Text;
                    command = new SqlCommand(query, connection);
                    Int32 amountExecuteNonQuery = command.ExecuteNonQuery();

                    if (dataGridViewGoods.RowCount > 1)
                    {
                        foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                        {
                            if ((Int32)row.Cells[0].Value == Int32.Parse(textBoxId.Text))
                            {
                                LoadData(true, row.Index);
                                break;
                            }
                        }
                    }
                    else LoadData();
                    if (amountExecuteNonQuery != 0) MessageBox.Show("Оновлення запису успішне", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Запис був відсутій в базі данних", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                        if (i + 1 != ex.Errors.Count) errorMessages.Append("\n\n");
                    }
                    MessageBox.Show(errorMessages.ToString(), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nПомилка при підключенні до бази данних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) // clear button click
        {
            textBoxId.Clear();
            textBoxProvider.Clear();
            textBoxKind.Clear();
            textBoxProduct.Clear();
            textBoxAmount.Value = 0;
            dateTimePicker.Value = DateTime.Now;
        }

        private void buttonRefresh_Click(object sender, EventArgs e) // refresh button click
        {
            //if (fLastToolStripMenuItem != null)
            //{
            //    readData(dataGridViewGoods, fLastQuery, true);
            //}
            LoadData();
        }

        private void LoadData(Boolean makeSpecialRowSelected = false, Int32 rowIndex = 0) // loading records from the database
        {
            String query = "SELECT Goods.ID 'Номер', Provider.Name 'Постачальник', Kind.Name 'Тип', Product.Name 'Назва', " +
                "Amount 'Кількість', Date 'Дата' " +
                "FROM Goods " +
                "JOIN Provider ON Goods.ProviderID = Provider.ID " +
                "JOIN Product ON Goods.ProductID = Product.ID " +
                "JOIN Kind ON Product.KindID = Kind.ID";
            readData(DataSetMain, query);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DataSetMain;
            dataGridViewGoods.DataSource = bindingSource;

            try
            {
                dataGridViewGoods.Columns["Дата"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nПомилка при встановленні формату дати", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dataGridViewGoods.RowCount != 0)
            {
                if (!makeSpecialRowSelected)
                {
                    dataGridViewGoods.CurrentCell = dataGridViewGoods.Rows[dataGridViewGoods.RowCount - 1].Cells[0];
                    dataGridViewGoods.CurrentCell.Selected = true;
                }
                else
                {
                    if (rowIndex < dataGridViewGoods.RowCount && rowIndex >= 0)
                    {
                        dataGridViewGoods.CurrentCell = dataGridViewGoods.Rows[rowIndex].Cells[0];
                        dataGridViewGoods.CurrentCell.Selected = true;
                    }
                }
            }
        }

        public enum RefreshTableName { Provider, Kind, Product }

        public void RefreshAutoComplete(RefreshTableName refreshTableName)
        {
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            String query = "";
            if (refreshTableName == RefreshTableName.Kind) query = "SELECT Name FROM Kind";
            else if (refreshTableName == RefreshTableName.Provider) query = "SELECT Name FROM Provider";
            else if (refreshTableName == RefreshTableName.Product) query = "SELECT Product.Name FROM Product " +
                    "JOIN Kind ON Product.KindID = Kind.ID WHERE Kind.Name = '" + textBoxKind.Text + "'";
            SqlDataReader reader;
            using (SqlConnection connection = new SqlConnection(source))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();
                    String kind;
                    while (reader.Read())
                    {
                        kind = reader.GetString(0);
                        stringCollection.Add(kind);
                    }
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure + "\n\n");
                    }
                    MessageBox.Show(errorMessages.ToString(), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nПомилка при зчитуванні з бази данних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (refreshTableName == RefreshTableName.Kind) textBoxKind.AutoCompleteCustomSource = stringCollection;
            if (refreshTableName == RefreshTableName.Provider) textBoxProvider.AutoCompleteCustomSource = stringCollection;
            if (refreshTableName == RefreshTableName.Product) textBoxProduct.AutoCompleteCustomSource = stringCollection;
        }
                
        private void dataGridViewGoods_CurrentCellChanged(object sender, EventArgs e) // filling in textBoxs by the selected line
        {
            DataGridViewCell dataGridViewCurrentCell = dataGridViewGoods.CurrentCell;
            if (dataGridViewCurrentCell != null)
            {
                Int32 rowIndex = dataGridViewCurrentCell.RowIndex;
                DataGridViewRow dataGridViewRow = dataGridViewGoods.Rows[rowIndex];
                if (!(dataGridViewRow.Cells[0].Value is null)) textBoxId.Text = dataGridViewRow.Cells[0].Value.ToString();
                if (!(dataGridViewRow.Cells[1].Value is null)) textBoxProvider.Text = dataGridViewRow.Cells[1].Value.ToString();
                if (!(dataGridViewRow.Cells[2].Value is null))
                {
                    textBoxKind.Text = dataGridViewRow.Cells[2].Value.ToString();
                    RefreshAutoComplete(RefreshTableName.Product);
                }
                if (!(dataGridViewRow.Cells[3].Value is null)) textBoxProduct.Text = dataGridViewRow.Cells[3].Value.ToString();
                if (!(dataGridViewRow.Cells[4].Value is null)) textBoxAmount.Text = dataGridViewRow.Cells[4].Value.ToString();
                if (!(dataGridViewRow.Cells[5].Value is null)) dateTimePicker.Text = dataGridViewRow.Cells[5].Value.ToString();
            }
        }

        private Boolean isKeyDownEnter = false;

        private void textBoxId_KeyDown(object sender, KeyEventArgs e) // filling the textBoxs by id
        {
            if (e.KeyCode == Keys.Enter)
            {
                isKeyDownEnter = true;
                Boolean searchSuccess = false;
                foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBoxId.Text)
                    {
                        dataGridViewGoods.CurrentCell = dataGridViewGoods.Rows[row.Index].Cells[0];
                        dataGridViewGoods.CurrentCell.Selected = true;
                        searchSuccess = true;
                        break;
                    }
                }
                if (!searchSuccess) textBoxId.Text = "0";
            }
            else isKeyDownEnter = false;
        }

        //private void extraTextBox_MouseClick(object sender, MouseEventArgs e)
        //{
            //String query = "";
            //extraDataGridView.Rows.Clear();
            //extraDataGridView.Columns.Clear();
            //TextBox senderTextBox = sender as TextBox;
            //if (providerTextBox == senderTextBox)
            //{
            //    DataGridViewTextBoxColumn9.HeaderText = "Код";
            //    DataGridViewTextBoxColumn10.HeaderText = "Назва";
            //    extraDataGridView.Columns.AddRange(new DataGridViewColumn[] {
            //    DataGridViewTextBoxColumn9, DataGridViewTextBoxColumn10});

            //    query = "SELECT * FROM Provider";
            //}
            //else return;

            //if (readData(extraDataGridView, query))
            //{
            //    extraDataGridView.Show();
            //    Point locationSenderTextBox = senderTextBox.FindForm().PointToClient(
            //        senderTextBox.Parent.PointToScreen(senderTextBox.Location)); // global location senderTextBox on form
            //    locationSenderTextBox.Y += senderTextBox.Height;
            //    extraDataGridView.Location = new Point(locationSenderTextBox.X - 2, locationSenderTextBox.Y - 2);

            //    DataGridViewElementStates states = DataGridViewElementStates.None;
            //    var totalHeight = extraDataGridView.Rows.GetRowsHeight(states);
            //    if (extraDataGridView.Rows.Count > 5) totalHeight = totalHeight / extraDataGridView.Rows.Count * 5;
            //    var totalWidth = extraDataGridView.Columns.GetColumnsWidth(states);
            //    extraDataGridView.ClientSize = new Size(totalWidth + 3, totalHeight + 3);

            //    extraDataGridView.BringToFront();
            //    extraDataGridView.Focus();

            //    if (senderTextBox.TextLength > 0)
            //    {
            //        foreach (DataGridViewRow row in extraDataGridView.Rows)
            //        {
            //            if (row.Cells[0].Value.ToString() == senderTextBox.Text)
            //            {
            //                extraDataGridView.CurrentCell = row.Cells[0];
            //                extraDataGridView.CurrentCell.Selected = true;
            //                break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        extraDataGridView.ClearSelection();
            //    }
            //}
        //}

        private ToolStripMenuItem fLastToolStripMenuItem = null;
        private String fLastQuery;

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //String query;
            //if (fProviderToolStripMenuItem == (sender as ToolStripMenuItem))
            //{
            //    fProviderToolStripMenuItem.Checked = !fProviderToolStripMenuItem.Checked;
            //    if (fProviderToolStripMenuItem.Checked == false)
            //    {
            //        fLastToolStripMenuItem = null;
            //        LoadData();
            //        return;
            //    }
            //    if (providerTextBox.TextLength > 0)
            //    {
            //        if (fLastToolStripMenuItem != null) fLastToolStripMenuItem.Checked = false;
            //        fLastToolStripMenuItem = fProviderToolStripMenuItem;
            //        fLastQuery = query = "SELECT * FROM Goods WHERE ProviderID = '" + providerTextBox.Text + "'";
            //    }
            //    else
            //    {
            //        fProviderToolStripMenuItem.Checked = false;
            //        return;
            //    }
            //}
            //else if (fTypeToolStripMenuItem == (sender as ToolStripMenuItem))
            //{
            //    fTypeToolStripMenuItem.Checked = !fTypeToolStripMenuItem.Checked;
            //    if (fTypeToolStripMenuItem.Checked == false)
            //    {
            //        fLastToolStripMenuItem = null;
            //        LoadData();
            //        return;
            //    }
            //    if (typeTextBox.TextLength > 0)
            //    {
            //        if (fLastToolStripMenuItem != null) fLastToolStripMenuItem.Checked = false;
            //        fLastToolStripMenuItem = fTypeToolStripMenuItem;
            //        fLastQuery = query = "SELECT * FROM Goods WHERE c_kind = '" + typeTextBox.Text + "'";
            //    }
            //    else
            //    {
            //        fTypeToolStripMenuItem.Checked = false;
            //        return;
            //    }
            //}
            //else return;
            //dataGridViewGoods.Rows.Clear();
            //readData(dataGridViewGoods, query, true);
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            //filterContextMenuStrip.Show(filterButton, ((MouseEventArgs)e).Location);
        }

        private void readData(DataTable dataTable, String query)
        {
            using (SqlConnection connection = new SqlConnection(source))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    dataTable.Clear();
                    SqlDataAdapter DBDataAdapter = new SqlDataAdapter();
                    DBDataAdapter.SelectCommand = command;
                    DBDataAdapter.Fill(dataTable);
                }
                catch (SqlException ex)
                {
                    StringBuilder errorMessages = new StringBuilder();
                    for (int i = 0; i < ex.Errors.Count; i++)
                    {
                        errorMessages.Append("Index #" + i + "\n" +
                            "Message: " + ex.Errors[i].Message + "\n" +
                            "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                            "Source: " + ex.Errors[i].Source + "\n" +
                            "Procedure: " + ex.Errors[i].Procedure);
                        if (i + 1 != ex.Errors.Count) errorMessages.Append("\n\n");
                    }
                    MessageBox.Show(errorMessages.ToString(), "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nПомилка при зчитуванні з бази данних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ви дійсно хочете Вийти?", "Вихід", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.OK) Application.ExitThread();
        }

        private void buttonMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonMaximized_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                buttonMaximized.Image = Properties.Resources.Restore_Window_26;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                buttonMaximized.Image = Properties.Resources.Maximize_Window_26;
            }
        }

        private void panelHeader_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
        }

        private void panelHeader_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                buttonMaximized.Image = Properties.Resources.Restore_Window_26;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                buttonMaximized.Image = Properties.Resources.Maximize_Window_26;
            }
        }

        private void Goods_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) MainPanel.Dock = DockStyle.Fill;
            else
            {
                if (MainPanel.Dock == DockStyle.Fill) MainPanel.Dock = DockStyle.None;
                MainPanel.Size = new Size(this.Size.Width - 10, this.Size.Height - 10);
                MainPanel.Location = new Point(5, 5);
            }
        }

        private Boolean isActiveButtonAdd = false;
        private Boolean isCollapsedButtonAdd = true;
        private Boolean isActiveButtonDelete = false;
        private Boolean isCollapsedButtonDelete = true; 
        private Boolean isActiveButtonEdit = false;
        private Boolean isCollapsedButtonEdit = true;
        private Boolean isActivePanelTextBoxs = false;
        private Boolean isCollapsedPanelTextBoxs = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActiveButtonAdd)
            {
                if (isCollapsedButtonAdd)
                {
                    panelButtonAdd.Enabled = true;
                    buttonAdd.Enabled = false;
                    panelButtonAdd.Width += 10;
                    if (!isCollapsedButtonDelete) isActiveButtonDelete = true;
                    if (!isCollapsedButtonEdit) isActiveButtonEdit = true;
                    if (panelButtonAdd.Size == panelButtonAdd.MaximumSize)
                    {
                        if (!isActiveButtonDelete && !isActiveButtonEdit && !isActivePanelTextBoxs) timer1.Stop();
                        isCollapsedButtonAdd = false;
                        isActiveButtonAdd = false;
                    }
                }
                else
                {
                    panelButtonAdd.Enabled = false;
                    buttonAdd.Enabled = true;
                    panelButtonAdd.Width -= 10;
                    if (panelButtonAdd.Size == panelButtonAdd.MinimumSize)
                    {
                        if(!isActiveButtonDelete && !isActiveButtonEdit && !isActivePanelTextBoxs) timer1.Stop();
                        isCollapsedButtonAdd = true;
                        isActiveButtonAdd = false;
                        panelButtonAdd.Hide();
                    }
                }
            }
            if (isActiveButtonDelete)
            {
                if (isCollapsedButtonDelete)
                {
                    panelButtonDelete.Enabled = true;
                    buttonDelete.Enabled = false;
                    panelButtonDelete.Width += 10;
                    if (!isCollapsedButtonAdd) isActiveButtonAdd = true;
                    if (!isCollapsedButtonEdit) isActiveButtonEdit = true;
                    if (panelButtonDelete.Size == panelButtonDelete.MaximumSize)
                    {
                        if (!isActiveButtonAdd && !isActiveButtonEdit && !isActivePanelTextBoxs) timer1.Stop();
                        isCollapsedButtonDelete = false;
                        isActiveButtonDelete = false;
                    }
                }
                else
                {
                    panelButtonDelete.Enabled = false;
                    buttonDelete.Enabled = true;
                    panelButtonDelete.Width -= 10;
                    if (panelButtonDelete.Size == panelButtonDelete.MinimumSize)
                    {
                        if (!isActiveButtonAdd && !isActiveButtonEdit && !isActivePanelTextBoxs) timer1.Stop();
                        isCollapsedButtonDelete = true;
                        isActiveButtonDelete = false;
                        panelButtonDelete.Hide();
                    }
                }
            }
            if (isActiveButtonEdit)
            {
                if (isCollapsedButtonEdit)
                {
                    panelButtonEdit.Enabled = true;
                    buttonEdit.Enabled = false;
                    panelButtonEdit.Width += 10;
                    if (!isCollapsedButtonAdd) isActiveButtonAdd = true;
                    if (!isCollapsedButtonDelete) isActiveButtonDelete = true;
                    if (panelButtonEdit.Size == panelButtonEdit.MaximumSize)
                    {
                        if (!isActiveButtonAdd && !isActiveButtonDelete && !isActivePanelTextBoxs) timer1.Stop();
                        isCollapsedButtonEdit = false;
                        isActiveButtonEdit = false;
                    }
                }
                else
                {
                    panelButtonEdit.Enabled = false;
                    buttonEdit.Enabled = true;
                    panelButtonEdit.Width -= 10;
                    if (panelButtonEdit.Size == panelButtonEdit.MinimumSize)
                    {
                        if(!isActiveButtonAdd && !isActiveButtonDelete && !isActivePanelTextBoxs) timer1.Stop();
                        isCollapsedButtonEdit = true;
                        isActiveButtonEdit = false;
                        panelButtonEdit.Hide();
                    }
                }
            }
            if (isActivePanelTextBoxs)
            {
                if (isCollapsedPanelTextBoxs)
                {
                    panelTextBoxs.Enabled = true;
                    panelTextBoxs.Height += 20;
                    if (panelTextBoxs.Size.Height == panelTextBoxs.MaximumSize.Height)
                    {
                        if (!isActiveButtonAdd && !isActiveButtonDelete && !isActiveButtonEdit) timer1.Stop();
                        isCollapsedPanelTextBoxs = false;
                        isActivePanelTextBoxs = false;
                    }
                }
                else
                {
                    panelTextBoxs.Enabled = false;
                    panelTextBoxs.Height -= 20;
                    if (panelTextBoxs.Size.Height == panelTextBoxs.MinimumSize.Height)
                    {
                        if (!isActiveButtonAdd && !isActiveButtonDelete && !isActiveButtonEdit) timer1.Stop();
                        isCollapsedPanelTextBoxs = true;
                        isActivePanelTextBoxs = false;
                        panelTextBoxs.Hide();
                    }   
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            textBoxId.Enabled = false;
            textBoxProvider.Enabled = true;
            textBoxKind.Enabled = true;
            if (textBoxKind.AutoCompleteCustomSource.Contains(textBoxKind.Text)) textBoxProduct.Enabled = true;
            else textBoxProduct.Enabled = false;
            textBoxAmount.Enabled = true;
            dateTimePicker.Enabled = false;

            isActiveButtonAdd = true;
            if (isCollapsedButtonDelete && isCollapsedButtonEdit)
                if (!isActiveButtonDelete && !isActiveButtonEdit) isActivePanelTextBoxs = true;
            panelButtonAdd.Show();
            panelTextBoxs.Show();
            timer1.Start();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBoxId.Enabled = true;
            textBoxProvider.Enabled = false;
            textBoxKind.Enabled = false;
            textBoxProduct.Enabled = false;
            textBoxAmount.Enabled = false;
            dateTimePicker.Enabled = false;

            isActiveButtonDelete = true;
            if (isCollapsedButtonAdd && isCollapsedButtonEdit)
                if (!isActiveButtonAdd && !isActiveButtonEdit) isActivePanelTextBoxs = true;
            panelButtonDelete.Show();
            panelTextBoxs.Show();
            timer1.Start();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            textBoxId.Enabled = true;
            textBoxProvider.Enabled = true;
            textBoxKind.Enabled = true;
            if (textBoxKind.AutoCompleteCustomSource.Contains(textBoxKind.Text)) textBoxProduct.Enabled = true;
            else textBoxProduct.Enabled = false;
            textBoxAmount.Enabled = true;
            dateTimePicker.Enabled = true;

            isActiveButtonEdit = true;
            if (isCollapsedButtonAdd && isCollapsedButtonDelete)
                if (!isActiveButtonAdd && !isActiveButtonDelete) isActivePanelTextBoxs = true;
            panelButtonEdit.Show();
            panelTextBoxs.Show();
            timer1.Start();
        }

        private void buttonAddCancel_Click(object sender, EventArgs e)  
        {
            isActiveButtonAdd = true;
            if (!isActiveButtonDelete && !isActiveButtonEdit) isActivePanelTextBoxs = true;
            timer1.Start();
        }

        private void buttonDeleteCancel_Click(object sender, EventArgs e)
        {
            isActiveButtonDelete = true;
            if (!isActiveButtonAdd && !isActiveButtonEdit) isActivePanelTextBoxs = true;
            timer1.Start();
        }

        private void Goods_Load(object sender, EventArgs e)
        {
            RefreshAutoComplete(RefreshTableName.Kind);
            RefreshAutoComplete(RefreshTableName.Provider);
            LoadData();
        }

        private void textBoxKind_Leave(object sender, EventArgs e)
        {
            if (!textBoxKind.AutoCompleteCustomSource.Contains(textBoxKind.Text)) textBoxKind.Clear();
            else RefreshAutoComplete(RefreshTableName.Product);
        }

        private void textBoxKind_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKind.AutoCompleteCustomSource.Contains(textBoxKind.Text))
            {
                if(panelButtonDelete.Enabled == false) textBoxProduct.Enabled = true;
            }
            else textBoxProduct.Enabled = false;
            textBoxProduct.Clear();
        }

        private void textBoxProvider_Leave(object sender, EventArgs e)
        {
            if (!textBoxProvider.AutoCompleteCustomSource.Contains(textBoxProvider.Text))
                textBoxProvider.Clear();
        }

        private void textBoxProduct_Leave(object sender, EventArgs e)
        {
            if (!textBoxProduct.AutoCompleteCustomSource.Contains(textBoxProduct.Text))
                textBoxProduct.Clear();
        }

        private void textBoxId_Leave(object sender, EventArgs e)
        {
            Boolean searchSuccess = false;
            foreach (DataGridViewRow row in dataGridViewGoods.Rows)
            {
                if (row.Cells[0].Value.ToString() == textBoxId.Text) searchSuccess = true;
            }
            if (!searchSuccess) textBoxId.Text = "0";
        }

        private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46) e.Handled = true;
            if (!isKeyDownEnter)
            {
                textBoxProvider.Clear();
                textBoxKind.Clear();
                textBoxProduct.Clear();
                textBoxAmount.Value = 0;
                dateTimePicker.Value = DateTime.Now;
            }
        }

        private void buttonEditCancel_Click(object sender, EventArgs e)
        {
            isActiveButtonEdit = true;
            if (!isActiveButtonAdd && !isActiveButtonDelete) isActivePanelTextBoxs = true;
            timer1.Start();
        }

        private Boolean mouseDown;
        private Point lastLocation;

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private Boolean windowStateRefresh = false;

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    buttonMaximized.Image = Properties.Resources.Maximize_Window_26;
                    Double rationX = (Double)lastLocation.X / (Double)Screen.PrimaryScreen.Bounds.Width;
                    this.Location = new Point(lastLocation.X - (Int32)(this.Width * rationX), lastLocation.Y);
                    windowStateRefresh = true;
                }
                else
                {
                    if (windowStateRefresh)
                    {
                        windowStateRefresh = false;
                        lastLocation = e.Location;
                    }
                    this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                }
                this.Update();
            }
        }
    }
}
