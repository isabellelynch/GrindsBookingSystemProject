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
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmUpdateTutor()
        {
            InitializeComponent();
            comboBoxes = ControlFunctions.CreateComboList(cboTutorID, cboNames, cboSurnames);
            ClearUI();

            foreach (var c in comboBoxes)
            {
                c.SelectedIndexChanged += ComboBoxChange;
            }
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
                ControlFunctions.ApplyFilters("'" + cboTutorID.Text + "'", "TutorID", "Tutors", cboTutorID, cboNames, cboSurnames);
            }
            else if (cbo == cboNames)
            {
                ControlFunctions.ApplyFilters("'" + cboNames.Text + "'", "FirstName", "Tutors", cboTutorID, cboNames, cboSurnames);
            }
            else if (cbo == cboSurnames)
            {
                ControlFunctions.ApplyFilters("'" + cboSurnames.Text + "'", "Surname", "Tutors", cboTutorID, cboNames, cboSurnames);
            }

            updating = false;

        }

        private void btnFindTutor_Click(object sender, EventArgs e)
        {
            grpTutorDetails.Visible = true;

            if (cboTutorID.Items.Count > 1) 
            {
                return;
            }

            Tutor t = Tutor.GetTutor(Convert.ToInt32(cboTutorID.Items[0]));

            cboRates.Text = t.RateCode;
            cboSubjects.Text = t.Subject;
            txtEmail.Text = t.Email;
            txtPhone.Text = t.Phone;

            cboTutorID.Enabled = false;
            cboNames.Enabled = false;
            cboSurnames.Enabled = false;
            
        }

        private void btnUpdateTutor_Click(object sender, EventArgs e)
        {
            Tutor t = new Tutor(Convert.ToInt32(cboTutorID.Text),cboNames.Text, cboSurnames.Text, cboRates.Text.Substring(0, 3),
                cboSubjects.Text.Substring(0, 3), txtEmail.Text, txtPhone.Text);

            if (Tutor.IsValidPerson(t) != "Valid")
            {
                return;
            }

            Tutor t2 = Tutor.GetTutor(t.PersonID);

            if (t2 == null) { return; }

            t2.RateCode = t.RateCode;
            t2.Subject = t.Subject;
            t2.Email = t.Email;
            t2.Phone = t.Phone;

            Tutor.UpdateTutor(t2);

            String details = Tutor.GetTutorDetails(t2.PersonID);

            if (details != null)
            {
                MessageBox.Show("The selected Tutor has been updated and their details are now as follows\n\n" +
                    details, "Tutor Updated Successfully",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The selected Tutor could not be found.",
                    "Tutor Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearUI();
        }

        private void ClearUI()
        {
            ControlFunctions.ClearCombos(cboTutorID, cboNames, cboSurnames, cboRates, cboSubjects);
            ControlFunctions.ClearTextBoxes(txtEmail, txtPhone);

            grpTutorDetails.Visible = false;

            cboTutorID.Enabled = true;
            cboNames.Enabled = true;
            cboSurnames.Enabled = true;

            ControlFunctions.FillRatesAndSubjects(cboRates, cboSubjects);
            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboNames, cboSurnames);
        }

     
    }
}
