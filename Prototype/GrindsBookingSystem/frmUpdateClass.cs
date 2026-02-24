using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmUpdateClass : ClassBaseForm
    {
        private string TutorID;
        private Class UpdatingClass;
        public frmUpdateClass()
        {
            InitializeComponent();
        }
        public frmUpdateClass(int day, int time, string room, Class c) : base(day, time, room)
        {
            TutorID = c.TutorID;
            UpdatingClass = c;

            InitializeComponent();
            Reset(this.Controls);
        }

        private void frmUpdateClass_Load(object sender, EventArgs e)
        { 
            btnClass.Text = "Alter Class";
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

    
            Tutor t = Tutor.GetTutor(Convert.ToInt32(UpdatingClass.TutorID));

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


        private void btnClass_Click(object sender, EventArgs e)
        {
            string errorString = "";
            string details = cboTutors.Text;
            int id = 0;
            string[] parts = details.Split('-');
            string[] nameParts = parts[0].Split(' ');

            string sql = "SELECT TutorID FROM Tutors WHERE FirstName = '" + nameParts[0].Trim() +
                "' AND Surname = '" + nameParts[1].Trim() + "' AND SubjectCode = '" + parts[1].Trim() + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                id = dr.GetInt32(0);
            }
            dr.Close();

            UpdatingClass.Day = GetClassDayNumber(cboDays.Text);
            UpdatingClass.Time = Convert.ToInt32(cboTime.Text.Substring(0, 2));
            UpdatingClass.TutorID = id.ToString();
            UpdatingClass.RoomNo = cboRooms.Text.Substring(0, 1);

            if (UpdatingClass != null)
            {
                sql = "SELECT * FROM Classes WHERE SemesterNo = " + UpdatingClass.Semester.ToString();

                DataSet ds = Database.ExecuteMultiRowQuery(sql);

                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    if (r[0].ToString() == UpdatingClass.Day.ToString() && r[1].ToString() == UpdatingClass.Time.ToString() && r[2].ToString() == UpdatingClass.TutorID)
                    {
                        errorString = "The selected tutor already has a class on the selected day at the selected time.";
                    }
                    else if (r[0].ToString() == UpdatingClass.Day.ToString() && r[1].ToString() == UpdatingClass.Time.ToString() && r[2].ToString() != UpdatingClass.TutorID && r[4].ToString() == UpdatingClass.RoomNo)
                    {
                        errorString = "The selected room is taken at the selected day and time, please try another room.";
                    }
                }

                
                if (errorString != "")
                {
                    MessageBox.Show(errorString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    UpdatingClass.Update();

                    MessageBox.Show("Success! The class has been updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                    return;
                }
            }
        }
    }
}
