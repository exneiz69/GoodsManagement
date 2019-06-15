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
using System.Text.RegularExpressions;

namespace GoodsManagement
{
    public partial class Invoice : Form
    {
        private DataTable DataSetMain;

        public Invoice()
        {
            try
            {
                InitializeComponent();
                menuStrip1.Renderer = new MyRenderer();

                this.Controls.Add(this.extraDataGridView);
                this.SetStyle(ControlStyles.ResizeRedraw, true);
                this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
                this.DataSetMain = new DataTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nПомилка при запуску програми", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void buttonAddAccept_Click(object sender, EventArgs e) // add button click
        {
            if (textBoxProvider.Text.Length == 0)
            {
                MessageBox.Show("Заповність всі необхідні поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else using (SqlConnection connection = new SqlConnection(Helper.source))
                {
                    try
                    {
                        connection.Open();
                        Int32 ProviderID = -1;
                        using (var command = new SqlCommand(@"SELECT ID FROM Providers WHERE Name = @ProviderName", connection))
                        {
                            command.Parameters.AddWithValue("@ProviderName", textBoxProvider.Text);
                            ProviderID = (Int32)command.ExecuteScalar();
                        }
                        using (var command = new SqlCommand(@"INSERT INTO Invoices(ProviderID) VALUES(@ProviderID)", connection))
                        {
                            command.Parameters.AddWithValue("@ProviderID", ProviderID);
                            command.ExecuteNonQuery();
                        }
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
            }
            else using (SqlConnection connection = new SqlConnection(Helper.source))
                {
                    try
                    {
                        connection.Open();
                        using (var command = new SqlCommand(@"SELECT * FROM Goods WHERE InvoiceID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ID", textBoxId.Text);
                            if (!(command.ExecuteScalar() is null))
                            {
                                MessageBox.Show("Для видалення накладної вона повинна бути пуста.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        DialogResult dialogResult = MessageBox.Show("Ви дійсно хочете Видалити цей запис (Номер " +
                            textBoxId.Text + ")?", "Вихід", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.OK)
                        {
                            Int32 amountExecuteNonQuery = 0;
                            using (var command = new SqlCommand(@"DELETE FROM Invoices WHERE ID = @ID", connection))
                            {
                                command.Parameters.AddWithValue("@ID", textBoxId.Text);
                                amountExecuteNonQuery = command.ExecuteNonQuery();
                            }

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
                            if (amountExecuteNonQuery != 0) MessageBox.Show("Запис успішно видалений.", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show("Запис був відсутій в базі данних.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else return;
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
            if (textBoxId.Text.Length == 0 || textBoxId.Text == "0"  || textBoxProvider.Text.Length == 0)
            {
                MessageBox.Show("Заповність всі необхідні поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else using (SqlConnection connection = new SqlConnection(Helper.source))
            {
                    try
                    {
                        connection.Open();
                        Int32 ProviderID = -1;
                        using (var command = new SqlCommand(@"SELECT ID FROM Providers WHERE Name = @ProviderName", connection))
                        {
                            command.Parameters.AddWithValue("@ProviderName", textBoxProvider.Text);
                            ProviderID = (Int32)command.ExecuteScalar();
                        }
                        Int32 amountExecuteNonQuery = 0;

                        using (var command = new SqlCommand(@"UPDATE Invoices SET ProviderID = @ProviderID, Date = '" +
                            dateTimePicker.Value.ToString("yyyy-MM-dd hh:mm:ss") + "' WHERE ID = @ID", connection))
                        {
                            command.Parameters.AddWithValue("@ProviderID", ProviderID);
                            command.Parameters.AddWithValue("@ID", textBoxId.Text);
                            amountExecuteNonQuery = command.ExecuteNonQuery();
                        }

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
            textBoxId.Text = "0";
            textBoxProvider.Clear();
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
            String query = "SELECT Invoices.ID 'Накладна', Providers.Name 'Постачальник', Invoices.Date 'Дата' FROM Invoices " +
                "JOIN Providers ON ProviderID = Providers.ID";
            readData(DataSetMain, query);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DataSetMain;
            dataGridViewGoods.DataSource = bindingSource;
            RefreshAutoComplete(RefreshTableName.Search);

            try
            {
                dataGridViewGoods.Columns["Дата"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nПомилка при встановленні формату дати", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                dataGridViewGoods.Columns[0].FillWeight = 7;
                dataGridViewGoods.Columns[1].FillWeight = 16;
                dataGridViewGoods.Columns[2].FillWeight = 10;

                if (dataGridViewGoods.RowCount > 0)
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

                    using (SqlConnection connection = new SqlConnection(Helper.source))
                    {
                        try
                        {
                            connection.Open();

                            using (var command = new SqlCommand(@"SELECT * FROM Goods WHERE InvoiceID = @ID", connection))
                            {
                                SqlParameter parameter;
                                foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                                {
                                    parameter = command.Parameters.AddWithValue("@ID", row.Cells[0].Value);
                                    if (command.ExecuteScalar() is null)
                                    {
                                        row.HeaderCell.Style.BackColor = Color.FromArgb(192, 0, 0);
                                        row.HeaderCell.Style.SelectionBackColor = Color.FromArgb(192, 0, 0);
                                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 0, 0);
                                    }
                                    else
                                    {
                                        row.HeaderCell.Style.BackColor = Color.WhiteSmoke;
                                        row.HeaderCell.Style.SelectionBackColor = SystemColors.Highlight;
                                        row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                                    }
                                    command.Parameters.Remove(parameter);
                                }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public enum RefreshTableName { Provider, Search }

        public void RefreshAutoComplete(RefreshTableName refreshTableName)
        {
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            if (refreshTableName == RefreshTableName.Search)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                    {
                        stringCollection.Add(row.Cells[1].Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nПомилка при зчитуванні з бази данних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBoxSearch.AutoCompleteCustomSource = stringCollection;
            }
            else
            {
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(Helper.source))
                {
                    try
                    {
                        connection.Open();
                        using (var command = new SqlCommand(@"SELECT Name FROM Providers", connection))
                        {
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                stringCollection.Add(reader.GetString(0));
                            }
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
                    textBoxProvider.AutoCompleteCustomSource = stringCollection;
                }
            }
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
                if (!(dataGridViewRow.Cells[2].Value is null)) dateTimePicker.Text = dataGridViewRow.Cells[2].Value.ToString();
            }
        }

        private Boolean isKeyDownEnter = false;

        private void textBoxId_KeyDown(object sender, KeyEventArgs e) // filling the textBoxs by id
        {
            if (e.KeyCode == Keys.Enter)
            {
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
                else isKeyDownEnter = true;
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
            //        fLastQuery = query = "SELECT * FROM " + MainTable + " WHERE ProviderID = '" + providerTextBox.Text + "'";
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
            //        fLastQuery = query = "SELECT * FROM " + MainTable + " WHERE c_kind = '" + typeTextBox.Text + "'";
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

        private void readData(DataTable dataTable, String query)
        {
            using (SqlConnection connection = new SqlConnection(Helper.source))
            {
                try
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        dataTable.Clear();
                        SqlDataAdapter DBDataAdapter = new SqlDataAdapter();
                        DBDataAdapter.SelectCommand = command;
                        DBDataAdapter.Fill(dataTable);
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
                    panelBehindTextBoxs.Enabled = true;
                    panelBehindTextBoxs.Height += 13;
                    if (panelBehindTextBoxs.Size.Height == panelBehindTextBoxs.MaximumSize.Height)
                    {
                        if (!isActiveButtonAdd && !isActiveButtonDelete && !isActiveButtonEdit) timer1.Stop();
                        isCollapsedPanelTextBoxs = false;
                        isActivePanelTextBoxs = false;
                    }
                }
                else
                {
                    panelBehindTextBoxs.Enabled = false;
                    panelBehindTextBoxs.Height -= 13;
                    if (panelBehindTextBoxs.Size.Height == panelBehindTextBoxs.MinimumSize.Height)
                    {
                        if (!isActiveButtonAdd && !isActiveButtonDelete && !isActiveButtonEdit) timer1.Stop();
                        isCollapsedPanelTextBoxs = true;
                        isActivePanelTextBoxs = false;
                        panelBehindTextBoxs.Hide();
                    }   
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "0";
            textBoxId.Enabled = false;
            textBoxProvider.Enabled = true;
            dateTimePicker.Enabled = false;
            buttonClear.Enabled = true;
            isActiveButtonAdd = true;
            if (isCollapsedButtonDelete && isCollapsedButtonEdit)
                if (!isActiveButtonDelete && !isActiveButtonEdit)
                {
                    isActivePanelTextBoxs = true;
                    panelBehindTextBoxs.Show();
                }
            panelButtonAdd.Show();
            timer1.Start();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            textBoxId.Enabled = true;
            textBoxProvider.Enabled = false;
            dateTimePicker.Enabled = false;
            buttonClear.Enabled = true;
            isActiveButtonDelete = true;
            if (isCollapsedButtonAdd && isCollapsedButtonEdit)
                if (!isActiveButtonAdd && !isActiveButtonEdit)
                {
                    isActivePanelTextBoxs = true;
                    panelBehindTextBoxs.Show();
                }
            panelButtonDelete.Show();
            timer1.Start();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            textBoxId.Enabled = false;
            textBoxProvider.Enabled = true;
            dateTimePicker.Enabled = true;
            buttonClear.Enabled = true;
            isActiveButtonEdit = true;
            if (isCollapsedButtonAdd && isCollapsedButtonDelete)
                if (!isActiveButtonAdd && !isActiveButtonDelete)
                {
                    isActivePanelTextBoxs = true;
                    panelBehindTextBoxs.Show();
                }
            panelButtonEdit.Show();
            timer1.Start();
        }

        private void buttonAddCancel_Click(object sender, EventArgs e)  
        {
            buttonClear.Enabled = false;
            isActiveButtonAdd = true;
            if (!isActiveButtonDelete && !isActiveButtonEdit) isActivePanelTextBoxs = true;
            timer1.Start();
        }

        private void buttonDeleteCancel_Click(object sender, EventArgs e)
        {
            buttonClear.Enabled = false;
            isActiveButtonDelete = true;
            if (!isActiveButtonAdd && !isActiveButtonEdit) isActivePanelTextBoxs = true;
            timer1.Start();
        }

        private void Goods_Load(object sender, EventArgs e)
        {
            RefreshAutoComplete(RefreshTableName.Provider);
            LoadData();
        }

        private void textBoxProvider_Leave(object sender, EventArgs e)
        {
            if (!textBoxProvider.AutoCompleteCustomSource.Contains(textBoxProvider.Text))
                textBoxProvider.Clear();
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
                dateTimePicker.Value = DateTime.Now;
            }
            else isKeyDownEnter = false;
        }

        private Boolean textBoxSearchEnter = false;

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxSearchEnter)
                if (textBoxSearch.Focused)
                {
                    textBoxId.Text = "0";
                    textBoxProvider.Clear();
                    dateTimePicker.Value = DateTime.Now;

                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridViewGoods.DataSource = DataSetMain;
                        return;
                    }

                    Char temp = textBoxSearch.Text[0];
                    if (temp == '[' || temp == ']' || temp == '*' || temp == '%')
                    {
                        textBoxSearch.Text = textBoxSearch.Text.Remove(0, 1);
                    }
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridViewGoods.DataSource = DataSetMain;
                        return;
                    }

                    temp = textBoxSearch.Text[textBoxSearch.Text.Length - 1];
                    if (temp == '[' || temp == ']' || temp == '*' || temp == '%')
                    {
                        textBoxSearch.Text = textBoxSearch.Text.Remove(0, 1);
                    }
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridViewGoods.DataSource = DataSetMain;
                        return;
                    }

                    DataView dataView = new DataView(DataSetMain);
                    String pattern = textBoxSearch.Text;
                    StringBuilder pattertB = new StringBuilder();

                    Int32 index = pattern.IndexOf('*', 0);
                    if (index != -1)
                    {
                        while (index != -1)
                        {
                            pattertB.Append(pattern.Substring(0, index) + "[*]" + pattern.Substring(index + 1));
                            index = pattern.IndexOf('*', index + 1);
                        }
                        pattern = pattertB.ToString();
                    }
                    index = pattern.IndexOf('%', 0);
                    if (index != -1)
                    {
                        while (index != -1)
                        {
                            pattertB.Append(pattern.Substring(0, index) + "[%]" + pattern.Substring(index + 1));
                            index = pattern.IndexOf('%', index + 1);
                        }
                        pattern = pattertB.ToString();
                    }

                    dataView.RowFilter = String.Format("Постачальник LIKE '%{0}%'", pattern);
                    dataGridViewGoods.DataSource = dataView;

                }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            textBoxSearchEnter = true;
            textBoxSearch.Clear();
            textBoxSearchEnter = false;
            textBoxSearch.ForeColor = SystemColors.WindowText;
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (textBoxSearch.TextLength == 0)
            {
                textBoxSearch.Text = "Пошук...";
                dataGridViewGoods.DataSource = DataSetMain;
                textBoxSearch.ForeColor = Color.FromArgb(207, 214, 230);
            }
        }

        private void toolStripMenuItemBalance_Click(object sender, EventArgs e)
        {
            using (Products products = new Products())
            {
                products.ShowDialog();
            }
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"^\d*$");
            if (!regex.IsMatch(textBoxId.Text))
            {
                textBoxId.Text = "0";
            }
        }

        private void dataGridViewGoods_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dataGridViewRow = dataGridViewGoods.Rows[e.RowIndex];
            using (Goods goods = new Goods(dataGridViewRow.Cells[0].Value.ToString()))
            {
                if(goods.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection connection = new SqlConnection(Helper.source))
                    {
                        try
                        {
                            connection.Open();

                            using (var command = new SqlCommand(@"SELECT * FROM Goods WHERE InvoiceID = @ID", connection))
                            {
                                SqlParameter parameter;
                                foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                                {
                                    parameter = command.Parameters.AddWithValue("@ID", row.Cells[0].Value);
                                    if (command.ExecuteScalar() is null)
                                    {
                                        row.HeaderCell.Style.BackColor = Color.FromArgb(192, 0, 0);
                                        row.HeaderCell.Style.SelectionBackColor = Color.FromArgb(192, 0, 0);
                                        row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 0, 0);
                                    }
                                    else
                                    {
                                        row.HeaderCell.Style.BackColor = Color.WhiteSmoke;
                                        row.HeaderCell.Style.SelectionBackColor = SystemColors.Highlight;
                                        row.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
                                    }
                                    command.Parameters.Remove(parameter);
                                }
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
            }
        }

        private void dataGridViewGoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewGoods.CurrentCell = dataGridViewGoods.Rows[e.RowIndex].Cells[1];
            dataGridViewGoods.CurrentCell.Selected = true;

            DataGridViewRow dataGridViewRow = dataGridViewGoods.Rows[e.RowIndex];
            if (!(dataGridViewRow.Cells[0].Value is null)) textBoxId.Text = dataGridViewRow.Cells[0].Value.ToString();
            if (!(dataGridViewRow.Cells[1].Value is null)) textBoxProvider.Text = dataGridViewRow.Cells[1].Value.ToString();
            if (!(dataGridViewRow.Cells[2].Value is null)) dateTimePicker.Text = dataGridViewRow.Cells[2].Value.ToString();
        }

        private void buttonEditCancel_Click(object sender, EventArgs e)
        {
            buttonClear.Enabled = false;
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

    public partial class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }

    public partial class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(253, 244, 191); }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(253, 244, 191); }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(253, 244, 191); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(253, 244, 191); }
        }

        public override Color MenuBorder
        {
            get { return Color.FromArgb(14, 126, 152); }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(234, 240, 255); }
        }
    }
}
