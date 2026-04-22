using System;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmRemoveClass : ClassBaseForm
    {
        public Class deletingClass;
        public frmRemoveClass(Class c)
        {
            InitializeComponent();
            deletingClass = c;
            int id = Class.GetClassID(deletingClass.Day, deletingClass.Time, deletingClass.RoomNo);
            deletingClass.SetID(id);
            Reset(this.Controls);
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            SetTutor(deletingClass.TutorID);
            ControlFunctions.DisableBoxes(cboTutors);
        }

        private void frmRemoveClass_Load(object sender, System.EventArgs e)
        {
            btnClass.Text = "Remove Class";

            SetClassDay(deletingClass.Day);
            SetClassTime(deletingClass.Time);
            SetAttendance(deletingClass.RoomNo);
            SetRoom(deletingClass.RoomNo);

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
