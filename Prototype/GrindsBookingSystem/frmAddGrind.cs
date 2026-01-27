using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrindsBookingSystem.frmAddTutor;
using static GrindsBookingSystem.frmHome;
using static GrindsBookingSystem.frmSchedule;

namespace GrindsBookingSystem
{
    public partial class frmAddGrind : Form
    {
        public frmAddGrind()
        {
            InitializeComponent();
        }

        private void frmAddGrind_Load(object sender, EventArgs e)
        {

            LoadRooms();
            SetDateTimeFormat();
        }


        public void LoadRooms()
        {
            cboRooms.Items.Clear();
            cboRooms.Items.Add("R302");
            cboRooms.Items.Add("S302");
            cboRooms.Items.Add("T302");
            cboRooms.Items.Add("R300");
            cboRooms.Items.Add("S304");
            cboRooms.Items.Add("S306");
            cboRooms.Items.Add("R200");
            cboRooms.Items.Add("S300");

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

        public void goHome()
        {
            var form = new frmSchedule();
            form.Show();
            this.Hide();
        }

        public void reset()
        {
            pickDate.Value = DateTime.Now;
            pickTime.Value = DateTime.Now;
            txtAttendance.Text = "";
            cboRooms.SelectedIndex = -1;
            cboTutors.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Owner.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit ?",
                                                   "Please Confirm",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
