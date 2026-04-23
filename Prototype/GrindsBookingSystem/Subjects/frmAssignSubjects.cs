
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
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

            dgvSubjects.DataSource = Subject.GetSubjectDescriptions();

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

        private void btnAssignSubject_Click(object sender, EventArgs e)
        {
            String sub = dgvSubjects.CurrentCell.Value.ToString();

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
            else if (sub == null) 
            {
                ErrorMessage("A subject must be selected to continue");
                return;
            }
            else
            {
                string tutorID = cboTutorID.Text;
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

                string id = Subject.GetSubjectID(level, cert, sub);

                if (id == "") 
                {
                    DialogResult result = MessageBox.Show("No matching Subject found. Would you like to add this subject to the system ?", "Subject Not Found"
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
                    try
                    {
                        Subject.AddToTutorSubjectTable(tutorID, id);

                        SuccessMessage(sub + " successfully assigned to tutor " + cboFirstName.Text + " " + cboSurname.Text);
                    }
                    catch (Exception) 
                    {
                        ErrorMessage("Unable to assign subject to this tutor.");
                    }
                    
                }

                Reset(this.Controls);

            }
        }

        private void btnSelectTutor_Click(object sender, EventArgs e)
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
    }
}
