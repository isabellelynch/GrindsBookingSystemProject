using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmViewStudentDetails : Form
    {
        List<ComboBox> comboBoxes;

        private bool updating = false;
        public frmViewStudentDetails()
        {
            InitializeComponent();

            comboBoxes = loadComboBoxes.CreateComboList(cboStudentID, cboFirstName, cboLastName);

            loadComboBoxes.IDFirstnameSurname(comboBoxes, "Student");

            foreach(ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged += ComboBoxChange;
            }
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

      

        private void btnShowDetails_Click(object sender, EventArgs e)
        {

            String sql = "SELECT * FROM Students WHERE StudentID = " + cboStudentID.Text;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();

            if (dr != null)
            {
                MessageBox.Show("The selected Students details are as follows\n\nStudent ID: " + dr.GetInt32(0).ToString() + "\nFirst Name: " +
                                dr.GetString(1) + "\nSurname: " + dr.GetString(2) + "\nPhone Number: " + dr.GetString(3) + "\nEmail Address: " +
                                dr.GetString(4), "Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ComboBoxChange(object sender, EventArgs e)
        {
            if (updating) return;

            ComboBox cbo = sender as ComboBox;

            if (cbo == null || cbo.SelectedItem == null)
            {
                return;
            }

            updating = true;

            if (cbo == cboStudentID)
            {
                loadComboBoxes.ApplyFilters("'" + cboStudentID.Text + "'", "StudentID", "Student", comboBoxes, cbo);
            }
            else if (cbo == cboFirstName)
            {
                loadComboBoxes.ApplyFilters("'" + cboFirstName.Text + "'", "FirstName", "Student", comboBoxes, cbo);
            }
            else if (cbo == cboLastName)
            {
                loadComboBoxes.ApplyFilters("'" + cboLastName.Text + "'", "Surname", "Student", comboBoxes, cbo);
            }

            updating = false;

        }
       
    }
}
