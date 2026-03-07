using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmAddBooking : BaseForm
    {
        private bool updating = false;
        public frmAddBooking()
        {
            InitializeComponent();
            Reset(this.Controls);
        }


        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboSurname);

            grpMakeBooking.Visible = false;

            List<ComboBox> cb = ControlFunctions.CreateComboList(cboStudentID, cboFirstName, cboSurname);

            foreach (ComboBox c in cb)
            {
                c.SelectedIndexChanged -= ComboBoxChange;
                c.SelectedIndexChanged += ComboBoxChange;
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

            ControlFunctions.Filters("Student", cbo, cboStudentID, cboFirstName, cboSurname);

            updating = false;

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if(cboStudentID.SelectedIndex == -1)
            {
                ErrorMessage("Student ID must be selected before continuing.");
                return;
            }
            if (cboFirstName.SelectedIndex == -1)
            {
                ErrorMessage("Student First Name must be selected before continuing.");
                return;
            }
            if (cboSurname.SelectedIndex == -1)
            {
                ErrorMessage("Student Last Name must be selected before continuing.");
                return;
            }
            if (cboStudentID.Items.Count > 1) 
            {
                ErrorMessage("Please select a single student in order to book a class for them");
                return;
            }

            grpMakeBooking.Visible = true;

            ControlFunctions.DisableBoxes(cboFirstName, cboSurname, cboStudentID);
        }

    }
}
