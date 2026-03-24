using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace GrindsBookingSystem
{
    public partial class frmAddBooking : BaseForm
    {
        private bool updating = false;
        public frmAddBooking()
        {
            InitializeComponent();
            Reset(this.Controls);
        }


        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboSurname);

            grpMakeBooking.Visible = false;

            ControlFunctions.EnableBoxes(cboStudentID, cboFirstName, cboSurname);

            List<ComboBox> cb = ControlFunctions.CreateComboList(cboStudentID, cboFirstName, cboSurname);

            foreach (ComboBox c in cb)
            {
                c.SelectedIndexChanged -= ComboBoxChange;
                c.SelectedIndexChanged += ComboBoxChange;
            }

            GridViews.MakeBooking(dgvMakeBooking);

            FillGridView();

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

            ControlFunctions.Filters("Student", cbo, cboStudentID, cboFirstName, cboSurname);

            updating = false;

        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (cboStudentID.Items.Count > 1) 
            {
                ErrorMessage("Please select a single student in order to book a class for them");
                return;
            }

            grpMakeBooking.Visible = true;

            ControlFunctions.DisableBoxes(cboFirstName, cboSurname, cboStudentID);

            FillSubjects();
        }

        private void FillSubjects()
        {
            cboSubjects.Items.Clear();

            string sql = "SELECT DISTINCT Description FROM Subjects";

            try
            {
                DataSet ds = Database.ExecuteMultiRowQuery(sql);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cboSubjects.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex) 
            {
                ErrorMessage(ex.Message);
            }
        }

        private void FillGridView()
        {
            dgvMakeBooking.Rows.Clear();

            string edit = "";

            if(cboSubjects.Text.Length > 0)
            {
                edit = " AND s.Description = '" + cboSubjects.Text + "' ";
            }

            string sql = "SELECT s.Description, s.SubjectLevel, s.SubjectCategory, " +
                         "CASE c.Day " +
                                "WHEN 1 THEN 'Monday'"+
                                "WHEN 2 THEN 'Tuesday'"+
                                "WHEN 3 THEN 'Wednesday'"+
                                "WHEN 4 THEN 'Thursday'"+
                                "WHEN 5 THEN 'Friday'"+
                                "END AS DayName, " +
                         "c.Time, c.RoomNo, c.CurrentEnrollment, r.Capacity " +
                         "FROM Classes c JOIN Subjects s " +
                         "ON c.SubjectID = s.SubjectID " +
                         "JOIN Rooms r ON c.RoomNo = r.RoomNo " +
                         "WHERE c.SemesterNo = " + Class.GetCurrentSemester() + edit +
                         "ORDER BY s.Description, c.Day";

            

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dgvMakeBooking.Rows.Add(
                dr["Description"],
                dr["DayName"],
                dr["Time"] + ":00",
                dr["RoomNo"],
                dr["CurrentEnrollment"] + " / " + dr["Capacity"],
                dr["SubjectLevel"],
                dr["SubjectCategory"]
                );
            }

        }

        private void cboSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void btnMakeBooking_Click(object sender, EventArgs e)
        {
            if (dgvMakeBooking.SelectedRows.Count == 0)
            {
                ErrorMessage("A class must be chosen to book it");
                return;
            }
            else if(cboStudentID.Text == "" || cboStudentID.Items.Count > 1)
            {
                ErrorMessage("A single student must be chosen to book a class");
                return;
            }
            else
            {
                DataGridViewRow r = dgvMakeBooking.CurrentRow;

                int day = ClassBaseForm.GetClassDayNumber(r.Cells[1].Value.ToString());
                string time = r.Cells[2].Value.ToString().Substring(0,r.Cells[2].Value.ToString().IndexOf(":"));
                string room = r.Cells[3].Value.ToString();

                int ClassID = Class.GetClassID(day, Convert.ToInt32(time), room);

                Class c = Class.GetClass(ClassID);

                Booking b = new Booking(Convert.ToInt32(cboStudentID.Text), ClassID);

                if (c.IsClassFull() == false)
                {
                    if (b.HasStudentAlreadyBooked() == false)
                    {
                        int amount = Booking.GetAmount(c.TutorID);

                        DialogResult d = MessageBox.Show("Please confirm that the student has paid the €" + amount + " due before continuing to book","Payment", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (d == DialogResult.Yes)
                        {
                            b.IncrementCurrentEnrollment(c.CurrentEnrollment);

                            try
                            {
                                b.Create();
                                SuccessMessage("Class Booked!");
                                //SendBookingConfirmation();
                            }
                            catch (Exception ex)
                            {
                                ErrorMessage(ex.Message);
                            } 
                        }
                        else
                        {
                            ErrorMessage("The student must provide payment before continuing");
                            return;
                        }
                    }
                    else
                    {
                        ErrorMessage("This student has already been booked into this class");
                    }
                }
                else
                {
                    ErrorMessage("System Error! The class you would like to book cannot be found");
                    return;
                }


                
            }
            Reset(this.Controls);
        }

        
    }
}
