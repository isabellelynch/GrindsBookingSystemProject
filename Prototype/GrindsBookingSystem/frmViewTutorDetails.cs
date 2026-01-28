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
using static GrindsBookingSystem.frmAddStudent;
using static GrindsBookingSystem.frmAddTutor;
using static GrindsBookingSystem.frmHome;

namespace GrindsBookingSystem
{
    public partial class frmViewTutorDetails : Form
    {
        public frmViewTutorDetails()
        {
            InitializeComponent();
            loadComboBoxes.IDFirstnameSurname(cboTutorID, cboName, cboLastName);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            Owner.Show();
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

        private void cboTutorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBoxes.ApplyFilters(cboTutorID.Text, "TutorID", "Tutor", cboTutorID, cboName, cboLastName);
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBoxes.ApplyFilters(cboName.Text, "FirstName", "Tutor", cboTutorID, cboName, cboLastName);
        }

        private void cboLastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBoxes.ApplyFilters(cboLastName.Text, "Surname", "Tutor", cboTutorID, cboName, cboLastName);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            cboTutorID.SelectedIndex = 0;

            String sql = "SELECT * FROM Tutors WHERE TutorID = " + cboTutorID.Text;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();

            if (dr != null)
            {
                MessageBox.Show("The selected Tutors deatils are as follows\n\nTutor ID: " + dr.GetInt32(0).ToString() + "\nFirst Name: " +
                                dr.GetString(1) + "\nSurname: " + dr.GetString(2) + "\nRate Code: " + dr.GetString(3) + "\nSubject: " +
                                dr.GetString(4) + "\nPhone Number: " + dr.GetString(5) + "\nEmail Address: " + dr.GetString(6), "Tutor Details",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    
}
