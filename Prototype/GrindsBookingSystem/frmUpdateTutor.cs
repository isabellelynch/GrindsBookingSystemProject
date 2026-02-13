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

namespace GrindsBookingSystem
{
    public partial class frmUpdateTutor : Form
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmUpdateTutor()
        {
            InitializeComponent();
            Reset();

            comboBoxes = ControlFunctions.CreateComboList(cboTutorID, cboNames, cboSurnames);
            
            

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

            ControlFunctions.DisableBoxes(cboNames, cboSurnames, cboTutorID);
            
        }

        private void btnUpdateTutor_Click(object sender, EventArgs e)
        {
            Tutor t = new Tutor(cboNames.Text, 
                                cboSurnames.Text, 
                                txtEmail.Text, 
                                txtPhone.Text, 
                                cboRates.Text.Substring(0, 3),
                                cboSubjects.Text.Substring(0, 3));

            t.SetID(cboTutorID.Text);


            if (t.IsValid() != "Valid")
            {
                MessageBox.Show(t.IsValid()
                    , "Invalid Details Entered",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Tutor t2 = Tutor.GetTutor(Convert.ToInt32(t.PersonID));
            t2.SetID(t.PersonID);

            if (t2 == null) 
            { 
                return; 
            }
            else if (t == t2) 
            {
                MessageBox.Show("No Details Changed, Goodbye"
                    , "Goodbye",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; 
            }
            else
            {
                    t2.RateCode = t.RateCode;
                    t2.Subject = t.Subject;
                    t2.Email = t.Email;
                    t2.Phone = t.Phone;
                    t2.SetID(t.PersonID);
                try
                {
                    t2.Update();


                    MessageBox.Show("The selected Tutor has been updated and their details are now as follows\n\n" +
                            t2.ToString(), "Tutor Updated Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    
            }
            Reset();
        }

        private void Reset()
        {
            ControlFunctions.ClearCombos(cboTutorID, cboNames, cboSurnames, cboRates, cboSubjects);
            ControlFunctions.ClearTextBoxes(txtEmail, txtPhone);

            grpTutorDetails.Visible = false;

            ControlFunctions.EnableBoxes(cboTutorID, cboNames, cboSurnames);

            ControlFunctions.FillRatesAndSubjects(cboRates, cboSubjects);
            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboNames, cboSurnames);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
