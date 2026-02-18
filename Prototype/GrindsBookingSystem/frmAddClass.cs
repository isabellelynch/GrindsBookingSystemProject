using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmAddClass : BaseForm
    {
        public int day {get ; set;}
        public int time {get; set;}
        public string room {get; set;}
        public frmAddClass(int day, int time, string room)
        {
            InitializeComponent();
            this.day = day;
            this.time = time;
            this.room = room;
            Reset(this.Controls);
            
        }
        private void frmAddClass_Load(object sender, EventArgs e)
        {
            SetClassDay(day);
            SetClassTime(time);
            SetAttendance();
            SetRoom();
        }
        
        


        
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.DisableBoxes(txtDay, txtTime, txtAttendance, cboRooms);

            ControlFunctions.FillRooms(cboRooms);

            DataSet ds = Tutor.RetrieveAll();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cboTutors.Items.Add(dr[1].ToString() + " " + dr[2].ToString() + " - " + dr[6].ToString());
            }

            
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset(this.Controls);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            GoHome();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void SetClassDay(int day)
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

            txtDay.Text = s;
        }

        private void SetRoom()
        {
            cboRooms.Text = room.ToString();
        }

        private void SetClassTime(int time)
        {
            int t = time + 9;
            txtTime.Text = t.ToString() + ":00";
        }

        private void SetAttendance()
        {
            string sql = "SELECT Capacity FROM Rooms WHERE RoomNo = '" + room + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

            if (dr.Read())
            {
                int cap = dr.GetInt32(0);
                txtAttendance.Text = cap.ToString();
            }
            
            dr.Close();
        }

        private void btnAddGrind_Click(object sender, EventArgs e)
        {
            string details = cboTutors.Text;

            if(details == "")
            {
                MessageBox.Show("A Tutor must be chosen before adding a class", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] parts = details.Split('-');
            string[] nameParts = parts[0].Split(' ');


            string sql = "SELECT TutorID FROM Tutors WHERE FirstName = '" + nameParts[0].Trim() +
                "' AND Surname = '" + nameParts[1].Trim() + "' AND SubjectCode = '" + parts[1].Trim() + "'";
            try
            {
                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

                if (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    int t = Convert.ToInt32(txtTime.Text.Substring(0, txtTime.Text.IndexOf(':')));
                    Class c = new Class(day, t, id.ToString(), 0, room, 2);
                    c.Create();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                return;
            }

            MessageBox.Show("Your Class has been sucessfully added to the Schedule", "Class Added",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

    }
}
