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
    public partial class frmViewTutorDetails : Form
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmViewTutorDetails()
        {
            InitializeComponent();

            comboBoxes = loadComboBoxes.CreateComboList(cboTutorID, cboName, cboLastName);

            loadComboBoxes.IDFirstnameSurname(comboBoxes, "Tutor");
            
            foreach(ComboBox cb  in comboBoxes)
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

        public void ComboBoxChange(object sender, EventArgs e)
        {
            if (updating) return;

            ComboBox cbo = sender as ComboBox;

            if (cbo == null || cbo.SelectedItem == null)
            {
                return;
            }

            updating = true;

            if (cbo == cboTutorID)
            {
                loadComboBoxes.ApplyFilters("'" + cboTutorID.Text + "'", "TutorID", "Tutor", comboBoxes, cbo);
            }
            else if (cbo == cboName)
            {
                loadComboBoxes.ApplyFilters("'" + cboName.Text + "'", "FirstName", "Tutor", comboBoxes, cbo);
            }
            else if (cbo == cboLastName) 
            {
                loadComboBoxes.ApplyFilters("'" + cboLastName.Text + "'", "Surname", "Tutor", comboBoxes, cbo);
            }

            updating = false;
        }
        


        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            String details = Tutor.GetTutorDetails(Convert.ToInt32(cboTutorID.Items[0]));

            if (details != null)
            {
                MessageBox.Show("The selected Tutors details are \n\n" + details,
                    "Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The selected Tutor could not be found.",
                    "Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
