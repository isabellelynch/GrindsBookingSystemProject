using System;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // check the database connection once at the start, so a missing secrets.config or an
            // unreachable Oracle server gives one clear message instead of errors on every form
            try
            {
                Database.OpenConnection().Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the Oracle database, so most forms will not work.\n\n" + ex.Message,
                                "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new frmHome());
        }
    }
}
