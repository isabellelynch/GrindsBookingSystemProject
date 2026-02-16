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
                MessageBox.Show(s.IsValid() + "\nPlease make the necessary changes to the information and try again",
                    "Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you wish to add student " + txtStudentName.Text + " " +
                                                    txtStudentSurname.Text + "to the system ?",
                                                    "Please Confirm",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    s.Create();
                    MessageBox.Show("Student " + txtStudentName.Text + txtStudentSurname.Text + "has been succesfully added to the system.",
                                "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    
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
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Adding Student Function Cancelled",
                                "Cancelled",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Warning);
            }

            Reset(this.Controls);

            return;
        }


       

        private void exitBtnAddStudent_Click(object sender, EventArgs e)
        {
            Exit();
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reset(this.Controls);
        }

        private void backBtnAddStudent_Click(object sender, EventArgs e)
        {
            GoHome();
        }
    }
}