using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
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
                cboTutors.Items.Add(dr[1].ToString() + " " + dr[2].ToString());
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
            dr.Read();
            string cap = dr.GetInt32(0).ToString();
            txtAttendance.Text = cap;
        }
        
    }
}
