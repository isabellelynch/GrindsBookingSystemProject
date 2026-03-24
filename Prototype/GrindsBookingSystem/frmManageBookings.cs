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
                    dr["WEEKDAY"] = ClassBaseForm.GetClassDay(Convert.ToInt16(dr["Day"]));

                    int timeVal = Convert.ToInt32(dr["Time"]);
                    dr["CLASS TIME"] = timeVal.ToString("D2") + ":00";
                }

                dgvCancelBooking.DataSource = dt;

                dgvCancelBooking.Columns["Day"].Visible = false;
                dgvCancelBooking.Columns["Time"].Visible = false;

                grpCancelBooking.Visible = true;
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvCancelBooking.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dgvCancelBooking.SelectedRows[0];

                string bookingID = row.Cells[0].Value.ToString();

                string sql = "SELECT ClassID FROM Bookings WHERE BookingID = " + bookingID;

                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

                if (dr.Read())
                {
                    int classID = dr.GetInt32(0);

                    Class c = Class.GetClass(classID);

                    if (c != null)
                    {
                        try
                        {
                            Class.DecrementCurrentEnrollment(c);

                            int tutorID = GetTutorIDFromClassID(classID.ToString());

                            RemoveFromStudentClassesTable(classID.ToString(), cboStudentID.Text);

                            string amount = Booking.GetAmount(tutorID.ToString()).ToString();

                            ProcessRefund(bookingID, cboStudentID.Text, amount);

                            RemoveFromBookingsTable(bookingID);

                            SuccessMessage("Booking Cancelled");

                            dr.Close();
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
                   
            }
            else
            {
                ErrorMessage("No booking selected.");
            }
            
            Reset(this.Controls);

            
        }

        public int GetTutorIDFromClassID(string classID)
        {
            string sql = "SELECT t.TutorID FROM Bookings b JOIN Classes c ON " +
                                "b.ClassID = c.ClassID JOIN Tutors t " +
                                "ON c.TutorID = t.TutorID " +
                                "WHERE b.ClassID = " + classID;

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            if (dr.Read())
            {
                return dr.GetInt32(0);
            }
            else
            {
                return 0;
            }
        }

        private void RemoveFromStudentClassesTable(string ClassID, string StudentID)
        {
            string sql = "DELETE FROM Student_Classes WHERE ClassID = " + ClassID + " AND StudentID = " + StudentID;
            Database.ExecuteNonQuery(sql);
        }

        private void ProcessRefund(string id, string student, string amount)
        {
            string sql = "INSERT INTO Refunds (BookingID, StudentID, Amount) " +
                                    "VALUES(" + id + "," + student + "," + amount + ")";
            Database.ExecuteNonQuery(sql);
        }

        private void RemoveFromBookingsTable(string id)
        {
            string sql = "DELETE FROM Bookings WHERE BookingID = " + id;
            Database.ExecuteNonQuery(sql);
        }
    }
}
