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
    public partial class Routes : Form
    {
        private string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb;";

        private OleDbConnection myConnection;

        private Cars _cars;
        private Drivers _drivers;
        private Goods _goods;
        private Providers _providers;

        public Cars Cars { get { return _cars; } }
        public Drivers Drivers { get { return _drivers; } }
        public Goods Goods { get { return _goods; } }
        public Providers Providers { get { return _providers; } }

        public DataGridView DataGridView { get { return dataGridViewRoutes; } }

        private Boolean _isFirst;

        public Routes(bool isFirst)
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
                _goods = new Goods(false);
                _providers = new Providers(false);

                _cars.Synch(this);
                _drivers.Synch(this);
                _goods.Synch(this);
                _providers.Synch(this);
            }
        }

        public void Synch(Form form)
        {
            if (form.GetType() == typeof(Cars))
            {
                _cars = (Cars)form;
                _drivers = _cars.Drivers;
                _goods = _cars.Goods;
                _providers = _cars.Providers;
            }
            else if (form.GetType() == typeof(Drivers))
            {
                _drivers = (Drivers)form;
                _cars = _drivers.Cars;
                _goods = _drivers.Goods;
                _providers = _drivers.Providers;
            }
            else if (form.GetType() == typeof(Goods))
            {
                _goods = (Goods)form;
                _cars = _goods.Cars;
                _drivers = _goods.Drivers;
                _providers = _goods.Providers;
            }
            else
            {
                _providers = (Providers)form;
                _cars = _providers.Cars;
                _drivers = _providers.Drivers;
                _goods = _providers.Goods;
            }
        }

        private void Routes_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void Routes_VisibleChanged(object sender, EventArgs e)
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
            String query = "SELECT * FROM Routes WHERE r_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteScalar() == null)
            {
                query = "INSERT INTO Routes VALUES ('" + textBox1.Text + "', '" 
                    + textBox2.Text + "', " + textBox3.Text.Remove(textBox3.Text.Length - 4) + ")";
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                LoadData();
                foreach (DataGridViewRow row in dataGridViewRoutes.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewRoutes.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("В БД вже є маршрут з таким кодом", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "DELETE * FROM Routes WHERE r_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                LoadData();
                dataGridViewRoutes.Focus();
            }
            else
            {
                MessageBox.Show("В БД відсутній такий запис!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Routes SET r_dest = '" + textBox2.Text + "', r_dist = " + textBox3.Text.Remove(textBox3.Text.Length - 4)
                + " WHERE r_code = '" + textBox1.Text + "'";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            if (command.ExecuteNonQuery() != 0)
            {
                LoadData();
                foreach (DataGridViewRow row in dataGridViewRoutes.Rows)
                {
                    if (row.Cells[0].Value.ToString() == textBox1.Text)
                    {
                        dataGridViewRoutes.CurrentCell = row.Cells[0];
                        break;
                    }
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("В БД відсутній такий запис!\nДобавити цей запис в таблицю Маршрут?",
                    "Помилка", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    query = "INSERT INTO Routes VALUES ('" + textBox1.Text + "', '" 
                    + textBox2.Text + "', " + textBox3.Text.Remove(textBox3.Text.Length - 4) + ")";
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    LoadData();
                    foreach (DataGridViewRow row in dataGridViewRoutes.Rows)
                    {
                        if (row.Cells[0].Value.ToString() == textBox1.Text)
                        {
                            dataGridViewRoutes.CurrentCell = row.Cells[0];
                            break;
                        }
                    }
                }
            }
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _drivers.Location = this.Location;
            _drivers.Show();
        }

        private void CarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _cars.Location = this.Location;
            _cars.Show();
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
            String query = "SELECT * FROM Routes";
            dataGridViewRoutes.Rows.Clear();
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Int32 n = dataGridViewRoutes.Rows.Add();
                for (Int32 i = 0; i < reader.VisibleFieldCount; i++)
                {
                    if (i == reader.VisibleFieldCount - 1)
                    {
                        dataGridViewRoutes.Rows[n].Cells[i].Value = reader[i].ToString() + " км.";
                        continue;
                    }
                    dataGridViewRoutes.Rows[n].Cells[i].Value = reader[i].ToString();
                    
                }
            }
            reader.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox3.TextLength > 0)
            { button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; }
            else { button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox3.TextLength > 0)
            { button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; }
            else { button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && textBox2.TextLength > 0 && textBox3.TextLength > 0)
            { button1.Enabled = true; button2.Enabled = true; button3.Enabled = true; }
            else { button1.Enabled = false; button2.Enabled = false; button3.Enabled = false; }
        }

        private void dataGridViewRoutes_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 rowIndex = dataGridViewRoutes.SelectedCells[0].RowIndex;
            DataGridViewRow dataGridViewRow = dataGridViewRoutes.Rows[rowIndex];

            textBox1.Text = dataGridViewRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridViewRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridViewRow.Cells[2].Value.ToString();
        }
    }
}
