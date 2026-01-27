using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmHome;
using static GrindsBookingSystem.frmSchedule;

namespace GrindsBookingSystem
{
    public partial class frmRemoveGrind : Form
    {
        public frmRemoveGrind()
        {
            InitializeComponent();
            lvGrinds.FullRowSelect = true;
            lvGrinds.View = View.Details;
            lvGrinds.GridLines = true;

            lvGrinds.Columns.Add("Date", 100);
            lvGrinds.Columns.Add("Time", 100);
            lvGrinds.Columns.Add("Room No", 100);
            lvGrinds.Columns.Add("Tutor ID", 80);
        }
        
        private void btnBack_Click(object sender, EventArgs e)
        {
            var form = new frmSchedule();
            form.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit ?",
                                                   "Please Confirm",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
