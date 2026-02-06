using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmAddTutor;
using Oracle.ManagedDataAccess.Client;

namespace GrindsBookingSystem
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

        }
     

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new frmAddTutor();
            f.Owner = this;
            f.Show();
            this.Hide();
        }

        private void removeTutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmRemoveTutor();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAddStudent();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void removeStuentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmRemoveStudent();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void updateTutorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmUpdateTutor();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void updateStudentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmUpdateStudent();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void viewStudentDetaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmViewStudentDetails();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void viewTutorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmViewTutorDetails();
            form.Owner = this;
            form.Show();
            this.Hide();
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmSchedule();
            form.Owner = this;
            form.Show(); 
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void makeBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmAddBooking();
            form.Owner = this;
            form.Show();
            this.Hide();
        }
  
        private void cancelBokingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmCancelBooking();
            form.Show();
            form.Owner = this;
            this.Hide();
        }

        private void viewBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowBookings();
            form.Show();
            form.Owner = this;
            this.Hide();
        }
        public static void ClearCombos(Control.ControlCollection Controls)
        {
            foreach (Control control in Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.Items.Clear();
                    comboBox.Text = "";
                }
            }
        }
        public class DateTimeListViewComparer : IComparer
        {
            private readonly int dateColumnIndex;
            private readonly int timeColumnIndex;
            private readonly bool ascending;

            public DateTimeListViewComparer(int dateColumnIndex, int timeColumnIndex, bool ascending = true)
            {
                this.dateColumnIndex = dateColumnIndex;
                this.timeColumnIndex = timeColumnIndex;
                this.ascending = ascending;
            }

            public int Compare(object x, object y)
            {
                var item1 = x as ListViewItem;
                var item2 = y as ListViewItem;

                // Read values
                DateTime date1 = DateTime.Parse(item1.SubItems[dateColumnIndex].Text);
                DateTime date2 = DateTime.Parse(item2.SubItems[dateColumnIndex].Text);

                TimeSpan time1 = TimeSpan.Parse(item1.SubItems[timeColumnIndex].Text);
                TimeSpan time2 = TimeSpan.Parse(item2.SubItems[timeColumnIndex].Text);

                // Combine date + time
                DateTime dt1 = date1.Add(time1);
                DateTime dt2 = date2.Add(time2);

                return ascending ? dt1.CompareTo(dt2) : dt2.CompareTo(dt1);
            }
        }


        private void tutorEarningsAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmTutorReport();
            form.Show();
            form.Owner = this;
            this.Hide();
        }

        private void yearlyRevenueAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAdmin();
            form.Show();
            form.Owner = this;
            this.Hide();
        }
    }
}
