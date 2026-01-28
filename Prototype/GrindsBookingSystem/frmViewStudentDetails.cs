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
using static GrindsBookingSystem.frmHome;


namespace GrindsBookingSystem
{
    public partial class frmViewStudentDetails : Form
    {
        public frmViewStudentDetails()
        {
            InitializeComponent();
            loadComboBoxes.IDFirstnameSurname(cboStudentID, cboFirstName, cboLastName);
        }

        private void frmViewStudentDetails_Load(object sender, EventArgs e)
        {

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

        private void cboStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBoxes.ApplyFilters(cboStudentID.Text, "StudentID", "Student", cboStudentID, cboFirstName, cboLastName);
        }

        private void cboFirstName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBoxes.ApplyFilters(cboFirstName.Text, "FirstName", "Student", cboStudentID, cboFirstName, cboLastName);
        }

        private void cboLastName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadComboBoxes.ApplyFilters(cboLastName.Text, "Surname", "Student", cboStudentID, cboFirstName, cboLastName);
        }

        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            cboStudentID.SelectedIndex = 0;

            String sql = "SELECT * FROM Tutors WHERE TutorID = " + cboStudentID.Text;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();

            if (dr != null)
            {
                MessageBox.Show("The selected Students deatils are as follows\n\nStudent ID: " + dr.GetInt32(0).ToString() + "\nFirst Name: " +
                                dr.GetString(1) + "\nSurname: " + dr.GetString(2) + "\nPhone Number: " + dr.GetString(3) + "\nEmail Address: " +
                                dr.GetString(4), "Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
