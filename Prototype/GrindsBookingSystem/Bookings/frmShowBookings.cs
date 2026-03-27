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

            ControlFunctions.Filters("Student", cbo, cboStudentID, cboFirstName, cboSurname);

            updating = false;

        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            grpCancelBooking.Visible = false;
            ControlFunctions.EnableBoxes(cboStudentID, cboFirstName, cboSurname);
            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboSurname);
        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            grpCancelBooking.Visible = true;
            ControlFunctions.DisableBoxes(cboStudentID, cboFirstName, cboSurname);
        }
    }
}
