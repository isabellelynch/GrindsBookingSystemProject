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

            ControlFunctions.DisableBoxes(cboFirstName, cboSurname, cboStudentID);
        }
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student(txtFirstName.Text, txtLastName.Text,txtEmail.Text, txtPhone.Text);

            s.SetID(cboStudentID.Text);


            if (s.IsValid() != "Valid")
            {
                ErrorMessage(s.IsValid());
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
                SuccessMessage("No details changed, Goodbye!");
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

                    SuccessMessage("The selected Student has been updated and their details are now as follows\n\n" + s2.ToString());
                }
                catch (Exception ex)
                {
                    ErrorMessage(ex.Message);
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

            ControlFunctions.Filters("Student", cbo, cboStudentID, cboFirstName, cboSurname);

            updating = false;

        }

        protected override void Reset(Control.ControlCollection controls)
        {
            base.Reset(controls);

            grpStudentDetails.Visible = false;

            ControlFunctions.EnableBoxes(cboStudentID, cboFirstName, cboSurname);

            ControlFunctions.FillBoxes("Students", cboStudentID, cboFirstName, cboSurname);

            comboBoxes = ControlFunctions.CreateComboList(cboStudentID, cboFirstName, cboSurname);

            foreach (var c in comboBoxes)
            {
                c.SelectedIndexChanged -= ComboBoxChange;
                c.SelectedIndexChanged += ComboBoxChange;
            }
        }
    }
}
