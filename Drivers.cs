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

namespace GoodsManagement
{
    public partial class Drivers : Form
    {
        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb;";

        private OleDbConnection myConnection;

        private Cars _cars;
        private Routes _routes;
        private Goods _goods;
        private Providers _providers;

        public Cars Cars { get { return _cars; } }
        public Routes Routes { get { return _routes; } }
        public Goods Goods { get { return _goods; } }
        public Providers Providers { get { return _providers; } }

        public DataGridView DataGridView { get { return dataGridViewDrivers; } }

        private Boolean _isFirst;

        public Drivers(bool isFirst)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            _isFirst = isFirst;

            if (isFirst)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                myConnection.Open();
                LoadData();

                _cars = new Cars(false);
                _routes = new Routes(false);
                _goods = new Goods(false);
                _providers = new Providers(false);

                _cars.Synch(this);
                _routes.Synch(this);
                _goods.Synch(this);
                _providers.Synch(this);
            }
        }

        public void Synch(Form form)
        {
            if (form.GetType() == typeof(Cars))
            {
                _cars = (Cars)form;
                _routes = _cars.Routes;
                _goods = _cars.Goods;
                _providers = _cars.Providers;
            }
            else if (form.GetType() == typeof(Routes))
            {
                _routes = (Routes)form;
                _cars = _routes.Cars;
                _goods = _routes.Goods;
                _providers = _routes.Providers;
            }
            else if (form.GetType() == typeof(Goods))
            {
                _goods = (Goods)form;
                _cars = _goods.Cars;
                _routes = _goods.Routes;
                _providers = _goods.Providers;
            }
            else
            {
                _providers = (Providers)form;
                _cars = _providers.Cars;
                _routes = _providers.Routes;
                _goods = _providers.Goods;
            }
        }

        private void Drivers_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Drivers_VisibleChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Drivers WHERE d_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteScalar() == null)
            {
                query = "INSERT INTO Drivers VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                LoadData();
                foreach (DataGridViewRow row in dataGridViewDrivers.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewDrivers.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("В БД вже є водій з таким кодом", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "DELETE * FROM Drivers WHERE d_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                textBox1.Clear();
                textBox2.Clear();
                LoadData();
                dataGridViewDrivers.Focus();
            }
            else
            {
                MessageBox.Show("В БД відсутній такий запис!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Drivers SET d_name = '" + textBox2.Text + "' WHERE d_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                LoadData();
                foreach (DataGridViewRow row in dataGridViewDrivers.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewDrivers.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("В БД відсутній такий запис!\nДобавити цей запис в таблицю Водії?",
                    "Помилка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    query = "INSERT INTO Drivers VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    LoadData();
                    foreach (DataGridViewRow row in dataGridViewDrivers.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == textBox1.Text)
                        {
                            dataGridViewDrivers.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void CarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _cars.Location = this.Location;
            _cars.Show();
        }

        private void RoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _routes.Location = this.Location;
            _routes.Show();
        }

        private void GoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _goods.Location = this.Location;
            _goods.Show();
        }

        private void ProvidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _providers.Location = this.Location;
            _providers.Show();
        }

        private void LoadData()
        {
            String query = "SELECT * FROM Drivers";
            dataGridViewDrivers.Rows.Clear();
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = dataGridViewDrivers.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    dataGridViewDrivers.Rows[n].Cells[i].Value = reader[i].ToString();
                }
            }
            reader.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0) { button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; }
            else { button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0) { button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; }
            else { button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; }
        }

        private void dataGridViewDrivers_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 rowIndex = dataGridViewDrivers.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dataGridViewDrivers.Rows[rowIndex];

            textBox1.Text = dataGridViewRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridViewRow.Cells[1].Value.ToString();
        }
    }
}
