using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using clsBussinseLibrary;

namespace Project_Bank_C
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsDatabaseInitializer.DatabaseInitializer();
            Application.Run(new FrmLogin());
        }
    }
}
