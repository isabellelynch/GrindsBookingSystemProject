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
using static GrindsBookingSystem.frmAddTutor;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public partial class frmUpdateTutor : Form
    {
        
        public frmUpdateTutor()
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

        public void loadRateCodes()
        {
            cboRates.Items.Add("SNR - €50 per hour Senior Tutor");
            cboRates.Items.Add("JNR - €40 per hour Junior Tutor");
            cboRates.Items.Add("NEW - €30 per hour Trainee Tutor");
        }

        public void loadSubjects()
        {
            cboSubjects.Items.Add("Maths");
            cboSubjects.Items.Add("Irish");
            cboSubjects.Items.Add("English");
            cboSubjects.Items.Add("Science");
            cboSubjects.Items.Add("History");
            cboSubjects.Items.Add("Geography");
            cboSubjects.Items.Add("Accounting");
            cboSubjects.Items.Add("Applied Maths");
            cboSubjects.Items.Add("Business");
        }

        public void goHome()
        {
            this.Hide();
            Owner.Show();
            cboNames.Enabled = true;
            cboSurnames.Enabled = true;
            cboTutID.Enabled = true;
        }

        public void reset()
        {
            cboNames.Enabled = true;
            cboSurnames.Enabled = true;
            cboTutID.Enabled = true;
            cboSubjects.Items.Clear();
            cboRates.Items.Clear();
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            grpTutorDetails.Visible = false;
        }
    }
}
