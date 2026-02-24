using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class ClassBaseForm : BaseForm
    {
        protected int Day { get; set; }
        protected int Time { get; set; }
        protected string Room { get; set; }

        public ClassBaseForm()
        {
            InitializeComponent();
        }
        public ClassBaseForm(int day, int time, string room):this()
        {
            Day = day;
            Time = time;
            Room = room;
        }


        public void SetClassDay(int day, ComboBox t)
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

            t.Text = s;
        }

        public int GetClassDayNumber(string day)
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
            cb.Text = room;
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

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        private void btnBack_Click(object sender, System.EventArgs e)
        {
            GoHome();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            Reset(this.Controls);
        }

        private void ClassBaseForm_Load(object sender, System.EventArgs e)
        {
            SetClassDay(Day, cboDays);
            SetClassTime(Time, cboTime);
            SetAttendance(txtAttendance, Room);
            SetRoom(cboRooms, Room);
        }
    }
}
