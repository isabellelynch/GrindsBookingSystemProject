using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace GrindsBookingSystem
{
    public partial class frmUpdateStudent : BaseForm
    {
        List<ComboBox> comboBoxes;
        private bool updating = false;
        Student s = new Student();
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

            int id = Convert.ToInt32(cboStudentID.Items[0]);

            Student s = Student.GetStudent(id);
            
            s.SetID(s.PersonID);

            txtEmail.Text = s.Email;
            txtPhone.Text = s.Phone;
            txtFirstName.Text = s.FirstName;
            txtLastName.Text = s.Surname;

            ControlFunctions.DisableBoxes(cboFirstName, cboSurname, cboStudentID);
        }
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            s.Email = txtEmail.Text;
            s.Phone = txtPhone.Text;
            s.Surname = txtLastName.Text;
            s.FirstName = txtFirstName.Text;

            if (s.IsValid() != "Valid")
            {
                ErrorMessage(s.IsValid());
                return;
            }

            try
            {
                s.Update();

                SuccessMessage("The selected Student has been updated and their details are now as follows\n\n" + s.ToString());
            }
            catch (Exception ex)
            {
                ErrorMessage(ex.Message);
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
