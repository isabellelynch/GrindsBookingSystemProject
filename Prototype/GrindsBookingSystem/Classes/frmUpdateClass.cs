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
            SetAttendance(cboRooms.Text.Substring(0, 1));
        }


        private void btnClass_Click(object sender, EventArgs e)
        {
            int day = DayConversions.GetDayNumber(cboDays.Text);
            int time = Convert.ToInt32(cboTime.Text.Substring(0, 2));
            string room = cboRooms.Text.Substring(0, 1);

            updatingClass.RoomNo = room;
            updatingClass.Day = day;
            updatingClass.Time = time;

            if (updatingClass != null)
            {
                DataSet ds = Class.GetAllClasses();

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    int D = Convert.ToInt32(r[1]);
                    int T = Convert.ToInt32(r[2]);
                    string ID = r[3].ToString();
                    string Room = r[5].ToString();

                    string capacity = Rooms.GetRoomCapacity(Room);
                    
                    if(capacity == updatingClass.ClassID.ToString())
                    {
                        continue;
                    }
                    else if (D == updatingClass.Day && T == updatingClass.Time && ID == updatingClass.TutorID && Room == updatingClass.RoomNo)
                    {
                        SuccessMessage("You have made no changes to the class, goodbye");
                        GoHome();
                        return;
                    }
                    else if (D == updatingClass.Day && T == updatingClass.Time && ID == updatingClass.TutorID)
                    {
                        ErrorMessage("The selected tutor already has a class on the selected day at the selected time.");
                        return;
                    }
                    else if (D == updatingClass.Day && T == updatingClass.Time && Room == updatingClass.RoomNo)
                    {
                        ErrorMessage("The selected room is taken at the selected day and time, please try another room.");
                        return;
                    }
                    else if (capacity == "" || updatingClass.CurrentEnrollment > Convert.ToInt32(capacity))
                    {
                        ErrorMessage("The selected room cannot facilitate the amount of students already enrolled in this class");
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
