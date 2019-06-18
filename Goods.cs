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
using Dapper;

namespace GoodsManagement
{
    public partial class Goods : Form
    {
        public Goods(String InvoiceID, String Date)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.DataTableGoods = new DataTable();
            this.InvoiceID = InvoiceID;
            this.Date = Date;
        }

        private DataTable DataTableGoods;
        private String InvoiceID;
        private String Date;

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

        private void LoadData(Boolean makeSpecialRowSelected = false, Int32 rowIndex = 0) // loading records from the database
        {
            String query = "SELECT Goods.ID, Kinds.Name 'Тип', Products.Name 'Назва', Goods.Amount 'Кількість', Goods.Price 'Ціна' " +
                "FROM Goods " +
                "JOIN Products ON Goods.ProductID = Products.ID " +
                "JOIN Kinds ON Products.KindID = Kinds.ID " +
                $"WHERE Goods.InvoiceID = { InvoiceID }"; 
            readData(DataTableGoods, query);
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DataTableGoods;
            dataGridView.DataSource = bindingSource;

            RefreshAutoComplete(RefreshTableName.Search);

            try
            {
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].FillWeight = 14;
                dataGridView.Columns[2].FillWeight = 25;
                dataGridView.Columns[3].FillWeight = 8;
                dataGridView.Columns[4].FillWeight = 10;

                if (dataGridView.RowCount > 0)
                {
                    RefreshAutoComplete(RefreshTableName.Product);
                    if (!makeSpecialRowSelected)
                    {
                        dataGridView.CurrentCell = dataGridView.Rows[dataGridView.RowCount - 1].Cells[1];
                        dataGridView.CurrentCell.Selected = true;
                    }
                    else
                    {
                        if (rowIndex < dataGridView.RowCount && rowIndex >= 0)
                        {
                            dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[1];
                            dataGridView.CurrentCell.Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public enum RefreshTableName { Kind, Product, Search }

        public void RefreshAutoComplete(RefreshTableName refreshTableName)
        {
            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            if (refreshTableName == RefreshTableName.Search)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        stringCollection.Add(row.Cells[2].Value.ToString());
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
                String query = "";
                SqlDataReader reader;
                using (SqlConnection connection = new SqlConnection(Helper.source))
                {
                    try
                    {
                        connection.Open();
                        if (refreshTableName == RefreshTableName.Kind)
                        {
                            query = @"SELECT Name FROM Kinds";
                            using (var command = new SqlCommand(query, connection))
                            {
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    stringCollection.Add(reader.GetString(0));
                                }
                            }
                        }
                        else
                        {
                            query = @"SELECT Products.Name FROM Products " +
                                  "JOIN Kinds ON Products.KindID = Kinds.ID WHERE Kinds.Name = @KindName";
                            using (var command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@KindName", textBoxKind.Text);
                                reader = command.ExecuteReader();
                                while (reader.Read())
                                {
                                    stringCollection.Add(reader.GetString(0));
                                }   
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
                    if (refreshTableName == RefreshTableName.Kind) textBoxKind.AutoCompleteCustomSource = stringCollection;
                    textBoxProduct.AutoCompleteCustomSource = stringCollection;
                }
            }
        }

        private Boolean textBoxSearchEnter = false;

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxSearchEnter)
                if (textBoxSearch.Focused)
                {
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridView.DataSource = DataTableGoods;
                        return;
                    }

                    Char temp = textBoxSearch.Text[0];
                    if (temp == '[' || temp == ']' || temp == '*' || temp == '%')
                    {
                        textBoxSearch.Text = textBoxSearch.Text.Remove(0, 1);
                    }
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridView.DataSource = DataTableGoods;
                        return;
                    }

                    temp = textBoxSearch.Text[textBoxSearch.Text.Length - 1];
                    if (temp == '[' || temp == ']' || temp == '*' || temp == '%')
                    {
                        textBoxSearch.Text = textBoxSearch.Text.Remove(0, 1);
                    }
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridView.DataSource = DataTableGoods;
                        return;
                    }

                    DataView dataView = new DataView(DataTableGoods);
                    String pattern = textBoxSearch.Text;
                    Int32 index = pattern.IndexOf('*', 0);
                    StringBuilder pattertB = new StringBuilder();
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
                    dataView.RowFilter = String.Format("Назва LIKE '%{0}%'", pattern);
                    dataGridView.DataSource = dataView;
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
            textBoxSearch.Text = "Пошук...";
            dataGridView.DataSource = DataTableGoods;
            textBoxSearch.ForeColor = Color.FromArgb(207, 214, 230);
        }

        private void textBoxKind_Leave(object sender, EventArgs e)
        {
            if (!textBoxKind.AutoCompleteCustomSource.Contains(textBoxKind.Text)) textBoxKind.Clear();
            else RefreshAutoComplete(RefreshTableName.Product);
        }

        private void textBoxKind_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKind.AutoCompleteCustomSource.Contains(textBoxKind.Text)) textBoxProduct.Enabled = true;
            else textBoxProduct.Enabled = false;
            textBoxProduct.Clear();
        }

        private void textBoxProduct_Leave(object sender, EventArgs e)
        {
            if (!textBoxProduct.AutoCompleteCustomSource.Contains(textBoxProduct.Text))
                textBoxProduct.Clear();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxKind.Text.Length == 0 || textBoxProduct.Text.Length == 0 || textBoxAmount.Value == 0 || textBoxPrice.Value == 0)
            {
                MessageBox.Show("Заповність всі необхідні поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else using (SqlConnection connection = new SqlConnection(Helper.source))
                {
                    try
                    {
                        connection.Open();
                        Int32 ProductID = -1;
                        using (var command = new SqlCommand(@"SELECT ID FROM Products WHERE Name = @Name", connection))
                        {
                            command.Parameters.AddWithValue("@Name", textBoxProduct.Text);
                            ProductID = (Int32)command.ExecuteScalar();
                        }

                        using (var command = new SqlCommand(@"INSERT INTO Goods(InvoiceID, ProductID, Amount, Price) " +
                            "VALUES(@ID, @PRODUCT, @AMOUNT, @PRICE)", connection))
                        {
                            command.Parameters.AddWithValue("@ID", InvoiceID);
                            command.Parameters.AddWithValue("@PRODUCT", ProductID);
                            SqlParameter parameter = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
                            parameter.Scale = 3;
                            parameter.Value = Decimal.Multiply(textBoxAmount.Value, 1.000M);
                            command.Parameters.Add(parameter);
                            parameter = new SqlParameter("@PRICE", SqlDbType.Decimal);
                            parameter.Scale = 2;
                            parameter.Value = Decimal.Multiply(textBoxPrice.Value, 1.00M);
                            command.Parameters.Add(parameter);
                            command.ExecuteNonQuery();
                        }

                        LoadData();
                        MessageBox.Show("Товар успішно доданий", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell dataGridViewCurrentCell = dataGridView.CurrentCell;
            if (dataGridViewCurrentCell != null)
            {
                using (SqlConnection connection = new SqlConnection(Helper.source))
                {
                    try
                    {
                        Int32 rowIndex = dataGridViewCurrentCell.RowIndex;
                        DataGridViewRow dataGridViewRow = dataGridView.Rows[rowIndex];

                        connection.Open();
                        Int32 amountExecuteNonQuery = 0;
                        using (var command = new SqlCommand(@"DELETE FROM Goods WHERE ID = @GoodID", connection))
                        {
                            command.Parameters.AddWithValue("@GoodID", dataGridViewRow.Cells[0].Value.ToString());
                            amountExecuteNonQuery = command.ExecuteNonQuery();
                        }

                        if (dataGridView.RowCount > 2) LoadData(true, rowIndex - 1);
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
            else
            {
                MessageBox.Show("Невірно вказаний запис або таблиця пуста.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell dataGridViewCurrentCell = dataGridView.CurrentCell;
            if (dataGridViewCurrentCell != null)
            {
                Int32 rowIndex = dataGridViewCurrentCell.RowIndex;
                DataGridViewRow dataGridViewRow = dataGridView.Rows[rowIndex];
                if (!(dataGridViewRow.Cells[1].Value is null)) textBoxKind.Text = dataGridViewRow.Cells[1].Value.ToString();
                if (!(dataGridViewRow.Cells[2].Value is null)) textBoxProduct.Text = dataGridViewRow.Cells[2].Value.ToString();
                if (!(dataGridViewRow.Cells[3].Value is null)) textBoxAmount.Text = dataGridViewRow.Cells[3].Value.ToString();
                if (!(dataGridViewRow.Cells[4].Value is null)) textBoxPrice.Text = dataGridViewRow.Cells[4].Value.ToString();
            }
        }

        private void Goods_Load(object sender, EventArgs e)
        {
            labelHeader.Text = "Накладна №" + InvoiceID + " від " + Date;
            RefreshAutoComplete(RefreshTableName.Kind);
            LoadData();
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[1];
                dataGridView.CurrentCell.Selected = true;

                DataGridViewRow dataGridViewRow = dataGridView.Rows[e.RowIndex];
                if (!(dataGridViewRow.Cells[1].Value is null)) textBoxKind.Text = dataGridViewRow.Cells[1].Value.ToString();
                if (!(dataGridViewRow.Cells[2].Value is null)) textBoxProduct.Text = dataGridViewRow.Cells[2].Value.ToString();
                if (!(dataGridViewRow.Cells[3].Value is null)) textBoxAmount.Text = dataGridViewRow.Cells[3].Value.ToString();
                if (!(dataGridViewRow.Cells[4].Value is null)) textBoxPrice.Text = dataGridViewRow.Cells[4].Value.ToString();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            String query = "SELECT Kinds.Name 'KindName', Products.Name 'ProductName', Goods.Amount, Goods.Price, " +
                "cast(round(Goods.Amount * Goods.Price, 2) as decimal(8,2)) 'Sum' FROM Goods " +
                "JOIN Products ON Goods.ProductID = Products.ID " +
                "JOIN Kinds ON Products.KindID = Kinds.ID " +
                $"WHERE Goods.InvoiceID = { InvoiceID }";
            DataTable dataTable = new DataTable();
            readData(dataTable, query);

            using (SqlConnection connection = new SqlConnection(Helper.source))
            {
                try
                {
                    connection.Open();
                    List<String> provider = new List<String>(3);
                    using (var command = new SqlCommand("SELECT Providers.Name, Providers.EDRPOU, Providers.IPN FROM Invoices " +
                        "JOIN Providers ON Providers.ID = Invoices.ProviderID " +
                        $"WHERE Invoices.ID = { InvoiceID }", connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        provider.Add(reader[0].ToString());
                        provider.Add(reader[1].ToString());
                        provider.Add(reader[2].ToString());
                        reader.Close();
                    }

                    using (PrintGoods printGoods = new PrintGoods(dataTable, InvoiceID, Date, provider))
                    {
                        printGoods.ShowDialog();
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

        private void Goods_SizeChanged(object sender, EventArgs e)
        {
            MainPanel.Size = new Size(this.Size.Width - 10, this.Size.Height - 10);
            MainPanel.Location = new Point(5, 5);
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

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point((this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void panelHeader_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
        }
    }
}
