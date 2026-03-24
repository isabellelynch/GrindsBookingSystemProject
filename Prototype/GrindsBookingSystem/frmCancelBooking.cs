using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmCancelBooking : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmCancelBooking()
        {
            InitializeComponent();
            Reset(this.Controls);
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

            GridViews.Default(dgvCancelBooking);

            updating = false;

        }

        private void btnShowBookings_Click(object sender, EventArgs e)
        {
            ControlFunctions.DisableBoxes(cboStudentID, cboName, cboSName);

            DataTable dt = Booking.GetStudentBookings(cboStudentID.Text).Tables[0];

            dt.Columns.Add("WEEKDAY", typeof(string));
            dt.Columns.Add("CLASS TIME", typeof(string));

            foreach (DataRow dr in dt.Rows)
            {
                dr["WEEKDAY"] = ClassBaseForm.GetClassDay(Convert.ToInt16(dr["Day"]));

                int timeVal = Convert.ToInt32(dr["Time"]);
                dr["CLASS TIME"] = timeVal.ToString("D2") + ":00";
            }

            dgvCancelBooking.DataSource = dt;

            dgvCancelBooking.Columns["Day"].Visible = false;
            dgvCancelBooking.Columns["Time"].Visible = false;


            grpCancelBooking.Visible = true;
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvCancelBooking.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCancelBooking.SelectedRows[0];
                string sql = "SELECT ClassID FROM Bookings WHERE BookingID = " + row.Cells[0].Value;
                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
                if (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    Class c = Class.GetClass(id);
                    if (c != null)
                    {
                        try
                        {
                            Class.DecrementCurrentEnrollment(c);
                            sql = "DELETE FROM Student_Bookings WHERE BookingID = " + id + " AND StudentID = " + cboStudentID.Text;
                            Database.ExecuteNonQuery(sql);

                            sql = "SELECT TutorID FROM Bookings b JOIN Classes c ON " +
                                "b.ClassID = c.ClassID JOIN Tutors t " +
                                "ON c.TutorID = t.TutorID " +
                                "WHERE BookingID = " + id;

                            sql = "INSERT INTO Refunds (BookingID, StudentID, Amount) " +
                                "VALUES(" + id + "," + cboStudentID.Text + ")";
                            SuccessMessage("Booking Cancelled");

                        }
                        catch (Exception ex)
                        {
                            ErrorMessage(ex.ToString());
                        }
                    }
                    else
                    {
                        ErrorMessage("No Class can be found for the selected booking.");
                    }

                }
                

                



                    

                Reset(this.Controls);
            }
            else
            {
                ErrorMessage("No booking selected.");
            }
        }
    }
}
