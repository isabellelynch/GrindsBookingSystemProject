using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace GrindsBookingSystem
{
    public partial class frmUpdateClass : ClassBaseForm
    {
        public Class c;
        public frmUpdateClass()
        {
            InitializeComponent();
        }
        public frmUpdateClass(int day, int time, string room):base(day, time, room)
        {
            InitializeComponent();
            
        }

        private void frmUpdateClass_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Classes WHERE Day = " + Day + " AND Time = " + (Time + 9) + " AND RoomNo = '" + Room + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            dr.Read();

            c = new Class(Day, Time, dr.GetString(2), dr.GetInt32(3), Room, dr.GetString(5));

            Reset(this.Controls);

            SetClassDay(Day, cboDays);
            SetClassTime(Time, cboTime);
            SetAttendance(txtAttendance, Room);
            SetRoom(cboRooms, Room);
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.DisableBoxes(txtAttendance);

            cboTime.Items.Clear();

            for (int i = 9; i <= 17; i++) 
            {
                string s = "";

                if(i < 10)
                {
                    s = "0" + i.ToString() + ":00";
                }
                else
                {
                    s = i.ToString() + ":00";
                }

                if(i == Time)
                {
                    cboTime.Text = s;
                }

                cboTime.Items.Add(s);
            }
  
            ControlFunctions.FillRooms(cboRooms);

            cboRooms.SelectedIndexChanged -= RoomChanged;
            cboRooms.SelectedIndexChanged += RoomChanged;

            DataSet ds = Tutor.RetrieveAll();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cboTutors.Items.Add(dr[1].ToString() + " " + dr[2].ToString() + " - " + dr[6].ToString());
            }

    
            Tutor t = Tutor.GetTutor(Convert.ToInt32(c.TutorID));

            if (t != null)
            {
                string tutor = t.FirstName + " " + t.Surname + " - " + t.Subject;
                cboTutors.Text = tutor;
            }
        }

        private void RoomChanged(object sender, EventArgs e)
        {
            SetAttendance(txtAttendance, cboRooms.Text.Substring(0, 1));
        }

        private void btnRemoveClass_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateClass_Click(object sender, EventArgs e)
        {
            string details = cboTutors.Text;
            int id = 0;
            string errorString = "";
            string[] parts = details.Split('-');
            string[] nameParts = parts[0].Split(' ');
            string sql = "SELECT TutorID FROM Tutors WHERE FirstName = '" + nameParts[0].Trim() +
                "' AND Surname = '" + nameParts[1].Trim() + "' AND SubjectCode = '" + parts[1].Trim() + "'";
            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            if (dr.Read())
            {
                id = dr.GetInt32(0); 
            }

            Class c2 = new Class(GetClassDayNumber(cboDays.Text), Convert.ToInt32(cboTime.Text.Substring(0, 2)),
               id.ToString(), c.CurrentEnrollment, cboRooms.Text.Substring(0,1), c.Semester);

            if (c2 != null) 
            {
                sql = "SELECT * FROM Classes WHERE SemesterNo = " + c2.Semester.ToString();
                DataSet ds = Database.ExecuteMultiRowQuery(sql);

                foreach (DataRow r in ds.Tables[0].Rows) 
                {
                    if (r[0].ToString() == c2.Day.ToString() && r[1].ToString() == c2.Time.ToString() && r[2].ToString() == c2.TutorID)
                    {
                        errorString = "The selected tutor already has a class on the selected day at the selected time.";
                    }
                    else if(r[0].ToString() == c2.Day.ToString() && r[1].ToString() == c2.Time.ToString() && r[2].ToString() != c2.TutorID && r[4].ToString() == c2.RoomNo)
                    {
                        errorString = "The selected room is taken at the selected day and time, please try another room.";
                    }
                }
                if(errorString != "")
                {
                    MessageBox.Show(errorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    c.Delete();
                    c2.Create();

                    MessageBox.Show("Success! The class has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    return;
                }
            }
        }
    }
}
