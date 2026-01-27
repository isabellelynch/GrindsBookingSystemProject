using System;
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
using static GrindsBookingSystem.frmHome;


namespace GrindsBookingSystem
{
    public partial class frmUpdateStudent : Form
    {

        public frmUpdateStudent()
        {
            InitializeComponent();
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
        public void goHome()
        {
            this.Hide();
            Owner.Show();
            cboNames.Enabled = true;
            cboSurnames.Enabled = true;
            cboStudentID.Enabled = true;
        }
        public void reset()
        {

            cboNames.Enabled = true;
            cboSurnames.Enabled = true;
            cboStudentID.Enabled = true;

            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            grpStudentDetails.Visible = false;
        }

        private void frmUpdateStudent_Load_1(object sender, EventArgs e)
        {

            grpStudentDetails.Visible = false;
        }



        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Owner.Show();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
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
