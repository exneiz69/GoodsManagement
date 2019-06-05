using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsManagement
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Goods());
            }
            catch(Exception ex)
            {
                DialogResult dialogResult = MessageBox.Show(ex.Message + "\nЗверніться до адміністратора для вирішення проблеми."
                   , "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
