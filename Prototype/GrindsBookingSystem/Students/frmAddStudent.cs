using System;
using System.Windows.Forms;

namespace GrindsBookingSystem
{
    public partial class frmAddStudent : BaseForm
    {
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            Student s = new Student(txtStudentName.Text, txtStudentSurname.Text, txtStudentEmail.Text, txtStudentPhone.Text);

            if (s.IsValid() != "Valid")
            {
                ErrorMessage(s.IsValid() + "\nPlease make the necessary changes to the information and try again");
                return;
            }

            try
            {
                s.Create();

                SuccessMessage("Student " + txtStudentName.Text + " " + txtStudentSurname.Text + "has been succesfully added to the system.");
                    
                DialogResult addAnother = MessageBox.Show("Would you like to add another Student?",
                                                    "Please Confirm",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
                if (addAnother == DialogResult.No)
                {
                    GoHome();
                }
            }
            catch(Exception ex)
            {
                ErrorMessage(ex.Message);
            }

            Reset(this.Controls);
        }
    }
}