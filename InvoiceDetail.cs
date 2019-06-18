using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsManagement
{
    class InvoiceDetail
    {
        public String ProductName { get; set; }

        public Decimal Amount { get; set; }

        public Decimal Price { get; set; }

        public Decimal Sum
        {
            get
            {
                return Decimal.Divide(Price * Amount, 1.000M);
            }
        }
    }
}
