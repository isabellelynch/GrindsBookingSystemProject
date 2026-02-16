using System;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmShowBookings : BaseForm
    {
        private bool updating = false;
        public frmShowBookings()
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

            if (cbo == cboStudentID)
            {
                ControlFunctions.ApplyFilters("'" + cboStudentID.Text + "'", "StudentID", "Students", cboStudentID, cboName, cboSName);
            }
            else if (cbo == cboName)
            {
                ControlFunctions.ApplyFilters("'" + cboName.Text + "'", "FirstName", "Students", cboStudentID, cboName, cboSName);
            }
            else if (cbo == cboSName)
            {
                ControlFunctions.ApplyFilters("'" + cboSName.Text + "'", "Surname", "Students", cboStudentID, cboName, cboSName);
            }

            updating = false;

        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            grpCancelBooking.Visible = false;
            ControlFunctions.EnableBoxes(cboStudentID, cboName, cboSName);
            ControlFunctions.FillBoxes("Students", cboStudentID, cboName, cboSName);
        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            grpCancelBooking.Visible = true;
            ControlFunctions.DisableBoxes(cboStudentID, cboName, cboSName);
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
