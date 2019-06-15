using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsManagement
{
    public static class Helper
    {
        static Helper()
        {
            source = @"Data Source=DESKTOP-M22O3UA\SQLEXPRESS;Initial Catalog=GoodsDB;Integrated Security=True;
                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        }

        public static String source;
    }
}
