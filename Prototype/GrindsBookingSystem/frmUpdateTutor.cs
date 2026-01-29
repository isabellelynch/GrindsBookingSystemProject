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

            loadComboBoxes.IDFirstnameSurname(cboTutID, cboNames, cboSurnames, "Tutor");

            grpTutorDetails.Visible = false;

            loadComboBoxes.RateCodes(cboRates);
            loadComboBoxes.Subjects(cboSubjects);
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
        }

        public void reset()
        {

        }
    }
}
