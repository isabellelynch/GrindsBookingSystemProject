using System;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmCancelBooking : BaseForm
    {
        public frmCancelBooking()
        {
            InitializeComponent();
        }



        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.EnableBoxes(cboStudentID, cboName, cboSName);
            grpCancelBooking.Visible = false;
        }
    }
}
