using System;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmUpdateClass : ClassBaseForm
    {
        private Class c1;
        public frmUpdateClass()
        {
            InitializeComponent();
        }
        public frmUpdateClass(int day, int time, string room, Class c) : base(day, time, room)
        {
            c1 = c;
            InitializeComponent();
            Reset(this.Controls);
        }

        private void frmUpdateClass_Load(object sender, EventArgs e)
        { 
            btnClass.Text = "Alter Class";
            ControlFunctions.EnableBoxes(cboDays, cboTime, cboRooms);
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            cboRooms.SelectedIndexChanged -= RoomChanged;
            cboRooms.SelectedIndexChanged += RoomChanged;

            SetTutor(cboTutors, c1.TutorID);
        }

        private void RoomChanged(object sender, EventArgs e)
        {
            SetAttendance(txtAttendance, cboRooms.Text.Substring(0, 1));
        }


        private void btnClass_Click(object sender, EventArgs e)
        {
            Class c = c1;

            c.Delete();

            c1.Day = GetClassDayNumber(cboDays.Text);
            c1.Time = Convert.ToInt32(cboTime.Text.Substring(0, 2));
            c1.TutorID = GetTutorID().ToString();
            c1.RoomNo = cboRooms.Text.Substring(0, 1);

            if (c1 != null)
            {
                string errorString = "";
                string sql = "SELECT * FROM Classes WHERE SemesterNo = " + c1.Semester.ToString();

                DataSet ds = Database.ExecuteMultiRowQuery(sql);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    string day = r[0].ToString();
                    string time = r[1].ToString();
                    string id = r[2].ToString();
                    string room = r[4].ToString();

                    if (day == c1.Day.ToString() && time == c1.Time.ToString() && id == c1.TutorID)
                    {
                        errorString = "The selected tutor already has a class on the selected day at the selected time.";
                    }
                    else if (day == c1.Day.ToString() && time == c1.Time.ToString() && id != c1.TutorID && room == c1.RoomNo)
                    {
                        errorString = "The selected room is taken at the selected day and time, please try another room.";
                    }
                }

                
                if (errorString != "")
                {
                    ErrorMessage(errorString);
                    return;
                }
                else
                {
                    try
                    {
                        c1.Update();
                        SuccessMessage("Success! The class has been updated");
                        GoHome();
                        return;
                    }
                    catch (Exception ex)
                    {
                        ErrorMessage(ex.Message);
                        return;
                    }
                    
                }
            }
        }
    }
}
