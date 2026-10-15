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

            if (s.IsValid() == "Valid")
            {
                if (Student.DoesStudentExist(s.Email) == false)
                { 
                    try
                    {
                        s.Create();

                        SuccessMessage("Student " + txtStudentName.Text + " " + txtStudentSurname.Text + " has been successfully added to the system.");
                    
                        DialogResult addAnother = CustomDialogMessageBox.Show("Would you like to add another Student?");

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
                else
                {
                    ErrorMessage("Student with the email " + s.Email + " already exists on the system.");
                }
            }
            else
            {
                ErrorMessage(s.IsValid() + "\nPlease make the necessary changes to the information and try again");
            }
        }
    }
}