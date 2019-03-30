using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb;";

        private OleDbConnection myConnection;
        
        private Cars _cars;
        private Drivers _drivers;
        private Routes _routes;
        private Providers _providers;

        public Cars Cars { get { return _cars; } }
        public Drivers Drivers { get { return _drivers; } }
        public Routes Routes { get { return _routes; } }
        public Providers Providers { get { return _providers; } }

        public DataGridView DataGridView { get { return dataGridViewGoods; } }

        private bool _isFirst; // if this form is open first

        public Goods(bool isFirst)
        {
            InitializeComponent();
            createTempDataGridView();
            //createTempListBox();
            myConnection = new OleDbConnection(connectString);
            _isFirst = isFirst;

            if (isFirst)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                myConnection.Open();
                LoadData();

                _cars = new Cars(false);
                _drivers = new Drivers(false);
                _routes = new Routes(false);
                _providers = new Providers(false);

                _cars.Synch(this);
                _drivers.Synch(this);
                _routes.Synch(this);
                _providers.Synch(this);
            }
        }

        public void Synch(Form form) // assigning pointers to all forms
        {
            if (form.GetType() == typeof(Cars))
            {
                _cars = (Cars)form;
                _drivers = _cars.Drivers;
                _routes = _cars.Routes;
                _providers = _cars.Providers;
            }
            else if (form.GetType() == typeof(Drivers))
            {
                _drivers = (Drivers)form;
                _cars = _drivers.Cars;
                _routes = _drivers.Routes;
                _providers = _drivers.Providers;
            }
            else if (form.GetType() == typeof(Routes))
            {
                _routes = (Routes)form;
                _cars = _routes.Cars;
                _drivers = _routes.Drivers;
                _providers = _routes.Providers;
            }
            else
            {
                _providers = (Providers)form;
                _cars = _providers.Cars;
                _drivers = _providers.Drivers;
                _routes = _providers.Routes;
            }
        } 

        private void Goods_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Goods_VisibleChanged(object sender, EventArgs e)
        {
            if (_isFirst) _isFirst = false;
            else
            {
                if (this.Visible == true)
                {
                    myConnection.Open();
                    LoadData();
                }
                else myConnection.Close();
            }
        }

        private void addButton_Click(object sender, EventArgs e) // add button click
        {
            String query = "SELECT * FROM Goods WHERE c_code = '" + codTextBox.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteScalar() == null)
            {
                query = "INSERT INTO Goods VALUES ('" + codTextBox.Text + "', '" + providerTextBox.Text + "', '" + routeTextBox.Text + "', '"
                    + carTextBox.Text + "', '" + typeTextBox.Text + "', '" + nameTextBox.Text + "', " + amountTextBox.Text + ", '" + dateTimePicker1.Value.ToString() + "')";
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                LoadData();
                foreach(DataGridViewRow row in dataGridViewGoods.Rows)
                { 
                    if(row.Cells[0].Value.ToString() == codTextBox.Text)
                    {
                        dataGridViewGoods.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("В БД вже є перевезення з таким кодом", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                codTextBox.Focus();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) // delete button click
        {
            String query = "DELETE * FROM Goods WHERE c_code = '" + codTextBox.Value.ToString() + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                codTextBox.Value = 0;
                providerTextBox.Clear();
                routeTextBox.Clear();
                carTextBox.Clear();
                typeTextBox.Clear();
                nameTextBox.Clear();
                amountTextBox.Value = 0;
                LoadData();
                dataGridViewGoods.Focus();
            }
            else
            {
                MessageBox.Show("В БД відсутній такий запис!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                codTextBox.Focus();
            }
        }

        private void updateButton_Click(object sender, EventArgs e) // update button click
        {
            string query = "UPDATE Goods SET c_prov = '" + providerTextBox.Text + "', c_rout = '" + routeTextBox.Text + "', c_car = '"
                    + carTextBox.Text + "', c_kind = '" + typeTextBox.Text + "', c_name = '" + nameTextBox.Text + "', c_amount = " 
                    + amountTextBox.Text + ", c_date = '" + dateTimePicker1.Value.ToString() + "' WHERE c_code = '" + codTextBox.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                LoadData();
                foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                {
                    if (row.Cells[0].Value.ToString() == codTextBox.Text)
                    {
                        dataGridViewGoods.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("В БД відсутній такий запис!\nДобавити цей запис в таблицю Перевезення?",
                    "Помилка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    query = "INSERT INTO Goods VALUES ('" + codTextBox.Text + "', '" + providerTextBox.Text + "', '" + routeTextBox.Text + "', '"
                    + carTextBox.Text + "', '" + typeTextBox.Text + "', '" + nameTextBox.Text + "', " + amountTextBox.Text + ", '" + dateTimePicker1.Value.ToString() + "')";
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    LoadData();
                    foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == codTextBox.Text)
                        {
                            dataGridViewGoods.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e) // clear button click
        {
            codTextBox.Value = 0;
            providerTextBox.Clear();
            routeTextBox.Clear();
            carTextBox.Clear();
            typeTextBox.Clear();
            nameTextBox.Clear();
            amountTextBox.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void filterButton_Click(object sender, EventArgs e) // filter button click
        {
            checkedListBox1.Location = new Point(filterButton.Location.X + ((MouseEventArgs)e).X - 5, filterButton.Location.Y + ((MouseEventArgs)e).Y - 5);
            checkedListBox1.BringToFront();
            checkedListBox1.Show();
            checkedListBox1.Focus();
        }

        private void CarsToolStripMenuItem_Click(object sender, EventArgs e) // switching to Cars form
        {
            this.Hide();
            _cars.Location = this.Location;
            _cars.Show();
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e) // switching to Drivers form
        {
            this.Hide();
            _drivers.Location = this.Location;
            _drivers.Show();
        }

        private void RoutesToolStripMenuItem_Click(object sender, EventArgs e) // switching to Routes form
        {
            this.Hide();
            _routes.Location = this.Location;
            _routes.Show();
        }

        private void ProvidersToolStripMenuItem_Click(object sender, EventArgs e) // switching to Providers form
        {
            this.Hide();
            _providers.Location = this.Location;
            _providers.Show();
        }

        private void LoadData() // loading records from the database
        {
            String query = "SELECT * FROM Goods";
            dataGridViewGoods.Rows.Clear();
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = dataGridViewGoods.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    dataGridViewGoods.Rows[n].Cells[i].Value = reader[i].ToString();
                }
            }
            reader.Close();
        }

        private void TextBoxTextChanged(object sender, EventArgs e) // disabling buttons when some textBox is empty
        {
            if (codTextBox.Value > 0 && providerTextBox.TextLength > 0 && routeTextBox.TextLength > 0 && carTextBox.TextLength > 0
                && typeTextBox.TextLength > 0 && nameTextBox.TextLength > 0 && amountTextBox.Value > 0)
            { addButton.Enabled = true; deleteButton.Enabled = true; updateButton.Enabled = true; }
            else { addButton.Enabled = false; deleteButton.Enabled = false; updateButton.Enabled = false; }
        }
                
        private void dataGridViewGoods_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e) // filling in textBoxs by the selected line
        {
            Int32 rowIndex = dataGridViewGoods.SelectedRows[0].Index;
            DataGridViewRow dataGridViewRow = dataGridViewGoods.Rows[rowIndex];

            codTextBox.Text = dataGridViewRow.Cells[0].Value.ToString();
            providerTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
            routeTextBox.Text = dataGridViewRow.Cells[2].Value.ToString();
            carTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
            typeTextBox.Text = dataGridViewRow.Cells[4].Value.ToString();
            nameTextBox.Text = dataGridViewRow.Cells[5].Value.ToString();
            amountTextBox.Text = dataGridViewRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridViewRow.Cells[7].Value.ToString();
        }

        private void codTextBox_KeyDown(object sender, KeyEventArgs e) // filling the textBoxs by code
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewRow row in dataGridViewGoods.Rows)
                {
                    if (row.Cells[0].Value.ToString() == codTextBox.Text)
                    {
                        providerTextBox.Text = row.Cells[1].Value.ToString();
                        routeTextBox.Text = row.Cells[2].Value.ToString();
                        carTextBox.Text = row.Cells[3].Value.ToString();
                        typeTextBox.Text = row.Cells[4].Value.ToString();
                        nameTextBox.Text = row.Cells[5].Value.ToString();
                        amountTextBox.Text = row.Cells[6].Value.ToString();
                        dateTimePicker1.Text = row.Cells[7].Value.ToString();
                    }
                }
            }
        }

        private DataGridView tempDataGridView;

        private void createTempDataGridView()
        {
            tempDataGridView = new DataGridView();
            tempDataGridView.AllowUserToAddRows = false;
            tempDataGridView.AllowUserToDeleteRows = false;
            tempDataGridView.AllowUserToResizeColumns = false;
            tempDataGridView.AllowUserToResizeRows = false;
            tempDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            tempDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tempDataGridView.MultiSelect = false;
            tempDataGridView.Name = "tempDataGridView";
            tempDataGridView.ReadOnly = true;
            tempDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            tempDataGridView.RowHeadersVisible = false;
            tempDataGridView.RowTemplate.Height = 24;
            tempDataGridView.ScrollBars = ScrollBars.None;
            tempDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tempDataGridView.TabIndex = 43;
            tempDataGridView.Visible = false;
            tempDataGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            tempDataGridView.CellMouseUp += tempDataGridView_CellMouseUp;
            tempDataGridView.VisibleChanged += new System.EventHandler(tempDataGridView_VisibleChanged);
            tempDataGridView.Leave += new System.EventHandler(tempDataGridView_Leave);
            tempDataGridView.MouseLeave += new System.EventHandler(tempDataGridView_Leave);
            Controls.Add(tempDataGridView);
            tempDataGridView.BringToFront();
        }

        private void copyDataGridView(DataGridView from, DataGridView to)
        {
            DataGridViewColumn[] dataGridViewColumns = new DataGridViewColumn[from.ColumnCount];
            DataGridViewColumn tempDataGridViewColumn;
            for (Int32 i = 0; i < from.ColumnCount; i++)
            {
                tempDataGridViewColumn = from.Columns[i].Clone() as DataGridViewColumn;
                tempDataGridViewColumn.Name = "TempDataGridViewTextBoxColumn" + i.ToString();
                dataGridViewColumns[i] = tempDataGridViewColumn;
            }
            to.Columns.AddRange(dataGridViewColumns);
        }

        private void providerTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            copyDataGridView(_drivers.DataGridView, tempDataGridView);
            tempDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tempDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            String query = "SELECT * FROM Providers";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = tempDataGridView.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    tempDataGridView.Rows[n].Cells[i].Value = reader[i].ToString();
                }
            }
            reader.Close();

            tempDataGridView.Name = "tempDataGridView1";
            tempDataGridView.Location = new Point(providerTextBox.Location.X + providerTextBox.Size.Width, providerTextBox.Location.Y + providerTextBox.Size.Height);
            tempDataGridView.Show();
            tempDataGridView.Columns[0].Width = 0;
            tempDataGridView.Columns[1].Width = 0;
            tempDataGridView.Size = new Size(tempDataGridView.Columns[0].Width + tempDataGridView.Columns[1].Width,
                (tempDataGridView.RowCount + 1) * tempDataGridView.Rows[0].Height);
            tempDataGridView.Focus();
        }

        private void routeTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            copyDataGridView(_routes.DataGridView, tempDataGridView);
            tempDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tempDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tempDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            String query = "SELECT * FROM Routes";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = tempDataGridView.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    if (i == reader.VisibleFieldCount - 1)
                    {
                        tempDataGridView.Rows[n].Cells[i].Value = reader[i].ToString() + " км.";
                        continue;
                    }
                    tempDataGridView.Rows[n].Cells[i].Value = reader[i].ToString();
                }
            }
            reader.Close();

            tempDataGridView.Name = "tempDataGridView2";
            tempDataGridView.Location = new Point(routeTextBox.Location.X + routeTextBox.Size.Width, routeTextBox.Location.Y + routeTextBox.Size.Height);
            tempDataGridView.Show();
            tempDataGridView.Columns[0].Width = 0;
            tempDataGridView.Columns[1].Width = 0;
            tempDataGridView.Columns[2].Width = 0;
            tempDataGridView.Size = new Size(tempDataGridView.Columns[0].Width + tempDataGridView.Columns[1].Width 
                + tempDataGridView.Columns[2].Width, (tempDataGridView.RowCount + 1) * tempDataGridView.Rows[0].Height);
            tempDataGridView.Focus(); 
        }

        private void carTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            copyDataGridView(_cars.DataGridView, tempDataGridView);
            tempDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tempDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            String query = "SELECT * FROM Cars";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = tempDataGridView.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    tempDataGridView.Rows[n].Cells[i].Value = reader[i].ToString();
                }
            }
            reader.Close();
            tempDataGridView.Name = "tempDataGridView3";
            tempDataGridView.Location = new Point(carTextBox.Location.X + carTextBox.Size.Width, carTextBox.Location.Y + carTextBox.Size.Height);
            tempDataGridView.Show();
            tempDataGridView.Columns[0].Width = 0;
            tempDataGridView.Columns[1].Width = 0;
            tempDataGridView.Size = new Size(tempDataGridView.Columns[0].Width + tempDataGridView.Columns[1].Width, (tempDataGridView.RowCount + 1) * tempDataGridView.Rows[0].Height);
            tempDataGridView.Focus();
        }

        private void tempDataGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(((DataGridView)sender).Name == "tempDataGridView1")
            {
                providerTextBox.Text = tempDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            }
            else if (((DataGridView)sender).Name == "tempDataGridView2")
            {
                routeTextBox.Text = tempDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            }
            else if (((DataGridView)sender).Name == "tempDataGridView3")
            {
                carTextBox.Text = tempDataGridView.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void tempDataGridView_VisibleChanged(object sender, EventArgs e)
        {
            if (tempDataGridView.Visible == false)
            {
                tempDataGridView.Rows.Clear();
                tempDataGridView.Columns.Clear();
            }
        }

        private void tempDataGridView_Leave(object sender, EventArgs e)
        {
            tempDataGridView.Hide();
        }

        private void checkListBox1_Leave(object sender, EventArgs e)
        {
            checkedListBox1.Hide();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            String query = "";
            if (checkedListBox1.SelectedIndex == 0)
            {
                if (checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Unchecked)
                {
                    checkedListBox1.Hide();
                    LoadData();
                    return;
                }
                if (providerTextBox.TextLength > 0)
                {
                    foreach (int index in checkedListBox1.CheckedIndices)
                    {
                        if (index != checkedListBox1.SelectedIndex) checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
                    }
                    query = "SELECT * FROM Goods WHERE c_prov = '" + providerTextBox.Text + "'";
                }
                else
                {
                    checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex, CheckState.Unchecked);
                    checkedListBox1.Hide();
                    return;
                }
            }
            else if (checkedListBox1.SelectedIndex == 1)
            {
                if (checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Unchecked)
                {
                    checkedListBox1.Hide();
                    LoadData();
                    return;
                }
                if (routeTextBox.TextLength > 0)
                {
                    foreach (int index in checkedListBox1.CheckedIndices)
                    {
                        if (index != checkedListBox1.SelectedIndex) checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
                    }
                    query = "SELECT * FROM Goods WHERE c_rout = '" + routeTextBox.Text + "'";
                }
                else
                {
                    checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex, CheckState.Unchecked);
                    checkedListBox1.Hide();
                    return;
                }

            }
            else if (checkedListBox1.SelectedIndex == 2)
            {
                if (checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Unchecked)
                {
                    checkedListBox1.Hide();
                    LoadData();
                    return;
                }
                if (carTextBox.TextLength > 0)
                {
                    foreach (int index in checkedListBox1.CheckedIndices)
                    {
                        if (index != checkedListBox1.SelectedIndex) checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
                    }
                    query = "SELECT * FROM Goods WHERE c_car = '" + carTextBox.Text + "'";
                }
                else
                {
                    checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex, CheckState.Unchecked);
                    checkedListBox1.Hide();
                    return;
                }
            }
            else if (checkedListBox1.SelectedIndex == 3)
            {
                if (checkedListBox1.GetItemCheckState(checkedListBox1.SelectedIndex) == CheckState.Unchecked)
                {
                    checkedListBox1.Hide();
                    LoadData();
                    return;
                }
                if (typeTextBox.TextLength > 0)
                {
                    foreach (int index in checkedListBox1.CheckedIndices)
                    {
                        if (index != checkedListBox1.SelectedIndex) checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
                    }
                    query = "SELECT * FROM Goods WHERE c_kind = '" + typeTextBox.Text + "'";
                }
                else
                {
                    checkedListBox1.SetItemCheckState(checkedListBox1.SelectedIndex, CheckState.Unchecked);
                    checkedListBox1.Hide();
                    return;
                }
            }
            checkedListBox1.Hide();
            dataGridViewGoods.Rows.Clear();
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = dataGridViewGoods.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    dataGridViewGoods.Rows[n].Cells[i].Value = reader[i].ToString();
                }
            }
            reader.Close();
        }

        /*private ListBox tempListBox;

        private void createTempListBox()
        {
            tempListBox = new ListBox();
            tempListBox.Items.AddRange(new object[] { "Створити таблицю" });
            tempListBox.Visible = false;
            tempListBox.SelectedIndexChanged += new System.EventHandler(this.tempListBox_SelectedIndexChanged);
            tempListBox.Leave += new System.EventHandler(this.tempListBox_Leave);
            tempListBox.MouseLeave += new System.EventHandler(this.tempListBox_Leave);
            Controls.Add(tempListBox);     
        }

        private void GoodsToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tempListBox.Location = new Point(100, 100);
                tempListBox.BringToFront();
                tempListBox.Focus();
                tempListBox.Show();
            }
        }

        private Form tempForm;

        private void createTempForm()
        {
            tempForm = new Form();
            Button yesButton = new Button();
            Button noButton = new Button();
            Controls.Add(tempForm);
            tempForm.BringToFront();
            
        }

        private void tempListBox_Leave(object sender, EventArgs e)
        {
            tempListBox.Hide();
        }

        private void tempListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            tempListBox.Hide();
        }
        */
    }
}
