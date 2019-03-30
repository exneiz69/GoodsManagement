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
    public partial class Cars : Form
    {
        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb;";

        private OleDbConnection myConnection;

        private Drivers _drivers;
        private Routes _routes;
        private Goods _goods;
        private Providers _providers;

        public Drivers Drivers { get { return _drivers; } }
        public Routes Routes { get { return _routes; } }
        public Goods Goods { get { return _goods; } }
        public Providers Providers { get { return _providers; } }

        public DataGridView DataGridView { get { return dataGridViewCars; } }

        private Boolean _isFirst;

        public Cars(bool isFirst)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            _isFirst = isFirst;

            if (isFirst)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
                myConnection.Open();
                LoadData();

                _drivers = new Drivers(false);
                _routes = new Routes(false);
                _goods = new Goods(false);
                _providers = new Providers(false);

                _drivers.Synch(this);
                _routes.Synch(this);
                _goods.Synch(this);
                _providers.Synch(this);
            }
        }

        public void Synch(Form form)
        {
            if (form.GetType() == typeof(Drivers))
            {
                _drivers = (Drivers)form;
                _routes = _drivers.Routes;
                _goods = _drivers.Goods;
                _providers = _drivers.Providers;
            }
            else if (form.GetType() == typeof(Routes))
            {
                _routes = (Routes)form;
                _drivers = _routes.Drivers;
                _goods = _routes.Goods;
                _providers = _routes.Providers;
            }
            else if (form.GetType() == typeof(Goods))
            {
                _goods = (Goods)form;
                _drivers = _goods.Drivers;
                _routes = _goods.Routes;
                _providers = _goods.Providers;
            }
            else
            {
                _providers = (Providers)form;
                _drivers = _providers.Drivers;
                _routes = _providers.Routes;
                _goods = _providers.Goods;
            }
        }

        private void Cars_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Cars_VisibleChanged(object sender, EventArgs e)
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
            String query = "SELECT * FROM Cars WHERE c_number = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteScalar() == null)
            {
                query = "INSERT INTO Cars VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                LoadData();
                foreach (DataGridViewRow row in dataGridViewCars.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewCars.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("В БД вже є автомобіль з таким номером!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "DELETE * FROM Cars WHERE c_number = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                textBox1.Clear();
                textBox2.Clear();
                LoadData();
                dataGridViewCars.Focus();
            }
            else
            {
                MessageBox.Show("В БД відсутній такий запис!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Cars SET c_driver = '" + textBox2.Text + "' WHERE c_number = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                LoadData();
                foreach (DataGridViewRow row in dataGridViewCars.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewCars.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("В БД відсутній такий запис!\nДобавити цей запис в таблицю Автомобілі?", 
                    "Помилка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogResult == DialogResult.Yes)
                {
                    query = "INSERT INTO Cars VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    LoadData();
                }
            }
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

        private void ProvidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _providers.Location = this.Location;
            _providers.Show();
        }

        private void LoadData()
        {
            String query = "SELECT * FROM Cars";
            dataGridViewCars.Rows.Clear();
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = dataGridViewCars.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    dataGridViewCars.Rows[n].Cells[i].Value = reader[i].ToString();
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

        private void dataGridViewCars_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 rowIndex = dataGridViewCars.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dataGridViewCars.Rows[rowIndex];

            textBox1.Text = dataGridViewRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridViewRow.Cells[1].Value.ToString();
        }
    }
}
