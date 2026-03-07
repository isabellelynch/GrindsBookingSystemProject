using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;



namespace GrindsBookingSystem
{
    public partial class frmAddTutor : BaseForm
    {
        public frmAddTutor()
        {
            InitializeComponent();
            Reset(this.Controls);
        }
        private void btnAddTutor_Click(object sender, EventArgs e)
        {
            String rate = cboTutorRates.Text.Substring(0,3);

            Tutor t = new Tutor(txtTutorName.Text, txtTutorSurname.Text, txtTutorEmail.Text, txtTutorPhone.Text, rate);

            if(t.IsValid() == "Valid")
            {
                t.Create();

                //AddToTutorSubjectTable(t);

                SuccessMessage("Tutor " + txtTutorName.Text + " " + txtTutorSurname.Text + " has been succesfully added to the system.");

                DialogResult addAnother = MessageBox.Show("Would you like to add another Tutor?",
                                                    "Please Confirm",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (addAnother == DialogResult.Yes)
                {
                    Reset(this.Controls);
                }
                else
                {
                    GoHome();
                }
            }
            else
            {
                ErrorMessage("Invalid Entry, " + t.IsValid());
            }
        }
        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);
            ControlFunctions.FillRates(cboTutorRates);
        }


        /*private void FillLevelAndCategory()
        {
            ControlFunctions.ClearCombos(cboCategory, cboLevel);
            ControlFunctions.EnableBoxes(cboLevel, cboCategory);

            string sql = "SELECT SubjectLevel, SubjectCategory FROM Subjects WHERE SubjectCode = '" + cboTutorSubjects.Text.Substring(0, 3) + "'";

            DataSet ds = Database.ExecuteMultiRowQuery(sql);

            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (!cboLevel.Items.Contains(row[0].ToString()))
                    {
                        cboLevel.Items.Add(row[0].ToString());
                    }
                    if (!cboCategory.Items.Contains(row[1].ToString()))
                    {
                        cboCategory.Items.Add(row[1].ToString());
                    }
                }
            }
        }

        public void AddToTutorSubjectTable(Tutor t) 
        {
            string sql = "SELECT TutorID FROM Tutors WHERE FirstName = '" + t.FirstName + "' AND Surname = '" +
                    t.Surname + "' AND Email = '" + t.Email + "' AND PhoneNo = '" + t.Phone + "'";
            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();
            string tutorID = dr.GetString(0);
            dr.Close();


            sql = "INSERT INTO Tutor_Subjects (TutorID, SubjectID) VALUES ('" + tutorID + "','" + GetSubjectID() + "')";
            Database.ExecuteNonQuery(sql);

        }
        
       private string GetSubjectID()
        {
            String subject = cboTutorSubjects.Text.Substring(0, 3);

            string sql =    "SELECT SubjectID " +
                            "FROM Subjects " +
                            "WHERE SubjectCode = '" + subject + 
                            "' AND SubjectLevel = '" + cboLevel.Text + 
                            "' AND SubjectCategory = '" + cboCategory.Text + "'";

            OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);
            dr.Read();

            string sub = dr.GetInt32(0).ToString();

            dr.Close();

            return sub;
        }*/
    }
}