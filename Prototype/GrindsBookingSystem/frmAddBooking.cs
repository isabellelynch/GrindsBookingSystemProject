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
            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboLastName);
            grpMakeBooking.Visible = false;
            List<ComboBox> cb = ControlFunctions.CreateComboList(cboStudentID, cboFirstName, cboLastName);
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

            if (cbo == cboStudentID)
            {
                ControlFunctions.ApplyFilters("'" + cboStudentID.Text + "'", "StudentID", "Students", cboStudentID, cboFirstName, cboLastName);
            }
            else if (cbo == cboFirstName)
            {
                ControlFunctions.ApplyFilters("'" + cboFirstName.Text + "'", "FirstName", "Students", cboStudentID, cboFirstName, cboLastName);
            }
            else if (cbo == cboLastName)
            {
                ControlFunctions.ApplyFilters("'" + cboLastName.Text + "'", "Surname", "Students", cboStudentID, cboFirstName, cboLastName);
            }

            updating = false;

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

            if(cboStudentID.SelectedIndex == -1)
            {
                MessageBox.Show("Student ID must be selected before continuing.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboFirstName.SelectedIndex == -1)
            {
                MessageBox.Show("Student First Name must be selected before continuing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboLastName.SelectedIndex == -1)
            {
                MessageBox.Show("Student Last Name must be selected before continuing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grpMakeBooking.Visible = true;

            ControlFunctions.DisableBoxes(cboFirstName, cboLastName, cboStudentID);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset(this.Controls);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }
    }
}
