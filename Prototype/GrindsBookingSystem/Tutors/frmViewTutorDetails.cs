using GrindsBookingSystem.HelperClasses;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmViewTutorDetails : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmViewTutorDetails()
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

            ControlFunctions.Filters("Tutor", cbo, cboTutorID, cboName, cboLastName);

            updating = false;

        }



        private void btnShowDetails_Click(object sender, EventArgs e)
        {
            Tutor t = Tutor.GetTutor(Convert.ToInt32(cboTutorID.Items[0]));

            String details = t.Read();

            if (details != null)
            {
                CustomMessageBox.ShowDetails("The selected Tutors details are \n\n" + details,
                                             "Tutor Details");
            }
            else
            {
                ErrorMessage("The selected Tutor could not be found.");
            }
            Reset(this.Controls);
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            
            comboBoxes = ControlFunctions.CreateComboList(cboTutorID, cboName, cboLastName);

            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboName, cboLastName);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }

        }
    }
    
}
