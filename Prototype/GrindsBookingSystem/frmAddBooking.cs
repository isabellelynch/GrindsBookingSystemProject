using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmHome;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GrindsBookingSystem
{
    public partial class frmAddBooking : Form
    {
        public frmAddBooking()
        {
            InitializeComponent();
            grpMakeBooking.Visible = false;
        }

       
        public void reset()
        {
            cboStudentID.Items.Clear();
            cboFirstName.Items.Clear();
            cboLastName.Items.Clear();
            lvSchedule.Items.Clear();
            grpMakeBooking.Visible = false;
            cboStudentID.Enabled = true;
            cboFirstName.Enabled = true;
            cboLastName.Enabled = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if(cboStudentID.SelectedIndex == -1)
            {
                MessageBox.Show("Student ID must be selected before continuing.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboFirstName.SelectedIndex == -1)
            {
                MessageBox.Show("Student First Name must be selected before continuing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboLastName.SelectedIndex == -1)
            {
                MessageBox.Show("Student Last Name must be selected before continuing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grpMakeBooking.Visible = true;
            cboFirstName.Enabled = false;
            cboLastName.Enabled = false;
            cboStudentID.Enabled = false;

            if (lvSchedule.Columns.Count == 0)
            {
                lvSchedule.Columns.Add("Date", 100);
                lvSchedule.Columns.Add("Time", 100);
                lvSchedule.Columns.Add("Max Attendance", 115);
                lvSchedule.Columns.Add("Current Enrollment", 115);
                lvSchedule.Columns.Add("Room No", 130);
                lvSchedule.Columns.Add("Tutor ID", 120);
            }

            lvSchedule.View = View.Details;
            lvSchedule.FullRowSelect = true;
            lvSchedule.GridLines = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Owner.Show();
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
