using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GrindsBookingSystem
{
    public partial class frmRemoveClass : ClassBaseForm
    {
        public Class deletingClass;
        public frmRemoveClass(Class c)
        {
            InitializeComponent();
            deletingClass = c;
            Reset(this.Controls);
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            SetTutor(cboTutors, deletingClass.TutorID);
            ControlFunctions.DisableBoxes(cboTutors);
        }

        private void frmRemoveClass_Load(object sender, System.EventArgs e)
        {
            btnClass.Text = "Remove Class";

            SetClassDay(deletingClass.Day, cboDays);
            SetClassTime(deletingClass.Time, cboTime);
            SetAttendance(txtAttendance, deletingClass.RoomNo);
            SetRoom(cboRooms, deletingClass.RoomNo);

            cboSubjects.Text = Subject.GetSubjectDetails(deletingClass.SubjectID);
        }

        private void btnClass_Click(object sender, System.EventArgs e)
        {
            try
            {
                deletingClass.Delete();
                SuccessMessage("Your chosen class has successfully been deleted");
            }
            catch(Exception ex)
            {
                ErrorMessage(ex.Message);
            }

            GoHome();
        }

        
    }
}
