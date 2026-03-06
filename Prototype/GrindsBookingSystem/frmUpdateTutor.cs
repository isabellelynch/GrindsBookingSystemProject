using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmUpdateTutor : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmUpdateTutor()
        {
            InitializeComponent();
            Reset(this.Controls);
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
                                cboRates.Text.Substring(0, 3));

            t.SetID(cboTutorID.Text);


            if (t.IsValid() != "Valid")
            {
                ErrorMessage(t.IsValid());
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
                SuccessMessage("No Details Changed, Goodbye");
                return; 
            }
            else
            {
                    t2.RateCode = t.RateCode;
                    t2.Email = t.Email;
                    t2.Phone = t.Phone;
                    t2.SetID(t.PersonID);
                try
                {
                    t2.Update();
                    SuccessMessage("The selected Tutor has been updated and their details are now as follows\n\n" + t2.ToString());
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                    
            }

            Reset(this.Controls);
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            grpTutorDetails.Visible = false;

            ControlFunctions.EnableBoxes(cboTutorID, cboNames, cboSurnames);

            ControlFunctions.FillRates(cboRates);
            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboNames, cboSurnames);
            
            comboBoxes = ControlFunctions.CreateComboList(cboTutorID, cboNames, cboSurnames);
            foreach (var c in comboBoxes)
            {
                c.SelectedIndexChanged -= ComboBoxChange;
                c.SelectedIndexChanged += ComboBoxChange;
            }


        }

    }
}
