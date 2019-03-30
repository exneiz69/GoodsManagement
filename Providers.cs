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
    public partial class Providers : Form
    {
        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb;";

        private OleDbConnection myConnection;

        private Cars _cars;
        private Drivers _drivers;
        private Routes _routes;
        private Goods _goods;

        public Cars Cars { get { return _cars; } }
        public Drivers Drivers { get { return _drivers; } }
        public Routes Routes { get { return _routes; } }
        public Goods Goods { get { return _goods; } }

        public DataGridView DataGridView { get { return dataGridViewProviders; } }

        private bool _isFirst;

        public Providers(bool isFirst)
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
                _drivers = new Drivers(false);
                _routes = new Routes(false);
                _goods = new Goods(false);

                _cars.Synch(this);
                _drivers.Synch(this);
                _routes.Synch(this);
                _goods.Synch(this);
            }
        }

        public void Synch(Form form)
        {
            if (form.GetType() == typeof(Cars))
            {
                _cars = (Cars)form;
                _drivers = _cars.Drivers;
                _routes = _cars.Routes;
                _goods = _cars.Goods;
            }
            else if (form.GetType() == typeof(Drivers))
            {
                _drivers = (Drivers)form;
                _cars = _drivers.Cars;
                _routes = _drivers.Routes;
                _goods = _drivers.Goods;
            }
            else if (form.GetType() == typeof(Routes))
            {
                _routes = (Routes)form;
                _cars = _routes.Cars;
                _drivers = _routes.Drivers;
                _goods = _routes.Goods;
            }
            else
            {
                _goods = (Goods)form;
                _cars = _goods.Cars;
                _drivers = _goods.Drivers;
                _routes = _goods.Routes;
            }
        }

        private void Providers_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Providers_VisibleChanged(object sender, EventArgs e)
        {
            if (_isFirst) _isFirst = false;
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
            String query = "SELECT * FROM Providers WHERE p_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteScalar() == null)
            {
                query = "INSERT INTO Providers VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                LoadData();
                foreach (DataGridViewRow row in dataGridViewProviders.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewProviders.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("В БД вже є постачальник з таким кодом", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "DELETE * FROM Providers WHERE p_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                textBox1.Clear();
                textBox2.Clear();
                LoadData();
                dataGridViewProviders.Focus();
            }
            else
            {
                MessageBox.Show("В БД відсутній такий запис!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Providers SET p_name = '" + textBox2.Text + "' WHERE p_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                LoadData();
                foreach (DataGridViewRow row in dataGridViewProviders.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewProviders.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("В БД відсутній такий запис!\nДобавити цей запис в таблицю Перевізники?",
                    "Помилка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    query = "INSERT INTO Providers VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    LoadData();
                    foreach (DataGridViewRow row in dataGridViewProviders.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == textBox1.Text)
                        {
                            dataGridViewProviders.CurrentCell = row.Cells[0];
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

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _drivers.Location = this.Location;
            _drivers.Show();
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

        private void LoadData()
        {
            String query = "SELECT * FROM Providers";
            dataGridViewProviders.Rows.Clear();
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = dataGridViewProviders.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    dataGridViewProviders.Rows[n].Cells[i].Value = reader[i].ToString();
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

        private void dataGridViewProviders_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 rowIndex = dataGridViewProviders.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dataGridViewProviders.Rows[rowIndex];

            textBox1.Text = dataGridViewRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridViewRow.Cells[1].Value.ToString();
        }
    }
}
