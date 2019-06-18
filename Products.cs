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
    public partial class Products : Form
    {
        private DataTable DataTableProducts;

        public Products()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            this.DataTableProducts = new DataTable();
            LoadData();
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

        private void LoadData()
        {
            String query = "SELECT Products.ID, Kinds.Name 'Тип', Products.Name 'Назва', SUM(Amount) 'Залишок' " +
                "FROM Goods " +
                "FULL JOIN Products ON Goods.ProductID = Products.ID " +
                "JOIN Kinds ON Products.KindID = Kinds.ID " +
                "GROUP BY Products.ID, Kinds.Name, Products.Name " +
                "ORDER BY Kinds.Name";
            readData(DataTableProducts, query);

            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = DataTableProducts;
            dataGridView.DataSource = bindingSource;

            try
            {
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].FillWeight = 14;
                dataGridView.Columns[2].FillWeight = 25;
                dataGridView.Columns[3].FillWeight = 6;
                dataGridView.Columns[3].DefaultCellStyle.NullValue = "0,000";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            AutoCompleteStringCollection stringCollection = new AutoCompleteStringCollection();
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
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

        private void Providers_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private Boolean textBoxSearchEnter = false;

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxSearchEnter)
                if (textBoxSearch.Focused)
                {
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridView.DataSource = DataTableProducts;
                        return;
                    }

                    Char temp = textBoxSearch.Text[0];
                    if (temp == '[' || temp == ']' || temp == '*' || temp == '%')
                    {
                        textBoxSearch.Text = textBoxSearch.Text.Remove(0, 1);
                    }
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridView.DataSource = DataTableProducts;
                        return;
                    }

                    temp = textBoxSearch.Text[textBoxSearch.Text.Length - 1];
                    if (temp == '[' || temp == ']' || temp == '*' || temp == '%')
                    {
                        textBoxSearch.Text = textBoxSearch.Text.Remove(0, 1);
                    }
                    if (textBoxSearch.Text == String.Empty)
                    {
                        dataGridView.DataSource = DataTableProducts;
                        return;
                    }

                    DataView dataView = new DataView(DataTableProducts);
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
            dataGridView.DataSource = DataTableProducts;
            textBoxSearch.ForeColor = Color.FromArgb(207, 214, 230);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewCell dataGridViewCurrentCell = dataGridView.CurrentCell;
            if (dataGridViewCurrentCell != null)
            {
                Int32 rowIndex = dataGridViewCurrentCell.RowIndex;
                DataGridViewRow dataGridViewRow = dataGridView.Rows[rowIndex];

                String query = "SELECT Amount 'Кількість', Date 'Дата' FROM Invoices " +
                    $"JOIN Goods ON Goods.InvoiceID = Invoices.ID WHERE Goods.ProductID = { dataGridViewRow.Cells[0].Value }";
                dataGridViewInOut.Rows.Clear();
                using (SqlConnection connection = new SqlConnection(Helper.source))
                {
                    try
                    {
                        connection.Open();

                        using (var command = new SqlCommand(query, connection))
                        {
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Int32 n = dataGridViewInOut.Rows.Add();
                                dataGridViewInOut.Rows[n].Cells[0].Value = "+" + reader[0].ToString();
                                dataGridViewInOut.Rows[n].Cells[1].Value = reader[1].ToString();
                            }

                            reader.Close();
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
        }

        private void Products_SizeChanged(object sender, EventArgs e)
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
