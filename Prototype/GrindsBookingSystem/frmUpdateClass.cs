using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GrindsBookingSystem
{
    public partial class frmUpdateClass : ClassBaseForm
    {
        private Class updatingClass;
        public frmUpdateClass(Class c)
        {
            InitializeComponent();
            updatingClass = c;
            Reset(this.Controls);
        }

        private void frmUpdateClass_Load(object sender, EventArgs e)
        { 
            btnClass.Text = "Alter Class";
            ControlFunctions.EnableBoxes(cboDays, cboTime, cboRooms);

            SetClassDay(updatingClass.Day, cboDays);
            SetClassTime(updatingClass.Time, cboTime);
            SetAttendance(txtAttendance, updatingClass.RoomNo);
            SetRoom(cboRooms, updatingClass.RoomNo);

            cboSubjects.Text = Subject.GetSubjectDetails(updatingClass.SubjectID);
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            cboRooms.SelectedIndexChanged -= RoomChanged;
            cboRooms.SelectedIndexChanged += RoomChanged;

            SetTutor(cboTutors, updatingClass.TutorID);
        }

        private void RoomChanged(object sender, EventArgs e)
        {
            SetAttendance(txtAttendance, cboRooms.Text.Substring(0, 1));
        }


        private void btnClass_Click(object sender, EventArgs e)
        {
            updatingClass.Day = GetClassDayNumber(cboDays.Text);
            updatingClass.Time = Convert.ToInt32(cboTime.Text.Substring(0, 2));
            updatingClass.TutorID = GetTutorID().ToString();
            updatingClass.RoomNo = cboRooms.Text.Substring(0, 1);

            if (updatingClass != null)
            {
                string sql = "SELECT * FROM Classes WHERE SemesterNo = " + updatingClass.Semester.ToString();

                DataSet ds = Database.ExecuteMultiRowQuery(sql);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    string day = r[1].ToString();
                    string time = r[2].ToString();
                    string id = r[3].ToString();
                    string room = r[5].ToString();

                    if (day == updatingClass.Day.ToString() && time == updatingClass.Time.ToString() && id == updatingClass.TutorID)
                    {
                        ErrorMessage("The selected tutor already has a class on the selected day at the selected time.");
                        return;
                    }
                    else if (day == updatingClass.Day.ToString() && time == updatingClass.Time.ToString() && id != updatingClass.TutorID && room == updatingClass.RoomNo)
                    {
                        ErrorMessage("The selected room is taken at the selected day and time, please try another room.");
                        return;
                    }
                }
                try
                {
                    updatingClass.Update();
                    SuccessMessage("Success! The class has been updated");
                    GoHome();
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
                }
                  
            }
        }
    }
}
