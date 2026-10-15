using GrindsBookingSystem.HelperClasses;
using System;
using System.Data;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmUpdateClass : ClassBaseForm
    {
        private Class updatingClass;
        public frmUpdateClass(Class c)
        {
            InitializeComponent();

            btnClass.Text = "Alter Class";
            updatingClass = c;
            updatingClass.SetID(c.ClassID);

            Reset(this.Controls);
        }

        private void frmUpdateClass_Load(object sender, EventArgs e)
        { 
            ControlFunctions.EnableBoxes(cboDays, cboTime, cboRooms);

            SetClassDay(updatingClass.Day);
            SetClassTime(updatingClass.Time);
            SetAttendance(updatingClass.RoomNo);
            SetRoom(updatingClass.RoomNo);

            cboSubjects.Text = Subject.GetSubjectDetails(updatingClass.SubjectID);

            cboSubjects.Enabled = false;
            cboTutors.Enabled = false;
            
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            cboRooms.SelectedIndexChanged -= RoomChanged;
            cboRooms.SelectedIndexChanged += RoomChanged;

            SetTutor(updatingClass.TutorID);
        }

        private void RoomChanged(object sender, EventArgs e)
        {
            if (cboRooms.Text == "")
            {
                return;
            }

            SetAttendance(cboRooms.Text.Substring(0, 1));
        }


        private void btnClass_Click(object sender, EventArgs e)
        {
            if (updatingClass == null)
            {
                return;
            }

            if (DayConversions.GetDayNumber(cboDays.Text) == 0 || cboTime.Text.Length < 2 || cboRooms.Text.Length < 1)
            {
                ErrorMessage("Please choose a day, time and room for the class.");
                return;
            }

            int day = DayConversions.GetDayNumber(cboDays.Text);
            int time = Convert.ToInt32(cboTime.Text.Substring(0, 2));
            string room = cboRooms.Text.Substring(0, 1);

            // nothing changed - checked before the loop, because the loop now skips this class's own row
            if (day == updatingClass.Day && time == updatingClass.Time && room == updatingClass.RoomNo)
            {
                SuccessMessage("You have made no changes to the class, goodbye");
                GoHome();
                return;
            }

            // the new room has to fit the students already booked in (this used to be checked against
            // every other class's room instead of the room chosen here)
            string capacity = Rooms.GetRoomCapacity(room);

            if (capacity == "" || updatingClass.CurrentEnrollment > Convert.ToInt32(capacity))
            {
                ErrorMessage("The selected room cannot facilitate the amount of students already enrolled in this class");
                return;
            }

            DataSet ds = Class.GetAllClasses();

            foreach (DataRow r in ds.Tables[0].Rows)
            {
                int D = Convert.ToInt32(r[1]);
                int T = Convert.ToInt32(r[2]);
                string ID = r[3].ToString();
                string Room = r[5].ToString();

                // skip the class being changed, otherwise moving it to another room at the same time
                // clashed with itself ("tutor already has a class")
                if (Convert.ToInt32(r[0]) == updatingClass.ClassID)
                {
                    continue;
                }
                else if (D == day && T == time && ID == updatingClass.TutorID)
                {
                    ErrorMessage("The selected tutor already has a class on the selected day at the selected time.");
                    return;
                }
                else if (D == day && T == time && Room == room)
                {
                    ErrorMessage("The selected room is taken at the selected day and time, please try another room.");
                    return;
                }
            }

            updatingClass.RoomNo = room;
            updatingClass.Day = day;
            updatingClass.Time = time;

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
