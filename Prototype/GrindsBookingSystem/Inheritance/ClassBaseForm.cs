using GrindsBookingSystem.HelperClasses;
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
            RefreshButton.Visible = false;
        }
        public void SetClassDay(int day)
        {
            cboDays.Text = DayConversions.GetDayString(day);
        }

        
        public void SetRoom(string room)
        {
            cboRooms.Text = Rooms.GetRoomDetails(room);
        }

        public void SetClassTime(int time)
        {
            cboTime.Text = time.ToString() + ":00";
        }

        public void SetAttendance(string room)
        {
            txtAttendance.Text = Rooms.GetRoomCapacity(room).ToString();
        }

        protected void SetTutor(string id)
        {
            Tutor t = Tutor.GetTutor(Convert.ToInt32(id));

            cboTutors.Text = t.FirstName + " " + t.Surname;
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

            string id = cboTutors.Text.Split(' ')[0];

            DataTable dt = Tutor.GetTutorsSubjects(id);

            foreach (DataRow dr in dt.Rows)
            {
                cboSubjects.Items.Add(dr[2] + "," + dr[1] + " " + dr[0]);
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
            string[] nameParts = cboTutors.Text.Split('-')[0].Split(' ');

            string name = nameParts[0].Trim();
            string surname = nameParts[1].Trim();

            int id = Tutor.GetTutorID(name, surname);

            return id;
        }

        private void cboTutors_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSubjects();

            cboSubjects.Enabled = true;
        }
    }
}
