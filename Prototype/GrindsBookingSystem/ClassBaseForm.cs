using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class ClassBaseForm : BaseForm
    {
        public ClassBaseForm()
        {
            InitializeComponent();
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.DisableBoxes(cboDays, cboTime, txtAttendance, cboRooms);
            ControlFunctions.FillRooms(cboRooms);
            
            FillTutorDetails();
            FillTimes();
            cboSubjects.Enabled = false;
        }
        public void SetClassDay(int day, ComboBox t)
        {
            t.Text = GetClassDay(day);
        }

        public static string GetClassDay(int day)
        {
            string s = "";

            switch (day)
            {
                case 1:
                    s = "Monday";
                    break;
                case 2:
                    s = "Tuesday";
                    break;
                case 3:
                    s = "Wednesday";
                    break;
                case 4:
                    s = "Thursday";
                    break;
                case 5:
                    s = "Friday";
                    break;
                default:
                    s = "";
                    break;
            }
            return s;
        }

        public static int GetClassDayNumber(string day)
        {
            switch (day)
            {
                case "Monday":
                    return 1;
                case "Tuesday":
                    return 2;
                case "Wednesday":
                    return 3;
                case "Thursday":
                    return 4;
                case "Friday":
                    return 5;

            }

            return 0;
        }
        public void SetRoom(ComboBox cb, string room)
        {
            cb.Text = GetRoomDetails(room);
        }

        public void SetClassTime(int time, ComboBox t)
        {
            t.Text = time.ToString() + ":00";
        }

        public void SetAttendance(TextBox t, string room)
        {
            string sql = "SELECT Capacity FROM Rooms WHERE RoomNo = '" + room + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                int cap = dr.GetInt32(0);
                t.Text = cap.ToString();
            }

            dr.Close();
        }

        protected string GetRoomDetails(string r)
        {
            string sql = "SELECT RoomNo, Description FROM Rooms WHERE RoomNo = '" + r + "'";
            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();
            string details =  dr.GetString(0) + " - " + dr.GetString(1);
            dr.Close();
            return details;
        }

        protected void SetTutor(ComboBox cb, string id)
        {
            Tutor t = Tutor.GetTutor(Convert.ToInt32(id));
            cb.Text = t.FirstName + " " + t.Surname;
        }

        protected void FillTutorDetails()
        {
            cboTutors.Items.Clear();

            DataSet ds = Tutor.RetrieveAll();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cboTutors.Items.Add(dr[0].ToString() + " - " + dr[1].ToString() + " " + dr[2].ToString());
            }
        }

        protected void FillSubjects()
        {
            cboSubjects.Items.Clear();

            string sql = "SELECT s.Description, s.SubjectLevel, s.SubjectCategory " +
                         "FROM Subjects s " +
                         "JOIN Tutor_Subjects ts ON s.SubjectID = ts.SubjectID" +
                         " WHERE ts.TutorID = '" + cboTutors.Text.Split(' ')[0] + "'";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cboSubjects.Items.Add(dr[2] + ", " + dr[1] + " " + dr[0]);
            }
        }

        protected void FillTimes()
        {
            cboTime.Items.Clear();

            for (int i = 9; i <= 17; i++)
            {
                if (i < 10)
                {
                    cboTime.Items.Add("0" + i.ToString() + ":00");
                }
                else
                {
                    cboTime.Items.Add(i.ToString() + ":00");
                }
            }
        }


        protected int GetTutorID()
        {
            string details = cboTutors.Text;
            int id = 0;
            string[] parts = details.Split('-');
            string[] nameParts = parts[0].Split(' ');

            string sql = "SELECT TutorID FROM Tutors WHERE FirstName = '" + nameParts[0].Trim() +
                "' AND Surname = '" + nameParts[1].Trim() + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }

            dr.Close();

            return id;
        }

        private void cboTutors_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSubjects();
            cboSubjects.Enabled = true;
        }
    }
}
