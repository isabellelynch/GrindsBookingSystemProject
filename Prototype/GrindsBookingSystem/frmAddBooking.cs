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
            string sql = "SELECT s.Description, s.SubjectLevel, s.SubjectCategory, " +
                         "CASE c.Day " +
                                "WHEN 1 THEN 'Monday'"+
                                "WHEN 2 THEN 'Tuesday'"+
                                "WHEN 3 THEN 'Wednesday'"+
                                "WHEN 4 THEN 'Thursday'"+
                                "WHEN 5 THEN 'Friday'"+
                                "END AS DayName, " +
                         "c.Time, c.RoomNo " +
                         "FROM Classes c JOIN Subjects s " +
                         "ON c.SubjectID = s.SubjectID " +
                         "WHERE c.SemesterNo = " + Class.GetCurrentSemester() +
                         "ORDER BY s.Description, c.Day";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                dgvMakeBooking.Rows.Add(
                dr["Description"],
                dr["SubjectLevel"],
                dr["SubjectCategory"],
                dr["DayName"],
                dr["Time"],
                dr["RoomNo"]
                );
            }

        }

            
            
        

    }
}
