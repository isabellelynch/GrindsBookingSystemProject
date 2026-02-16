using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace GrindsBookingSystem
{
    public partial class frmUpdateStudent : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        public frmUpdateStudent()
        {
            InitializeComponent();
            Reset(this.Controls);
        }
        private void btnFindStudent_Click(object sender, EventArgs e)
        {
            grpStudentDetails.Visible = true;

            if (cboStudentID.Items.Count > 1)
            {
                return;
            }

            Student s = Student.GetStudent(Convert.ToInt32(cboStudentID.Items[0]));

            txtEmail.Text = s.Email;
            txtPhone.Text = s.Phone;
            txtFirstName.Text = s.FirstName;
            txtLastName.Text = s.Surname;

            ControlFunctions.DisableBoxes(cboNames, cboSurnames, cboStudentID);
        }
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student(txtFirstName.Text, txtLastName.Text,txtEmail.Text, txtPhone.Text);

            s.SetID(cboStudentID.Text);


            if (s.IsValid() != "Valid")
            {
                MessageBox.Show(s.IsValid()
                    , "Invalid Details Entered",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Student s2 = Student.GetStudent(Convert.ToInt32(s.PersonID));
            s2.SetID(s.PersonID);

            if (s2 == null)
            {
                return;
            }
            else if (s == s2)
            {
                MessageBox.Show("No Details Changed, Goodbye"
                    , "Goodbye",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                s2.Email = s.Email;
                s2.Phone = s.Phone;
                s2.Surname = s.Surname;
                s2.FirstName = s.FirstName;
                try
                {
                    s2.Update();


                    MessageBox.Show("The selected Student has been updated and their details are now as follows\n\n" +
                            s2.ToString(), "Student Updated Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            Reset(this.Controls);
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

            if (cbo == cboStudentID)
            {
                ControlFunctions.ApplyFilters("'" + cboStudentID.Text + "'", "StudentID", "Students", cboStudentID, cboNames, cboSurnames);
            }
            else if (cbo == cboNames)
            {
                ControlFunctions.ApplyFilters("'" + cboNames.Text + "'", "FirstName", "Students", cboStudentID, cboNames, cboSurnames);
            }
            else if (cbo == cboSurnames)
            {
                ControlFunctions.ApplyFilters("'" + cboSurnames.Text + "'", "Surname", "Students", cboStudentID, cboNames, cboSurnames);
            }

            updating = false;

        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            grpStudentDetails.Visible = false;

            ControlFunctions.EnableBoxes(cboStudentID, cboNames, cboSurnames);

            ControlFunctions.FillBoxes("Students", cboStudentID, cboNames, cboSurnames);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboNames, cboSurnames);

            foreach (var c in comboBoxes)
            {
                c.SelectedIndexChanged -= ComboBoxChange;
                c.SelectedIndexChanged += ComboBoxChange;
            }
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
