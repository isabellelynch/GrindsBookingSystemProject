using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmDBconnectionTest : Form
    {
        //Creating an object to connect to an Oracle DB using an Oracle DB connection string (defined in the class DBConnect)
        OracleConnection conn = new OracleConnection(Database.connectionString);
        public frmDBconnectionTest()
        { 
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                lblStatus.Text = "CLOSED";
                lblStatus.ForeColor = Color.Black;
            }
            else
            {
                conn.Open();
                lblStatus.Text = "OPEN";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}

