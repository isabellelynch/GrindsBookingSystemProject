using GrindsBookingSystem.HelperClasses;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmManageBookings : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmManageBookings()
        {
            InitializeComponent();
            Reset(this.Controls);
            GridViews.Default(dgvCancelBooking);
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            
            ControlFunctions.EnableBoxes(cboStudentID, cboName, cboSName);

            grpCancelBooking.Visible = false;

            ControlFunctions.FillBoxes("Students", cboStudentID, cboName, cboSName);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboName, cboSName);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }
            
        }

        public void ComboBoxChange(object sender, EventArgs e)
        {
            if (updating) return;

            ComboBox cbo = sender as ComboBox;

            if (cbo == null || cbo.SelectedItem == null)
            {
                return;
            }

            updating = true;

            ControlFunctions.Filters("Student", cbo, cboStudentID, cboName, cboSName);

            

            updating = false;

        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            ControlFunctions.DisableBoxes(cboStudentID, cboName, cboSName);

            DataTable dt = Booking.GetStudentBookings(cboStudentID.Text).Tables[0];

            if (dt.Rows.Count > 0)
            {
                dt.Columns.Add("WEEKDAY", typeof(string));
                dt.Columns.Add("CLASS TIME", typeof(string));

                foreach (DataRow dr in dt.Rows)
                {
                    dr["WEEKDAY"] = DayConversions.GetDayString(Convert.ToInt16(dr["Day"]));

                    int timeVal = Convert.ToInt32(dr["Time"]);
                    dr["CLASS TIME"] = timeVal.ToString("D2") + ":00";
                }

                dgvCancelBooking.DataSource = dt;

                dgvCancelBooking.Columns["Day"].Visible = false;
                dgvCancelBooking.Columns["Time"].Visible = false;

                grpCancelBooking.Visible = true;
            }
            else
            {
                MessageBox.Show("Student currently has no bookings made",
                                "No Bookings",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                Reset(this.Controls);
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvCancelBooking.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCancelBooking.SelectedRows[0];

                string bookingID = row.Cells[0].Value.ToString();

                try
                {
                    Booking.CancelBooking(bookingID, cboStudentID.Text);
                    SuccessMessage("Booking Cancelled");

                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.ToString());
                }

            }
            else
            {
                ErrorMessage("Please select a booking before continuing.");
            }

            Reset(this.Controls);   
        }

        

        

        

        
    }
}
