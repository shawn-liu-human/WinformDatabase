using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinformDatabase
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Server=(localdb)\v11.0;" +
                            "Integrated Security=true;" +
                            "";
            connection.Open();
            using (connection)
            {
                Application.Run(new Form1(connection));
            }
        }
    }
}
