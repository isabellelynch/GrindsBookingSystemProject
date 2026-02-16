using System;
using System.Data;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmAddGrind : BaseForm
    {
        public frmAddGrind()
        {
            InitializeComponent();
            SetDateTimeFormat();
        }

        private void FillRooms()
        {
            cboRooms.Items.Clear();

            string sql = "SELECT RoomNo FROM Rooms";
            DataSet ds = Database.ExecuteMultiRowQuery(sql);
            foreach (DataRow r in ds.Tables[0].Rows)
            {
                cboRooms.Items.Add(r[0].ToString());
            }
        }
        public void SetDateTimeFormat()
        {
            pickDate.Format = DateTimePickerFormat.Short;
            pickDate.MinDate = DateTime.Today;
            pickDate.MaxDate = DateTime.Today.AddDays(28);
            pickTime.Format = DateTimePickerFormat.Time;
            pickTime.ShowUpDown = true;
            pickTime.Value = pickTime.Value.Date.AddHours(9);

            pickTime.ValueChanged += (s, e) =>
            {
                DateTime val = pickTime.Value;

                int hour = val.Hour;

                if (hour < 9) hour = 9;
                if (hour > 17) hour = 17;

                pickTime.Value = new DateTime(
                    val.Year,
                    val.Month,
                    val.Day,
                    hour,
                    0,
                    0
                );
            };

            pickDate.ValueChanged += (s, e) =>
            {
                DateTime val = pickDate.Value;

                if (val.DayOfWeek == DayOfWeek.Saturday)
                {
                    MessageBox.Show("Grinds can only be added Monday through Friday, Saturdays cannot be chosen. Date will now be changed to Monday",
                        "Error - No weekend Grinds!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pickDate.Value = val.AddDays(2);
                }
                else if (val.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Grinds can only be added Monday through Friday, Sundays cannot be chosen. Date will now be changed to Monday",
                        "Error - No weekend Grinds!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pickDate.Value = val.AddDays(1);
                }
            };


        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            pickDate.Value = DateTime.Now;
            pickTime.Value = DateTime.Now;
            FillRooms();

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
    }
}
