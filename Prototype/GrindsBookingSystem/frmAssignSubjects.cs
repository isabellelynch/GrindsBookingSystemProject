
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmAssignSubjects : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmAssignSubjects()
        {
            InitializeComponent();
            Reset(this.Controls);
        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            grpSubjects.Visible = false;
            ControlFunctions.EnableBoxes(cboTutorID, cboFirstName, cboSurname);

            ControlFunctions.FillBoxes("Tutors", cboTutorID, cboFirstName, cboSurname);

            comboBoxes = ControlFunctions.CreateComboList(cboTutorID, cboFirstName, cboSurname);

            foreach (ComboBox cb in comboBoxes)
            {
                cb.SelectedIndexChanged -= ComboBoxChange;
                cb.SelectedIndexChanged += ComboBoxChange;
            }

            string sql = "SELECT DISTINCT Description FROM Subjects";
            DataSet ds = Database.ExecuteMultiRowQuery(sql);
            dgvSubjects.DataSource = ds.Tables[0];

            GridViews.Default(dgvSubjects);
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

            ControlFunctions.Filters("Tutor", cbo, cboTutorID, cboFirstName, cboSurname);

            updating = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cboTutorID.Items.Count > 1)
            {
                ErrorMessage("Please select a single tutor in order to assign a subject to them.");
            }
            else
            {
                grpSubjects.Visible = true;
                ControlFunctions.DisableBoxes(cboTutorID, cboFirstName, cboSurname);
            }
        }

        private void btnAssignSubject_Click(object sender, EventArgs e)
        {
            if(!radioJunior.Checked && !radioLeaving.Checked)
            {
                ErrorMessage("Please select Leaving or Junior Certificate to continue.");
                return;
            }
            else if (!radioHigher.Checked && !radioOrdinary.Checked)
            {
                ErrorMessage("Please select ordinary or Higher Level to continue.");
                return;
            }
            else if (dgvSubjects.SelectedRows.Count == 0) 
            {
                ErrorMessage("A subject must be selected to continue");
                return;
            }
            else
            {
                string tutorID = cboTutorID.Text;
                string subID = "";
                string level = "HL";
                string cert = "LC";
                if (radioOrdinary.Checked)
                {
                    level = "OL";
                }
                if (radioJunior.Checked)
                {
                    cert = "JC";
                }

                DataGridViewRow dgvr = dgvSubjects.SelectedRows[0];

                string sql = "SELECT SubjectID " +
                            "FROM Subjects " +
                            "WHERE Description = '" + dgvr.Cells[0].Value.ToString() +
                            "' AND SubjectLevel = '" + level +
                            "' AND SubjectCategory = '" + cert + "'";

                OracleDataReader dr = Database.ExecuteSingleRowQuery(sql);

                if (!dr.Read()) 
                {
                    DialogResult result = MessageBox.Show("No matching SubjectID found. Would you like to add this subject to the system ?", "Subject Not Found"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes) 
                    {
                        Form f = new frmAddSubject();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        Refresh();
                        return;
                    }
                        
                }
                else
                {
                    subID = dr.GetInt32(0).ToString();
                    sql = "INSERT INTO Tutor_Subjects (TutorID, SubjectID) VALUES ('" + tutorID + "','" + subID + "')";
                    Database.ExecuteNonQuery(sql);
                    SuccessMessage(dgvr.Cells[0].Value.ToString() + " successfully assigned to tutor " + cboFirstName.Text + " " + cboSurname.Text);
                }

                dr.Close();

                Reset(this.Controls);



            }
        }
    }
}
