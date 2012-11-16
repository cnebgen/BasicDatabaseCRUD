using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BasicDatabaseCRUD
{
    static class Program
    {
        ///Connection String. Only place able to get to work.
        public static OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\VisualBasic.NET\BasicDatabaseCRUD\BasicDatabaseCRUD\Menuitems.accdb");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
