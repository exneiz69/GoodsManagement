using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace GoodsManagement
{
    public partial class PrintGoods : Form
    {
        private DataTable _dataTable;
        private String _invoiceID;
        private String _date;
        private List<String> _provider;

        public PrintGoods(DataTable dataTable, String InvoiceID, String Date, List<String> provider)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.MaximumSize = SystemInformation.PrimaryMonitorMaximizedWindowSize;
            _dataTable = dataTable;
            _invoiceID = InvoiceID;
            _date = Date;
            _provider = provider;
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

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintGoods_Load(object sender, EventArgs e)
        {
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("pInvoiceID", _invoiceID),
                new ReportParameter("pDate", _date),
                new ReportParameter("pProvider", _provider[0]),
                new ReportParameter("pEDRPOU", _provider[1]),
                new ReportParameter("pIPN", _provider[2])
            };
            this.reportViewer.LocalReport.SetParameters(parameters);
            ReportDataSource source = new ReportDataSource("InvoiceDetail", _dataTable);
            this.reportViewer.LocalReport.DataSources.Clear();
            this.reportViewer.LocalReport.DataSources.Add(source);
            this.reportViewer.LocalReport.Refresh();

            this.reportViewer.RefreshReport();
        }

        private void PrintGoods_SizeChanged(object sender, EventArgs e)
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

