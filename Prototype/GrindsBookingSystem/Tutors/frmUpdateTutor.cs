using GrindsBookingSystem.HelperClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmUpdateTutor : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        Tutor t = new Tutor();
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

            ControlFunctions.Filters("Tutor", cbo, cboTutorID, cboNames, cboSurnames);

            updating = false;

        }

        private void btnFindTutor_Click(object sender, EventArgs e)
        {
            if (cboTutorID.Items.Count > 1) 
            {
                ErrorMessage("Please select a Tutor to continue");
                return;
            }
            
            grpTutorDetails.Visible = true;

            int id = Convert.ToInt32(cboTutorID.Items[0]);

            t = Tutor.GetTutor(id);

            t.SetID(id.ToString());

            cboRates.Text = t.RateCode;
            txtEmail.Text = t.Email;
            txtPhone.Text = t.Phone;

            ControlFunctions.DisableBoxes(cboNames, cboSurnames, cboTutorID);
        }

        private void btnUpdateTutor_Click(object sender, EventArgs e)
        {
            t.Email = txtEmail.Text;
            t.Phone = txtPhone.Text;
            t.RateCode = cboRates.Text.Substring(0,3);

            if (t.IsValid() != "Valid")
            {
                ErrorMessage(t.IsValid());
                return;
            }
            try
            {
                t.Update();
                CustomMessageBox.ShowDetails("The selected Tutor has been updated and their details are now as follows\n\n" + t.ToString());
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
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
