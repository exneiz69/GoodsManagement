using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsManagement
{
    public partial class Filter : Form
    {
        public DateTime dateTimeFrom
        {
            get
            {
                return dateTimePicker1.Value;
            }
        }

        public DateTime dateTimeTo
        {
            get
            {
                return dateTimePicker2.Value;
            }
        }

        public Filter()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(DateTime.Compare(dateTimePicker1.Value, dateTimePicker2.Value) > 0) dateTimePicker1.Value = DateTime.Now;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Compare(dateTimePicker2.Value, dateTimePicker1.Value) < 0) dateTimePicker2.Value = DateTime.Now;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
